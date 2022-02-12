using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Homework13.Core.Wrapper
{
    public class UIElement : IWebElement
    {
        private IWebElement _webElementImplementation;
        private IWebDriver _webDriver;
        private By _by;
        private Actions _actions;
        private IJavaScriptExecutor _javaScriptExecutor;

        public UIElement(IWebDriver driver, By by)
        {
            _webDriver = driver;
            _actions = new Actions(_webDriver);
            _javaScriptExecutor = (IJavaScriptExecutor)_webDriver;
            _by = by;
            _webElementImplementation = _webDriver.FindElement(by);
        }

        public UIElement(IWebDriver driver, IWebElement webElement)
        {
            _webDriver = driver;
            _actions = new Actions(_webDriver);
            _javaScriptExecutor = (IJavaScriptExecutor)_webDriver;
            _webElementImplementation = webElement;
        }

        public IWebElement FindElement(By @by)
        {
            return _webElementImplementation.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _webElementImplementation.FindElements(@by);
        }

        public void Clear() => _webElementImplementation.Clear();

        public void SendKeys(string text) => _webElementImplementation.SendKeys(text);

        public void Submit() => _webElementImplementation.Submit();

        public void Click()
        {
            try
            {
                _webElementImplementation.Click();
            }
            catch (Exception e)
            {
                try
                {
                    _actions
                        .MoveToElement(_webElementImplementation)
                        .Click()
                        .Build()
                        .Perform();
                }
                catch (Exception exception)
                {
                    _javaScriptExecutor.ExecuteScript("arguments[0].click();", _webElementImplementation);
                }
            }
        }

        public bool Active => GetAttribute("class").Contains("active") || GetAttribute("class").Contains("selected");

        public string GetAttribute(string attributeName) => _webElementImplementation.GetAttribute(attributeName);

        public string GetProperty(string propertyName) => _webElementImplementation.GetProperty(propertyName);

        public string GetCssValue(string propertyName) => _webElementImplementation.GetCssValue(propertyName);

        public void Hover()
        {
            // Do the action.
            _actions.MoveToElement(_webElementImplementation).Build().Perform();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public string TagName => _webElementImplementation.TagName;

        public string Text => _webElementImplementation.Text;

        public bool Enabled => _webElementImplementation.Enabled;

        public bool Selected => _webElementImplementation.Selected;

        public Point Location => _webElementImplementation.Location;

        public Size Size => _webElementImplementation.Size;

        public bool Displayed => _webElementImplementation.Displayed;
    }
}
