using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage7.Pages
{
    public class CardPage
    {
        private IWebDriver driver;
        public CardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
