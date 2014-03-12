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

        public IHomeScreen EnterStartMenu()
        {
            startBar.EnterStartMenu();
            return this;
        }


    }
}
