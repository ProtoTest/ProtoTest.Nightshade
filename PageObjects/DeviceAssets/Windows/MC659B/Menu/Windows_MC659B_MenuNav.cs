using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Menu;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu
{
    class Windows_MC659B_MenuNav : IMenuNav
    {
        public INetworkSettings SetCellularConnectionToTwoG()
        {
            var settings = new Windows_MC659B_NetworkSettings();
            settings.SetCellularNetworkToTwoG();
            return new Windows_MC659B_NetworkSettings();
        }

        public INetworkSettings SetCellularConnectionToThreeG()
        {
            var settings = new Windows_MC659B_NetworkSettings();
            settings.SetCellularNetworkToThreeG();
            return new Windows_MC659B_NetworkSettings();
        }
        
        public IAlarmsApp GoToAlarmsApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.AlarmsApp);
            startMenu.AlarmsApp.Click();
            return new Windows_MC659B_AlarmsApp();
        }

        public IBrowserApp GoToBrowserApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.BrowserApp);
            startMenu.BrowserApp.Click();
            return new Windows_MC659B_BrowserApp();
        }

        public ICalendarApp GoToCalendarApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.CalendarApp);
            startMenu.CalendarApp.Click();
            return new Windows_MC659B_CalendarApp();
        }

        public IFileExplorer GoToAudioFiles()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.FileExplorerApp);
            startMenu.FileExplorerApp.Click();
            return new Windows_MC659B_FileExplorerApp();
        }

        public IHomeScreen GoToHome()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.HomeIcon);
            startMenu.HomeIcon.Click();
            return new Windows_MC659B_HomeDesktop();
        }

        public IMediaPlayerApp GoToMediaPlayerApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.WindowsMediaApp);
            startMenu.CalendarApp.Click();
            var mediaApp = new Windows_MC659B_WindowsMediaApp();
            mediaApp.SetAppState();
            return new Windows_MC659B_WindowsMediaApp();
        }

        public IPicturesAndVideoApp GoToPicturesAndVideoApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.PicturesAndVideoApp);
            startMenu.PicturesAndVideoApp.Click();
            return new Windows_MC659B_PicturesAndVideoApp();
        }

        public ITasksApp GoToTasksApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.TasksApp);
            startMenu.TasksApp.Click();
            return new Windows_MC659B_TasksApp();
        }
    }
}
