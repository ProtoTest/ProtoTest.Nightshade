using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_TextMessagesApp : ITextMessagesApp
    {
        public EggplantElement TextMessagesAppHeader = new EggplantElement(By.Image("MC659B/Apps/TextMessages/TextMessagesAppHeader"));
        public EggplantElement ShowMenuDropdown = new EggplantElement(By.Image("MC659B/Apps/TextMessages/ShowMenuDropdown"));
        public EggplantElement ShowingInbox = new EggplantElement(By.Image("MC659B/Apps/TextMessages/ShowingInbox"));
        public EggplantElement ShowingDeletedItems = new EggplantElement(By.Image("MC659B/Apps/TextMessages/ShowingDeletedItems"));
        public EggplantElement SortByReceived = new EggplantElement(By.Image("MC659B/Apps/TextMessages/SortByReceived"));
        public EggplantElement DeletedItemsIcon = new EggplantElement(By.Image("MC659B/Apps/TextMessages/DeletedItemsIcon"));
        public EggplantElement DraftsIcon = new EggplantElement(By.Image("MC659B/Apps/TextMessages/DraftsIcon"));
        public EggplantElement InboxIcon = new EggplantElement(By.Image("MC659B/Apps/TextMessages/InboxIcon"));
        public EggplantElement OutboxIcon = new EggplantElement(By.Image("MC659B/Apps/TextMessages/OutboxIcon"));
        public EggplantElement SentItemsIcon = new EggplantElement(By.Image("MC659B/Apps/TextMessages/SentItemsIcon"));
        public EggplantElement NewTextMessage = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewTextMessage"));
        public EggplantElement OpenedTextMessage = new EggplantElement(By.Image("MC659B/Apps/TextMessages/OpenedTextMessage"));
        public EggplantElement OpenFirstTextMessage = new EggplantElement(By.Image("MC659B/Apps/TextMessages/OpenFirstTextMessage"));

        public EggplantElement AddRecipientMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/AddRecipientMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/DeleteMenuOption"));
        public EggplantElement NewMessageMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMessageMenuOption"));
        public EggplantElement MMSMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/MMSMenuOption"));
        public EggplantElement SMSMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/SMSMenuOption"));

        public EggplantElement InboxIconTextMessage = new EggplantElement(By.Image("MC659B/Apps/TextMessages/InboxIconTextMessage"));

        public EggplantElement SMSSendToField = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewSMS/SendToField"));
        public EggplantElement SMSTextBodyField = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewSMS/TextBodyField"));
        public EggplantElement TextMaxCharacters = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewSMS/TextMaxCharacters"));

        public EggplantElement MMSAddContactFromContactsApp = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/AddContactFromContactsApp"));
        public EggplantElement MMSAttachAudioFile = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/AttachAudioFile"));
        public EggplantElement MMSAttachmentTestFileAudio = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/AttachmentTestFileAudio"));
        public EggplantElement MMSAttachmentTestFileImage = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/AttachmentTestFileImage"));
        public EggplantElement MMSAttachmentTestFileVideo = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/AttachmentTestFileVideo"));
        public EggplantElement MMSAttachPictureOrVideo = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/AttachPictureOrVideo"));
        public EggplantElement MMSFileNavDataFolder = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/FileNavDataFolder"));
        public EggplantElement MMSFileNavMyDocuments = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/FileNavMyDocuments"));
        public EggplantElement MMSInsertContactsField = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/InsertContactsField"));
        public EggplantElement MMSInsertSubjectField = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/InsertSubjectField"));
        public EggplantElement MMSRemoveAttachmentButton = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/RemoveAttachmentButton"));
        public EggplantElement MMSSelectContactMobileNumber = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/SelectContactMobileNumber"));
        public EggplantElement MMSTextBodyField = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/TextBodyField"));
        public EggplantElement MMSTextMessagesFileNav = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMMS/TextMessagesFileNav"));
        
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
            EggplantTestBase.Note("Verifying Text Messaging app elements.");
            TextMessagesAppHeader.WaitForPresent();
            ShowingInbox.WaitForPresent();
            SortByReceived.WaitForPresent();
            return this;
        }

        public ITextMessagesApp ResetTextMessagesAppToDefault()
        {
            EggplantTestBase.Note("Resetting Text Messages app to default state.");
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            while (InboxIconTextMessage.IsPresent())
            {
                EggplantTestBase.Note("Previous text message detected in Inbox.  Deleting...");
                InboxIconTextMessage.Click();
                DeleteMenuOption.Click();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            DeletedItemsIcon.Click();
            while (InboxIconTextMessage.IsPresent())
            {
                EggplantTestBase.Note("Previous text message detected in Deleted Items.  Permanently deleting...");
                InboxIconTextMessage.Click();
                DeleteMenuOption.Click();
                popup.ClickYes();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            InboxIconTextMessage.WaitForNotPresent();
            EggplantTestBase.Note("Text Messages app has been to default state.");
            return this;
        }

        public ITextMessagesApp SendSMSWithMaxCharacters(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Note("Preparing SMS with Max characters.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            SMSMenuOption.Click();
            SMSSendToField.WaitForPresent();
            EggplantTestBase.Note("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            //var contacts = new Windows_MC659B_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            EggplantTestBase.Note("Contact added.  Inserting text.");
            SMSTextBodyField.Click();
            driver.Type("Lorem ipsum dolor sit amet");
            Thread.Sleep(10000);
            driver.Type(", consectetuer adipiscing elit. ");
            Thread.Sleep(10000);
            driver.Type("Aenean commodo ligula eget dolor. ");
            Thread.Sleep(10000);
            driver.Type("Aenean massa. Cum sociis natoque ");
            Thread.Sleep(10000);
            driver.Type("penatibus et magnis dis parturient.");
            TextMaxCharacters.WaitForPresent(30000);
            startBar.SendMessage.Click();
            ExitApp();
            return this;
        }

        public ITextMessagesApp OpenReceivedSMSWithMaxCharacters()
        {
            EggplantTestBase.Note("Opening received SMS with max characters.");
            
            return this;
        }

        public ITextMessagesApp SendMMSWithAudioAttachment(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Note("Preparing MMS with audio attachment.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            MMSMenuOption.Click();
            MMSInsertContactsField.WaitForPresent();
            EggplantTestBase.Note("Adding contact.");
            MMSInsertContactsField.Click();
            //var contacts = new Windows_MC659B_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            MMSSelectContactMobileNumber.Click();
            EggplantTestBase.Note("Contact added.  Inserting text.");
            MMSInsertSubjectField.Click();
            driver.Type("MMS Audio");
            Thread.Sleep(10000);
            startBar.DoneOption.Click();
            MMSTextBodyField.Click();
            driver.Type("MMS Audio");
            startBar.DoneOption.Click();
            EggplantTestBase.Note("Subject and body added.  Attaching audio file.");
            MMSAttachAudioFile.Click();
            MMSAttachmentTestFileAudio.Click();
            Thread.Sleep(3000);
            if (popup.YesButton.IsPresent())
            {
                popup.ClickYes();
            }
            MMSRemoveAttachmentButton.WaitForPresent(15);
            startBar.SendMessage.Click();
            ExitApp();
            notificationsBar.OutgoingTextMessage.WaitForNotPresent(60);
            return this;
        }

        public ITextMessagesApp SendMMSWithImageAttachment(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Note("Preparing MMS with image attachment.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            MMSMenuOption.Click();
            MMSInsertContactsField.WaitForPresent();
            EggplantTestBase.Note("Adding contact.");
            MMSInsertContactsField.Click();
            //var contacts = new Windows_MC659B_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            MMSSelectContactMobileNumber.Click();
            EggplantTestBase.Note("Contact added.  Inserting text.");
            MMSInsertSubjectField.Click();
            driver.Type("MMS Image");
            Thread.Sleep(10000);
            startBar.DoneOption.Click();
            EggplantTestBase.Note("Subject and body added.  Attaching image file.");
            MMSAttachPictureOrVideo.Click();
            MMSAttachmentTestFileImage.Click();
            Thread.Sleep(3000);
            if (popup.YesButton.IsPresent())
            {
                popup.ClickYes();
            }
            MMSRemoveAttachmentButton.WaitForPresent(15);
            startBar.SendMessage.Click();
            ExitApp();
            notificationsBar.OutgoingTextMessage.WaitForNotPresent(60);
            return this;
        }

        public ITextMessagesApp SendMMSWithVideoAttachment(string contactFirst)
        {
            var driver = new EggplantDriver();
            EggplantTestBase.Note("Preparing MMS with video attachment.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            MMSMenuOption.Click();
            MMSInsertContactsField.WaitForPresent();
            EggplantTestBase.Note("Adding contact.");
            MMSInsertContactsField.Click();
            //var contacts = new Windows_MC659B_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            driver.Type(contactFirst);
            Thread.Sleep(2000);
            driver.PressKey("Return");
            MMSSelectContactMobileNumber.Click();
            EggplantTestBase.Note("Contact added.  Inserting text.");
            MMSInsertSubjectField.Click();
            driver.Type("MMS Video");
            Thread.Sleep(10000);
            startBar.DoneOption.Click();
            EggplantTestBase.Note("Subject and body added.  Attaching video file.");
            MMSAttachPictureOrVideo.Click();
            MMSAttachmentTestFileVideo.Click();
            Thread.Sleep(3000);
            if (popup.YesButton.IsPresent())
            {
                popup.ClickYes();
            }
            MMSRemoveAttachmentButton.WaitForPresent(15);
            startBar.SendMessage.Click();
            ExitApp();
            notificationsBar.OutgoingTextMessage.WaitForNotPresent(60);
            return this;
        }

        public ITextMessagesApp OpenReceivedMMSWithAttachment()
        {
            EggplantTestBase.Note("Opening received MMS with attachment.");
            NewTextMessage.WaitForPresent();
            OpenFirstTextMessage.Click();
            var driver = new EggplantDriver();
            driver.LogScreenshot();
            startBar.OKButton.Click();
            return this;
        }

        public ITextMessagesApp VerifySMSReceived()
        {
            EggplantTestBase.Note("Verifying SMS was received.");
            NewTextMessage.WaitForPresent();
            return this;
        }

        public ITextMessagesApp VerifyMMSReceived()
        {
            EggplantTestBase.Note("Verifying MMS was received.");
            NewTextMessage.WaitForPresent();
            return this;
        }

        public ITextMessagesApp ExitApp()
        {
            EggplantTestBase.Note("Exiting Text Messaging app.");
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
