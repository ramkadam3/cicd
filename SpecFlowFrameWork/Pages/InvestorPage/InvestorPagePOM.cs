using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowFrameWork.Utility;
using NUnit.Framework;
using System.Runtime.Intrinsics.X86;
using OpenQA.Selenium.Interactions;

namespace Yrefy_AutomationProject.Pages.InvestorPage
{
  public class InvestorPagePOM
  {
    public static void NavigateToInvestorsPage(IWebDriver driver)
    {
      string Xpath = "//span[normalize-space()='Investors']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }
    
    public static void ClickOnAddInvestorButton_InvestorPage(IWebDriver driver)
    {
      string Xpath = "//descendant::span[(normalize-space()='INVESTOR') or (normalize-space()='Investor')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static Boolean CheckOnStatusOfCheckBox_InvestorPage(IWebDriver driver,string checkName)
    {
      string Xpath = $"//span[contains(text(),'{checkName}')]/ancestor::mat-radio-button[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      
      Boolean s= driver.FindElement(By.XPath(Xpath)).GetAttribute("class").Contains("checked");
      return s;
    }
    

    public static void ClickOnInviteInvestorButton_InvestorPage(IWebDriver driver)
    {
      string Xpath = "//descendant::span[(normalize-space()='INVITE INVESTOR') or (normalize-space()='Invite Investor')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void SelectInvestorTypeButton_InvestorPage(IWebDriver driver, string investorType)
    {
      string Xpath = $"//span[text()='{investorType}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static IWebElement ClickOnInvestorName_InvestorPage(IWebDriver driver, int rowNumber)
    {
      string Xpath = $"//tbody/descendant::tr[{rowNumber}]/descendant::a";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static void NavigateToInvestorUsersSection_InvestorDetails_InvestorPage(IWebDriver driver)
    {
      string Xpath = $"//div[contains(text(),'Investor Users')]/parent::div";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static IWebElement ReadEmailOfInvestor_InvestorPage(IWebDriver driver, int? rowNumber=1)
    {
      string Xpath = $"//tbody/tr[{rowNumber}]/descendant::td[@data-label='Email']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement CheckEmailOfInvestorIsAvailable_InvestorPage(IWebDriver driver, int? rowNumber = 1)
    {
      string Xpath = $"//tbody/tr[{rowNumber}]/descendant::td[@data-label='Email']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IDictionary<string,string> ReadLoginEmailOfInvestor_FromInvestorDetailsInvestorPage(IWebDriver driver, int? investorNumber=1)
    {
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "First Name", "Middle Name", "Last Name", "Type", "SSN", "Email-login" };
      dataDic = (IDictionary<string, string>)AddInvestorPOM.GetInvestorDetails_JointInvestor_InvestorDetails(driver, "Investor Details", dataKey, (int)investorNumber);

      return dataDic;
    }
    public static IDictionary<string, string> ReadIRAInvestorName_FromInvestorDetailsInvestorPage(IWebDriver driver, int? investorNumber = 1)
    {
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Investor Name" };
      dataDic = (IDictionary<string, string>)AddInvestorPOM.GetInvestorDetails_JointInvestor_InvestorDetails(driver, "IRA Custodian Details", dataKey, (int)investorNumber);

      return dataDic;
    }
    public static IDictionary<string, string> ReadInvestorName_FromInvestorDetailsInvestorPage(IWebDriver driver, int? investorNumber = 1)
    {
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Investor Name" };
      dataDic = (IDictionary<string, string>)AddInvestorPOM.GetInvestorDetails_JointInvestor_InvestorDetails(driver, "Investor Details", dataKey, (int)investorNumber);

      return dataDic;
    }
    public static void ClickOnTypeFilter_InvestmentPage(IWebDriver driver)
    {
      string Xpath = $"//mat-label[text()='Type']/preceding::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      Thread.Sleep(1000);
      driver.FindElement(By.XPath(Xpath)).Click();
     
      Thread.Sleep(1000);
    }
    public static void ClickOnApplyButton_InvestmentPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='APPLY']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      Actions act =new Actions(driver);
      act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
      
    }
  }
}
