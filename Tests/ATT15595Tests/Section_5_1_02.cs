using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.2")]
    [Category("Messaging Stability Tests")]

    public class Section_5_1_02 : EggplantTestBase
    {
        //[Test]
        //[Description("Send 2G SMS with Max Characters - Test 5.1.2.1A")]
        //[Category("Paired Device")]
        //[Repeat(1)]
        //public void TestSendTwoGMessageMaxCharacters()
        //{

        //}

        [Test]
        [Description("Send 3G SMS with Max Characters - Test 5.1.2.1B")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestSendThreeGMessageMaxCharacters#")]
        public void TestSendThreeGMessageMaxCharacters()
        {
            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToTextMessagesApp().ResetTextMessagesAppToDefault().ExitApp();

            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.NavigateTheMenu()
                .GoToTextMessagesApp()
                .ResetTextMessagesAppToDefault()
                .SendSMSWithMaxCharacters("TEST02")
                .ResetTextMessagesAppToDefault()
                .ExitApp();

            ConnectToHost2();
            Command.OnHomeScreen().VerifyTextMessageArrived();
            Command.NavigateTheMenu().GoToTextMessagesApp().ResetTextMessagesAppToDefault().ExitApp();
        }

        //[Test]
        //[Description("Send 2G MMS with Audio Attachment - Test 5.1.2.2A")]
        //[Category("Paired Device")]
        //[Repeat(1)]
        //public void TestSendTwoGMessageAudioAttachment()
        //{

        //}

        [Test]
        [Description("Send 3G MMS with Audio Attachment - Test 5.1.2.2B")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestSendThreeGMessageAudioAttachment#")]
        public void TestSendThreeGMessageAudioAttachment()
        {

        }

        //[Test]
        //[Description("Send 2G MMS with Video Attachment - Test 5.1.2.3A")]
        //[Category("Paired Device")]
        //[Repeat(1)]
        //public void TestSendTwoGMessageVideoAttachment()
        //{

        //}

        [Test]
        [Description("Send 3G MMS with Video Attachment - Test 5.1.2.3B")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestSendThreeGMessageVideoAttachment#")]
        public void TestSendThreeGMessageVideoAttachment()
        {

        }

        //[Test]
        //[Description("Send 2G MMS with Image Attachment - Test 5.1.2.4A")]
        //[Category("Paired Device")]
        //[Repeat(1)]
        //public void TestSendTwoGMessageImageAttachment()
        //{

        //}

        [Test]
        [Description("Send 3G MMS with Image Attachment - Test 5.1.2.4B")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestSendThreeGMessageImageAttachment#")]
        public void TestSendThreeGMessageImageAttachment()
        {

        }

        [Test]
        [Description("Open MMS with Audio Attachment - Test 5.1.2.5")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestOpenMessageAudioAttachment#")]
        public void TestOpenMessageAudioAttachment()
        {

        }

        [Test]
        [Description("Open MMS with Video Attachment - Test 5.1.2.6")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestOpenMessageVideoAttachment#")]
        public void TestOpenMessageVideoAttachment()
        {

        }

        [Test]
        [Description("Open MMS with Image Attachment - Test 5.1.2.7")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestOpenMessageImageAttachment#")]
        public void TestOpenMessageImageAttachment()
        {

        }

        [Test]
        [Description("Open SMS with Max Characters - Test 5.1.2.8")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestOpenMessageMaxCharacters#")]
        public void TestOpenMessageMaxCharacters()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();

            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.NavigateTheMenu()
                .GoToTextMessagesApp()
                .ResetTextMessagesAppToDefault()
                .SendSMSWithMaxCharacters("TEST01")
                .ResetTextMessagesAppToDefault()
                .ExitApp();

            ConnectToHost1();
            Command.OnHomeScreen().VerifyTextMessageArrived();
            Command.NavigateTheMenu().GoToTextMessagesApp().ResetTextMessagesAppToDefault();
        }

    }
}
