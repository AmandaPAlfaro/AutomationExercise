using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
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

        //private static readonly string remoteUrl = "http://localhost:4444/wd/hub";
        private static readonly string remoteUrl = "http://localhost:4444";

        public static IWebDriver CreateDriver(string browserType, bool isRemote)
        {
            IWebDriver driver;

            switch (browserType.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");

                    if (isRemote)
                    {
                        driver = new RemoteWebDriver(new Uri(remoteUrl), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(60));
                    }
                    else
                    {
                        driver = new ChromeDriver(chromeOptions);
                    }
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--width=1920");
                    firefoxOptions.AddArgument("--height=1080");

                    if (isRemote)
                    {
                        driver = new RemoteWebDriver(new Uri(remoteUrl), firefoxOptions.ToCapabilities(), TimeSpan.FromSeconds(60));
                    }
                    else
                    {
                        driver = new FirefoxDriver(firefoxOptions);
                    }
                    break;

                default:
                    throw new ArgumentException($"Navegador '{browserType}' no es compatible.");
            }

            return driver;
        }


        [SetUp]
        public void Setup()
        { 
            Console.WriteLine("🔷 Iniciando test...");

            // Aquí decides si usar remoto o no (puedes cambiar este valor o incluso leerlo desde config)
            bool isRemote = false; // o false si quieres local
            string browserType = "chrome"; // o "firefox"

            driver = CreateDriver(browserType, isRemote);

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
