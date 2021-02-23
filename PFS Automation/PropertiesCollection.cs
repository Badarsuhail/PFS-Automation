using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            return (driver.FindElement(By.CssSelector(element)).Text == msg);
        }
       
    }
}

