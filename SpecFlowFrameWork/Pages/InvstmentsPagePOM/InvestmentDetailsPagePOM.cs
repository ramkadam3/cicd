using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.Pages.InvstmentsPagePOM
{
  public class InvestmentDetailsPagePOM
  {
    public static void ClickOnUpdateInvestmentButton_InvestmentDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[text()='Update Investment']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static string CheckNumberOFTranchInvested_InvestmentDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//p[normalize-space()='No. of Tranches Invested']/following-sibling::h3";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text;
    }
    public static string CheckDateOfInvested_InvestmentDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//p[contains(text(),'Investment Receipt Date')]/following-sibling::h3";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text;
    }
    public static string CheckInvestmentAmount_InvestedInvestment_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::p[contains(text(),'Investment Amount')]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",", "");
    }
   
      public static string CheckIntrestRate_InvestedInvestment_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/following::span[contains(text(),'Year')][1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text.Replace("% / Year","").RemoveFractionIfWhole();
      
    }
    public static string CheckEffectiveInterestRate_InvestedInvestment_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::p[contains(text(),'Effective Interest Yield')]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",", "").RemoveFractionIfWhole();
    }
    public static string CheckBonus_InvestedInvestment_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::p[contains(text(),'Bonus')]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",", "");
    }
    public static string CheckMonthlyIncomePercentage_InvestedInvestment_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::p[contains(text(),'Monthly Income')]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text.Trim('%');
    }
    public static string CheckMaturityDate_InvestedInvestment_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::p[contains(text(),'Maturity Date')]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text;
    }
      public static string CheckReddemedAmountOnMaturity_InvestedInvestment_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
      {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::p[contains(text(), 'Amount redeemed on Maturity')]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text;
      }
    
      public static void ExpandReinvestmentField_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
      {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::span[text() = 'Re-invest on Maturity']/following::span[contains(text(), 'expand_more')][1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

       driver.FindElement(By.XPath(Xpath)).Click();
      }
    public static void ExpandReinvestmentFieldOfSimulator_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[3]/ancestor::mat-card[1]/descendant::p[contains(text(),'Re-invest on Maturity')]/following::span[contains(text(), 'expand_more')][1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

        driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static string CheckReinvestedvalue_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber, int reInvestedTranche)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::div[contains(.,'Tranche {reInvestedTranche}')]/following-sibling::div[contains(@class,'label-data')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text;
    }
    public static void EnterReinvestedvalue_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber, int reInvestedTranche, string reInvestmentValue)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::div[contains(@class,'reInvestmentInput')][{reInvestedTranche}]/descendant::input";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(reInvestmentValue);
    }
    public static void ClearAllReInvestedValue_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::div[contains(@class,'reInvestmentInput')]/descendant::input";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      IList<IWebElement>ReInves=driver.FindElements(By.XPath(Xpath));

      foreach(IWebElement Re in ReInves)
      {
       Re.Clear();
      }
    }
    public static IWebElement ReadValueOfSimulatorTrancheField_InvestmentdetailsPage(IWebDriver driver, int TrancheNumber, string FieldName)
    {
      string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[contains(text(),'{FieldName}')][1]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement Read_ReinvestmentValueOfSimulatorTrancheField_InvestmentdetailsPage(IWebDriver driver, int TrancheNumber, int reInvestTranche)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[3]/ancestor::mat-card[1]/descendant::p[contains(.,'Tranche {reInvestTranche}')]/following::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement Read_Reinvestment_WithrowAmountOnSimulatorTrancheField_InvestmentdetailsPage(IWebDriver driver, int TrancheNumber)
    {
      string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[3]/ancestor::mat-card[1]/descendant::p[contains(.,'Withdraw Amount')]/following::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement EnterInputToTrancheField_InvestmentDetailsPage(IWebDriver driver, int TrancheNumber, string InputFieldName)
    {
      string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[contains(text(),'{InputFieldName}')][1]/following::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    
  }
}
