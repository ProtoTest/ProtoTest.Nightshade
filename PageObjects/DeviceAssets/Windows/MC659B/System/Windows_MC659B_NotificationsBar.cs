using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_NotificationsBar : INotificationsBar
    {
        EggplantElement ClockTime = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Clock/Time"));
        EggplantElement Battery = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Battery"));
        EggplantElement BatteryCharging = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Battery/BatteryCharging"));
        EggplantElement Battery1 = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Battery/Battery1"));
        EggplantElement Wifi = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Wifi"));
        EggplantElement WifiConnected4 = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Wifi/Connected4"));

        EggplantElement RunningProgramsMenuHeader = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningProgramsMenuHeader"));
        EggplantElement RunningProgramsMenuOKButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OKButton"));
        EggplantElement RunningProgramsArrowRight = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OptionsArrowRight"));
        EggplantElement RunningProgramsArrowLeft = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OptionsArrowLeft"));
        
        EggplantElement RunningProgramsAlarms = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/OptionButton"));
        EggplantElement RunningProgramsEditAlarm = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/AlarmsEditAlarm"));
        EggplantElement RunningProgramsAlarm1On = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/Alarm1On"));
        EggplantElement RunningProgramsAlarm1Off = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/Alarm1Off"));

        EggplantElement RunningProgramsPowerAndRadio = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/OptionButton"));
        EggplantElement RunningProgramsBatteryRemaining = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/BatteryRemaining"));
        EggplantElement RunningProgramsPhoneRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/PhoneRadioOn"));
        EggplantElement RunningProgramsPhoneRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/PhoneRadioOff"));
        EggplantElement RunningProgramsWifiRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/WifiRadioOn"));
        EggplantElement RunningProgramsWifiRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/WifiRadioOff"));


        public INotificationsBar VerifyElements()
        {
            EggplantTestBase.Log("Verifying Notification Bar elements.");
            Battery.VerifyPresent();
            Wifi.VerifyPresent();
            ClockTime.VerifyPresent();
            ClockTime.LogText();
            return this;
        }

        public INotificationsBar OpenRunningProgramsMenu()
        {
            EggplantTestBase.Log("Opening the Running Programs notification menu.");
            Battery.Click();
            RunningProgramsMenuHeader.VerifyPresent();
            RunningProgramsArrowRight.Click();
            return this;
        }

        public INotificationsBar ClickOnMenuOKButton()
        {
            EggplantTestBase.Log("Closing the Running Programs notification menu.");
            RunningProgramsMenuOKButton.Click();
            return this;
        }

        public INotificationsBar SelectAlarmsMenuOption()
        {
            EggplantTestBase.Log("Selecting Alarms menu option.");
            RunningProgramsArrowRight.Click();
            RunningProgramsAlarms.Click();
            RunningProgramsEditAlarm.VerifyPresent();
            return this;
        }

        public INotificationsBar SelectPowerAndRadioMenuOption()
        {
            EggplantTestBase.Log("Selecting Power & Radio menu option.");
            RunningProgramsPowerAndRadio.Click();
            RunningProgramsBatteryRemaining.VerifyPresent();
            return this;
        }

        public INotificationsBar VerifyAlarm1On()
        {
            EggplantTestBase.Log("Verifying Alarm 1 is ON.");
            RunningProgramsAlarm1On.VerifyPresent();
            return this;
        }

        public INotificationsBar VerifyAlarm1Off()
        {
            EggplantTestBase.Log("Verifying Alarm 1 is OFF.");
            RunningProgramsAlarm1Off.VerifyPresent();
            return this;
        }
    }
}
