

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_NotificationsBar : EggplantTestBase
    {
        //EggplantElement ClockTime = new EggplantElement(By.TextAtLocation("MC659B/System/NotificationsBar/Clock/Time"));
        EggplantElement Battery = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Battery"));
        public enum BatteryState
        {
            Battery1,
            BatteryCharging
        }
        EggplantElement Wifi = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Wifi"));
        public enum WifiState
        {
            WifiConnected4
        }

        public Windows_MC659B_NotificationsBar VerifyElements()
        {
            Log("Verifying Notification Bar elements.");
            Battery.VerifyPresent();
            Wifi.VerifyPresent();
            //ClockTime.VerifyPresent();
            //Battery.WaitForNotPresent(BatteryState.BatteryCharging);
            return this;
        }
    }
}
