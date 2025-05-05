using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Text;
using System.Xml.Linq;

namespace SeleniumTests
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected bool acceptNextAlert = true;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("🔷 [START] Iniciando test...");
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddArgument("--disable-blink-features=AutomationControlled");

            driver = new ChromeDriver(options); // aquí también cambié a ChromeDriver
            baseURL = "https://automationexercise.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void Teardown()
        {
            // Mostrar si el test pasó o falló
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                Console.WriteLine("✅ [END] Test finalizado correctamente.");
            }
            else
            {
                Console.WriteLine("❌ [FAIL] El test falló: " + TestContext.CurrentContext.Result.Message);
            }

            // Intentar cerrar y liberar el driver
            try
            {
                driver?.Quit();
                driver?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ [WARNING] Ocurrió un error al cerrar el navegador: " + ex.Message);
                // Ignorar errores
            }

            // Verificación final de errores (si usas verificationErrors)
            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        protected bool IsElementPresent(By by)
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

        protected bool IsAlertPresent()
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

        protected string CloseAlertAndGetItsText()
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

        //Esperar a que un elemento sea visible
        public IWebElement WaitUntilVisible(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        //Esperar a que un elemento sea clickeable
        public IWebElement WaitUntilClickable(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
