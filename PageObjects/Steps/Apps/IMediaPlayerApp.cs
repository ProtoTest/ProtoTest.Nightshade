

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IMediaPlayerApp
    {
        IMediaPlayerApp VerifyElements();
        IMediaPlayerApp VerifyFilePlaying();
        IMediaPlayerApp PauseFile();
        IMediaPlayerApp RemoveFileFromActiveStatus();
        IMediaPlayerApp ExitApp();

    }
}
