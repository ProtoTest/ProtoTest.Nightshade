using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Menu;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu
{
    public class Windows_MC65_MenuNav : IMenuNav
    {
        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        public Windows_MC65_NetworkSettings settings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_StartMenu startMenu = new Windows_MC65_StartMenu();
        public Enhancements.Windows.MC65.Utilities utilities = new Enhancements.Windows.MC65.Utilities();


        public INetworkSettings SetCellularConnectionToTwoG()
        {
            settings.SetCellularNetworkToTwoG();
            return new Windows_MC65_NetworkSettings();
        }

        public INetworkSettings SetCellularConnectionToThreeG()
        {
            settings.SetCellularNetworkToThreeG();
            return new Windows_MC65_NetworkSettings();
        }
        
        public IAlarmsApp GoToAlarmsApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.AlarmsApp);
            startMenu.AlarmsApp.Click();
            return new Windows_MC65_AlarmsApp();
        }

        public IBrowserApp GoToBrowserApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.BrowserApp);
            startMenu.BrowserApp.Click();
            Thread.Sleep(10000);
            return new Windows_MC65_BrowserApp();
        }

        public ICalendarApp GoToCalendarApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.CalendarApp);
            startMenu.CalendarApp.Click();
            return new Windows_MC65_CalendarApp();
        }

        public IContactsApp GoToContactsApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.ContactsApp);
            startMenu.ContactsApp.Click();
            Thread.Sleep(3000);
            return new Windows_MC65_ContactsApp();
        }

        public IEmailApp GoToEmailApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.EmailApp);
            startMenu.EmailApp.Click();
            var emailApp = new Windows_MC65_EmailApp();
            emailApp.MessagingHotmailAccount.Click();
            Thread.Sleep(2000);
            return new Windows_MC65_EmailApp();
        }

        public IInstantMessengerApp GoToInstantMessengerApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.WindowsMessengerApp);
            startMenu.WindowsMessengerApp.Click();
            return new Windows_MC65_WindowsMessengerApp();
        }

        public IFileExplorer GoToAudioFiles()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.FileExplorerApp);
            startMenu.FileExplorerApp.Click();
            return new Windows_MC65_FileExplorerApp();
        }

        public IHomeScreen GoToHome()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.HomeIcon);
            startMenu.HomeIcon.Click();
            return new Windows_MC65_HomeDesktop();
        }

        public IMediaPlayerApp GoToMediaPlayerApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.WindowsMediaApp);
            startMenu.WindowsMediaApp.Click();
            return new Windows_MC65_WindowsMediaApp();
        }

        public IPicturesAndVideoApp GoToPicturesAndVideoApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.PicturesAndVideoApp);
            startMenu.PicturesAndVideoApp.Click();
            var picsApp = new Windows_MC65_PicturesAndVideoApp();
            picsApp.PicturePlaceholder.WaitForNotPresent(15);
            Thread.Sleep(3000);
            return new Windows_MC65_PicturesAndVideoApp();
        }

        public IPhoneApp GoToPhoneApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.PhoneApp);
            startMenu.PhoneApp.Click();
            return new Windows_MC65_PhoneApp();
        }

        public ISettingsApp GoToSettingsApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.SettingsApp);
            startMenu.SettingsApp.Click();
            return new Windows_MC65_SettingsApp();
        }

        public ITasksApp GoToTasksApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.TasksApp);
            startMenu.TasksApp.Click();
            return new Windows_MC65_TasksApp();
        }

        public ITextMessagesApp GoToTextMessagesApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.TextMessengerApp);
            startMenu.TextMessengerApp.Click();
            return new Windows_MC65_TextMessagesApp();
        }

        public IWifiManager GoToWifiManagerApp()
        {
            startBar.EnterStartMenu();
            utilities.SearchMenuFor(startMenu.WirelessCompanionApp);
            startMenu.WirelessCompanionApp.Click();
            return new Windows_MC65_WifiManager();
        }
    }
}
