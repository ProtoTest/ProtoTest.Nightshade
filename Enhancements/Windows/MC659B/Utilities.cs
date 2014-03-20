using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.Enhacements.Windows.MC659B
{
    public class Utilities
    {
        public void SearchMenuFor(EggplantElement element)
        {
            int driverTimeOut = Config.DriveTimeoutSec;
            int driverTimeOutMS = driverTimeOut*1000;
            var eggplantDriver = new EggplantDriver(driverTimeOutMS);
            string elementText = element.locator;

            if (element.IsPresent())
            {
                EggplantTestBase.Log(elementText + " detected.");
                return;
            }
            const int totalAttempts = 3;
            for (int i = 0; i < totalAttempts; i++)
            {
                EggplantTestBase.Log("Scrolling through menu for " + elementText + ". Attempt #" + i + ".");
                    
                for (int j = 0; j < 10; j++)
                {
                    //EggplantTestBase.Log("Searching for " + elementText + ".  Iteration #" + j + ".");
                    eggplantDriver.SwipeUp();
                    Thread.Sleep(3000);
                    if (element.IsPresent())
                    {
                        EggplantTestBase.Log(elementText + " detected.");
                        return;
                    }
                }

                EggplantTestBase.Log("Returning to top of menu for another attempt.");
                for(int k = 0; k < 10; k++)
                {
                    eggplantDriver.SwipeDown();
                    Thread.Sleep(3000);
                }
                var startMenu = new Windows_MC659B_StartMenu();
                startMenu.HomeIcon.WaitForPresent();
            }
            
            throw new Exception("Element not detected within menu after " + totalAttempts + " attempts.");
            
        }
    }
}
