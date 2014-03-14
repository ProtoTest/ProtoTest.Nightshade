using System;
using System.Drawing;
using System.Threading;
using Gallio.Framework;
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

        public EggplantElement LogText()
        {
            WaitForPresent();
            var elementText = int.Parse(Driver.ReadText(locator));
            EggplantTestBase.Log("Text at target location is (" + elementText +").");
            return this;
        }

        public EggplantElement Click()
        {
            WaitForPresent();
            EggplantTestBase.Log(string.Format("Clicking on element {0}.",locator));
            Driver.Click(locator);
            return this;
        }

        public EggplantElement Type(string text)
        {
            EggplantTestBase.Log(string.Format("Typing text:({0}).",text));
            Click();
            Driver.Type(text);
            return this;
        }

        public EggplantElement WaitForPresent()
        {
            EggplantTestBase.Log(string.Format("Waiting for element {0} to be present.",locator));
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
                    Thread.Sleep(500);
                    now = DateTime.Now;
                }
            }
            throw new Exception(string.Format("Element was not present after {0} seconds", Config.ElementWaitSec));
        }

        public EggplantElement WaitForNotPresent()
        {
            EggplantTestBase.Log(string.Format("Waiting for element {0} to not be present.", locator));
            var now = DateTime.Now;
            var endTime = DateTime.Now.AddSeconds(Config.ElementWaitSec);
            while (now < endTime)
            {
                if (!Driver.IsPresent(locator))
                {
                    return this;
                }
                else
                {
                    Thread.Sleep(500);
                    now = DateTime.Now;
                }
            }
            throw new Exception(string.Format("WaitForNotPresent Failed : Element was still present after {0} seconds", Config.ElementWaitSec));
        }

        public EggplantElement VerifyPresent()
        {
            EggplantTestBase.Log(string.Format("Verifying element {0} should be present.",locator));
            if (!Driver.IsPresent(locator))
            {
                VerificationErrors.AddVerificationError(string.Format("Verification Error : Element {0} should be present.", locator));
            }
            else
            {
                EggplantTestBase.Log(string.Format("Verification Passed : Element {0} is present.", locator));
            }
            return this;
        }

        public EggplantElement VerifyNotPresent()
        {
            EggplantTestBase.Log(string.Format("Verifying element {0} is not be present.",locator));

            if (Driver.IsPresent(locator))
            {
                VerificationErrors.AddVerificationError(string.Format("Verification Error : Element {0} should not be present.",locator));
            }
            else
            {
                EggplantTestBase.Log(string.Format("Verification Passed : Element {0} is not be present",locator));
            }
            return this;
        }

        public void WithState(Enum state)
        {
            this.locator = this.locator + "/" + state.ToString();
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