using OpenQA.Selenium;

namespace Homework13.Core.Wrapper
{
    public class Button
    {
        private UIElement _uiElement;

        public Button(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
        }

        public void Click()
        {
            // Do the Action.
            _uiElement.Click();
            // Do unique Button action.
        }

        public bool Enabled => _uiElement.Enabled;
        public bool Displayed => _uiElement.Displayed;
    }
}
