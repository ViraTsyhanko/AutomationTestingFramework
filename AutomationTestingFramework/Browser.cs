using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestingFramework
{
    public enum ElementIdentifier
    {
        ClassName,
        CssCelector,
        Id,
        LinkText,
        Name,
        PartialLinkText,
        TagName,
        XPath,
    }

    public enum Browsers
    {
        Chrome,
        Firefox,
        Ie
    }

    public static class Browser
    {

        public static IWebDriver Driver { get; set; }

        public static void CreateDriver(Browsers br)
        {
            switch (br)
            {
                case Browsers.Chrome:
                {
                    Driver = new ChromeDriver();
                    break;
                }

                case Browsers.Firefox:
                {
                    Driver = new FirefoxDriver();
                    break;
                }

                case Browsers.Ie:
                {
                    Driver = new InternetExplorerDriver();
                    break;
                }
                default:
                    Console.WriteLine("There is no such browser");
                    break;
            }
        }

        public static void GoTo(string url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElementInPage(ElementIdentifier elementIdentifier, string value)
        {
            switch (elementIdentifier)
            {
                case ElementIdentifier.Id:
                {
                    return FindElementWithWait(By.Id(value));
                }

                case ElementIdentifier.XPath:
                {
                    return FindElementWithWait(By.XPath(value));
                }
                case ElementIdentifier.Name:
                {
                    return FindElementWithWait(By.Name(value));
                }
                case ElementIdentifier.ClassName:
                {
                    return FindElementWithWait(By.ClassName(value));
                }
                case ElementIdentifier.CssCelector:
                {
                    return FindElementWithWait(By.CssSelector(value));
                }
                case ElementIdentifier.LinkText:
                {
                    return FindElementWithWait(By.LinkText(value));

                }
                case ElementIdentifier.PartialLinkText:
                {
                    return FindElementWithWait(By.PartialLinkText(value));
                }
                case ElementIdentifier.TagName:
                {
                    return FindElementWithWait(By.TagName(value));
                }
                default:
                    return null;
            }
        }

        private static IWebElement FindElementWithWait(By by)
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(by));
            return myDynamicElement;
        }
    }
}


