using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitDemo.pages
{
    
 public  class LoginPage
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
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login")).Click();
            IWebElement logoutIcon = driver.FindElement(By.CssSelector("i.fa.fa-sign-out"));
            return logoutIcon.Displayed;
        }

        public bool logout()
        {
            var driver = webDriverFixture.ChromeDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement logoutButton = driver.FindElement(By.CssSelector("i.fa.fa-sign-out"));
            logoutButton.Click();
            IWebElement loginButton = driver.FindElement(By.Id("login"));
            return loginButton.Displayed;
        }
    }
}
