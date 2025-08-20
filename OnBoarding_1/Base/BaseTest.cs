using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace OnBoarding_1.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;
        
        protected WebDriverWait wait;
        // WebDriverWait es una clase que permite esperar hasta que se cumpla una condición específica en el navegador,
        // como la visibilidad de un elemento o la presencia de un elemento en la página.

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            
            driver.Manage().Cookies.DeleteAllCookies();
            // .Manage es para acceder a las opciones del navegador y cookies es para eliminar las cookies
            
            driver.Manage().Window.Size = new System.Drawing.Size(1440, 900);
            // .Manage es para acceder a las opciones del navegador y
            // Window.Size es para cambiar el tamaño de la ventana del navegador,
            // se crea un objeto de tipo System.Drawing.Size para definir el tamaño de la ventana
           
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //wait es una instancia de WebDriverWait que espera hasta 10 segundos para que se cumpla una condición específica en el navegador.
        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
