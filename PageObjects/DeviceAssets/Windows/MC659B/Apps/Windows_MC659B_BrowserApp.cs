using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_BrowserApp : IBrowserApp
    {
        public EggplantElement AddressBar = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/AddressBar"));
        public EggplantElement BackButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/BackButton"));
        public EggplantElement BookmarksButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/BookmarksButton"));
        public EggplantElement BrowsingHistoryMenuOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/BrowsingHistoryMenuOption"));
        public EggplantElement OverlayExitButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/ExitButton"));
        public EggplantElement GoButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/GoButton"));
        public EggplantElement HistoryMenuOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/HistoryMenuOption"));
        public EggplantElement HomePageMenuOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/HomePageMenuOption"));
        public EggplantElement KeyboardButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/KeyboardButton"));
        public EggplantElement OverlayMenuButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/MenuButton"));
        public EggplantElement OptionsMenuOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/OptionsMenuOption"));
        public EggplantElement PopupWantToContinue = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/PopupWantToContinue"));
        public EggplantElement ShowOverlayButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/ShowOverlayButton"));
        public EggplantElement StartButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/StartButton"));
        public EggplantElement StopButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/StopButton"));
        public EggplantElement ToolsMenuOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/ToolsMenuOption"));

        public EggplantElement BookmarkGoogleIcon = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Bookmarks/BookmarkGoogleIcon"));
        public EggplantElement BookmarksHeader = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Bookmarks/BookmarksHeader"));

        public EggplantElement CookiesOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/BrowserHistoryMenu/CookiesOption"));
        public EggplantElement HistoryOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/BrowserHistoryMenu/HistoryOption"));
        public EggplantElement TemporaryFilesOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/BrowserHistoryMenu/TemporaryFilesOption"));

        public EggplantElement DownloadFileButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Downloads/DownloadFileButton"));
        public EggplantElement DownloadTheFilePrompt = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Downloads/DownloadTheFilePrompt"));
        public EggplantElement PowerDictaphonelnstallHeader = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Downloads/PowerDictaphonelnstallHeader"));
        public EggplantElement PowerDictaphonelnstallPrompt = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Downloads/PowerDictaphonelnstallPrompt"));

        public EggplantElement ATTCopyright = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/ATTCopyright"));
        public EggplantElement FacebookCreateAccount = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/FacebookCreateAccount"));
        public EggplantElement FacebookLoginButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/FacebookLoginButton"));
        public EggplantElement FacebookLogo = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/FacebookLogo"));
        public EggplantElement GoogleSearchButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/GoogleSearchButton"));
        public EggplantElement GoogleViewingOptions = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/GoogleViewingOptions"));
        public EggplantElement HomepageBackground = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/HomepageBackground"));
        public EggplantElement NYTimesInternationalEditionOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/NYTimesInternationalEditionOption"));
        public EggplantElement NYTimesTechnologySection = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/NYTimesTechnologySection"));
        public EggplantElement NYTimesUSEditionOption = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/NYTimesUSEditionOption"));
        public EggplantElement YahooLogo = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/YahooLogo"));
        public EggplantElement YahooMailIcon = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/YahooMailIcon"));
        public EggplantElement YahooSearchButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/YahooSearchButton"));
        public EggplantElement YoutubeNextPageButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/YoutubeNextPageButton"));
        public EggplantElement YoutubeSearchButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/YoutubeSearchButton"));
        public EggplantElement YoutubeSignInButton = new EggplantElement(By.Image("MC659B/Apps/BrowserIE/Websites/YoutubeSignInButton"));

        public Windows_MC659B_HomeDesktop homeDesktop = new Windows_MC659B_HomeDesktop();
        public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();
        public Windows_MC659B_MenuNav menuNav = new Windows_MC659B_MenuNav();
        public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        public Windows_MC659B_Popups popup = new Windows_MC659B_Popups();
        public Windows_MC659B_NetworkSettings settings = new Windows_MC659B_NetworkSettings();
        public Windows_MC659B_StartMenu startMenu = new Windows_MC659B_StartMenu();
        public Enhancements.Windows.MC659B.Utilities utilities = new Enhancements.Windows.MC659B.Utilities();

        private void ActivateOverlayIfHidden()
        {
            if (ShowOverlayButton.IsPresent())
            {
                EggplantTestBase.Log("Clicking on Show Overlay button.");
                ShowOverlayButton.Click();
                Thread.Sleep(1000);
            }
        }

        private void CloseKeyboardIfOpened()
        {
            if (startBar.KeyboardButton.IsPresent())
            {
                EggplantTestBase.Log("Closing keyboard.");
                startBar.KeyboardButton.Click();
                Thread.Sleep(3000);
            }
        }

        private void ContinueIfWarned()
        {
            if (PopupWantToContinue.IsPresent())
            {
                EggplantTestBase.Log("Do you want to continue?  Selecting (Yes).");
                startBar.YesOption.Click();
            }
        }

        public IBrowserApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying browser app (Internet Explorer) elements.");
            return this;
        }

        public IBrowserApp ResetBrowserToDefaultState()
        {
            EggplantTestBase.Log("Resetting browser app (Internet Explorer) to default state.");
            ActivateOverlayIfHidden();
            BookmarksButton.Click();
            Thread.Sleep(3000);
            OverlayExitButton.Click();
            EggplantTestBase.Log("Deleting browser app (Internet Explorer) cache items.");
            OverlayMenuButton.Click();
            ToolsMenuOption.Click();
            OptionsMenuOption.Click();
            BrowsingHistoryMenuOption.Click();
            EggplantTestBase.Log("Deleting temporary files.");
            TemporaryFilesOption.Click();
            startBar.ClearOption.Click();
            popup.ClickYes();
            EggplantTestBase.Log("Deleting cookies.");
            CookiesOption.Click();
            startBar.ClearOption.Click();
            popup.ClickYes();
            EggplantTestBase.Log("Deleting browser history.");
            HistoryOption.Click();
            startBar.ClearOption.Click();
            popup.ClickYes();
            startBar.OKButton.Click();
            startBar.OKButton.Click();
            EggplantTestBase.Log("Cache items cleared.  Returning to home page...");
            Thread.Sleep(3000);
            ActivateOverlayIfHidden();
            OverlayMenuButton.Click();
            HomePageMenuOption.Click();
            ContinueIfWarned();
            OverlayExitButton.WaitForNotPresent(30);
            HomepageBackground.WaitForPresent();
            EggplantTestBase.Log("Browser is on the home page.");
            Thread.Sleep(5000);
            if (startBar.KeyboardKeyEnter.IsPresent())
            {
                startBar.KeyboardButton.Click();
            }
            EggplantTestBase.Log("Browser state reset.  Waiting for overlay to hide...");
            ShowOverlayButton.WaitForPresent(15);
            Thread.Sleep(10000);
            return this;
        }

        public IBrowserApp GoToBookmarkedWebsite()
        {
            EggplantTestBase.Log("Going to bookmarked website (google.com).");
            ActivateOverlayIfHidden();
            BookmarksButton.Click();
            BookmarksHeader.WaitForPresent();
            BookmarkGoogleIcon.Click();
            GoButton.Click();
            Thread.Sleep(10000);
            CloseKeyboardIfOpened();
            ShowOverlayButton.WaitForPresent(60);
            GoogleSearchButton.WaitForPresent();
            GoogleViewingOptions.WaitForPresent();
            EggplantTestBase.Log("Bookmarked website (google.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(15);
            return this;
        }

        public IBrowserApp GoToATTWebsite()
        {
            EggplantTestBase.Log("Going to AT&T mobile homepage (m.att.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.att.com");
            Thread.Sleep(2000);
            GoButton.Click();
            Thread.Sleep(3000);
            //ShowOverlayButton.WaitForPresent(30);   >>> Website is unstable, just doing simplistic checks.
            CloseKeyboardIfOpened();
            ATTCopyright.WaitForPresent(60);
            EggplantTestBase.Log("AT&T homepage (m.att.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToYahooWebsite()
        {
            EggplantTestBase.Log("Going to Yahoo mobile website (m.yahoo.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.yahoo.com");
            Thread.Sleep(2000);
            GoButton.Click();
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            YahooLogo.WaitForPresent();
            YahooMailIcon.WaitForPresent();
            YahooSearchButton.WaitForPresent();
            EggplantTestBase.Log("Yahoo mobile website (m.yahoo.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToFacebookWebsite()
        {
            EggplantTestBase.Log("Going to Facebook mobile website (m.facebook.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.facebook.com");
            Thread.Sleep(2000);
            GoButton.Click();
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            FacebookLogo.WaitForPresent();
            FacebookCreateAccount.WaitForPresent();
            FacebookLoginButton.WaitForPresent();
            EggplantTestBase.Log("Facebook mobile website (m.facebook.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToYoutubeWebsite()
        {
            EggplantTestBase.Log("Going to Youtube mobile website (m.youtube.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.youtube.com");
            Thread.Sleep(2000);
            GoButton.Click();
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            YoutubeSignInButton.WaitForPresent();
            YoutubeSearchButton.WaitForPresent();
            YoutubeNextPageButton.WaitForPresent();
            EggplantTestBase.Log("Youtube mobile website (m.youtube.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp GoToNYTimesWebsite()
        {
            EggplantTestBase.Log("Going to NY Times mobile website (m.nytimes.com).");
            ActivateOverlayIfHidden();
            AddressBar.Type("m.nytimes.com");
            Thread.Sleep(2000);
            GoButton.Click();
            Thread.Sleep(15000);
            ContinueIfWarned();
            ShowOverlayButton.WaitForPresent(60);
            CloseKeyboardIfOpened();
            NYTimesUSEditionOption.WaitForPresent();
            NYTimesInternationalEditionOption.WaitForPresent();
            NYTimesTechnologySection.WaitForPresent();
            EggplantTestBase.Log("NY Times mobile website (m.nytimes.com) has loaded.");
            Thread.Sleep(30000);
            ShowOverlayButton.WaitForPresent(60);
            return this;
        }

        public IBrowserApp DownloadNativeApp()
        {
            EggplantTestBase.Log("Downloading native application.");
            ActivateOverlayIfHidden();
            AddressBar.Type(Config.DownloadAppTestPath);
            Thread.Sleep(3000);
            GoButton.Click();
            Thread.Sleep(3000);
            DownloadTheFilePrompt.WaitForPresent(10);
            startBar.YesOption.Click();
            return this;
        }

        public IHomeScreen ReturnToHomeScreen()
        {
            EggplantTestBase.Log("Returning to the home screen from the browser app.");
            ActivateOverlayIfHidden();
            StartButton.Click();
            menuNav.GoToHome();
            return new Windows_MC659B_HomeDesktop();
        }

        public IBrowserApp ExitApp()
        {
            EggplantTestBase.Log("Exiting browser app (Internet Explorer).");
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
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
