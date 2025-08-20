using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding_1.POM
{
    internal class Login
    {
        private IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ForgottenPassword => driver.FindElement(By.CssSelector("a[title='Especial:RestablecerContraseña']"));

        public void ClickForgottenPassword() => ForgottenPassword.Click();
    }
}
