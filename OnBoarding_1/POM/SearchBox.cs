using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding_1.POM
{
    public class SearchBox
    {
        private IWebDriver driver;
        public SearchBox(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SearchInput => driver.FindElement(By.Id("searchInput"));

        public void EnterSearchText(string text)
        {
            SearchInput.SendKeys(text);
            SearchInput.Submit();
        }
    }
}
