using SpecFlowFrameWork.Utility;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow.Configuration;
using static System.Net.Mime.MediaTypeNames;
using TechTalk.SpecFlow;


namespace SpecFlowFrameWork.Pages
{
    public class LoginPOM
    {               
             
        public static Boolean verifyLogoforHomePage(IWebDriver driver)
        {
            string Xpath = "//strong[text()='Log out']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
           return  driver.FindElement(By.XPath(Xpath)).Displayed;            
        }
        public  static void EnterUsername(IWebDriver driver ,String username)
        {
            string Xpath = "//input[@id='email']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(username);
            

        }
        public static void EnterPassword(IWebDriver driver, String Password)
        {
            string Xpath = "//input[@id='password']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(Password);
            Thread.Sleep(2000);

        }
        public static void ClickOnSubmitButton(IWebDriver driver)
        {
            string Xpath = "//button[@type='submit']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();           

        }
        public static Boolean CheckErrorMessageforLogin(IWebDriver driver)
        {
            string Xpath = "//div[contains(@class,'error')]/p[text()]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
           return  driver.FindElement(By.XPath(Xpath)).Displayed;


        }
        public static void Logout(IWebDriver driver)
        {
            string Xpath = "//strong[text()='Log out']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
    }
}
