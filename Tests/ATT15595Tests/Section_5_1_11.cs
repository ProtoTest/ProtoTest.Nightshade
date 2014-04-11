using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.11")]
    [Category("Wifi Stability Tests")]

    public class Section_5_1_11 : EggplantTestBase
    {
        [Test]
        [Description("Turn the Wifi Radio Off and On - Test 5.1.11.1")]
        [Category("Single Device")]
        [RepeatForConfigValue("TestTurnWifiRadioOffandOn#")]
        public void TestTurnWifiRadioOffandOn()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreen().TurnOnWifi();
            Command.OnHomeScreen().VerifyWifiOn();
            Command.OnHomeScreen().TurnOffWifi();
            Command.OnHomeScreen().VerifyWifiOff();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreen().ConfirmHomeScreen();
        }

        [Test]
        [Description("Connect and Disconnect to a Wifi Network - Test 5.1.11.2")]
        [Category("Single Device")]
        [RepeatForConfigValue("TestConnectAndDisconnectToAWifiNetwork#")]
        public void TestConnectAndDisconnectToAWifiNetwork()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
            Command.OnHomeScreen().TurnOnWifi();
            Command.OnHomeScreen().DisconnectFromDefaultWifiNetwork();
            Command.OnHomeScreen().ConnectToDefaultWifiNetwork();
            Command.OnHomeScreen().DisconnectFromDefaultWifiNetwork();
            Command.OnHomeScreen().ConnectToDefaultWifiNetwork();
            Command.OnHomeScreen().ResetWifiRadioToDefault();
        }

    }
}
