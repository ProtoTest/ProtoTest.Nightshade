

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu
{
    public class Windows_MC659B_StartMenu
    {
        public EggplantElement StartMenuHeader = new EggplantElement(By.Image("MC659B/System/Menus/StartMenuHeader"));
        public EggplantElement AlarmsApp = new EggplantElement(By.Image("MC659B/AppIcons/AlarmsApp"));
        public EggplantElement BrowserApp = new EggplantElement(By.Image("MC659B/AppIcons/BrowserApp"));
        public EggplantElement CalendarApp = new EggplantElement(By.Image("MC659B/AppIcons/CalendarApp"));
        public EggplantElement ContactsApp = new EggplantElement(By.Image("MC659B/AppIcons/ContactsApp"));
        public EggplantElement FileExplorerApp = new EggplantElement(By.Image("MC659B/AppIcons/FileExplorerApp"));
        public EggplantElement HomeIcon = new EggplantElement(By.Image("MC659B/AppIcons/HomeIcon"));
        public EggplantElement WindowsMediaApp = new EggplantElement(By.Image("MC659B/AppIcons/WindowsMediaApp"));
        public EggplantElement PicturesAndVideoApp = new EggplantElement(By.Image("MC659B/AppIcons/PicturesAndVideoApp"));
        public EggplantElement TasksApp = new EggplantElement(By.Image("MC659B/AppIcons/TasksApp"));
        
        public Windows_MC659B_StartMenu VerifyElements()
        {
            EggplantTestBase.Log("Entering start menu.");
            StartMenuHeader.WaitForPresent();
            return this;
        }

    }
}
