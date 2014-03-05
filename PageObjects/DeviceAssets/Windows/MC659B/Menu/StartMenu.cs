using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu
{
    public class StartMenu
    {
        public EggplantElement ContactsApp = new EggplantElement(By.Image("MC659B/AppIcons/ContactsApp"));
        public EggplantElement CalendarApp = new EggplantElement(By.Image("MC659B/AppIcons/CalendarApp"));
        public EggplantElement AlarmsApp = new EggplantElement(By.Image("MC659B/AppIcons/AlarmsApp"));
        public EggplantElement TasksApp = new EggplantElement(By.Image("MC659B/AppIcons/TasksApp"));
        
    }
}
