using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.7")]
    [Category("PIM Stability Tests")]
    public class Section_5_1_07 : EggplantTestBase
    {
        [Test]
        [Description("Calendar Appointments - Tests 5.1.7.1 and 5.1.7.3")]
        [Category("Single Device")]
        [RepeatForConfigValue("TestCalendarAppointments#")] //"SetCalendarAppointments" section adds a given # of appointments
        public void TestCalendarAppointments()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToCalendarApp().VerifyElements().SetUpCalendarApp().SetCalendarAppointments(5).ExitApp(); //Number of iterations set within "SetCalendarAppointments"
            Command.NavigateTheMenu().GoToCalendarApp().DeleteCalendarAppointments().ExitApp();
        }

        [Test]
        [Description("Alarms - Tests 5.1.7.2 and 5.1.7.4")]
        [Category("Single Device")]
        [RepeatForConfigValue("TestAlarms#")]
        public void TestAlarms()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToAlarmsApp().VerifyElements().SetUpAlarmsApp().SetAlarm1().ExitApp();
            Command.OnHomeScreen().ConfirmAlarm1On();
            Command.NavigateTheMenu().GoToAlarmsApp().TurnOffAllAlarms().ExitApp();
            Command.OnHomeScreen().ConfirmAlarm1Off();
        }

        [Test]
        [Description("Tasks - Tests 5.1.7.5, 5.1.7.6, and 5.1.7.7")]
        [Category("Single Device")]
        [RepeatForConfigValue("TestTasks#")]
        public void TestTasks()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToTasksApp().VerifyElements().SetUpTasksApp().CreateTask().DeleteAllTasks().ExitApp();
        }

    }
}
