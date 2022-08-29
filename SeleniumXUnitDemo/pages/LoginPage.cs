using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitDemo.pages
{
    
    class LoginPage
    {
        WebDriverFixture webDriverFixture;
        public LoginPage(WebDriverFixture webDriverFixture)
        {
            this.webDriverFixture = webDriverFixture;
        }
        public bool Login(string url, string username,string password)
        {
            var driver = webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl(url);
            driver.FindElementById("username").SendKeys(username);
            driver.FindElementById("password").SendKeys(password);
            driver.FindElementById("login").Click();
            IWebElement logoutIcon = driver.FindElementByCssSelector("i.fa.fa-sign-out");
            return logoutIcon.Displayed;
        }

        public bool logout()
        {
            var driver = webDriverFixture.ChromeDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement logoutButton = driver.FindElementByCssSelector("i.fa.fa-sign-out");
            logoutButton.Click();
            IWebElement loginButton = driver.FindElementById("login");
            return loginButton.Displayed;
        }
    }
}
