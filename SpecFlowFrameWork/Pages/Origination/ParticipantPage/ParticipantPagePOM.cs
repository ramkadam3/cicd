using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yrefy_AutomationProject.Pages.ParticipantPage
{
  public class ParticipantPagePOM
  {


    public static void NavigateToParticipantPage(IWebDriver driver)
    {
      string Xpath = "//span[normalize-space()='Participants']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }

    public static void ClickOnAddParticipantButton_ParticipantPage(IWebDriver driver)
    {
      string Xpath = $"//span[normalize-space()='Participant']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static Boolean CheckDataOfParticipant_ParticipantPage(IWebDriver driver,string dataValue,int? rowNumber=1)
    {
      string Xpath = $"//tr/descendant::td[normalize-space()='{dataValue}']";
      //string Xpath = $"//tr[{rowNumber}]/descendant::td[normalize-space()='{dataValue}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static (IWebElement,int) CheckDeleteButton_ParticipantPage(IWebDriver driver)
    {
      string Xpath = $"//button[@title='Delete Participant']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return (driver.FindElements(By.XPath(Xpath))[0],driver.FindElements(By.XPath(Xpath)).Count);
    }


  }
}
