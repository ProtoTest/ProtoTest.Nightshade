using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class NotificationsBar : EggplantTestBase
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

        public NotificationsBar VerifyElements()
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
