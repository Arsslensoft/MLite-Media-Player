/*****************************
* Functions (by Joshua Park) *
* updated 9/1/2010           *
*****************************/
using System;
using System.Runtime.InteropServices;

public static class Functions {
    [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
    static extern long PathIsURL(string pszPath);

    public static bool validateURL(string url)
    {
                 return true;
    }

    public static string getFileSize(string FilePath, int RoundTo)
    {
        try {
            var FileProperties = new System.IO.FileInfo(FilePath);
            decimal Filesize = default(decimal);
            if (FileProperties.Length < 1024) {
                // Bytes
                return (FileProperties.Length + " B");
            } else if (FileProperties.Length >= 1024 & FileProperties.Length < 1048576) {
                // Kilobytes
                Filesize = Math.Round(Convert.ToDecimal(FileProperties.Length) / 1024, RoundTo);
                return (Filesize + " kB");
            } else if (FileProperties.Length >= 1048576 & FileProperties.Length < 1073741824) {
                // Megabytes
                Filesize = Math.Round(Convert.ToDecimal(FileProperties.Length) / 1048576, RoundTo);
                return (Filesize + " MB");
            } else if (FileProperties.Length >= 1073741824 & FileProperties.Length < 1099511627776L) {
                // Gigabytes
                Filesize = Math.Round(Convert.ToDecimal(FileProperties.Length) / 1073741824, RoundTo);
                return (Filesize + " GB");
            } else if (FileProperties.Length >= 1099511627776L & FileProperties.Length < 1099511627776L) {
                // Terabytes
                Filesize = Math.Round(Convert.ToDecimal(FileProperties.Length) / 1099511627776L, RoundTo);
                return (Filesize + " TB");
            } else {
                return "Not Available";
            }
        } catch (Exception ex) {
            return ("Error: " + ex.Message);
        }
    }

    public static string getFolderName(string fileLocation) {
        try {
            var objInfo = new System.IO.FileInfo(fileLocation);
            return objInfo.Directory.Name;
        } catch(Exception ex) {
            return ex.Message;
        }
    }

    public static string decodeURL(string input) {
        return System.Web.HttpUtility.UrlDecode(input);
    }

    public static string removeZero(string toUse) {
        if (toUse.StartsWith("00") == false) {
            while (toUse.StartsWith("0"))
                toUse = toUse.Remove(0, 1);
            while (toUse.StartsWith(":"))
                toUse = toUse.Remove(0, 1);
        } else {
            toUse = toUse.Remove(0, 1);
        }
        return toUse;
    }

    public static string autoEllipsis(int max, string toUse) {
        if (max < toUse.Length)
            return toUse.Remove(max, toUse.Length - max) + "...";
        else
            return toUse;
    }

    public static string convertTime(double totalSec) {
        string newTime;
        int hour = (int)(totalSec / 3600);
        int min = (int)((totalSec % 3600) / 60);
        int sec = (int)(totalSec % 60);
        if (hour > 0)
            newTime = hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
        else
            newTime = min.ToString("00") + ":" + sec.ToString("00");
        return newTime;
    }
}