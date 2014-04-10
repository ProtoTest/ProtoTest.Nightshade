using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.10")]
    [Category("Menu Navigation Stability Tests")]
    
    public class Section_5_1_10 : EggplantTestBase
    {
        [Test]
        [Description("Navigate to Each Desktop Icon Until Menu Tree Complete - Test 5.1.10.1")]
        [Category("Single Device")]
        [Repeat(10)]
        public void TestNavigateToEachDesktopIconUntilMenuTreeCompelted()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
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
        }

    }
}
