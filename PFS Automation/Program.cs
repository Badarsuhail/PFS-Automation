using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using PFS_Automation.pages;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;

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
          //  PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]

      public void CreateJOB()
        {
            CreateJobPage jobpage = new CreateJobPage();
            LoginPageObject login = new LoginPageObject();
            HomePageObject home;
            home = login.login("badarsuhail147@gmail.com", "Badarsuhail!");
            home.StartFromScratchbtn.Click();
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

        [Test]
        public void RecordCanvasloadTime()
        {
           
            LoginPageObject login = new LoginPageObject();
            HomePageObject home;
            home = login.login("badarsuhail147@gmail.com", "Badarsuhail!");
            System.Threading.Thread.Sleep(3000);
            home.largemodal.Click();
            var start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath("//*[@id='drawingArea']"));
            });
            var finish = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine(finish - start);
        }
        [TearDown]
        public void close()
        {
        PropertiesCollection.driver.Quit();
        }
    }
}
