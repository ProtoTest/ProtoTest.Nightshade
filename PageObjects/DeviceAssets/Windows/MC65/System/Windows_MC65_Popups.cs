

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System
{
    public class Windows_MC65_Popups
    {
        public EggplantElement YesButton = new EggplantElement(By.Image("MC65/System/Popups/YesButton"));
        public EggplantElement NoButton = new EggplantElement(By.Image("MC65/System/Popups/NoButton"));
        public EggplantElement DeleteItem = new EggplantElement(By.Image("MC65/System/Popups/Delete"));
        public EggplantElement OKButton = new EggplantElement(By.Image("MC65/System/Popups/OKButton"));

        public EggplantElement PopupPocketPCNetworkingHeader = new EggplantElement(By.Image("MC65/System/Popups/PopupPocketPCNetworkingHeader"));
        public EggplantElement PopupPocketPCNetworkingOKButton = new EggplantElement(By.Image("MC65/System/Popups/PopupPocketPCNetworkingOKButton"));

        public EggplantElement NewTextMessage = new EggplantElement(By.Image("MC65/System/Popups/NewTextMessage"));

        public void ClickYes()
        {
            EggplantTestBase.Info("Selecting popup option - Yes.");
            YesButton.Click();
        }
        
        public void ClickNo()
        {
            EggplantTestBase.Info("Selecting popup option - No.");
            NoButton.Click();
        }

        public void ClickOK()
        {
            EggplantTestBase.Info("Selecting popup option - OK.");
            OKButton.Click();
        }

        public void IfNetworkingPopupAppearsClickOK()
        {
            if (PopupPocketPCNetworkingHeader.IsPresent())
            {
                EggplantTestBase.Info("Pocket PC Networking popup detected.  Clicking OK.");
                PopupPocketPCNetworkingOKButton.Click();
            }
            
        }
    }
}
