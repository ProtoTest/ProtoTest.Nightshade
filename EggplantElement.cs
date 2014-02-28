using System;
using System.Drawing;
using System.Threading;
using Gallio.Model;
using MbUnit.Framework;
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
            {return EggplantTestBase.Driver; }
            set { EggplantTestBase.Driver = value; }
        }

        public bool IsPresent()
        {
            return Driver.IsPresent(locator);
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
            var now = DateTime.Now;
            var endTime = DateTime.Now.AddSeconds(Config.ElementWaitSec);
            while(now<endTime)
            {
                if (Driver.IsPresent(locator))
                {
                    return this;
                }
                else
                {
                    now = DateTime.Now;
                }
            }
            throw new Exception(string.Format("Element was not present after {0} seconds", Config.ElementWaitSec));

        }



        public EggplantElement WaitForNotPresent()
        {
            var timer = Config.ElementSearchTime * 1000;
            for (var i = 0; i < Config.ElementWaitSec * 1000; i = i + timer)
            {
                if (!Driver.IsPresent(locator))
                {
                    return this;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            throw new Exception(string.Format("Element was still present after {0} seconds", Config.ElementWaitSec));

        }
    }
}