using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_AlarmsApp : IAlarmsApp
    {
        public EggplantElement AlarmsAppHeader = new EggplantElement(By.Image("MC65/Apps/Alarms/AlarmsAppHeader"));
        public EggplantElement AlarmsSectionHeader = new EggplantElement(By.Image("MC65/Apps/Alarms/AlarmsAlarmsHeader"));
        public EggplantElement Alarm1Checkbox = new EggplantElement(By.Image("MC65/Apps/Alarms/Alarm1Checkbox"));
        public EggplantElement AlarmCheckboxOff = new EggplantElement(By.Image("MC65/Apps/Alarms/AlarmCheckboxOff"));
        public EggplantElement AlarmCheckboxOn = new EggplantElement(By.Image("MC65/Apps/Alarms/AlarmCheckboxOn"));
        public EggplantElement AlarmTime = new EggplantElement(By.Image("MC65/Apps/Alarms/AlarmTime"));
        public EggplantElement AlarmPropertiesDefault = new EggplantElement(By.Image("MC65/Apps/Alarms/AlarmPropertiesDefault"));

        public IAlarmsApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Alarm app elements.");
            AlarmsAppHeader.WaitForPresent();
            AlarmsSectionHeader.WaitForPresent();
            return this;
        }

        public IAlarmsApp SetUpAlarmsApp()
        {
            EggplantTestBase.Info("Confirming Alarms app is configured correctly.");
            while (AlarmCheckboxOn.IsPresent())
            {
                EggplantTestBase.Info("Previous alarm detected.  Disabling alarm...");
                AlarmCheckboxOn.Click();
                Thread.Sleep(1000);
            }
            AlarmCheckboxOn.WaitForNotPresent();
            EggplantTestBase.Info("Alarms app is ready for testing.");
            return this;
        }

        public IAlarmsApp SetAlarm1()
        {
            EggplantTestBase.Info("Setting alarm #1.");
            Alarm1Checkbox.Click();
            //AlarmTime.LogText();
            AlarmPropertiesDefault.WaitForPresent();
            AlarmCheckboxOn.WaitForPresent();
            return this;
        }

        public IAlarmsApp ConfirmAlarm1()
        {
            EggplantTestBase.Info("Confirming alarm #1 is set.");
            AlarmCheckboxOn.WaitForPresent();
            ExitApp();
            return this;
        }

        public IAlarmsApp TurnOffAllAlarms()
        {
            EggplantTestBase.Info("Turning off all alarms.");
            while (AlarmCheckboxOn.IsPresent())
            {
                AlarmCheckboxOn.Click();
            }
            AlarmCheckboxOn.WaitForNotPresent();
            return this;
        }

        public IAlarmsApp ExitApp()
        {
            EggplantTestBase.Info("Exiting alarms app.");
            var startBar = new Windows_MC65_StartBar();
            startBar.OKButton.Click();
            Thread.Sleep(2000);
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
