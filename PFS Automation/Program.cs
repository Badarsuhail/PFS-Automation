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
using Assert = NUnit.Framework.Assert;
using System.Linq;

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

        public void MultipleTabs()

        {
            System.Threading.Thread.Sleep(2000);

            PropertiesCollection.OpenTabs(3);
            //String test_url = "https://betapostframesolver.azurewebsites.net/Account/Login";
            //WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            //PropertiesCollection.driver.Url = test_url;
            //var browser_button = PropertiesCollection.driver.FindElement(By.XPath("//a[.='Click Here']"));
            //Assert.AreEqual(1, PropertiesCollection.driver.WindowHandles.Count);
            //string WindowTitle = "The Internet";
            //Assert.AreEqual(WindowTitle, PropertiesCollection.driver.Title);
            //browser_button.Click();
            //Assert.AreEqual(2, PropertiesCollection.driver.WindowHandles.Count);
            //Console.WriteLine("Window Handle[0] - " + PropertiesCollection.driver.WindowHandles[0]);
            //var newTabHandle = PropertiesCollection.driver.WindowHandles[1];
            //Assert.IsTrue(!string.IsNullOrEmpty(newTabHandle));
            //Console.WriteLine("Window Handle[1] - " + PropertiesCollection.driver.WindowHandles[1]);
            //Assert.AreEqual(PropertiesCollection.driver.SwitchTo().Window(newTabHandle).Url, "https://betapostframesolver.azurewebsites.net/Account/Login");
            //System.Threading.Thread.Sleep(2000);
            //PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles[1]).Close();
            //PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles[0]);
            //System.Threading.Thread.Sleep(2000);

        }

 

        [Test]

        public void Login()
        {
            LoginPageObject login = new LoginPageObject();
            login.login("romanpete404@gmail.com", "Romanpete!");
            Assert.IsTrue(PropertiesCollection.Validateurl("https://betapostframesolver.azurewebsites.net/"));
        }

        [Test]
      public void CreateJOB()
        {
            LoginPageObject login = new LoginPageObject();
            login.login("romanpete404@gmail.com", "Romanpete!");
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            PropertiesCollection.driver.Navigate().GoToUrl("https://betapostframesolver.azurewebsites.net/Framer/Create/0");
            CreateJobPage jobpage = new CreateJobPage();
            IWebElement jobr = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath("//*[@id='drawingArea']"));
            });
            System.Threading.Thread.Sleep(5000);
            jobpage.jobreview.Click();
            System.Threading.Thread.Sleep(5000);
            jobpage.doors.Click();
            try
            {
                jobpage.qty = PropertiesCollection.driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[5]/div[4]/div/div[5]/div[4]/div/div/div[3]/div[1]/table/tbody/tr[3]/td[5]/div")).Text;
                jobpage.InsertAndverifyDoor();
               

            }
            catch
            {
                jobpage.InsertAndverifyDoor();
            }
            jobpage.SaveJobAndVerify("test");

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
            System.Threading.Thread.Sleep(2000);

        }

        [Test]
        public void RecordCanvasloadTime()
        {
           
            LoginPageObject login = new LoginPageObject();
            HomePageObject home;
            home = login.login("romanpete404@gmail.com", "Romanpete!");
            var start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            System.Threading.Thread.Sleep(5000);
            home.StartFromScratchbtn.Click();
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
