using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace PFS_Automation.pages
{
    class CreateJobPage
    {
       public string qty = "";
        public CreateJobPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);

        }
        [FindsBy(How = How.XPath, Using = "//*[@id='tabs_myForm_tabs_tab_tab5']/div")]
        public IWebElement Jobbtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='ProjectName']")]
        public IWebElement NameTxt { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Phone']")]
        public IWebElement PhoneTxt { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='tb_editToolbar_item_save']")]
        public IWebElement Savebtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='tb_editToolbar_item_cancel']")]
        public IWebElement Homebtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='tb_view3dToolbar_item_item3a']/table/tbody/tr/td/table/tbody/tr/td[2]")]
        public IWebElement doorbtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='drawingArea']")]
        public IWebElement canvas { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div")]
        public IWebElement cancelbtn { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div[1]/div[4]/div[1]/table/tbody/tr/td[8]/table/tbody/tr/td/table/tbody/tr/td[2]")]
        public IWebElement jobreview { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div[5]/div[4]/div/div[11]/div[4]/div/table/tbody/tr/td[5]/div")]
        public IWebElement doors { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div[1]/div[4]/div[1]/table/tbody/tr/td[7]/table/tbody/tr/td/table/tbody/tr/td[2]")]
        public IWebElement review3d { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[1]/div[4]/div[2]/table/tbody/tr/td[6]/table/tbody/tr/td")]
        public IWebElement porchbtn { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/button[1]")]
        public IWebElement porchdropdown{ get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Apply']")]
        public IWebElement applybtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='tb_view3dToolbar_item_item3d']/table/tbody/tr/td")]
        public IWebElement windowbtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='tb_view3dToolbar_item_item3c']/table/tbody/tr/td")]
        public IWebElement sliderbtn { get; set; }
       

        public  void zoomIn()
        {
            for (int i = 0; i < 1; i++)
            {
           //  (Keys.Control, Keys.Add);
            }
        }
        public void SaveJobAndVerify(string title)
        {
            Jobbtn.Click();
            NameTxt.SendKeys(title);
            PhoneTxt.Click();
            Savebtn.Click();
            System.Threading.Thread.Sleep(6000);
            Homebtn.Click();
            Assert.IsTrue(PropertiesCollection.Validatemessage("test", "/html/body/div[2]/div[2]/span[2]/a"));



        }

        public void InsertAndverifyDoor()
        {
            review3d.Click();
            doorbtn.Click();
            System.Threading.Thread.Sleep(5000);
            int h = canvas.Size.Height / 2;
            int w = canvas.Size.Width / 2;
            Actions actions = new Actions(PropertiesCollection.driver);
            actions.ClickAndHold(canvas)
             .MoveByOffset(-100, -20)
             .Release().Build().Perform();
            actions.Release();
            actions.MoveToElement(canvas, w, h).Click().Build().Perform();
            System.Threading.Thread.Sleep(5000);
            jobreview.Click();
            doors.Click();
            if (qty == "")
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(PropertiesCollection.Validatemessage("1", "//*[@id='grid_MaterialsGrid_rec_0']/td[5]/div"));
            }
            else
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(PropertiesCollection.Validatemessage(qty+1, "//*[@id='grid_MaterialsGrid_rec_0']/td[5]/div"));


            }

        }
       public void InsertAndVerifyPorche()
        {
            review3d.Click();
            porchbtn.Click();
            porchdropdown.Click();
            applybtn.Click();

        }
        public void InsertWindows()
        {
            review3d.Click();
            windowbtn.Click();
            System.Threading.Thread.Sleep(5000);
            int h = canvas.Size.Height / 2;
            int w = canvas.Size.Width / 2;
            Actions actions = new Actions(PropertiesCollection.driver);
            actions.ClickAndHold(canvas)
             .MoveByOffset(-70, -20)
             .Release().Build().Perform();
            actions.Release();
            actions.MoveToElement(canvas, w, h).Click().Build().Perform();

        }

        public void InsertSlider()
        {
            //review3d.Click();
            sliderbtn.Click();
            System.Threading.Thread.Sleep(5000);
            int h = canvas.Size.Height / 2;
            int w = canvas.Size.Width / 2;
            Actions actions = new Actions(PropertiesCollection.driver);
            actions.ClickAndHold(canvas)
             .MoveByOffset(-40, -20)
             .Release().Build().Perform();
            actions.Release();
            actions.MoveToElement(canvas, w, h).Click().Build().Perform();

        }


    }
}
