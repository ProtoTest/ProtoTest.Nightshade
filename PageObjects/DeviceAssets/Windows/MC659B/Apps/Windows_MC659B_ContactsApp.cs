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
        public EggplantElement EnterANameField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterANameField"));
        public EggplantElement EnterCompanyField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterCompanyField"));
        public EggplantElement EnterNameField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterNameField"));
        public EggplantElement ContactFieldDone = new EggplantElement(By.Image("MC659B/Apps/Contacts/MobilePhoneFieldDone"));
        public EggplantElement OutlookContactType = new EggplantElement(By.Image("MC659B/Apps/Contacts/OutlookContactType"));
        public EggplantElement ContactIcon = new EggplantElement(By.Image("MC659B/Apps/Contacts/ContactIcon"));
        public EggplantElement ScrollbarDownArrow = new EggplantElement(By.Image("MC659B/Apps/Contacts/ScrollbarDownArrow"));
        public EggplantElement ScrollbarUpArrow = new EggplantElement(By.Image("MC659B/Apps/Contacts/ScrollbarUpArrow"));
        public EggplantElement DeleteContactMenuOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/DeleteContactMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/DeleteMenuOption"));


        public IContactsApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Contacts app elements.");
            ContactsAppHeader.WaitForPresent();
            EnterANameField.WaitForPresent();
            return this;
        }

        public IContactsApp AddContact(string handle, string first, string last, string company, string phone1,
            string phone2, string phone3, string email1, string email2, string email3, string im1, string im2,
            string im3)
        {
        
            //MC659B Device only utilizes the FIRSTNAME, COMPANY, and PHONE1 fields

            var ContactDataFirstName = new EggplantElement(By.Text(first));
            //var ContactDataLameName = new EggplantElement(By.Text(last));
            var ContactDataCompany = new EggplantElement(By.Text(company));
            var ContactDataPhone1 = new EggplantElement(By.Text(phone1));
            //var ContactDataPhone2 = new EggplantElement(By.Text(phone2));
            //var ContactDataPhone3 = new EggplantElement(By.Text(phone3));
            //var ContactDataEmail1 = new EggplantElement(By.Text(email1));
            //var ContactDataEmail2 = new EggplantElement(By.Text(email2));
            //var ContactDataEmail3 = new EggplantElement(By.Text(email3));
            //var ContactDataIM1 = new EggplantElement(By.Text(im1));
            //var ContactDataIM2 = new EggplantElement(By.Text(im2));
            //var ContactDataIM3 = new EggplantElement(By.Text(im3));

            EggplantTestBase.Log("SETUP: Adding contact data from Setup Files - Contacts.csv.");
            EggplantTestBase.Log("Fetching contact data...");
            EggplantTestBase.Log("Contact #: (" + handle + ")");
            EggplantTestBase.Log("First name: (" + first + ")");
            EggplantTestBase.Log("Company: (" + company + ")");
            EggplantTestBase.Log("Phone1: (" + phone1 + ")");
            EggplantTestBase.Log("Email1: (" + email1 + ")");
            
            var startBar = new Windows_MC659B_StartBar();
            startBar.AddItemButton.Click();
            OutlookContactType.Click();
            AddANameOption.Click();
            EnterNameField.Type(first);
            EnterCompanyField.Type(company);
            startBar.OKButton.Click();
            ContactDataFirstName.WaitForPresent();
            ContactDataCompany.WaitForPresent();
            AddMobileNumberOption.Click();
            var driver = new EggplantDriver();
            driver.Type(phone1);
            Thread.Sleep(3000);
            ContactFieldDone.Click();
            AddEmailOption.Click();
            driver.Type(email1);
            Thread.Sleep(3000);
            ContactFieldDone.Click();
            ContactDataPhone1.WaitForPresent();
            startBar.OKButton.Click();

            return this;
        }

        public void ClickOnContact(string contactName)
        {
            var contact = new EggplantElement(By.Text(contactName));
            contact.Click();
        }

        public IContactsApp RestoreDelectedContacts(string handle, string first, string last, string company, string phone1,
            string phone2, string phone3, string email1, string email2, string email3, string im1, string im2,
            string im3)
        {
            var contactsToDelete = Enumerable.Range(int.Parse(Config.DeleteContactsStarting), int.Parse(Config.DeleteContactsTotalCount))
                .ToArray();
            var handleStrings = new List<string>();
            foreach (var handleNum in contactsToDelete)
            {
                if (handleNum < 10)
                {
                    string handleString = "0" + handleNum;
                    handleStrings.Add(handleString);
                }
                else
                {
                    handleStrings.Add(Convert.ToString(handleNum));
                }
            }

            EggplantTestBase.Log("Contacts specified for deletion were: " + string.Join(", ", handleStrings));
            if (handleStrings.Contains(handle))
            {
                EggplantTestBase.Log("Contact #" + handle + " with first name (" + first + ") has been marked for restoration.");
                AddContact(handle, first, last, company, phone1, phone2, phone3, email1, email2, email3, im1, im2, im3);
            }
            else
            {
                EggplantTestBase.Log("Contact #" + handle + " has not been specified for restoration.");
            }
            return this;
        }

        public IContactsApp DeleteContact(string handle, string first)
        {
            EggplantTestBase.Log("Deleting contact #" + handle + " with first name (" + first + ") from device.");
            var ContactDataFirstName = new EggplantElement(By.Text(first));
            var utilities = new Utilities();
            utilities.SearchForContact(ContactDataFirstName);
            ContactDataFirstName.Click();
            Thread.Sleep(2000);
            //ContactDataFirstName.WaitForPresent();
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            DeleteContactMenuOption.Click();
            var popup = new Windows_MC659B_Popups();
            popup.ClickYes();
            ContactDataFirstName.WaitForNotPresent();
            EggplantTestBase.Log("Contact deleted.");
            return this;
        }

        public IContactsApp DeleteSpecifiedContacts(string contactHandle, string contactFirst)
        {
            var contactsToDelete = Enumerable.Range(int.Parse(Config.DeleteContactsStarting), int.Parse(Config.DeleteContactsTotalCount))
                .ToArray();
            var handleStrings = new List<string>();
            foreach (var handleNum in contactsToDelete)
            {
                if (handleNum < 10)
                {
                    string handleString = "0" + handleNum;
                    handleStrings.Add(handleString);
                }
                else
                {
                    handleStrings.Add(Convert.ToString(handleNum));
                }
            }
            
            EggplantTestBase.Log("Contacts specified for deletion are: " + string.Join(", ", handleStrings));
            if (handleStrings.Contains(contactHandle))
            {
                EggplantTestBase.Log("Contact #" + contactHandle + " with first name (" + contactFirst + ") has been marked for deletion.");
                DeleteContact(contactHandle, contactFirst);
            }
            else
            {
                EggplantTestBase.Log("Contact #" + contactHandle + " has not been specified for deletion.");
            }
            return this;
        }

        public IContactsApp DeleteAllContacts()
        {
            EggplantTestBase.Log("Deleting all contacts from device.");
            while (ContactIcon.IsPresent())
            {
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                DeleteMenuOption.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
            }
            EggplantTestBase.Log("All contacts have been deleted.");
            return this;
        }

        public IContactsApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Contacts app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
