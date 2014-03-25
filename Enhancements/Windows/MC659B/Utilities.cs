﻿using System;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.Enhancements.Windows.MC659B
{
    public class Utilities
    {
        public void SearchMenuFor(EggplantElement element)
        {
            int driverTimeOut = Config.DriveTimeoutSec;
            int driverTimeOutMS = driverTimeOut*1000;
            var eggplantDriver = new EggplantDriver(driverTimeOutMS);
            string elementText = element.locator;
            Thread.Sleep(2000);

            if (element.IsPresent())
            {
                EggplantTestBase.Log(elementText + " detected.");
                return;
            }
            const int totalAttempts = 3;
            for (int i = 1; i < totalAttempts+1; i++)
            {
                EggplantTestBase.Log("Scrolling through menu for " + elementText + ". Attempt #" + i + ".");
                    
                for (int j = 0; j < 5; j++)
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
                for(int k = 0; k < 5; k++)
                {
                    eggplantDriver.SwipeDown();
                    Thread.Sleep(3000);
                }
                var startMenu = new Windows_MC659B_StartMenu();
                startMenu.HomeIcon.WaitForPresent();
            }
            
            throw new Exception("Element not detected within menu after " + totalAttempts + " attempts.");
            
        }

        public void SearchForContact(EggplantElement element)
        {
            string elementText = element.locator;
            
            if (element.IsPresent())
            {
                EggplantTestBase.Log("Contact (" + elementText + ") detected.");
                return;
            }

            const int totalAttempts = 50;
            for (int i = 1; i < totalAttempts+1; i++)
            {
                EggplantTestBase.Log("Searching through Contacts list for contact (" + elementText + "). Attempt #" + i + ".");

                var contactsApp = new Windows_MC659B_ContactsApp();
                contactsApp.ScrollbarDownArrow.Click();
                Thread.Sleep(3000);
                if (element.IsPresent())
                {
                    EggplantTestBase.Log("Contact (" + elementText + ") detected.");
                    return;
                }
            }

            throw new Exception("Element not detected within menu after " + totalAttempts + " attempts.");
        }
    }
}
