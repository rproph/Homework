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

        public void LogIn(string username, string password)
        {
            var logInPage = new LoginPage(Driver, true);

            logInPage.Input_UserName.SendKeys(username);
            logInPage.Input_Password.SendKeys(password);
            logInPage.Button_LogIn.Click();
        }
    }
}
