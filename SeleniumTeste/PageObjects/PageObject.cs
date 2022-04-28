using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTeste.Drivers;

namespace SeleniumTeste.PageObjects
{
    public class PageObject
    {
        private const string Url = "https://blogdoagi.com.br/";

        private readonly IWebDriver _webDriver;
        

        public PageObject(BrowserDriver webDriver)
        {
            _webDriver = webDriver.Current;
        }


        private IWebElement _searchButton => _webDriver.FindElement(By.XPath("//button[@id='search-open']"));
        private IWebElement _searchInput => _webDriver.FindElement(By.XPath(
            "//div[@class='desktop-search']//input[@class='search-field']"));
        

        public void PreSettings()
        {
            if (_webDriver.Url != Url)
            {
                _webDriver.Url = Url;
            }

            _webDriver.Manage().Window.Maximize();
        }

        public void FinishSettings()
        {
            _webDriver.Manage().Cookies.DeleteAllCookies();
        }

        public void InputSearch(string value)
        {
            _searchButton.Click();
            _searchInput.SendKeys(value);
        }

        public void SubmitSearch()
        {
            _searchInput.Submit();
        }

        public bool VerifyArticleWithSnippet(string snippet)
        => _webDriver.FindElement(By.XPath($"//article//h2[contains(.,'{snippet}')]")).Enabled;
        
        public bool VerifyFoundArticles()
            => _webDriver.FindElements(By.XPath($"//article")).Count > 1;

    }
}