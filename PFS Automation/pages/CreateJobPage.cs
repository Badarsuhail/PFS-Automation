﻿using System;
using System.Collections.Generic;
using System.Text;
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

        public  void zoomIn()
        {
            for (int i = 0; i < 1; i++)
            {
           //  (Keys.Control, Keys.Add);
            }
        }

        public void InsertAndverifyDoor()
        {
            review3d.Click();
            doorbtn.Click();
            System.Threading.Thread.Sleep(5000);
            //jobpage.cancelbtn.Click();
            //System.Threading.Thread.Sleep(5000);

            //jobpage.Jobbtn.Click();
            //jobpage.NameTxt.SendKeys("test");
            //jobpage.PhoneTxt.Click();
            //System.Threading.Thread.Sleep(3000);
            //jobpage.Savebtn.Click();
            //jobpage.Homebtn.Click();
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(PropertiesCollection.Validatemessage("1", "#grid_MaterialsGrid_rec_0 > td:nth-child(5) > div:nth-child(1)"));
            }
            else
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(PropertiesCollection.Validatemessage(qty, "#grid_MaterialsGrid_rec_0 > td:nth-child(5) > div:nth-child(1)"));


            }

        }
       public void InsertAndVerifyPorche()
        {
            review3d.Click();
            porchbtn.Click();
            porchdropdown.Click();
            applybtn.Click();

        }



    }
}