using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
  public class NotesPOM
  {

    public static IWebElement NavigateToNotesPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Notes']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnAddNotesButton_NotesPage(IWebDriver driver)
    {
      string Xpath = $"//span[normalize-space()='NOTE']/ancestor::button";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnAddbutton_NotesPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::div[(normalize-space()='ADD') or (normalize-space()='add') or (normalize-space()='Add')]]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnCreateButton_NotesPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::div[(normalize-space()='ADD') or (normalize-space()='add')]]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static Boolean CheckAddedNoteDetails_NotesPage(IWebDriver driver,string value)
    {
      string Xpath = $"//mat-card[contains(@class,'replyList')][1]/descendant::div[normalize-space()='{value}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static void ClickOnReplyButton_NotesPage(IWebDriver driver)
    {
      string Xpath = $"//mat-card[contains(@class,'replyList')][1]/descendant::button[descendant::mat-icon[text()='reply']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
  }
}
