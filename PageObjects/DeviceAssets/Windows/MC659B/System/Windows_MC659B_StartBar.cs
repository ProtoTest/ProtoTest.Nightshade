using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class Windows_MC659B_StartBar
    {
        public EggplantElement AddItemButton = new EggplantElement(By.Image("MC659B/System/StartBar/AddItemButton"));
        public EggplantElement ClearOption = new EggplantElement(By.Image("MC659B/System/StartBar/ClearOption"));
        public EggplantElement ExitButton = new EggplantElement(By.Image("MC659B/System/StartBar/ExitButton"));
        public EggplantElement KeyboardButton = new EggplantElement(By.Image("MC659B/System/StartBar/KeyboardButton"));
        public EggplantElement OKButton = new EggplantElement(By.Image("MC659B/System/StartBar/OKButton"));
        public EggplantElement MenuButton = new EggplantElement(By.Image("MC659B/System/StartBar/MenuButton"));
        public EggplantElement MenuOption = new EggplantElement(By.Image("MC659B/System/StartBar/MenuOption"));
        public EggplantElement NowPlaying = new EggplantElement(By.Image("MC659B/Apps/WindowsMedia/NowPlaying"));
        public EggplantElement StartButton = new EggplantElement(By.Image("MC659B/System/StartBar/StartButton"));
        public EggplantElement StopOption = new EggplantElement(By.Image("MC659B/System/StartBar/StopOption"));
        public EggplantElement TaskEditButton = new EggplantElement(By.Image("MC659B/System/StartBar/TaskEditButton"));
        public EggplantElement ThumbnailsButton = new EggplantElement(By.Image("MC659B/System/StartBar/ThumbnailsButton"));
        public EggplantElement YesOption = new EggplantElement(By.Image("MC659B/System/StartBar/YesOption"));

        public EggplantElement KeyboardKeyEnter = new EggplantElement(By.Image("MC659B/System/StartBar/Keyboard/KeyboardKeyEnter"));

        public Windows_MC659B_StartBar VerifyElements()
        {
            EggplantTestBase.Log("Verifying start bar elements.");
            StartButton.WaitForPresent();
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
