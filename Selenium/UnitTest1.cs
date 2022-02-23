using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://calc.by/building-calculators/laminate.html");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement layingMethod = driver.FindElement(By.Id("laying_method_laminate"));
            SelectElement select = new SelectElement(layingMethod);
            select.SelectByValue("2");

            IWebElement roomLength = driver.FindElement(By.Id("ln_room_id"));
            roomLength.Click();
            roomLength.Clear();
            roomLength.SendKeys("500");

            IWebElement roomWidth = driver.FindElement(By.Id("wd_room_id"));
            roomWidth.Click();
            roomWidth.Clear();
            roomWidth.SendKeys("400");

            IWebElement lmLength = driver.FindElement(By.Id("ln_lam_id"));
            lmLength.Click();
            lmLength.Clear();
            lmLength.SendKeys("2000");

            IWebElement lmWidth = driver.FindElement(By.Id("wd_lam_id"));
            lmWidth.Click();
            lmWidth.Clear();
            lmWidth.SendKeys("200");

            IWebElement lmDirection = driver.FindElement(By.Id("direction-laminate-id1"));
            lmDirection.Click();

            IWebElement button = driver.FindElement(By.LinkText("Рассчитать"));
            button.Click();

            String plankCount = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[1]/div[3]/article/section/div[2]/div[3]/div[2]/div[1]/span")).GetAttribute("innerHTML");
            String plankPackageCount = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[1]/div[3]/article/section/div[2]/div[3]/div[2]/div[2]/span")).GetAttribute("innerHTML");
            
            if ((plankCount.Equals("53")) && plankPackageCount.Equals("7"))
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://www.calc.ru/kalkulyator-kalorii.html");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement age = driver.FindElement(By.Id("age"));
            age.Click();
            age.SendKeys("35");

            IWebElement weight = driver.FindElement(By.Id("weight"));
            weight.Click();
            weight.SendKeys("85");

            IWebElement height = driver.FindElement(By.Id("sm"));
            height.Click();
            height.SendKeys("185");

            IWebElement physicalActivity = driver.FindElement(By.Id("activity"));
            SelectElement select = new SelectElement(physicalActivity);
            select.SelectByValue("1.4625");

            IWebElement button = driver.FindElement(By.Id("submit"));
            button.Click();

            string result = driver.FindElement(By.XPath("//td[contains(text(), '3028 ккал/день')]")).GetAttribute("innerHTML");

            if (result.Trim().Equals("3028 ккал/день"))
            {
                driver.Quit();
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
