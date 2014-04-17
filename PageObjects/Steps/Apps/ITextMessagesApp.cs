

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface ITextMessagesApp
    {
        ITextMessagesApp VerifyElements();
        ITextMessagesApp ResetTextMessagesAppToDefault();
        ITextMessagesApp SendSMSWithMaxCharacters(string contactFirst);
        ITextMessagesApp OpenReceivedSMSWithMaxCharacters();
        ITextMessagesApp SendMMSWithAudioAttachment(string contactFirst);
        ITextMessagesApp SendMMSWithImageAttachment(string contactFirst);
        ITextMessagesApp SendMMSWithVideoAttachment(string contactFirst);
        ITextMessagesApp OpenReceivedMMSWithAttachment();
        ITextMessagesApp VerifySMSReceived();
        ITextMessagesApp VerifyMMSReceived();
        ITextMessagesApp ExitApp();

    }
}
