using NUnit.Framework;
using OpenQA.Selenium;



namespace TestProject1.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickButtonViewProduct() => driver.FindElement(By.XPath("//div[@class=\"features_items\"]/div[2]/div/div[2]/ul/li/a/i")).Click();
        public void clickAddToCartButton() => driver.FindElement(By.XPath("//div[@class=\"features_items\"]/div[2]/div/div[1]/div[1]/a")).Click();

        public By modalAddToCart = By.XPath("//h4[contains(text(),'Added!')]");

        private By elementoProduct = By.XPath("//a[contains(text(),'Blue Top')]");

        public void clickAddToCartButtonPopUp() => driver.FindElement(By.XPath("//button[contains(text(),'Continue Shopping')]")).Click();

        public void navigateTabCard() => driver.FindElement(By.XPath("//div/ul/li[3]/a[contains(@href, 'view_cart')]")).Click();



        public string ObtenerPopUpAddCart()
        {
            return driver.FindElement(modalAddToCart).Text;
        }


        public string ObtenerTextoDelProducto()
        {
            return driver.FindElement(elementoProduct).Text;
        }
    }
}
