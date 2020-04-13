using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Guru99
{
    class DriverOperations
    {
        public IWebDriver _driver { get; set; }
        public IWebDriver OneTimeInitialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return GetDriverInstance();
            
        }
        
        public void CleanUp()
        {
            string testStatus = GetTestStatus();
            string testName = GetTestName();
            Console.WriteLine($"Test status of {testName} is {testStatus}");
            Console.WriteLine("-------------"); 
        }
        public void KillDriverInstance()
        {
            _driver.Quit();
        }
        public string GetTestName()
        {
            return TestContext.CurrentContext.Test.Name;
        }

        public string GetTestStatus()
        {
            return TestContext.CurrentContext.Result.Outcome.Status.ToString();
        }
        public IWebDriver GetDriverInstance()
        {
            return _driver;
        }
    }
}
