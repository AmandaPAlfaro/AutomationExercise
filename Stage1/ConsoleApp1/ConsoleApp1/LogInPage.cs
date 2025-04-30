using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class CreateAUserForYourOwnUse
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCreateAUserForYourOwnUseTest()
        {
            //Navegar a la pagina de AutomationExercise
            driver.Navigate().GoToUrl("https://automationexercise.com/");

			//Click the 'Signup / Login' Tab
			driver.FindElement(By.LinkText("Signup / Login")).Click();

            //Hacer click en el texbox "Name"
            driver.FindElement(By.Name("name")).Click();
            driver.FindElement(By.Name("name")).Clear();

            // Ingresa el nombre de Julia01 en el texbox name
            driver.FindElement(By.Name("name")).SendKeys("Julia01");

            //Hace click en el texbox de Email
            driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/input[3]")).Click();
            driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/input[3]")).Clear();

            //Ingresa el email: Julia01@gmail
            driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/input[3]")).SendKeys("Julia01@gmail.com");

			//Hace click en el boton Signup
			driver.FindElement(By.XPath("//section[@id='form']/div/div/div[3]/div/form/button")).Click();

            //Hace click en el textbox del Pasword
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();

            //Ingresa un pasword
            driver.FindElement(By.Id("password")).SendKeys("Control123$");

            //Hace click en el texbox del First Name
            driver.FindElement(By.Id("first_name")).Click();
            driver.FindElement(By.Id("first_name")).Clear();

            //Ingresa el First name en el text box
            driver.FindElement(By.Id("first_name")).SendKeys("JuliaA");

			//Hace click en el texbox del First Name
			driver.FindElement(By.Id("last_name")).Click();
            driver.FindElement(By.Id("last_name")).Clear();

            //Ingresar en el texbox el last name
            driver.FindElement(By.Id("last_name")).SendKeys("LJulia");

			//Hace click en el texbox del Address1
			driver.FindElement(By.Id("address1")).Click();
            driver.FindElement(By.Id("address1")).Clear();

            //Ingresar en el texbox el Address
            driver.FindElement(By.Id("address1")).SendKeys("Capa");

            //Hacer click en el dropdown country
            driver.FindElement(By.Id("country")).Click();

            //Seleccionar la opion United States para el coutry
            new SelectElement(driver.FindElement(By.Id("country"))).SelectByText("United States");

            //Hacer click en el texbox state
            driver.FindElement(By.Id("state")).Click();
            driver.FindElement(By.Id("state")).Clear();
            
            //Ingresar datos en el texbox de state
            driver.FindElement(By.Id("state")).SendKeys("Florida");

            //Hacer click en el texbox city
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).Clear();

            //Ingresar Datos en el texboc city
            driver.FindElement(By.Id("city")).SendKeys("Fl");

            //Hacer click en el texbox del zipcode
            driver.FindElement(By.Id("zipcode")).Click();
            driver.FindElement(By.Id("zipcode")).Clear();

            //Ingresar datos en el texbox
            driver.FindElement(By.Id("zipcode")).SendKeys("33101");

            //Hacer click en el texbox mobileNumber
            driver.FindElement(By.Id("mobile_number")).Click();
            driver.FindElement(By.Id("mobile_number")).Clear();

            //Ingresar el; numero en el texbox MobileNumber
            driver.FindElement(By.Id("mobile_number")).SendKeys("1 (444)55555");

            //Hacer click en el boton Create Account
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //Hacer click en el boton Continue
            driver.FindElement(By.LinkText("Continue")).Click();
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
