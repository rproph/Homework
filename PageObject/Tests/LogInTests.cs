using NUnit.Framework;
using OpenQA.Selenium;
using Homework13.BaseEntities;
using Homework13.Pages;
using Homework13.Steps;
using System.Threading;

namespace Homework13
{
    [Parallelizable(ParallelScope.All)]
    public class LogInTests : BaseTest
    {
        LogInSteps steps;

        [SetUp]
        public void SetUp()
        {
            steps = new LogInSteps(Driver);
        }

        [OneTimeTearDown]
        public void OneTImeTearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void LogInTest1()
        {
            steps.LogIn("standard_user", "secret_sauce");
            Thread.Sleep(500);

            if (Driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[1]/div[3]/a")).Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LogInTest2()
        {
            steps.LogIn("", "secret_sauce");

            Thread.Sleep(500);

            if (Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3[text() = 'Epic sadface: Username is required']")).Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LogInTest3()
        {
            steps.LogIn("", "");

            Thread.Sleep(500);

            if (Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3[text() = 'Epic sadface: Username is required']")).Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LogInTest4()
        {
            steps.LogIn("standard_user", "");

            Thread.Sleep(500);

            if (Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3[text() = 'Epic sadface: Password is required']")).Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LogInTest5()
        {
            steps.LogIn("standard", "secr");

            Thread.Sleep(500);

            if (Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3[text() = 'Epic sadface: Username and password do not match any user in this service']")).Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LogInTest6()
        {
            steps.LogIn("standard_user", "secr");

            Thread.Sleep(500);

            if (Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3[text() = 'Epic sadface: Username and password do not match any user in this service']")).Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void LogInTest7()
        {
            steps.LogIn("stan", "secret_sauce");

            Thread.Sleep(500);

            if (Driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3[text() = 'Epic sadface: Username and password do not match any user in this service']")).Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
