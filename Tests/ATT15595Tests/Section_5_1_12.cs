﻿using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.12")]
    [Category("NFC Stability Tests")]
    
    public class Section_5_1_12 : EggplantTestBase
    {
        [Test]
        [Description("Turn the NFC Radio Off and On - Test 5.1.12.1")]
        [Category("Single Device")]
        [RepeatForConfigValue("TestTurnNFCRadioOnAndOff#")]
        public void TestTurnNFCRadioOnAndOff()
        {
            ConnectToHost1();
            Command.OnHomeScreen().ResetDeviceStateToDefault();
            Command.OnHomeScreen().ResetNFCRadioToDefault();
            Command.OnHomeScreen().TurnOnNFC();
            Command.OnHomeScreen().VerifyNFCOn();
            Command.OnHomeScreen().TurnOffNFC();
            Command.OnHomeScreen().VerifyNFCOff();
            Command.OnHomeScreen().ResetNFCRadioToDefault();
            Command.OnHomeScreen().ConfirmHomeScreen();
        }

    }
}
