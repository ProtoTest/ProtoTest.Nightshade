using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_EmailApp : IEmailApp
    {
        public EggplantElement AddRecipientMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/AddRecipientMenuOption"));
        public EggplantElement DeletedItemsIcon = new EggplantElement(By.Image("MC659B/Apps/Email/DeletedItemsIcon"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/DeleteMenuOption"));
        public EggplantElement EmailBodyField = new EggplantElement(By.Image("MC659B/Apps/Email/EmailBodyField"));
        public EggplantElement FileMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/FileMenuOption"));
        public EggplantElement FolderFieldDownArrow = new EggplantElement(By.Image("MC659B/Apps/Email/FolderFieldDownArrow"));
        public EggplantElement HotmailAppHeader = new EggplantElement(By.Image("MC659B/Apps/Email/HotmailAppHeader"));
        public EggplantElement InboxIcon = new EggplantElement(By.Image("MC659B/Apps/Email/InboxIcon"));
        public EggplantElement InboxIconTextMessage = new EggplantElement(By.Image("MC659B/Apps/Email/InboxIconTextMessage"));
        public EggplantElement InsertMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/InsertMenuOption"));
        public EggplantElement MessagingHotmailAccount = new EggplantElement(By.Image("MC659B/Apps/Email/MessagingHotmailAccount"));
        public EggplantElement NewMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/NewMenuOption"));
        public EggplantElement SetupEmailAddressField = new EggplantElement(By.Image("MC659B/Apps/Email/SetupEmailAddressField"));
        public EggplantElement SetupEmailOpyion = new EggplantElement(By.Image("MC659B/Apps/Email/SetupEmailOpyion"));
        public EggplantElement SetupEmailPasswordField = new EggplantElement(By.Image("MC659B/Apps/Email/SetupEmailPasswordField"));
        public EggplantElement SetupNextOption = new EggplantElement(By.Image("MC659B/Apps/Email/SetupNextOption"));
        public EggplantElement ShowMenuDropdown = new EggplantElement(By.Image("MC659B/Apps/Email/ShowMenuDropdown"));
        public EggplantElement SubjectField = new EggplantElement(By.Image("MC659B/Apps/Email/SubjectField"));
        
        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_MenuNav menuNav = new Windows_MC659B_MenuNav();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        public Windows_MC659B_NetworkSettings settings = new Windows_MC659B_NetworkSettings();
        public Windows_MC659B_StartMenu startMenu = new Windows_MC659B_StartMenu();
        public Enhancements.Windows.MC659B.Utilities utilities = new Enhancements.Windows.MC659B.Utilities();


        public IEmailApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Email app elements.");
            //
            return this;
        }

        public IEmailApp ResetEmailAppToDefault()
        {
            EggplantTestBase.Log("Resetting Email app to default state.");
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            while (InboxIconTextMessage.IsPresent())
            {
                EggplantTestBase.Log("Previous email detected in Inbox.  Deleting...");
                InboxIconTextMessage.Click();
                DeleteMenuOption.Click();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            DeletedItemsIcon.Click();
            while (InboxIconTextMessage.IsPresent())
            {
                EggplantTestBase.Log("Previous email detected in Deleted Items.  Permanently deleting...");
                InboxIconTextMessage.Click();
                DeleteMenuOption.Click();
                popup.ClickYes();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            InboxIconTextMessage.WaitForNotPresent();
            EggplantTestBase.Log("Email app has been to default state.");
            return this;
        }

        public IEmailApp SendEmailWithNoAttachment(string contactFirst)
        {
            EggplantTestBase.Log("Preparing email with no attachment.");
            startBar.MenuButton.Click();
            NewMenuOption.Click();
            EggplantTestBase.Log("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            var contacts = new Windows_MC659B_ContactsApp();
            contacts.ClickOnContact(contactFirst);
            EggplantTestBase.Log("Contact added.  Inserting subject.");
            SubjectField.Click();
            var driver = new EggplantDriver();
            driver.Type("Test no atch");
            EggplantTestBase.Log("Subject added.  Inserting body text.");
            Thread.Sleep(10000);
            driver.Type("Lorem ipsum dolor sit amet con");
            Thread.Sleep(10000);
            startBar.SendMessage.Click();
            return this;
        }

        public IEmailApp SendEmailWithAnAttachment(string contactFirst)
        {
            throw new global::System.NotImplementedException();
        }

        public IEmailApp VerifyEmailArrived()
        {
            throw new global::System.NotImplementedException();
        }

        public IEmailApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Email app.");
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
