

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu
{
    public class Windows_MC65_StartMenu
    {
        public EggplantElement StartMenuHeader = new EggplantElement(By.Image("MC65/System/Menus/StartMenuHeader"));
        public EggplantElement AlarmsApp = new EggplantElement(By.Image("MC65/AppIcons/AlarmsApp"));
        public EggplantElement BrowserApp = new EggplantElement(By.Image("MC65/AppIcons/InternetExplorerApp"));
        public EggplantElement CalendarApp = new EggplantElement(By.Image("MC65/AppIcons/CalendarApp"));
        public EggplantElement ContactsApp = new EggplantElement(By.Image("MC65/AppIcons/ContactsApp"));
        public EggplantElement EmailApp = new EggplantElement(By.Image("MC65/AppIcons/EmailApp"));
        public EggplantElement FileExplorerApp = new EggplantElement(By.Image("MC65/AppIcons/FileExplorerApp"));
        public EggplantElement HomeIcon = new EggplantElement(By.Image("MC65/AppIcons/HomeIcon"));
        public EggplantElement PicturesAndVideoApp = new EggplantElement(By.Image("MC65/AppIcons/PicturesAndVideoApp"));
        public EggplantElement PhoneApp = new EggplantElement(By.Image("MC65/AppIcons/PhoneApp"));
        public EggplantElement SettingsApp = new EggplantElement(By.Image("MC65/AppIcons/SettingsApp"));
        public EggplantElement TasksApp = new EggplantElement(By.Image("MC65/AppIcons/TasksApp"));
        public EggplantElement TextMessengerApp = new EggplantElement(By.Image("MC65/AppIcons/TextMessagesApp"));
        public EggplantElement WindowsMediaApp = new EggplantElement(By.Image("MC65/AppIcons/WindowsMediaPlayerApp"));
        public EggplantElement WindowsMessengerApp = new EggplantElement(By.Image("MC65/AppIcons/WindowsMessengerApp"));
        public EggplantElement WirelessCompanionApp = new EggplantElement(By.Image("MC65/AppIcons/WirelessCompanionApp"));

        public EggplantElement WirelessCompanionAppWirelessLaunch = new EggplantElement(By.Image("MC65/AppIcons/WirelessCompanionMenu/WirelessLaunch"));
        public EggplantElement WirelessCompanionAppWirelessStatus = new EggplantElement(By.Image("MC65/AppIcons/WirelessCompanionMenu/WirelessStatus"));
        public EggplantElement WirelessCompanionAppManageProfilesOption = new EggplantElement(By.Image("MC65/AppIcons/WirelessCompanionMenu/ManageProfilesOption"));
        
        
        public Windows_MC65_StartMenu VerifyElements()
        {
            EggplantTestBase.Info("Entering start menu.");
            StartMenuHeader.WaitForPresent();
            return this;
        }

    }
}
