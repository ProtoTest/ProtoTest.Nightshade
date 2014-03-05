using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;

namespace ProtoTest.Nightshade.PageObjects.Interfaces
{
    public interface IMenuNav
    {
        void GoToCalendarApp();
        void GoToAlarmsApp();
        void GoToTasksApp();
    }

    public class WindowsMC659BMenuNav : IMenuNav
    {
        public void GoToCalendarApp()
        {
            var StartMenu = new StartMenu();
            StartMenu.CalendarApp.Click();
        }
        public void GoToAlarmsApp()
        {
            //PageObjects.DeviceAssets.Windows.MC659B.Menu.StartMenu.AlarmsApp.Click();
        }
        public void GoToTasksApp()
        {
            //PageObjects.DeviceAssets.Windows.MC659B.Menu.StartMenu.TasksApp.Click();
        }
    }
}
