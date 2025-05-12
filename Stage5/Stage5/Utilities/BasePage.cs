using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Utilities;
using System;
using System.Text;

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
            Console.WriteLine("🔷 Iniciando test...");

            string browser = "chrome";   // Cambia por lo que necesites
            bool remoto = false;         // Cambia por true si quieres Selenium Grid

            AdministradorDePruebas.IniciarDriver(browser, remoto);
            driver = AdministradorDePruebas.ObtenerDriver();

            baseURL = "https://automationexercise.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                Console.WriteLine("✅ Test finalizado correctamente.");
            }
            else
            {
                Console.WriteLine("❌ Falló: " + TestContext.CurrentContext.Result.Message);
            }

            try
            {
                AdministradorDePruebas.CerrarDriver();
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Error al cerrar el navegador: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        // Métodos auxiliares como WaitUntilVisible, WaitUntilClickable, etc., los mantienes igual
    }
}
