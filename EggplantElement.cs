using System.Drawing;
using System.Threading;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantElement
    {
        public string locator;

        public EggplantElement(By by)
        {
            locator = by.ToString();
        }

        public static EggplantDriver Driver
        {
            get
            {
                Thread.Sleep(Config.DelayTimeMs); 
                return EggplantTestBase.Driver; }
            set { EggplantTestBase.Driver = value; }
        }

        public EggplantElement Click()
        {
            Driver.Click(locator);
            return this;
        }

        public EggplantElement Type(string text)
        {
            Click();
            Driver.Type(text);
            return this;
        }

        public EggplantElement WaitForPresent()
        {
            Driver.WaitFor(locator);
            return this;
        }

        public void WaitForNotPresent()
        {
        }
    }
}