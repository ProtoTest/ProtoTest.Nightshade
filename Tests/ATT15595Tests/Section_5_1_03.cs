using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.3")]
    [Category("Email Stability Tests")]

    public class Section_5_1_03 : EggplantTestBase
    {
        //[Test]
        //[Description("Send 2G Email with No Attachment - Test 5.1.3.1A")]
        //[Category("Paired Device")]
        //[Repeat(1)]
        //public void TestSendTwoGEmailNoAttachment()
        //{

        //}

        [Test]
        [Description("Send 3G Email with No Attachment - Test 5.1.3.1B")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestSendThreeGEmailNoAttachment#")]
        public void TestSendThreeGEmailNoAttachment()
        {
            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToEmailApp().ResetEmailAppToDefault();

            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreen().SetCellularNetworkToThreeG();
            Command.NavigateTheMenu()
                .GoToEmailApp()
                .ResetEmailAppToDefault()
                .SendEmailWithNoAttachment("TEST01")
                .ResetEmailAppToDefault()
                .ExitApp();

            ConnectToHost2();
            Command.OnHomeScreen().VerifyEmailArrived();
            Command.NavigateTheMenu().GoToEmailApp().ResetEmailAppToDefault().ExitApp();
        }

        //[Test]
        //[Description("Send 2G Email with Attachment - Test 5.1.3.2A")]
        //[Category("Paired Device")]
        //[Repeat(1)]
        //public void TestSendTwoGEmailWithAttachment()
        //{

        //}

        [Test]
        [Description("Send 3G Email with Attachment - Test 5.1.3.2B")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestSendThreeGEmailWithAttachment#")]
        public void TestSendThreeGEmailWithAttachment()
        {
            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToEmailApp().ResetEmailAppToDefault();

            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreen().SetCellularNetworkToThreeG();
            Command.NavigateTheMenu()
                .GoToEmailApp()
                .ResetEmailAppToDefault()
                .SendEmailWithAnAttachment("TEST01")
                .ResetEmailAppToDefault()
                .ExitApp();

            ConnectToHost2();
            Command.OnHomeScreen().VerifyEmailArrived();
            Command.NavigateTheMenu().GoToEmailApp().ResetEmailAppToDefault().ExitApp();
        }

        [Test]
        [Description("Open an Email - Test 5.1.3.3")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestOpenAnEmail#")]
        public void TestOpenAnEmail()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();

            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.NavigateTheMenu()
                .GoToEmailApp()
                .ResetEmailAppToDefault()
                .SendEmailWithNoAttachment("TEST01")
                .ResetEmailAppToDefault()
                .ExitApp();

            ConnectToHost1();
            Command.OnHomeScreen().VerifyEmailArrived();
            Command.NavigateTheMenu().GoToEmailApp().OpenReceivedEmail().ResetEmailAppToDefault();
        }

    }
}
