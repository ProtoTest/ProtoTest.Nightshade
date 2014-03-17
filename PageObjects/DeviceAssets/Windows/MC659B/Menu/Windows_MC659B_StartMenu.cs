

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu
{
    public class Windows_MC659B_StartMenu
    {
        public EggplantElement StartMenuHeader = new EggplantElement(By.Image("MC659B/System/Menus/StartMenuHeader"));
        public EggplantElement AlarmsApp = new EggplantElement(By.Image("MC659B/AppIcons/AlarmsApp"));
        public EggplantElement BrowserApp = new EggplantElement(By.Image("MC659B/AppIcons/BrowserApp"));
        public EggplantElement CalendarApp = new EggplantElement(By.Image("MC659B/AppIcons/CalendarApp"));
        public EggplantElement ContactsApp = new EggplantElement(By.Image("MC659B/AppIcons/ContactsApp"));
        public EggplantElement PicturesAndVideoApp = new EggplantElement(By.Image("MC659B/AppIcons/PicturesAndVideoApp"));
        public EggplantElement TasksApp = new EggplantElement(By.Image("MC659B/AppIcons/TasksApp"));
        
        public Windows_MC659B_StartMenu VerifyElements()
        {
            EggplantTestBase.Log("Entering start menu.");
            StartMenuHeader.VerifyPresent();
            return this;
        }

        //public void GoToApp(EggplantElement app)
        //{
        //    var utility = new Enhacements.Windows.MC659B.Utilities();
        //    utility.SearchMenuFor(app);
        //    EggplantTestBase.Log("Clicking on " + app + " icon.");
        //    app.Click();
        //}

    }
}
