using Guru99.Pages;
using Guru99.TestsInfo;
using OpenQA.Selenium;

namespace Guru99.Interfaces
{
    public interface IPages
    {
        IPages GetAttributeValue(IWebElement e, string attribute);
        IPages FixFormat(string actual, string desired);
        IPages ElementIsSelected(IWebElement e);
        IPages True();
        void SetLoggerInstance(Logger logger);
    }
}
