using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.1")]
    [Category("Telephony Stability Tests")]
    
    public class Section_5_1_01 : EggplantTestBase
    {
        [Test]
        [Description("2G Voice Call (Dialed) - Test 5.1.1.1")]
        [Category("Paired Devices")]
        public void TestTwoGVoiceCallDialed()
        {

        }

        [Test]
        [Description("3G Voice Call (Dialed) - Test 5.1.1.2")]
        [Category("Paired Devices")]
        public void TestThreeGVoiceCallDialed()
        {

        }

        //[Test]
        //[Description("LTE Voice Call (Dialed) - Test 5.1.1.3")]
        //[Category("Paired Devices")]
        //public void TestLTEVoiceCallDialed()
        //{

        //}

        [Test]
        [Description("2G Voice Call (History) - Test 5.1.1.4")]
        [Category("Paired Devices")]
        public void TestTwoGVoiceCallHistory()
        {

        }

        [Test]
        [Description("3G Voice Call (History) - Test 5.1.1.5")]
        [Category("Paired Devices")]
        public void TestThreeGVoiceCallHistory()
        {

        }

        //[Test]
        //[Description("LTE Voice Call (History) - Test 5.1.1.6")]
        //[Category("Paired Devices")]
        //public void TestLTEVoiceCallHistory()
        //{

        //}

        [Test]
        [Description("Receive a Voice Call - Test 5.1.1.7")]
        [Category("Paired Devices")]
        public void TestReceiveVoiceCall()
        {

        }

        [CsvData(FilePath = ".\\Setup Files\\Contacts.csv", HasHeader = true)]
        [Test]
        [Description("Contacts - Tests 5.1.1.8 and 5.1.1.9")]
        [Category("Single Device")]
        public void DeleteAndRestoreContacts(string handle, string first, string last, string company, string phone1, 
            string phone2, string phone3, string email1, string email2, string email3, string im1, string im2, string im3)
        {
            ConnectToHost1();
            Command.NavigateTheMenu().GoToContactsApp().DeleteSpecifiedContacts(handle, first).ExitApp();
            Command.NavigateTheMenu()
                .GoToContactsApp()
                .RestoreDelectedContacts(handle, first, last, company, phone1, phone2, phone3, email1, email2, email3,
                    im1, im2, im3)
                .ExitApp();
        }

    }
}
