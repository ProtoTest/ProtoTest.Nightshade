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
        [Repeat(10)] //Number of iterations set within "SetCalendarAppointments"
        public void TestCalendarAppointments()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToCalendarApp().VerifyElements().SetUpCalendarApp().SetCalendarAppointments(5).ExitApp(); //Number of iterations set within "SetCalendarAppointments"
            Command.NavigateTheMenu().GoToCalendarApp().DeleteCalendarAppointments().ExitApp();
        }

        [Test]
        [Description("Alarms - Tests 5.1.7.2 and 5.1.7.4")]
        [Category("Single Device")]
        [Repeat(10)]
        public void TestAlarms()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToAlarmsApp().VerifyElements().SetUpAlarmsApp().SetAlarm1().ExitApp();
            Command.OnHomeScreenScreen().ConfirmAlarm1On();
            Command.NavigateTheMenu().GoToAlarmsApp().TurnOffAllAlarms().ExitApp();
            Command.OnHomeScreenScreen().ConfirmAlarm1Off();
        }

        [Test]
        [Description("Tasks - Tests 5.1.7.5, 5.1.7.6, and 5.1.7.7")]
        [Category("Single Device")]
        [Repeat(10)]
        public void TestTasks()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.NavigateTheMenu().GoToTasksApp().VerifyElements().SetUpTasksApp().CreateTask().DeleteAllTasks().ExitApp();
        }

    }
}
