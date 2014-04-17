using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ProtoTest.Nightshade.Enhancements.Windows.MC659B;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_ContactsApp : IContactsApp
    {
        public EggplantElement AddANameOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/AddANameOption"));
        public EggplantElement AddMobileNumberOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/AddMobileNumberOption"));
        public EggplantElement AddEmailOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/AddEmailOption"));
        public EggplantElement ContactsAppHeader = new EggplantElement(By.Image("MC659B/Apps/Contacts/ContactsAppHeader"));
        public EggplantElement CallMobileButton = new EggplantElement(By.Image("MC659B/Apps/Contacts/CallMobileButton"));
        public EggplantElement EnterANameField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterANameField"));
        public EggplantElement EnterCompanyField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterCompanyField"));
        public EggplantElement EnterNameField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterNameField"));
        public EggplantElement ContactFieldDone = new EggplantElement(By.Image("MC659B/Apps/Contacts/MobilePhoneFieldDone"));
        public EggplantElement OutlookContactType = new EggplantElement(By.Image("MC659B/Apps/Contacts/OutlookContactType"));
        public EggplantElement LocalContactIcon = new EggplantElement(By.Image("MC659B/Apps/Contacts/ContactIcon"));
        public EggplantElement ScrollbarDownArrow = new EggplantElement(By.Image("MC659B/Apps/Contacts/ScrollbarDownArrow"));
        public EggplantElement ScrollbarUpArrow = new EggplantElement(By.Image("MC659B/Apps/Contacts/ScrollbarUpArrow"));
        public EggplantElement DeleteContactMenuOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/DeleteContactMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/DeleteMenuOption"));


        public IContactsApp VerifyElements()
        {
            EggplantTestBase.Note("Verifying Contacts app elements.");
            ContactsAppHeader.WaitForPresent();
            EnterANameField.WaitForPresent();
            return this;
        }

        public IContactsApp AddContact(string first, string company, string phone1)
        {
            //MC659B Device only utilizes the FIRSTNAME, COMPANY, and PHONE1 fields
            EggplantTestBase.Note("Adding new contact...");

            //var ContactDataFirstName = new EggplantElement(By.Text(first).InRectangle(SearchRectangle.TopHalf));
            //var ContactDataLameName = new EggplantElement(By.Text(last));
            //var ContactDataCompany = new EggplantElement(By.Text(company).InRectangle(SearchRectangle.TopHalf));
            //var ContactDataPhone1 = new EggplantElement(By.Text(phone1));
            //var ContactDataPhone2 = new EggplantElement(By.Text(phone2));
            //var ContactDataPhone3 = new EggplantElement(By.Text(phone3));
            //var ContactDataEmail1 = new EggplantElement(By.Text(email1));
            //var ContactDataEmail2 = new EggplantElement(By.Text(email2));
            //var ContactDataEmail3 = new EggplantElement(By.Text(email3));
            //var ContactDataIM1 = new EggplantElement(By.Text(im1));
            //var ContactDataIM2 = new EggplantElement(By.Text(im2));
            //var ContactDataIM3 = new EggplantElement(By.Text(im3));

            //EggplantTestBase.Note("SETUP: Adding contact data from Setup Files - Contacts.csv.");
            //EggplantTestBase.Note("Fetching contact data...");
            //EggplantTestBase.Note("Contact #: (" + handle + ")");
            //EggplantTestBase.Note("First name: (" + first + ")");
            //EggplantTestBase.Note("Company: (" + company + ")");
            //EggplantTestBase.Note("Phone1: (" + phone1 + ")");
            //EggplantTestBase.Note("Email1: (" + email1 + ")");
            
            var startBar = new Windows_MC659B_StartBar();
            startBar.AddItemButton.Click();
            OutlookContactType.Click();
            AddANameOption.Click();
            EnterNameField.Type(first);
            EnterCompanyField.Type(company);
            startBar.OKButton.Click();
            //ContactDataFirstName.WaitForPresent(10);
            //ContactDataCompany.WaitForPresent(10);
            AddMobileNumberOption.Click();
            var driver = new EggplantDriver();
            driver.Type(phone1);
            Thread.Sleep(3000);
            ContactFieldDone.Click();
            //AddEmailOption.Click();
            //driver.Type(email1);
            //Thread.Sleep(3000);
            //ContactFieldDone.Click();
            //ContactDataPhone1.WaitForPresent(10);
            startBar.OKButton.Click();
            //ContactDataFirstName.WaitForPresent(10);
            //ContactDataPhone1.WaitForPresent(10);
            return this;
        }

        public void ClickOnContact(string contactName)
        {
            var contact = new EggplantElement(By.Text(contactName));
            contact.Click();
        }

        public IContactsApp DeleteContact(string first, string company, string phone1)
        {
            EggplantTestBase.Note("Deleting contact (" + first + ") from device.");
            //var ContactDataFirstName = new EggplantElement(By.Text(first).InRectangle(SearchRectangle.TopHalf));
            var utilities = new Utilities();
            //utilities.SearchForContact(ContactDataFirstName);
            //ContactDataFirstName.Click();
            LocalContactIcon.Click();
            Thread.Sleep(2000);
            //ContactDataFirstName.WaitForPresent();
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            DeleteContactMenuOption.Click();
            var popup = new Windows_MC659B_Popups();
            popup.ClickYes();
            //ContactDataFirstName.WaitForNotPresent();
            EggplantTestBase.Note("Contact deleted.");
            return this;
        }

        public IContactsApp AddContactsToDelete(int totalNum)
        {
            EggplantTestBase.Note("Adding (" + totalNum + ") total contacts to Contacts app.");
            int iterationsDone = 0;
            for (int i = 1; i < totalNum + 1; i++)
            {
                //EggplantTestBase.Note("Running loop #" + i);
                string handleNum;
                if (i < 10)
                {
                    string num = i.ToString();
                    handleNum = "0" + num;
                }
                else
                {
                    string num = i.ToString();
                    handleNum = num;
                }
                string handle = handleNum;
                string first = "AddedContact" + handle;
                string company = "Acme";
                string phone1 = "1234567890";
                EggplantTestBase.Note("Contact (" + first + ", " + company + ", " + phone1 + ") is now being added to Contacts app.");
                AddContact(first, company, phone1);
                iterationsDone = i; 
            }

            EggplantTestBase.Note("Added (" + iterationsDone + ") total contacts to Contacts app.");
            return this;
        }

        public IContactsApp DeleteAddedContacts()
        {
            EggplantTestBase.Note("Deleting all added contacts from Contacts app.");
            //LocalContactIcon.WaitForPresent();
            var driver = new EggplantDriver();
            driver.LogScreenshot();
            int i = 0;
            while (LocalContactIcon.IsPresent())
            {
                i++;
                EggplantTestBase.Note("Previously added Contact detected.  Deleting...");
                LocalContactIcon.Click();
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                DeleteContactMenuOption.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
                //ContactDataFirstName.WaitForNotPresent();
                EggplantTestBase.Note("Contact #"+ i + " deleted.");
                Thread.Sleep(2000);
                //string first = "Added";
                //string company = "Acme";
                //string phone1 = "1234567890";
                //DeleteContact(first, company, phone1);
            }
            //ContactDataFirstName.WaitForNotPresent();
            EggplantTestBase.Note("All previously added contacts (" + i + "  total) deleted.");
            return this;
        }

        public IContactsApp DeleteAllContacts()
        {
            EggplantTestBase.Note("Deleting all contacts from device.");
            //while (ContactIcon.IsPresent())
            //{
            //    var startBar = new Windows_MC659B_StartBar();
            //    startBar.MenuButton.Click();
            EggplantTestBase.Note("FUNCTION DISABLED - Recheck use in test.");
            //    DeleteMenuOption.Click();
            //    var popup = new Windows_MC659B_Popups();
            //    popup.ClickYes();
            //}
            EggplantTestBase.Note("All contacts have been deleted.");
            return this;
        }

        public IContactsApp ExitApp()
        {
            EggplantTestBase.Note("Exiting Contacts app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
