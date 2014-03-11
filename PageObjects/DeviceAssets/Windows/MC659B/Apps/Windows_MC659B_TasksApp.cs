using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_TasksApp
    {
        public EggplantElement TasksAppHeader = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TasksAppHeader"));
        public EggplantElement NewTask = new EggplantElement(By.Image("MC659B/Apps/TasksApp/NewTask"));
        public EggplantElement TasksTaskHeader = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TasksTaskHeader"));
        public EggplantElement TaskSubjectField = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskSubjectField"));
        public EggplantElement TaskTitleText = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskTitleText"));
        public EggplantElement TaskHeaderText = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskHeaderText"));
        public EggplantElement TaskDelete = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskDelete"));

    }
}
