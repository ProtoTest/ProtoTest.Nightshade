using System;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;

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
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        
        public IHomeScreen ConfirmHomeScreen()
        {
            var menuNav = new Windows_MC659B_MenuNav();
            
            popup.IfNetworkingPopupAppearsClickOK();
            if (!DefaultDesktop.IsPresent())
            {
                var picsApp = new Windows_MC659B_PicturesAndVideoApp();
                EggplantTestBase.Note("Device's home screen is incorrect.  Fixing...");
                menuNav.GoToPicturesAndVideoApp();
                Thread.Sleep(1000);
                picsApp.SetUpPicturesAndVideoApp();
                picsApp.BackgroundDefault.Click();
                startBar.MenuOption.Click();
                picsApp.SetAsHomeBackgroundMenuOption.Click();
                Thread.Sleep(5000);
                startBar.OKButton.Click();
                Thread.Sleep(5000);
                startBar.OKButton.Click();
                Thread.Sleep(2000);
                startBar.ExitButton.Click();
            }
            if (!DefaultDesktop.IsPresent())
            {
                throw new Exception("Device is not on the home screen.");
            }
            EggplantTestBase.Note("Device is on the home screen.");
            DefaultDesktop.WaitForPresent();
            startBar.VerifyElements();
            notificationsBar.VerifyElements();
            return this;
        }

        public IHomeScreen ResetDeviceStateToDefault()
        {
            EggplantTestBase.Note("Resetting device state to default.");
            ReturnToHomeScreen();
            EggplantTestBase.Note("Scanning for presence of notification bar menu.");
            if (notificationsBar.RunningProgramsMenuOKButton.IsPresent())
            {
                notificationsBar.ClickOnMenuOKButton();
            }
            Thread.Sleep(2000);
            int loops = 1;
            EggplantTestBase.Note("Closing any open menus.");
            while (startBar.ExitButton.IsPresent() || startBar.OKButton.IsPresent() || notificationsBar.RunningProgramsMenuOKButton.IsPresent())
            {
                if (loops == 10)
                {
                    throw new Exception("Cannot close menu to return to the desktop after " + loops + " attempts.");
                }
                
                EggplantTestBase.Note("Open menu detected.  Closing now...");
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
            notificationsBar.OpenNotificationsBarMenu();
            if (notificationsBar.RunningProgramsCloseAllButton.IsPresent())
            {
                EggplantTestBase.Note("Running programs detected.  Closing now...");
                notificationsBar.ClickOnMenuCloseAllButton();
            }
            notificationsBar.ClickOnMenuOKButton();
            popup.IfNetworkingPopupAppearsClickOK();
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

        public IHomeScreen ReturnToHomeScreen()
        {
            var phoneApp = new Windows_MC659B_PhoneApp();
            var startMenu = new Windows_MC659B_MenuNav();
            if (phoneApp.CloseAppButton.IsPresent())
            {
                phoneApp.CloseAppButton.Click();
                Thread.Sleep(1000);
                if(notificationsBar.RunningPrograms.IsPresent())
                {
                    notificationsBar.Battery.Click();
                }
                Thread.Sleep(1000);
                startBar.StartButton.Click();
                Thread.Sleep(1000);
                startMenu.GoToHome();
            }
            else
            {
                var driver = new EggplantDriver();
                driver.PressKey("F4");
                Thread.Sleep(1000);
                driver.PressKey("F4");
            }
            return this;
        }


        public INotificationsBar OpenNotificationsBar()
        {
            var bar = new Windows_MC659B_NotificationsBar();
            bar.OpenNotificationsBarMenu();
            return new Windows_MC659B_NotificationsBar();
        }


        public IHomeScreen ConfirmAlarm1On()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1On()
                .ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen ConfirmAlarm1Off()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1Off()
                .ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }


        public IHomeScreen ResetNFCRadioToDefault()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetNFCRadioToDefault().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen TurnOnNFC()
        {
            Command.OnHomeScreen()
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
            Command.OnHomeScreen()
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
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetWifiRadioToDefault().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen TurnOnWifi()
        {
            Command.OnHomeScreen()
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
            Command.OnHomeScreen()
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
            Command.NavigateTheMenu().GoToWifiManagerApp().ConnectToDefaultWifiNetwork().ExitApp();
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

        public IHomeScreen VerifyCallEstablished()
        {
            var phone = new Windows_MC659B_PhoneApp();
            phone.VerifyCallEstablished();
            return this;
        }


        public IHomeScreen VerifyTextMessageArrived()
        {
            EggplantTestBase.Note("Verifying Text Message has arrived.");
            notificationsBar.NewMessage.WaitForPresent(30);
            startBar.NotificationOption.WaitForPresent(30);
            startBar.NotificationOption.Click();
            popup.NewTextMessage.WaitForPresent();
            return this;
        }

        public IHomeScreen VerifyEmailArrived()
        {
            EggplantTestBase.Note("Verifying Email has arrived.");
            //notificationsBar.NewMessage.WaitForPresent(30);
            //startBar.NotificationOption.WaitForPresent(30);
            //startBar.NotificationOption.Click();
            //popup.NewTextMessage.WaitForPresent();
            var menuNav = new Windows_MC659B_MenuNav();
            menuNav.GoToEmailApp();
            var emailApp = new Windows_MC659B_EmailApp();
            emailApp.VerifyEmailArrived();
            emailApp.ExitApp();
            return this;
        }
    }
}
