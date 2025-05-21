using NUnit.Framework;
using SeleniumTests;
using Stage6.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage6.Tests
{
    [TestFixture]
    public class LogInTests : BasePage
    {
        [Test]
        public void ValidLoginShouldRedirectToHome()
        {
            var loginPage = new LogInPage(driver);
            driver.Navigate().GoToUrl("https://automationexercise.com/login");

            Assert.That(loginPage.verifyLoads(), Is.True, "🔴 Los elementos de la página de login no se cargaron correctamente.");

            var homePage = loginPage.logIn("Ignacio@gamil.com", "Control123$");

            Assert.That(homePage.verifyLoads(), Is.True, "🔴 No se cargó correctamente la HomePage luego del login.");
        }

        [Test, Timeout(7000)]
        public void InvalidLoginShouldShowErrorMessage()
        {
            var loginPage = new LogInPage(driver);
            driver.Navigate().GoToUrl("https://automationexercise.com/login");

            loginPage.logIn("Ignacio@gamil.com", "Control123");

            Assert.That(loginPage.verifyErrorMsg("Your email or password is incorrect!"), Is.True,
                "🔴 No se mostró el mensaje de error esperado.");
        }
    }
}
