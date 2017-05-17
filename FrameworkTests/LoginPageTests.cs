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
            LoginPage.PerformLoginOperation("veronikakats", "180895Vira");
            Assert.IsTrue(MyMembershipPage.IsAt());
            Console.WriteLine("User successfully loggedin ang is in MyMembershipPage");
        }

        [TestMethod]
        public void LoginWhenValidUserNameAndInvalidPassword()
        {
            Assert.IsTrue(LoginPage.IsAt());
            LoginPage.PerformLoginOperation("veronikakats", "180895vira");
            Assert.IsTrue(LoginPage.IsAt());
            Console.WriteLine("User is not loggedin ang is not in MyMembershipPage");
        }


        [TestCleanup]
        public void QuitBrowser()
        {
            Browser.Driver.Quit();
            //Browser.Driver.Close();
        }



    }
}
