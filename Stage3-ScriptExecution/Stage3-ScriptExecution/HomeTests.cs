using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class CreateAUserForYourOwnUse
    {
        [OneTimeSetUp]
        public void AntesDeTodaLaClase()
        {
            string nombreClase = GetType().Name;
            Console.WriteLine($"Ejecutando clase: {nombreClase}");
        }

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

    

        [SetUp]
        public void SetupTest()
        {
            Console.WriteLine("*-*-**-*-");
            Console.WriteLine("🔷 [START] Iniciando test...");
            Console.WriteLine("*-*-**-*-");

            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();

            
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver?.Quit();
                driver?.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }


        [Test]
        public void TheCreateAUserForYourOwnUseTest()
        {
            driver.Navigate().GoToUrl("https://automationexercise.com/");
            driver.FindElement(By.LinkText("Signup / Login")).Click();
            driver.FindElement(By.Name("name")).Click();
            driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys("Julia01");
            driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/input[3]")).Click();
            driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/input[3]")).Clear();
            driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/input[3]")).SendKeys("Julia01@gamil.com");
            driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/button")).Click();
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Control123$");
            driver.FindElement(By.Id("first_name")).Click();
            driver.FindElement(By.Id("first_name")).Clear();
            driver.FindElement(By.Id("first_name")).SendKeys("JuliaA");
            driver.FindElement(By.Id("last_name")).Click();
            driver.FindElement(By.Id("last_name")).Clear();
            driver.FindElement(By.Id("last_name")).SendKeys("LJulia");
            driver.FindElement(By.Id("address1")).Click();
            driver.FindElement(By.Id("address1")).Clear();
            driver.FindElement(By.Id("address1")).SendKeys("Capa");
            driver.FindElement(By.Id("country")).Click();
            new SelectElement(driver.FindElement(By.Id("country"))).SelectByText("United States");
            driver.FindElement(By.Id("state")).Click();
            driver.FindElement(By.Id("state")).Clear();
            driver.FindElement(By.Id("state")).SendKeys("Florida");
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("Fl");
            driver.FindElement(By.Id("zipcode")).Click();
            driver.FindElement(By.Id("zipcode")).Clear();
            driver.FindElement(By.Id("zipcode")).SendKeys("33101");
            driver.FindElement(By.Id("mobile_number")).Click();
            driver.FindElement(By.Id("mobile_number")).Clear();
            driver.FindElement(By.Id("mobile_number")).SendKeys("1 (444)55555");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
            driver.FindElement(By.LinkText("Delete Account")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
        }

        [Test]
        public void TheVerifyThatTheUserCanViewProductDetailsTest()
        {
            driver.Navigate().GoToUrl("https://automationexercise.com/");
            driver.FindElement(By.XPath("//div[@class=\"features_items\"]/div[2]/div/div[2]/ul/li/a/i")).Click();
        }

        [Test]
        public void TheVerifyThatTheUserCanSeeTheAddedPopupWhenAProductIsAddedToTheCartTest()
        {
            driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
            driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
            driver.Navigate().GoToUrl("https://automationexercise.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Rs. 500'])[2]/following::a[1]")).Click();
            driver.FindElement(By.XPath("//div[@id='cartModal']/div/div/div[3]/button")).Click();
        }

        [Test]
        public void TheVerifyThatTheUserCanViewProductsAddedToTheCartTest()
        {
            driver.Navigate().GoToUrl(baseURL + "chrome://newtab/");
            driver.Navigate().GoToUrl("https://automationexercise.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Rs. 500'])[2]/following::a[1]")).Click();
            driver.FindElement(By.XPath("//div[@id='cartModal']/div/div/div[3]/button")).Click();
            driver.FindElement(By.LinkText("Cart")).Click();
            driver.FindElement(By.Id("product-1")).Click();
        }

        [Test]
        public void TheVerifyThatTheUserCanSearchForAProductTest()
        {
            driver.Navigate().GoToUrl("https://automationexercise.com/");
            driver.FindElement(By.XPath("//header[@id='header']/div/div/div/div[2]/div/ul/li[2]/a/i")).Click();
            driver.FindElement(By.Id("search_product")).Click();
            driver.FindElement(By.Id("search_product")).Clear();
            driver.FindElement(By.Id("search_product")).SendKeys("Dress");
            driver.FindElement(By.Id("submit_search")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /*private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }*/

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
