

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface ICalendarApp
    {
        ICalendarApp VerifyElements();
        ICalendarApp SetUpCalendarApp();
        ICalendarApp SetCalendarAppointments();
        ICalendarApp DeleteCalendarAppointments();
        ICalendarApp ExitApp();
    }
}
