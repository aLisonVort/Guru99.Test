using Guru99.TestsInfo;
using OpenQA.Selenium;
using System.Configuration;
namespace Guru99.Pages
{
    class FileUploadingPage: BasePage
    {
        private IWebElement chooseFileButton => _driver.FindElement(By.Id("uploadfile_0"));
        private IWebElement submitButton => _driver.FindElement(By.Id("submitbutton"));
        private IWebElement message => _driver.FindElement(By.XPath("//h3[@id = 'res']/center"));

        private string expectedText = ConfigurationManager.AppSettings.Get("expectedMessage");
        private string location = ConfigurationManager.AppSettings["fileLocation"];
        public FileUploadingPage(IWebDriver driver, Logger logger) 
        {
            _driver = driver;
            SetLoggerInstance(logger);
        }

        public void UploadFile()
        {
            chooseFileButton.SendKeys(location);
            logger.LogInfo("File is attached");
            submitButton.Click();
        }
        public string GetExpectedText()
        {
            return expectedText;
        }

        public IWebElement GetMessageElement()
        {
            return message;
        }
    }
}
