

using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;

namespace ProtoTest.Nightshade.PageObjects.Steps.System
{
    public interface IHomeScreen
    {
        IHomeScreen ConfirmHomeScreen();
        IHomeScreen SetThemeToOption(string picNumber);
        IHomeScreen SetThemeToDefault();

        IHomeScreen ConfirmAlarm1On();
        IHomeScreen ConfirmAlarm1Off();

        IHomeScreen TurnOnNFC();
        IHomeScreen VerifyNFCOn();
        IHomeScreen TurnOffNFC();
        IHomeScreen VerifyNFCOff();

        INotificationsBar OpenNotificationsBar();

    }
}