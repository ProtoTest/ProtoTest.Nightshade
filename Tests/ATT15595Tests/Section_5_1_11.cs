using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.11")]
    [Category("Wifi Stability Tests")]

    public class Section_5_1_11 : EggplantTestBase
    {
        // AT&T 15595 Test Suite
        // Section 5.1.11 - Wifi Stability Tests

        [Test]
        [Description("Turn the Wifi Radio Off and On - Test 5.1.11.1")]
        [Category("Single Device")]
        public void TestTurnWifiRadioOffandOn()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            //Command.OnHomeScreenScreen().TurnOnWifi();
            //Command.OnHomeScreenScreen().VerifyWifiOn();
            //Command.OnHomeScreenScreen().TurnOffWifi();
            //Command.OnHomeScreenScreen().VerifyWifiOff();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
        }

        [Test]
        [Description("Connect and Disconnect to a Wifi Network - Test 5.1.11.2")]
        [Category("Single Device")]
        public void TestConnectAndDisconnectToAWifiNetwork()
        {

        }

    }
}
