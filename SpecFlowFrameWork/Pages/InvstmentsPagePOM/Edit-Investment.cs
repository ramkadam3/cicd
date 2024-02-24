using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;
using SpecFlowFrameWork.Pages.OfferingPagePOM;
using TechTalk.SpecFlow;

namespace Yrefy_AutomationProject.Pages.InvstmentsPagePOM
{
    public class Edit_Investment
    {

        public static IWebElement EnterInvestmentAmount_AddInvestmentProcess(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"(//descendant::span[text()='Tranche {TrancheNumber}'])[2]/following::p[text()='Investment Amount'][1]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement EnterInputToTrancheField_AddInvestmentProcess(IWebDriver driver, int TrancheNumber, string InputFieldName)
        {
            string Xpath = $"(//descendant::span[text()='Tranche {TrancheNumber}'])[2]/following::p[contains(text(),'{InputFieldName}')][1]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement CheckEstimatedMonthlyIncome_AddInvestmentProcess(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"(//descendant::span[text()='Tranche {TrancheNumber}'])[2]/following::p[contains(text(),'Estimated Monthly Income')][1]/following-sibling::h6";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static string CheckAmountTobeInvested_EditInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::span[contains(text(),'Amount to be Invested:')]/span";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
           
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",","");
        }







    }
}
