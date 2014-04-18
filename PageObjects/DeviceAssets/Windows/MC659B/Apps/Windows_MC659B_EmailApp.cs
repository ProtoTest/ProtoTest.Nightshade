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
        public EggplantElement AttachedField = new EggplantElement(By.Image("MC659B/Apps/Email/AttachedField"));
        public EggplantElement DeletedItemsIcon = new EggplantElement(By.Image("MC659B/Apps/Email/DeletedItemsIcon"));
        //public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/DeleteMenuOption"));
        public EggplantElement EmailBodyField = new EggplantElement(By.Image("MC659B/Apps/Email/EmailBodyField"));
        public EggplantElement FileMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/FileMenuOption"));
        public EggplantElement FinishedSync = new EggplantElement(By.Image("MC659B/Apps/Email/FinishedSync"));
        public EggplantElement FolderFieldDownArrow = new EggplantElement(By.Image("MC659B/Apps/Email/FolderFieldDownArrow"));
        public EggplantElement HotmailAppHeader = new EggplantElement(By.Image("MC659B/Apps/Email/HotmailAppHeader"));
        public EggplantElement InboxIcon = new EggplantElement(By.Image("MC659B/Apps/Email/InboxIcon"));
        //public EggplantElement InboxIconTextMessage = new EggplantElement(By.Image("MC659B/Apps/Email/InboxIconTextMessage"));
        public EggplantElement InsertMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/InsertMenuOption"));
        public EggplantElement MessagingHotmailAccount = new EggplantElement(By.Image("MC659B/Apps/Email/MessagingHotmailAccount"));
        public EggplantElement NewEmailInInbox = new EggplantElement(By.Image("MC659B/Apps/Email/NewEmailInInbox"));
        public EggplantElement NewMenuOption = new EggplantElement(By.Image("MC659B/Apps/Email/NewMenuOption"));
        public EggplantElement OpenedEmail = new EggplantElement(By.Image("MC659B/Apps/Email/OpenedEmail"));
        public EggplantElement OpenFirstInboxEmail = new EggplantElement(By.Image("MC659B/Apps/Email/OpenFirstInboxEmail"));
        public EggplantElement OutboxIcon = new EggplantElement(By.Image("MC659B/Apps/Email/OutboxIcon"));
        public EggplantElement SendingMessage = new EggplantElement(By.Image("MC659B/Apps/Email/SendingMessage"));
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
            EggplantTestBase.Note("Verifying Email app elements.");
            //
            return this;
        }

        public IEmailApp ResetEmailAppToDefault()
        {
            EggplantTestBase.Note("Resetting Email app to default state.");
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            while (NewEmailInInbox.IsPresent() || OpenedEmail.IsPresent())
            {
                EggplantTestBase.Note("Previous email detected in Inbox.  Deleting...");
                if (NewEmailInInbox.IsPresent())
                {
                    NewEmailInInbox.Click();
                    startBar.DeleteMenuOption.Click();
                    Thread.Sleep(1000);
                }
                Thread.Sleep(3000);
                if (OpenedEmail.IsPresent())
                {
                    OpenedEmail.Click();
                    startBar.DeleteMenuOption.Click();
                    Thread.Sleep(1000);
                }
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            DeletedItemsIcon.Click();
            while (NewEmailInInbox.IsPresent() || OpenedEmail.IsPresent())
            {
                EggplantTestBase.Note("Clearing 'Deleted Items' folder...");
                startBar.MenuButton.Click();
                startBar.ToolsMenuOption.Click();
                startBar.EmptyDeletedItemsMenuOption.Click();
                popup.ClickYes();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            NewEmailInInbox.WaitForNotPresent();
            OpenedEmail.WaitForNotPresent();
            EggplantTestBase.Note("Email app has been to default state.");
            return this;
        }

        public IEmailApp SendEmailWithNoAttachment(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Note("Preparing email with no attachment.");
            startBar.MenuButton.Click();
            NewMenuOption.Click();
            EggplantTestBase.Note("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            //var contacts = new Windows_MC659B_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            EggplantTestBase.Note("Contact added.  Inserting subject...");
            SubjectField.Click();
            driver.Type("Test no atch ");
            string randomNumber = utilities.GetRandomNumberSixDigits();
            driver.Type(randomNumber);
            EggplantTestBase.Note("Subject added.  Inserting body text...");
            Thread.Sleep(5000);
            SubjectField.Click();
            driver.Type("Lorem ipsum dolor sit ");
            driver.Type(randomNumber);
            Thread.Sleep(5000);
            EggplantTestBase.Note("Sending email...");
            startBar.SendMessage.Click();
            Thread.Sleep(10000);
            return this;
        }

        public IEmailApp SendEmailWithAnAttachment(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Note("Preparing email with attachment.");
            startBar.MenuButton.Click();
            NewMenuOption.Click();
            EggplantTestBase.Note("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            //var contacts = new Windows_MC659B_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            EggplantTestBase.Note("Contact added.  Inserting subject...");
            SubjectField.Click();
            driver.Type("Test no atch ");
            string randomNumber = utilities.GetRandomNumberSixDigits();
            driver.Type(randomNumber);
            EggplantTestBase.Note("Subject added.  Inserting body text...");
            Thread.Sleep(5000);
            SubjectField.Click();
            driver.Type("Lorem ipsum dolor sit ");
            driver.Type(randomNumber);
            Thread.Sleep(5000);
            EggplantTestBase.Note("Body text added.  Inserting attachment...");
            startBar.MenuButton.Click();
            startBar.InsertMenuOption.Click();
            startBar.PictureMenuOption.Click();
            var picsApp = new Windows_MC659B_PicturesAndVideoApp();
            picsApp.BackgroundPreview01.Click();
            AttachedField.WaitForPresent();
            EggplantTestBase.Note("Sending email...");
            startBar.SendMessage.Click();
            Thread.Sleep(30000);
            return this;
        }

        public IEmailApp SyncEmailAccount()
        {
            startBar.MenuButton.Click();
            var driver = new EggplantDriver();
            driver.PressKey("UpArrow");
            startBar.SendAndReceiveEmailMenuOption.Click();
            FinishedSync.WaitForPresent(30);
            return this;
        }

        public IEmailApp VerifyEmailArrived()
        {
            SyncEmailAccount();
            NewEmailInInbox.WaitForPresent();
            var driver = new EggplantDriver();
            driver.LogScreenshot();
            //NewEmailInInbox.Click();
            return this;
        }

        public IEmailApp OpenReceivedEmail()
        {
            OpenFirstInboxEmail.Click();
            var driver = new EggplantDriver();
            driver.LogScreenshot();
            startBar.OKButton.Click();
            return this;
        }

        public IEmailApp ExitApp()
        {
            EggplantTestBase.Note("Exiting Email app.");
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
