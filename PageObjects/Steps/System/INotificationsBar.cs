

namespace ProtoTest.Nightshade.PageObjects.Steps.System
{
    public interface INotificationsBar
    {
        INotificationsBar VerifyElements();
        INotificationsBar OpenRunningProgramsMenu();
        INotificationsBar ClickOnMenuOKButton();
        INotificationsBar SelectAlarmsMenuOption();
        INotificationsBar SelectPowerAndRadioMenuOption();
        INotificationsBar VerifyAlarm1On();
        INotificationsBar VerifyAlarm1Off();
    }
}