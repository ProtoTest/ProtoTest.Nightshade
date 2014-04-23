using System.Threading;
using Gallio.Common.Concurrency;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_TasksApp : ITasksApp
    {
        public EggplantElement TasksAppHeader = new EggplantElement(By.Image("MC65/Apps/Tasks/TasksAppHeader"));
        public EggplantElement TapHereToAddANewTaskField = new EggplantElement(By.Image("MC65/Apps/Tasks/TapHereToAddANewTaskField"));
        public EggplantElement NewTask = new EggplantElement(By.Image("MC65/Apps/Tasks/NewTask"));
        public EggplantElement TasksTaskHeader = new EggplantElement(By.Image("MC65/Apps/Tasks/TasksTaskHeader"));
        public EggplantElement TaskSubjectField = new EggplantElement(By.Image("MC65/Apps/Tasks/TaskSubjectField"));
        public EggplantElement TaskTitleText = new EggplantElement(By.Image("MC65/Apps/Tasks/TaskTitleText"));
        public EggplantElement TaskHeaderText = new EggplantElement(By.Image("MC65/Apps/Tasks/TaskHeaderText"));
        public EggplantElement TaskDelete = new EggplantElement(By.Image("MC65/Apps/Tasks/TaskDelete"));

        public ITasksApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Tasks app elements.");
            TasksAppHeader.WaitForPresent();
            TapHereToAddANewTaskField.WaitForPresent();
            return this;
        }

        public ITasksApp SetUpTasksApp()
        {
            EggplantTestBase.Info("Confirming Tasks app is configured correctly.");
            while (TaskTitleText.IsPresent())
            {
                EggplantTestBase.Info("Previous task detected.  Deleting...");
                TaskTitleText.Click();
                var startBar = new Windows_MC65_StartBar();
                startBar.MenuButton.Click();
                TaskDelete.Click();
                var popup = new Windows_MC65_Popups();
                popup.ClickYes();
            }
            TaskTitleText.WaitForNotPresent();
            EggplantTestBase.Info("Calendar app is ready for testing.");
            return this;
        }

        public ITasksApp CreateTask()
        {
            EggplantTestBase.Info("Creating task #1.");
            var startBar = new Windows_MC65_StartBar();
            startBar.MenuButton.Click();
            NewTask.Click();
            Thread.Sleep(2000);
            TaskSubjectField.Type("TASK1");
            startBar.OKButton.Click();
            EggplantTestBase.Info("Task created.  Verifying...");
            //TaskTitleText.LogText();
            TaskTitleText.Click();
            TaskHeaderText.WaitForPresent();
            //TaskHeaderText.LogText();
            startBar.TaskEditButton.WaitForPresent();
            EggplantTestBase.Info("Task verified.");
            startBar.OKButton.Click();
            return this;
        }

        public ITasksApp DeleteAllTasks()
        {
            EggplantTestBase.Info("Deleting all tasks.");
            while (TaskTitleText.IsPresent())
            {
                EggplantTestBase.Info("Task detected.  Deleting...");
                var startBar = new Windows_MC65_StartBar();
                startBar.MenuButton.Click();
                TaskDelete.Click();
                var popup = new Windows_MC65_Popups();
                popup.ClickYes();
            }
            TaskTitleText.WaitForNotPresent();
            EggplantTestBase.Info("All tasks cleared.");
            return this;
            
        }

        public ITasksApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Tasks app.");
            var startBar = new Windows_MC65_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
