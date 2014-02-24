using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using ProtoTest.TestRunner.Nightshade;
using System.Configuration;


namespace ProtoTest.Nightshade
{
    public static class Config
    {
        public static int ElementTimeoutSec = int.Parse(Config.GetConfigValue("ElementTimeoutSec", "30"));
        public static string BatchFilePath = Directory.GetCurrentDirectory() + "\\StartDrive.bat";
        public static int DriveTimeoutSec = int.Parse(Config.GetConfigValue("DriveTimeoutSec","60"));
        public static int WaitForDriveMs = int.Parse(Config.GetConfigValue("WaitForDriveMs", "10000"));
        public static string BaseImageDir = Common.GetCodeDirectory();
        public static List<string> Hosts
        {
            //looks in app.config for Host1, Host2....Host5.  
            get { 
                var list = new List<string>();
                for (var i = 1; i < 6; i ++)
                {
                    string value = GetConfigValue("Host" + i, "Null");
                   if(value!="Null")
                    {
                        list.Add(value);
                    }
                }
                return list;
            }
        }


        /// <summary>
        /// Returns the App.config value for requested key, or default value if not defined.
        /// </summary>
        /// <param name="key">Application configuration key</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static string GetConfigValue(string key, string defaultValue)
        {
            string setting = ConfigurationSettings.AppSettings[key];
            if (setting == null)
            {
                return defaultValue;
            }

            return setting;
        }

        /// <summary>
        /// Updates the App.config setting key with value
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
