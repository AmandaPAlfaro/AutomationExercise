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

        //****************************************/
        //****************************************/

        // ELEMENTOS

        private By categoriesTitle = By.XPath("//h2[text()='Category']");
        private By categoriesList = By.CssSelector(".panel-group.category-products .panel");
        private By usernameField = By.XPath("//li[10]/a/b");
        private By navigationMenu = By.CssSelector("ul.nav.navbar-nav");

        // MÉTODOS

        public bool verifyLoads()
        {
            try
            {
                return driver.FindElement(categoriesTitle).Displayed &&
                       driver.FindElement(navigationMenu).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool verifyUsr(string usr)
        {
            try
            {
                var userElement = driver.FindElement(usernameField);
                return userElement.Displayed && userElement.Text.Trim().Equals(usr);
            }
            catch
            {
                return false;
            }
        }

        // MÉTODOS DE NAVEGACIÓN DEL MENÚ

        public void GoToHome() =>
            driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Click();

        public void GoToPostAnAd() =>
            driver.FindElement(By.XPath("//a[contains(text(),'Products')]")).Click();

        public void GoToMyAds() =>
            driver.FindElement(By.XPath("//a[contains(text(),'Cart')]")).Click();
    }
}
