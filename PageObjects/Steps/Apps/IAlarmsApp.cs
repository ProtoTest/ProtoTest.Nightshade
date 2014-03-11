using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IAlarmsApp
    {
        IAlarmsApp VerifyElements();
        IAlarmsApp SetupAlarmsApp();
        IAlarmsApp SetAlarm1();
        IAlarmsApp ConfirmAlarm1();
        IAlarmsApp TurnOffAllAlarms();
        IAlarmsApp ExitApp();
        
    }
}
