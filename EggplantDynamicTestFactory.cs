using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using CookComputing.XmlRpc;
using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;

namespace ProtoTest.TestRunner.Nightshade
{
    /// <summary>
    /// This class reads the config file and creates tests dynamically for each one found.
    /// To execute multi-device tests, one script is needed for each device.  
    /// So a single test can contain multiple scripts to be executed and validated against a specific host.  
    /// It executes the tests through eggplant drive, which includes an XmlRpc service we can call to execute commands.
    /// We execute a test by telling eggplant drive to execute a script (by name) against a host
    /// The eggplant results file is parsed to determine if a failure occured.  
    /// Eggplant drive needs to be restarted periodically, as it will run out of memory after 40 hours of execution.
    /// Each test can be repeated as many times as necessary, and each failure can be retried.  
    /// </summary>
    class EggplantDynamicTestFactory
    {
        private static string configFilePath = Directory.GetCurrentDirectory() + "\\TestConfig.xml";
        private static string batchFilePath = Directory.GetCurrentDirectory() + "\\StartDrive.bat";
        private static string suitePath = Common.GetValueFromConfigFile("//Suite/@path");
        private static XmlNodeList tests = Common.GetNodesFromConfigFile("//Test");
        private static int driveTimeoutMs = int.Parse(Common.GetValueFromConfigFile("//EggPlantSettings/@driveTimeoutMs"));
        private static int waitForDriveMs = int.Parse(Common.GetValueFromConfigFile("//EggPlantSettings/@waitForDriveMs"));
        private static Process cmdProcess;
        private static EggplantDriver driver;
        private static string scriptName;
        private static string host;
        private static int timeout = 0;
        private static int repeat = 0;
        private static int retry = 0;
        private static bool testFailed = false;

        /// <summary>
        /// This is run once, to instantiate the driver and delete the results directory
        /// </summary>
        [FixtureInitializer]
        public void Initialize()
        {
            Gallio.Framework.Pattern.TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            driver = new EggplantDriver(driveTimeoutMs);
            Common.DeleteResultsDirectory(suitePath);
            batchFilePath =  Common.CreateBatchFile();

        }

        /// <summary>
        /// This function will run before each suite, it will restart drive, start a suite session, and delete the results directory.
        /// </summary>
        [FixtureSetUp]
        public void setup()
        {

            if (Common.GetValueFromConfigFile("//Suite/@startDrive") == "true")
            {
                RestartDrive();
            }
        }

        /// <summary>
        /// This will run after all tests are complete, to close drive if the test failed.
        /// </summary>
        [FixtureTearDown]
        public void TearDown()
        {
            driver.StopEggPlantDrive();
        }

        /// <summary>
        /// This stores the number of times to repeat the entire suite.  
        /// It uses the factory GetNumRepetitions() to determine how many times to loop.
        /// The MbUnit factory handles the rest.
        /// </summary>
        [Factory("GetNumRepetitions")]
        public int repetition;

        /// <summary>
        /// This method parses the log file and yields once for each repetition.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> GetNumRepetitions()
        {
            XmlDocument configFile = new XmlDocument();
            configFile.Load(Directory.GetCurrentDirectory() + "\\TestConfig.xml");
            int num = int.Parse(configFile.SelectSingleNode("//Suite/@repeat").Value);
            for (var i = 1; i <= num; i++)
            {
                yield return i;
            }

        }


        /// <summary>
        /// Restarts drive, and restarts the session.
        /// </summary>
        public static void RestartDrive()
        {
            driver.StopEggPlantDrive();
            driver.StartEggPlantDrive(batchFilePath, waitForDriveMs);
            driver.StartSuiteSession(suitePath);
        }

        /// <summary>
        /// This is the test factory.  It parses the xml file and generates a new test case for every <Test> defined.
        /// Each test contains one or more scripts executed against a specific device host.
        /// Each Test can be repeated x times and retried y times on failure.
        /// If a script in a test fails, it can retry all scripts in a test.
        /// </summary>
        /// <returns></returns>
        [DynamicTestFactory]
        public static IEnumerable<Test> RunTestsFromConfigFile()
        {
            foreach (XmlNode test in tests)
            {
                yield return new TestCase(Common.GetValueFromNode("@name", test), () =>
                {
                    XmlNodeList scripts = test.ChildNodes;
                    testFailed = false;
                    repeat = int.Parse(Common.GetValueFromNode("@repeat", test));
                    retry = int.Parse(Common.GetValueFromNode("@retry", test));
                    TestOutcome testOutcome = TestOutcome.Failed;

                    if (Common.GetValueFromNode("@restartDrive", test)=="true")
                    {
                        RestartDrive();
                    }

                    for (int i = 0; i < repeat; i++)
                    {
                        foreach (XmlNode script in scripts)
                        {
                            scriptName = script.SelectSingleNode("@scriptName").Value;
                            host = Common.GetValueFromNode("@host", script);
                            timeout = int.Parse(Common.GetValueFromNode("@timeout", script));
                            string name = scriptName + " : Iteration #" + (i + 1).ToString();

                            EggplantScript eScript = new EggplantScript(driver, suitePath, scriptName, host, timeout);
                            testOutcome = eScript.ExecuteScriptAndGetOutcome(name);

                            if (testOutcome != TestOutcome.Passed)
                            {
                                testFailed = true;
                            }

                        }
                        if (testFailed == true)
                        {
                            for (var j = 0; ((j < retry) && (testOutcome != TestOutcome.Passed)); j++)
                            {
                                foreach (XmlNode script in scripts)
                                {
                                    scriptName = Common.GetValueFromNode("@scriptName", script);
                                    host = Common.GetValueFromNode("@host", script);
                                    timeout = int.Parse(Common.GetValueFromNode("@timeout", script));

                                    string name = scriptName + " : Iteration #" + (i + 1).ToString() + " : Retry : " + (j + 1).ToString();
                                    
                                    EggplantScript eScript = new EggplantScript(driver, suitePath, scriptName, host, timeout);
                                    testOutcome = eScript.ExecuteScriptAndGetOutcome(name);
                                    
                                    if (testOutcome != TestOutcome.Passed)
                                    {
                                        testFailed = true;
                                    }
                                }
                            }

                        }


                    }
                    
                    if (testFailed == true)
                    {
                        Assert.TerminateSilently(TestOutcome.Failed);
                    }
                });
            }
            if (testFailed == true)
            {
                Assert.TerminateSilently(TestOutcome.Failed);
            }
        }


    }
}
