using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PFS_Automation.pages;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;

namespace PFS_Automation
{
    class Program
    {
       


        [SetUp]

      public void Initialize()
        {
           PropertiesCollection.driver = new OperaDriver();
           PropertiesCollection.driver.Manage().Window.Maximize();
           PropertiesCollection.driver.Navigate().GoToUrl("https://betapostframesolver.azurewebsites.net/Account/Login");
        }

        [Test]

      public void CreateJOB()
        { 
            LoginPageObject login = new LoginPageObject();
            HomePageObject home;
            home =login.login("badarsuhail147@gmail.com", "Badarsuhail!");
            home.StartFromScratchbtn.Click();
            CreateJobPage jobpage = new CreateJobPage();
            System.Threading.Thread.Sleep(20000);
            jobpage.jobreview.Click();
            jobpage.doors.Click();
            try
            {
                jobpage.qty = PropertiesCollection.driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[5]/div[4]/div/div[5]/div[4]/div/div/div[3]/div[1]/table/tbody/tr[3]/td[5]/div")).Text;
                jobpage.InsertAndverifyDoor();
                jobpage.InsertAndVerifyPorche();
               
            }
            catch
            {
                jobpage.InsertAndverifyDoor();
                jobpage.InsertAndVerifyPorche();
                
            }
        }
        [TearDown]
        public void close()
        {
         PropertiesCollection.driver.Quit();
        }
    }
}
