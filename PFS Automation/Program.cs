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
                jobpage.InsertWindows();
                jobpage.InsertSlider();
               
            }
            catch
            {
                jobpage.InsertAndverifyDoor();
                jobpage.InsertAndVerifyPorche();
                jobpage.InsertWindows();
                jobpage.InsertSlider();
                
            }
        }
       
        [Test]
        public void uploadfile()
        {
            LoginPageObject login = new LoginPageObject();
            HomePageObject home;
            home = login.login("romanpete404@gmail.com", "Romanpete!");
            home.settingbtn.Click();
            home.materialbtn.Click();
             TrussesPageObject t= new TrussesPageObject();
            t.UploadData();
            PropertiesCollection.Validatemessage( "Your update is now processing. You will recieve an email at 'romanpete404@gmail.com' when it is complete. Be sure to add 'SmartBuildFramerSupport@keymark.com' to your safe sender list so you dont miss it. ", "//*[@id='status']");

        }
        [TearDown]
        public void close()
        {
        PropertiesCollection.driver.Quit();
        }
    }
}
