using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System
{
    public class StartBar
    {
        public EggplantElement StartButton = new EggplantElement(By.Image("MC659B/System/StartBar/StartButton"));
        public EggplantElement ExitButton = new EggplantElement(By.Image("MC659B/System/StartBar/ExitButton"));
    }
}
