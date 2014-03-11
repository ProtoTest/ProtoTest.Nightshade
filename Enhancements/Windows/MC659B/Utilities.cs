using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            
            if (element.IsPresent())
            {
                EggplantTestBase.Log(element + " detected.");
                return;
            }
            const int totalAttempts = 3;
            for (int i = 0; i < totalAttempts; i++)
            {
                EggplantTestBase.Log("Scrolling through menu for " + element + ". Attempt #" + i + ".");
                    
                for (int j = 0; j < 10; ++j)
                {
                    EggplantTestBase.Log("Searching for " + element + ".  Iteration #" + j + ".");
                    eggplantDriver.ScrollDown("10");
                        
                    if (element.IsPresent())
                    {
                        EggplantTestBase.Log(element + " detected.");
                        return;
                    }
                }

                EggplantTestBase.Log("Returning to top of menu for another attempt.");
                eggplantDriver.ScrollUp("100");

            }
            EggplantTestBase.Log("Element not detected within menu after " + totalAttempts + " attempts.");
            throw new Exception("gbuierkjnerke");
            
        }
    }
}
