using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
  public class CreditReportPOM
  {
    public static IWebElement NavigateToCreditReportPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Credit Report']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnAddCreditReportButton_CreditReportPage(IWebDriver driver)
    {
      string Xpath = $"//span[normalize-space()='Credit Report']/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnFetchbutton_creditreportPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::div[(normalize-space()='Fetch') or (normalize-space()='fetch') or (normalize-space()='FETCH')]]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static Boolean CheckBorrowerNameOnPopup_creditreportPage(IWebDriver driver,string borrowerName)
    {
      string Xpath = $"//mat-dialog-content/descendant::b[normalize-space()='{borrowerName.ToUpper()}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static IWebElement ClickOnCheckOnPopup_creditreportPage(IWebDriver driver)
    {
      string Xpath = $"//mat-dialog-content/descendant::mat-checkbox";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static Boolean CheckLabelsOnCreditReportPopup_creditreportPage(IWebDriver driver,string labelName)
    {
      string Xpath = $"//mat-dialog-container/descendant::span[normalize-space()='{labelName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
   
      public static void ClickOnCreditReportActionItem_creditreportPage(IWebDriver driver,int? rowNumber=1)
      {
      string Xpath = $"(//button[@title='Credit Report'])[{rowNumber}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      }
  }
}
