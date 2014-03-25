using System.Drawing;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_WindowsMediaApp : IMediaPlayerApp
    {
        public EggplantElement WindowsMediaHeader = new EggplantElement(By.Image("MC659B/Apps/WindowsMedia/WindowsMediaHeader"));
        public EggplantElement PlayingFile = new EggplantElement(By.Image("MC659B/Apps/WindowsMedia/PlayingFile"));
        public EggplantElement PauseIcon = new EggplantElement(By.Image("MC659B/Apps/WindowsMedia/PauseIcon"));
        public EggplantElement PlayIcon = new EggplantElement(By.Image("MC659B/Apps/WindowsMedia/PlayIcon"));

        public EggplantElement NowPlayingRemoveFile = new EggplantElement(By.Image("MC659B/Apps/WindowsMedia/NowPlayingRemoveFile"));

        public IMediaPlayerApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Windows Media elements.");
            WindowsMediaHeader.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp SetAppState()
        {
            EggplantTestBase.Log("Setting Windows Media app state.");
            var startBar = new Windows_MC659B_StartBar();
            if (startBar.OKButton.IsPresent())
            {
                startBar.OKButton.Click();
            }
            PlayIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp VerifyFilePlaying()
        {
            EggplantTestBase.Log("Verifying file is currently playing.");
            PlayingFile.WaitForPresent();
            PauseIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp PauseFile()
        {
            EggplantTestBase.Log("Pausing file that is currently playing.");
            PauseIcon.Click();
            PlayIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp RemoveFileFromActiveStatus()
        {
            EggplantTestBase.Log("Removing file from active status.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.NowPlaying.Click();
            NowPlayingRemoveFile.Click();
            startBar.OKButton.Click();
            return this;
        }

        public IMediaPlayerApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Windows Media app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
