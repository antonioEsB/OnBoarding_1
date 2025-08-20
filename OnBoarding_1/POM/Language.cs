using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding_1.POM
{
    public class Language
    {
        private IWebDriver driver;
        public Language(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SpanishLink => driver.FindElement(By.Id("js-link-box-es")); 

        public void ClickSpanish() => SpanishLink.Click();
    }
}
