using OpenQA.Selenium;
using Homework13.BaseEntities;
using Homework13.Pages;

namespace Homework13.Steps
{
    public class LogInSteps : BaseStep
    {
        public LogInSteps(IWebDriver driver) : base(driver)
        {
        }

        public void LogIn()
        {
            var logInPage = new LoginPage(Driver, true);

            logInPage.Input_UserName.SendKeys("standard_user");
            logInPage.Input_Password.SendKeys("secret_sauce");
            logInPage.Button_LogIn.Click();
        }
    }
}
