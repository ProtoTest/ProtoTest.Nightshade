using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_WifiManager : IWifiManager
    {
        public EggplantElement DefaultWifiNetwork = new EggplantElement(By.Text(Config.DefaultWifiNetworkName).InRectangle(SearchRectangle.TopHalf));
        public EggplantElement ConnectMenuOption = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/ConnectMenuOption"));
        public EggplantElement DisableMenuOption = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/DisableMenuOption"));
        public EggplantElement ManageProfiles = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/ManageProfiles"));
        public EggplantElement ManageProfilesHeader = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/ManageProfilesHeader"));
        public EggplantElement ManageProfilesOption = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/ManageProfilesOption"));
        public EggplantElement UnhighlightClickedProfile = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/UnhighlightClickedProfile"));
        public EggplantElement WifiProfileActiveIconHotspotAway = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/WifiProfileActiveIconHotspotAway"));
        public EggplantElement WirelessStatusSignalStrengthBars = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/WirelessStatusSignalStrengthBars"));
        public EggplantElement WirelessStatusSignalStrengthMenuOption = new EggplantElement(By.Image("MC65/Apps/FusionWifiManager/WirelessStatusSignalStrengthMenuOption"));

        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_MenuNav menuNav = new Windows_MC65_MenuNav();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        public Windows_MC65_NetworkSettings settings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_StartMenu startMenu = new Windows_MC65_StartMenu();
        public Enhancements.Windows.MC65.Utilities utilities = new Enhancements.Windows.MC65.Utilities();

        public IWifiManager VerifyElements()
        {
            EggplantTestBase.Info("Verifying Fusion Wifi Manager elements.");
            //
            return this;
        }

        public IWifiManager ConnectToDefaultWifiNetwork()
        {
            EggplantTestBase.Info("Connecting to the default wifi network.");
            startMenu.WirelessCompanionAppWirelessLaunch.Click();
            startMenu.WirelessCompanionAppManageProfilesOption.Click();
            DefaultWifiNetwork.DoubleClick();
            ConnectMenuOption.Click();
            Thread.Sleep(2000);
            UnhighlightClickedProfile.Click();
            WifiProfileActiveIconHotspotAway.WaitForPresent(30);
            notificationsBar.VerifyWifiOn();
            EggplantTestBase.Info("Connection to the default wifi network verified.");
            startBar.OKButton.Click();
            Command.NavigateTheMenu().GoToWifiManagerApp();
            startMenu.WirelessCompanionAppWirelessStatus.Click();
            WirelessStatusSignalStrengthMenuOption.Click();
            WirelessStatusSignalStrengthBars.WaitForPresent();
            EggplantTestBase.Info("Default wifi network signal strength verified.");
            startBar.OKButton.Click();
            return this;
        }

        public IWifiManager DisconnectFromDefaultWifiNetwork()
        {
            EggplantTestBase.Info("Disconnecting from the default wifi network.");
            startMenu.WirelessCompanionAppWirelessLaunch.Click();
            startMenu.WirelessCompanionAppManageProfilesOption.Click();
            DefaultWifiNetwork.DoubleClick();
            DisableMenuOption.Click();
            Thread.Sleep(2000);
            UnhighlightClickedProfile.Click();
            WifiProfileActiveIconHotspotAway.WaitForNotPresent(15);
            notificationsBar.VerifyWifiOff();
            return this;
        }

        public IWifiManager ExitApp()
        {
            EggplantTestBase.Info("Exiting Fusion Wifi Manager app.");
            if (startBar.OKButton.IsPresent())
            {
                startBar.OKButton.Click();
            }
            if (startBar.ExitButton.IsPresent())
            {
                startBar.ExitButton.Click();
            }
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
