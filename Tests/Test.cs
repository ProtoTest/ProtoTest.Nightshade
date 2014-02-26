﻿using System.ComponentModel;
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
                EggplantElement PhoneButton = new EggplantElement(By.Text("Phone"));
                EggplantElement ExitButton = new EggplantElement(By.Image("MC659B/System/StartMenu/StartButton"));
               // PhoneButton.Click();
                ExitButton.Click();
            

            }



            [Test]
            public void TestElementSearchRectangle()
            {
                EggplantElement element = new EggplantElement(By.Image("MC659B/System/StartMenu/ExitButton").InRectangle(new SearchRectangle(new Point(12,13),new Point(13,15))));
                element.Click();
            }

            [Test]
            public void TestElementByPath()
            {
                EggplantElement element = new EggplantElement(By.Image("MC659B/System/StartMenu/ExitButton"));
                element.Click();
            }

            [Test]
            public void TestElementByText()
            {
                EggplantElement element = new EggplantElement(By.Image("(Text:\"Text Of Element\")"));
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