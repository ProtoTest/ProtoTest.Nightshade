﻿using System.Runtime.Remoting.Messaging;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_TextMessagesApp : ITextMessagesApp
    {
        public EggplantElement TextMessagesAppHeader = new EggplantElement(By.Image("MC65/Apps/TextMessages/TextMessagesAppHeader"));
        public EggplantElement ShowMenuDropdown = new EggplantElement(By.Image("MC65/Apps/TextMessages/ShowMenuDropdown"));
        public EggplantElement ShowingInbox = new EggplantElement(By.Image("MC65/Apps/TextMessages/ShowingInbox"));
        public EggplantElement ShowingDeletedItems = new EggplantElement(By.Image("MC65/Apps/TextMessages/ShowingDeletedItems"));
        public EggplantElement SortByReceived = new EggplantElement(By.Image("MC65/Apps/TextMessages/SortByReceived"));
        public EggplantElement DeletedItemsIcon = new EggplantElement(By.Image("MC65/Apps/TextMessages/DeletedItemsIcon"));
        public EggplantElement DraftsIcon = new EggplantElement(By.Image("MC65/Apps/TextMessages/DraftsIcon"));
        public EggplantElement InboxIcon = new EggplantElement(By.Image("MC65/Apps/TextMessages/InboxIcon"));
        public EggplantElement OutboxIcon = new EggplantElement(By.Image("MC65/Apps/TextMessages/OutboxIcon"));
        public EggplantElement SentItemsIcon = new EggplantElement(By.Image("MC65/Apps/TextMessages/SentItemsIcon"));
        public EggplantElement NewTextMessage = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewTextMessage"));
        public EggplantElement OpenedTextMessage = new EggplantElement(By.Image("MC65/Apps/TextMessages/OpenedTextMessage"));
        public EggplantElement OpenFirstTextMessage = new EggplantElement(By.Image("MC65/Apps/TextMessages/OpenFirstTextMessage"));

        public EggplantElement AddRecipientMenuOption = new EggplantElement(By.Image("MC65/Apps/TextMessages/AddRecipientMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC65/Apps/TextMessages/DeleteMenuOption"));
        public EggplantElement NewMessageMenuOption = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMessageMenuOption"));
        public EggplantElement MMSMenuOption = new EggplantElement(By.Image("MC65/Apps/TextMessages/MMSMenuOption"));
        public EggplantElement SMSMenuOption = new EggplantElement(By.Image("MC65/Apps/TextMessages/SMSMenuOption"));

        public EggplantElement InboxIconTextMessage = new EggplantElement(By.Image("MC65/Apps/TextMessages/InboxIconTextMessage"));

        public EggplantElement SMSSendToField = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewSMS/SendToField"));
        public EggplantElement SMSTextBodyField = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewSMS/TextBodyField"));
        public EggplantElement TextMaxCharacters = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewSMS/TextMaxCharacters"));

        public EggplantElement MMSAddContactFromContactsApp = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/AddContactFromContactsApp"));
        public EggplantElement MMSAttachAudioFile = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/AttachAudioFile"));
        public EggplantElement MMSAttachmentTestFileAudio = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/AttachmentTestFileAudio"));
        public EggplantElement MMSAttachmentTestFileImage = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/AttachmentTestFileImage"));
        public EggplantElement MMSAttachmentTestFileVideo = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/AttachmentTestFileVideo"));
        public EggplantElement MMSAttachPictureOrVideo = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/AttachPictureOrVideo"));
        public EggplantElement MMSFileNavDataFolder = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/FileNavDataFolder"));
        public EggplantElement MMSFileNavMyDocuments = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/FileNavMyDocuments"));
        public EggplantElement MMSInsertContactsField = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/InsertContactsField"));
        public EggplantElement MMSInsertSubjectField = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/InsertSubjectField"));
        public EggplantElement MMSRemoveAttachmentButton = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/RemoveAttachmentButton"));
        public EggplantElement MMSSelectContactMobileNumber = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/SelectContactMobileNumber"));
        public EggplantElement MMSTextBodyField = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/TextBodyField"));
        public EggplantElement MMSTextMessagesFileNav = new EggplantElement(By.Image("MC65/Apps/TextMessages/NewMMS/TextMessagesFileNav"));
        
        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_MenuNav menuNav = new Windows_MC65_MenuNav();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        public Windows_MC65_NetworkSettings settings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_StartMenu startMenu = new Windows_MC65_StartMenu();
        public Enhancements.Windows.MC65.Utilities utilities = new Enhancements.Windows.MC65.Utilities();


        public ITextMessagesApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Text Messaging app elements.");
            TextMessagesAppHeader.WaitForPresent();
            ShowingInbox.WaitForPresent();
            SortByReceived.WaitForPresent();
            return this;
        }

        public ITextMessagesApp ResetTextMessagesAppToDefault()
        {
            EggplantTestBase.Info("Resetting Text Messages app to default state.");
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            while (InboxIconTextMessage.IsPresent())
            {
                EggplantTestBase.Info("Previous text message detected in Inbox.  Deleting...");
                InboxIconTextMessage.Click();
                DeleteMenuOption.Click();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            DeletedItemsIcon.Click();
            Thread.Sleep(3000);
            //while (InboxIconTextMessage.IsPresent())
            //{
            //    EggplantTestBase.Info("Previous text message detected in Deleted Items.  Permanently deleting...");
            //    InboxIconTextMessage.Click();
            //    DeleteMenuOption.Click();
            //    popup.ClickYes();
            //    Thread.Sleep(3000);
            //}
            EggplantTestBase.Info("Permanently deleting all text messages...");
            startBar.MenuButton.Click();
            EggplantTestBase.Driver.PressKey("t");
            EggplantTestBase.Driver.PressKey("e");
            popup.ClickYes();
            EggplantTestBase.Info("Returning to inbox...");
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            InboxIconTextMessage.WaitForNotPresent();
            EggplantTestBase.Info("Text Messages app has been to default state.");
            return this;
        }

        public void CloseKeyboardOverlayIfPresent()
        {
            EggplantTestBase.Info("Scanning for presence of keyboard overlay.");
            if (startBar.KeyboardButtonOpened.IsPresent())
            {
                EggplantTestBase.Info("Keyboard overlay detected.  Closing...");
                startBar.KeyboardButtonOpened.Click();
            }
        }

        public void NavigateToTestFilesFolder()
        {
            if (!MMSAttachmentTestFileAudio.IsPresent())
            {
                Thread.Sleep(1000);
                MMSTextMessagesFileNav.Click();
                MMSFileNavMyDocuments.Click();
                MMSFileNavDataFolder.Click();
            }
            EggplantTestBase.Info("File navigation is on the test file folder.");
        }

        public ITextMessagesApp SendSMSWithMaxCharacters(string contactFirst)
        {
            EggplantTestBase.Info("Preparing SMS with Max characters.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            SMSMenuOption.Click();
            SMSSendToField.WaitForPresent();
            EggplantTestBase.Info("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            //var contacts = new Windows_MC65_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            EggplantTestBase.Driver.Type(contactFirst);
            Thread.Sleep(2000);
            EggplantTestBase.Driver.PressKey("Return");
            Thread.Sleep(3000);
            if (MMSSelectContactMobileNumber.IsPresent())
            {
                EggplantTestBase.Info("Multiple send options detected.  Selecting mobile number...");
                MMSSelectContactMobileNumber.Click();
            }
            EggplantTestBase.Info("Contact added.  Inserting text.");
            SMSTextBodyField.Click();
            EggplantTestBase.Driver.Type("Lorem ipsum dolor sit amet");
            Thread.Sleep(10000);
            EggplantTestBase.Driver.Type(", consectetuer adipiscing elit. ");
            Thread.Sleep(10000);
            EggplantTestBase.Driver.Type("Aenean commodo ligula eget dolor. ");
            Thread.Sleep(10000);
            EggplantTestBase.Driver.Type("Aenean massa. Cum sociis natoque ");
            Thread.Sleep(10000);
            EggplantTestBase.Driver.Type("penatibus et magnis dis parturient.");
            Thread.Sleep(10000);
            CloseKeyboardOverlayIfPresent();
            TextMaxCharacters.WaitForPresent(30000);
            if(startBar.SendMessage.IsPresent())
            {
                startBar.SendMessage.Click();
            }
            if(startBar.SendOption.IsPresent())
            {
                startBar.SendOption.Click();
            }
            //ExitApp();
            Thread.Sleep(3000);
            notificationsBar.OutgoingTextMessage.WaitForNotPresent(60);
            return this;
        }

        public ITextMessagesApp OpenReceivedSMSWithMaxCharacters()
        {
            EggplantTestBase.Info("Opening received SMS with max characters.");
            //NewTextMessage.WaitForPresent();
            OpenFirstTextMessage.Click();
            EggplantTestBase.Driver.LogScreenshot();
            startBar.OKButton.Click();
            return this;
        }

        public ITextMessagesApp SendMMSWithAudioAttachment(string contactFirst)
        {
            EggplantTestBase.Info("Preparing MMS with audio attachment.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            MMSMenuOption.Click();
            MMSInsertContactsField.WaitForPresent();
            EggplantTestBase.Info("Adding contact.");
            MMSInsertContactsField.Click();
            MMSAddContactFromContactsApp.Click();
            Thread.Sleep(1000);
            //var contacts = new Windows_MC65_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            EggplantTestBase.Driver.Type(contactFirst);
            Thread.Sleep(2000);
            EggplantTestBase.Driver.PressKey("Return");
            Thread.Sleep(3000);
            if(MMSSelectContactMobileNumber.IsPresent())
            {
                EggplantTestBase.Info("Multiple send options detected.  Selecting mobile number...");
                MMSSelectContactMobileNumber.Click();
            }
            EggplantTestBase.Info("Contact added.  Inserting text.");
            MMSInsertSubjectField.Click();
            EggplantTestBase.Driver.Type("MMS Audio");
            Thread.Sleep(10000);
            startBar.DoneOption.Click();
            MMSTextBodyField.Click();
            EggplantTestBase.Driver.Type("MMS Audio");
            startBar.DoneOption.Click();
            EggplantTestBase.Info("Subject and body added.  Attaching audio file.");
            MMSAttachAudioFile.Click();
            NavigateToTestFilesFolder();
            MMSAttachmentTestFileAudio.Click();
            Thread.Sleep(3000);
            if (popup.YesButton.IsPresent())
            {
                popup.ClickYes();
            }
            MMSRemoveAttachmentButton.WaitForPresent(15);
            if(startBar.SendMessage.IsPresent())
            {
                startBar.SendMessage.Click();
            }
            if(startBar.SendOption.IsPresent())
            {
                startBar.SendOption.Click();
            }
            //ExitApp();
            Thread.Sleep(3000);
            notificationsBar.OutgoingTextMessage.WaitForNotPresent(60);
            notificationsBar.OutgoingTextMessageSent.WaitForPresent(120);
            return this;
        }

        public ITextMessagesApp SendMMSWithImageAttachment(string contactFirst)
        {
            EggplantTestBase.Info("Preparing MMS with image attachment.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            MMSMenuOption.Click();
            MMSInsertContactsField.WaitForPresent();
            EggplantTestBase.Info("Adding contact.");
            MMSInsertContactsField.Click();
            MMSAddContactFromContactsApp.Click();
            Thread.Sleep(1000);
            //var contacts = new Windows_MC65_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            EggplantTestBase.Driver.Type(contactFirst);
            Thread.Sleep(2000);
            EggplantTestBase.Driver.PressKey("Return");
            Thread.Sleep(3000);
            if (MMSSelectContactMobileNumber.IsPresent())
            {
                EggplantTestBase.Info("Multiple send options detected.  Selecting mobile number...");
                MMSSelectContactMobileNumber.Click();
            }
            EggplantTestBase.Info("Contact added.  Inserting text.");
            MMSInsertSubjectField.Click();
            EggplantTestBase.Driver.Type("MMS Image");
            Thread.Sleep(10000);
            startBar.DoneOption.Click();
            EggplantTestBase.Info("Subject and body added.  Attaching image file.");
            MMSAttachPictureOrVideo.Click();
            NavigateToTestFilesFolder();
            MMSAttachmentTestFileImage.Click();
            Thread.Sleep(3000);
            if (popup.YesButton.IsPresent())
            {
                popup.ClickYes();
            }
            MMSRemoveAttachmentButton.WaitForPresent(15);
            if(startBar.SendMessage.IsPresent())
            {
                startBar.SendMessage.Click();
            }
            if(startBar.SendOption.IsPresent())
            {
                startBar.SendOption.Click();
            }
            //ExitApp();
            Thread.Sleep(3000);
            notificationsBar.OutgoingTextMessage.WaitForNotPresent(60);
            notificationsBar.OutgoingTextMessageSent.WaitForPresent(120);
            return this;
        }

        public ITextMessagesApp SendMMSWithVideoAttachment(string contactFirst)
        {
            EggplantTestBase.Info("Preparing MMS with video attachment.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            MMSMenuOption.Click();
            MMSInsertContactsField.WaitForPresent();
            EggplantTestBase.Info("Adding contact.");
            MMSInsertContactsField.Click();
            MMSAddContactFromContactsApp.Click();
            Thread.Sleep(1000);
            //var contacts = new Windows_MC65_ContactsApp();
            //contacts.ClickOnContact(contactFirst);
            EggplantTestBase.Driver.Type(contactFirst);
            Thread.Sleep(2000);
            EggplantTestBase.Driver.PressKey("Return");
            Thread.Sleep(3000);
            if (MMSSelectContactMobileNumber.IsPresent())
            {
                EggplantTestBase.Info("Multiple send options detected.  Selecting mobile number...");
                MMSSelectContactMobileNumber.Click();
            }
            EggplantTestBase.Info("Contact added.  Inserting text.");
            MMSInsertSubjectField.Click();
            EggplantTestBase.Driver.Type("MMS Video");
            Thread.Sleep(10000);
            startBar.DoneOption.Click();
            EggplantTestBase.Info("Subject and body added.  Attaching video file.");
            MMSAttachPictureOrVideo.Click();
            NavigateToTestFilesFolder();
            MMSAttachmentTestFileVideo.Click();
            Thread.Sleep(3000);
            if (popup.YesButton.IsPresent())
            {
                popup.ClickYes();
            }
            MMSRemoveAttachmentButton.WaitForPresent(15);
            if(startBar.SendMessage.IsPresent())
            {
                startBar.SendMessage.Click();
            }
            if(startBar.SendOption.IsPresent())
            {
                startBar.SendOption.Click();
            }
            //ExitApp();
            Thread.Sleep(3000);
            notificationsBar.OutgoingTextMessage.WaitForNotPresent(60);
            notificationsBar.OutgoingTextMessageSent.WaitForPresent(120);
            return this;
        }

        public ITextMessagesApp OpenReceivedMMSWithAttachment()
        {
            EggplantTestBase.Info("Opening received MMS with attachment.");
            NewTextMessage.WaitForPresent();
            OpenFirstTextMessage.Click();
            EggplantTestBase.Driver.LogScreenshot();
            startBar.OKButton.Click();
            return this;
        }

        public ITextMessagesApp VerifySMSReceived()
        {
            EggplantTestBase.Info("Verifying SMS was received.");
            NewTextMessage.WaitForPresent();
            return this;
        }

        public ITextMessagesApp VerifyMMSReceived()
        {
            EggplantTestBase.Info("Verifying MMS was received.");
            NewTextMessage.WaitForPresent();
            return this;
        }

        public ITextMessagesApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Text Messaging app.");
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
