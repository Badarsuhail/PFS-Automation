using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;


namespace PFS_Automation.pages
{
    class HomePageObject
    {
        public HomePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/ul/li[1]/a")]
        public IWebElement StartFromScratchbtn { get; set; }
        //[FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        //public IWebElement Upassword { get; set; }
        //[FindsBy(How = How.XPath, Using = "//*[@id='loginForm']/form/div[4]/div/input")]
        //public IWebElement Loginbtn { get; set; }


      
    }

}