// Utilities/AdministradorDePruebas.cs

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumTests.Utilities
{
    public static class AdministradorDePruebas
    {
        [ThreadStatic]
        private static IWebDriver driver;

        private static readonly string remoteUrl = "http://localhost:4444";

        public static void IniciarDriver(string navegador, bool esRemoto)
        {
            if (driver != null)
                return;

            if (navegador == "chrome")
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");

                driver = esRemoto
                    ? new RemoteWebDriver(new Uri(remoteUrl), options.ToCapabilities(), TimeSpan.FromSeconds(60))
                    : new ChromeDriver(options);
            }
            else if (navegador == "firefox")
            {
                var options = new FirefoxOptions();
                options.AddArgument("--width=1920");
                options.AddArgument("--height=1080");

                driver = esRemoto
                    ? new RemoteWebDriver(new Uri(remoteUrl), options.ToCapabilities(), TimeSpan.FromSeconds(60))
                    : new FirefoxDriver(options);
            }
            else
            {
                throw new ArgumentException($"Navegador '{navegador}' no es compatible.");
            }
        }

        public static IWebDriver ObtenerDriver()
        {
            return driver;
        }

        public static void CerrarDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
