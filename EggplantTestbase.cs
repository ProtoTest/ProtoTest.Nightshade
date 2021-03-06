﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using Gallio.Model;
using MbUnit.Framework;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    /// <summary>
    /// All test classes should inherit this class.  
    /// Framework functionality is triggered by the [FixtureSetUp] methods
    /// </summary>
    public class EggplantTestBase
    {
        private static Process EggPlantDriveProcess;
        public static EggplantDriver _Driver;
       
        public static EggplantDriver Driver
        {
            get { return _Driver; }
            set { _Driver = value; }
        }

        public static void SkipThisTest(string message)
        {
            throw new SilentTestException(TestOutcome.Skipped, message);
        }

        public static void SetDefaultSearchTime()
        {
            Driver.Execute("set the ImageSearchTime to " + Config.ElementSearchTime);
            Driver.Execute("set the ImageSearchCount to " + Config.ImageSearchCount);
        }

        public static void ConnectToHost1()
        {
            Config.DeviceType = Config.Host1Type;
            Driver.Connect(Config.Host1Ip,Config.Host1Port.ToString());
        }

        public static void ConnectToHost2()
        {
            Config.DeviceType = Config.Host2Type;
            Driver.Connect(Config.Host2Ip, Config.Host2Port.ToString());         
        }

        private static void LogTestState()
        {
            Log.SystemState("Determining test state...");
            if (TestContext.CurrentContext.Outcome == TestOutcome.Passed)
            {
                Log.SystemState("TEST COMPLETE (PASSED).");
                //DiagnosticLog.WriteLine(">>> TEST COMPLETE (PASSED).");
                //TestLog.WriteLine(">>> TEST COMPLETE (PASSED).");
            }
            if (TestContext.CurrentContext.Outcome != TestOutcome.Passed)
            {
                Log.SystemState("TEST FAILED.");
                //DiagnosticLog.WriteLine(">>> TEST FAILED.");
                //TestLog.WriteLine(">>> TEST FAILED.");
            }
        }

        private static void LogScreenshotOnError()
        {
            if (TestContext.CurrentContext.Outcome != TestOutcome.Passed)
            {
                Log.SystemState("Test failure detected - capturing device screenshot...");
                //DiagnosticLog.WriteLine(">>> Test failure detected - capturing device screenshot...");
                //TestLog.WriteLine(">>> Test failure detected - capturing device screenshot...");
                var screenshot = Driver.GetScreenshot();
                if (screenshot != null)
                {
                    TestLog.Failures.WriteLine("Below screenshot was captured at the moment of the error.");
                    TestLog.Failures.EmbedImage(null, screenshot);
                }
            }
        }

        public static void StopEggplant()
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

        public static void StartEggplant()
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
                    TestLog.Warnings.WriteLine("Could not start Eggplant, trying again. Mssage :" +e.Message);
                    StopEggplant();
                }
                
            }
            Assert.Fail("Eggplant drive did not appear to launch after 5 attempts");
        }

        private static void VerifyEnvironment()
        {
            if (!System.IO.Directory.Exists(Config.SuitePath))
            {
                Assert.Fail("Cannot find suite located at : " + Config.SuitePath + " Add an App.Config key 'SuitePath' with the correct location of your Eggpplant .suite folder");
            }
            if (!System.IO.File.Exists(Config.RunScriptPath))
            {
                Assert.Fail("Cannot find eggplant's runscript.bat at : " + Config.RunScriptPath + " Please add a config key RunScriptPath with the correct location to your App.Config ");
            }
        }

        [FixtureSetUp]
        public static void FixtureSetup()
        {
            VerifyEnvironment();
            Config.BatchFilePath = Common.CreateBatchFile();
            TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            Driver = EggplantDriver.GetDriver();
            StopEggplant();
            StartEggplant();
        }


        [FixtureTearDown]
        public static void FixtureTeardown()
        {
            StopEggplant();
        }

        public static string LastTestName;

        [SetUp]
        public static void SetUp()
        {
            LastTestName = TestContext.CurrentContext.TestStep.FullName;
            Log.SystemState("BEGINNING EGGPLANT TESTBASE SETUP FOR (" + LastTestName + ").");
            //DiagnosticLog.WriteLine(">>> BEGINNING EGGPLANT TESTBASE SETUP FOR (" + LastTestName + ").");
            //TestLog.WriteLine(">>> BEGINNING EGGPLANT TESTBASE SETUP FOR (" + LastTestName + ").");
        }

        [TearDown]
        public static void Teardown()
        {
            LogTestState();
            Log.SystemState("BEGINNING EGGPLANT TESTBASE TEARDOWN.");
            //DiagnosticLog.WriteLine(">>> BEGINNING EGGPLANT TESTBASE TEARDOWN.");
            //TestLog.WriteLine(">>> BEGINNING EGGPLANT TESTBASE TEARDOWN.");
            Thread.Sleep(1000);
            LogScreenshotOnError();
        }


    }
}