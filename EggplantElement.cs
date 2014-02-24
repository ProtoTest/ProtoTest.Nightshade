using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantElement
    {
        public static EggplantDriver Driver
        {
            get { return EggplantTestBase.Driver; }
            set { EggplantTestBase.Driver = value; }
        }

        public string locator;

        public EggplantElement(string locator)
        {
            this.locator = locator;
        }

        public EggplantElement Click()
        {
            Driver.Click(locator);
            return this;
        }

        public EggplantElement Type(string text)
        {
            Driver.Type(locator,text);
            return this;
        }

        public EggplantElement WaitForPresent()
        {
            Driver.WaitFor(locator);
            return this;
        }

        public EggplantElement WaitForNotPresent()
        {
          //  Driver.WaitFor(locator);
            return this;
        }
    }
}
