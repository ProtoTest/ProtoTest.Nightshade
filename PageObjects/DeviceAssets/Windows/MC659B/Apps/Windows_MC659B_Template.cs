using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_Template : ITemplate
    {
        public EggplantElement ELEMENT = new EggplantElement(By.Image(""));

        public ITemplate VerifyElements()
        {
            EggplantTestBase.Log("Verifying TEMPLATE elements.");
            //
            return this;
        }

        public ITemplate ExitApp()
        {
            EggplantTestBase.Log("Exiting TEMPLATE app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
