using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Locators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\file.html"));
            Thread.Sleep(5000);

            string locator = driver.FindElement(By.CssSelector("div:nth-child(4) span:nth-child(3)")).Text;

            Console.WriteLine(locator);

            IWebElement arrow = driver.FindElement(By.ClassName("arrow"));
            IWebElement id123 = driver.FindElement(By.Id("123"));

            ReadOnlyCollection<IWebElement> spanChild = driver.FindElements(By.CssSelector("h1 span"));
            ReadOnlyCollection<IWebElement> spanValue = driver.FindElements(By.CssSelector("span"));

            List<IWebElement> spanValue12 = new List<IWebElement>();

            foreach (IWebElement element in spanValue)
            {
                if (element.GetAttribute("value") == null)
                {
                    continue;
                }
                else if (element.GetAttribute("value").Contains("12"))
                {
                    spanValue12.Add(element);
                }
            }

            Console.WriteLine(spanValue12[1].GetAttribute("value"));

            string containsTest = driver.FindElement(By.XPath("(//span)[2][contains(text(), 'Test')]")).Text;
            Console.WriteLine(containsTest);

            string containsIds = driver.FindElement(By.XPath("//span[Text() = 'Test'][@ids]")).Text;
            Console.WriteLine(containsIds);

            string title = driver.FindElement(By.XPath("//tag[text() = 'Title 2']")).Text;
            Console.WriteLine(title);


            string h1 = driver.FindElement(By.XPath("//h1[text() = 'Title 3']")).Text;
            Console.WriteLine(h1);

            string arrow2 = driver.FindElement(By.XPath("//span[text() = 'Title 2']/../../tag[@class = 'arrow'][2]")).Text;
            Console.WriteLine(arrow2);

            driver.Quit();
        }
    }
}
