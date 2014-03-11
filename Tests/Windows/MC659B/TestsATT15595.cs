using System.Drawing;
using System.Threading;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.Nightshade.PageObjects.Steps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.Tests.Windows.MC659B
{
    public class TestsATT15595 : EggplantTestBase
    {
        
        [Test]
        [Description("Calendar Appointments - Tests 5.1.7.1 and 5.1.7.3 ")]
        [Category("Single Device")]
        public void TestCalendarAppointments()
        {
            ConnectToHost1();
            Command.SetUpTest().ConfirmHomeScreen();

        }

        [Test]
        [Description("Alarms - Tests 5.1.7.2 and 5.1.7.4 ")]
        [Category("Single Device")]
        public void TestAlarms()
        {
            ConnectToHost1();
            Command.SetUpTest().ConfirmHomeScreen();
            Command.Execute().GoToAlarmsApp().VerifyElements().SetupAlarmsApp().SetAlarm1().ExitApp();
            Command.Execute().ConfirmAlarm1();
            Command.Execute().GoToAlarmsApp().TurnOffAllAlarms().ExitApp();
        }

        [Test]
        [Description("Tasks - Tests 5.1.7.5, 5.1.7.6, and 5.1.7.7 ")]
        [Category("Single Device")]
        public void TestTasks()
        {
            ConnectToHost1();
            Command.SetUpTest().ConfirmHomeScreen();
        }

    }
}
