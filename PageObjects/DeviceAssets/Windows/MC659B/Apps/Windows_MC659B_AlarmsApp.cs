using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_AlarmsApp : IAlarmsApp
    {
        public EggplantElement AlarmsAppHeader = new EggplantElement(By.Image("MC659B/Apps/Alarms/AlarmsAppHeader"));
        public EggplantElement AlarmsSectionHeader = new EggplantElement(By.Image("MC659B/Apps/Alarms/AlarmsAlarmsHeader"));
        public EggplantElement AlarmCheckboxOff = new EggplantElement(By.Image("MC659B/Apps/Alarms/AlarmCheckboxOff"));
        public EggplantElement AlarmCheckboxOn = new EggplantElement(By.Image("MC659B/Apps/Alarms/AlarmCheckboxOn"));
        public EggplantElement AlarmTime = new EggplantElement(By.Image("MC659B/Apps/Alarms/AlarmTime"));
        public EggplantElement AlarmPropertiesDefault = new EggplantElement(By.Image("MC659B/Apps/Alarms/AlarmPropertiesDefault"));

        public IAlarmsApp VerifyElements()
        {
            EggplantTestBase.Log("Verifying Alarm app elements.");
            AlarmsAppHeader.WaitForPresent();
            AlarmsSectionHeader.WaitForPresent();
            return this;
        }

        public IAlarmsApp SetUpAlarmsApp()
        {
            EggplantTestBase.Log("Confirming Alarms app is configured correctly.");
            while (AlarmCheckboxOn.IsPresent())
            {
                EggplantTestBase.Log("Previous alarm detected.  Disabling alarm...");
                AlarmCheckboxOn.Click();
            }
            AlarmCheckboxOn.WaitForNotPresent();
            EggplantTestBase.Log("Alarms app is ready for testing.");
            return this;
        }

        public IAlarmsApp SetAlarm1()
        {
            EggplantTestBase.Log("Setting alarm #1.");
            AlarmCheckboxOff.Click();
            AlarmTime.LogText();
            AlarmPropertiesDefault.WaitForPresent();
            AlarmCheckboxOn.WaitForPresent();
            return this;
        }

        public IAlarmsApp ConfirmAlarm1()
        {
            EggplantTestBase.Log("Confirming alarm #1 is set.");
            AlarmCheckboxOn.WaitForPresent();
            ExitApp();
            return this;
        }

        public IAlarmsApp TurnOffAllAlarms()
        {
            EggplantTestBase.Log("Turning off all alarms.");
            while (AlarmCheckboxOn.IsPresent())
            {
                AlarmCheckboxOn.Click();
            }
            AlarmCheckboxOn.WaitForNotPresent();
            return this;
        }

        public IAlarmsApp ExitApp()
        {
            EggplantTestBase.Log("Exiting alarms app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreenScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
