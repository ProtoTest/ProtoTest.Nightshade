using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.8")]
    [Category("Multi-Media Stability Tests")]
    public class Section_5_1_08 : EggplantTestBase
    {
        [Test]
        [Description("Camera Video - Tests 5.1.8.1, 5.1.8.2, and 5.1.8.3")]
        [Category("Single Device")]
        [Repeat(1)]
        public void TestCameraVideo()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            Command.NavigateTheMenu().GoToPicturesAndVideoApp().VerifyElements().RecordAVideo().OpenRecordedVideo().DeleteRecordedVideo().ExitApp();
        }

        [Test]
        [Description("Camera Pictures - Tests 5.1.8.4, 5.1.8.5, and 5.1.8.6")]
        [Category("Single Device")]
        [Repeat(20)]
        public void TestCameraPictures()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            Command.NavigateTheMenu().GoToPicturesAndVideoApp().VerifyElements().TakePicture().OpenTakenPicture().DeleteTakenPicture().ExitApp();
        }

        [Test]
        [Description("Record Audio Message - Tests 5.1.8.7, 5.1.8.8, and 5.1.8.9")]
        [Category("Single Device")]
        public void TestRecordAudioMessage()
        {

        }

        [Test]
        [Description("Play Video Streaming Content With Browser and Player - Test 5.1.8.10")]
        [Category("Single Device")]
        public void TestVideoStreamingWithBrowserAndPlayer()
        {

        }

        [Test]
        [Description("Open and Close the Music Player - Tests 5.1.8.11, 5.1.8.12, and 5.1.8.13")]
        [Category("Single Device")]
        public void TestOpenAndCloseTheMusicPlayer()
        {

        }

        [Test]
        [Description("Device Themes - Test 5.1.8.14")]
        [Category("Single Device")]
        public void TestDeviceThemes()
        {

        }

    }
}
