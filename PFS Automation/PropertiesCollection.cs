using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFS_Automation
{
    //enum PropertyType
    //{
    //    Id,
    //    Name,
    //    LinktText,
    //    CssName,
    //    ClassName,
    //    XPath
    //}
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }


        public static Boolean Validateurl(string exp)
        {
            return (driver.Url == exp);
       
        }
        public static Boolean Validatemessage(String msg, string element)
        {
            return (driver.FindElement(By.XPath(element)).Text == msg);
        }
        public static void OpenTabs(int n)
        {
            for(int i=0;i<n;i++)
            {
                ((IJavaScriptExecutor)PropertiesCollection.driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());
                driver.Navigate().GoToUrl("https://betapostframesolver.azurewebsites.net/Account/Login");

            }
        }
       
    }
}

