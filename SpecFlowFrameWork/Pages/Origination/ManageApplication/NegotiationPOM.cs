using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
  public class NegotiationPOM
  {
    public static void ClickOnAddNegotiationButton_LoanDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='Negotiation']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static string ReadDataNegotiation_NegotiationTable_LoanDetailsPage(IWebDriver driver,string columnName,int? rowNumber=1)
    {
      string Xpath = $"//b[normalize-space()='Negotiation']/following::tbody/descendant::tr[{rowNumber}]/descendant::td[@data-label='{columnName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Text;
    }
    public static void SelectLoan_Negotiation_LoanDetailsPage(IWebDriver driver, int? RowNumber = 1)
    {
      string Xpath = $"//b[normalize-space()='Private Student Loans']/following::tbody/tr[{RowNumber}]/descendant::mat-checkbox";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static string GetData_Negotiation_LoanDetailsPage(IWebDriver driver,string keyName, int? RowNumber = 1)
    {
      string Xpath = $"//b[normalize-space()='Private Student Loans']/following::tbody/tr[1]/descendant::td[@data-label='{keyName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);      
      string a = visibleElements.Text.Trim('$').Replace(",","");
      return a;
    }

    public static void ClickOnActionItem_NegotiationTable_LoanDetailsPage(IWebDriver driver, string actionItem, int? rowNumber = 1)
    {
      string Xpath = $"(//button[descendant::mat-icon[normalize-space()='{actionItem}']])[{rowNumber}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static IWebElement EnterValueToColumnCell_NegotiationTable_LoanDetailsPage(IWebDriver driver, string columnName, int? rowNumber = 1)
    {
      string Xpath = $"//tbody/descendant::tr[{rowNumber}]/descendant::td[@data-label='{columnName}']/descendant::input";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return  driver.FindElement(By.XPath(Xpath));
    }

    public static string GetData_NegotiationInnerTable_LoanDetailsPage(IWebDriver driver, string keyName, int? RowNumber = 1)
    {
      string Xpath = $"//tr[{RowNumber+1}]/descendant::td[contains(@class,'{keyName}')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);
      string a = visibleElements.Text.Trim('$').Replace(",", "");
      return a;
    }
  }
}
