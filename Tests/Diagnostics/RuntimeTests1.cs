using System.Threading;
using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;

namespace ProtoTest.Nightshade.Tests.Diagnostics
{
    public class RuntimeTests1 : EggplantTestBase
        {

            //[Test]
            [RepeatForConfigValue("RuntimeTests#")]
            public void StartAndStopEggplantDrive1A()
            {
                Info("Test #1A: Eggplant should have started up.  Now running simple test...");
               EggplantTestBase.Driver.Connect(Config.Host1Ip);
                var desktop = new Windows_MC65_HomeDesktop();
                desktop.ConfirmHomeScreen();
                Thread.Sleep(3000);
                Info("Eggplant should now power down successfully.");
            }

            //[Test]
            [RepeatForConfigValue("RuntimeTests#")]
            public void StartAndStopEggplantDrive1B()
            {
                Info("Test #1B: Eggplant should have started up.  Now running simple test...");
               EggplantTestBase.Driver.Connect(Config.Host1Ip);
                var desktop = new Windows_MC65_HomeDesktop();
                desktop.ConfirmHomeScreen();
                Thread.Sleep(3000);
                Info("Eggplant should now power down successfully.");
            }
        }
}