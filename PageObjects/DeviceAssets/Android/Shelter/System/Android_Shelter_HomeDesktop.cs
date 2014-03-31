using System;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Android.Shelter.System
{
    public class Android_Shelter_HomeDesktop : IHomeScreen
    {
        public EggplantElement HomeButton = new EggplantElement(By.Image("Shelter/System/AppsIcon").InRectangle(SearchRectangle.BottomQuarter));
        //public Windows_MC659B_StartBar startBar = new Windows_MC659B_StartBar();
        //public Windows_MC659B_NotificationsBar notificationsBar = new Windows_MC659B_NotificationsBar();

        public IHomeScreen ConfirmHomeScreen()
        {
            if (!HomeButton.IsPresent())
            {
                throw new Exception("Device is not on the home screen.");
            }
            EggplantTestBase.Log("Device is on the home screen.");
            //DefaultDesktop.WaitForPresent();
            //startBar.VerifyElements();
            //notificationsBar.VerifyElements();
            return this;
        }

        public IHomeScreen ResetDeviceStateToDefault()
        {
            EggplantTestBase.Log("Resetting device state to default.");
            HomeButton.Click();
            ConfirmHomeScreen();
            return this;
        }

        public IHomeScreen SetThemeToOption(string picNumber)
        {
            var picsApp = new Windows_MC659B_PicturesAndVideoApp();
            picsApp.SetThemeToOption(picNumber);
            return this;
        }

        public IHomeScreen SetThemeToDefault()
        {
            var picsApp = new Windows_MC659B_PicturesAndVideoApp();
            picsApp.ResetThemeToDefault();
            return this;
        }

        public IHomeScreen ReturnToHomeScreen()
        {
            throw new NotImplementedException();
        }


        public INotificationsBar OpenNotificationsBar()
        {
            var bar = new Windows_MC659B_NotificationsBar();
            bar.OpenNotificationsBarMenu();
            return new Windows_MC659B_NotificationsBar();
        }


        public IHomeScreen ConfirmAlarm1On()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1On()
                .ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen ConfirmAlarm1Off()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar()
                .SelectAlarmsMenuOption()
                .VerifyAlarm1Off()
                .ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }


        public IHomeScreen ResetNFCRadioToDefault()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetNFCRadioToDefault().ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen TurnOnNFC()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetNFCRadioToOn().ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen VerifyNFCOn()
        {
           // notificationsBar.BluetoothConnected.WaitForPresent();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen TurnOffNFC()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetNFCRadioToOff().ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen VerifyNFCOff()
        {
           // notificationsBar.BluetoothConnected.WaitForNotPresent();
            return new Android_Shelter_HomeDesktop();
        }


        public IHomeScreen ResetWifiRadioToDefault()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().ResetWifiRadioToDefault().ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen TurnOnWifi()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetWifiRadioToOn().ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen VerifyWifiOn()
        {
            Command.OnHomeScreenScreen().VerifyWifiOn();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen TurnOffWifi()
        {
            Command.OnHomeScreenScreen()
                .OpenNotificationsBar().SelectPowerAndRadioMenuOption().SetWifiRadioToOff().ClickOnMenuOKButton();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen VerifyWifiOff()
        {
            Command.OnHomeScreenScreen().VerifyWifiOff();
            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen ConnectToDefaultWifiNetwork()
        {

            return new Android_Shelter_HomeDesktop();
        }

        public IHomeScreen DisconnectFromDefaultWifiNetwork()
        {

            return new Android_Shelter_HomeDesktop();
        }

        public INetworkSettings SetCellularNetworkToTwoG()
        {
            throw new NotImplementedException();
        }

        public INetworkSettings SetCellularNetworkToThreeG()
        {
            throw new NotImplementedException();
        }

        public IPhoneApp AnswerPhoneCall()
        {
            throw new NotImplementedException();
        }

        public IPhoneApp EndPhoneCall()
        {
            throw new NotImplementedException();
        }

        public IHomeScreen VerifyCallEstablished()
        {
            throw new NotImplementedException();
        }

        public IHomeScreen VerifyTextMessageArrived()
        {
            throw new NotImplementedException();
        }

        public IHomeScreen VerifyEmailArrived()
        {
            throw new NotImplementedException();
        }
    }
}
