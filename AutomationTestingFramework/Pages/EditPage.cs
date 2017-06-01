using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingFramework.Pages
{
    class EditPage
    {
        private static IWebElement _PageTitleName
        {
            get { return Browser.FindElementInPage(ElementIdentifier.XPath, "//h1[contains(text(),'Edit Profile')]"); }
        }

        public static bool IsAt()
        {
            if (_PageTitleName.Displayed)
                return true;
            else
                return false;
        }
    }
}
