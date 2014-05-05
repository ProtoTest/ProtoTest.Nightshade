using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_BrowserApp : IBrowserApp
    {
        public EggplantElement AddressBar = new EggplantElement(By.Image("MC65/Apps/BrowserIE/AddressBar"));
        public EggplantElement BackButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/BackButton"));
        public EggplantElement BookmarksButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/BookmarksButton"));
        public EggplantElement BrowsingHistoryMenuOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/BrowsingHistoryMenuOption"));
        public EggplantElement OverlayExitButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/ExitButton"));
        public EggplantElement GoButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/GoButton"));
        public EggplantElement HistoryMenuOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/HistoryMenuOption"));
        public EggplantElement HomePageMenuOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/HomePageMenuOption"));
        public EggplantElement KeyboardButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/KeyboardButton"));
        public EggplantElement OverlayMenuButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/MenuButton"));
        public EggplantElement OptionsMenuOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/OptionsMenuOption"));
        public EggplantElement PopupWantToContinue = new EggplantElement(By.Image("MC65/Apps/BrowserIE/PopupWantToContinue"));
        public EggplantElement ShowOverlayButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/ShowOverlayButton"));
        public EggplantElement StartButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/StartButton"));
        public EggplantElement StopButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/StopButton"));
        public EggplantElement ToolsMenuOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/ToolsMenuOption"));

        public EggplantElement BookmarkGoogleIcon = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Bookmarks/BookmarkGoogleIcon"));
        public EggplantElement BookmarksHeader = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Bookmarks/BookmarksHeader"));

        public EggplantElement CookiesOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/BrowserHistoryMenu/CookiesOption"));
        public EggplantElement HistoryOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/BrowserHistoryMenu/HistoryOption"));
        public EggplantElement TemporaryFilesOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/BrowserHistoryMenu/TemporaryFilesOption"));

        public EggplantElement DownloadFileButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Downloads/DownloadFileButton"));
        public EggplantElement DownloadTheFilePrompt = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Downloads/DownloadTheFilePrompt"));
        public EggplantElement PowerDictaphonelnstallHeader = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Downloads/PowerDictaphonelnstallHeader"));
        public EggplantElement PowerDictaphonelnstallPrompt = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Downloads/PowerDictaphonelnstallPrompt"));

        public EggplantElement ATTCopyright = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/ATTCopyright"));
        public EggplantElement FacebookCreateAccount = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/FacebookCreateAccount"));
        public EggplantElement FacebookLoginButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/FacebookLoginButton"));
        public EggplantElement FacebookLogo = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/FacebookLogo"));
        public EggplantElement GoogleSearchButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/GoogleSearchButton"));
        public EggplantElement GoogleViewingOptions = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/GoogleViewingOptions"));
        public EggplantElement HomepageBackground = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/HomepageBackground"));
        public EggplantElement NYTimesInternationalEditionOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/NYTimesInternationalEditionOption"));
        public EggplantElement NYTimesTechnologySection = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/NYTimesTechnologySection"));
        public EggplantElement NYTimesUSEditionOption = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/NYTimesUSEditionOption"));
        public EggplantElement YahooLogo = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/YahooLogo"));
        public EggplantElement YahooMailIcon = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/YahooMailIcon"));
        public EggplantElement YahooSearchButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/YahooSearchButton"));
        public EggplantElement YoutubeNextPageButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/YoutubeNextPageButton"));
        public EggplantElement YoutubeSearchButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/YoutubeSearchButton"));
        public EggplantElement YoutubeSignInButton = new EggplantElement(By.Image("MC65/Apps/BrowserIE/Websites/YoutubeSignInButton"));

        public Windows_MC65_HomeDesktop homeDesktop = new Windows_MC65_HomeDesktop();
        public Windows_MC65_NotificationsBar notificationsBar = new Windows_MC65_NotificationsBar();
        public Windows_MC65_MenuNav menuNav = new Windows_MC65_MenuNav();
        public Windows_MC65_StartBar startBar = new Windows_MC65_StartBar();
        public Windows_MC65_Popups popup = new Windows_MC65_Popups();
        public Windows_MC65_NetworkSettings settings = new Windows_MC65_NetworkSettings();
        public Windows_MC65_StartMenu startMenu = new Windows_MC65_StartMenu();
        public Enhancements.Windows.MC65.Utilities utilities = new Enhancements.Windows.MC65.Utilities();

        private void ActivateOverlayIfHidden()
        {
            Thread.Sleep(1000);

            if (startBar.KeyboardButton.IsPresent())
            {
                EggplantTestBase.Info("Clicking on Show Overlay button.");
                startBar.KeyboardButton.Click();
            }

            if (ShowOverlayButton.IsPresent())
            {
                EggplantTestBase.Info("Clicking on Show Overlay button.");
                ShowOverlayButton.Click();
                //Thread.Sleep(1000);
                AddressBar.WaitForPresent();
                Thread.Sleep(1000);
            }

        }

        private void CloseKeyboardIfOpened()
        {
            if (startBar.KeyboardButton.IsPresent())
            {
                EggplantTestBase.Info("Closing keyboard.");
                startBar.KeyboardButton.Click();
                Thread.Sleep(3000);
            }
        }

        private void ContinueIfWarned()
        {
            if (PopupWantToContinue.IsPresent())
            {
                EggplantTestBase.Info("Do you want to continue?  Selecting (Yes).");
                startBar.YesOption.Click();
            }
        }

        public IBrowserApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying browser app (Internet Explorer) elements.");
            return this;
        }

        public IBrowserApp ResetBrowserToDefaultState()
        {
            EggplantTestBase.Info("Resetting browser app (Internet Explorer) to default state.");
            ActivateOverlayIfHidden();
            //BookmarksButton.Click();
            //Thread.Sleep(3000);
            //OverlayExitButton.Click();
            EggplantTestBase.Info("Deleting browser app (Internet Explorer) cache items.");
            OverlayMenuButton.Click();
            ToolsMenuOption.Click();
            OptionsMenuOption.Click();
            BrowsingHistoryMenuOption.Click();
            EggplantTestBase.Info("Deleting temporary files.");
            TemporaryFilesOption.Click();
            startBar.ClearOption.Click();
            popup.ClickYes();
            EggplantTestBase.Info("Deleting cookies.");
            CookiesOption.Click();
            startBar.ClearOption.Click();
            popup.ClickYes();
            EggplantTestBase.Info("Deleting browser history.");
            HistoryOption.Click();
            startBar.ClearOption.Click();
            popup.ClickYes();
            startBar.OKButton.Click();
            startBar.OKButton.Click();
            EggplantTestBase.Info("Cache items cleared.  Returning to home page...");
            Thread.Sleep(3000);
            ActivateOverlayIfHidden();
            OverlayMenuButton.Click();
            HomePageMenuOption.Click();
            ContinueIfWarned();
            OverlayExitButton.WaitForNotPresent(30);
            HomepageBackground.WaitForPresent();
            EggplantTestBase.Info("Browser is on the home page.");
            Thread.Sleep(5000);
            if (startBar.KeyboardButton.IsPresent())
            {
                startBar.KeyboardButton.Click();
            }
            EggplantTestBase.Info("Browser state reset.  Waiting for overlay to hide...");
            ShowOverlayButton.WaitForPresent(15);
            Thread.Sleep(10000);
            return this;
        }

        public IBrowserApp GoToBookmarkedWebsite()
        {
            EggplantTestBase.Info("Going to bookmarked website (google.com).");
            ActivateOverlayIfHidden();
            BookmarksButton.Click();
            BookmarksHeader.WaitForPresent();
            BookmarkGoogleIcon.Click();
            //GoButton.Click();
            Thread.Sleep(10000);
            CloseKeyboardIfOpened();
            ShowOverlayButton.WaitForPresent(60);
            GoogleSearchButton.WaitForPresent(30);
            GoogleViewingOptions.WaitForPresent(30);
            EggplantTestBase.Info("Bookmarked website (google.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(15);
            return this;
        }

        public IBrowserApp GoToATTWebsite()
        {
            EggplantTestBase.Info("Going to AT&T mobile homepage (m.att.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.att.com");
            Thread.Sleep(2000);
            var driver = new EggplantDriver();
            driver.PressKey("Return");
            Thread.Sleep(3000);
            //ShowOverlayButton.WaitForPresent(30);   >>> Website is unstable, just doing simplistic checks.
            CloseKeyboardIfOpened();
            ATTCopyright.WaitForPresent(120);
            EggplantTestBase.Info("AT&T homepage (m.att.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToYahooWebsite()
        {
            EggplantTestBase.Info("Going to Yahoo mobile website (m.yahoo.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.yahoo.com");
            Thread.Sleep(2000);
            var driver = new EggplantDriver();
            driver.PressKey("Return");
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            YahooLogo.WaitForPresent(120);
            YahooMailIcon.WaitForPresent(120);
            YahooSearchButton.WaitForPresent(120);
            EggplantTestBase.Info("Yahoo mobile website (m.yahoo.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToFacebookWebsite()
        {
            EggplantTestBase.Info("Going to Facebook mobile website (m.facebook.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.facebook.com");
            Thread.Sleep(2000);
            var driver = new EggplantDriver();
            driver.PressKey("Return");
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            FacebookLogo.WaitForPresent(120);
            FacebookCreateAccount.WaitForPresent(120);
            FacebookLoginButton.WaitForPresent(120);
            EggplantTestBase.Info("Facebook mobile website (m.facebook.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToYoutubeWebsite()
        {
            EggplantTestBase.Info("Going to Youtube mobile website (m.youtube.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.youtube.com");
            Thread.Sleep(2000);
            var driver = new EggplantDriver();
            driver.PressKey("Return");
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            YoutubeSignInButton.WaitForPresent(120);
            YoutubeSearchButton.WaitForPresent(120);
            YoutubeNextPageButton.WaitForPresent(120);
            EggplantTestBase.Info("Youtube mobile website (m.youtube.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToNYTimesWebsite()
        {
            EggplantTestBase.Info("Going to NY Times mobile website (m.nytimes.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.nytimes.com");
            Thread.Sleep(2000);
            var driver = new EggplantDriver();
            driver.PressKey("Return");
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            NYTimesUSEditionOption.WaitForPresent(120);
            NYTimesInternationalEditionOption.WaitForPresent(120);
            NYTimesTechnologySection.WaitForPresent(120);
            EggplantTestBase.Info("NY Times mobile website (m.nytimes.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp DownloadNativeApp()
        {
            EggplantTestBase.Info("Downloading native application.");
            ActivateOverlayIfHidden();
            AddressBar.Type(Config.DownloadAppTestPath);
            Thread.Sleep(3000);
            var driver = new EggplantDriver();
            driver.PressKey("Return");
            Thread.Sleep(3000);
            DownloadTheFilePrompt.WaitForPresent(10);
            startBar.YesOption.Click();
            return this;
        }

        public IHomeScreen ReturnToHomeScreen()
        {
            EggplantTestBase.Info("Returning to the home screen from the browser app.");
            homeDesktop.ReturnToHomeScreen();
            //ActivateOverlayIfHidden();
            //StartButton.Click();
            //menuNav.GoToHome();
            return new Windows_MC65_HomeDesktop();
        }

        public IBrowserApp ExitApp()
        {
            EggplantTestBase.Info("Exiting browser app (Internet Explorer).");
            ActivateOverlayIfHidden();
            if (OverlayExitButton.IsPresent())
            {
                OverlayExitButton.Click();
            }
            Thread.Sleep(2000);
            while (OverlayExitButton.IsPresent() || startBar.ExitButton.IsPresent())
            {
                if (OverlayExitButton.IsPresent())
                {
                    OverlayExitButton.Click();
                }
                if (startBar.ExitButton.IsPresent())
                {
                    startBar.ExitButton.Click();
                }
            }
            Thread.Sleep(3000);
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
