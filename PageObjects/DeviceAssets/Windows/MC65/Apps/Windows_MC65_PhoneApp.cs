using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_PhoneApp : IPhoneApp
    {
        public EggplantElement PhoneAppHeader = new EggplantElement(By.Image("MC65/Apps/Phone/PhoneAppHeader"));
        public EggplantElement CallKey = new EggplantElement(By.Image("MC65/Apps/Phone/CallKey"));
        public EggplantElement EndCallKey = new EggplantElement(By.Image("MC65/Apps/Phone/EndCallKey"));
        public EggplantElement DeleteKey = new EggplantElement(By.Image("MC65/Apps/Phone/DeleteKey"));
        public EggplantElement Dial1 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial1"));
        public EggplantElement Dial2 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial2"));
        public EggplantElement Dial3 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial3"));
        public EggplantElement Dial4 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial4"));
        public EggplantElement Dial5 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial5"));
        public EggplantElement Dial6 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial6"));
        public EggplantElement Dial7 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial7"));
        public EggplantElement Dial8 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial8"));
        public EggplantElement Dial9 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial9"));
        public EggplantElement DialAsterisk = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/DialAsterisk"));
        public EggplantElement Dial0 = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Dial0"));
        public EggplantElement DialPound = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/DialPound"));
        public EggplantElement SpeakerphoneOption = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/SpeakerphoneOption"));
        public EggplantElement AddCaller = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/AddCaller"));
        public EggplantElement Mute = new EggplantElement(By.Image("MC65/Apps/Phone/DialPad/Mute"));
        public EggplantElement ContactsButton = new EggplantElement(By.Image("MC65/Apps/Phone/ContactsButton"));
        public EggplantElement CallLogButton = new EggplantElement(By.Image("MC65/Apps/Phone/CallLogButton"));
        public EggplantElement CountryCodesButton = new EggplantElement(By.Image("MC65/Apps/Phone/CountryCodesButton"));
        public EggplantElement PhoneMenuButton = new EggplantElement(By.Image("MC65/Apps/Phone/PhoneMenuButton"));
        public EggplantElement CloseAppButton = new EggplantElement(By.Image("MC65/Apps/Phone/CloseAppButton"));

        public EggplantElement CallLogHeader = new EggplantElement(By.Image("MC65/Apps/Phone/CallLog/CallLogHeader"));
        public EggplantElement CallLogSettingsButton = new EggplantElement(By.Image("MC65/Apps/Phone/CallLog/CallLogSettingsButton"));
        public EggplantElement CallLogPreviousCall1 = new EggplantElement(By.Image("MC65/Apps/Phone/Calllog/CallLogPreviousCall1"));
        public EggplantElement CallLogPreviousCall1Name = new EggplantElement(By.Image("MC65/Apps/Phone/Calllog/CallLogPreviousCall1Name"));
        public EggplantElement CallLogPreviousCall1Number = new EggplantElement(By.Image("MC65/Apps/Phone/Calllog/CallLogPreviousCall1Number"));
        public EggplantElement CallLogPreviousCallAgain = new EggplantElement(By.Image("MC65/Apps/Phone/Calllog/CallLogPreviousCallAgain"));
        public EggplantElement CallLogPreviousCallDetails = new EggplantElement(By.Image("MC65/Apps/Phone/Calllog/CallLogPreviousCallDetails"));

        public EggplantElement IncomingCallAlert = new EggplantElement(By.Image("MC65/Apps/Phone/IncomingCall/IncomingCallAlert"));
        public EggplantElement CallerName = new EggplantElement(By.Image("MC65/Apps/Phone/IncomingCall/CallerName"));
        public EggplantElement CallerNumber = new EggplantElement(By.Image("MC65/Apps/Phone/IncomingCall/CallerNumber"));
        public EggplantElement AnswerCallButton = new EggplantElement(By.Image("MC65/Apps/Phone/IncomingCall/AnswerCallButton"));

        public EggplantElement OutgoingCallingAlert = new EggplantElement(By.Image("MC65/Apps/Phone/OutgoingCall/CallingAlert"));
        

        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_MenuNav menuNav = new Windows_MC65_MenuNav();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        public Windows_MC65_NetworkSettings settings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_StartMenu startMenu = new Windows_MC65_StartMenu();
        public Enhancements.Windows.MC65.Utilities utilities = new Enhancements.Windows.MC65.Utilities();


        public IPhoneApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Phone app elements.");
            //
            return this;
        }

        public IPhoneApp UseDialpadToCallContactNumber(string handle)
        {
            EggplantTestBase.Info("Using dialpad to call contact #" + handle + ".");
            var contactData = utilities.ParseCsvFile(".\\Setup Files\\Contacts.csv", true);
            string[] contact = (from element in contactData
                where element[0] == handle
                select element).SingleOrDefault();
            string contactPhone1 = contact[4];
            EggplantTestBase.Info("Contact's phone number is (" + contactPhone1 + ").");
            return this;
        }

        public IPhoneApp CallTestContact(int contactNum)
        {
            EggplantTestBase.Info("Calling all contacts iteratively until contact #" + contactNum + " is reached.");
            for (int i = 1; i < contactNum + 1; i++)
            {
                ContactsButton.Click();
                string handleNum;
                if (contactNum < 10)
                {
                    string num = i.ToString();
                    handleNum = "0" + num;
                }
                else
                {
                    string num = i.ToString();
                    handleNum = num;
                }
                string contactName = "TEST" + handleNum;
                var contactFirstName = new EggplantElement(By.Text(contactName).InRectangle(SearchRectangle.TopHalf));
                utilities.SearchForContact(contactFirstName);
                contactFirstName.Click();
                var contactsApp = new Windows_MC65_ContactsApp();
                EggplantTestBase.Info("Calling contact.");
                contactsApp.CallMobileButton.Click();
                Thread.Sleep(1000);
            }
            return this;
        }

        public IPhoneApp CallMostRecentContactFromHistory()
        {
            EggplantTestBase.Info("Selecting most recent contact from call log.");
            CallLogButton.Click();
            CallLogHeader.WaitForPresent();
            CallLogPreviousCall1.Click();
            Thread.Sleep(1000);
            EggplantTestBase.Info("Calling contact.");
            CallKey.Click();
            return this;
        }

        public IPhoneApp AnswerPhoneCall()
        {
            //string name = CallerName.GetText();
            //string number = CallerNumber.GetText();
            //EggplantTestBase.Info("Incoming call from: (" + name + ") at number (" + number + ").  Answering...");
            AnswerCallButton.WaitForPresent(20);
            EggplantTestBase.Info("Answering call...");
            AnswerCallButton.Click();
            return this;
        }

        public IPhoneApp VerifyCallEstablished()
        {
            EndCallKey.WaitForPresent();
            notificationsBar.CallInProgress.WaitForPresent();
            EggplantTestBase.Info("Call established.");
            Thread.Sleep(5000);
            return this;
        }

        public IPhoneApp EndPhoneCall()
        {
            EggplantTestBase.Info("Ending call...");
            var driver = new EggplantDriver();
            driver.PressKey("F4");
            return this;
        }

        public IPhoneApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Phone app.");
            CloseAppButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
