using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Menu;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu
{
    class Windows_MC659B_MenuNav : IMenuNav
    {

        public IAlarmsApp GoToAlarmsApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.AlarmsApp);
            return new Windows_MC659B_AlarmsApp();
        }

        public IHomeScreen ConfirmAlarm1()
        {
            Command.Execute().GoToAlarmsApp().ConfirmAlarm1().ExitApp();
            return new Windows_MC659B_HomeDesktop();
        }

        public ICalendarApp GoToCalendarApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.CalendarApp);
            return new Windows_MC659B_CalendarApp();
        }

        public ITasksApp GoToTasksApp()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.EnterStartMenu();
            var utilities = new Enhacements.Windows.MC659B.Utilities();
            var startMenu = new Windows_MC659B_StartMenu();
            utilities.SearchMenuFor(startMenu.TasksApp);
            return new Windows_MC659B_TasksApp();
        }
    }
}
