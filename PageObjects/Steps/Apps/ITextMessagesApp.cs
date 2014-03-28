

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface ITextMessagesApp
    {
        ITextMessagesApp VerifyElements();
        ITextMessagesApp ResetTextMessagesAppToDefault();
        ITextMessagesApp SendSMSWithMaxCharacters(string contactFirst);
        ITextMessagesApp ExitApp();

    }
}
