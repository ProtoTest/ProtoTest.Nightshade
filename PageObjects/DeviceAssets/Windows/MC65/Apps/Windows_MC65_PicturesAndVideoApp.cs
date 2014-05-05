using System;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_PicturesAndVideoApp : IPicturesAndVideoApp
    {
        public EggplantElement PicturesAndVideoHeader = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturesAndVideoHeader"));
        public EggplantElement CameraMenuOption = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/CameraMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/DeleteMenuOption"));
        public EggplantElement SetAsHomeBackgroundMenuOption = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/SetAsHomeBackgroundMenuOption"));
        public EggplantElement StillMenuOption = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/StillMenuOption"));
        public EggplantElement VideoMenuOption = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/VideoMenuOption"));

        public EggplantElement CameraIcon = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/CameraIcon"));
        public EggplantElement PictureModeIcon = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturesModeIcon"));
        public EggplantElement VideoModeIcon = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/VideoModeIcon"));
        public EggplantElement PictureCaptured = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PictureCaptured"));
        public EggplantElement PictureCapturedIcon = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PictureCapturedIcon"));
        public EggplantElement VideoCapturedIcon = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/VideoCapturedIcon"));
        public EggplantElement PicturePlaceholder = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePlaceholder"));

        public EggplantElement BackgroundDefault = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background01"));
        public EggplantElement MyPicturesDefaultState = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/MyPicturesDefaultState"));
        public EggplantElement DefaultPicturesState = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/DefaultPicturesState"));
        
        public EggplantElement BackgroundPreview01 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background01"));
        public EggplantElement BackgroundPreview02 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background02"));
        public EggplantElement BackgroundPreview03 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background03"));
        public EggplantElement BackgroundPreview04 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background04"));
        public EggplantElement BackgroundPreview05 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background05"));
        public EggplantElement BackgroundPreview06 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background06"));
        public EggplantElement BackgroundPreview07 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background07"));
        public EggplantElement BackgroundPreview08 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background08"));
        public EggplantElement BackgroundPreview09 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background09"));
        public EggplantElement BackgroundPreview10 = new EggplantElement(By.Image("MC65/Apps/PicturesAndVideo/PicturePreviews/Background10"));

        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_MenuNav menuNav = new Windows_MC65_MenuNav();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();

        public void SetToPicturesMode()
        {
            EggplantTestBase.Info("Setting app to Pictures mode.");
            startBar.MenuOption.Click();
            Thread.Sleep(1000);
            if (VideoMenuOption.IsPresent())
            {
                startBar.MenuOption.Click();
            }
            else
            {
                EggplantTestBase.Info("App is currently in Video mode.  Changing to pictures mode...");
                StillMenuOption.Click();
            }
            Thread.Sleep(1000);
            PictureModeIcon.WaitForPresent();
            EggplantTestBase.Info("App is now in Pictures mode.");
        }

        public void SetToVideoMode()
        {
            EggplantTestBase.Info("Setting app to Video mode.");
            startBar.MenuOption.Click();
            Thread.Sleep(1000);
            if (StillMenuOption.IsPresent())
            {
                startBar.MenuOption.Click();
            }
            else
            {
                EggplantTestBase.Info("App is currently in Pictures mode.  Changing to video mode...");
                VideoMenuOption.Click();
            }
            Thread.Sleep(1000);
            VideoModeIcon.WaitForPresent();
            EggplantTestBase.Info("App is now in Video mode.");
        }

        public IPicturesAndVideoApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Pictures & Video app elements.");
            PicturesAndVideoHeader.WaitForPresent(15);
            Thread.Sleep(5000);
            return this;
        }

        public IPicturesAndVideoApp SetUpPicturesAndVideoApp()
        {
            EggplantTestBase.Info("Confirming Pictures and Video app is configured correctly.");
            Thread.Sleep(1000);
            while (!MyPicturesDefaultState.IsPresent())
            {
                if (DefaultPicturesState.IsPresent())
                {
                    EggplantTestBase.Info("System default pictures detected - cannot delete any further.");
                    break;
                }
                EggplantTestBase.Info("Previous picture file detected.  Deleting...");
                PictureCapturedIcon.Press();
                Thread.Sleep(3000);
                var driver = new EggplantDriver();
                driver.Type("d");
                Thread.Sleep(1000);
                driver.PressKey("RightArrow");
                Thread.Sleep(1000);
                driver.PressKey("Return");
                Thread.Sleep(5000);
            }
            MyPicturesDefaultState.WaitForPresent();
            while (VideoCapturedIcon.IsPresent())
            {
                if (DefaultPicturesState.IsPresent())
                {
                    EggplantTestBase.Info("System default pictures detected - cannot delete any further.");
                    break;
                }
                EggplantTestBase.Info("Previous video file detected.  Deleting...");
                VideoCapturedIcon.Press();
                Thread.Sleep(5000);
                var driver = new EggplantDriver();
                driver.Type("d");
                Thread.Sleep(1000);
                driver.PressKey("RightArrow");
                Thread.Sleep(1000);
                driver.PressKey("Return");
                Thread.Sleep(5000);
            }
            VideoCapturedIcon.WaitForNotPresent();
            EggplantTestBase.Info("Previous video files deleted.");
            //while (PictureCapturedIcon.IsPresent())
            //{
            //    EggplantTestBase.Info("Previous picture file detected.  Deleting...");
            //    PictureCapturedIcon.Press();
            //    Thread.Sleep(3000);
            //    var driver = new EggplantDriver();
            //    driver.Type("d");
            //    Thread.Sleep(1000);
            //    driver.PressKey("RightArrow");
            //    Thread.Sleep(1000);
            //    driver.PressKey("Return");
            //    Thread.Sleep(5000);
            //}
            //PictureCapturedIcon.WaitForNotPresent();
            BackgroundPreview10.WaitForPresent();
            EggplantTestBase.Info("Previous picture files deleted.");
            return this;
        }

        public IPicturesAndVideoApp TakePicture()
        {
            var driver = new EggplantDriver();
            
            EggplantTestBase.Info("Taking a picture using device camera.");
            //startBar.MenuOption.Click();
            //CameraMenuOption.Click();
            CameraIcon.DoubleClick();
            SetToPicturesMode();
            //startBar.KeyboardButton.Click();
            //startBar.KeyboardKeyEnter.Click();
            driver.PressKey("Return");
            PictureCaptured.WaitForPresent();
            Thread.Sleep(1000);
            driver.LogScreenshot();
            startBar.OKButton.Click();
            startBar.ThumbnailsButton.Click();
            ExitApp();
            return this;
        }

        public IPicturesAndVideoApp OpenTakenPicture()
        {
            var driver = new EggplantDriver();

            EggplantTestBase.Info("Opening the picture taken with device camera.");
            notificationsBar.OpenNotificationsBarMenu();
            notificationsBar.ClickOnMenuCloseAllButton();
            notificationsBar.ClickOnMenuOKButton();
            Thread.Sleep(1000);
            menuNav.GoToPicturesAndVideoApp();
            PictureCapturedIcon.Click();
            PictureCaptured.WaitForPresent();
            driver.LogScreenshot();
            startBar.OKButton.Click();
            Thread.Sleep(5000);
            return this;
        }

        public IPicturesAndVideoApp DeleteTakenPicture()
        {
            EggplantTestBase.Info("Deleting the picture taken with device camera.");
            PictureCapturedIcon.Press();
            var driver = new EggplantDriver();
            driver.Type("d");
            popup.DeleteItem.WaitForPresent();
            Thread.Sleep(1000);
            driver.PressKey("RightArrow");
            Thread.Sleep(1000);
            driver.PressKey("Return");
            //PictureCapturedIcon.WaitForNotPresent();
            MyPicturesDefaultState.WaitForPresent();
            return this;
        }

        public IPicturesAndVideoApp RecordAVideo()
        {
            var driver = new EggplantDriver();

            EggplantTestBase.Info("Recording a video with the device camera.");
            CameraIcon.DoubleClick();
            //startBar.MenuOption.Click();
            //CameraMenuOption.Click();
            SetToVideoMode();
            //startBar.KeyboardButton.Click();
            //startBar.KeyboardKeyEnter.Click();
            //startBar.KeyboardButton.Click();
            driver.PressKey("Return");
            startBar.StopOption.WaitForNotPresent(120);
            startBar.ThumbnailsButton.Click();
            Thread.Sleep(5000);
            return this;
        }

        public IPicturesAndVideoApp OpenRecordedVideo()
        {
            EggplantTestBase.Info("Opening the video recorded with the device camera.");
            VideoCapturedIcon.Click();
            var mediaPlayer = new Windows_MC65_WindowsMediaApp();
            mediaPlayer.VerifyElements();
            mediaPlayer.VerifyFilePlaying();
            mediaPlayer.PauseFile();
            mediaPlayer.RemoveFileFromActiveStatus();
            startBar.ExitButton.Click();
            Thread.Sleep(5000);
            return this;
        }

        public IPicturesAndVideoApp DeleteRecordedVideo()
        {
            EggplantTestBase.Info("Deleting the video recorded with the device camera.");
            VideoCapturedIcon.Press();
            Thread.Sleep(1000);
            var driver = new EggplantDriver();
            driver.Type("d");
            popup.DeleteItem.WaitForPresent();
            Thread.Sleep(1000);
            driver.PressKey("RightArrow");
            Thread.Sleep(1000);
            driver.PressKey("Return");
            VideoCapturedIcon.WaitForNotPresent();
            return this;
        }

        public IPicturesAndVideoApp SetThemeToOption(string picNumber)
        {
            EggplantTestBase.Info("Setting device theme to option #" +picNumber+ ".");
            if (Equals(picNumber,"01"))
            {
                menuNav.GoToPicturesAndVideoApp();
            }
            else
            {
                notificationsBar.OpenNotificationsBarMenu();
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
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"02"))
            {
                homeDesktop.Desktop02.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"03"))
            {
                homeDesktop.Desktop03.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"04"))
            {
                homeDesktop.Desktop04.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"05"))
            {
                homeDesktop.Desktop05.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"06"))
            {
                homeDesktop.Desktop06.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"07"))
            {
                homeDesktop.Desktop07.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"08"))
            {
                homeDesktop.Desktop08.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"09"))
            {
                homeDesktop.Desktop09.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            if (Equals(picNumber,"10"))
            {
                homeDesktop.Desktop10.WaitForPresent();
                EggplantTestBase.Info("Device theme set to option #" + picNumber + ".");
            }
            return this;
        }

        public IHomeScreen ResetThemeToDefault()
        {
            EggplantTestBase.Info("Setting device theme to default.");
            notificationsBar.OpenNotificationsBarMenu();
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
            Command.OnHomeScreen().ConfirmHomeScreen();
            return new Windows_MC65_HomeDesktop();
        }

        public IPicturesAndVideoApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Pictures & Video app.");
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
