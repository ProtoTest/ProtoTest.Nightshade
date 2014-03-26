using System;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_PicturesAndVideoApp : IPicturesAndVideoApp
    {
        public EggplantElement PicturesAndVideoHeader = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturesAndVideoHeader"));
        public EggplantElement CameraMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/CameraMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/DeleteMenuOption"));
        public EggplantElement SetAsHomeBackgroundMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/SetAsHomeBackgroundMenuOption"));
        public EggplantElement StillMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/StillMenuOption"));
        public EggplantElement VideoMenuOption = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/VideoMenuOption"));

        public EggplantElement PictureModeIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PictureModeIcon"));
        public EggplantElement VideoModeIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/VideoModeIcon"));
        public EggplantElement PictureCaptured = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PictureCaptured"));
        public EggplantElement PictureCapturedIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PictureCapturedIcon"));
        public EggplantElement VideoCapturedIcon = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/VideoCapturedIcon"));

        public EggplantElement BackgroundDefault = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background01"));

        public EggplantElement BackgroundPreview01 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background01"));
        public EggplantElement BackgroundPreview02 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background02"));
        public EggplantElement BackgroundPreview03 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background03"));
        public EggplantElement BackgroundPreview04 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background04"));
        public EggplantElement BackgroundPreview05 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background05"));
        public EggplantElement BackgroundPreview06 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background06"));
        public EggplantElement BackgroundPreview07 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background07"));
        public EggplantElement BackgroundPreview08 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background08"));
        public EggplantElement BackgroundPreview09 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background09"));
        public EggplantElement BackgroundPreview10 = new EggplantElement(By.Image("MC659B/Apps/PicturesAndVideo/PicturePreviews/Background10"));

        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_MenuNav menuNav = new Windows_MC659B_MenuNav();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();

        public void SetToPicturesMode()
        {
            EggplantTestBase.Log("Setting app to Pictures mode.");
            startBar.MenuOption.Click();
            if (VideoMenuOption.IsPresent())
            {
                EggplantTestBase.Log("App is currently in Video mode.");
                startBar.MenuOption.Click();
            }
            else
            {
                EggplantTestBase.Log("Activating Pictures mode.");
                StillMenuOption.Click();
            }
            PictureModeIcon.WaitForPresent();
            EggplantTestBase.Log("App is now in Pictures mode.");
        }

        public void SetToVideoMode()
        {
            EggplantTestBase.Log("Setting app to Video mode.");
            startBar.MenuOption.Click();
            if (StillMenuOption.IsPresent())
            {
                EggplantTestBase.Log("App is currently in Video mode.");
                startBar.MenuOption.Click();
            }
            else
            {
                EggplantTestBase.Log("Activating Video mode.");
                VideoMenuOption.Click();
            }
            VideoModeIcon.WaitForPresent();
            EggplantTestBase.Log("App is now in Video mode.");
        }

        public IPicturesAndVideoApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Pictures & Video app elements.");
            PicturesAndVideoHeader.WaitForPresent(15);
            return this;
        }

        public IPicturesAndVideoApp SetUpPicturesAndVideoApp()
        {
            EggplantTestBase.Log("Confirming Pictures and Video app is configured correctly.");
            while (VideoCapturedIcon.IsPresent())
            {
                VideoCapturedIcon.Press();
                Thread.Sleep(1000);
                DeleteMenuOption.Click();
                popup.ClickYes();
                Thread.Sleep(2000);
            }
            VideoCapturedIcon.WaitForNotPresent();
            EggplantTestBase.Log("Previous video files deleted.");
            return this;
        }

        public IPicturesAndVideoApp TakePicture()
        {
            EggplantTestBase.Log("Taking a picture using device camera.");
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
            startBar.OKButton.Click();
            return this;
        }

        public IPicturesAndVideoApp DeleteTakenPicture()
        {
            EggplantTestBase.Log("Deleting the picture taken with device camera.");
            startBar.MenuButton.Click();
            DeleteMenuOption.Click();
            popup.DeleteItem.WaitForPresent();
            popup.ClickYes();
            PictureCapturedIcon.WaitForNotPresent();
            startBar.ExitButton.Click();
            return this;
        }

        public IPicturesAndVideoApp RecordAVideo()
        {
            EggplantTestBase.Log("Recording a video with the device camera.");
            startBar.MenuOption.Click();
            CameraMenuOption.Click();
            SetToVideoMode();
            startBar.KeyboardButton.Click();
            startBar.KeyboardKeyEnter.Click();
            startBar.KeyboardButton.Click();
            startBar.StopOption.WaitForNotPresent(60);
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
            startBar.ExitButton.Click();
            return this;
        }

        public IPicturesAndVideoApp DeleteRecordedVideo()
        {
            EggplantTestBase.Log("Deleting the video recorded with the device camera.");
            startBar.MenuOption.Click();
            DeleteMenuOption.Click();
            popup.DeleteItem.WaitForPresent();
            popup.ClickYes();
            PictureCapturedIcon.WaitForNotPresent();
            return this;
        }

        public IPicturesAndVideoApp SetThemeToOption(string picNumber)
        {
            EggplantTestBase.Log("Setting device theme to option #" +picNumber+ ".");
            if (Equals(picNumber,"01"))
            {
                menuNav.GoToPicturesAndVideoApp();
            }
            else
            {
                notificationsBar.OpenRunningProgramsMenu();
                Thread.Sleep(2000);
                notificationsBar.PicturesAndVideoProgram.Click();
            }

            if (Equals(picNumber,"01"))
            {
                BackgroundPreview01.Click();
            }
            if (Equals(picNumber,"02"))
            {
                BackgroundPreview02.Click();
            }
            if (Equals(picNumber,"03"))
            {
                BackgroundPreview03.Click();
            }
            if (Equals(picNumber,"04"))
            {
                BackgroundPreview04.Click();
            }
            if (Equals(picNumber,"05"))
            {
                BackgroundPreview05.Click();
            }
            if (Equals(picNumber,"06"))
            {
                BackgroundPreview06.Click();
            }
            if (Equals(picNumber,"07"))
            {
                BackgroundPreview07.Click();
            }
            if (Equals(picNumber,"08"))
            {
                BackgroundPreview08.Click();
            }
            if (Equals(picNumber,"09"))
            {
                BackgroundPreview09.Click();
            }
            if (Equals(picNumber,"10"))
            {
                BackgroundPreview10.Click();
            }
            startBar.MenuOption.Click();
            SetAsHomeBackgroundMenuOption.Click();
            Thread.Sleep(5000);
            startBar.OKButton.Click();
            Thread.Sleep(5000);
            startBar.OKButton.Click();
            Thread.Sleep(2000);
            startBar.ExitButton.Click();
            if (notificationsBar.RunningProgramsMenuOKButton.IsPresent())
            {
                notificationsBar.ClickOnMenuOKButton();
            }
            if (Equals(picNumber,"01"))
            {
                homeDesktop.Desktop01.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"02"))
            {
                homeDesktop.Desktop02.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"03"))
            {
                homeDesktop.Desktop03.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"04"))
            {
                homeDesktop.Desktop04.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"05"))
            {
                homeDesktop.Desktop05.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"06"))
            {
                homeDesktop.Desktop06.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"07"))
            {
                homeDesktop.Desktop07.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"08"))
            {
                homeDesktop.Desktop08.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"09"))
            {
                homeDesktop.Desktop09.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"10"))
            {
                homeDesktop.Desktop10.WaitForPresent();
                EggplantTestBase.Log("Device theme set to option #" + picNumber + ".");
            }
            return this;
        }

        public IHomeScreen ResetThemeToDefault()
        {
            EggplantTestBase.Log("Setting device theme to default.");
            notificationsBar.OpenRunningProgramsMenu();
            notificationsBar.PicturesAndVideoProgram.Click();
            BackgroundDefault.Click();
            startBar.MenuOption.Click();
            SetAsHomeBackgroundMenuOption.Click();
            Thread.Sleep(5000);
            startBar.OKButton.Click();
            Thread.Sleep(5000);
            startBar.OKButton.Click();
            Thread.Sleep(2000);
            startBar.ExitButton.Click();
            if (notificationsBar.RunningProgramsMenuOKButton.IsPresent())
            {
                notificationsBar.ClickOnMenuOKButton();
            }
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return new Windows_MC659B_HomeDesktop();
        }

        public IPicturesAndVideoApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Pictures & Video app.");
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
