using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using CookComputing.XmlRpc;
using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
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

        public EggplantDriver(int timeoutMs = -1)
        {
            if (timeoutMs == -1)
            {
                timeoutMs = Config.DriveTimeoutSec * 1000;
            }
            driveService = (IEggplantDriveService)XmlRpcProxyGen.Create(typeof(IEggplantDriveService));
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
                driveRunning = true; 
                return cmdProcess;
            }
            catch (Exception e)
            {
                TestLog.Warnings.WriteLine("Error Starting Eggplant Drive : " + e.Message);
                return null;
            }
        }

        public void WaitForDriveToLoad(int waitForDriveMs)
        {
            DiagnosticLog.WriteLine("Waiting for drive");
            for (int i = 0; i < waitForDriveMs; i = i + 1000)
            {
                try
                {
                    driveService.StartSession(Config.SuitePath);
                    DiagnosticLog.WriteLine("The suite session has started : " + Config.SuitePath);
                    return;
                }
                catch (Exception e)
                {
                   // Thread.Sleep(1000);
                }
            }
            TestLog.Warnings.WriteLine("Eggplant Drive did not appear to launch after " + waitForDriveMs +
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
                Common.KillProcess("adb");
                driveRunning = false;
            }
            catch (Exception e)
            {
                TestLog.Warnings.WriteLine("Eggplant Drive could not be properly stopped.  Message returned: (" + e.Message + ").");
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
        public void Connect(string host, string port = "5900")
        {
            for (var i = 1; i <= 5; i++)
            {
                try
                {
                    TestLog.WriteLine("Trying to connect to device (" + i + ") : " + host);
                    DiagnosticLog.WriteLine("Trying to connect to device (" + i + ") : " + host);
                    if (port == "0")
                    {
                        Execute(string.Format("Connect (ServerID:\"{0}\")", host));
                    }
                    else
                    {
                        Execute(string.Format("Connect (ServerID:\"{0}\", portNum: \"{1}\")", host, port));
                    }
                    
                    DiagnosticLog.WriteLine("Connection established to device : " + GetConnectionInfo());
                    return;
                }
                catch (Exception e)
                {
                    DiagnosticLog.WriteLine("Could not connect, retrying : " + e.Message);
                }
                
            }
           TestLog.Warnings.WriteLine("Error caught connecting to device.  Check the internet connection and try connecting via Eggplant GUI : " + host);
        }

        /// <summary>
        ///     Connects to a device, must be run before any steps can be executed.
        /// </summary>
        /// <param name="host"></param>
        public void Disconnect(string host="")
        {
            try
            {
                DiagnosticLog.WriteLine("Trying to disconnect from device : " + host);
                driveService.Execute("Disconnect " + host);
            }
            catch (Exception e)
            {
                TestLog.Warnings.WriteLine(
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
            if (Config.LogDriveCommands)
            {
                EggplantTestBase.Log(string.Format("Executing command: {0}", command));
            }
            return driveService.Execute(command);
        }

        /// <summary>
        ///     Executes any SenseTalk command.  Full list of commands available in eggplant drive documentation.
        /// </summary>
        /// <param name="command"></param>
        public string ExecuteAndGetOutput(string command)
        {
            var rpc = Execute(command);
            var output = (string)rpc["Output"];
            return output.TrimEnd("\r\n".ToCharArray());
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
                TestLog.Warnings.WriteLine("Exception Caught Ending EggPlant Session for suite : " + suitePath + e.Message);
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
                TestLog.Warnings.WriteLine("Exception Caught Starting EggPLant Session for suite : " + suitePath +
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
            Thread.Sleep(Config.ClickExecuteDelay);
            ExecuteCommand("Click", element);
        }

        public void Tap(string element)
        {
            ExecuteCommand("Tap", element);
        }

        public void DoubleTap(string element)
        {
            ExecuteCommand("DoubleTap", element);
        }

        public void Press(string element)
        {
            ExecuteCommand("Press", element);
        }

        public void Release(string element)
        {
            ExecuteCommand("Release", element);
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
            ExecuteCommand("WaitFor " + Config.ElementWaitSec + ",", element);
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
            var output = ExecuteAndGetOutput(string.Format("put ImageFound {0}", element));
            return output.Contains("True");
        }

        public void Type(string text)
        {
            text = "\"" + text + "\"";
            ExecuteCommand("TypeText", text);
            EggplantTestBase.Info("Driver - Typing text: (" + text + ").");
            Thread.Sleep(2000);
        }

        public void Type(List<string> listOfText)
        {
            string commands = listOfText[0];
            for(var i=1;i<listOfText.Count;i++)
            {
                commands += ", " + listOfText[0];
            }
            ExecuteCommand("TypeText", commands);
            Thread.Sleep(2000);
        }

        public void PressKey(string text)
        {
            //text = "\"" + text + "\"";
            ExecuteCommand("TypeText", text);
            EggplantTestBase.Info("Driver - Pressing keyboard key: (" + text + ").");
            Thread.Sleep(2000);
        }

        public void ScrollWheelUp(string num)
        {
            ExecuteCommand("ScrollWheelUp", num);
        }

        public void ScrollWheelDown(string num)
        {
            ExecuteCommand("ScrollWheelDown", num);
        }

        public void SwipeDown(Point origin = default(Point))
        {
            if(origin == default(Point))
                origin = new Point(SearchRectangle.FullScreen.width / 2, SearchRectangle.FullScreen.height / 2);
            ExecuteCommand("SwipeDown", "(" + origin.X + "," + origin.Y + ")");
        }

        public void SwipeUp(Point origin = default(Point))
        {
            if (origin == default(Point))
                origin = new Point(SearchRectangle.FullScreen.width / 2, SearchRectangle.FullScreen.height / 2);
            ExecuteCommand("SwipeUp", "(" + origin.X + "," + origin.Y + ")");
        }

        public void SwipeLeft(Point origin = default(Point))
        {
            if (origin == default(Point))
                origin = new Point(SearchRectangle.FullScreen.width / 2, SearchRectangle.FullScreen.height / 2);
            ExecuteCommand("SwipeLeft", "(" + origin.X + "," + origin.Y + ")");
        }

        public void SwipeRight(Point origin = default(Point))
        {
            if (origin == default(Point))
                origin = new Point(SearchRectangle.FullScreen.width / 2, SearchRectangle.FullScreen.height / 2);
            ExecuteCommand("SwipeRight", "(" + origin.X + "," + origin.Y + ")");
        }

        public Image GetScreenshot(string filePath = "")
        {
            if (filePath == "")
            {
                 filePath = string.Format("{0}\\Screenshot.png", Directory.GetCurrentDirectory());    
            }
            
            try
            {
                ExecuteCommand("CaptureScreen", string.Format("(Name: \"{0}\")", filePath));
                Image image = null;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                   image = Image.FromStream(fs);
                }
                return image;
            }
            catch (Exception e)
            {
                DiagnosticLog.WriteLine("Error capturing image : " + e.Message);
            }
            return null;
        }

        public void LogScreenshot()
        {
            
            string screenshotDir = Directory.GetCurrentDirectory() + "\\Screenshots\\";
            string screenshotPath = screenshotDir + "Screenshot_" + DateTime.Now.ToString("yymmddhhmmssff") + ".png";
            var screenshot = GetScreenshot(screenshotPath);
            if (!Directory.Exists(screenshotDir))
            {
                Directory.CreateDirectory(screenshotDir);
            }
            if (screenshot == null)
            {
                TestLog.Warnings.WriteLine("Could not get screenshot.");
                return;
            }
            TestLog.EmbedImage(null, screenshot);

        }

        public string ReadText(string element)
        {
            //EggplantTestBase.Log(string.Format("Command used is: put ReadText (\"{0}\")", element));
            //return ExecuteAndGetOutput(string.Format("put ReadText (\"{0}\")", element));
            //EggplantTestBase.Log(string.Format("Command used is: put ReadText (40,100),(175,175)"));
            //return ExecuteAndGetOutput(string.Format("put ReadText (40,100),(175,175)"));
           // EggplantTestBase.Log(string.Format("Command used is: put ReadText {0}", element));
            var result = ExecuteAndGetOutput(string.Format("put ReadText {0}", element));
             WaitFor(element);
            var toks = result.Split("\r\n".ToCharArray());
            return toks[toks.Length - 1];
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

        public string GetOptions()
        {
            var output = ExecuteAndGetOutput("put getOptions()");
            return output;
        }

        public string GetOption(string option)
        {
            var output = ExecuteAndGetOutput(string.Format("put getOption({0})",option));
            return output;
        }

        public string SetOption(string option,string value)
        {
            var output = ExecuteAndGetOutput(string.Format("set the {0} to {1}",option,value));
            return output;
        }
    }
}