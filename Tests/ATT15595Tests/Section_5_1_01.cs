using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.1")]
    [Category("Telephony Stability Tests")]
    
    public class Section_5_1_01 : EggplantTestBase
    {
        //[Test]
        //[Description("2G Voice Call (Dialed) - Test 5.1.1.1 and 2G Voice Call (History) - Test 5.1.1.4")]
        //[Category("Paired Devices")]
        //[Repeat(1)]
        //public void TestTwoGVoiceCallFromContactsAndHistory()
        //{
            

        //}

        [Test]
        [Description("3G Voice Call (Contacts) - Test 5.1.1.2 and 3G Voice Call (History) - Test 5.1.1.5")]
        [Category("Paired Devices")]
        [RepeatForConfigValue("TestThreeGVoiceCallFromContactsAndHistory#")]
        public void TestThreeGVoiceCallFromContactsAndHistory()
        {
            //3G Voice Call (Contacts) - Test 5.1.1.2
            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreen().SetCellularNetworkToThreeG();
            Command.NavigateTheMenu().GoToPhoneApp().CallTestContact(1);
            ConnectToHost2();
            Command.OnHomeScreen().AnswerPhoneCall().EndPhoneCall();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            //3G Voice Call (History) - Test 5.1.1.5
            Command.NavigateTheMenu().GoToPhoneApp().CallMostRecentContactFromHistory();
            ConnectToHost2();
            Command.OnHomeScreen().AnswerPhoneCall().VerifyCallEstablished().EndPhoneCall();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
        }

        //[Test]
        //[Description("LTE Voice Call (Contacts) - Test 5.1.1.3 and LTE Voice Call (History) - Test 5.1.1.6")]
        //[Category("Paired Devices")]
        //[Repeat(1)]
        //public void TestLTEVoiceCallFromContactsAndHistory()
        //{

        //}

        [Test]
        [Description("Receive a Voice Call - Test 5.1.1.7")]
        [Category("Paired Devices")]
        [RepeatForConfigValue("TestReceiveVoiceCall#")]
        public void TestReceiveVoiceCall()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().SetCellularNetworkToThreeG();
            Command.NavigateTheMenu().GoToPhoneApp().CallMostRecentContactFromHistory();
            ConnectToHost1();
            Command.OnHomeScreen().AnswerPhoneCall().VerifyCallEstablished();
            ConnectToHost2();
            Command.OnHomeScreen().VerifyCallEstablished().ReturnToHomeScreen();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
        }

        [Test]
        [Description("Contacts - Tests 5.1.1.8 and 5.1.1.9")]
        [Category("Single Device")]
        [RepeatForConfigValue("AddAndDeleteLocalContacts#")]
        public void AddAndDeleteLocalContacts()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToContactsApp().AddContactsToDelete(20).ExitApp();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToContactsApp().DeleteAddedContacts().ExitApp();

        }

    }
}
