using System;
using System.Drawing;
using System.Threading;
using Gallio.Model;
using System.Timers;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using MbUnit.Framework;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantElement
    {
        bool running;

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            running = false;
        }

        public string locator;

        //private bool elementIsPresent(string locator)
        //{
        //    Driver.(locator);
        //}

        public EggplantElement(By by)
        {
            locator = by.ToString();
        }

        public static EggplantDriver Driver
        {
            get {return EggplantTestBase.Driver; }
            set { EggplantTestBase.Driver = value; }
        }

        public bool IsPresent()
        {
            return Driver.IsPresent(locator);
        }

        public EggplantElement Click()
        {
            EggplantTestBase.Log("Clicking on element.");
            Driver.Click(locator);
            return this;
        }

        public EggplantElement Type(string text)
        {
            EggplantTestBase.Log("Typing text:(" + text + ").");
            Click();
            Driver.Type(text);
            return this;
        }

        public EggplantElement WaitForPresent()
        {
            EggplantTestBase.Log("Waiting for element to be present.");
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

        public EggplantElement VerifyPresent()
        {
            try
            {
                EggplantTestBase.Log("Verifying element should be present.");
                Driver.WaitFor(locator);
                return this;
            }
            catch
            {
                EggplantTestBase.Log("Element not detected.");
            }
            return this;
        }

        public EggplantElement VerifyNotPresent()
        {
            EggplantTestBase.Log("Verifying element must not be present.");

            if (Driver.IsPresent(locator) == null)
            {
                EggplantTestBase.Log("Element is not present.");
            }
            else
            {
                EggplantTestBase.Log("Element is erroneously present.");
                Assert.Fail();
            }
            return this;
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

        public void verifyState<E>(E state) where E : struct, IComparable, IConvertible, IFormattable
        {
            string element = state.GetType().Name;
            EggplantTestBase.Log("Verifying element(" + element + ") with state (" + state + ").");
            locator = this.locator + "/" + state;
            Driver.WaitFor(locator);
        }
    }
}