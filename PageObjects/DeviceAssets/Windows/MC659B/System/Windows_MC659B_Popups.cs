

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_Popups
    {
        public EggplantElement YesButton = new EggplantElement(By.Image("MC659B/System/Popups/YesButton"));
        public EggplantElement NoButton = new EggplantElement(By.Image("MC659B/System/Popups/NoButton"));
        public EggplantElement DeleteItem = new EggplantElement(By.Image("MC659B/System/Popups/Delete"));
        public EggplantElement OKButton = new EggplantElement(By.Image("MC659B/System/Popups/OKButton"));

        public EggplantElement PopupPocketPCNetworkingHeader = new EggplantElement(By.Image("MC659B/System/Popups/PopupPocketPCNetworkingHeader"));
        public EggplantElement PopupPocketPCNetworkingOKButton = new EggplantElement(By.Image("MC659B/System/Popups/PopupPocketPCNetworkingOKButton"));

        public EggplantElement NewTextMessage = new EggplantElement(By.Image("MC659B/System/Popups/NewTextMessage"));

        public void ClickYes()
        {
            EggplantTestBase.Log("Selecting popup option - Yes.");
            YesButton.Click();
        }
        
        public void ClickNo()
        {
            EggplantTestBase.Log("Selecting popup option - No.");
            NoButton.Click();
        }

        public void ClickOK()
        {
            EggplantTestBase.Log("Selecting popup option - OK.");
            OKButton.Click();
        }

        public void IfNetworkingPopupAppearsClickOK()
        {
            if (PopupPocketPCNetworkingHeader.IsPresent())
            {
                EggplantTestBase.Log("Pocket PC Networking popup detected.  Clicking OK.");
                PopupPocketPCNetworkingOKButton.Click();
            }
            
        }
    }
}
