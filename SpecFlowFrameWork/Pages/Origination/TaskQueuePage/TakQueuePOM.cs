using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Yrefy_AutomationProject.Pages.Origination.TaskQueuePage
{
  public class TakQueuePOM
  {
    public static void NavigateToTaskQueuePage(IWebDriver driver)
    {
      string Xpath = "//span[normalize-space()='Task Queue']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }

    public static void ClickOnAddTaskButton_TaskQueuePage(IWebDriver driver)
    {
      string Xpath = $"//span[normalize-space()='Task']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static IWebElement EnterInputTextarea_TaskQueuePage(IWebDriver driver,int? index=1)
    {
      string Xpath = $"//textarea[{index}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static void ClickOnCreateButton_AddIncomePopup_TaskQueuePage(IWebDriver driver)
    {
      string Xpath = $"//mat-dialog-container/descendant::button[descendant::span[normalize-space()='Create']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(2000);
    }
    public static void ClickOnButton_ActionItem_TaskQueuePage(IWebDriver driver,string butonName,int? rowNumber=1)
    {//Assign Task|Edit Task
      string Xpath = $"//tbody/descendant::tr[{rowNumber}]/descendant::button[@title='{butonName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(2000);
    }
    public static void ChangeStatusButton_ActionItem_TaskQueuePage(IWebDriver driver, string butonName)
    {//Completed| In Progress|Canceled
      string Xpath = $"//tbody/descendant::tr[1]/descendant::mat-icon[@title='Change Status']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(2000);
      driver.FindElement(By.XPath($"//button[descendant::span[text()='{butonName}']]")).Click();


    }
    public static void ClickOnButton_Popup_TaskQueuePage(IWebDriver driver, string butonName)
    {//Assign|Update
      string Xpath = $"//button[descendant::*[normalize-space()='{butonName}']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
          }

    public static void EnterInputValue_QueuePage(IWebDriver driver, string elementName, string value)
    {
      string Xpath = $"//mat-dialog-container/descendant::mat-label[normalize-space()='{elementName}']/preceding::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Clear();
      Thread.Sleep(2000);
      driver.FindElement(By.XPath(Xpath)).SendKeys(value);
      Thread.Sleep(2000);
      
    }
    public static IDictionary GetAddedTaskData_TaskQueuePage(IWebDriver driver, string[] ElementRequired)
    {
      string Xpath;

      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      foreach (string element in ElementRequired)
      {
        Xpath = $"//tbody/descendant::tr[1]/td[@data-label='{element}']";
        Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

        Thread.Sleep(500);
        string KeyValue=driver.FindElement(By.XPath(Xpath)).Text;        
        DataDic.Add(element, KeyValue);       
      }

      return (IDictionary)DataDic;
    }
  }
}
