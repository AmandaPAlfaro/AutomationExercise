using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Pages;

namespace Stage6.Pages
{
    public class LogInPage
    {
        private readonly IWebDriver driver;

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // ELEMENTOS DE LA VISTA LOGIN

        private By usernameField = By.XPath("//input[@data-qa='login-email']");
        private By passwordField = By.XPath("//input[@data-qa='login-password']");
        private By logInBtn = By.XPath("//button[@data-qa='login-button']");
        private By errorMessageField = By.XPath("//p[contains(@style, 'color: red')]");
        private By navigationMenu = By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul");

        // MÉTODO 1: Verificar que todos los elementos carguen

        public bool verifyLoads()
        {
            try
            {
                return driver.FindElement(usernameField).Displayed &&
                       driver.FindElement(passwordField).Displayed &&
                       driver.FindElement(logInBtn).Displayed &&
                       driver.FindElement(navigationMenu).Displayed;
            }
            catch
            {
                return false;
            }
        }

        // MÉTODO 2: Hacer login con usuario y contraseña

        public HomePage logIn(string usr, string pwd)
        {
            driver.FindElement(usernameField).SendKeys(usr);
            driver.FindElement(passwordField).SendKeys(pwd);
            driver.FindElement(logInBtn).Click();

            return new HomePage(driver);
        }

        // MÉTODO 3: Verificar mensaje de error

        public bool verifyErrorMsg(string errorMsg)
        {
            try
            {
                var msg = driver.FindElement(errorMessageField);
                return msg.Displayed && msg.Text.Trim().Equals(errorMsg);
            }
            catch
            {
                return false;
            }
        }



        /*public bool VerifyErrorMsg(string expectedMsg)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var msg = wait.Until(d =>
                {
                    var element = d.FindElement(errorMessageField);
                    return element.Displayed ? element : null;
                });

                return msg.Text.Trim().Equals(expectedMsg, StringComparison.OrdinalIgnoreCase);
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("⚠️ El mensaje de error no apareció a tiempo.");
                return false;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ No se encontró el campo del mensaje de error.");
                return false;
            }
        }*/

    }
}
