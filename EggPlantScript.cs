﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using Gallio.Common.Markup;
using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using ProtoTest.Nightshade;
using Action = Gallio.Common.Action;

namespace ProtoTest.TestRunner.Nightshade
{
    /// <summary>
    ///     This class contains all info related to executing an eggplant script and validating it was successful.
    ///     It is passed an instantiated EggplantDriver.
    /// </summary>
    public class EggplantScript
    {
        private readonly EggplantDriver Driver;
        //private Process cmdProcess;
        public string description;
        public string host;
        public string scriptName;
        public string scriptPath;
        public string suitePath;
        public int timeoutMin;

        public EggplantScript(EggplantDriver Driver, string suitePath, string scriptName, string host, int timeoutMin)
        {
            this.Driver = Driver;
            this.suitePath = suitePath;
            this.scriptName = scriptName;
            this.host = host;
            this.timeoutMin = timeoutMin;
            scriptPath += suitePath + "\\Scripts\\" + scriptName + ".script";
            description = GetCommentsFromScript();
            VerifyScriptExists();
        }

        /// <summary>
        ///     Verify the script file exists
        /// </summary>
        private void VerifyScriptExists()
        {
            Assert.IsTrue(File.Exists(scriptPath), "Test aborted, could not find file : " + scriptPath);
        }

        /// <summary>
        ///     Execute the script and verify it passed
        /// </summary>
        /// <param name="testName"></param>
        /// <returns></returns>
        public TestOutcome ExecuteScriptAndGetOutcome(string testName)
        {
            Action executeTest = delegate
            {
                Driver.Connect(host);
                Driver.ExecuteScript(scriptName, description);
                VerifySuccess();
                AttachTestFiles();
            };

            return TestStep.RunStep(testName, executeTest, new TimeSpan(0, 0, timeoutMin, 0), true, null).Outcome;
        }

        /// <summary>
        ///     Get the test result files and embed them into the report
        /// </summary>
        private void AttachTestFiles()
        {
            TestLog.Attach(new TextAttachment("LogFile.txt", "locator", GetLogFile()));
            TestLog.Attach(new TextAttachment("LogFile.xml", "locator", GetLogXmlFile()));
        }

        /// <summary>
        ///     Gets the LogFile.txt for the current test
        /// </summary>
        /// <returns></returns>
        private string GetLogFile()
        {
            return File.ReadAllText(getResultDirectory() + "\\LogFile.txt");
        }

        /// <summary>
        ///     Gets the LogFile.xml for the current test
        /// </summary>
        /// <returns></returns>
        private string GetLogXmlFile()
        {
            return File.ReadAllText(getResultDirectory() + "\\LogFile.xml");
        }

        /// <summary>
        ///     Gets the path of the results directory
        /// </summary>
        /// <returns></returns>
        private string getResultDirectory()
        {
            string path = "";
            path += suitePath;
            path += "\\Results\\" + scriptName + "\\";
            string[] directories = Directory.GetDirectories(path);
            string biggest = "0";
            foreach (string dir in directories)
            {
                string folder = dir.Replace(path, "");
                folder = folder.Replace("\\", "");
                if (folder.CompareTo(biggest) > 0)
                    biggest = folder;
            }
            return path + "\\" + biggest;
        }

        /// <summary>
        ///     Returns all lines marked as comments in the script file
        /// </summary>
        /// <returns></returns>
        private string GetCommentsFromScript()
        {
            if (!File.Exists(scriptPath))
                throw new FileNotFoundException("Could not find script file at path : " + scriptPath);
            string path = scriptPath;
            var file = new StreamReader(path);
            string line = "";
            string result = "";
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("--"))
                {
                    result += line += "\r\n";
                }
            }
            return result;
        }


        /// <summary>
        ///     Verify the script that ran was successful.  Load the results files and parse them for errors.
        /// </summary>
        private void VerifySuccess()
        {
            DiagnosticLog.WriteLine("Verifying Test : " + scriptName);
            var resultsFile = new XmlDocument();
            string file = getResultDirectory() + "\\LogFile.xml";
            DiagnosticLog.WriteLine("Checking results file : " + file);
            resultsFile.Load(file);
            string result = resultsFile.SelectSingleNode("//property[@name='Status']/@value").Value;
            if (result != "Success")
            {
                DiagnosticLog.WriteLine("Test Failure Detected : " + scriptName);
                TestContext.CurrentContext.IncrementAssertCount();
                TestLog.Failures.BeginSection("EggPlant Error");
                TestLog.Failures.WriteLine(GetFailureMessage());
                if (File.Exists(getResultDirectory() + "\\Screen_Error.png"))
                {
                    TestLog.Failures.EmbedImage(null,
                        Common.ScaleImage(Image.FromFile(getResultDirectory() + "\\Screen_Error.png")));
                }
                TestLog.Failures.End();
                Assert.TerminateSilently(TestOutcome.Failed);
            }
        }

        /// <summary>
        ///     Get the failure message from the LogFile.txt file
        /// </summary>
        /// <returns></returns>
        public string GetFailureMessage()
        {
            string file = getResultDirectory() + "\\LogFile.txt";
            DiagnosticLog.WriteLine("Getting failure reason from file : " + file);
            string line;
            string previous = "";
            using (var reader = new StreamReader(file))
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains("Error"))
                    {
                        var error = new StringBuilder();
                        error.AppendLine(previous);
                        error.AppendLine(line);
                        error.AppendLine(reader.ReadToEnd());
                        return error.ToString();
                    }
                    previous = line;
                    line = reader.ReadLine();
                }

                return "";
            }
        }
    }
}