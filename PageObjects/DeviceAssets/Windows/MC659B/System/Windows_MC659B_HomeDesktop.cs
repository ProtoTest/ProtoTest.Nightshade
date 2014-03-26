using System;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_HomeDesktop : IHomeScreen
    {
        public EggplantElement DefaultDesktop = new EggplantElement(By.Image("MC659B/System/Themes/Desktop01"));

        public EggplantElement Desktop01 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop01"));
        public EggplantElement Desktop02 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop02"));
        public EggplantElement Desktop03 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop03"));
        public EggplantElement Desktop04 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop04"));
        public EggplantElement Desktop05 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop05"));
        public EggplantElement Desktop06 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop06"));
        public EggplantElement Desktop07 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop07"));
        public EggplantElement Desktop08 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop08"));
        public EggplantElement Desktop09 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop09"));
        public EggplantElement Desktop10 = new EggplantElement(By.Image("MC659B/System/Themes/Desktop10"));
        
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_NetworkSettings networkSettings = new Windows_MC659B_NetworkSettings();

        public IHomeScreen ConfirmHomeScreen()
        {
            if (!DefaultDesktop.IsPresent())
            {
                throw new Exception("Device is not on the home screen.");
            }
            EggplantTestBase.Log("Device is on the home screen.");
            DefaultDesktop.WaitForPresent();
            startBar.VerifyElements();
            notificationsBar.VerifyElements();
            return this;
        }

        public IHomeScreen ResetDeviceStateToDefault()
        {
            EggplantTestBase.Log("Resetting device state to default.");
            int loops = 1;
            while (startBar.ExitButton.IsPresent() || startBar.OKButton.IsPresent() || notificationsBar.RunningProgramsMenuOKButton.IsPresent())
            {
                if (loops == 10)
                {
                    throw new Exception("Cannot close menu to return to the desktop after " + loops + " attempts.");
                }
                
                EggplantTestBase.Log("Open menu detected.  Closing now...");
                if (startBar.ExitButton.IsPresent())
                {
                    startBar.ExitButton.Click();
                }
                if (startBar.OKButton.IsPresent())
                {
                    startBar.OKButton.Click();
                }
                if (notificationsBar.RunningProgramsMenuOKButton.IsPresent())
                {
                    notificationsBar.RunningProgramsMenuOKButton.Click();
                }
                loops++;
            }
            notificationsBar.OpenRunningProgramsMenu();
            if (notificationsBar.RunningProgramsCloseAllButton.IsPresent())
            {
                EggplantTestBase.Log("Running programs detected.  Closing now...");
                notificationsBar.ClickOnMenuCloseAllButton();
            }
            notificationsBar.ClickOnMenuOKButton();
            ConfirmHomeScreen();
            return this;
        }

        public IHomeScreen SetThemeToOption(string picNumber)
        {
            var picsApp = new Windows_MC659B_PicturesAndVideoApp();
            picsApp.SetThemeToOption(picNumber);
            return this;
        }

        public IHomeScreen SetThemeToDefault()
        {
            var picsApp = new Windows_MC659B_PicturesAndVideoApp();
            picsApp.ResetThemeToDefault();
            return this;
        }


        public INotificationsBar OpenNotificationsBar()
        {
            var bar = new Windows_MC659B_NotificationsBar();
            bar.OpenRunningProgramsMenu();
            return new Windows_MC659B_NotificationsBar();
        }


        public IHomeScreen ConfirmAlarm1On()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1On()
                .ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen ConfirmAlarm1Off()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1Off()
                .ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }


        public IHomeScreen ResetNFCRadioToDefault()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetNFCRadioToDefault().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen TurnOnNFC()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetNFCRadioToOn().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen VerifyNFCOn()
        {
            notificationsBar.BluetoothConnected.WaitForPresent();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen TurnOffNFC()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetNFCRadioToOff().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen VerifyNFCOff()
        {
            notificationsBar.BluetoothConnected.WaitForNotPresent();
            return new Windows_MC659B_HomeDesktop();
        }


        public IHomeScreen ResetWifiRadioToDefault()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetWifiRadioToDefault().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen TurnOnWifi()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetWifiRadioToOn().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen VerifyWifiOn()
        {
            notificationsBar.VerifyWifiOn();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen TurnOffWifi()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetWifiRadioToOff().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen VerifyWifiOff()
        {
            notificationsBar.VerifyWifiOff();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen ConnectToDefaultWifiNetwork()
        {
            
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen DisconnectFromDefaultWifiNetwork()
        {
            
            return new Windows_MC659B_HomeDesktop();
        }


        public INetworkSettings SetCellularNetworkToTwoG()
        {
            networkSettings.SetCellularNetworkToTwoG();
            return new Windows_MC659B_NetworkSettings();
        }

        public INetworkSettings SetCellularNetworkToThreeG()
        {
            networkSettings.SetCellularNetworkToThreeG();
            return new Windows_MC659B_NetworkSettings();
        }

        public IPhoneApp AnswerPhoneCall()
        {
            var phoneApp = new Windows_MC659B_PhoneApp();
            phoneApp.AnswerPhoneCall();
            return new Windows_MC659B_PhoneApp();
        }

        public IPhoneApp EndPhoneCall()
        {
            var phoneApp = new Windows_MC659B_PhoneApp();
            phoneApp.EndPhoneCall();
            return new Windows_MC659B_PhoneApp();
        }
    }
}
