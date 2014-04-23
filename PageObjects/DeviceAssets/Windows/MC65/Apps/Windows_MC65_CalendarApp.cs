using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_CalendarApp : ICalendarApp
    {
        public EggplantElement CalendarAppHeader = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarAppHeader"));
        public EggplantElement CalendarLeftArrow = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarLeftArrow"));
        public EggplantElement CalendarRightArrow = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarRightArrow"));
        public EggplantElement CalendarCurrentDate = new EggplantElement(By.Image("MC65/Apps/Calendar/AlarmCheckboxOn"));
        public EggplantElement CalendarGoToToday = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarGoToToday"));

        public EggplantElement CalendarNewAppointment = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarNewAppointment"));
        public EggplantElement CalendarDeleteAppointment = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarDeleteAppointment"));

        public EggplantElement CalendarAppointmentSubjectField = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarAppointmentSubjectField"));
        public EggplantElement CalendarAppointmentLocationField = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarAppointmentLocationField"));
        public EggplantElement CalendarAppointmentEndsText = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarAppointmentEndsText"));
        public EggplantElement CalendarAppointmentStartText = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarAppointmentStartText"));

        public EggplantElement CalendarAppointmentSelected = new EggplantElement(By.Image("MC65/Apps/Calendar/CalendarAppointmentSelected"));

        public ICalendarApp VerifyElements()
        {
            EggplantTestBase.Info("Verifying Calendar app elements.");
            CalendarAppHeader.WaitForPresent();
            CalendarGoToToday.WaitForPresent();
            return this;
        }

        public ICalendarApp SetUpCalendarApp()
        {
            EggplantTestBase.Info("Confirming Calendar app is configured correctly.");

            CalendarGoToToday.Click();
            while (CalendarAppointmentSelected.IsPresent())
            {
                EggplantTestBase.Info("Previous appointment detected.  Deleting...");
                var startBar = new Windows_MC65_StartBar();
                startBar.MenuButton.Click();
                CalendarDeleteAppointment.Click();
                var popup = new Windows_MC65_Popups();
                popup.ClickYes();
            }
            CalendarAppointmentSelected.WaitForNotPresent();

            int iterationsMax = Config.CalendarAppointmentsIterations;
            for (int currentIteration = 1; currentIteration < iterationsMax; currentIteration++)
            {
                CalendarRightArrow.Click();
                while (CalendarAppointmentSelected.IsPresent())
                {
                    EggplantTestBase.Info("Previous appointment detected.  Deleting...");
                    var startBar = new Windows_MC65_StartBar();
                    startBar.MenuButton.Click();
                    CalendarDeleteAppointment.Click();
                    var popup = new Windows_MC65_Popups();
                    popup.ClickYes();
                }
                CalendarAppointmentSelected.WaitForNotPresent();
            }
            CalendarGoToToday.Click();
            EggplantTestBase.Info("Calendar app is ready for testing.");
            return this;
        }

        public ICalendarApp SetCalendarAppointments(int iterationsMax)
        {
            var startBar = new Windows_MC65_StartBar();
            
            EggplantTestBase.Info("Setting appointment #1.");
            CalendarGoToToday.Click();
            startBar.MenuButton.Click();
            CalendarNewAppointment.Click();
            CalendarAppointmentSubjectField.Type("Appt_1");
            CalendarAppointmentLocationField.Type("Conference_Room");
            startBar.OKButton.Click();
            CalendarAppointmentSelected.WaitForPresent();
            EggplantTestBase.Info("Appointment #1 set.");
            
            //int iterationsMax = Config.CalendarAppointmentsIterations;
            for (int currentIteration = 2; currentIteration <= iterationsMax; currentIteration++)
            {
                EggplantTestBase.Info("Setting appointment #" + currentIteration + ".");
                CalendarRightArrow.Click();
                Thread.Sleep(2000);
                startBar.MenuButton.Click();
                CalendarNewAppointment.Click();
                CalendarAppointmentSubjectField.Type("Appt_" + currentIteration);
                CalendarAppointmentLocationField.Type("Conference_Room");
                startBar.OKButton.Click();
                CalendarAppointmentSelected.WaitForPresent();
                EggplantTestBase.Info("Appointment #" + currentIteration + " set.");
            }
            CalendarGoToToday.Click();
            EggplantTestBase.Info("Calendar appointments set.");
            return this;
        }

        public ICalendarApp DeleteCalendarAppointments()
        {
            EggplantTestBase.Info("Deleting previously set appointments.");
            CalendarGoToToday.Click();
            while (CalendarAppointmentSelected.IsPresent())
            {
                EggplantTestBase.Info("Previous appointment detected.  Deleting...");
                var startBar = new Windows_MC65_StartBar();
                startBar.MenuButton.Click();
                CalendarDeleteAppointment.Click();
                var popup = new Windows_MC65_Popups();
                popup.ClickYes();
            }
            CalendarAppointmentSelected.WaitForNotPresent();
            int iterationsMax = Config.CalendarAppointmentsIterations;
            for (int currentIteration = 1; currentIteration <= iterationsMax; currentIteration++)
            {
                CalendarRightArrow.Click();
                while (CalendarAppointmentSelected.IsPresent())
                {
                    EggplantTestBase.Info("Previous appointment detected.  Deleting...");
                    var startBar = new Windows_MC65_StartBar();
                    startBar.MenuButton.Click();
                    CalendarDeleteAppointment.Click();
                    var popup = new Windows_MC65_Popups();
                    popup.ClickYes();
                }
                CalendarAppointmentSelected.WaitForNotPresent();
            }
            CalendarGoToToday.Click();
            EggplantTestBase.Info("Previous appointments deleted.");
            return this;
        }

        public ICalendarApp ExitApp()
        {
            EggplantTestBase.Info("Exiting Calendar app.");
            var startBar = new Windows_MC65_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
