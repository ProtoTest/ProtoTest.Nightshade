using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.9")]
    [Category("Multi-tasking Stability Tests")]
    public class Section_5_1_09 : EggplantTestBase
    {
        [Test]
        [Description("Start a Phone Call, Switch to other Running Apps, End Call - Tests 5.1.9.1, 5.1.9.2, and 5.1.9.3")]
        [Category("Paired Device")]
        [RepeatForConfigValue("TestStartPhoneCallSwitchToOtherAppsEndCall#")]
        public void TestStartPhoneCallSwitchToOtherAppsEndCall()
        {
            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().SetCellularNetworkToThreeG();
            Command.NavigateTheMenu().GoToPhoneApp().CallMostRecentContactFromHistory();
            ConnectToHost2();
            Command.OnHomeScreen().AnswerPhoneCall().VerifyCallEstablished();
            ConnectToHost1();
            Command.OnHomeScreen().VerifyCallEstablished().ReturnToHomeScreen();
            Command.NavigateTheMenu().GoToAlarmsApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToBrowserApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToCalendarApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToContactsApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToEmailApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToInstantMessengerApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToMediaPlayerApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToPhoneApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToSettingsApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToTasksApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToTextMessagesApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToPhoneApp().EndPhoneCall().ExitApp();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            ConnectToHost2();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
        }

        [Test]
        [Description("Open the Browser, Switch to other Running Apps, Close Browser - Tests 5.1.9.4, 5.1.9.5, and 5.1.9.6")]
        [Category("Single Device")]
        [RepeatForConfigValue("TestStartBrowserSwitchToOtherAppsCloseBrowser#")]
        public void TestStartBrowserSwitchToOtherAppsCloseBrowser()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().SetCellularConnectionToThreeG();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreen().TurnOnWifi();
            Command.OnHomeScreen().VerifyWifiOn();
            Command.NavigateTheMenu().GoToBrowserApp().ResetBrowserToDefaultState().ExitApp();
            Command.NavigateTheMenu().GoToBrowserApp().GoToBookmarkedWebsite().ReturnToHomeScreen();
            Command.NavigateTheMenu().GoToAlarmsApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToBrowserApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToCalendarApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToContactsApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToEmailApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToInstantMessengerApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToMediaPlayerApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToPhoneApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToSettingsApp().VerifyElements().ExitApp();
            Command.NavigateTheMenu().GoToTasksApp().VerifyElements().ExitApp();
            //Command.NavigateTheMenu().GoToTextMessagesApp().VerifyElements().ExitApp();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
        }

    }
}
