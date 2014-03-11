using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.Steps.System
{
    public interface IHomeScreen
    {
        IHomeScreen ConfirmHomeScreen();
        IHomeScreen ChangeBackground();

    }
}