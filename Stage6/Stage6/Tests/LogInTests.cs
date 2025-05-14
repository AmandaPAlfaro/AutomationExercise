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

            Assert.That.IsTrue(loginPage.verifyLoads(), "🔴 Los elementos de la página de login no se cargaron correctamente.");

            var homePage = loginPage.logIn("correct_email@example.com", "correct_password");

            Assert.IsTrue(homePage.verifyLoads(), "🔴 No se cargó correctamente la HomePage luego del login.");
        }

        [Test]
        public void InvalidLoginShouldShowErrorMessage()
        {
            var loginPage = new LogInPage(driver);
            driver.Navigate().GoToUrl("https://automationexercise.com/login");

            loginPage.logIn("fake@example.com", "wrongpass");

            Assert.IsTrue(loginPage.verifyErrorMsg("Your email or password is incorrect!"),
                "🔴 El mensaje de error no se mostró o no es el esperado.");
        }
    }
}
