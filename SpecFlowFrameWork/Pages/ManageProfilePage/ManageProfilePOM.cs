using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.IO;
using SpecFlowFrameWork.Utility;

namespace Yrefy_AutomationProject.Pages.ManageProfilePage
{
    public class ManageProfilePOM
    {
        public static void NavigateToManageProfilePage(IWebDriver driver)
        {
            string Xpath = $"//descendant::span[contains(text(),'Manage Profile')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();

        }
    
    public static void EnterAccountName_NameFilter_ManageProfilePage(IWebDriver driver,string name)
    {
      string Xpath = $"//mat-label[text()='Name']/preceding::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(name);
    }
    public static void ClickOnAccountName_ManageProfilePage(IWebDriver driver,int? rowNumber=1)
    {
      string Xpath = $"//tbody/tr[{rowNumber}]/descendant::a";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ClickOnNextNavigationButton_ManageProfilePage(IWebDriver driver)
        {
            string Xpath = $"//div[contains(@class,'pagination-after')]/div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();


        }
        public static void ClickOnReportPermission_ManageProfilePage(IWebDriver driver)
        {
            string Xpath = $"//div[contains(text(),'Report Permissions')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();

        }//span[contains(text(),'Not Allow')]/parent::mat-option
    public static void ClickOnProceedToInvestButton_ManageProfilePage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[contains(text(),'Proceed to Invest')]]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();

    }
    public static IWebElement SelectSelfPermission_ManageProfilePage(IWebDriver driver)
        {
            string Xpath = $"//h4[contains(text(),'Select Permission for self')]/following::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));






        }
        public static IWebElement SeletctSelfPermissionOption_ManageProfilePage(IWebDriver driver, string OptionName)
        {
            string Xpath = $"//span[contains(text(),'{OptionName}')]/parent::mat-option";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));






        }
        public static IWebElement SelectGlobalPermission_ManageProfilePage(IWebDriver driver, string EntityName)
        {
            string Xpath = $"//tbody/descendant::td[contains(text(),'{EntityName}')]/following::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));

        }
        public static void ExpandInnerTable_OfPermission_ManageProfilePage(IWebDriver driver, string EntityName, string more_less)
        {
            string Xpath = $"//tbody/descendant::td[contains(text(),'{EntityName}')]/following::button[1]/descendant::mat-icon";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            string gg = driver.FindElement(By.XPath(Xpath)).Text;


            if (driver.FindElement(By.XPath(Xpath)).Text.Contains(more_less))
            {
                driver.FindElement(By.XPath(Xpath)).Click();
            }
            Thread.Sleep(1000);
        }
        public static (IWebElement, string) ClickOnEntityCheckBox_ManageProfilePage(IWebDriver driver, int CheckNumber)
        {//CheckNumber=33-44
            string XpathCheck = $"//label[@for='mat-checkbox-{CheckNumber}-input']/child::span[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XpathCheck)));

            IWebElement CheckBox = driver.FindElement(By.XPath(XpathCheck));

            string XpathName = $"//label[@for='mat-checkbox-{CheckNumber}-input']/child::span[2]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XpathName)));
            string CheckName = driver.FindElement(By.XPath(XpathCheck)).Text;

            return (CheckBox, CheckName);
        }
        public static (IWebElement, string) SelectOptionForUserLevelPermission_ManageProfilePage(IWebDriver driver, int CheckNumber)
        {//CheckNumber=33-44
            string XpathCheck = $"//label[@for='mat-checkbox-{CheckNumber.ToString()}-input']/following::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(XpathCheck)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XpathCheck)));

            IWebElement DropDown = driver.FindElement(By.XPath(XpathCheck));

            string XpathName = $"//label[@for='mat-checkbox-{CheckNumber.ToString()}-input']/child::span[2]";
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(XpathName)));
            string CheckName = driver.FindElement(By.XPath(XpathCheck)).Text;
            
            return (DropDown, CheckName);
        }
    }
}
