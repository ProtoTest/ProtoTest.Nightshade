

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu
{
    public class Windows_MC659B_StartMenu
    {
        public EggplantElement StartMenuHeader = new EggplantElement(By.Image("MC659B/System/Menus/StartMenuHeader"));
        public EggplantElement AlarmsApp = new EggplantElement(By.Image("MC659B/AppIcons/AlarmsApp"));
        public EggplantElement BrowserApp = new EggplantElement(By.Image("MC659B/AppIcons/InternetExplorerApp"));
        public EggplantElement CalendarApp = new EggplantElement(By.Image("MC659B/AppIcons/CalendarApp"));
        public EggplantElement ContactsApp = new EggplantElement(By.Image("MC659B/AppIcons/ContactsApp"));
        public EggplantElement EmailApp = new EggplantElement(By.Image("MC659B/AppIcons/EmailApp"));
        public EggplantElement FileExplorerApp = new EggplantElement(By.Image("MC659B/AppIcons/FileExplorerApp"));
        public EggplantElement HomeIcon = new EggplantElement(By.Image("MC659B/AppIcons/HomeIcon"));
        public EggplantElement PicturesAndVideoApp = new EggplantElement(By.Image("MC659B/AppIcons/PicturesAndVideoApp"));
        public EggplantElement PhoneApp = new EggplantElement(By.Image("MC659B/AppIcons/PhoneApp"));
        public EggplantElement SettingsApp = new EggplantElement(By.Image("MC659B/AppIcons/SettingsApp"));
        public EggplantElement TasksApp = new EggplantElement(By.Image("MC659B/AppIcons/TasksApp"));
        public EggplantElement TextMessengerApp = new EggplantElement(By.Image("MC659B/AppIcons/TextMessagesApp"));
        public EggplantElement WindowsMediaApp = new EggplantElement(By.Image("MC659B/AppIcons/WindowsMediaPlayerApp"));
        public EggplantElement WindowsMessengerApp = new EggplantElement(By.Image("MC659B/AppIcons/WindowsMessengerApp"));
        public EggplantElement WirelessCompanionApp = new EggplantElement(By.Image("MC659B/AppIcons/WirelessCompanionApp"));

        public EggplantElement WirelessCompanionAppWirelessLaunch = new EggplantElement(By.Image("MC659B/AppIcons/WirelessCompanionMenu/WirelessLaunch"));
        public EggplantElement WirelessCompanionAppWirelessStatus = new EggplantElement(By.Image("MC659B/AppIcons/WirelessCompanionMenu/WirelessStatus"));
        public EggplantElement WirelessCompanionAppManageProfilesOption = new EggplantElement(By.Image("MC659B/AppIcons/WirelessCompanionMenu/ManageProfilesOption"));
        
        
        public Windows_MC659B_StartMenu VerifyElements()
        {
            EggplantTestBase.Note("Entering start menu.");
            StartMenuHeader.WaitForPresent();
            return this;
        }

    }
}
