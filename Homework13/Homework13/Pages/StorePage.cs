using System;
using OpenQA.Selenium;
using Homework13.BaseEntities;

namespace Homework13.Pages
{
    public class StorePage : BasePage
    {
        private static string END_POINT = "inventory.html";

        // Описание элементов
        public static readonly By Shopping_Cart_LinkBy = By.ClassName("shopping_cart_link");
        public static readonly By Menu_ButtonBy = By.Id("react-burger-menu-btn");
        public static readonly By Product_Sort_ContainerBy = By.Id("product_sort_container");

        // Инициализация класса
        public StorePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public StorePage(IWebDriver driver) : base(driver, false)
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
                return Menu_Button.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Методы
        public static IWebElement Shopping_Cart_Link => Driver.FindElement(Shopping_Cart_LinkBy);
        public static IWebElement Menu_Button => Driver.FindElement(Menu_ButtonBy);
        public static IWebElement Product_Sort_Container => Driver.FindElement(Product_Sort_ContainerBy);

    }
}
