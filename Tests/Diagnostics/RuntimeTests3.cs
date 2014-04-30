using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.Tests.Diagnostics
{
    public class RuntimeTests3 : EggplantTestBase
        {

            [Test]
            [RepeatForConfigValue("RuntimeTests#")]
            public void StartAndStopEggplantDrive3A()
            {
                Info("Test #3A: Eggplant should have started up.  Now running simple test...");
                Driver.Connect(Config.Host1Ip);
                var desktop = new Windows_MC65_HomeDesktop();
                desktop.ConfirmHomeScreen();
                Thread.Sleep(3000);
                Info("Eggplant should now power down successfully.");
            }

            [Test]
            [RepeatForConfigValue("RuntimeTests#")]
            public void StartAndStopEggplantDrive3B()
            {
                Info("Test #3B: Eggplant should have started up.  Now running simple test...");
                Driver.Connect(Config.Host1Ip);
                var desktop = new Windows_MC65_HomeDesktop();
                desktop.ConfirmHomeScreen();
                Thread.Sleep(3000);
                Info("Eggplant should now power down successfully.");
            }
        }
}