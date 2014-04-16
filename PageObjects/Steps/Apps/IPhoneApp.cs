

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IPhoneApp
    {
        IPhoneApp VerifyElements();
        IPhoneApp UseDialpadToCallContactNumber(string handle);
        IPhoneApp CallTestContact(int contactNum);
        IPhoneApp CallMostRecentContactFromHistory();
        IPhoneApp AnswerPhoneCall();
        IPhoneApp VerifyCallEstablished();
        IPhoneApp EndPhoneCall();
        IPhoneApp ExitApp();

    }
}
