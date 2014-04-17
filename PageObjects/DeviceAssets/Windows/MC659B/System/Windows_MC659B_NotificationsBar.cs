using System.Runtime.InteropServices;
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
        public EggplantElement WifiConnected = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Wifi"));
        public EggplantElement CellularConnected4 = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Cellular/CellularConnected4"));
        public EggplantElement CallInProgress = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Cellular/CallActive"));
        public EggplantElement BluetoothConnected = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Bluetooth/BluetoothConnected"));
        public EggplantElement NewMessage = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Messaging/NewMessage"));
        public EggplantElement OutgoingTextMessage = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Messaging/OutgoingTextMessage"));

        public EggplantElement OptionsArrowRight = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OptionsArrowRight"));
        public EggplantElement OptionsArrowLeft = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OptionsArrowLeft"));
        public EggplantElement RunningPrograms = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningPrograms/RunningProgramsHeader"));
        public EggplantElement RunningProgramsSelected = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningPrograms/RunningProgramsSelected"));
        public EggplantElement RunningProgramsUnselected = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningPrograms/RunningProgramsUnselected"));
        public EggplantElement RunningProgramsMenuOKButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/OKButton"));
        public EggplantElement RunningProgramsCloseAllButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningProgramsCloseAllButton"));
        public EggplantElement PicturesAndVideoProgram = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/RunningPrograms/PicturesAndVideosProgram"));

        public EggplantElement AlarmsOptionButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/OptionButton"));
        public EggplantElement AlarmsEditAlarm = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/AlarmsEditAlarm"));
        public EggplantElement AlarmsAlarm1On = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/Alarm1On"));
        public EggplantElement AlarmsAlarm1Off = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Alarms/Alarm1Off"));

        public EggplantElement PowerAndRadioOptionButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/OptionButton"));
        public EggplantElement PowerAndRadioBatteryRemaining = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/BatteryRemaining"));
        public EggplantElement PowerAndRadioPhoneRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/PhoneRadioOn"));
        public EggplantElement PowerAndRadioPhoneRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/PhoneRadioOff"));
        public EggplantElement PowerAndRadioWifiRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/WifiRadioOn"));
        public EggplantElement PowerAndRadioWifiRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/WifiRadioOff"));
        public EggplantElement PowerAndRadioBluetoothRadioOn = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/BluetoothRadioOn"));
        public EggplantElement PowerAndRadioBluetoothRadioOff = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/PowerAndRadio/BluetoothRadioOff"));

        public EggplantElement FusionOptionButton = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Fusion/OptionButton"));
        public EggplantElement FusionWirelessManager = new EggplantElement(By.Image("MC659B/System/NotificationsBar/Options/Fusion/FusionWirelessManager"));


        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();


        public INotificationsBar VerifyElements()
        {
            EggplantTestBase.Note("Verifying Notification Bar elements.");
            Battery.WaitForPresent();
            //ClockTime.LogText();
            return this;
        }

        public INotificationsBar OpenNotificationsBarMenu()
        {
            EggplantTestBase.Note("Opening the notification menu.");
            Battery.Click();
            Thread.Sleep(3000);
            if (OptionsArrowLeft.IsPresent())
            {
                OptionsArrowLeft.Click();
                Thread.Sleep(1000);
            }
            if (RunningProgramsUnselected.IsPresent())
            {
                RunningProgramsUnselected.Click();
            }
            if (RunningProgramsSelected.IsPresent())
            {
                RunningProgramsSelected.Click();
            }
            RunningPrograms.WaitForPresent();
            return this;
        }

        public INotificationsBar ClickOnMenuOKButton()
        {
            EggplantTestBase.Note("Closing the Running Programs notification menu.");
            Thread.Sleep(3000);
            RunningProgramsMenuOKButton.Click();
            Thread.Sleep(1000);
            return this;
        }

        public INotificationsBar ClickOnMenuCloseAllButton()
        {
            EggplantTestBase.Note("Closing all active running programs notification menu.");
            Thread.Sleep(3000);
            RunningProgramsCloseAllButton.Click();
            popup.ClickOK();
            Thread.Sleep(5000);
            return this;
        }


        public INotificationsBar SelectAlarmsMenuOption()
        {
            EggplantTestBase.Note("Selecting Alarms menu option.");
            OptionsArrowRight.Click();
            AlarmsOptionButton.Click();
            AlarmsEditAlarm.WaitForPresent();
            return this;
        }

        public INotificationsBar VerifyAlarm1On()
        {
            EggplantTestBase.Note("Verifying Alarm 1 is ON.");
            AlarmsAlarm1On.WaitForPresent();
            return this;
        }

        public INotificationsBar VerifyAlarm1Off()
        {
            EggplantTestBase.Note("Verifying Alarm 1 is OFF.");
            AlarmsAlarm1Off.WaitForPresent();
            return this;
        }


        public INotificationsBar SelectPowerAndRadioMenuOption()
        {
            EggplantTestBase.Note("Selecting Power & Radio menu option.");
            PowerAndRadioOptionButton.Click();
            PowerAndRadioBatteryRemaining.WaitForPresent();
            return this;
        }

        public INotificationsBar ResetNFCRadioToDefault()
        {
            EggplantTestBase.Note("Resetting NFC radio to default.");
            Thread.Sleep(5000);
            if (PowerAndRadioBluetoothRadioOn.IsPresent())
            {
                EggplantTestBase.Note("NFC radio was falsely in 'On' State.");
                SetNFCRadioToOff();
            }
            PowerAndRadioBluetoothRadioOff.WaitForPresent();
            EggplantTestBase.Note("NFC is in default state (Off).");
            return this;
        }

        public INotificationsBar SetNFCRadioToOn()
        {
            EggplantTestBase.Note("Setting NFC radio to: On.");
            PowerAndRadioBluetoothRadioOff.Click();
            PowerAndRadioBluetoothRadioOn.WaitForPresent(15);
            return this;
        }

        public INotificationsBar VerifyNFCOn()
        {
            EggplantTestBase.Note("Verifying NFC is on.");
            BluetoothConnected.WaitForPresent();
            return this;
        }

        public INotificationsBar SetNFCRadioToOff()
        {
            EggplantTestBase.Note("Setting NFC radio to: Off.");
            PowerAndRadioBluetoothRadioOn.Click();
            PowerAndRadioBluetoothRadioOff.WaitForPresent(15);
            return this;
        }

        public INotificationsBar VerifyNFCOff()
        {
            EggplantTestBase.Note("Verifying NFC is off.");
            BluetoothConnected.WaitForNotPresent();
            Thread.Sleep(3000);
            return this;
        }

        public INotificationsBar ResetWifiRadioToDefault()
        {
            EggplantTestBase.Note("Resetting Wifi radio to default.");
            Thread.Sleep(5000);
            if (PowerAndRadioWifiRadioOn.IsPresent())
            {
                EggplantTestBase.Note("Wifi radio was falsely in 'On' State.");
                SetWifiRadioToOff();
            }
            PowerAndRadioWifiRadioOff.WaitForPresent();
            WifiConnected.WaitForNotPresent();
            EggplantTestBase.Note("Wifi is in default state (Off).");
            return this;
        }

        public INotificationsBar SetWifiRadioToOn()
        {
            EggplantTestBase.Note("Setting Wifi radio to: On.");
            PowerAndRadioWifiRadioOff.Click();
            PowerAndRadioWifiRadioOn.WaitForPresent(15);
            return this;
        }

        public INotificationsBar VerifyWifiOn()
        {
            EggplantTestBase.Note("Verifying Wifi is on.");
            WifiConnected.WaitForPresent();
            return this;
        }

        public INotificationsBar SetWifiRadioToOff()
        {
            EggplantTestBase.Note("Setting Wifi radio to: Off.");
            PowerAndRadioWifiRadioOn.Click();
            PowerAndRadioWifiRadioOff.WaitForPresent(15);
            return this;
        }

        public INotificationsBar VerifyWifiOff()
        {
            EggplantTestBase.Note("Verifying Wifi is off.");
            WifiConnected.WaitForNotPresent();
            return this;
        }

        public INotificationsBar ConnectToDefaultWifiNetwork()
        {
            EggplantTestBase.Note("Disconnecting from the default wifi network.");
            return this;
        }

        public INotificationsBar DisconnectFromDefaultWifiNetwork()
        {
            EggplantTestBase.Note("Disconnecting from the default wifi network.");
            return this;
        }


        public INotificationsBar SelectWifiManagerOption()
        {
            EggplantTestBase.Note("Selecting Fusion Wifi Manager menu option.");
            OptionsArrowRight.Click();
            FusionOptionButton.Click();
            FusionWirelessManager.WaitForPresent();
            return this;
        }


    }
}
