using System.Drawing;
using System.Threading;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.Tests.Windows.MC659B
{
    public class TestsATT15595 : EggplantTestBase
    {
        [Test]
        [Description("Test 5.1.7A - Calendar Appointments")]
        [Category("Single Device")]
        public void TestCalendarAppointments()
        {
            OpenPage().
            PageObjects.Interfaces.IHomePage.OpenPage();

        }

        [Test]
        [Description("Test 5.1.7B - Alarms")]
        [Category("Single Device")]
        public void TestAlarms()
        {

        }

        [Test]
        [Description("Test 5.1.7C - Tasks")]
        [Category("Single Device")]
        public void TestTasks()
        {

        }

    }
}
