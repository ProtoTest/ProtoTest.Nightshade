using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_WifiManager : IWifiManager
    {
        public EggplantElement DefaultWifiNetwork = new EggplantElement(By.Text(Config.DefaultWifiNetworkName).InRectangle(SearchRectangle.TopHalf));
        public EggplantElement ConnectMenuOption = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/ConnectMenuOption"));
        public EggplantElement DisableMenuOption = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/DisableMenuOption"));
        public EggplantElement ManageProfiles = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/ManageProfiles"));
        public EggplantElement ManageProfilesHeader = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/ManageProfilesHeader"));
        public EggplantElement ManageProfilesOption = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/ManageProfilesOption"));
        public EggplantElement UnhighlightClickedProfile = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/UnhighlightClickedProfile"));
        public EggplantElement WifiProfileActiveIconHotspotAway = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/WifiProfileActiveIconHotspotAway"));
        public EggplantElement WirelessStatusSignalStrengthBars = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/WirelessStatusSignalStrengthBars"));
        public EggplantElement WirelessStatusSignalStrengthMenuOption = new EggplantElement(By.Image("MC659B/Apps/FusionWifiManager/WirelessStatusSignalStrengthMenuOption"));

        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_MenuNav menuNav = new Windows_MC659B_MenuNav();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        public Windows_MC659B_NetworkSettings settings = new Windows_MC659B_NetworkSettings();
        public Windows_MC659B_StartMenu startMenu = new Windows_MC659B_StartMenu();
        public Enhancements.Windows.MC659B.Utilities utilities = new Enhancements.Windows.MC659B.Utilities();

        public IWifiManager VerifyElements()
        {
            EggplantTestBase.Note("Verifying Fusion Wifi Manager elements.");
            //
            return this;
        }

        public IWifiManager ConnectToDefaultWifiNetwork()
        {
            EggplantTestBase.Note("Connecting to the default wifi network.");
            startMenu.WirelessCompanionAppWirelessLaunch.Click();
            startMenu.WirelessCompanionAppManageProfilesOption.Click();
            DefaultWifiNetwork.DoubleClick();
            ConnectMenuOption.Click();
            Thread.Sleep(2000);
            UnhighlightClickedProfile.Click();
            WifiProfileActiveIconHotspotAway.WaitForPresent(30);
            notificationsBar.VerifyWifiOn();
            EggplantTestBase.Note("Connection to the default wifi network verified.");
            startBar.OKButton.Click();
            Command.NavigateTheMenu().GoToWifiManagerApp();
            startMenu.WirelessCompanionAppWirelessStatus.Click();
            WirelessStatusSignalStrengthMenuOption.Click();
            WirelessStatusSignalStrengthBars.WaitForPresent();
            EggplantTestBase.Note("Default wifi network signal strength verified.");
            startBar.OKButton.Click();
            return this;
        }

        public IWifiManager DisconnectFromDefaultWifiNetwork()
        {
            EggplantTestBase.Note("Disconnecting from the default wifi network.");
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
            EggplantTestBase.Note("Exiting Fusion Wifi Manager app.");
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
