using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Yrefy_AutomationProject.Pages.ServicingObject
{
  public class BorrowerPagePOM
  {
    public static void NavigateToBorrowerPage(IWebDriver driver)
    {
      string Xpath = "//span[normalize-space()='Borrower']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }
    //descendant::span[normalize-space()='EDIT']

    public static void ClickOnEiditButton_BorrowerPage(IWebDriver driver)
    {
      string Xpath = "//descendant::span[(normalize-space()='EDIT') or (normalize-space()='Edit')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }
    
    public static IDictionary GetAddedData_BorrowerDetails_withSubCardName(IWebDriver driver, string cardName, string[] ElementRequired)
    {//Education Details|Employment Details|Reference Details|Mailing Address|Other|Physical Address etc
      string Xpath;

      Xpath = $"(//span[contains(text(),'{cardName}')])[last()]/ancestor::mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);


      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElements);
      for (int i = 0; i < ElementRequired.Length; i++)
      {

        string XpathKey = $"{Xpath}/descendant::div[contains(text(),'{ElementRequired[i]}')][1]/following-sibling::div[contains(@class,'label-data')]";
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
