using System;
using System.Diagnostics;
using System.Threading;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using Gallio.Model;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantTestBase
    {
        private Process EggPlantDriveProcess;
        private BackgroundVideoRecorder recorder;
        public static EggplantDriver _Driver;
       
        public static EggplantDriver Driver
        {
            get
            {
                
                return _Driver;
            }
            set { _Driver = value; }
        }

        public void SetDefaultSearchTime()
        {
            Driver.Execute("set the ImageSearchTime to " + Config.ElementSearchTime);
            Driver.Execute("set the ImageSearchCount to " + Config.ImageSearchCount);

        }

        public void ConnectToHost1()
        {
            Driver.Connect(Config.Hosts[0]);
   
        }

        public void ConnectToHost2()
        {
            Driver.Connect(Config.Hosts[1]);
            
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

        private void LogScreenshotOnError()
        {
            if (TestContext.CurrentContext.Outcome != TestOutcome.Passed)
            {
                var screenshot = Driver.GetScreenshot();
                if (screenshot != null) ;
                {
                    TestLog.Failures.EmbedImage(null, screenshot);
                }
            }
        }

        [FixtureSetUp]
        public void FixtureSetup()
        {
            Config.BatchFilePath = Common.CreateBatchFile();
            TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            Driver = new EggplantDriver(Config.DriveTimeoutSec*1000);
            Driver.StopEggPlantDrive();
            EggPlantDriveProcess = Driver.StartEggPlantDrive(Config.BatchFilePath, Config.WaitForDriveMs);
            Driver.WaitForDriveToLoad(Config.WaitForDriveMs);
            SetDefaultSearchTime();
        }

        [FixtureTearDown]
        public void FixtureTeardown()
        {

            EggPlantDriveProcess.CloseMainWindow();
            EggPlantDriveProcess.WaitForExit();
            Driver.StopEggPlantDrive();
        }

        [SetUp]
        public void SetUp()
        {
            ConnectToHost1();
            StartVideoRecording();   
        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(1000);
            LogScreenshotOnError();
           StopVideoRecording();
           Driver.Disconnect();
        }


    }
}