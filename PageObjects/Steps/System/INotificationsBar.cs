

namespace ProtoTest.Nightshade.PageObjects.Steps.System
{
    public interface INotificationsBar
    {
        INotificationsBar VerifyElements();
        INotificationsBar OpenRunningProgramsMenu();
        INotificationsBar ClickOnMenuOKButton();

        INotificationsBar SelectAlarmsMenuOption();
        INotificationsBar VerifyAlarm1On();
        INotificationsBar VerifyAlarm1Off();

        INotificationsBar SelectPowerAndRadioMenuOption();
        INotificationsBar ResetNFCRadioToDefault();
        INotificationsBar SetNFCRadioToOn();
        INotificationsBar VerifyNFCOn();
        INotificationsBar SetNFCRadioToOff();
        INotificationsBar VerifyNFCOff();
        INotificationsBar ResetWifiRadioToDefault();
        INotificationsBar SetWifiRadioToOn();
        INotificationsBar VerifyWifiOn();
        INotificationsBar SetWifiRadioToOff();
        INotificationsBar VerifyWifiOff();

        INotificationsBar SelectWifiManagerOption();
    }
}