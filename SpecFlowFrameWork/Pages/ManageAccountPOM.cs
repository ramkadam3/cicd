using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFrameWork.Pages
{
    public class ManageAccountPOM
    {    // private IWebDriver _driver;
       
        public static void NavigateToManageAccountPage(IWebDriver driver)
        {
            string Xpath = "//descendant::span[contains(text(),'Manage Account')]"; //descendant::span[contains(text(),'Notifications')]|
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::b[contains(text(),'Accounts List')]")));
        }

       
        public static IWebElement EnterInputToNameFieldPage(IWebDriver driver)
        {
            string Xpath = "//descendant::mat-label[contains(text(),'Name')]/preceding::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
           
        }
        public static void ClickOnAddInvestoreButton(IWebDriver driver)
        {
            string Xpath = "//descendant::span[contains(text(),'New Investor Account')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        
        public static IWebElement CheckNavigatedToAddInvestorPage(IWebDriver driver)
        {
            string Xpath = "//descendant::span[contains(text(),'Add Investor')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
    public static IWebElement SwitchToThisAccount_ManageAccountPage(IWebDriver driver,string accountName)
    {
      string Xpath = $"//a[ contains(text(),'{accountName}')]/ancestor::tr/descendant::button[contains(@title,'Switch to this Account')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
  }
}
