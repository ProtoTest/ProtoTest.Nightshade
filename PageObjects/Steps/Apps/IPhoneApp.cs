

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IPhoneApp
    {
        IPhoneApp VerifyElements();
        IPhoneApp UseDialpadToCallContactNumber(string handle);
        IPhoneApp CallMostRecentContactFromHistory();
        IPhoneApp AnswerPhoneCall();
        IPhoneApp VerifyCallEstablished();
        IPhoneApp EndPhoneCall();
        IPhoneApp ExitApp();

    }
}
