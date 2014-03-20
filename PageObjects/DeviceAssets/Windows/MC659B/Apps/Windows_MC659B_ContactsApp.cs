using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_ContactsApp : IContactsApp

    {
        public EggplantElement AddANameOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/AddANameOption"));
        public EggplantElement AddMobileNumberOption = new EggplantElement(By.Image("MC659B/Apps/Contacts/AddMobileNumberOption"));
        public EggplantElement ContactsAppHeader = new EggplantElement(By.Image("MC659B/Apps/Contacts/ContactsAppHeader"));
        public EggplantElement EnterANameField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterANameField"));
        public EggplantElement EnterCompanyField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterCompanyField"));
        public EggplantElement EnterNameField = new EggplantElement(By.Image("MC659B/Apps/Contacts/EnterNameField"));
        public EggplantElement MobilePhoneFieldDone = new EggplantElement(By.Image("MC659B/Apps/Contacts/MobilePhoneFieldDone"));
        public EggplantElement OutlookContactType = new EggplantElement(By.Image("MC659B/Apps/Contacts/OutlookContactType"));
        public EggplantElement ScrollbarDownArrow = new EggplantElement(By.Image("MC659B/Apps/Contacts/ScrollbarDownArrow"));
        public EggplantElement ScrollbarUpArrow = new EggplantElement(By.Image("MC659B/Apps/Contacts/ScrollbarUpArrow"));

        public EggplantElement ContantDataFirstName = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataLameName = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataCompany = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataPhoneOne = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataPhoneTwo = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataPhoneThree = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataEmailOne = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataEmailTwo = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataEmailThree = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataIMOne = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataIMTwo = new EggplantElement(By.Text("PULL FROM CSV FILE"));
        public EggplantElement ContantDataIMThree = new EggplantElement(By.Text("PULL FROM CSV FILE"));

        public IContactsApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Contacts app elements.");
            ContactsAppHeader.WaitForPresent();
            EnterANameField.WaitForPresent();
            return this;
        }

        public IContactsApp AddAllContactsFromSetupFile()
        {
            //MC659B Device only utilizes the FIRSTNAME and PHONE1 fields

            EggplantTestBase.Log("SETUP: Adding all contacts from setup CSV file.");
            
            //loop

            var startBar = new Windows_MC659B_StartBar();
            startBar.AddItemButton.Click();
            OutlookContactType.Click();
            AddANameOption.Click();
            EnterNameField.Click();
            //TYPE FIRST AND LAST NAME INTO FIELD
            //EnterCompanyField.Click();
            //TYPE COMPANY NAME INTO FIELD
            startBar.OKButton.Click();
            ContantDataFirstName.WaitForPresent();
            //ContantDataCompany.WaitForPresent();
            AddMobileNumberOption.Click();
            //TYPE MOBILE NUMBER INTO FIELD
            MobilePhoneFieldDone.Click();
            ContantDataPhoneOne.WaitForPresent();
            startBar.OKButton.Click();
            //endloop

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
