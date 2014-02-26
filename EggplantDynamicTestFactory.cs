using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Gallio.Framework.Pattern;
using Gallio.Model;
using MbUnit.Framework;

namespace ProtoTest.TestRunner.Nightshade
{
    /// <summary>
    ///     This class reads the config file and creates tests dynamically for each one found.
    ///     To execute multi-device tests, one script is needed for each device.
    ///     So a single test can contain multiple scripts to be executed and validated against a specific host.
    ///     It executes the tests through eggplant drive, which includes an XmlRpc service we can call to execute commands.
    ///     We execute a test by telling eggplant drive to execute a script (by name) against a host
    ///     The eggplant results file is parsed to determine if a failure occured.
    ///     Eggplant drive needs to be restarted periodically, as it will run out of memory after 40 hours of execution.
    ///     Each test can be repeated as many times as necessary, and each failure can be retried.
    /// </summary>
    internal class EggplantDynamicTestFactory
    {
        private static string configFilePath = Directory.GetCurrentDirectory() + "\\TestConfig.xml";
        private static string batchFilePath = Directory.GetCurrentDirectory() + "\\StartDrive.bat";
        private static readonly string suitePath = Common.GetValueFromConfigFile("//Suite/@path");
        private static readonly XmlNodeList tests = Common.GetNodesFromConfigFile("//Test");

        private static readonly int driveTimeoutMs =
            int.Parse(Common.GetValueFromConfigFile("//EggPlantSettings/@DriveTimeoutMs"));

        private static readonly int waitForDriveMs =
            int.Parse(Common.GetValueFromConfigFile("//EggPlantSettings/@WaitForDriveMs"));

        private static Process cmdProcess;
        public static EggplantDriver Driver;
        private static string scriptName;
        private static string host;
        private static int timeout;
        private static int repeat;
        private static int retry;
        private static bool testFailed;

        /// <summary>
        ///     This stores the number of times to repeat the entire suite.
        ///     It uses the factory GetNumRepetitions() to determine how many times to loop.
        ///     The MbUnit factory handles the rest.
        /// </summary>
        [Factory("GetNumRepetitions")] public int repetition;

        /// <summary>
        ///     This is run once, to instantiate the Driver and delete the results directory
        /// </summary>
        [FixtureInitializer]
        public void Initialize()
        {
            TestAssemblyExecutionParameters.DefaultTestCaseTimeout = null;
            Driver = new EggplantDriver(driveTimeoutMs);
            Common.DeleteResultsDirectory(suitePath);
            batchFilePath = Common.CreateBatchFile();
        }

        /// <summary>
        ///     This function will run before each suite, it will restart drive, start a suite session, and delete the results
        ///     directory.
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
        ///     This will run after all tests are complete, to close drive if the test failed.
        /// </summary>
        [FixtureTearDown]
        public void TearDown()
        {
            Driver.StopEggPlantDrive();
        }

        /// <summary>
        ///     This method parses the log file and yields once for each repetition.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> GetNumRepetitions()
        {
            var configFile = new XmlDocument();
            configFile.Load(Directory.GetCurrentDirectory() + "\\TestConfig.xml");
            int num = int.Parse(configFile.SelectSingleNode("//Suite/@repeat").Value);
            for (int i = 1; i <= num; i++)
            {
                yield return i;
            }
        }


        /// <summary>
        ///     Restarts drive, and restarts the session.
        /// </summary>
        public static void RestartDrive()
        {
            Driver.StopEggPlantDrive();
            Driver.StartEggPlantDrive(batchFilePath, waitForDriveMs);
            Driver.StartSuiteSession(suitePath);
        }

        /// <summary>
        ///     This is the test factory.  It parses the xml file and generates a new test case for every
        ///     <Test>
        ///         defined.
        ///         Each test contains one or more scripts executed against a specific device host.
        ///         Each Test can be repeated x times and retried y times on failure.
        ///         If a script in a test fails, it can retry all scripts in a test.
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

                    if (Common.GetValueFromNode("@restartDrive", test) == "true")
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
                            string name = scriptName + " : Iteration #" + (i + 1);

                            var eScript = new EggplantScript(Driver, suitePath, scriptName, host, timeout);
                            testOutcome = eScript.ExecuteScriptAndGetOutcome(name);

                            if (testOutcome != TestOutcome.Passed)
                            {
                                testFailed = true;
                            }
                        }
                        if (testFailed)
                        {
                            for (int j = 0; ((j < retry) && (testOutcome != TestOutcome.Passed)); j++)
                            {
                                foreach (XmlNode script in scripts)
                                {
                                    scriptName = Common.GetValueFromNode("@scriptName", script);
                                    host = Common.GetValueFromNode("@host", script);
                                    timeout = int.Parse(Common.GetValueFromNode("@timeout", script));

                                    string name = scriptName + " : Iteration #" + (i + 1) + " : Retry : " + (j + 1);

                                    var eScript = new EggplantScript(Driver, suitePath, scriptName, host, timeout);
                                    testOutcome = eScript.ExecuteScriptAndGetOutcome(name);

                                    if (testOutcome != TestOutcome.Passed)
                                    {
                                        testFailed = true;
                                    }
                                }
                            }
                        }
                    }

                    if (testFailed)
                    {
                        Assert.TerminateSilently(TestOutcome.Failed);
                    }
                });
            }
            if (testFailed)
            {
                Assert.TerminateSilently(TestOutcome.Failed);
            }
        }
    }
}