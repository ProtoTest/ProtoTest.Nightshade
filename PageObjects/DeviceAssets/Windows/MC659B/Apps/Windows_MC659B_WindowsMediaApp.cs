﻿using System.Drawing;
using System.Threading;
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
            EggplantTestBase.Note("Verifying Windows Media elements.");
            WindowsMediaHeader.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp SetAppState()
        {
            EggplantTestBase.Note("Setting Windows Media app state.");
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
            EggplantTestBase.Note("Verifying file is currently playing.");
            PlayingFile.WaitForPresent(20);
            PauseIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp PauseFile()
        {
            EggplantTestBase.Note("Pausing file that is currently playing.");
            PauseIcon.Click();
            PlayIcon.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp RemoveFileFromActiveStatus()
        {
            EggplantTestBase.Note("Removing file from active status.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.NowPlaying.Click();
            NowPlayingRemoveFile.Click();
            startBar.OKButton.Click();
            Thread.Sleep(2000);
            return this;
        }

        public IMediaPlayerApp ExitApp()
        {
            EggplantTestBase.Note("Exiting Windows Media app.");
            var startBar = new Windows_MC659B_StartBar();
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
