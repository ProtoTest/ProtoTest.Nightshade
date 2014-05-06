using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Gallio.Framework;

namespace ProtoTest.Nightshade
{
    /// <summary>
    /// Non terminating validations.  
    /// </summary>
    class VerificationErrors
    {
        public static List<VerificationError> Errors = new List<VerificationError>();


        public static void AddVerificationError(string message)
        {
            TestContext.CurrentContext.AddAssertCount(1);
            Errors.Add(new VerificationError(message));
        }

        public void AssertNoVerificationErrors()
        {
            if (Errors.Count != 0)
            {
                TestLog.Failures.BeginSection("Verification Errors");
                foreach (var error in Errors)
                {
                    TestLog.Failures.WriteLine(string.Format("Verification Error Found At {0} : {1}", error.time.ToShortTimeString(), error.message));
                    if (error.screenshot != null)
                    {
                        TestLog.Failures.EmbedImage(null, error.screenshot);    
                    }
                    
                }    
                TestLog.Failures.End();
            }
            
        }
        internal class VerificationError
        {
            public string message;
            public Image screenshot;
            public DateTime time;
            public VerificationError(string message)
            {
                this.message = message;
                this.screenshot = EggplantTestBase.Driver.GetScreenshot();
                this.time = DateTime.Now;
            }
        }
    }
}
