using System.Diagnostics;
using System.Threading;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using MbUnit.Framework;
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
                recorder = new BackgroundVideoRecorder(20);
                recorder.Start();    
            }
            
        }

        public void StopVideoRecording()
        {
            if (Config.RecordVideo)
            {
                recorder.Stop();
                TestLog.EmbedVideo(TestStep.CurrentStep.FullName + "_Video", recorder.video);    
            }
            
        }

        public void Log(string message)
        {
            TestLog.WriteLine(message);
            DiagnosticLog.WriteLine(message);
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
            ConnectToHost1();
           // StartVideoRecording();
        }

        [TearDown]
        public void FixtureTeardown()
        {
            Thread.Sleep(1000);
            EggPlantDriveProcess.CloseMainWindow();
            //Driver.StopEggPlantDrive();
        }
    }
}