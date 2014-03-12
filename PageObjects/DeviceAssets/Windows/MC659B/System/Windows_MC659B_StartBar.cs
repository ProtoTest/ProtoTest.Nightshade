using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_StartBar
    {
        public EggplantElement StartButton = new EggplantElement(By.Image("MC659B/System/StartBar/StartButton"));
        public EggplantElement ExitButton = new EggplantElement(By.Image("MC659B/System/StartBar/ExitButton"));
        public EggplantElement OKButton = new EggplantElement(By.Image("MC659B/System/StartBar/OKButton"));
        public EggplantElement MenuButton = new EggplantElement(By.Image("MC659B/System/StartBar/MenuButton"));
        public EggplantElement TaskEditButton = new EggplantElement(By.Image("MC659B/System/StartBar/TaskEditButton"));

        public Windows_MC659B_StartBar VerifyElements()
        {
            EggplantTestBase.Log("Verifying start bar elements.");
            StartButton.VerifyPresent();
            return this;
        }
        
        public Windows_MC659B_StartMenu EnterStartMenu()
        {
            EggplantTestBase.Log("Selecting Start Button.");
            StartButton.Click();
            return new Windows_MC659B_StartMenu();
        }


    }
}
