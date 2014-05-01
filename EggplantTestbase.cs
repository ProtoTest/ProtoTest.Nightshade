﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using Gallio.Model;
using MbUnit.Framework;
using ProtoTest.Nightshade;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantTestBase
    {
        private static Process EggPlantDriveProcess;
        private BackgroundVideoRecorder recorder;
        public static EggplantDriver _Driver;
       
        public static EggplantDriver Driver
        {
            get { return _Driver; }
            set { _Driver = value; }
        }

        [Factory("GetNumRepetitions")]
        public static int SuiteRepetitions;

        public static IEnumerable<int> GetNumRepetitions()
        {
            var num = int.Parse(Config.GetConfigValue("SuiteRepetitions", "1"));
            for (var i = 1; i <= num; i++)
            {
                yield return i;
            }
        }

        public void SkipThisTest(string message)
        {
            throw new SilentTestException(TestOutcome.Skipped, message);
        }

        public void SetDefaultSearchTime()
        {
            Driver.Execute("set the ImageSearchTime to " + Config.ElementSearchTime);
            Driver.Execute("set the ImageSearchCount to " + Config.ImageSearchCount);

        }

        public void ConnectToHost1()
        {
            Config.DeviceType = Config.Host1Type;
            Driver.Connect(Config.Host1Ip,Config.Host1Port.ToString());
   
        }

        public void ConnectToHost2()
        {
            Config.DeviceType = Config.Host2Type;
            Driver.Connect(Config.Host2Ip, Config.Host2Port.ToString());
            
        }

        public void StartVideoRecording()
        {
            if (Config.RecordVideo)
            {
                recorder = new BackgroundVideoRecorder(Config.VideoFrameRate);
                recorder.Start();    
            }
            
        }

        public void StopVideoRecording()
        {
            if (Config.RecordVideo)
            {
                recorder.Stop();
                recorder.Dispose();
                Thread.Sleep(1000);
                TestLog.EmbedVideo(TestStep.CurrentStep.FullName + "_Video", recorder.video);    
            }
            
        }

        public static void Log(string message)
        {
            message = string.Format("({0}): {1}", DateTime.Now.ToString("H:mm:ss:FFF"), message);
            TestLog.WriteLine(message);
            DiagnosticLog.WriteLine(message);
        }

        public static void Info(string message)
        {
            message = string.Format("|   {0}", message);
            TestLog.WriteLine(message);
            DiagnosticLog.WriteLine(message);
        }

        private void LogScreenshotOnError()
        {
            if (TestContext.CurrentContext.Outcome != TestOutcome.Passed)
            {
                var screenshot = Driver.GetScreenshot();
                if (screenshot != null)
                {
                    TestLog.Failures.EmbedImage(null, screenshot);
                }
            }
        }

        public void StopEggplant()
        {
          try
          {
              if (EggPlantDriveProcess != null)
              {
                  EggPlantDriveProcess.CloseMainWindow();
                  EggPlantDriveProcess.WaitForExit();
                  EggPlantDriveProcess = null;
              }
              Driver.StopEggPlantDrive();
          }
          catch (Exception e)
          {
              TestLog.Warnings.WriteLine("Exception trying to stop eggplant : " + e.Message);
          }
           
        }

        public void StartEggplant()
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    EggPlantDriveProcess = Driver.StartEggPlantDrive(Config.BatchFilePath, Config.WaitForDriveMs);
                    Driver.WaitForDriveToLoad(Config.WaitForDriveMs);
                    SetDefaultSearchTime();
                    Driver.SetOption("MouseClickDelay", Config.MouseClickDelay);
                    return;
                }
                catch (Exception e)
                {
                    TestLog.Warnings.WriteLine("Could not start Eggplant, trying again.");
                    StopEggplant();
                }
                
            }
            TestLog.Warnings.WriteLine("Eggplant drive did not appear to launch after 5 attempts");
        }

        private void VerifyEnvironment()
        {
            if (!System.IO.Directory.Exists(Config.SuitePath))
            {
                Assert.Fail("Cannot find suite located at : " + Config.SuitePath + " Add an App.Config key 'SuitePath' with the correct locatijon of your Eggpplant .suite folder");
            }
            if (!System.IO.File.Exists(Config.RunScriptPath))
            {
                Assert.Fail("Cannot find eggplant's runscript.bat at : " + Config.RunScriptPath + " Please add a config key RunScriptPath with the correct location to your App.Config ");
            }
        }

        [FixtureSetUp]
        public void FixtureSetup()
        {
            VerifyEnvironment();
            Config.BatchFilePath = Common.CreateBatchFile();
            TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            Driver = new EggplantDriver(Config.DriveTimeoutSec*1000);
            StopEggplant();
            StartEggplant();
        }


        [FixtureTearDown]
        public void FixtureTeardown()
        {
            StopEggplant();
        }

        public static string LastTestName;

        [SetUp]
        public void SetUp()
        {
            LastTestName = TestContext.CurrentContext.TestStep.FullName; 
        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(1000);
            LogScreenshotOnError();
            Driver.Disconnect();
        }


    }
}