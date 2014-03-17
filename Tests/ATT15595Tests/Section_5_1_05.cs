using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Section 5.1.5")]
    [Category("Browser Stability Tests")]
    public class Section_5_1_05 : EggplantTestBase
    {
        //[Test]
        //[Description("2G Open Native Browser and go to AT&T Homepage - Test 5.1.5.1A")]
        //[Category("Single Device")]
        //public void TestOpenTwoGNativeBrowserGoToATTHomepage()
        //{

        //}

        [Test]
        [Description("3G Open Native Browser and go to AT&T Homepage - Test 5.1.5.1B")]
        [Category("Single Device")]
        public void TestOpenThreeGNativeBrowserGoToATTHomepage()
        {
            ConnectToHost1();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            Command.NavigateTheMenu().SetCellularConnectionToThreeG();
        }

        //[Test]
        //[Description("2G Open Native Browser and Click on a Link - Test 5.1.5.2A")]
        //[Category("Single Device")]
        //public void TestOpenTwoGNativeBrowserClickOnLink()
        //{

        //}

        [Test]
        [Description("3G Open Native Browser and Click on a Link - Test 5.1.5.2B")]
        [Category("Single Device")]
        public void TestOpenThreeGNativeBrowserClickOnLink()
        {

        }

        //[Test]
        //[Description("2G Open Native Browser and go to Top Websites - Test 5.1.5.3A")]
        //[Category("Single Device")]
        //public void TestOpenTwoGNativeBrowserGoToTopWebsites()
        //{

        //}

        [Test]
        [Description("3G Open Native Browser and go to Top Websites - Test 5.1.5.3B")]
        [Category("Single Device")]
        public void TestOpenThreeGNativeBrowserGoToTopWebsites()
        {

        }

        //[Test]
        //[Description("Start the Seasame client and load Seasame Homepage - Test 5.1.5.4")]
        //[Category("Single Device")]
        //public void TestOpenSeasameClientLoadSeasameHomepage()
        //{

        //}

        //[Test]
        //[Description("Start the Seasame client and Click on a Link - Test 5.1.5.5")]
        //[Category("Single Device")]
        //public void TestOpenSeasameClientClickLink()
        //{

        //}

    }
}
