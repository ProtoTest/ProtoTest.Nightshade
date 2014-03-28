using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_PhoneApp : IPhoneApp
    {
        public EggplantElement PhoneAppHeader = new EggplantElement(By.Image("MC659B/Apps/Phone/PhoneAppHeader"));
        public EggplantElement CallKey = new EggplantElement(By.Image("MC659B/Apps/Phone/CallKey"));
        public EggplantElement EndCallKey = new EggplantElement(By.Image("MC659B/Apps/Phone/EndCallKey"));
        public EggplantElement DeleteKey = new EggplantElement(By.Image("MC659B/Apps/Phone/DeleteKey"));
        public EggplantElement Dial1 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial1"));
        public EggplantElement Dial2 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial2"));
        public EggplantElement Dial3 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial3"));
        public EggplantElement Dial4 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial4"));
        public EggplantElement Dial5 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial5"));
        public EggplantElement Dial6 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial6"));
        public EggplantElement Dial7 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial7"));
        public EggplantElement Dial8 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial8"));
        public EggplantElement Dial9 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial9"));
        public EggplantElement DialAsterisk = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/DialAsterisk"));
        public EggplantElement Dial0 = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Dial0"));
        public EggplantElement DialPound = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/DialPound"));
        public EggplantElement SpeakerphoneOption = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/SpeakerphoneOption"));
        public EggplantElement AddCaller = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/AddCaller"));
        public EggplantElement Mute = new EggplantElement(By.Image("MC659B/Apps/Phone/DialPad/Mute"));
        public EggplantElement ContactsButton = new EggplantElement(By.Image("MC659B/Apps/Phone/ContactsButton"));
        public EggplantElement CallLogButton = new EggplantElement(By.Image("MC659B/Apps/Phone/CallLogButton"));
        public EggplantElement CountryCodesButton = new EggplantElement(By.Image("MC659B/Apps/Phone/CountryCodesButton"));
        public EggplantElement PhoneMenuButton = new EggplantElement(By.Image("MC659B/Apps/Phone/PhoneMenuButton"));
        public EggplantElement CloseAppButton = new EggplantElement(By.Image("MC659B/Apps/Phone/CloseAppButton"));

        public EggplantElement CallLogHeader = new EggplantElement(By.Image("MC659B/Apps/Phone/CallLog/CallLogHeader"));
        public EggplantElement CallLogSettingsButton = new EggplantElement(By.Image("MC659B/Apps/Phone/CallLog/CallLogSettingsButton"));
        public EggplantElement CallLogPreviousCall1 = new EggplantElement(By.Image("MC659B/Apps/Phone/Calllog/CallLogPreviousCall1"));
        public EggplantElement CallLogPreviousCall1Name = new EggplantElement(By.Image("MC659B/Apps/Phone/Calllog/CallLogPreviousCall1Name"));
        public EggplantElement CallLogPreviousCall1Number = new EggplantElement(By.Image("MC659B/Apps/Phone/Calllog/CallLogPreviousCall1Number"));
        public EggplantElement CallLogPreviousCallAgain = new EggplantElement(By.Image("MC659B/Apps/Phone/Calllog/CallLogPreviousCallAgain"));
        public EggplantElement CallLogPreviousCallDetails = new EggplantElement(By.Image("MC659B/Apps/Phone/Calllog/CallLogPreviousCallDetails"));

        public EggplantElement IncomingCallAlert = new EggplantElement(By.Image("MC659B/Apps/Phone/IncomingCall/IncomingCallAlert"));
        public EggplantElement CallerName = new EggplantElement(By.Image("MC659B/Apps/Phone/IncomingCall/CallerName"));
        public EggplantElement CallerNumber = new EggplantElement(By.Image("MC659B/Apps/Phone/IncomingCall/CallerNumber"));
        public EggplantElement AnswerCallButton = new EggplantElement(By.Image("MC659B/Apps/Phone/IncomingCall/AnswerCallButton"));

        public EggplantElement OutgoingCallingAlert = new EggplantElement(By.Image("MC659B/Apps/Phone/OutgoingCall/CallingAlert"));
        

        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_MenuNav menuNav = new Windows_MC659B_MenuNav();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        public Windows_MC659B_NetworkSettings settings = new Windows_MC659B_NetworkSettings();
        public Windows_MC659B_StartMenu startMenu = new Windows_MC659B_StartMenu();
        public Enhancements.Windows.MC659B.Utilities utilities = new Enhancements.Windows.MC659B.Utilities();


        public IPhoneApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Phone app elements.");
            //
            return this;
        }

        public IPhoneApp UseDialpadToCallContactNumber(string handle)
        {
            EggplantTestBase.Log("Using dialpad to call contact #" + handle + ".");
            var contactData = utilities.ParseCsvFile(".\\Setup Files\\Contacts.csv", true);
            string[] contact = (from element in contactData
                where element[0] == handle
                select element).SingleOrDefault();
            string contactPhone1 = contact[4];
            EggplantTestBase.Log("Contact's phone number is (" + contactPhone1 + ").");
            return this;
        }

        public IPhoneApp CallMostRecentContactFromHistory()
        {
            EggplantTestBase.Log("Selecting most recent contact from call log.");
            CallLogButton.Click();
            CallLogHeader.WaitForPresent();
            CallLogPreviousCall1.Click();
            Thread.Sleep(1000);
            CallKey.Click();
            return this;
        }

        public IPhoneApp AnswerPhoneCall()
        {
            //string name = CallerName.GetText();
            //string number = CallerNumber.GetText();
            //EggplantTestBase.Log("Incoming call from: (" + name + ") at number (" + number + ").  Answering...");
            AnswerCallButton.WaitForPresent(20);
            AnswerCallButton.Click();
            return this;
        }

        public IPhoneApp VerifyCallEstablished()
        {
            EndCallKey.WaitForPresent();
            notificationsBar.CallInProgress.WaitForPresent();
            Thread.Sleep(5000);
            return this;
        }

        public IPhoneApp EndPhoneCall()
        {
            var driver = new EggplantDriver(1000);
            driver.PressKey("F4");
            return this;
        }

        public IPhoneApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Phone app.");
            CloseAppButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
