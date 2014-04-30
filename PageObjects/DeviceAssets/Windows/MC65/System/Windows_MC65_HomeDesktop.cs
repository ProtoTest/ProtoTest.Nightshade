using System;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System
{
    public class Windows_MC65_HomeDesktop : IHomeScreen
    {
        public EggplantElement DefaultDesktop = new EggplantElement(By.Image("MC65/System/Themes/Desktop01"));

        public EggplantElement Desktop01 = new EggplantElement(By.Image("MC65/System/Themes/Desktop01"));
        public EggplantElement Desktop02 = new EggplantElement(By.Image("MC65/System/Themes/Desktop02"));
        public EggplantElement Desktop03 = new EggplantElement(By.Image("MC65/System/Themes/Desktop03"));
        public EggplantElement Desktop04 = new EggplantElement(By.Image("MC65/System/Themes/Desktop04"));
        public EggplantElement Desktop05 = new EggplantElement(By.Image("MC65/System/Themes/Desktop05"));
        public EggplantElement Desktop06 = new EggplantElement(By.Image("MC65/System/Themes/Desktop06"));
        public EggplantElement Desktop07 = new EggplantElement(By.Image("MC65/System/Themes/Desktop07"));
        public EggplantElement Desktop08 = new EggplantElement(By.Image("MC65/System/Themes/Desktop08"));
        public EggplantElement Desktop09 = new EggplantElement(By.Image("MC65/System/Themes/Desktop09"));
        public EggplantElement Desktop10 = new EggplantElement(By.Image("MC65/System/Themes/Desktop10"));
        
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_NetworkSettings networkSettings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        
        public IHomeScreen ConfirmHomeScreen()
        {
            Thread.Sleep(3000);
            var menuNav = new Windows_MC65_MenuNav();
            
            popup.IfNetworkingPopupAppearsClickOK();
            if (!DefaultDesktop.IsPresent())
            {
                var picsApp = new Windows_MC65_PicturesAndVideoApp();
                EggplantTestBase.Info("Device's home screen is incorrect.  Fixing...");
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
            EggplantTestBase.Info("Device is on the home screen.");
            DefaultDesktop.WaitForPresent();
            startBar.VerifyElements();
            notificationsBar.VerifyElements();
            return this;
        }

        public IHomeScreen ResetDeviceStateToDefault()
        {
            EggplantTestBase.Info("Resetting device state to default.");
            ReturnToHomeScreen();
            EggplantTestBase.Info("Scanning for presence of notification bar menu.");
            if (notificationsBar.RunningProgramsMenuOKButton.IsPresent())
            {
                notificationsBar.ClickOnMenuOKButton();
            }
            Thread.Sleep(2000);
            int loops = 1;
            EggplantTestBase.Info("Closing any open menus.");
            while (startBar.ExitButton.IsPresent() || startBar.OKButton.IsPresent() || notificationsBar.RunningProgramsMenuOKButton.IsPresent())
            {
                if (loops == 10)
                {
                    throw new Exception("Cannot close menu to return to the desktop after " + loops + " attempts.");
                }
                
                EggplantTestBase.Info("Open menu detected.  Closing now...");
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
                EggplantTestBase.Info("Running programs detected.  Closing now...");
                notificationsBar.ClickOnMenuCloseAllButton();
            }
            notificationsBar.ClickOnMenuOKButton();
            popup.IfNetworkingPopupAppearsClickOK();
            ConfirmHomeScreen();
            return this;
        }

        public IHomeScreen SetThemeToOption(string picNumber)
        {
            var picsApp = new Windows_MC65_PicturesAndVideoApp();
            picsApp.SetThemeToOption(picNumber);
            return this;
        }

        public IHomeScreen SetThemeToDefault()
        {
            var picsApp = new Windows_MC65_PicturesAndVideoApp();
            picsApp.ResetThemeToDefault();
            return this;
        }

        public IHomeScreen ReturnToHomeScreen()
        {
            EggplantTestBase.Info("Returning Device to the home screen.");
            var phoneApp = new Windows_MC65_PhoneApp();
            var startMenu = new Windows_MC65_MenuNav();
            if (phoneApp.CloseAppButton.IsPresent())
            {
                EggplantTestBase.Info("Device is on the phone app.  Returning to home screen without closing app.");
                phoneApp.CloseAppButton.Click();
                Thread.Sleep(1000);
                if(notificationsBar.RunningPrograms.IsPresent())
                {
                    notificationsBar.Battery.Click();
                }
                Thread.Sleep(1000);
                startMenu.GoToHome();
            }
            else
            {
                EggplantTestBase.Info("Closing all active apps.");
                var driver = new EggplantDriver();
                driver.PressKey("F4");
                Thread.Sleep(1000);
                driver.PressKey("F4");
            }
            return this;
        }


        public INotificationsBar OpenNotificationsBar()
        {
            var bar = new Windows_MC65_NotificationsBar();
            bar.OpenNotificationsBarMenu();
            return new Windows_MC65_NotificationsBar();
        }


        public IHomeScreen ConfirmAlarm1On()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1On()
                .ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen ConfirmAlarm1Off()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1Off()
                .ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }


        public IHomeScreen ResetNFCRadioToDefault()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetNFCRadioToDefault().ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen TurnOnNFC()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetNFCRadioToOn().ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen VerifyNFCOn()
        {
            notificationsBar.BluetoothConnected.WaitForPresent();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen TurnOffNFC()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetNFCRadioToOff().ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen VerifyNFCOff()
        {
            notificationsBar.BluetoothConnected.WaitForNotPresent();
            return new Windows_MC65_HomeDesktop();
        }


        public IHomeScreen ResetWifiRadioToDefault()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetWifiRadioToDefault().ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen TurnOnWifi()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetWifiRadioToOn().ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen VerifyWifiOn()
        {
            notificationsBar.VerifyWifiOn();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen TurnOffWifi()
        {
            Command.OnHomeScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetWifiRadioToOff().ClickOnMenuOKButton();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen VerifyWifiOff()
        {
            notificationsBar.VerifyWifiOff();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen ConnectToDefaultWifiNetwork()
        {
            Command.NavigateTheMenu().GoToWifiManagerApp().ConnectToDefaultWifiNetwork().ExitApp();
            return new Windows_MC65_HomeDesktop();
        }

        public IHomeScreen DisconnectFromDefaultWifiNetwork()
        {
            
            return new Windows_MC65_HomeDesktop();
        }


        public INetworkSettings SetCellularNetworkToTwoG()
        {
            networkSettings.SetCellularNetworkToTwoG();
            return new Windows_MC65_NetworkSettings();
        }

        public INetworkSettings SetCellularNetworkToThreeG()
        {
            networkSettings.SetCellularNetworkToThreeG();
            return new Windows_MC65_NetworkSettings();
        }

        public IPhoneApp AnswerPhoneCall()
        {
            var phoneApp = new Windows_MC65_PhoneApp();
            phoneApp.AnswerPhoneCall();
            return new Windows_MC65_PhoneApp();
        }

        public IPhoneApp EndPhoneCall()
        {
            var phoneApp = new Windows_MC65_PhoneApp();
            phoneApp.EndPhoneCall();
            return new Windows_MC65_PhoneApp();
        }

        public IHomeScreen VerifyCallEstablished()
        {
            var phone = new Windows_MC65_PhoneApp();
            phone.VerifyCallEstablished();
            return this;
        }


        public IHomeScreen VerifyTextMessageArrived()
        {
            EggplantTestBase.Info("Verifying Text Message has arrived.");
            notificationsBar.NewMessage.WaitForPresent(30);
            startBar.NotificationOption.WaitForPresent(30);
            startBar.NotificationOption.Click();
            popup.NewTextMessage.WaitForPresent();
            return this;
        }

        public IHomeScreen VerifyEmailArrived()
        {
            EggplantTestBase.Info("Verifying Email has arrived.");
            //notificationsBar.NewMessage.WaitForPresent(30);
            //startBar.NotificationOption.WaitForPresent(30);
            //startBar.NotificationOption.Click();
            //popup.NewTextMessage.WaitForPresent();
            var menuNav = new Windows_MC65_MenuNav();
            menuNav.GoToEmailApp();
            var emailApp = new Windows_MC65_EmailApp();
            emailApp.VerifyEmailArrived();
            emailApp.ExitApp();
            return this;
        }
    }
}
