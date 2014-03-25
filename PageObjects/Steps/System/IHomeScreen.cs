

using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;

namespace ProtoTest.Nightshade.PageObjects.Steps.System
{
    public interface IHomeScreen
    {
        IHomeScreen ConfirmHomeScreen();
        IHomeScreen ResetDeviceStateToDefault();
        IHomeScreen SetThemeToOption(string picNumber);
        IHomeScreen SetThemeToDefault();

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
        
    }
}