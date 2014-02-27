using System.Threading;
using Gallio.Framework.Pattern;
using MbUnit.Framework;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantTestBase
    {
        public static EggplantDriver _Driver;
        public static EggplantDriver Driver
        {
            get
            {
                Thread.Sleep(Config.DelayTimeMs);
                return _Driver;
            }
            set { _Driver = value; }
        }
        public void SetDefaultSearchTime()
        {
            Driver.Execute("set the ImageSearchTime to " + Config.ElementSearchTime);
        }

        public void ConnectToHost1()
        {
            Driver.Connect(Config.Hosts[0]);
        }
        public void ConnectToHost2()
        {
            Driver.Connect(Config.Hosts[1]);
        }

        [FixtureSetUp]
        public void FixtureSetup()
        {
            Config.BatchFilePath = Common.CreateBatchFile();
            TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            Driver = new EggplantDriver(Config.DriveTimeoutSec*1000);
            Driver.StopEggPlantDrive();
            Driver.StartEggPlantDrive(Config.BatchFilePath, Config.WaitForDriveMs);
            Driver.WaitForDriveToLoad(Config.WaitForDriveMs);
        }

        [TearDown]
        public void FixtureTeardown()
        {
            Driver.StopEggPlantDrive();
        }
    }
}