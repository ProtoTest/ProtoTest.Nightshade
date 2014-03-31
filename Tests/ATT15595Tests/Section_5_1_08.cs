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
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToPicturesAndVideoApp().VerifyElements().SetUpPicturesAndVideoApp().RecordAVideo().OpenRecordedVideo().DeleteRecordedVideo().ExitApp();
        }

        [Test]
        [Description("Camera Pictures - Tests 5.1.8.4, 5.1.8.5, and 5.1.8.6")]
        [Category("Single Device")]
        [Repeat(1)]
        public void TestCameraPictures()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToPicturesAndVideoApp().VerifyElements().TakePicture().OpenTakenPicture().DeleteTakenPicture().ExitApp();
        }

        //[Test]
        //[Description("Record Audio Message - Tests 5.1.8.7, 5.1.8.8, and 5.1.8.9")]
        //[Category("Single Device")]
        //[Repeat(1)]
        //public void TestRecordAudioMessage()
        //{

        //}

        //[Test]
        //[Description("Play Video Streaming Content With Browser and Player - Test 5.1.8.10")]
        //[Category("Single Device")]
        //[Repeat(1)]
        //public void TestVideoStreamingWithBrowserAndPlayer()
        //{
        //    ConnectToHost1();
        //    Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
        //    Command.OnHomeScreenScreen().ResetWifiRadioToDefault();

        //}

        [Test]
        [Description("Open and Close the Music Player - Test 5.1.8.11")]
        [Category("Single Device")]
        [Repeat(1)]
        public void TestOpenAndCloseTheMusicPlayer()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToMediaPlayerApp().VerifyElements().ExitApp();
        }

        [Test]
        [Description("Use the Music Player to Play a Music File - Tests 5.1.8.12 and 5.1.8.13")]
        [Category("Single Device")]
        [Repeat(1)] //Number of iterations set within "IterativelyOpenAudioFiles"
        public void TestPlayingAMusicFile()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToAudioFiles().IterativelyOpenAudioFiles(50).ExitApp(); //Number of iterations set within "IterativelyOpenAudioFiles"
        }

        [Test]
        [Description("Device Themes - Test 5.1.8.14")]
        [Category("Single Device")]
        [Repeat(1)]
        public void TestDeviceThemes()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreenScreen()
                .SetThemeToOption("01")
                .SetThemeToOption("02")
                .SetThemeToOption("03")
                .SetThemeToOption("04")
                .SetThemeToOption("05")
                .SetThemeToOption("06")
                .SetThemeToOption("07")
                .SetThemeToOption("08")
                .SetThemeToOption("09")
                .SetThemeToOption("10")
                .SetThemeToDefault();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
        }

    }
}
