using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
  public class EscrowDetailsPOM
  {
    public static IWebElement NavigateToEscrowDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Escrow Details']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }

    public static IWebElement ClickOnAddACHButton_EscrowDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//span[normalize-space()='ACH']/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnScheduleEscrowButton_EscrowDetailsPage(IWebDriver driver,string editOrAdd)
    {
      string Xpath = $"//*[normalize-space()='Schedule Escrow']/preceding-sibling::*[normalize-space()='{editOrAdd}']/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static string ClickOnPaymentMode_EscrowDetailsPage(IWebDriver driver,string mode)
    {
      string Xpath = $"(//mat-label[normalize-space()='Preferred Payment Mode']/parent::div/descendant::mat-radio-button)";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      if (mode.ToLower().Contains("yes"))
        driver.FindElement(By.XPath($"{Xpath}[1]")).Click();           
      else
        driver.FindElement(By.XPath($"{Xpath}[2]")).Click();
      return mode;
    }
    public static void ClickOnSaveButton_AddAchdetailsPopup(IWebDriver driver)
    {
      string Xpath = $"//div[normalize-space()='Save']/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ClickOnSetButton_AddAchdetailsPopup(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::div[normalize-space()='Set']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
  }
}
