using System;
using OpenQA.Selenium;
using Homework13.BaseEntities;

namespace Homework13.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов
        private static readonly By Input_UserNameBy = By.Id("user-name");
        private static readonly By Input_PasswordBy = By.Id("password");
        private static readonly By Button_LogInBy = By.Id("login-button");

        // Инициализация класса
        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseURL + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Button_LogIn.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Методы
        public IWebElement Input_UserName => Driver.FindElement(Input_UserNameBy);
        public IWebElement Input_Password => Driver.FindElement(Input_PasswordBy);
        public IWebElement Button_LogIn => Driver.FindElement(Button_LogInBy);
    }
}
