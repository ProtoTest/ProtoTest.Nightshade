using System.ComponentModel;
using System.Drawing;
using System.Threading;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    public class Test : EggplantTestBase
        {
            [Test]
            public void TestDriver()
            {
                Driver.Connect(Config.Hosts[0]);
                EggplantElement element = new EggplantElement(By.Text("Phone"));
                EggplantElement three = new EggplantElement(By.Text("3"));
                EggplantElement four = new EggplantElement(By.Text("4"));
                EggplantElement five = new EggplantElement(By.Text("5"));
                EggplantElement six = new EggplantElement(By.Text("6"));
                EggplantElement seven = new EggplantElement(By.Text("7"));
                element.Click();
                three.Click();
                four.Click();
               
                six.Click();
                seven.Click();
                Driver.LogScreenshot();

            }

            [Test]
            public void TestElementByPath()
            {
                EggplantElement element = new EggplantElement("imageName");
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
                Driver.Connect(Config.Hosts[0]);
                Driver.Disconnect(Config.Hosts[0]);
                Driver.Connect(Config.Hosts[1]);
                Driver.Click(@"\path\to\image");
                Driver.Disconnect(Config.Hosts[0]);
                Driver.Connect(Config.Hosts[1]);
                Driver.Click(@"\path\to\image");
            }

            [Test]
            public void TestPageObject()
            {
                Driver.Connect(Config.Hosts[0]);
                var page = new PageObjectExample();
                page.DoSomething();
            }

            [Test]
            public void TestByLocators()
            {
                Driver.Connect(Config.Hosts[0]);
                var Element = new EggplantElement(By.Text("Run"));
                Element.Click();
            }
        }
}