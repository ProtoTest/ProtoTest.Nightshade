using System.ComponentModel;
using System.Drawing;
using System.Threading;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.Tests
{
    public class Experiments : EggplantTestBase
    {
        [Test]
        public void TestNotificationBar()
        {
            ConnectToHost2();
            var Test = new PageObjects.DeviceAssets.System.NotificationsBar();
            Test.VerifyElements();
        }
    }
}
