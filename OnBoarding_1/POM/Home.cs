using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding_1.POM
{
    public class Home
    {
        private IWebDriver driver;
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement LoginBtn => driver.FindElement(By.CssSelector("a[data-mw='interface'][title*='iniciar sesión'][accesskey='o']"));

        public void ClickLogin() => LoginBtn.Click();
    }
}
