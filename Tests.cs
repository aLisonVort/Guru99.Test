using FluentAssertions;
using Guru99.Pages;
using Guru99.TestsInfo;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;

namespace Guru99
{
    [TestFixture]
    public class Tests
    {
        DriverOperations operations;
        IWebDriver driver { get; set; }
        Reporter reporter = new Reporter();
        Logger log;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            reporter.CreateReport();
            operations = new DriverOperations();
            driver = operations.OneTimeInitialize();
            log = new Logger();
            log.Initialize();
            
        }

        [SetUp]
        public void SetUp()
        {
            log.BeforeTets();
        }

        [Test, Order(1)]
        public void UploadFile()
        {
            reporter.StartReport();
            var uploadPage = new FileUploadingPage(driver, log);
            uploadPage.OpenPage("http://demo.guru99.com/test/upload/");
            uploadPage.UploadFile();
            var messageEl = uploadPage.GetMessageElement();
            uploadPage.GetAttributeValue(messageEl, "innerText").FixFormat("\r\n", " ");
            string actualText = uploadPage.GetActualText();
            string expectedText = uploadPage.GetExpectedText();
            actualText.Should().Be(expectedText);
        }

        [Test, Order(2)]
        public void SelectRadioButton()
        {
            reporter.StartReport();
            var pageURL = (ConfigurationManager.AppSettings.Get("initUrl"));
            var radioButtonPage = new RadioButtonPage(driver, log);
            radioButtonPage.OpenPage(pageURL);
            radioButtonPage.SelectOption();
            var option1 = radioButtonPage.GetOptionElement();
            radioButtonPage.ElementIsSelected(option1).True();
        }

        [TearDown]
        public void TearDown()
        {
            log.AfterTest();
            operations.CleanUp();

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            reporter.EndReport();
            operations.KillDriverInstance();
        }
    }
}
