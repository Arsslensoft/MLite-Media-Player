using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace MLITEMEDIAPLAYER {

    internal static class WinApi
    {
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args)
        {
            string message = String.Format(format, args);
            return RegisterWindowMessage(message);
        }

        public const int HWND_BROADCAST = 0xffff;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImportAttribute("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowToFront(IntPtr window)
        {
            ShowWindow(window, SW_SHOWNORMAL);
            SetForegroundWindow(window);
        }
    }
    internal static class SingleInstance
    {
        public static string AssemblyGuid
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                if (attributes.Length == 0)
                {
                    return String.Empty;
                }
                return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
            }
        }
        public static readonly int WM_SHOWFIRSTINSTANCE =
            WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", AssemblyGuid);
        static Mutex mutex;
        public static bool Start()
        {
            bool onlyInstance = false;
            string mutexName = String.Format("Local\\{0}", AssemblyGuid);

            // if you want your app to be limited to a single instance
            // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
            // string mutexName = String.Format("Global\\{0}", ProgramInfo.AssemblyGuid);

            mutex = new Mutex(true, mutexName, out onlyInstance);
            run = true;
            return onlyInstance;
        }
        public static void ShowFirstInstance()
        {
            WinApi.PostMessage(
                (IntPtr)WinApi.HWND_BROADCAST,
                WM_SHOWFIRSTINSTANCE,
                IntPtr.Zero,
                IntPtr.Zero);

        }
        internal static bool run = false;
        public static void Stop()
        {
            mutex.ReleaseMutex();
            mutex.Close();
            run = false;
        }
    }
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (!SingleInstance.Start())
                {
                    File.WriteAllLines(Application.StartupPath + @"\ARGS.t", Environment.GetCommandLineArgs());
                    SingleInstance.ShowFirstInstance();
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainForm());

                if (SingleInstance.run)
                    SingleInstance.Stop();
            }
            catch
            {

            }
        }
    }
}
