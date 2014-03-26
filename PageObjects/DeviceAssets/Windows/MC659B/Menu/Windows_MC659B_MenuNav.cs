using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Menu;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu
{
    public class Windows_MC659B_MenuNav : IMenuNav
    {
        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        public Windows_MC659B_NetworkSettings settings = new Windows_MC659B_NetworkSettings();
        public Windows_MC659B_StartMenu startMenu = new Windows_MC659B_StartMenu();
        public Enhancements.Windows.MC659B.Utilities utilities = new Enhancements.Windows.MC659B.Utilities();


        public INetworkSettings SetCellularConnectionToTwoG()
        {
            settings.SetCellularNetworkToTwoG();
            return new Windows_MC659B_NetworkSettings();
        }

        public INetworkSettings SetCellularConnectionToThreeG()
        {
            settings.SetCellularNetworkToThreeG();
            return new Windows_MC659B_NetworkSettings();
        }
        
        public IAlarmsApp GoToAlarmsApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.AlarmsApp);
            startMenu.AlarmsApp.Click();
            return new Windows_MC659B_AlarmsApp();
        }

        public IBrowserApp GoToBrowserApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.BrowserApp);
            startMenu.BrowserApp.Click();
            return new Windows_MC659B_BrowserApp();
        }

        public ICalendarApp GoToCalendarApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.CalendarApp);
            startMenu.CalendarApp.Click();
            return new Windows_MC659B_CalendarApp();
        }

        public IContactsApp GoToContactsApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.ContactsApp);
            startMenu.ContactsApp.Click();
            return new Windows_MC659B_ContactsApp();
        }

        public IEmailApp GoToEmailApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.EmailApp);
            startMenu.EmailApp.Click();
            return new Windows_MC659B_EmailApp();
        }

        public IInstantMessengerApp GoToInstantMessengerApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.WindowsMessengerApp);
            startMenu.WindowsMessengerApp.Click();
            return new Windows_MC659B_WindowsMessengerApp();
        }

        public IFileExplorer GoToAudioFiles()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.FileExplorerApp);
            startMenu.FileExplorerApp.Click();
            return new Windows_MC659B_FileExplorerApp();
        }

        public IHomeScreen GoToHome()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.HomeIcon);
            startMenu.HomeIcon.Click();
            return new Windows_MC659B_HomeDesktop();
        }

        public IMediaPlayerApp GoToMediaPlayerApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.WindowsMediaApp);
            startMenu.WindowsMediaApp.Click();
            return new Windows_MC659B_WindowsMediaApp();
        }

        public IPicturesAndVideoApp GoToPicturesAndVideoApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.PicturesAndVideoApp);
            startMenu.PicturesAndVideoApp.Click();
            return new Windows_MC659B_PicturesAndVideoApp();
        }

        public IPhoneApp GoToPhoneApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.PhoneApp);
            startMenu.PhoneApp.Click();
            return new Windows_MC659B_PhoneApp();
        }

        public ISettingsApp GoToSettingsApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.SettingsApp);
            startMenu.SettingsApp.Click();
            return new Windows_MC659B_SettingsApp();
        }

        public ITasksApp GoToTasksApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.TasksApp);
            startMenu.TasksApp.Click();
            return new Windows_MC659B_TasksApp();
        }

        public ITextMessagesApp GoToTextMessagesApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.TextMessengerApp);
            startMenu.TextMessengerApp.Click();
            return new Windows_MC659B_TextMessagesApp();
        }
    }
}
