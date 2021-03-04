using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFS_Automation.pages
{
    class TrussesPageObject
    {
        public TrussesPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='tb_grid_toolbar_item_upload']/table/tbody/tr/td")]
        public IWebElement uploadbtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='tb_grid_toolbar_item_download']/table/tbody/tr/td")]
        public IWebElement downloadbtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='w2ui - overlay']/div/div/table/tbody/tr[2]/td[1]")]
        public IWebElement exceldownload { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='w2ui - overlay']/div/div/table/tbody/tr[1]/td[1]")]
        public IWebElement csvdownload { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='fileBox']")]
        public IWebElement choosefilebtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='uploadBtn']")]
        public IWebElement upload2btn { get; set; }

        public void DownloadData()
        {
            downloadbtn.Click();
            exceldownload.Click();
        }
        public void UploadData()
        {
            System.Threading.Thread.Sleep(2000);
            uploadbtn.Click();
            System.Threading.Thread.Sleep(2000);
            choosefilebtn.SendKeys("C:\\Users\\Nasir\\Downloads\\Materials-Badar Test.xlsx");
            System.Threading.Thread.Sleep(5000);
            upload2btn.Click();

        }
    }
}
