using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public static class Config
    {

        public static string DeviceType = GetConfigValue("DeviceType", "null");
        public static string Host1Type = GetConfigValue("Host1Type", "null");
        public static string Host2Type = GetConfigValue("Host2Type", "null");
        public static string Host1Ip = GetConfigValue("Host1Ip", "localhost");
        public static string Host2Ip = GetConfigValue("Host2Ip", "localhost");
        public static int ElementWaitSec = int.Parse(GetConfigValue("ElementWaitTime", "5"));
        public static int ElementSearchTime = int.Parse(GetConfigValue("ElementSearchTime", "1"));
        public static string RunScriptPath = GetConfigValue("RunScriptPath", @"C:\Program Files (x86)\eggPlant\runscript.bat");
        public static string BatchFilePath = Directory.GetCurrentDirectory() + "\\StartDrive.bat";
        public static int DriveTimeoutSec = int.Parse(GetConfigValue("DriveTimeoutSec", "60"));
        public static int WaitForDriveMs = int.Parse(GetConfigValue("WaitForDriveMs", "30000"));
        public static string SuitePath = GetConfigValue("SuitePath", Common.GetCodeDirectory() + @"\Suites\MotorolaMaster.suite");
        public static int DelayTimeMs = int.Parse(GetConfigValue("DelayTimeMs", "200"));
        public static int Host1Port = int.Parse(GetConfigValue("Host1Port", "5900"));
        public static int Host2Port = int.Parse(GetConfigValue("Host2Port", "5900"));
        public static bool AutoCaptureScreen = IsTruthy(GetConfigValue("AutoCaptureScreen", "True"));
        public static bool RecordVideo = IsTruthy(GetConfigValue("RecordVideo", "False"));
        public static int ImageSearchCount = int.Parse(Config.GetConfigValue("ImageSearchCount", "1"));
        public static bool LogDriveCommands = IsTruthy(Config.GetConfigValue("LogDriveCommands", "False"));
        public static int VideoFrameRate = int.Parse(Config.GetConfigValue("VideoFrameRate", "20"));
        public static int ClickExecuteDelay = int.Parse(Config.GetConfigValue("ClickExecuteDelay", "10"));
        public static string MouseClickDelay = Config.GetConfigValue("MouseClickPressTime", "0.02");

        public static int CalendarAppointmentsIterations = int.Parse(Config.GetConfigValue("CalendarAppointmentsIterations", "5"));
        public static string AudioTestFileNamePrefix = GetConfigValue("AudioTestFileNamePrefix", "Audio Test ");
        public static string DefaultWifiNetworkName = GetConfigValue("DefaultWifiNetworkName", "null");
        public static string DeleteContactsStarting = GetConfigValue("DeleteContactsStarting", "null");
        public static string DeleteContactsTotalCount = GetConfigValue("DeleteContactsTotalCount", "null");
        public static string DownloadAppTestPath = GetConfigValue("DownloadAppTestPath", "null");
  
        /// <summary>
        ///     Returns the App.config value for requested key, or default value if not defined.
        /// </summary>
        /// <param name="key">Application configuration key</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static string GetConfigValue(string key, string defaultValue)
        {
            #pragma warning disable 618
            string setting = ConfigurationSettings.AppSettings[key];
            #pragma warning restore 618
            if (setting == null)
            {
                return defaultValue;
            }

            return setting;
        }
        /// <summary>
        /// Converts from string to boolean 
        /// </summary>
        /// <param name="truth"></param>
        /// <returns></returns>
        public static bool IsTruthy(string truth)
        {
            switch (truth)
            {
                case "1":
                case "true":
                case "True":
                    return true;
                case "0":
                case "false":
                case "False":
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Updates the App.config setting key with value
        /// </summary>
        /// <param name="key">Application configuration key</param>
        /// <param name="value">Application configuration key value to set</param>
        public static void UpdateConfigFile(string key, string value)
        {
            var doc = new XmlDocument();
            string path = Assembly.GetCallingAssembly().Location + ".config";
            doc.Load(path);
            doc.SelectSingleNode("//add[@key='" + key + "']").Attributes["value"].Value = value;
            doc.Save(path);

            path = Directory.GetCurrentDirectory().Replace(@"\bin\Debug", "").Replace(@"\bin\Release", "") +
                   "\\App.config";
            doc.Load(path);
            doc.SelectSingleNode("//add[@key='" + key + "']").Attributes["value"].Value = value;
            doc.Save(path);
        }
    }
}