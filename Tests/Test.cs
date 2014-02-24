using System;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using System.Text;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class Test: EggplantTestBase
    {
        [Test]
        public void TestDriver()
        {
            Driver.Connect(Config.Hosts[0]);
            Driver.ExecuteCommand("Click","/path/to/image");
        }

        [Test]
        public void TestElementByPath()
        {
            EggplantElement element = new EggplantElement("/path/to/image");
            element.Click();
        }

        [Test]
        public void TestElementByText()
        {
            EggplantElement element = new EggplantElement("(Text:\"Text Of Element\")");
            element.Click();
        }

        [Test]
        public void TestTwoHosts()
        {
            //first host is automatically connected
            Driver.Disconnect(Config.Hosts[0]);
            Driver.Connect(Config.Hosts[1]);
            Driver.Click("/path/to/image");
            Driver.Disconnect(Config.Hosts[0]);
            Driver.Connect(Config.Hosts[1]);
            Driver.Click("/path/to/image");
        }

        [Test]
        public void TestPageObject()
        {
            Driver.Connect(Config.Hosts[0]);
            var page = new PageObjectExample();
            page.DoSomething();
        }
    }
}
