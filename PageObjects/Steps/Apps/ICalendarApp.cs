

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface ICalendarApp
    {
        ICalendarApp VerifyElements();
        ICalendarApp SetUpCalendarApp();
        ICalendarApp SetCalendarAppointments(int iterationsMax);
        ICalendarApp DeleteCalendarAppointments();
        ICalendarApp ExitApp();
    }
}
