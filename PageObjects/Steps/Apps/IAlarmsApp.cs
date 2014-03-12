

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IAlarmsApp
    {
        IAlarmsApp VerifyElements();
        IAlarmsApp SetUpAlarmsApp();
        IAlarmsApp SetAlarm1();
        IAlarmsApp ConfirmAlarm1();
        IAlarmsApp TurnOffAllAlarms();
        IAlarmsApp ExitApp();
    }
}
