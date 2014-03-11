using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.System;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC659B.Apps
{
    public class Windows_MC659B_CalendarApp 
    {
        public EggplantElement CalendarAppHeader = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppHeader"));
        public EggplantElement CalendarLeftArrow = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarLeftArrow"));
        public EggplantElement CalendarRightArrow = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarRightArrow"));
        public EggplantElement CalendarCurrentDate = new EggplantElement(By.Image("MC659B/Apps/Calendar/AlarmCheckboxOn"));
        public EggplantElement CalendarGoToToday = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarGoToToday"));

        public EggplantElement CalendarNewAppointment = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarNewAppointment"));
        public EggplantElement CalendarAppointmentSubjectField = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentSubjectField"));
        public EggplantElement CalendarAppointmentLocationField = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentLocationField"));
        public EggplantElement CalendarAppointmentEndsText = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentEndsText"));
        public EggplantElement CalendarAppointmentStartText = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointmentStartText"));

        public EggplantElement CalendarAppointment1 = new EggplantElement(By.Image("MC659B/Apps/Calendar/CalendarAppointment1"));
        public Windows_MC659B_StartBar bar = new Windows_MC659B_StartBar();

        public Windows_MC659B_CalendarApp VerifyElements()
        {
            
            EggplantTestBase.Log("Verifying Calendar app elements.");
            CalendarAppHeader.VerifyPresent();
            CalendarGoToToday.VerifyPresent();
            return this;
        }

        public Windows_MC659B_CalendarApp VerifyElements()
        {

            EggplantTestBase.Log("Verifying Calendar app elements.");
            CalendarAppHeader.VerifyPresent();
            CalendarGoToToday.VerifyPresent();
            return this;
        }

    }
}
