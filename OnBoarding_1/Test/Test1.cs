using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;
using OnBoarding_1.POM;
using SeleniumExtras.WaitHelpers;

namespace OnBoarding_1.Test
{
    [TestFixture()]
    [Category("Login Page")]
    [Category("Smoke Test")]
    public class Tests : Base.BaseTest
    {
        [Test]
        public void Test1()
        {
            Language language = new Language(driver);
            SearchBox searchBox = new SearchBox(driver);
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            language.ClickSpanish();
            searchBox.EnterSearchText("Alien: Romulus");
            try
            {
                IWebElement year = driver.FindElement(By.XPath("//th[a[contains(text(),'Año')]]/following-sibling::td"));
                //th[a[contains(text(),'Año')]]/following-sibling::td 
                //Esta expresión XPath busca un elemento <th> que contenga un enlace con el texto 'Año' y luego selecciona el siguiente elemento <td> que es el año de la película "Alien: Romulus".
                //Esta expresion es un XPath Axes donde se utiliza el siguiente elemento hermano (following-sibling) para encontrar el año de la película.
                //El elemento year es un elemento <td> que contiene el año de la película "Alien: Romulus".
                //Por ejemplo th es el elemento que contiene el encabezado de la tabla, y a es el enlace dentro de ese encabezado que contiene el texto 'Año'.
                //El elemento year es un elemento <td> que contiene el año de la película "Alien: Romulus".
                //Entonces year es el sibling del elemento th que contiene el enlace con el texto 'Año' y contiene el año de la película "Alien: Romulus".

                driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", year);
                //Desplaza la vista del navegador para que el elemento year sea visible
                
                Console.WriteLine("Elemento econtrado: " + year.Text);
                Assert.That(year.Text, Is.EqualTo("2024"));
                //Valida que el año sea 2024 con la propiedad .Text del elemento year
            }
            catch(Exception ex)
            {
                Console.WriteLine("Elemento no encontrado." + ex.Message);
                throw;
            }

        }
        [Test]
        public void Test2()
        {
            Language language = new Language(driver);
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            language.ClickSpanish();
            try
            {
                IWebElement wikilibros = driver.FindElement(By.CssSelector("a[title*='b:']"));
                IWebElement wikispecies = driver.FindElement(By.CssSelector("a[title*='wikispecies:']"));
                IWebElement wikiversidad = driver.FindElement(By.CssSelector("a[title*='v:']"));

                driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", wikilibros, wikispecies, wikiversidad);
                //Desplaza la vista del navegador para que el elemento year sea visible

                Console.WriteLine("Elementos encontrados:" + "\n1. " + wikilibros.Text + "\n2. " + wikispecies.Text + "\n3. " + wikiversidad.Text);
                
                Assert.That(wikilibros.Text, Is.EqualTo("Wikilibros"), "El elemento Wikilibros no se encuentra en la página.");
                //.Text es una propiedad que devuelve el texto visible del elemento, Is.EqualTo compara el texto esperado con el texto del elemento.
                Assert.That(wikispecies.Text, Is.EqualTo("Wikispecies"), "El elemento Wikispecies no se encuentra en la pagina.");
                Assert.That(wikiversidad.Text, Is.EqualTo("Wikiversidad"), "El elemento Wikiversidad no se encuentra en la pagina.");

            }
            catch
            {
                Console.WriteLine("No se encontraron los elementos esperados.");
            }
        }
        [Test]
        public void Test3()
        {
            ForgotPassword forgotPassword = new ForgotPassword(driver);
            Language language = new Language(driver);
            Login login = new Login(driver);
            Home home = new Home(driver);

            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            language.ClickSpanish();
            home.ClickLogin();
            login.ClickForgottenPassword();
            forgotPassword.EnterUserName("testusername");
            forgotPassword.EnterEmail("test@example.com");
            forgotPassword.ClickSubmit();
            

            IWebElement firtsMssg = driver.FindElement(By.XPath("//*[@id=\"mw-content-text\"]/p[1]"));
            IWebElement secondMssg = driver.FindElement(By.XPath("//*[@id=\"mw-content-text\"]/p[2]/strong"));
            IWebElement thirdMssg = driver.FindElement(By.XPath("//*[@id=\"mw-content-text\"]/p[3]"));
            IWebElement userMssg = driver.FindElement(By.XPath("//*[@id=\"mw-content-text\"]/ul/li[1]"));
            IWebElement emailMssg = driver.FindElement(By.XPath("//*[@id=\"mw-content-text\"]/ul/li[2]"));

            string fullMssg = "Solo puedes pedir un " + secondMssg.Text.Split('.')[0] + ".";
            //Se creo la variable fullMssg para concatenar el texto del segundo mensaje con un texto adicional.
            // El método Split se utiliza para dividir el texto del segundo mensaje en partes, y se toma la primera parte (antes del punto) para crear el mensaje completo.
            //Esto sirve para personalizar el mensaje de acuerdo a la situación del usuario.

            Console.WriteLine("Mensaje: " + "\n" + firtsMssg.Text + "\n" + fullMssg + "\n" + thirdMssg.Text + "\n" + userMssg.Text + "\n" + emailMssg.Text);

            Assert.That(firtsMssg.Text, Is.EqualTo("Has solicitado un restablecimiento de contraseña."), "Error en el mensaje principal");
            Assert.That(fullMssg, Is.EqualTo("Solo puedes pedir un número limitado de restablecimientos de contraseña dentro de un corto período de tiempo."), "Error en el segundo mensaje");
            Assert.That(thirdMssg.Text, Is.EqualTo("Los detalles que enviaste son:"), "Error en el tercer mensaje");
            Assert.That(userMssg.Text, Is.EqualTo("Nombre de usuario: testusername"), "Error en el mensaje del nombre de usuario");
            Assert.That(emailMssg.Text, Is.EqualTo("Dirección de correo electrónico: test@example.com"), "Error en el mensaje del email");
        }

    }
}