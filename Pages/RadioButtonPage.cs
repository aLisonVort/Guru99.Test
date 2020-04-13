using Guru99.TestsInfo;
using OpenQA.Selenium;
using System.Threading;

namespace Guru99.Pages
{
    class RadioButtonPage : BasePage
    {
       private IWebElement option1 => _driver.FindElement(By.Id("vfb-7-1"));

        public void SelectOption()
        {
            Thread.Sleep(3000);
            option1.Click();
        }
        public IWebElement GetOptionElement()
        {
            return option1;
        }
        public RadioButtonPage(IWebDriver driver, Logger logger) 
        {
            _driver = driver;
            SetLoggerInstance(logger);
        }
    }
}
