using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Homework13.BaseEntities
{
    public class BaseTest
    {
        public static string BaseURL = "https://www.saucedemo.com/";
        [ThreadStatic] protected static IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
