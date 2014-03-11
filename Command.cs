using System;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Menu;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.Nightshade.PageObjects.Steps.Menu;
using ProtoTest.Nightshade.PageObjects.Steps.System;

namespace ProtoTest.Nightshade
{
    public static class Command
    {

        public static IHomeScreen SetUpTest()
        {
            if (Config.DeviceType == "null")
            {
                throw new Exception("You must have a device type.");
            }

            else if (Config.DeviceType.Contains("Windows"))
            {
                if (Config.DeviceType.Contains("MC659B"))
                {
                    return new Windows_MC659B_HomeDesktop();
                }
                //else if()
                else
                {
                    throw new Exception("Unknown windows device.  Check type formatting or add new device assets.");
                }

            }

            else if (Config.DeviceType.Contains("Android"))
            {
                if (Config.DeviceType.Contains("Shelter"))
                {
                    return new Windows_MC659B_HomeDesktop();
                }
                //else if()
                else
                {
                    throw new Exception("Unknown android device.  Check type formatting or add new device assets.");
                }
            }
            throw new Exception("Unknown device type.  Check type formatting or add new device assets.");
            
        }
        
        public static IMenuNav Execute()
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
                return new Windows_MC659B_MenuNav();
            }
            else
            {
                throw new Exception("Unknown device type.  Check type formatting or add new device assets.");
            }
        }
    }
}