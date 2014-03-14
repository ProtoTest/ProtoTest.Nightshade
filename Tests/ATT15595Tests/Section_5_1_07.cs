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
        public void TestCalendarAppointments()
        {
            ConnectToHost1();
            Command.SetUpTest().ConfirmHomeScreen();
            Command.Execute().GoToCalendarApp().VerifyElements().SetUpCalendarApp().SetCalendarAppointments(5).ExitApp();
            Command.Execute().GoToCalendarApp().DeleteCalendarAppointments().ExitApp();
        }

        [Test]
        [Description("Alarms - Tests 5.1.7.2 and 5.1.7.4")]
        [Category("Single Device")]
        public void TestAlarms()
        {
            ConnectToHost1();
            Command.SetUpTest().ConfirmHomeScreen();
            Command.Execute().GoToAlarmsApp().VerifyElements().SetUpAlarmsApp().SetAlarm1().ExitApp();
            Command.Execute().ConfirmAlarm1();
            Command.Execute().GoToAlarmsApp().TurnOffAllAlarms().ExitApp();
        }

        [Test]
        [Description("Tasks - Tests 5.1.7.5, 5.1.7.6, and 5.1.7.7")]
        [Category("Single Device")]
        public void TestTasks()
        {
            ConnectToHost1();
            Command.SetUpTest().ConfirmHomeScreen();
            Command.Execute().GoToTasksApp().VerifyElements().SetUpTasksApp().CreateTask().DeleteAllTasks().ExitApp();
        }

    }
}
