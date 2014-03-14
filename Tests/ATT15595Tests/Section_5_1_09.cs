using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.9")]
    [Category("Multi-tasking Stability Tests")]
    public class Section_5_1_09 : EggplantTestBase
    {
        [Test]
        [Description("Start a Phone Call, Switch to other Running Apps, End Call - Tests 5.1.9.1, 5.1.9.2, and 5.1.9.3")]
        [Category("Paired Device")]
        public void TestStartPhoneCallSwitchToOtherAppsEndCall()
        {

        }

        [Test]
        [Description("Open the Browser, Switch to other Running Apps, Close Browser - Tests 5.1.9.4, 5.1.9.5, and 5.1.9.6")]
        [Category("Single Device")]
        public void TestStartBrowserCallSwitchToOtherAppsCloseBrowser()
        {

        }

    }
}
