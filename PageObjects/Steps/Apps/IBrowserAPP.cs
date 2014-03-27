using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IBrowserApp
    {
        IBrowserApp VerifyElements();
        IBrowserApp ResetBrowserToDefaultState();
        IBrowserApp GoToBookmarkedWebsite();
        IBrowserApp GoToATTWebsite();
        IBrowserApp GoToYahooWebsite();
        IBrowserApp GoToFacebookWebsite();
        IBrowserApp GoToYoutubeWebsite();
        IBrowserApp GoToNYTimesWebsite();
        IHomeScreen ReturnToHomeScreen();
        IBrowserApp ExitApp();

    }
}
