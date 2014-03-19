using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_HomeDesktop : IHomeScreen
    {
        EggplantElement desktop = new EggplantElement(By.Image("MC659B/System/Desktop"));
        
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();

        public IHomeScreen ConfirmHomeScreen()
        {
            desktop.WaitForPresent();
            startBar.VerifyElements();
            notificationsBar.VerifyElements();
            return this;
        }

        public IHomeScreen ChangeBackground()
        {
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
