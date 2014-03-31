

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IFileExplorer
    {
        IFileExplorer VerifyElements();
        IMediaPlayerApp IterativelyOpenAudioFiles(int iterationsMax);
        IFileExplorer ExitApp();

    }
}
