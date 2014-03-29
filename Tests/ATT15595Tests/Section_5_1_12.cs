using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.12")]
    [Category("NFC Stability Tests")]
    
    public class Section_5_1_12 : EggplantTestBase
    {
        [Test]
        [Description("Turn the NFC Radio Off and On - Test 5.1.12.1")]
        [Category("Single Device")]
        [Repeat(1)]
        public void TestTurnNFCRadioOnAndOff()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreenScreen().ResetNFCRadioToDefault();
            Command.OnHomeScreenScreen().TurnOnNFC();
            Command.OnHomeScreenScreen().VerifyNFCOn();
            Command.OnHomeScreenScreen().TurnOffNFC();
            Command.OnHomeScreenScreen().VerifyNFCOff();
            Command.OnHomeScreenScreen().ResetNFCRadioToDefault();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
        }

    }
}
