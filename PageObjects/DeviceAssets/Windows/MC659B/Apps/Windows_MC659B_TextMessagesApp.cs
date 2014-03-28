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

        public EggplantElement AddRecipientMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/AddRecipientMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/DeleteMenuOption"));
        public EggplantElement NewMessageMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewMessageMenuOption"));
        public EggplantElement MMSMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/MMSMenuOption"));
        public EggplantElement SMSMenuOption = new EggplantElement(By.Image("MC659B/Apps/TextMessages/SMSMenuOption"));

        public EggplantElement InboxIconTextMessage = new EggplantElement(By.Image("MC659B/Apps/TextMessages/InboxIconTextMessage"));

        public EggplantElement SMSSendToField = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewSMS/SendToField"));
        public EggplantElement SMSTextBodyField = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewSMS/TextBodyField"));
        public EggplantElement TextMaxCharacters = new EggplantElement(By.Image("MC659B/Apps/TextMessages/NewSMS/TextMaxCharacters"));
        
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
            EggplantTestBase.Log("Verifying Text Messaging app elements.");
            TextMessagesAppHeader.WaitForPresent();
            ShowingInbox.WaitForPresent();
            SortByReceived.WaitForPresent();
            return this;
        }

        public ITextMessagesApp ResetTextMessagesAppToDefault()
        {
            EggplantTestBase.Log("Resetting Text Messages app to default state.");
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            while (InboxIconTextMessage.IsPresent())
            {
                EggplantTestBase.Log("Previous text message detected in Inbox.  Deleting...");
                InboxIconTextMessage.Click();
                DeleteMenuOption.Click();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            DeletedItemsIcon.Click();
            while (InboxIconTextMessage.IsPresent())
            {
                EggplantTestBase.Log("Previous text message detected in Deleted Items.  Permanently deleting...");
                InboxIconTextMessage.Click();
                DeleteMenuOption.Click();
                popup.ClickYes();
                Thread.Sleep(3000);
            }
            ShowMenuDropdown.Click();
            InboxIcon.Click();
            InboxIconTextMessage.WaitForNotPresent();
            EggplantTestBase.Log("Text Messages app has been to default state.");
            return this;
        }

        public ITextMessagesApp SendSMSWithMaxCharacters(string contactFirst)
        {
            EggplantTestBase.Log("Preparing SMS with Max characters.");
            startBar.MenuButton.Click();
            NewMessageMenuOption.Click();
            SMSMenuOption.Click();
            SMSSendToField.WaitForPresent();
            EggplantTestBase.Log("Adding contact.");
            startBar.MenuButton.Click();
            AddRecipientMenuOption.Click();
            var contacts = new Windows_MC659B_ContactsApp();
            contacts.ClickOnContact(contactFirst);
            EggplantTestBase.Log("Contact added.  Inserting text.");
            SMSTextBodyField.Click();
            var driver = new EggplantDriver(1000);
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
