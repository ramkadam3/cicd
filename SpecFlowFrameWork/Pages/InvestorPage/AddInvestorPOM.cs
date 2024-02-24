using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace Yrefy_AutomationProject.Pages.InvestorPage
{
  public class AddInvestorPOM
  {
    
    public static Boolean CheckHeadlineOfAddInvestorform_InvestorPage(IWebDriver driver, string investorType)
    {
      string Xpath = $"//div[text()='Type']/following-sibling::div[text()='{investorType}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static void SelectAccountType_AddInvestorPage(IWebDriver driver, string accountType)
    {
      string Xpath = $"//span[text()='{accountType}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Actions actions = new Actions(driver);
      actions.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build();
      actions.Perform();      
    }
    public static string SelectOffering_InviteInvestorPopup_InvestorPage(IWebDriver driver,int? selectByIndex=1)
    {
      string Xpath = "//span[normalize-space()='Offering']/ancestor::mat-select[1]";      

      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IWebElement element = driver.FindElement(By.XPath(Xpath));
      Actions actions = new Actions(driver);
      actions.MoveToElement(element).Click().Build();
      actions.Perform();      
      Thread.Sleep(2000);
      IList<IWebElement> OptionList = new List<IWebElement>();
      OptionList = driver.FindElements(By.XPath("//mat-option"));
      Thread.Sleep(2000);
      OptionList[(int)selectByIndex].Click();
      Thread.Sleep(2000);
      string q = element.Text;
      return element.Text;
    }
    public static IWebElement EnterEmail_InvitePopup_InvestorPage(IWebDriver driver)
    {
      string Xpath = $"//label[normalize-space()='Email']/following::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);
      return visibleElements;
    }
    public static void ClickOnCreateMyAccount(IWebDriver driver)
    {
      string Xpath = $"//span[text()='Create my account']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);
      visibleElements.Click();
    }
    public static IWebElement ClickOnInvestorTypeCard_AddInvestorPage(IWebDriver driver, string investorType)
    {
      string Xpath = $"//mat-card-title[normalize-space()='{investorType}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static void ClickOnConinueButton_ReminderPopup_AddInvestorPage(IWebDriver driver)
    {
      string Xpath = $"(//span[normalize-space()='Continue'])[1]/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void NavigateToManageProfilePage(IWebDriver driver)
    {
      string Xpath = "//span[normalize-space()='Manage Profile']|//span[normalize-space()='Profile']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }
    public static void ClickOnNewInvestorAccountButton(IWebDriver driver)
    {
      string Xpath = "//descendant::span[(normalize-space()='New Investor Account')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }
    public static IWebElement ClickOnInvestorAccount_ManageAccountsPage(IWebDriver driver,int? rowNumber=2)
    {
      string Xpath = $"//tbody/tr[{rowNumber}]/descendant::a";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

     return driver.FindElement(By.XPath(Xpath));
      
    }
    
    public static void ClickOnInvestorOption_InvestorTypeFilter_InvestorPage(IWebDriver driver, string InvestorName)
    {
      string Xpath = $"//mat-option/descendant::span[text()='{InvestorName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void SelectInvestor_JointInvestorForm_AddInvestorPage(IWebDriver driver,int investorNumber)
    {
      string Xpath = $"//div[contains(text(),'Investor {investorNumber}')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      
    }
    public static IDictionary GetInvestorDetails_JointInvestor_InvestorDetails(IWebDriver driver, string cardName, string[] ElementRequired,int investorNumber)
    {
      string Xpath;

      Xpath = $"(//*[contains(text(),'{cardName}')])[last()]/ancestor::mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      if (elements.Count > 0)
      {
        Actions actions = new Actions(driver);
        actions.MoveToElement(elements[0]);
        actions.Perform();
      }

      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElements);
      for (int i = 0; i < ElementRequired.Length; i++)
      {

        string XpathKey = $"{Xpath}/descendant::*[contains(text(),'{ElementRequired[i]}')][{investorNumber}]/following-sibling::*[contains(@class,'label-data')]";
        string Key = ElementRequired[i];
        Thread.Sleep(500);
       
        string KeyValue = driver.FindElement(By.XPath(XpathKey)).Text;
        DataDic.Add(Key, KeyValue);
      }

      return (IDictionary)DataDic;
    }
    public static IDictionary GetAddressDetails_JointInvestor_InvestorDetails(IWebDriver driver, string cardName, string[] ElementRequired, int investorNumber)
    {
      string Xpath;

      Xpath = $"(//*[contains(text(),'{cardName}')])/ancestor::mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      if (elements.Count > 0)
      {
        Actions actions = new Actions(driver);
        actions.MoveToElement(elements[0]);
        actions.Perform();
      }

      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElements);
      for (int i = 0; i < ElementRequired.Length; i++)
      {

        string XpathKey = $"{Xpath}/descendant::*[contains(text(),'{ElementRequired[i]}')][{investorNumber}]/following-sibling::*[contains(@class,'label-data')]";
        string Key = ElementRequired[i];
        Thread.Sleep(500);
        string KeyValue = driver.FindElement(By.XPath(XpathKey)).Text;
        //string KeyValue = element.FindElement(By.XPath(XpathKey)).Text;
        DataDic.Add(Key, KeyValue);
      }

      return (IDictionary)DataDic;
    }
  }
}
