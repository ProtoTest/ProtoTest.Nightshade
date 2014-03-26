using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_TextMessagesApp : ITextMessagesApp
    {
        public EggplantElement TextMessagesAppHeader = new EggplantElement(By.Image("MC659B/Apps/TextMessages/TextMessagesAppHeader"));
        public EggplantElement ShowingInbox = new EggplantElement(By.Image("MC659B/Apps/TextMessages/ShowingInbox"));
        public EggplantElement SortByReceived = new EggplantElement(By.Image("MC659B/Apps/TextMessages/SortByReceived"));
        
        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_MenuNav menuNav = new Windows_MC659B_MenuNav();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        public Windows_MC659B_NetworkSettings settings = new Windows_MC659B_NetworkSettings();
        public Windows_MC659B_StartMenu startMenu = new Windows_MC659B_StartMenu();
        public Enhancements.Windows.MC659B.Utilities utilities = new Enhancements.Windows.MC659B.Utilities();


        public ITextMessagesApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Text Messaging elements.");
            TextMessagesAppHeader.WaitForPresent();
            ShowingInbox.WaitForPresent();
            SortByReceived.WaitForPresent();
            return this;
        }

        public ITextMessagesApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Text Messaging app.");
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
