using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System.Configuration;

namespace Guru99.TestsInfo
{
    class Reporter
    {
        private string currentTestName = TestContext.CurrentContext.Test.Name;
        private ExtentReports extent;
        private ExtentHtmlReporter htmlReporter;
        private ExtentTest test;
        private readonly string path = ConfigurationManager.AppSettings["Guru99.Report.Path"];
        public void CreateReport()
        {
            extent = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent.AttachReporter(htmlReporter);
        }
        public void StartReport()
        {
             test = extent.CreateTest(currentTestName).Info("Test is started");
        }
        public void EndReport()
        {
            extent.Flush();
        }
    }
}
