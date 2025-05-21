using OpenQA.Selenium;
using TestProject1.Pages;

namespace Stage7.Pages
{
    public class NavigationPage
    {
        private readonly IWebDriver driver;

        public NavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Selectores comunes de navegación
        private By homeLink = By.XPath("//a[contains(text(), 'Home')]");
        private By cardLink = By.XPath("//a[contains(text(), 'Cart')]");
        private By productsLink = By.XPath("//a[contains(text(), 'Products')]");

        // Métodos de navegación
        public HomePage GoToHome()
        {
            driver.FindElement(homeLink).Click();
            return new HomePage(driver);
        }

        public CardPage GoToCard()
        {
            driver.FindElement(cardLink).Click();
            return new CardPage(driver);
        }

        public ProductsPage GoToProduct()
        {
            driver.FindElement(productsLink).Click();
            return new ProductsPage(driver);
        }

        public bool VerifyLoads()
        {
            try
            {
                return driver.FindElement(homeLink).Displayed &&
                       driver.FindElement(cardLink).Displayed &&
                       driver.FindElement(productsLink).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
