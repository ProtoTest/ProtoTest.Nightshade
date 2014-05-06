using System.Threading;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace GolemWebScripts.PageObjects
{
    public class HotmailPage : BasePageObject
    {
        //public Image LoginPageSplash = new Image(By.XPath("//img[@id='hero']"));
        //public Image OutlookBanner = new Image(By.XPath("//img[@alt='Outlook']"));
        public Element MicrosoftLoginHeader = new Element(By.XPath("//div[@id='idTd_PWD_UsernameLbl']"));
        public Field HotmailLoginEmailField = new Field(By.XPath("//input[@id='i0116']"));
        public Field HotmailLoginPasswordField = new Field(By.XPath("//input[@id='i0118']"));
        public Button HotmailLoginSigninButton = new Button(By.XPath("//input[@id='idSIButton9']"));
        public Button HotmailAccountButton = new Button(By.XPath("//span[@id='c_meun']"));
        public Element HotmailAccountSignout = new Element(By.XPath("//a[@id='c_signout']"));
        public Element MSNLogo = new Element(By.XPath("//img[@alt='MSN Logo']"));

        public Dropdown HotmailOptionsDropdown = new Dropdown(By.XPath("//a[@id='c_clogoc']"));
        public Dropdown HotmailOptionsPeople = new Dropdown(By.XPath("//a[@id='c_h_ppl']"));

        public Checkbox PeopleAllCheckbox = new Checkbox(By.XPath("//input[@id='chk_selectAll']"));
        public Button PeopleDelete = new Button(By.XPath("//a[@id='delete']"));
        public Button PeopleDeleteConfirmation = new Button(By.XPath("//button[contains(.,'Delete')]"));
        public Element PeopleHaveNoContacts = new Element(By.XPath("//div[@class='NoContactsMsg' and contains(.,'You have no contacts.')]"));
        public Button PeopleAddNew = new Button(By.XPath("//a[@id='' and contains(.,'New')]"));
        public Field PeopleAddFirstNameField = new Field(By.XPath("//input[@id='edtInp_firstName']"));
        public Field PeopleAddCompanyField = new Field(By.XPath("//input[@id='edtInp_companyName']"));
        public Field PeopleAddEmail = new Field(By.XPath("//input[@id='edtInp_personalEmail']"));
        public Field PeopleAddPhone = new Field(By.XPath("//input[@id='edtInp_mobilePhone']"));
        public Button PeopleAddSave = new Button(By.XPath("//button[@id='btnSave']"));


        public override void WaitForElements()
        {
            
        }

        public static HotmailPage LaunchHotmail()
        {
            Common.Log("Launching Hotmail.com webpage...");
            WebDriverTestBase.driver.Navigate().GoToUrl("http://www.hotmail.com");
            Thread.Sleep(5000);
            return new HotmailPage();
        }
        
        public HotmailPage LoginToHotmail()
        {
            Common.Log("Logging into Hotmail...");
            //LoginPageSplash.WaitUntil().Present();
            //OutlookBanner.WaitUntil().Visible();
            MicrosoftLoginHeader.WaitUntil().Visible();
            HotmailLoginEmailField.Verify().Visible().Text = Config.GetConfigValue("HotmailEmail", "APPCONFIG_ERROR");
            HotmailLoginPasswordField.Verify().Visible().Text = Config.GetConfigValue("HotmailPassword", "");
            HotmailLoginSigninButton.Click();
            HotmailOptionsDropdown.WaitUntil(15).Present();
            return new HotmailPage();
        }

        public HotmailPage GoToPeopleMainPage()
        {
            Common.Log("Going to People main page...");
            HotmailOptionsDropdown.Click();
            HotmailOptionsPeople.WaitUntil().Present();
            Thread.Sleep(1000);
            HotmailOptionsPeople.Click();
            driver.SelectNewWindow();
            //driver.SwitchTo().Window("People");
            //PeopleAllCheckbox.WaitUntil(10).Present();
            return new HotmailPage();
        }

        public HotmailPage DeleteAllContacts()
        {
            Common.Log("Deleting all contacts...");
            PeopleAllCheckbox.WaitUntil(10).Present().Click();
            PeopleDelete.WaitUntil().Present().Click();
            PeopleDeleteConfirmation.WaitUntil(5).Present();
            Thread.Sleep(3000);
            PeopleDeleteConfirmation.WaitUntil().Present().Click();
            //PeopleDelete.SendKeys(Keys.Return);
            PeopleHaveNoContacts.WaitUntil(60).Present();
            return new HotmailPage();
        }

        public HotmailPage IterativelyAddContacts(int iterationsStart, int iterationsMax)
        {
            Common.Log("Iteratively adding contacts...");
            for (int i = iterationsStart; i < iterationsMax + 1; i++)
            {
                PeopleAddNew.WaitUntil(10).Present().Click();
                string first;
                //string contactNum;
                if (i < 10)
                {
                    first = Config.GetConfigValue("ContactTemplate_FirstName", "APPCONFIG_ERROR") + "0" + i;
                    //contactNum = "0" + i;
                }
                else
                {
                    first = Config.GetConfigValue("ContactTemplate_FirstName", "APPCONFIG_ERROR") + i;
                    //contactNum = i.ToString();
                }
                //string contactNumber = contactNum;
                var firstName = first;
                string company = Config.GetConfigValue("ContactTemplate_Company", "APPCONFIG_ERROR");
                string email = Config.GetConfigValue("ContactMasterEmail", "APPCONFIG_ERROR");
                string phone = Config.GetConfigValue("ContactMasterPhone", "APPCONFIG_ERROR");

                Common.Log("LOADING CONTACT INFO...");
                Common.Log("Contact First Name: (" + firstName + ").");
                Common.Log("Contact Company: (" + company + ").");
                Common.Log("Contact Email: (" + email + ").");
                Common.Log("Contact Phone: (" + phone + ").");

                PeopleAddFirstNameField.Text = firstName;
                Thread.Sleep(1000);
                PeopleAddCompanyField.Text = company;
                Thread.Sleep(1000);
                PeopleAddEmail.Text = email;
                Thread.Sleep(1000);
                PeopleAddPhone.Text = phone;

                Thread.Sleep(5000);
                PeopleAddSave.Click();

                var ContactOnScreen = new Button(By.XPath("//div[@class='CL_Display_Name' and contains(.,'" + firstName + "')]"));
                ContactOnScreen.WaitUntil(5).Present();
            }
            return this;
        }

        public HotmailPage LogOut()
        {
            Common.Log("Logging out...");
            HotmailAccountButton.WaitUntil(5).Present().Click();
            Thread.Sleep(2000);
            HotmailAccountSignout.WaitUntil(5).Present().Click();
            Thread.Sleep(2000);
            MSNLogo.WaitUntil(20).Present();
            return new HotmailPage();
        }
    }
}
