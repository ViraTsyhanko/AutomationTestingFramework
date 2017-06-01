using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTestingFramework.Pages
{
    public class LoginPage
    {
        #region ElementsLocators

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

        private static IWebElement _ErrorMax
        {
            get { return Browser.FindElementInPage(ElementIdentifier.XPath, "//div[contains(text(),'Max')]"); }
        }

        private static IWebElement _ErrorWhenInvalidData
        {
            get { return Browser.FindElementInPage(ElementIdentifier.XPath, "//*[contains(text(),'ERROR')]"); }
        }

        private static IWebElement _EditBtn
        {
            get { return Browser.FindElementInPage(ElementIdentifier.CssCelector, "[href='/edit-profile/']"); }
        }

        #endregion

        public static bool IsAt()
        {
            if (_PageIdentifierElement.Displayed)
                return true;
            return false;
        }

        public static void PerformLoginOperationWithInValidData(string loginData, string password)
        {
            Browser.FindElementInPage(ElementIdentifier.XPath, ".//*[@class='close-overlay overlay-text']").Click();
            _LoginField.SendKeys(loginData);
            _PasswordField.SendKeys(password);
            _LoginButton.Click();
            Assert.IsTrue(_ErrorWhenInvalidData.Displayed);
            Console.WriteLine("User is not loggedin ang is not in MyMembershipPage");
        }

        public static void PerformLoginOperationWithValidData(string loginData, string password)
        {
            Browser.FindElementInPage(ElementIdentifier.XPath, ".//*[@class='close-overlay overlay-text']").Click();
            _LoginField.SendKeys(loginData);
            _PasswordField.SendKeys(password);
            _LoginButton.Click();
            Assert.IsTrue(MyMembershipPage.IsAt());
            Console.WriteLine("User successfully loggedin ang is in MyMembershipPage");
        }

        public static void EditProfileOperation()
        {
            PerformLoginOperationWithValidData("veronikakats", "180895Vira");
            _EditBtn.SendKeys(Keys.Return);
            Browser.SwitchTabs(1);
            Assert.IsTrue(EditPage.IsAt());

        }
    }
}
