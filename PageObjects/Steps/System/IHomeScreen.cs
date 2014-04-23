using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.Steps.System
{
    public interface IHomeScreen
    {
        IHomeScreen ConfirmHomeScreen();
        IHomeScreen ResetDeviceStateToDefault();
        IHomeScreen SetThemeToOption(string picNumber);
        IHomeScreen SetThemeToDefault();
        IHomeScreen ReturnToHomeScreen();

        INotificationsBar OpenNotificationsBar();
        
        IHomeScreen ConfirmAlarm1On();
        IHomeScreen ConfirmAlarm1Off();

        IHomeScreen ResetNFCRadioToDefault();
        IHomeScreen TurnOnNFC();
        IHomeScreen VerifyNFCOn();
        IHomeScreen TurnOffNFC();
        IHomeScreen VerifyNFCOff();

        IHomeScreen ResetWifiRadioToDefault();
        IHomeScreen TurnOnWifi();
        IHomeScreen VerifyWifiOn();
        IHomeScreen TurnOffWifi();
        IHomeScreen VerifyWifiOff();
        IHomeScreen ConnectToDefaultWifiNetwork();
        IHomeScreen DisconnectFromDefaultWifiNetwork();

        INetworkSettings SetCellularNetworkToTwoG();
        INetworkSettings SetCellularNetworkToThreeG();

        IPhoneApp AnswerPhoneCall();
        IPhoneApp EndPhoneCall();
        IHomeScreen VerifyCallEstablished();

        IHomeScreen VerifyTextMessageArrived();
        IHomeScreen VerifyEmailArrived();
    }
}