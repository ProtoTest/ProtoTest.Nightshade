using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Menu;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System
{
    public class Windows_MC65_StartBar
    {
        public EggplantElement AddItemButton = new EggplantElement(By.Image("MC65/System/StartBar/AddItemButton"));
        public EggplantElement ClearOption = new EggplantElement(By.Image("MC65/System/StartBar/ClearOption"));
        public EggplantElement DoneOption = new EggplantElement(By.Image("MC65/System/StartBar/DoneOption"));
        public EggplantElement ExitButton = new EggplantElement(By.Image("MC65/System/StartBar/ExitButton"));
        public EggplantElement GoToContactButton = new EggplantElement(By.Image("MC65/System/StartBar/GoToContactButton"));
        public EggplantElement KeyboardButton = new EggplantElement(By.Image("MC65/System/StartBar/KeyboardButton"));
        public EggplantElement OKButton = new EggplantElement(By.Image("MC65/System/StartBar/OKButton"));
        public EggplantElement MenuButton = new EggplantElement(By.Image("MC65/System/StartBar/MenuButton"));
        public EggplantElement MenuOption = new EggplantElement(By.Image("MC65/System/StartBar/MenuOption"));
        public EggplantElement NowPlaying = new EggplantElement(By.Image("MC65/Apps/WindowsMedia/NowPlaying"));
        public EggplantElement StartButton = new EggplantElement(By.Image("MC65/System/StartBar/StartButton"));
        public EggplantElement StopOption = new EggplantElement(By.Image("MC65/System/StartBar/StopOption"));
        public EggplantElement TaskEditButton = new EggplantElement(By.Image("MC65/System/StartBar/TaskEditButton"));
        public EggplantElement ThumbnailsButton = new EggplantElement(By.Image("MC65/System/StartBar/ThumbnailsButton"));
        public EggplantElement YesOption = new EggplantElement(By.Image("MC65/System/StartBar/YesOption"));
        public EggplantElement SendMessage = new EggplantElement(By.Image("MC65/System/StartBar/SendMessage"));
        public EggplantElement NotificationOption = new EggplantElement(By.Image("MC65/System/StartBar/NotificationOption"));

        public EggplantElement KeyboardKeyEnter = new EggplantElement(By.Image("MC65/System/StartBar/Keyboard/KeyboardKeyEnter"));

        //MenuOptions
        public EggplantElement SendAndReceiveEmailMenuOption = new EggplantElement(By.Image("MC65/System/MenuOptions/SendAndReceiveEmailMenuOption"));
        public EggplantElement DeleteMenuOption = new EggplantElement(By.Image("MC65/System/MenuOptions/DeleteMenuOption"));
        public EggplantElement ToolsMenuOption = new EggplantElement(By.Image("MC65/System/MenuOptions/ToolsMenuOption"));
        public EggplantElement EmptyDeletedItemsMenuOption = new EggplantElement(By.Image("MC65/System/MenuOptions/EmptyDeletedItemsMenuOption"));
        public EggplantElement InsertMenuOption = new EggplantElement(By.Image("MC65/System/MenuOptions/InsertMenuOption"));
        public EggplantElement PictureMenuOption = new EggplantElement(By.Image("MC65/System/MenuOptions/InsertMenuOption"));

        public Windows_MC65_StartBar VerifyElements()
        {
            EggplantTestBase.Info("Verifying start bar elements.");
            StartButton.WaitForPresent();
            return this;
        }
        
        public Windows_MC65_StartMenu EnterStartMenu()
        {
            EggplantTestBase.Info("Selecting Start Button.");
            StartButton.Click();
            return new Windows_MC65_StartMenu();
        }


    }
}
