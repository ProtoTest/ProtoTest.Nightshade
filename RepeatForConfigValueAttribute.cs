﻿using System;
using Gallio.Common.Reflection;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using Gallio.Model;
using MbUnit.Framework;

namespace ProtoTest.Nightshade
{
    /// <summary>
    ///     Runs a test the number of times specified by the key in the App.Config
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Each repetition of the test method will occur within its own individually labeled
    ///         test step so that it can be identified in the test report.
    ///     </para>
    ///     <para>
    ///         The initialize, setup, teardown and dispose methods will are invoked around each
    ///         repetition of the test.
    ///     </para>
    /// </remarks>
    /// <seealso cref="RepeatAttribute" />
    [AttributeUsage(PatternAttributeTargets.Test, AllowMultiple = true, Inherited = true)]
    public class RepeatForConfigValueAttribute : TestDecoratorPatternAttribute
    {
        private int _numberOfRepetitions;
        private string _configKey;
        private string _configValue;

        /// <summary>
        ///     Will re-run the test method each time we get a failure for a limited number of attempts.
        /// </summary>
        /// <example>
        ///     <code><![CDATA[
        /// [Test]
        /// [RepeatForConfigValue("NameOfKey")]
        /// public void Test()
        /// {
        /// }
        /// ]]></code>
        /// </example>
        /// <param name="configKey">The key in the App.Config to look for.  Assumes the value is an int <add key="NameOfKey" value="2"/> </param>
        /// </exception>
        public RepeatForConfigValueAttribute(string configKey)
        {
            try
            {
                this._configKey = configKey;
                this._configValue = Config.GetConfigValue(configKey, "Default");
                if (this._configValue == "Default")
                {
                    _numberOfRepetitions = 1;
                }
                else
                {
                    _numberOfRepetitions = int.Parse(_configValue); 
                }
                   
            }
            catch (Exception e)
            {
                throw new ArgumentException("RepeatForConfigValueAttribue could not read the App.Config file for a value=" + configKey + " " + e.Message);
            }        
        }

        /// <inheritdoc />
        protected override void DecorateTest(IPatternScope scope, ICodeElementInfo codeElement)
        {
            scope.TestBuilder.TestInstanceActions.RunTestInstanceBodyChain.Around(
                delegate(PatternTestInstanceState state,
                    Gallio.Common.Func<PatternTestInstanceState, TestOutcome> inner)
                {
                    TestOutcome outcome = TestOutcome.Skipped;
                    if (_configValue == "Default")
                    {
                        TestLog.Warnings.WriteLine("RepeatForConfigValueAttribue did not find a key matching '"+_configKey +"' in the App.Config, using a default value of 1");
                        _numberOfRepetitions = 1;
                    }
                    else
                    {
                        _numberOfRepetitions = int.Parse(_configValue);
                    }
                    for (int i = 0; i < _numberOfRepetitions; i++)
                    {
                        string name = String.Format("Repetition #{0}", i + 1);
                        TestContext context = TestStep.RunStep(name, delegate
                        {
                            TestOutcome innerOutcome = inner(state);
                            if (innerOutcome.Status != TestStatus.Passed)
                            {
                                throw new SilentTestException(innerOutcome);
                            }
                        }, null, false, codeElement);
                        outcome = context.Outcome;
                    }
                    return outcome;
                });
        }
    }
}
