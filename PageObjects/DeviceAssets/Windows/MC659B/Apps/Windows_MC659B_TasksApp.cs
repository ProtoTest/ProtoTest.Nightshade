using System.Threading;
using Gallio.Common.Concurrency;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_TasksApp : ITasksApp
    {
        public EggplantElement TasksAppHeader = new EggplantElement(By.Image("MC659B/Apps/Tasks/TasksAppHeader"));
        public EggplantElement TapHereToAddANewTaskField = new EggplantElement(By.Image("MC659B/Apps/Tasks/TapHereToAddANewTaskField"));
        public EggplantElement NewTask = new EggplantElement(By.Image("MC659B/Apps/Tasks/NewTask"));
        public EggplantElement TasksTaskHeader = new EggplantElement(By.Image("MC659B/Apps/Tasks/TasksTaskHeader"));
        public EggplantElement TaskSubjectField = new EggplantElement(By.Image("MC659B/Apps/Tasks/TaskSubjectField"));
        public EggplantElement TaskTitleText = new EggplantElement(By.Image("MC659B/Apps/Tasks/TaskTitleText"));
        public EggplantElement TaskHeaderText = new EggplantElement(By.Image("MC659B/Apps/Tasks/TaskHeaderText"));
        public EggplantElement TaskDelete = new EggplantElement(By.Image("MC659B/Apps/Tasks/TaskDelete"));

        public ITasksApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Tasks app elements.");
            TasksAppHeader.WaitForPresent();
            TapHereToAddANewTaskField.WaitForPresent();
            return this;
        }

        public ITasksApp SetUpTasksApp()
        {
            EggplantTestBase.Log("Confirming Tasks app is configured correctly.");
            while (TaskTitleText.IsPresent())
            {
                EggplantTestBase.Log("Previous task detected.  Deleting...");
                TaskTitleText.Click();
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                TaskDelete.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
            }
            TaskTitleText.WaitForNotPresent();
            EggplantTestBase.Log("Calendar app is ready for testing.");
            return this;
        }

        public ITasksApp CreateTask()
        {
            EggplantTestBase.Log("Creating task #1.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.MenuButton.Click();
            NewTask.Click();
            Thread.Sleep(2000);
            TaskSubjectField.Type("TASK1");
            startBar.OKButton.Click();
            EggplantTestBase.Log("Task created.  Verifying...");
            //TaskTitleText.LogText();
            TaskTitleText.Click();
            TaskHeaderText.WaitForPresent();
            //TaskHeaderText.LogText();
            startBar.TaskEditButton.WaitForPresent();
            EggplantTestBase.Log("Task verified.");
            startBar.OKButton.Click();
            return this;
        }

        public ITasksApp DeleteAllTasks()
        {
            EggplantTestBase.Log("Deleting all tasks.");
            while (TaskTitleText.IsPresent())
            {
                EggplantTestBase.Log("Task detected.  Deleting...");
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                TaskDelete.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
            }
            TaskTitleText.WaitForNotPresent();
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
