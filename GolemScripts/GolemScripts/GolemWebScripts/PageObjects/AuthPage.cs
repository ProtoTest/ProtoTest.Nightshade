using OpenQA.Selenium;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using ProtoTest.Golem.WebDriver.Elements.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GolemWebScripts.PageObjects
{
    public class AuthPage : BasePageObject
    {
        public Element YesButton = new Element(By.CssSelector("input#idBtn_Accept"));
        
        public String Accept()
        {
            YesButton.Click();
            string pattern= "access_token=(.*)&token_type";
            var url = driver.Url;
            string token = Regex.Match(url, pattern).Groups[1].ToString();
            Common.Log("Token = " + token);
            return token;
        }

        private void LogOut()
        {
            driver.Navigate().GoToUrl("www.live.com");
            Button HotmailAccountButton = new Button(By.XPath("//span[@id='c_meun']"));
            Element HotmailAccountSignout = new Element(By.XPath("//a[@id='c_signout']"));
            HotmailAccountButton.WaitUntil(15).Present().Click();
            HotmailAccountSignout.WaitUntil(15).Present().Click();
        }

        public override void WaitForElements()
        {
            //throw new NotImplementedException();
        }
    }
}
