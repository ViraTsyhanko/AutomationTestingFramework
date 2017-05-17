using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingFramework.Pages
{
    public class AutomationTestingPracticePage
    {
        private static IWebElement _PageIdentifierElement
        {
            get
            {
                return Browser.FindElementInPage(ElementIdentifier.XPath,
              "//h1[contains(text(),'Automation Testing Practice Page')]");
            }
        }

        private static IWebElement _LoginButton
        {
            get
            {
                return Browser.FindElementInPage(ElementIdentifier.CssCelector,
                    "[class=et_pb_promo_button][href='/wp-login.php']");
            }
        }

        public static bool IsAt()
        {
            if (_PageIdentifierElement.Displayed)
                return true;
            return false;
        }

        public static void LoginButtonClick()
        {
            _LoginButton.SendKeys(Keys.Return);
        }
    }
}
