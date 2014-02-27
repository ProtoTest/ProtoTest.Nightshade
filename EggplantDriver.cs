using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using CookComputing.XmlRpc;
using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium.Remote;
using ProtoTest.Nightshade;

namespace ProtoTest.TestRunner.Nightshade
{
    /// <summary>
    ///     Eggplant drive is an RPC service that we can use to execute eggplant commands
    ///     This class wraps all calls to the RPC service with easy to use methods.
    ///     The following methods should be called in the following order:
    ///     StartEggplantDrive, StartSuiteSession, Connect, Execute (or ExecuteScript), EndSession, StopEggplantDrive
    /// </summary>
    public class EggplantDriver
    {
        private readonly IEggplantDriveService driveService;
        public bool driveRunning = false;
        //public bool connectedToDevice = false;
        public string host;
        public string suitePath;
        public bool suiteStarted = false;

        public EggplantDriver(int timeoutMs)
        {
            driveService = (IEggplantDriveService) XmlRpcProxyGen.Create(typeof (IEggplantDriveService));
            driveService.Timeout = timeoutMs;
        }

        /// <summary>
        ///     Starts the eggplantDrive process by executing a batch file, and waiting x number of ms
        /// </summary>
        /// <param name="batchPath"></param>
        /// <param name="waitForDriveMs"></param>
        /// <returns></returns>
        public Process StartEggPlantDrive(string batchPath, int waitForDriveMs)
        {
            try
            {
                DiagnosticLog.WriteLine("Starting Eggplant Drive using batch file : " + batchPath);
                Process cmdProcess = Common.ExecuteBatchFile(batchPath);
                return cmdProcess;
            }
            catch (Exception e)
            {
                Assert.TerminateSilently(TestOutcome.Failed, "Error Starting Eggplant Drive : " + e.Message);
                return null;
            }
        }

        public void WaitForDriveToLoad(int waitForDriveMs)
        {
            for (int i = 1000; i < waitForDriveMs; i = i + 1000)
            {
                try
                {
                    driveService.StartSession(Config.SuitePath);
                    DiagnosticLog.WriteLine("The suite session has started : " + Config.SuitePath);
                    return;
                }
                catch (Exception e)
                {
                    // DiagnosticLog.WriteLine("Waiting for drive : " + i + " " +  e.Message);
                    Thread.Sleep(1000);
                }
            }
            Assert.TerminateSilently(TestOutcome.Failed,
                "Eggplant Drive did not appear to launch after " + waitForDriveMs +
                "ms.  Please verify eggPlant is installed and has a valid license.");
        }

        /// <summary>
        ///     Stops eggplant drive by searching the process list and killing the process named Eggplant
        /// </summary>
        public void StopEggPlantDrive()
        {
            try
            {
                //DiagnosticLog.WriteLine("Trying to stop Eggplant Drive");
                Common.KillProcess("Eggplant");
                driveRunning = false;
            }
            catch (Exception e)
            {
                Assert.TerminateSilently(TestOutcome.Failed, "Exception caught stopping eggplant drive " + e.Message);
            }
        }

        /// <summary>
        ///     Runs a .script file.  A suite session should already have been started, so only pass the name of the script, not
        ///     the path
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="description"></param>
        public void ExecuteScript(string scriptName, string description)
        {
            DiagnosticLog.WriteLine("Executing test : " + scriptName);
            TestLog.WriteLine(description);
            driveService.Execute("RunWithNewResults(" + scriptName + ")");
        }

        /// <summary>
        ///     Connects to a device, must be run before any steps can be executed.
        /// </summary>
        /// <param name="host"></param>
        public void Connect(string host)
        {
            var msg = "";
            for (var i = 1; i <= 5; i++)
            {
                try
                {
                    DiagnosticLog.WriteLine("Trying to connect to device (" + i + ") : " + host);
                    Execute("Connect (ServerID:\"10.10.1.167\", Visible:\"True\")");
                    DiagnosticLog.WriteLine("Connection established to device : " + GetConnectionInfo());
                    return;
                }
                catch (Exception e)
                {
                    msg = e.Message;
                }
                
            }
            Assert.TerminateSilently(TestOutcome.Failed,
                       "Error caught connecting to device.  Check the internet connection and try connecting via Eggplant GUI : " +
                       host + " : " + msg);
            
        }

        /// <summary>
        ///     Connects to a device, must be run before any steps can be executed.
        /// </summary>
        /// <param name="host"></param>
        public void Disconnect(string host)
        {
            try
            {
                DiagnosticLog.WriteLine("Trying to disconnect from device : " + host);
                driveService.Execute("Disconnect (name:\"" + host + "\")");
            }
            catch (Exception e)
            {
                Assert.TerminateSilently(TestOutcome.Failed,
                    "Error caught connecting to device.  Check the internet connection and try connecting via Eggplant GUI : " +
                    host + " : " + e.Message);
            }
        }

        public void CaptureScreenshot(string path = "")
        {
            if (path == "")
                path = Directory.GetCurrentDirectory() + "\\screenshot";
            driveService.Execute("CaptureScreen(Name:\"" + path + "\", increment:yes)");
        }

        /// <summary>
        ///     Executes any SenseTalk command.  Full list of commands available in eggplant drive documentation.
        /// </summary>
        /// <param name="command"></param>
        public XmlRpcStruct Execute(string command)
        {
            try
            {
                DiagnosticLog.WriteLine("Executing command : " + command);
                //return new object();
                return driveService.Execute(command);
            }
            catch (Exception e)
            {
                Assert.TerminateSilently(TestOutcome.Failed,
                    "Error caught executing command " + command + " : " + e.Message);
                return null;
            }
        }

        /// <summary>
        ///     Executes any SenseTalk command.  Full list of commands available in eggplant drive documentation.
        /// </summary>
        /// <param name="command"></param>
        public string ExecuteAndGetOutput(string command)
        {
            try
            {
                var rpc = Execute(command);
                var output = (string) rpc["Output"];
                return output.TrimEnd("\r\n".ToCharArray());
            }
            catch (Exception e)
            {
                Assert.TerminateSilently(TestOutcome.Failed,
                    "Error caught getting output " + command + " : " + e.Message);
                return null;
            }
        }



        /// <summary>
        ///     Ends a suite session.  Should be called before Stopping Drive, or when changing suites.
        /// </summary>
        public void EndSuiteSession()
        {
            try
            {
                DiagnosticLog.WriteLine("Ending Eggplant Session");
                driveService.EndSession();
            }
            catch (Exception e)
            {
                Assert.TerminateSilently(TestOutcome.Failed,
                    "Exception Caught Ending EggPlant Session for suite : " + suitePath + e.Message);
            }
        }

        /// <summary>
        ///     Starts a Suite Session. Should be called before executing any commands.
        /// </summary>
        /// <param name="suitePath"></param>
        public void StartSuiteSession(string suitePath)
        {
            try
            {
                this.suitePath = suitePath;
                DiagnosticLog.WriteLine("Starting eggplant session for suite : " + suitePath);
                driveService.StartSession(suitePath);
            }
            catch (Exception e)
            {
                Assert.TerminateSilently(TestOutcome.Failed,
                    "Exception Caught Starting EggPLant Session for suite : " + suitePath +
                    " Check the log to see if drive started correctly : " + e.Message);
            }
        }

        public object ExecuteCommand(string command, string[] args = null)
        {
            for (int i = 0; i < args.Length; i++)
            {
                command = command += " {" + i + ")";
            }
            return Execute(string.Format(command, args));
        }

        public object ExecuteCommand(string command, string arg)
        {
            return Execute(string.Format(command + " {0}", arg));
        }

        public object ExecuteCommand(string command, string firstArg, string secondArg)
        {
            return Execute(string.Format(command + " {0} {1}", firstArg, secondArg));
        }

        public void Click(string element)
        {
            ExecuteCommand("Click", element);
        }

        public void Drag(string element)
        {
            ExecuteCommand("Drag", element);
        }

        public void Drop(string element)
        {
            ExecuteCommand("Drop", element);
        }

        public void DragAndDrop(string fromElement, string toElement)
        {
            Drag(fromElement);
            Drop(toElement);
        }

        public void Wait(int ms)
        {
            DiagnosticLog.WriteLine(string.Format("Waiting {0} ms", ms));
            Thread.Sleep(ms);
        }

        public void WaitFor(string element)
        {
            ExecuteCommand("WaitFor", element);
        }

        public void WaitFor(string element, string timeoutSec)
        {
            ExecuteCommand("WaitFor " + timeoutSec + ",", element);
        }

        public void RightClick(string element)
        {
            ExecuteCommand("RightClick", element);
        }

        public bool IsPresent(string element)
        {
            return (bool)ExecuteCommand("ImageFound", element);
        }

        public void Type(string text)
        {
            ExecuteCommand("TypeText", text);
        }

        public void Type(List<string> listOfText)
        {
            string commands = listOfText[0];
            for(var i=1;i<listOfText.Count;i++)
            {
                commands += ", " + listOfText[0];
            }
            ExecuteCommand("TypeText", commands);
        }

        public void ScrollUp(string num)
        {
            ExecuteCommand("ScrollWheelUp", num);
        }

        public void ScrollDown(string num)
        {
            ExecuteCommand("ScrollWheelDown", num);
        }

        public Image GetScreenshot()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\Screenshot.png";
            ExecuteCommand("CaptureScreen", string.Format("(Name: \"{0}\")", filePath));
            if (File.Exists(filePath))
            {
                return Image.FromFile(filePath);
            }
            return Capture.Screenshot();
        }

        public void LogScreenshot()
        {
            TestLog.EmbedImage(null, GetScreenshot());
        }

        public string ReadText(string element)
        {
            return ExecuteAndGetOutput(string.Format("ReadText ((\"{0}\"))", element));
        }

        public SearchRectangle GetScreenRectangle()
        {
            var output = ExecuteAndGetOutput("put RemoteScreenRectangle()");
            output = output.TrimStart('(').TrimEnd("\r\n".ToCharArray()).TrimEnd(')');
            var toks = output.Split(',');
            Point lowerRight = new Point(int.Parse(toks[2]), int.Parse(toks[3]));
            Point upperLeft = new Point(0,0);
            return new SearchRectangle(upperLeft, lowerRight);
        }

        public string GetConnectionInfo()
        {
            return ExecuteAndGetOutput("put ConnectionInfo()");
        }

        public void HighlightRectangle(SearchRectangle rectangle)
        {
                Execute(string.Format("HighlightRectangle ({0},{1},{2},{3}), (Color: Red, Duration: 30 seconds)", rectangle.upperLeft.X,
                    rectangle.upperLeft.Y, rectangle.lowerRight.X, rectangle.lowerRight.Y));
            EggplantTestBase.Driver.LogScreenshot();
        }
    }
}