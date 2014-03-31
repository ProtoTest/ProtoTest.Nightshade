

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IEmailApp
    {
        IEmailApp VerifyElements();
        IEmailApp ResetEmailAppToDefault();
        IEmailApp SendEmailWithNoAttachment(string contactFirst);
        IEmailApp SendEmailWithAnAttachment(string contactFirst);
        IEmailApp VerifyEmailArrived();
        IEmailApp ExitApp();
    }
}
