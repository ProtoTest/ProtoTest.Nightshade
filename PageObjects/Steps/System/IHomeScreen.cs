

using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;

namespace ProtoTest.Nightshade.PageObjects.Steps.System
{
    public interface IHomeScreen
    {
        IHomeScreen ConfirmHomeScreen();
        IHomeScreen ChangeBackground();

        IHomeScreen ConfirmAlarm1On();
        IHomeScreen ConfirmAlarm1Off();

        INotificationsBar OpenNotificationsBar();

    }
}