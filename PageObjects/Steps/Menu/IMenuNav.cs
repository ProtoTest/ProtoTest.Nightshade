using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.Steps.Menu
{
    public interface IMenuNav
    {
        INetworkSettings SetCellularConnectionToTwoG();
        INetworkSettings SetCellularConnectionToThreeG();

        IAlarmsApp GoToAlarmsApp();
        IBrowserApp GoToBrowserApp();
        ICalendarApp GoToCalendarApp();
        IContactsApp GoToContactsApp();
        IFileExplorer GoToAudioFiles();
        IPicturesAndVideoApp GoToPicturesAndVideoApp();
        IMediaPlayerApp GoToMediaPlayerApp();
        ITasksApp GoToTasksApp();
    }
  
}
