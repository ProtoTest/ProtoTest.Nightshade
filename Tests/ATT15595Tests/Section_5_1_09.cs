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
        [Repeat(1)]
        public void TestStartPhoneCallSwitchToOtherAppsEndCall()
        {
            ConnectToHost2();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreenScreen().SetCellularNetworkToThreeG();
            Command.NavigateTheMenu().GoToPhoneApp().CallMostRecentContactFromHistory();
            ConnectToHost2();
            Command.OnHomeScreenScreen().AnswerPhoneCall().VerifyCallEstablished();
            ConnectToHost1();
            Command.OnHomeScreenScreen().VerifyCallEstablished().ReturnToHomeScreen();
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
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            ConnectToHost2();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
        }

        [Test]
        [Description("Open the Browser, Switch to other Running Apps, Close Browser - Tests 5.1.9.4, 5.1.9.5, and 5.1.9.6")]
        [Category("Single Device")]
        [Repeat(1)]
        public void TestStartBrowserCallSwitchToOtherAppsCloseBrowser()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().SetCellularConnectionToThreeG();
            Command.OnHomeScreenScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreenScreen().TurnOnWifi();
            Command.OnHomeScreenScreen().VerifyWifiOn();
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
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreenScreen().ResetWifiRadioToDefault();
        }

    }
}
