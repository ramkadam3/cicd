using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yrefy_AutomationProject.Pages.InvestorPage;
using AventStack.ExtentReports;

namespace Yrefy_AutomationProject.Pages.FindersPage
{
  public class FinderPagePOM
  {
    public static void NavigateToFindersPage(IWebDriver driver)
    {
      string Xpath = "//span[contains(text(),'Finders')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }

    public static void ClickOnTheAddFinderButton(IWebDriver driver)
    {
      string Xpath = "//button[descendant::span[normalize-space()='FINDER']]|//button[descendant::span[normalize-space()='Finder']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }
    public static void ClickOnAccountTypeButton_BankAccountDetails_FinderPage(IWebDriver driver,string accountType)
    {
      string Xpath = $"//span[text()='{accountType}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static Boolean Check_CheckBoxOfAccountType_BankAccountDetails_FinderPage(IWebDriver driver, string accountType)
    {
      string Xpath = $"//span[text()='{accountType}']/ancestor::mat-radio-button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
     return driver.FindElement(By.XPath(Xpath)).GetAttribute("class").Contains("checked");
    }
    public static IDictionary<string, string> ReadLoginEmailOfInvestor_FromFinderDetailsFinderPage(IWebDriver driver, int? investorNumber = 1)
    {
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Name", "Type", "SSN (Last 4 Digits)", "Email-login" };
      dataDic = (IDictionary<string, string>)AddInvestorPOM.GetInvestorDetails_JointInvestor_InvestorDetails(driver, "Finder Details", dataKey, (int)investorNumber);
      return dataDic;
    }
    public static void ClickOnInviteFinderButton_FinderPage(IWebDriver driver)
    {
      string Xpath = "//descendant::span[(normalize-space()='INVITE FINDER') or (normalize-space()='Invite Finder')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static Boolean CheckStatusOfFinder_finderDetails_FinderPage(IWebDriver driver, string statusText)
    {
      BaseClass.WaitForPageToLoad(driver);
      string Xpath = $"//mat-chip[contains(text(),'{statusText}')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static void ClickOnApproveButton_finderDetails_FinderPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::div[normalize-space()='Approve']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ClickOnStatusFilter_FinderPage(IWebDriver driver)
    {

      string Xpath = $"//descendant::mat-label[contains(text(),'Status')]/preceding::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
  }
}
