﻿

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_Popups
    {
        public EggplantElement YesButton = new EggplantElement(By.Image("MC659B/System/Popups/YesButton"));
        public EggplantElement NoButton = new EggplantElement(By.Image("MC659B/System/Popups/NoButton"));
        
        public void ClickYes()
        {
            EggplantTestBase.Log("Selecting popup option - Yes.");
            YesButton.VerifyPresent();
        }
        
        public void ClickNo()
        {
            EggplantTestBase.Log("Selecting popup option - No.");
            NoButton.Click();
        }

    }
}