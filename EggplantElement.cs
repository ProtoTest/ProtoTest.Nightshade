using System;
using System.Drawing;
using System.IO;
using System.Threading;
using Gallio.Framework;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class EggplantElement
    {
        //private bool running;
        
        //private void timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    running = false;
        //}

        public string locator;
        private By _by;

        //private bool elementIsPresent(string locator)
        //{
        //    Driver.(locator);
        //}

        public EggplantElement(By by)
        {
            locator = by.ToString();
            _by = by;
            //by by by oh right!
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

        public string GetText()
        {
            WaitForPresent();
            EggplantTestBase.Log(string.Format("Reading text on element {0}.", locator));
            var text = Driver.ReadText(locator);
            //EggplantTestBase.Log("Text was : " + text);
            return text;
        }



        public EggplantElement Click()
        {
            WaitForPresent();
            EggplantTestBase.Log(string.Format("Clicking on element {0}.",locator));
            Driver.Click(locator);
            Thread.Sleep(1000);
            return this;
        }

        public EggplantElement DoubleClick()
        {
            WaitForPresent();
            EggplantTestBase.Log(string.Format("Double-clicking on element {0}.", locator));
            Driver.DoubleTap(locator);
            return this;
        }

        public EggplantElement Press()
        {
            WaitForPresent();
            EggplantTestBase.Log(string.Format("Performing click+hold on element {0}.", locator));
            Driver.Press(locator);
            Thread.Sleep(2000);
            return this;
        }

        public EggplantElement Type(string text)
        {
            EggplantTestBase.Log(string.Format("Clicking on text field..."));
            Click();
            EggplantTestBase.Log(string.Format("Typing text:({0}).", text));
            Thread.Sleep(2000);
            Driver.Type(text);
            Thread.Sleep(2000);
            return this;
        }

        // Hard verification failures - Test will halt
        public EggplantElement WaitForPresent()
        {
            return WaitForPresent(Config.ElementWaitSec);
        }

        public EggplantElement WaitForPresent(int secs)
        {
            EggplantTestBase.Log(string.Format("Waiting for element {0} to be present.",locator));
            var now = DateTime.Now;
            var endTime = DateTime.Now.AddSeconds(secs);
            while(now<endTime)
            {
                if (Driver.IsPresent(locator))
                {
                    EggplantTestBase.Log(string.Format("Verification Passed : Element {0} is present.", locator));
                    return this;
                }
                else
                {
                    Thread.Sleep(500);
                    now = DateTime.Now;
                }
            }

            EggplantTestBase.Log(string.Format("!----ERROR : Element not found: " + locator + "."));
            LogSourceImage();
            throw new Exception(string.Format("Element was not present after {0} seconds", secs));
        }

        private void LogSourceImage()
        {
            if (locator.Contains("image"))
            {
                string nameOfImage = locator.Split(':')[1].Trim(' ').Trim(')').Trim('"').Replace("/", "\\");
                string pathToImage = Config.SuitePath + "\\Images\\" + nameOfImage;
                if (Directory.Exists(pathToImage))
                {
                    foreach (var file in Directory.GetFiles(pathToImage,"*.png"))
                    {
                        TestLog.EmbedImage(null, Image.FromFile(file));  
                    }
                }
                else
                {
                    pathToImage += ".png";
                    TestLog.EmbedImage(null, Image.FromFile(pathToImage));
                }
                
            }
        }

        public EggplantElement WaitForNotPresent()
        {
            return WaitForNotPresent(Config.ElementWaitSec);
        }

        public EggplantElement WaitForNotPresent(int secs)
        {
            EggplantTestBase.Log(string.Format("Waiting for element {0} to not be present for " +secs+ " seconds.", locator));
            var now = DateTime.Now;
            var endTime = DateTime.Now.AddSeconds(secs);
            while (now < endTime)
            {
                if (!Driver.IsPresent(locator))
                {
                    EggplantTestBase.Log("Element no longer present.");
                    return this;
                }
                else
                {
                    Thread.Sleep(500);
                    now = DateTime.Now;
                }
            }

            EggplantTestBase.Log(string.Format("Element still present: " + locator));
            LogSourceImage();
            throw new Exception(string.Format("WaitForNotPresent Failed : Element was still present after {0} seconds", secs));
        }

        // Soft verification failures - Test will keep progressing
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
        
    }
}