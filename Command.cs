using System;
using Gallio.Model.Environments;
using ProtoTest.Nightshade.PageObjects.DeviceAssets;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Android.Shelter.System;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Menu;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade
{
    public class Command
    {
        public static IHomeScreen OnHomeScreen()
        {
            if (Config.DeviceType == "null")
            {
                throw new Exception("You must have a device type.");
            }

            if (Config.DeviceType.Contains("Windows"))
            {
                if (Config.DeviceType.Contains("MC659B"))
                {
                    return new Windows_MC659B_HomeDesktop();
                }
                else
                {
                    throw new Exception("Unknown windows device.  Check type formatting or add new device assets.");
                }

            }

            if (Config.DeviceType.Contains("Android"))
            {
                if (Config.DeviceType.Contains("Shelter"))
                {
                    return new Android_Shelter_HomeDesktop();
                }
                else
                {
                    throw new Exception("Unknown android device.  Check type formatting or add new device assets.");
                }
            }
            throw new Exception("Unknown device type.  Check type formatting or add new device assets.");
            
        }

        public static IMenuNav NavigateTheMenu()
        {
            if (Config.DeviceType.Contains("Windows"))
            {
                if (Config.DeviceType.Contains("MC659B"))
                {
                    return new Windows_MC659B_MenuNav();
                }
                else
                {
                    throw new Exception("Unknown device type.  Check type formatting or add new device assets.");
                }
            }
            else if(Config.DeviceType.Contains("Android"))
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new Exception("Unknown device type.  Check type formatting or add new device assets.");
            }
        }
    }
}