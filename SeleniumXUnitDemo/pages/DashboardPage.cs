﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitDemo.pages
{
    class DashboardPage
    {
        WebDriverFixture webDriverFixture;
        public DashboardPage(WebDriverFixture webDriverFixture)
        {
            this.webDriverFixture = webDriverFixture;
        }
        public bool verifyCustomerLink()
        {
            var driver = webDriverFixture.ChromeDriver;
            IWebElement customerLink = driver.FindElementByLinkText("Customer List");
            return customerLink.Displayed;

        }

        public bool verifyProductsLink()
        {
            var driver = webDriverFixture.ChromeDriver;
            IWebElement productLink = driver.FindElementByLinkText("Products");
            return productLink.Displayed;
        }
    }
}
