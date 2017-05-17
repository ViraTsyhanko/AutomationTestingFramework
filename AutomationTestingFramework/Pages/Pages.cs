using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTestingFramework.Pages
{
    public class Pages
    {
        public static T PageInitializer<T>() where T: new ()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static LoginPage Login
        {
            get { return PageInitializer<LoginPage>(); }
        }
    }
}
