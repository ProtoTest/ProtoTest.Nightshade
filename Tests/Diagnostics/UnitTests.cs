using Gallio.Framework;
using MbUnit.Framework;
using ProtoTest.Nightshade.PageObjects;

namespace ProtoTest.Nightshade.Tests.Diagnostics
{
    public class UnitTests : EggplantTestBase
        {

            //[Test]
            public void TestDriver()
            {
                EggplantElement StartButton = new EggplantElement(By.Image("MC65/System/StartMenu/StartButton"));
                EggplantElement ContactsButton = new EggplantElement(By.Text("Contacts"));
                EggplantElement CloseButton = new EggplantElement(By.Image("MC65/System/StartMenu/ExitButton"));
                if(!ContactsButton.IsPresent())
                    StartButton.Click();
                ContactsButton.Click();
                CloseButton.Click();
                StartButton.Click();
                CloseButton.Click();

            }

            //[Test]
            public void TestScreenRectangle()
            {
                ConnectToHost1();
                var rect = Driver.GetScreenRectangle();
                DiagnosticLog.WriteLine("The rect is : " + rect.width + " x " + rect.height);
            }

            //[Test]
            public void TestGetOptions()
            {
                ConnectToHost1();
                DiagnosticLog.WriteLine(Driver.GetOptions());
                DiagnosticLog.WriteLine(Driver.GetOption("ImageSearchTime"));
            }

            //[Test]
            public void TestConnectionInfo()
            {
                ConnectToHost1();
                var info = Driver.GetConnectionInfo();
                DiagnosticLog.WriteLine(info);
            }

            //[Test]
            public void TestElementSearchRectangle()
            {
                ConnectToHost1();

                EggplantElement Home = new EggplantElement(By.Text("Home").InRectangle(SearchRectangle.TopQuarter));
                EggplantElement element = new EggplantElement(By.Image("MC65/System/StartMenu/ExitButton").InRectangle(SearchRectangle.BottomQuarter));
                Home.Click();
                element.Click();
            }

            //[Test]
            public void TestElementByPath()
            {
                EggplantElement element = new EggplantElement(By.Image("MC65/System/StartMenu/ExitButton"));
                element.Click();
            }

            //[Test]
            public void TestElementByText()
            {
                EggplantElement element = new EggplantElement(By.Image("(Text:\"Text Of Element\")"));
                element.Click();
            }

            //[Test]
            public void TestTwoHosts()
            {
                Driver.Disconnect();
                ConnectToHost2();

            }

            //[Test]
            public void TestPageObject()
            {
                Driver.Connect(Config.Host1Ip);
                var page = new FrameworkPageObjectExample();
                page.DoSomething();
            }

            //[Test]
            public void TestByLocators()
            {
                Driver.Connect(Config.Host1Ip);
                var Element = new EggplantElement(By.Text("Run"));
                Element.Click();
            }

        }
}