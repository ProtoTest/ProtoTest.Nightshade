using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_SettingsApp : ISettingsApp
    {
        public EggplantElement SettingsMenuHeader = new EggplantElement(By.Image("MC659B/Apps/Settings/SettingsMenuHeader"));
        public EggplantElement SettingsHomeIcon = new EggplantElement(By.Image("MC659B/Apps/Settings/SettingsHomeIcon"));
        public EggplantElement SettingsSystemIcon = new EggplantElement(By.Image("MC659B/Apps/Settings/SettingsSystemIcon"));

        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_MenuNav menuNav = new Windows_MC659B_MenuNav();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        public Windows_MC659B_NetworkSettings settings = new Windows_MC659B_NetworkSettings();
        public Windows_MC659B_StartMenu startMenu = new Windows_MC659B_StartMenu();
        public Enhancements.Windows.MC659B.Utilities utilities = new Enhancements.Windows.MC659B.Utilities();


        public ISettingsApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Settings menu elements.");
            SettingsMenuHeader.WaitForPresent();
            SettingsHomeIcon.WaitForPresent();
            SettingsSystemIcon.WaitForPresent();
            return this;
        }

        public ISettingsApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Settings menu.");
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
