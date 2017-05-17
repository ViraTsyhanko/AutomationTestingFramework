using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationTestingFramework.Pages
{
    public class MyMembershipPage
    {
        private static IWebElement _PageIdentifierElement
        {
            get { return Browser.FindElementInPage(ElementIdentifier.XPath, "//h1[contains(text(),'My Membership')]"); }
        }

        public static bool IsAt()
        {
            if (_PageIdentifierElement.Displayed)
                return true;
            return false;
        }
    }
}
