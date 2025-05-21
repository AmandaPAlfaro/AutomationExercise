using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests;
using Stage7.Pages;
using System.Buffers.Text;
using TestProject1.Pages;
//using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestProject1;

public class HomeTests
{
    [TestFixture]
    public class VeiofryViewDetails : BasePage
    {
        [Test]
        public void ViewDetailsdProduct()
        {
            var homePage = new HomePage(driver);

            driver.Navigate().GoToUrl(baseURL);
            homePage.clickButtonViewProduct();
        }

        [Test]
        public void NavigateToPostAdFromHome()
        {
            var navigationPage = new NavigationPage (driver);
            driver.Navigate().GoToUrl("https://automationexercise.com");

            Assert.That(navigationPage.VerifyLoads());

            var cardPage = navigationPage.GoToCard();
            var ProductPage = navigationPage.GoToProduct();
            //Assert.That(cardPage.VerifyLoads(), "❌ No cargó la vista de Post An Ad.");
        }

        [Test]
        public void VerifyThatTheUserCanSeePopupWhenAProductIsAddedToTheCart()
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var homePage = new HomePage(driver);

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseURL);
            homePage.clickAddToCartButton();
            Thread.Sleep(5000);

            //wait.Until(drv => homePage.ObtenerPopUpAddCart() == "Added!");

            string actualTextAddCart = homePage.ObtenerPopUpAddCart();
            string expectedTextAddCart = "Added!";
            Assert.That(actualTextAddCart, Is.EqualTo(expectedTextAddCart));
        }


       

        [Test]
        public void VerifyThatTheUserCanViewProductsAddedToTheCart()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var homePage = new HomePage(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseURL);
            homePage.clickAddToCartButton();
            //Thread.Sleep(5000);
            homePage.clickAddToCartButtonPopUp();
            //Thread.Sleep(5000);

            homePage.navigateTabCard();

            //homePage.clickAddToCartButton();
            //Thread.Sleep(5000);
            //wait.Until(drv => homePage.ObtenerTextoDelProducto() == "Blue Top");

            string actualDetailProduct = homePage.ObtenerTextoDelProducto();
            string expectedDetailProduct = "Blue Top";
            Assert.That(actualDetailProduct, Is.EqualTo(expectedDetailProduct));
        }

        

    }
}
