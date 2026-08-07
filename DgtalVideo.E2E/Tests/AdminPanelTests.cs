using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgtalVideo.Tests.E2E.Tests
{
    public class AdminPanelTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }
        [Test]
        public void AddMovie()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            _driver.Navigate().GoToUrl("https://localhost:7134/Auth/Login");
            _driver.FindElement(By.XPath("//input[@id='Login']")).SendKeys("admin");
            _driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("admin");
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            _driver.Navigate().GoToUrl("https://localhost:7134/AdminPanel/AdminPanel");
            executor.ExecuteScript("window.scrollBy(0, 1000);");
            Thread.Sleep(500);
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[@id='togglePortfolioForm']")));
            Thread.Sleep(500);
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[@data-close-form='portfolioCreateForm']")));
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[@id='togglePortfolioForm']")));
            Thread.Sleep(500); 
            _driver.FindElement(By.XPath("//input[@id='NewPortfolio_Title']")).SendKeys("Промо для альфа банка");
            _driver.FindElement(By.XPath("//input[@id='NewPortfolio_Category']")).SendKeys("Промо");
            _driver.FindElement(By.XPath("//textarea[@id='NewPortfolio_Description']")).SendKeys("Промо для альфа банка");
            _driver.FindElement(By.XPath("//input[@name='movie']")).SendKeys("/videos/alfa-bank.mp4");
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[contains(text(),'Сохранить работу')]")));
            Thread.Sleep(2000);
            executor.ExecuteScript("window.scrollBy(0, 1500);");
            Thread.Sleep(500);
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[@id='toggleReviewForm']")));
            Thread.Sleep(500);
            _driver.FindElement(By.XPath("//input[@id='NewReview_Name']")).SendKeys("Валерия С");
            _driver.FindElement(By.XPath("//input[@id='NewReview_ShortDescription']")).SendKeys("Видеограф");
            _driver.FindElement(By.XPath("//input[@id='NewReview_ShortDescription']")).SendKeys("Делают очень качественно");
            executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath("//button[contains(text(),'Сохранить отзыв')]")));
            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
