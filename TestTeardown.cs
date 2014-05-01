using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Gallio.Common.Collections;
using Gallio.Common.Reflection;
using Gallio.Framework;
using Gallio.Framework.Pattern;
using Gallio.Model;
using MbUnit.Framework;

namespace ProtoTest.Nightshade
{
    [AttributeUsage(PatternAttributeTargets.Test, AllowMultiple = true, Inherited = true)]
    public class TestTeardownAttribute : TestDecoratorPatternAttribute
    {

        public string methodName;

        public TestTeardownAttribute(string methodName)
        {
            this.methodName = methodName;


        }

        /// <inheritdoc />
        protected override void DecorateTest(IPatternScope scope, ICodeElementInfo codeElement)
        {
           
            scope.TestBuilder.TestInstanceActions.DisposeTestInstanceChain.After(delegate(PatternTestInstanceState instanceState)
            {
                ITypeInfo typeInfo;
                typeInfo = ReflectionUtils.GetType(codeElement);
                IMethodInfo method = typeInfo.GetMethod(this.methodName, BindingFlags.Instance | BindingFlags.Public);
                instanceState.InvokeFixtureMethod(method,
                                                  (IEnumerable<KeyValuePair<ISlotInfo, object>>)
                                                  EmptyArray<KeyValuePair<ISlotInfo, object>>.Instance);

            });
        }
    }
}