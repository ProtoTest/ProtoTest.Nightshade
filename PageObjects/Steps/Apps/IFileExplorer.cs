

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IFileExplorer
    {
        IFileExplorer VerifyElements();
        IFileExplorer IterativelyOpenAudioFiles(int iterationsMax);
        IFileExplorer ExitApp();

    }
}
