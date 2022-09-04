using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitDemo.pages
{
  public class OrderPage
    {
        WebDriverFixture webDriverFixture;
        public OrderPage(WebDriverFixture webDriverFixture)
        {
            this.webDriverFixture = webDriverFixture;
        }
        public bool verifyOrderList()
        {
            var driver = webDriverFixture.ChromeDriver;
            IWebElement orderLink = driver.FindElement(By.LinkText("Orders"));
            orderLink.Click();
            IList<IWebElement> orderListTableRows = driver.FindElements(By.XPath("//table/tbody/tr"));
            foreach(IWebElement eachOrder in orderListTableRows)
            {
              IWebElement eachRow=  eachOrder.FindElement(By.XPath("//td[2]/a"));
                Console.WriteLine(eachRow.Text);
                
            }
            return orderListTableRows.Count() >= 2;

        }
    }
}
