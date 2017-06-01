using System;
using AutomationTestingFramework;
using AutomationTestingFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkTests
{
    [TestClass]
    public class LoginPageTests
    {

        [TestInitialize]
        public void Initialize()
        {
            Browser.CreateDriver(Browsers.Chrome);
            Browser.GoTo(@"http://www.qtptutorial.net/automation-practice/");
            AutomationTestingPracticePage.LoginButtonClick();
        }

        [TestMethod]
        public void LoginWhenValidUserNameAndValidPassword()
        {
            Assert.IsTrue(LoginPage.IsAt());
            LoginPage.PerformLoginOperationWithValidData("veronikakats", "180895Vira");
        }

        [TestMethod]
        public void LoginWhenValidUserNameAndInvalidPassword()
        {
            Assert.IsTrue(LoginPage.IsAt());
            LoginPage.PerformLoginOperationWithInValidData("veronikakats", "180895vira");
        }

        [TestMethod]
        public void TestIfEditPageIsOpened()
        {
            LoginPage.EditProfileOperation();
        }


        [TestCleanup]
        public void QuitBrowser()
        {
            Browser.Driver.Quit();
            //Browser.Driver.Close();
        }



    }
}
