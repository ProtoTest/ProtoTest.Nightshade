using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_CalendarApp : ICalendarApp
    {
        public EggplantElement CalendarAppHeader = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppHeader"));
        public EggplantElement CalendarLeftArrow = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarLeftArrow"));
        public EggplantElement CalendarRightArrow = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarRightArrow"));
        public EggplantElement CalendarCurrentDate = new EggplantElement(By.Image("MC659B/Apps/Calendar/AlarmCheckboxOn"));
        public EggplantElement CalendarGoToToday = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarGoToToday"));

        public EggplantElement CalendarNewAppointment = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarNewAppointment"));
        public EggplantElement CalendarDeleteAppointment = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarDeleteAppointment"));

        public EggplantElement CalendarAppointmentSubjectField = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentSubjectField"));
        public EggplantElement CalendarAppointmentLocationField = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentLocationField"));
        public EggplantElement CalendarAppointmentEndsText = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentEndsText"));
        public EggplantElement CalendarAppointmentStartText = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentStartText"));

        public EggplantElement CalendarAppointmentSelected = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentSelected"));

        public ICalendarApp VerifyElements()
        {
            EggplantTestBase.Note("Verifying Calendar app elements.");
            CalendarAppHeader.WaitForPresent();
            CalendarGoToToday.WaitForPresent();
            return this;
        }

        public ICalendarApp SetUpCalendarApp()
        {
            EggplantTestBase.Note("Confirming Calendar app is configured correctly.");

            CalendarGoToToday.Click();
            while (CalendarAppointmentSelected.IsPresent())
            {
                EggplantTestBase.Note("Previous appointment detected.  Deleting...");
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                CalendarDeleteAppointment.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
            }
            CalendarAppointmentSelected.WaitForNotPresent();

            int iterationsMax = Config.CalendarAppointmentsIterations;
            for (int currentIteration = 1; currentIteration < iterationsMax; currentIteration++)
            {
                CalendarRightArrow.Click();
                while (CalendarAppointmentSelected.IsPresent())
                {
                    EggplantTestBase.Note("Previous appointment detected.  Deleting...");
                    var startBar = new Windows_MC659B_StartBar();
                    startBar.MenuButton.Click();
                    CalendarDeleteAppointment.Click();
                    var popup = new Windows_MC659B_Popups();
                    popup.ClickYes();
                }
                CalendarAppointmentSelected.WaitForNotPresent();
            }
            CalendarGoToToday.Click();
            EggplantTestBase.Note("Calendar app is ready for testing.");
            return this;
        }

        public ICalendarApp SetCalendarAppointments(int iterationsMax)
        {
            var startBar = new Windows_MC659B_StartBar();
            
            EggplantTestBase.Note("Setting appointment #1.");
            CalendarGoToToday.Click();
            startBar.MenuButton.Click();
            CalendarNewAppointment.Click();
            CalendarAppointmentSubjectField.Type("Appt_1");
            CalendarAppointmentLocationField.Type("Conference_Room");
            startBar.OKButton.Click();
            CalendarAppointmentSelected.WaitForPresent();
            EggplantTestBase.Note("Appointment #1 set.");
            
            //int iterationsMax = Config.CalendarAppointmentsIterations;
            for (int currentIteration = 2; currentIteration <= iterationsMax; currentIteration++)
            {
                EggplantTestBase.Note("Setting appointment #" + currentIteration + ".");
                CalendarRightArrow.Click();
                Thread.Sleep(2000);
                startBar.MenuButton.Click();
                CalendarNewAppointment.Click();
                CalendarAppointmentSubjectField.Type("Appt_" + currentIteration);
                CalendarAppointmentLocationField.Type("Conference_Room");
                startBar.OKButton.Click();
                CalendarAppointmentSelected.WaitForPresent();
                EggplantTestBase.Note("Appointment #" + currentIteration + " set.");
            }
            CalendarGoToToday.Click();
            EggplantTestBase.Note("Calendar appointments set.");
            return this;
        }

        public ICalendarApp DeleteCalendarAppointments()
        {
            EggplantTestBase.Note("Deleting previously set appointments.");
            CalendarGoToToday.Click();
            while (CalendarAppointmentSelected.IsPresent())
            {
                EggplantTestBase.Note("Previous appointment detected.  Deleting...");
                var startBar = new Windows_MC659B_StartBar();
                startBar.MenuButton.Click();
                CalendarDeleteAppointment.Click();
                var popup = new Windows_MC659B_Popups();
                popup.ClickYes();
            }
            CalendarAppointmentSelected.WaitForNotPresent();
            int iterationsMax = Config.CalendarAppointmentsIterations;
            for (int currentIteration = 1; currentIteration <= iterationsMax; currentIteration++)
            {
                CalendarRightArrow.Click();
                while (CalendarAppointmentSelected.IsPresent())
                {
                    EggplantTestBase.Note("Previous appointment detected.  Deleting...");
                    var startBar = new Windows_MC659B_StartBar();
                    startBar.MenuButton.Click();
                    CalendarDeleteAppointment.Click();
                    var popup = new Windows_MC659B_Popups();
                    popup.ClickYes();
                }
                CalendarAppointmentSelected.WaitForNotPresent();
            }
            CalendarGoToToday.Click();
            EggplantTestBase.Note("Previous appointments deleted.");
            return this;
        }

        public ICalendarApp ExitApp()
        {
            EggplantTestBase.Note("Exiting Calendar app.");
            var startBar = new Windows_MC659B_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
