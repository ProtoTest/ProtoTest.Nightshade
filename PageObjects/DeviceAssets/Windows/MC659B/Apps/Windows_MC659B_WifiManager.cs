using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_WifiManager : IWifiManager
    {
        public EggplantElement DefaultWifiNetwork = new EggplantElement(By.Text(Config.DefaultWifiNetworkName));

        public IWifiManager VerifyElements()
        {
            EggplantTestBase.Log("Verifying Fusion Wifi Manager elements.");
            //
            return this;
        }

        public IWifiManager ExitApp()
        {
            EggplantTestBase.Log("Exiting Fusion Wifi Manager app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
