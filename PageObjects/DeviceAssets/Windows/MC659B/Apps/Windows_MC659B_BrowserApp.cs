using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_BrowserApp : IBrowserApp
    {
        public EggplantElement ELEMENT = new EggplantElement(By.Image(""));

        public IBrowserApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying browser app (Internet Explorer) elements.");
            //.VerifyPresent();
            return this;
        }

        public IBrowserApp ExitApp()
        {
            EggplantTestBase.Log("Exiting browser app.");
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
