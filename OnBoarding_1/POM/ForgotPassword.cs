using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding_1.POM
{
    public class ForgotPassword
    {
        private IWebDriver driver;
        public ForgotPassword(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement InputUserName => driver.FindElement(By.Id("ooui-php-2"));
        private IWebElement InputEmail => driver.FindElement(By.Id("ooui-php-3"));
        private IWebElement SubmitBtn => driver.FindElement(By.CssSelector("button[value='Restablecer la contraseña']"));

        public void EnterUserName(string userName) => InputUserName.SendKeys(userName);
        public void EnterEmail(string email) => InputEmail.SendKeys(email);
        public void ClickSubmit() => SubmitBtn.Click();


    }
}
