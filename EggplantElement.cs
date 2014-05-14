using System;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using Gallio.Framework;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    /// <summary>
    /// This class represents a UI element in an application. 
    /// Can be instantiated using a By object representing its locator
    /// Easy way to manipulate objects in the UI.  
    /// </summary>
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

                return EggplantTestBase.Driver;
            }
        }

        public bool IsPresent()
        {
            return Driver.IsPresent(locator);
        }

        public string GetText()
        {
            WaitForPresent();
            Log.Message(string.Format("Reading text on element {0}.", locator));
            var text = Driver.ReadText(locator);
            return text;
        }



        public EggplantElement Click()
        {
            WaitForPresent();
            Log.Message(string.Format("Clicking on element {0}.",locator));
            Thread.Sleep(Config.ClickExecuteDelay);
            Driver.Click(locator);
            Thread.Sleep(2000);
            return this;
        }

        public EggplantElement DoubleClick()
        {
            WaitForPresent();
            Log.Message(string.Format("Double-clicking on element {0}.", locator));
            Thread.Sleep(Config.ClickExecuteDelay);
            Driver.DoubleTap(locator);
            Thread.Sleep(2000);
            return this;
        }

        public EggplantElement Press()
        {
            WaitForPresent();
            Log.Message(string.Format("Performing click+hold on element {0}.", locator));
            Driver.Press(locator);
            Thread.Sleep(2000);
            return this;
        }

        public EggplantElement Type(string text)
        {
            Log.Message(string.Format("Clicking on text field..."));
            Click();
            Log.Message(string.Format("Typing text:({0}).", text));
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
            Log.Message(string.Format("Waiting for element {0} to be present within (" + secs + ") seconds.",locator));
            var now = DateTime.Now;
            var endTime = DateTime.Now.AddSeconds(secs);
            while(now<endTime)
            {
                if (Driver.IsPresent(locator))
                {
                    Log.Message(string.Format("Verification Passed : Element {0} is present.", locator));
                    return this;
                }
                else
                {
                    Thread.Sleep(500);
                    now = DateTime.Now;
                }
            }
            TestLog.BeginSection("ERROR FOUND");
            Log.Message(string.Format("!----ERROR : Element not found: " + locator + "."));
            LogSourceImage();
            //LogFailureImage(string.Format("!----ERROR : Element not found: " + locator + "."));
            TestLog.End();
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
                    foreach (var file in Directory.GetFiles(pathToImage, "*.png"))
                    {
                        TestLog.Failures.EmbedImage(null, Image.FromFile(file));
                        TestLog.EmbedImage(null, Image.FromFile(file));
                    }
                }
                else
                {
                    pathToImage += ".png";
                    TestLog.Failures.WriteLine("This element was not found in attached device screenshot.");
                    TestLog.Failures.EmbedImage(null, Image.FromFile(pathToImage));
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
            Log.Message(string.Format("Waiting for element {0} to not be present for " +secs+ " seconds.", locator));
            var now = DateTime.Now;
            var endTime = DateTime.Now.AddSeconds(secs);
            while (now < endTime)
            {
                if (!Driver.IsPresent(locator))
                {
                    Log.Message("Element no longer present.");
                    return this;
                }
                else
                {
                    Thread.Sleep(500);
                    now = DateTime.Now;
                }
            }

            Log.Message(string.Format("Element still present: " + locator));
            LogSourceImage();
            throw new Exception(string.Format("WaitForNotPresent Failed : Element was still present after {0} seconds", secs));
        }

        // Soft verification failures - Test will keep progressing
        public EggplantElement VerifyPresent()
        {
            Log.Message(string.Format("Verifying element {0} should be present.",locator));
            if (!Driver.IsPresent(locator))
            {
                VerificationErrors.AddVerificationError(string.Format("Verification Error : Element {0} should be present.", locator));
            }
            else
            {
                Log.Message(string.Format("Verification Passed : Element {0} is present.", locator));
            }
            return this;
        }

        public EggplantElement VerifyNotPresent()
        {
            Log.Message(string.Format("Verifying element {0} is not be present.",locator));

            if (Driver.IsPresent(locator))
            {
                VerificationErrors.AddVerificationError(string.Format("Verification Error : Element {0} should not be present.",locator));
            }
            else
            {
                Log.Message(string.Format("Verification Passed : Element {0} is not be present",locator));
            }
            return this;
        }
        
    }
}