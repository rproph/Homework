using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace JSExecutor
{
    public class Tests
    {
        public WebDriver driver;
        public IJavaScriptExecutor executor;
        public WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            executor = (IJavaScriptExecutor)driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://catalog.onliner.by/tv");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            IWebElement checkbox1 = driver.FindElement(By.CssSelector(".schema-product__control:nth-child(1)"));

            checkbox1.Click();

            executor.ExecuteScript("window.scrollBy(0, 500)", "");

            IWebElement checkbox2 = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[3]/div/div[1]/div[1]/div/label"));

            checkbox2.Click();

            IWebElement button = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[3]/div/div[1]/div/div/div[1]/a[2]"));

            button.Click();

            IWebElement diag = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[2]/div/table/tbody[5]/tr[4]/td[1]"));

            diag.Click();

            IWebElement diagInfo = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[2]/div/table/tbody[5]/tr[4]/td[1]/div/span"));

            diagInfo.Click();

            try
            {
                IWebElement diagInfoWindow = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[3]/div"));
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail();
            }

            diagInfo.Click();

            IWebElement deleteButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[2]/div/table/tbody[2]/tr/th[3]/div/a"));

            deleteButton.Click();

            driver.Quit();
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://catalog.onliner.by/tv");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            string mainPage = driver.CurrentWindowHandle;

            IWebElement appleStoreLink = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[2]/div[2]/div[1]/div[2]/div[3]/div/a[1]"));
            IWebElement googlePlayLink = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[2]/div[2]/div[1]/div[2]/div[3]/div/a[2]"));

            appleStoreLink.Click();

            driver.SwitchTo().Window(mainPage);

            googlePlayLink.Click();

            ReadOnlyCollection<string> windows = driver.WindowHandles;

            if (driver.WindowHandles.Count != 3)
            {
                Assert.Fail();
            }

            driver.SwitchTo().Window(windows[2]);

            IWebElement googleMoreButton = wait.Until(e => e.FindElement(By.XPath("/html/body/div[1]/div[4]/c-wiz/div/div[2]/div/aside/c-wiz/c-wiz/c-wiz/div/div[1]/div[2]/a")));

            googleMoreButton.Click();

            ReadOnlyCollection<IWebElement> sameApps = driver.FindElements(By.ClassName("ImZGtf"));

            executor.ExecuteScript("console.log(" + sameApps.Count + ")");

            driver.SwitchTo().Window(windows[1]);

            IWebElement appleMoreButton = driver.FindElement(By.XPath("/html/body/div[5]/main/div[2]/section[3]/div/div/div/button"));

            appleMoreButton.Click();

            driver.Close();

            driver.SwitchTo().Window(windows[0]);

            IWebElement frame = driver.FindElement(By.Id("google_ads_iframe_/282428283/new_catalog_100x90_2_0"));

            driver.SwitchTo().Frame(frame);

            IWebElement frameLink = driver.FindElement(By.Id("aw0"));

            frameLink.Click();

            driver.Quit();
        }

        [Test]
        public void Test3()
        {
            driver.Navigate().GoToUrl("https://www.onliner.by/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement searchField = driver.FindElement(By.Name("query"));

            searchField.Click();

            searchField.SendKeys("тостер");

            IWebElement frame = driver.FindElement(By.ClassName("modal-iframe"));

            driver.SwitchTo().Frame(frame);

            string firstResultName = driver.FindElement(By.CssSelector(".product__title-link:nth-child(1)")).Text;

            IWebElement frameSearchField = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/input"));

            frameSearchField.Click();

            frameSearchField.Clear();

            frameSearchField.SendKeys(firstResultName);

            string matchResult = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/ul/li/div/div/div[2]/div/a")).Text;

            if (!firstResultName.Equals(matchResult))
            {
                Assert.Fail();
            }

            driver.Quit();
        }
    }
}