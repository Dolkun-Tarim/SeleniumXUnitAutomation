using OpenQA.Selenium;
using System.Collections.Generic;

namespace XUnitDemo.pages
{
  public class CustomerPage
    {
        WebDriverFixture webDriverFixture;
        public CustomerPage(WebDriverFixture webDriverFixture)
        {
            this.webDriverFixture = webDriverFixture;
        }

        public void clickCustomerLink()
        {
            var driver = webDriverFixture.ChromeDriver;
            IWebElement customerLink = driver.FindElement(By.LinkText("Customer List"));
            customerLink.Click();
        }

        public bool verifyCustomers()
        {
            var driver = webDriverFixture.ChromeDriver;
            IList<IWebElement> customerRecords = driver.FindElements(By.XPath("//div[@id='customer-list']/table/tbody/tr"));
            int totalCustomerCount = customerRecords.Count;
            if (totalCustomerCount >= 1)
                return true;
            else
                return false;

        }

        public bool addNewCustomer(string firstName,string lastName,string email)
        {
            var driver = webDriverFixture.ChromeDriver;
            IWebElement customerLink = driver.FindElement(By.LinkText("Customer List"));
            customerLink.Click();
            IWebElement addCustomerLink = driver.FindElement(By.LinkText("Add Customer"));
            addCustomerLink.Click();
            IWebElement firstNameElement = driver.FindElement(By.Id("cust-firstname"));
            firstNameElement.SendKeys(firstName);
            IWebElement lastnameElement = driver.FindElement(By.Id("cust-lastname"));
            lastnameElement.SendKeys(lastName);
            IWebElement emailElement = driver.FindElement(By.Id("cust-email"));
            emailElement.SendKeys(email);
            IWebElement saveButton = driver.FindElement(By.Name("save"));
            saveButton.Click();
            IWebElement successMessage = driver.FindElement(By.CssSelector("div.success"));
            string displayedMessage = successMessage.Text;
            if (displayedMessage.Contains("Customer successfully added"))
                return true;
            else
                return false;
        }

        public bool verifyNewCustomerMessage()
        {
            var driver = webDriverFixture.ChromeDriver;
            IWebElement successMessage = driver.FindElement(By.CssSelector("div.success"));
            string displayedMessage = successMessage.Text;
            if (displayedMessage.Contains("Customer successfully added"))
                return true;
            else
                return false;

        }

        
    }
}
