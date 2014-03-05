using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;

namespace ProtoTest.Nightshade.PageObjects.Interfaces
{
    public interface IHomePage
    {
        void VerifyHomePage();
        void GotoStartMenu();
    }

    public class WindowsMC659BHomePage : IHomePage
    {

        public void VerifyHomePage()
        {
            var HomeDesktop = new HomeDesktop();
            HomeDesktop.Desktop.VerifyPresent();
        }

        public void GotoStartMenu()
        {
            var StartBar = new StartBar();
            StartBar.StartButton.Click();
        }

    }

    public class AndroidShelterHomePage : IHomePage
    {
        public void VerifyHomePage()
        {
            //Desktop.VerifyPresent();
        }
    }
}
