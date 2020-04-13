using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using NUnit.Framework;
using System.Configuration;

namespace Guru99.TestsInfo
{
    public class Logger
    {
        private ILog logger { get; set; }
        private string testName = TestContext.CurrentContext.Test.Name;
        private readonly string logFilePath = ConfigurationManager.AppSettings["Guru99.Logger.LogFilePath"];
        public ILog SetUpLogger()
        {
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = ConfigurationManager.AppSettings.Get("converionPattern");
            patternLayout.ActivateOptions();


            var fileAppender = new FileAppender()
            {
                Name = "fileAppender",
                Layout = patternLayout,
                Threshold = Level.All,
                AppendToFile = true,
                File = logFilePath,
            };
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);
            ILog _logger = LogManager.GetLogger(typeof(Logger));
            return _logger;
        }

        public void Initialize()
        {
            logger = SetUpLogger();
        }
        public void BeforeTets()
        {
            logger.Info(TestContext.CurrentContext.Result.Outcome.Site +" Set Up is done" );
        }
        public ILog GetLogger()
        {
            return logger;
        }
        public void AfterTest()
        {
            var getStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var status = getStatus.ToString();
            logger.Info(getStatus);

            var label = TestContext.CurrentContext.Result.Outcome.Label;
            logger.Info(TestContext.CurrentContext.Result.Outcome.Site);
            if (status == "Failed" && label == "empty")
                logger.Error($"Test assertion {testName} is failed");
            else if (status == "Fauled" && label == "Error")
                logger.Error(" an unexpected exception occurred");
            else if (status == "Passed")
                logger.Info($"{testName} is passed");
            logger.Info(" Tear down is done");
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
    }
}
