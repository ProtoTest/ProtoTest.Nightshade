using ProtoTest.Golem.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;


namespace GolemWebScripts.PageObjects
{
    public class LoginPage : BasePageObject
    {
        public Element UserEmail = new Element(By.CssSelector("input#i0116"));
        public Element UserPassword = new Element(By.CssSelector("input#i0118"));
        public Element SubmitButton = new Element(By.CssSelector("input#idSIButton9"));

        public AuthPage login(string email, string password)
        {
            UserEmail.Text = email;
            UserPassword.Text = password;
            SubmitButton.Click();
            return new AuthPage();
        }

        public override void WaitForElements()
        {
            //throw new NotImplementedException();
        }
    }
}
