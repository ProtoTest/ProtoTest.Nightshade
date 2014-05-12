using System;
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

        private void LogScreenshotOnError()
        {
            if (TestContext.CurrentContext.Outcome != TestOutcome.Passed)
            {
                DiagnosticLog.WriteLine("Test Failed, capturing device screenshot.");
                TestLog.WriteLine("Test Failed, capturing device screenshot.");
                var screenshot = Driver.GetScreenshot();
                if (screenshot != null)
                {
                    TestLog.Failures.WriteLine("Below screenshot was captured at the moment of the error.");
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
                    TestLog.Warnings.WriteLine("Could not start Eggplant, trying again. Mssage :" +e.Message);
                    StopEggplant();
                }
                
            }
            Assert.Fail("Eggplant drive did not appear to launch after 5 attempts");
        }

        private void VerifyEnvironment()
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
        public void FixtureSetup()
        {
            VerifyEnvironment();
            Config.BatchFilePath = Common.CreateBatchFile();
            TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            Driver = EggplantDriver.GetDriver();
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
            DiagnosticLog.WriteLine("Eggplant Testbase Teardown started.");
            TestLog.WriteLine("Eggplant Testbase Teardown started.");
            Thread.Sleep(1000);
            LogScreenshotOnError();
        }


    }
}