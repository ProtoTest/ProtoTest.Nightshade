

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface ITasksApp
    {
        ITasksApp VerifyElements();
        ITasksApp SetUpTasksApp();
        ITasksApp CreateTask();
        ITasksApp DeleteAllTasks();
        ITasksApp ExitApp();
    }
}
