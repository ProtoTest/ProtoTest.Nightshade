using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_SettingsApp : ISettingsApp
    {
        public EggplantElement SettingsMenuHeader = new EggplantElement(By.Image("MC65/Apps/Settings/SettingsMenuHeader"));
        public EggplantElement SettingsHomeIcon = new EggplantElement(By.Image("MC65/Apps/Settings/SettingsHomeIcon"));
        public EggplantElement SettingsSystemIcon = new EggplantElement(By.Image("MC65/Apps/Settings/SettingsSystemIcon"));

        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_MenuNav menuNav = new Windows_MC65_MenuNav();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        public Windows_MC65_NetworkSettings settings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_StartMenu startMenu = new Windows_MC65_StartMenu();
        public Enhancements.Windows.MC65.Utilities utilities = new Enhancements.Windows.MC65.Utilities();


        public ISettingsApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Settings menu elements.");
            SettingsMenuHeader.WaitForPresent();
            SettingsHomeIcon.WaitForPresent();
            SettingsSystemIcon.WaitForPresent();
            return this;
        }

        public ISettingsApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Settings menu.");
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
