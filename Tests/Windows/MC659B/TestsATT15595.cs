using System.Drawing;
using System.Threading;
using Gallio.Common.Media;
using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.Windows.MC659B
{
    public class TestsATT15595 : EggplantTestBase
    {
        
        [Test]
        [Description("Calendar Appointments - Tests 5.1.7.1 and 5.1.7.3")]
        [Category("Single Device")]
        public void TestCalendarAppointments()
        {
            ConnectToHost1();
            Command.SetUpTest().ConfirmHomeScreen();
            Command.Execute().GoToCalendarApp().VerifyElements().SetUpCalendarApp().SetCalendarAppointments().ExitApp();
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

        [Test]
        [Description("Camera Video - Tests 5.1.8.1, 5.1.8.2, and 5.1.8.3")]
        [Category("Single Device")]
        public void TestCameraVideo()
        {

        }

        [Test]
        [Description("Camera Pictures - Tests 5.1.8.4, 5.1.8.5, and 5.1.8.6")]
        [Category("Single Device")]
        public void TestCameraPictures()
        {

        }

        [Test]
        [Description("Device Themes - Tests 5.1.8.14")]
        [Category("Single Device")]
        public void TestDeviceThemes()
        {

        }

    }
}
