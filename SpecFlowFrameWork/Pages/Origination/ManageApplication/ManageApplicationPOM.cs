using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
    public class ManageApplicationPOM
    {
        public static void NavigateToManageApplicationPage(IWebDriver driver)
        {
            string Xpath = "//span[normalize-space()='Manage Application']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
            BaseClass.WaitForSpinnerToDisappear(driver);
        }
        public static IWebElement ClickOnAppID_ManageApplicationPage(IWebDriver driver,int RowNumber)
        {
            string Xpath = $"//tr[{RowNumber}]/descendant::a";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return  driver.FindElement(By.XPath(Xpath));    
        }
         public static IWebElement ArrangeLoanInOrder_ManageApplicationPage(IWebDriver driver)
         {
           string Xpath = $"//div[normalize-space()='Loans']/parent::th";
           WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
           Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

           return driver.FindElement(By.XPath(Xpath));

         }
    //*********************************************************************Yopmail.com element******************************************************************************************
    public static void EnterEmail_YopmailCom(IWebDriver driver, string Email)
        {
            string Xpath = $"//input[@placeholder='Enter your inbox here']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      
        char[] characters = Email.ToCharArray();

        foreach (char s in characters)
        {
          driver.FindElement(By.XPath(Xpath)).SendKeys(s.ToString());
          Thread.Sleep(100);
        }
      
        }
        public static void ConfirmEmailByClickingOnArrow_YopmailCom(IWebDriver driver)
        {
            string Xpath = $"//i[normalize-space()='']/parent::button";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckEmailMessage_YopmailCom(IWebDriver driver,string Message)
        {
            string Xpath = $"//h2[contains(text(),'{Message}')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
             Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return  driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void DeleteTheEmailMessage_YopmailCom(IWebDriver driver)
        {
            string Xpath = $"//span[normalize-space()='Delete']/parent::button";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
    }
}
