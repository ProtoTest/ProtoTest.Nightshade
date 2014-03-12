using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.Steps.Menu
{
    public interface IMenuNav
    {
        IAlarmsApp GoToAlarmsApp();
        IHomeScreen ConfirmAlarm1();
        ICalendarApp GoToCalendarApp();
        ITasksApp GoToTasksApp();
    }
  
}
