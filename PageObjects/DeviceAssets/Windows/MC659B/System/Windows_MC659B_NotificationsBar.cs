using System.Threading;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_NotificationsBar : INotificationsBar
    {
        public EggplantElement ClockTime = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Clock/Time"));
        public EggplantElement Battery = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Battery"));
        public EggplantElement BatteryCharging = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Battery/BatteryCharging"));
        public EggplantElement Battery1 = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Battery/Battery1"));
        public EggplantElement Wifi = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Wifi"));
        public EggplantElement WifiConnected4 = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Wifi/Connected4"));
        public EggplantElement BluetoothConnected = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Bluetooth/BluetoothConnected"));

        public EggplantElement RunningPrograms = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningPrograms"));
        public EggplantElement RunningProgramsMenuOKButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OKButton"));
        public EggplantElement RunningProgramsArrowRight = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OptionsArrowRight"));
        public EggplantElement RunningProgramsArrowLeft = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OptionsArrowLeft"));
        public EggplantElement PicturesAndVideoProgram = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningPrograms/PicturesAndVideosProgram"));
        
        public EggplantElement RunningProgramsAlarms = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/OptionButton"));
        public EggplantElement RunningProgramsEditAlarm = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/AlarmsEditAlarm"));
        public EggplantElement RunningProgramsAlarm1On = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/Alarm1On"));
        public EggplantElement RunningProgramsAlarm1Off = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/Alarm1Off"));

        public EggplantElement PowerAndRadioOptionButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/OptionButton"));
        public EggplantElement PowerAndRadioBatteryRemaining = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/BatteryRemaining"));
        public EggplantElement PowerAndRadioPhoneRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/PhoneRadioOn"));
        public EggplantElement PowerAndRadioPhoneRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/PhoneRadioOff"));
        public EggplantElement PowerAndRadioWifiRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/WifiRadioOn"));
        public EggplantElement PowerAndRadioWifiRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/WifiRadioOff"));
        public EggplantElement PowerAndRadioBluetoothRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/BluetoothRadioOn"));
        public EggplantElement PowerAndRadioBluetoothRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/BluetoothRadioOff"));


        public INotificationsBar VerifyElements()
        {
            EggplantTestBase.Log("Verifying Notification Bar elements.");
            Battery.WaitForPresent();
            //ClockTime.LogText();
            return this;
        }

        public INotificationsBar OpenRunningProgramsMenu()
        {
            EggplantTestBase.Log("Opening the Running Programs notification menu.");
            Battery.Click();
            RunningPrograms.WaitForPresent();
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
            RunningProgramsEditAlarm.WaitForPresent();
            return this;
        }

        public INotificationsBar SelectPowerAndRadioMenuOption()
        {
            EggplantTestBase.Log("Selecting Power & Radio menu option.");
            PowerAndRadioOptionButton.Click();
            PowerAndRadioBatteryRemaining.WaitForPresent();
            return this;
        }

        public INotificationsBar VerifyAlarm1On()
        {
            EggplantTestBase.Log("Verifying Alarm 1 is ON.");
            RunningProgramsAlarm1On.WaitForPresent();
            return this;
        }

        public INotificationsBar VerifyAlarm1Off()
        {
            EggplantTestBase.Log("Verifying Alarm 1 is OFF.");
            RunningProgramsAlarm1Off.WaitForPresent();
            return this;
        }

        public INotificationsBar ResetNFCRadioToDefault()
        {
            EggplantTestBase.Log("Resetting NFC radio to default.");
            if (PowerAndRadioBluetoothRadioOn.IsPresent())
            {
                EggplantTestBase.Log("NFC radio was falsely in 'On' State.");
                SetNFCRadioToOff();
            }
            PowerAndRadioBluetoothRadioOff.WaitForPresent();
            EggplantTestBase.Log("NFC in default state.");
            return this;
        }

        public INotificationsBar SetNFCRadioToOn()
        {
            EggplantTestBase.Log("Setting NFC radio to: On.");
            PowerAndRadioBluetoothRadioOff.Click();
            PowerAndRadioBluetoothRadioOn.WaitForPresent(15);
            return this;
        }

        public INotificationsBar VerifyNFCOn()
        {
            EggplantTestBase.Log("Verifying NFC is on.");
            PowerAndRadioBluetoothRadioOff.Click();
            PowerAndRadioBluetoothRadioOn.WaitForPresent(15);
            return this;
        }

        public INotificationsBar SetNFCRadioToOff()
        {
            EggplantTestBase.Log("Setting NFC radio to: Off.");
            PowerAndRadioBluetoothRadioOn.Click();
            PowerAndRadioBluetoothRadioOff.WaitForPresent(15);
            return this;
        }

        public INotificationsBar VerifyNFCOff()
        {
            EggplantTestBase.Log("Verifying NFC is off.");
            PowerAndRadioBluetoothRadioOff.Click();
            PowerAndRadioBluetoothRadioOn.WaitForNotPresent(15);
            return this;
        }
    }
}
