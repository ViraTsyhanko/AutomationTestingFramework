using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTestingFramework.Pages
{
    public class LoginPage
    {
        private static IWebElement _PageIdentifierElement
        {
            get { return Browser.FindElementInPage(ElementIdentifier.XPath, "//*[@title='QTPtutorial.net Logo']"); }
        }
        private static IWebElement _LoginField
        {
            get { return Browser.FindElementInPage(ElementIdentifier.Id, "user_login"); }
        }

        private static IWebElement _PasswordField
        {
            get { return Browser.FindElementInPage(ElementIdentifier.Id, "user_pass"); }
        }

        private static IWebElement _LoginButton
        {
            get { return Browser.FindElementInPage(ElementIdentifier.Id, "wp-submit"); }
        }

        public static bool IsAt()
        {
            if (_PageIdentifierElement.Displayed)
                return true;
            return false;
        }

        public static void PerformLoginOperation(string loginData, string password)
        {
            Browser.FindElementInPage(ElementIdentifier.XPath, ".//*[@class='close-overlay overlay-text']").Click();
            _LoginField.SendKeys(loginData);
            _PasswordField.SendKeys(password);
            _LoginButton.Click();
        }
    }
}
