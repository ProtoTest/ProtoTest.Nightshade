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
            desktop.VerifyPresent();
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

        public INotificationsBar OpenNotificationsBar()
        {
            var bar = new Windows_MC659B_NotificationsBar();
            bar.OpenRunningProgramsMenu();
            return new Windows_MC659B_NotificationsBar();
        }

    }
}
