

using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System
{
    public class Windows_MC65_NetworkSettings : INetworkSettings
    {
        //public EggplantElement NetworkSetupHeader = new EggplantElement(By.Image(""));

        public Windows_MC65_NetworkSettings VerifyElements()
        {
            EggplantTestBase.Info("Verifying Network Setup menu elements.");
            //NetworkSetupHeader.VerifyPresent();
            return this;
        }

        public INetworkSettings SetCellularNetworkToTwoG()
        {
            EggplantTestBase.Info("Device cannot switch dyanmically to 2G.");
            return this;
        }

        public INetworkSettings SetCellularNetworkToThreeG()
        {
            EggplantTestBase.Info("Device is 3G only.");
            return this;
        }

        public INetworkSettings ExitSettings()
        {
            //Device is 3G only
            return this;
        }

    }
}
