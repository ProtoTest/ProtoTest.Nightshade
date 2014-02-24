using System;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using System.Text;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.Nightshade.Tests.Common;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class Test
    {
        [Test, Repeat(2), RepeatOnFailure(3)]
        public void TestDriver()
        {
           //Assert.Fail("sldkfjs");
        }

    }
}
