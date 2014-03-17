using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_TasksApp : ITasksApp
    {
        public EggplantElement TasksAppHeader = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TasksAppHeader"));
        public EggplantElement NewTask = new EggplantElement(By.Image("MC659B/Apps/TasksApp/NewTask"));
        public EggplantElement TasksTaskHeader = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TasksTaskHeader"));
        public EggplantElement TaskSubjectField = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskSubjectField"));
        public EggplantElement TaskTitleText = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskTitleText"));
        public EggplantElement TaskHeaderText = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskHeaderText"));
        public EggplantElement TaskDelete = new EggplantElement(By.Image("MC659B/Apps/TasksApp/TaskDelete"));

        public ITasksApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Tasks app elements.");
            TasksAppHeader.VerifyPresent();
            TasksTaskHeader.VerifyPresent();
            return this;
        }

        public ITasksApp SetUpTasksApp()
        {
            EggplantTestBase.Log("Confirming Tasks app is configured correctly.");
            while (TaskHeaderText.IsPresent())
            {
                EggplantTestBase.Log("Previous task detected.  Deleting...");
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                TaskDelete.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
            }
            TaskHeaderText.VerifyNotPresent();
            EggplantTestBase.Log("Calendar app is ready for testing.");
            return this;
        }

        public ITasksApp CreateTask()
        {
            EggplantTestBase.Log("Creating task #1.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            NewTask.Click();
            TaskSubjectField.Type("TASK 1");
            startBar.OKButton.Click();
            TaskTitleText.VerifyPresent();
            TaskTitleText.LogText();
            TaskTitleText.Click();
            TaskHeaderText.VerifyPresent();
            TaskHeaderText.LogText();
            startBar.TaskEditButton.VerifyPresent();
            EggplantTestBase.Log("Task created.");
            startBar.OKButton.Click();
            return this;
        }

        public ITasksApp DeleteAllTasks()
        {
            EggplantTestBase.Log("Deleting all tasks.");
            while (TaskHeaderText.IsPresent())
            {
                EggplantTestBase.Log("Task detected.  Deleting...");
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                TaskDelete.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
            }
            TaskHeaderText.VerifyNotPresent();
            EggplantTestBase.Log("All tasks cleared.");
            return this;
            
        }

        public ITasksApp ExitApp()
        {
            EggplantTestBase.Log("Exiting Tasks app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
