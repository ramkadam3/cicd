using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowFrameWork.Utility;

namespace Yrefy_AutomationProject.Pages.InvstmentsPagePOM
{
    public class ManageInvestmentPagePOM
    {

        public static void NavigateToManageInvestmentPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::span[text()='Manage Investments']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();            
        }
        public static void ClickOnViewInvestment_ManageInvestmentPage(IWebDriver driver)
        {
            string Xpath = $"(//button[contains(@title,'View Investment')]/descendant::mat-icon)[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
    }
}
