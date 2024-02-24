using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
    public class AddCoBorrowerPOM
    {
        public static IWebElement ClickOnAddCoBorrowerButton_ApplicationDetailsPage(IWebDriver driver)
        {
            string Xpath = $"//span[normalize-space()='Co-Applicant']/ancestor::button";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[normalize-space()='Edit']/ancestor::button")));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));         
              
            return driver.FindElement(By.XPath(Xpath));
        }
    public static IWebElement ClickOnEditButton_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//span[normalize-space()='Edit']/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[normalize-space()='Edit']/ancestor::button")));


      return driver.FindElement(By.XPath(Xpath));
    }
    public static Boolean CheckHeadline_AddCoBorrowerPage(IWebDriver driver)
        {
            string Xpath = $"//span[normalize-space()='Add Co-Applicant']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        public static void SelectAllLoanId_AddCoBorrowerPage(IWebDriver driver)
        {
            string Xpath = $"//mat-label[contains(text(),'Loan Id')]/preceding::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));           

            IWebElement element= driver.FindElement(By.XPath(Xpath));
            element.Click();
            Thread.Sleep(1000);
            IList<IWebElement>EList= element.FindElements(By.XPath("//following::mat-option"));
            foreach(IWebElement El in EList) 
            {
            El.Click();
            }
            Actions act = new Actions(driver);
            act.MoveToElement(element).Click().Build().Perform();
        }
        public static void SelectLoanId_AddCoBorrowerPage(IWebDriver driver,string LoanId)
        {
            string Xpath = $"//mat-label[contains(text(),'Loan Id')]/preceding::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            IWebElement element = driver.FindElement(By.XPath(Xpath));
            element.Click();
            IList<IWebElement> EList = element.FindElements(By.XPath($"//following::span[normalize-space()='{LoanId}']/parent::mat-option"));
            foreach (IWebElement El in EList)
            {
                El.Click();
            }

            Actions act = new Actions(driver);
            act.MoveToElement(element).Click().Build().Perform();
        }
    }
}
