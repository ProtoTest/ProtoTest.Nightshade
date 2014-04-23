using System.Drawing;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_WindowsMediaApp : IMediaPlayerApp
    {
        public EggplantElement WindowsMediaHeader = new EggplantElement(By.Image("MC65/Apps/WindowsMedia/WindowsMediaHeader"));
        public EggplantElement PlayingFile = new EggplantElement(By.Image("MC65/Apps/WindowsMedia/PlayingFile"));
        public EggplantElement PauseIcon = new EggplantElement(By.Image("MC65/Apps/WindowsMedia/PauseIcon"));
        public EggplantElement PlayIcon = new EggplantElement(By.Image("MC65/Apps/WindowsMedia/PlayIcon"));

        public EggplantElement NowPlayingRemoveFile = new EggplantElement(By.Image("MC65/Apps/WindowsMedia/NowPlayingRemoveFile"));

        public IMediaPlayerApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Windows Media elements.");
            WindowsMediaHeader.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp SetAppState()
        {
            EggplantTestBase.Info("Setting Windows Media app state.");
            var startBar = new Windows_MC65_StartBar();
            if (startBar.OKButton.IsPresent())
            {
                startBar.OKButton.Click();
            }
            PlayIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp VerifyFilePlaying()
        {
            EggplantTestBase.Info("Verifying file is currently playing.");
            PlayingFile.WaitForPresent(20);
            PauseIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp PauseFile()
        {
            EggplantTestBase.Info("Pausing file that is currently playing.");
            PauseIcon.Click();
            PlayIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp RemoveFileFromActiveStatus()
        {
            EggplantTestBase.Info("Removing file from active status.");
            var startBar = new Windows_MC65_StartBar();
            startBar.NowPlaying.Click();
            NowPlayingRemoveFile.Click();
            startBar.OKButton.Click();
            Thread.Sleep(2000);
            return this;
        }

        public IMediaPlayerApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Windows Media app.");
            var startBar = new Windows_MC65_StartBar();
            while (startBar.OKButton.IsPresent() || startBar.ExitButton.IsPresent())
            {
                Thread.Sleep(2000);
                if (startBar.OKButton.IsPresent())
                {
                    Thread.Sleep(1000);
                    startBar.OKButton.Click();
                }
                if (startBar.ExitButton.IsPresent())
                {
                    Thread.Sleep(1000);
                    startBar.ExitButton.Click();    
                }
            }
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
