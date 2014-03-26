

using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_NetworkSettings : INetworkSettings
    {
        //public EggplantElement NetworkSetupHeader = new EggplantElement(By.Image(""));

        public Windows_MC659B_NetworkSettings VerifyElements()
        {
            EggplantTestBase.Log("Verifying Network Setup menu elements.");
            //NetworkSetupHeader.VerifyPresent();
            return this;
        }

        public INetworkSettings SetCellularNetworkToTwoG()
        {
            EggplantTestBase.Log("Device cannot switch dyanmically to 2G.");
            return this;
        }

        public INetworkSettings SetCellularNetworkToThreeG()
        {
            EggplantTestBase.Log("Device is 3G only.");
            return this;
        }

        public INetworkSettings ExitSettings()
        {
            //Device is 3G only
            return this;
        }

    }
}
