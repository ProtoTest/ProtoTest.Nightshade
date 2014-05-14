using System;
using System.Diagnostics;
using Gallio.Common.Reflection;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using Gallio.Model;
using MbUnit.Framework;

namespace ProtoTest.Nightshade
{
    namespace Tests.Common
    {
        /// <summary>
        /// Repeats a test until the time has passed
        /// </summary>
        [AttributeUsage(PatternAttributeTargets.Test, AllowMultiple = true, Inherited = true)]
        public class RepeatForTimeAttribute : TestDecoratorPatternAttribute
        {
            private readonly int _minutes;

            /// <summary>
            ///     Will re-run the test method each time we get a failure for a limited number of attempts.
            /// </summary>
            /// <example>
            ///     <code><![CDATA[
            /// [Test]
            /// [RepeatOnFailure(3)]
            /// public void Test()
            /// {
            ///     // This test will be executed until we get a pass or have run it 3 times.
            ///     // Eg, if the first test run fails, we will run it again, and if the second attempt passes, then we will stop.
            ///     // if 3 attempts all fail, we dont try anymore
            /// }
            /// ]]></code>
            /// </example>
            /// <param name="maxNumberOfAttempts">The number of times to repeat the test while searching for a pass</param>
            /// <exception cref="ArgumentOutOfRangeException">
            ///     Thrown if <paramref name="maxNumberOfAttempts" />
            ///     is less than 1.
            /// </exception>
            public RepeatForTimeAttribute(int minutes)
            {
                if (minutes < 1)
                    throw new ArgumentOutOfRangeException("minutes",
                        @"The minutes must be at least 1.");

                _minutes = minutes;
            }

            /// <inheritdoc />
            protected override void DecorateTest(IPatternScope scope, ICodeElementInfo codeElement)
            {
                scope.TestBuilder.TestInstanceActions.RunTestInstanceBodyChain.Around(
                    delegate(PatternTestInstanceState state,
                        Gallio.Common.Func<PatternTestInstanceState, TestOutcome> inner)
                    {
                        TestOutcome outcome = TestOutcome.Passed;
                        //int failureCount = 0;
                        // we will try up to 'max' times to get a pass, if we do, then break out and don't run the test anymore

                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        for(int i=0;stopwatch.Elapsed < TimeSpan.FromMinutes(_minutes);i++)
                        {
                            string name = String.Format("Repetition #{0}", i + 1);
                            DiagnosticLog.WriteLine(name);
                            TestContext context = TestStep.RunStep(name, delegate
                            {
                                TestOutcome innerOutcome = inner(state);
                                 //if we get a fail, and we have used up the number of attempts allowed to get a pass, throw an error
                                if (innerOutcome.Status != TestStatus.Passed)
                                {
                                    throw new SilentTestException(innerOutcome);
                                }
                            }, null, false, codeElement);

                            outcome = context.Outcome;
                            // escape the loop if the test has passed, otherwise increment the failure count
                            //if (context.Outcome.Status == TestStatus.Passed)
                            //    break;
                           // failureCount++;
                        }

                        Log.Message(String.Format("Ran the test for {0} minutes", _minutes));
                        //TestLog.WriteLine(String.Format("Ran the test for {0} minutes", _minutes));

                        return outcome;
                    });
            }
        }
    }
}