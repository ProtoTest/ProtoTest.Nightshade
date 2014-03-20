using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
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

        public IHomeScreen ConfirmHomeScreen()
        {
            DefaultDesktop.WaitForPresent();
            startBar.VerifyElements();
            notificationsBar.VerifyElements();
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

        public IHomeScreen VerifyNFCInDefaultState()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetNFCRadioToDefault().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen TurnOnNFC()
        {
            VerifyNFCInDefaultState();

            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetNFCRadioToOn().ClickOnMenuOKButton();
            return new Windows_MC659B_HomeDesktop();
        }

        public IHomeScreen VerifyNFCOn()
        {
            Command.OnHomeScreenScreen().VerifyNFCOn();
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
            Command.OnHomeScreenScreen().VerifyNFCOff();
            return new Windows_MC659B_HomeDesktop();
        }

        public INotificationsBar OpenNotificationsBar()
        {
            var bar = new Windows_MC659B_NotificationsBar();
            bar.OpenRunningProgramsMenu();
            return new Windows_MC659B_NotificationsBar();
        }

    }
}
