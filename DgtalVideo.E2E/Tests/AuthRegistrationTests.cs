using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DgtalVideo.Tests.E2E.Tests
{
    public class AuthRegistrationTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Login()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            _driver.Navigate().GoToUrl("https://localhost:7134/Auth/Login");
            var loginInput = _driver.FindElement(By.CssSelector("#Login"));
            loginInput.SendKeys("admin");
            var passwordInput = _driver.FindElement(By.CssSelector("#Password"));
            passwordInput.SendKeys("admin");
            _driver.FindElement(By.CssSelector(".admin-button")).Click();
            _driver.FindElement(By.XPath("//a[@class='site-nav__link']")).Click();
            _driver.FindElement(By.CssSelector(".registration-link-style")).Click();
            _driver.FindElement(By.CssSelector("#Login")).SendKeys("admin");
            _driver.FindElement(By.CssSelector("#Password")).SendKeys("admin");
            _driver.FindElement(By.CssSelector("#Name")).SendKeys("admin");
            Thread.Sleep(500);
            _driver.FindElement(By.CssSelector("#MobilePhone")).SendKeys("+79867540938");
            Thread.Sleep(500);
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(500);
            _driver.FindElement(By.CssSelector("#Login")).SendKeys("user39");
            _driver.FindElement(By.CssSelector("#Password")).SendKeys("user39");
            _driver.FindElement(By.CssSelector("#Name")).SendKeys("user39");
            Thread.Sleep(500);
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[@type='submit']")));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
