using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using XUnitDemo.pages;
using System;

namespace XUnitDemo
{
    /// <summary>
    /// Contains Selenium Test with IClassFixture running in Sequence
    /// </summary>
    [Collection("Sequence")]
    public class SeleniumUITest : IClassFixture<WebDriverFixture>, IDisposable
    {

        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumUITest(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        LoginPage loginPage = new LoginPage(webDriverFixture);
        loginPage.Login("https://demo.cubecart.com/cc6/admin_5xArPd.php", "cubecart", "cubecart");
        }

        [Fact]
        public void ClassFixtureTestCustomerLink()
        {
            testOutputHelper.WriteLine("Customer Link");
            DashboardPage dashboardPage=new DashboardPage(webDriverFixture);
            Assert.True(dashboardPage.verifyCustomerLink());

        }

        [Fact]
        public void ClassFixtureTestProductLink()
        {
           testOutputHelper.WriteLine("Product Link");
            DashboardPage dashboardPage=new DashboardPage(webDriverFixture);
            Assert.True(dashboardPage.verifyProductsLink());
        }
        [Fact]
        public void ClassFixtureTestOrders()
        {
            testOutputHelper.WriteLine("Order Test");
            OrderPage orderPage = new OrderPage(webDriverFixture);

            Assert.True(orderPage.verifyOrderList());
        }
        //teardown
        public void Dispose()
    {
        LoginPage loginPage=new LoginPage(webDriverFixture);
        loginPage.logout();
    }
     
    }
}
