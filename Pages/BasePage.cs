using FluentAssertions;
using Guru99.Interfaces;
using Guru99.TestsInfo;
using OpenQA.Selenium;

namespace Guru99.Pages
{
    public abstract class BasePage : IPages
    {

        protected IWebDriver _driver { get; set; }
        protected string _url { get; set; }
        protected string _value { get; set; }
        protected Logger logger { get; set; }

        protected bool _selected { get; set; }
        protected void SetUrl(string url)
        {
            _url = url;
        }
        public void OpenPage(string url)
        {
            SetUrl(url);
            _driver.Navigate().GoToUrl(_url);
            logger.LogInfo($"The {url} is opened");
        }
        public IPages GetAttributeValue(IWebElement e, string attribute)
        {
            _value = e.GetAttribute(attribute);
            return this;

        }
        public IPages FixFormat(string actualString, string desiredString)
        {
            _value = _value.Replace(actualString, actualString);
            return this;
        }

        public string GetActualText()
        {
            return _value;
        }
        public IPages ElementIsSelected(IWebElement e)
        {
            _selected = e.Selected;
            return this;
        }

        public IPages True()
        {
            _selected.Should().BeTrue();
            return this;
        }

        public void SetLoggerInstance(Logger log)
        {
            logger = log;
        }

    }
}
