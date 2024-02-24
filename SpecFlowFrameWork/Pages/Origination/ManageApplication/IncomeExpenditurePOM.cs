using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
  public class IncomeExpenditurePOM
  {
    public static void NavigateToIncomeExpenditurePage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Income and Expenditure Details']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      
     driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static IWebElement ClickOnAddIncome_IncomeExpenditurePage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='Income']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

     return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnAddExpenditure_IncomeExpenditurePage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='Expenditure']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static void SelectValue_AddIncomePopup_ApplicationDetailsPage(IWebDriver driver, string fieldName, string Option)
    {
      string Xpath = $"//mat-dialog-container/descendant::mat-label[normalize-space()='{fieldName}']/preceding::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(Option);
      Thread.Sleep(2000);
    }


    public static void EnterInputValue_AddIncomePopup_ApplicationDetailsPage(IWebDriver driver, string elementName, string value)
    {
      string Xpath = $"//mat-dialog-container/descendant::mat-label[normalize-space()='{elementName}']/preceding::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(value);
      Thread.Sleep(2000);
    }
    public static void ClickOnAddButton_AddIncomePopup_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//mat-dialog-container/descendant::button[descendant::span[normalize-space()='Add']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(2000);
    }
    public static string CheckData_AddedIncome_IncomePage(IWebDriver driver,string dataName)
    {
      
      string Xpath = $"//tr[1]/descendant::td[@data-label='{dataName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text;
    }
    public static Boolean CheckIncomeAmount_AddedIncome_IncomePage(IWebDriver driver, string amount)
    {
      string Xpath = $"//tr[1]/descendant::td[@data-label='Income Amount']/descendant::div[contains(text(),'${amount}')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static Boolean CheckAmount_AddedExpenditure_IncomePage(IWebDriver driver, string amount)
    {
      string Xpath = $"//tr[1]/descendant::td[@data-label='Amount']/descendant::div[contains(text(),'${amount}')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static void ClickOnDeleteButton_AddedIncome_IncomePage(IWebDriver driver)
    {
      string Xpath = $"//tr[1]/descendant::button[@title='Delete Income']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ClickOnDeleteButton_AddedExpenditure_IncomePage(IWebDriver driver)
    {
      string Xpath = $"//tr[1]/descendant::button[@title='Delete']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static int CheckDeleteButton_AddedIncome_IncomePage(IWebDriver driver)
    {
      string Xpath = $"//tr/descendant::button[@title='Delete Income']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

     return  driver.FindElements(By.XPath(Xpath)).Count;
    }
    public static int CheckDeleteButton_AddedExpenditure_IncomePage(IWebDriver driver)
    {
      string Xpath = $"//tr/descendant::button[@title='Delete']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElements(By.XPath(Xpath)).Count;
    }
    //**********************************************************************income calculator********************************************************************************

    public static void NavigateToIncomeCalculatorPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Income Calculator']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static IWebElement ClickOnIncomeCalculatorButton_IncomeCalculatorPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='Income Calculator']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement CheckIncomeCheck_IncomeCalculatorPage(IWebDriver driver)
    {
      string Xpath = $"//tr[1]/descendant::mat-checkbox";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static string ReadDataOfIncome_IncomeCalculatorPopup(IWebDriver driver, string dataName)
    {
      //Income Frequency|Income Type|Income Amount|Borrower Type
      string Xpath = $"//tr[1]/descendant::td[@data-label='{dataName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",","");
    }
    public static void ClickOnDeleteButton_IncomeCalculatorPopup(IWebDriver driver, string dataName)
    {      
      string Xpath = $"//tr[1]/descendant::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ClickOnCalculationButton_IncomeCalculatorPopup(IWebDriver driver, string buttonName)
    {//Calculate|Calculate & Save
      string Xpath = $"//div[normalize-space()='{buttonName}']/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static string ReadCalculatedValue_IncomeCalculatorPopup(IWebDriver driver, string valueName)
    {//Average|Total
      string Xpath = $"//div[normalize-space()='{valueName}']/following-sibling::div";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      Thread.Sleep(5000);

      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      return visibleElements[0].Text.Trim('$').Replace(",", "");
    }//button[descendant::mat-icon[text()='close']]
    public static void CloseThePopup(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::mat-icon[text()='close']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(2000);
    }
    //******************************************************************DTI Calculator***************************************************************************************

    public static void NavigateToDTICalculatorPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='DTI Calculator']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static IWebElement SelectCheck_DTICalculatorPage(IWebDriver driver,int? checkNumber=0)
    {
      string Xpath = $"//tr[1]/descendant::mat-checkbox";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      Thread.Sleep(1000);

      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
     return  visibleElements[(int)checkNumber];
    }
    public static IWebElement ClickOnDTICalculatorButton_DTICalculatorPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='DTI Calculator']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnAddIncomeButton_IncomedetailsPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='Income']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static void CheckExpansionOfPanel_DTIcalculatorPopup_DTICalculatorPage(IWebDriver driver,string panelName)
    {
      string Xpath = $"//b[normalize-space()='{panelName}']/ancestor::mat-expansion-panel-header[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
     if( driver.FindElement(By.XPath(Xpath)).GetAttribute("aria-expanded").Contains("false"))
      driver.FindElement(By.XPath(Xpath)).Click();

    }
    public static string ReadDTIRatioValue_DTICalculatorPopup(IWebDriver driver)
    {
      string Xpath = $"//span[normalize-space()='Debts to Income Ratio :']/following::span[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      Thread.Sleep(5000);

      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      return visibleElements[0].Text.Trim('%');
    }

    public static void SelectIncomeCalculationId_DTIcalculatorPopup_DTICalculatorPage(IWebDriver driver, int? index=0)
    {
      string Xpath = $"//mat-label[normalize-space()='Income Calculation Id']/preceding::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
        driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(2000);
      IList<IWebElement> option=driver.FindElements(By.XPath("//mat-option"));
      option[(int)index].Click();    

    }


  }
}
