using MbUnit.Framework;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantTestBase
    {
        public static EggplantDriver Driver;

        [FixtureSetUp]
        public void FixtureSetup()
        {
            Config.BatchFilePath = Common.CreateBatchFile();
            Gallio.Framework.Pattern.TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            Driver = new EggplantDriver(Config.DriveTimeoutSec *1000);
            Driver.StopEggPlantDrive();
            Driver.StartEggPlantDrive(Config.BatchFilePath, Config.WaitForDriveMs);
        }

        [TearDown]
        public void FixtureTeardown()
        {
            Driver.StopEggPlantDrive();
        }
    }
}
