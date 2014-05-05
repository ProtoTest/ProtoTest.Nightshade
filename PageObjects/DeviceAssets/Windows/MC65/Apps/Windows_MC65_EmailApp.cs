using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_EmailApp : IEmailApp
    {
        public EggplantElement AddRecipientMenuOption = new EggplantElement(By.Image("MC65/Apps/Email/AddRecipientMenuOption"));
        public EggplantElement AttachedField = new EggplantElement(By.Image("MC65/Apps/Email/AttachedField"));
        public EggplantElement DeletedItemsIcon = new EggplantElement(By.Image("MC65/Apps/Email/DeletedItemsIcon"));
        //public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC65/Apps/Email/DeleteMenuOption"));
        public EggplantElement EmailBodyField = new EggplantElement(By.Image("MC65/Apps/Email/EmailBodyField"));
        public EggplantElement FileMenuOption = new EggplantElement(By.Image("MC65/Apps/Email/FileMenuOption"));
        public EggplantElement FinishedSync = new EggplantElement(By.Image("MC65/Apps/Email/FinishedSync"));
        public EggplantElement FolderFieldDownArrow = new EggplantElement(By.Image("MC65/Apps/Email/FolderFieldDownArrow"));
        public EggplantElement HotmailAppHeader = new EggplantElement(By.Image("MC65/Apps/Email/HotmailAppHeader"));
        public EggplantElement InboxIcon = new EggplantElement(By.Image("MC65/Apps/Email/InboxIcon"));
        //public EggplantElement InboxIconTextMessage = new EggplantElement(By.Image("MC65/Apps/Email/InboxIconTextMessage"));
        public EggplantElement InsertMenuOption = new EggplantElement(By.Image("MC65/Apps/Email/InsertMenuOption"));
        public EggplantElement MessagingHotmailAccount = new EggplantElement(By.Image("MC65/Apps/Email/MessagingHotmailAccount"));
        public EggplantElement NewEmailInInbox = new EggplantElement(By.Image("MC65/Apps/Email/NewEmailInInbox"));
        public EggplantElement NewMenuOption = new EggplantElement(By.Image("MC65/Apps/Email/NewMenuOption"));
        public EggplantElement OpenedEmail = new EggplantElement(By.Image("MC65/Apps/Email/OpenedEmail"));
        public EggplantElement OpenFirstInboxEmail = new EggplantElement(By.Image("MC65/Apps/Email/OpenFirstInboxEmail"));
        public EggplantElement OutboxIcon = new EggplantElement(By.Image("MC65/Apps/Email/OutboxIcon"));
        public EggplantElement SendingMessage = new EggplantElement(By.Image("MC65/Apps/Email/SendingMessage"));
        public EggplantElement SetupEmailAddressField = new EggplantElement(By.Image("MC65/Apps/Email/SetupEmailAddressField"));
        public EggplantElement SetupEmailOpyion = new EggplantElement(By.Image("MC65/Apps/Email/SetupEmailOpyion"));
        public EggplantElement SetupEmailPasswordField = new EggplantElement(By.Image("MC65/Apps/Email/SetupEmailPasswordField"));
        public EggplantElement SetupNextOption = new EggplantElement(By.Image("MC65/Apps/Email/SetupNextOption"));
        public EggplantElement ShowMenuDropdown = new EggplantElement(By.Image("MC65/Apps/Email/ShowMenuDropdown"));
        public EggplantElement SubjectField = new EggplantElement(By.Image("MC65/Apps/Email/SubjectField"));
        
        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_MenuNav menuNav = new Windows_MC65_MenuNav();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        public Windows_MC65_NetworkSettings settings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_StartMenu startMenu = new Windows_MC65_StartMenu();
        public Enhancements.Windows.MC65.Utilities utilities = new Enhancements.Windows.MC65.Utilities();


        public IEmailApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Email app elements.");
            //
            return this;
        }

        public IEmailApp ResetEmailAppToDefault()
        {
            EggplantTestBase.Info("Resetting Email app to default state.");
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            while (NewEmailInInbox.IsPresent() || OpenedEmail.IsPresent())
            {
                EggplantTestBase.Info("Previous email detected in Inbox.  Deleting...");
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
            //while (NewEmailInInbox.IsPresent() || OpenedEmail.IsPresent())
            //{
            //    EggplantTestBase.Info("Clearing 'Deleted Items' folder...");
            //    startBar.MenuButton.Click();
            //    startBar.ToolsMenuOption.Click();
            //    startBar.EmptyDeletedItemsMenuOption.Click();
            //    popup.ClickYes();
            //    Thread.Sleep(3000);
            //}
            EggplantTestBase.Info("Clearing 'Deleted Items' folder...");
            startBar.MenuButton.Click();
            var driver = new EggplantDriver();
            driver.PressKey("t");
            driver.PressKey("e");
            popup.ClickYes();
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            NewEmailInInbox.WaitForNotPresent();
            OpenedEmail.WaitForNotPresent();
            EggplantTestBase.Info("Email app has been to default state.");
            return this;
        }

        public IEmailApp SendEmailWithNoAttachment(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Info("Preparing email with no attachment.");
            startBar.MenuButton.Click();
            NewMenuOption.Click();
            EggplantTestBase.Info("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            //var contacts = new Windows_MC65_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            EggplantTestBase.Info("Contact added.  Inserting subject...");
            SubjectField.Click();
            driver.Type("Test no atch ");
            string randomNumber = utilities.GetRandomNumberSixDigits();
            driver.Type(randomNumber);
            EggplantTestBase.Info("Subject added.  Inserting body text...");
            Thread.Sleep(5000);
            EmailBodyField.Click();
            driver.Type("Lorem ipsum dolor sit ");
            driver.Type(randomNumber);
            Thread.Sleep(5000);
            EggplantTestBase.Info("Sending email...");
            startBar.SendMessage.Click();
            FinishedSync.WaitForPresent(30);
            //Thread.Sleep(10000);
            EggplantTestBase.Info("Email has been sent.");
            return this;
        }

        public IEmailApp SendEmailWithAnAttachment(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Info("Preparing email with attachment.");
            startBar.MenuButton.Click();
            NewMenuOption.Click();
            EggplantTestBase.Info("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            //var contacts = new Windows_MC65_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            EggplantTestBase.Info("Contact added.  Inserting subject...");
            SubjectField.Click();
            driver.Type("Test no atch ");
            string randomNumber = utilities.GetRandomNumberSixDigits();
            driver.Type(randomNumber);
            EggplantTestBase.Info("Subject added.  Inserting body text...");
            Thread.Sleep(5000);
            EmailBodyField.Click();
            driver.Type("Lorem ipsum dolor sit ");
            driver.Type(randomNumber);
            Thread.Sleep(5000);
            EggplantTestBase.Info("Body text added.  Inserting attachment...");
            startBar.MenuButton.Click();
            startBar.InsertMenuOption.Click();
            startBar.PictureMenuOption.Click();
            var picsApp = new Windows_MC65_PicturesAndVideoApp();
            picsApp.BackgroundPreview01.Click();
            AttachedField.WaitForPresent();
            EggplantTestBase.Info("Sending email...");
            startBar.SendMessage.Click();
            FinishedSync.WaitForPresent(30);
            //Thread.Sleep(30000);
            EggplantTestBase.Info("Email has been sent.");
            return this;
        }

        public IEmailApp SyncEmailAccount()
        {
            EggplantTestBase.Info("Syncing email account.");
            startBar.MenuButton.Click();
            var driver = new EggplantDriver();
            driver.PressKey("UpArrow");
            startBar.SendAndReceiveEmailMenuOption.Click();
            FinishedSync.WaitForPresent(30);
            return this;
        }

        public IEmailApp VerifyEmailArrived()
        {
            EggplantTestBase.Info("Verifying email has arrived.");
            SyncEmailAccount();
            NewEmailInInbox.WaitForPresent();
            var driver = new EggplantDriver();
            driver.LogScreenshot();
            //NewEmailInInbox.Click();
            return this;
        }

        public IEmailApp OpenReceivedEmail()
        {
            EggplantTestBase.Info("Opening received email.");
            OpenFirstInboxEmail.Click();
            var driver = new EggplantDriver();
            driver.LogScreenshot();
            startBar.OKButton.Click();
            return this;
        }

        public IEmailApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Email app.");
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
