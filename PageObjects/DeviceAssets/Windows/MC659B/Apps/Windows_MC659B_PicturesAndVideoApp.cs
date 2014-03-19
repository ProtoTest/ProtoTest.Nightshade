using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_PicturesAndVideoApp : IPicturesAndVideoApp
    {
        public EggplantElement PicturesAndVideoHeader = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturesAndVideoHeader"));
        public EggplantElement CameraMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/CameraMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/DeleteMenuOption"));
        public EggplantElement StillMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/StillMenuOption"));
        public EggplantElement VideoMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/VideoMenuOption"));

        public EggplantElement PictureModeIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PictureModeIcon"));
        public EggplantElement VideoModeIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/VideoModeIcon"));
        public EggplantElement PictureCaptured = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PictureCaptured"));
        public EggplantElement PictureCapturedIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PictureCapturedIcon"));
        public EggplantElement VideoCapturedIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/VideoCapturedIcon"));

        public void SetToPicturesMode()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            if (StillMenuOption.IsPresent())
            {
                StillMenuOption.Click();
            }
            PictureModeIcon.WaitForPresent();
        }

        public void SetToVideoMode()
        {
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            if (VideoMenuOption.IsPresent())
            {
                VideoMenuOption.Click();
            }
            VideoModeIcon.WaitForPresent();
        }

        public IPicturesAndVideoApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Pictures & Video app elements.");
            PicturesAndVideoHeader.WaitForPresent();
            return this;
        }

        public IPicturesAndVideoApp TakePicture()
        {
            EggplantTestBase.Log("Taking a picture using device camera.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            CameraMenuOption.Click();
            SetToPicturesMode();
            startBar.KeyboardButton.Click();
            startBar.KeyboardKeyEnter.Click();
            PictureCaptured.WaitForPresent();
            startBar.OKButton.Click();
            startBar.ThumbnailsButton.Click();
            PictureCapturedIcon.WaitForPresent();
            return this;
        }

        public IPicturesAndVideoApp OpenTakenPicture()
        {
            EggplantTestBase.Log("Opening the picture taken with device camera.");
            PictureCapturedIcon.Click();
            PictureCaptured.WaitForPresent();
            var startBar = new Windows_MC659B_StartBar();
            startBar.OKButton.Click();
            return this;
        }

        public IPicturesAndVideoApp DeleteTakenPicture()
        {
            EggplantTestBase.Log("Deleting the picture taken with device camera.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            DeleteMenuOption.Click();
            var popUp = new Windows_MC659B_Popups();
            popUp.DeleteItem.WaitForPresent();
            popUp.ClickYes();
            PictureCapturedIcon.WaitForNotPresent();
            startBar.ExitButton.Click();
            return this;
        }

        public IPicturesAndVideoApp RecordAVideo()
        {
            EggplantTestBase.Log("Recording a video with the device camera.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            CameraMenuOption.Click();
            SetToVideoMode();
            startBar.KeyboardButton.Click();
            startBar.KeyboardKeyEnter.Click();
            startBar.KeyboardButton.Click();
            startBar.StopButton.WaitForNotPresent(60);
            startBar.ThumbnailsButton.Click();
            return this;
        }

        public IPicturesAndVideoApp OpenRecordedVideo()
        {
            EggplantTestBase.Log("Opening the video recorded with the device camera.");
            VideoCapturedIcon.Click();
            var mediaPlayer = new Windows_MC659B_WindowsMediaApp();
            mediaPlayer.VerifyElements();
            mediaPlayer.VerifyFilePlaying();
            mediaPlayer.PauseFile();
            mediaPlayer.RemoveFileFromActiveStatus();
            mediaPlayer.ExitApp();
            return this;
        }

        public IPicturesAndVideoApp DeleteRecordedVideo()
        {
            EggplantTestBase.Log("Deleting the video recorded with the device camera.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            DeleteMenuOption.Click();
            var popUp = new Windows_MC659B_Popups();
            popUp.DeleteItem.WaitForPresent();
            popUp.ClickYes();
            PictureCapturedIcon.WaitForNotPresent();
            startBar.ExitButton.Click();
            return this;
        }

        public IPicturesAndVideoApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Pictures & Video app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
