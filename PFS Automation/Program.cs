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
using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;


namespace PFS_Automation
{
    class Program
    {


      public  Workbook workbook;
        public  Worksheet worksheet;


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


            this.CreateExcel(5);
            //_Application excel = new _excel.Application();
          
            //workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //worksheet = (Worksheet)workbook.Worksheets[1];
            //worksheet.Cells[1, 1] = "No";
            //worksheet.Cells[1, 2] = "Time";

            //worksheet.Cells[2, 1] = 1;
            //worksheet.Cells[2, 2] = this.RecordCanvasloadTime();
            //PropertiesCollection.OpenTabs(1);
            //PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles[1]);
            //worksheet.Cells[3, 1] = 1;
            //worksheet.Cells[3, 2] = this.RecordCanvasloadTime();
            //workbook.SaveAs(@"C:\SysWOW64\config\systemprofile\desktop\test1.xlsx");
            //workbook.Close();
            // xlApp.Quit();

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
             MaterialPageObject t= new MaterialPageObject();
            t.UploadData();
            PropertiesCollection.Validatemessage( "Your update is now processing. You will recieve an email at 'romanpete404@gmail.com' when it is complete. Be sure to add 'SmartBuildFramerSupport@keymark.com' to your safe sender list so you dont miss it. ", "//*[@id='status']");
            System.Threading.Thread.Sleep(2000);

        }

        [Test]
        public Double RecordCanvasloadTime()
        {
           
            LoginPageObject login = new LoginPageObject();
            HomePageObject home;
            home = login.login("romanpete404@gmail.com", "Romanpete!");
            var start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            System.Threading.Thread.Sleep(5000);
            home.StartFromScratchbtn.Click();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(30));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath("//*[@id='drawingArea']"));
            });
            var finish = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine(finish - start);
            System.Threading.Thread.Sleep(3000);
            return finish - start;
        }
        public void CreateExcel(int n)
        {

            _Application excel = new _excel.Application();

            workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            worksheet = (Worksheet)workbook.Worksheets[1];
            worksheet.Cells[1, 1] = "No";
            worksheet.Cells[1, 2] = "Time";
            for (int i = 1; i <= n; i++)
            {
              
                worksheet.Cells[i+1, 1] = i;
                worksheet.Cells[i+1, 2] = this.RecordCanvasloadTime();
                    PropertiesCollection.OpenTabs(1);
                //    PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles[i-1]);
                //PropertiesCollection.driver.Navigate().GoToUrl("https://betapostframesolver.azurewebsites.net/Account/Login");
            }
            worksheet.Cells[n+2,1] = "Average";
            worksheet.Cells[n + 2, 2] = "=AVERAGE(B2:B" + (n+1) + ","+n+")";
            workbook.SaveAs(@"C:\SysWOW64\config\systemprofile\desktop\test11.xlsx");
            workbook.Close();
        }
            [TearDown]
        public void close()
        {
        PropertiesCollection.driver.Quit();
        }
    }
}
