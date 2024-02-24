using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using SpecFlowFrameWork.Utility;

namespace SpecFlowFrameWork.Pages.InvstmentsPagePOM
{
    public class InvestmentPagePOM
    {
        public static void NavigateToInvestmentPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::span[text()='Investments']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
            
        }
        public static void EnterInputToFilter_InvestmentsPage(IWebDriver driver,string FlterName,string FilterValue)
        {//FilterName=Investor name|Offering Name|Company Name

            string Xpath = $"//descendant::mat-label[contains(text(),'{FlterName}')]/preceding::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Clear();
            driver.FindElement(By.XPath(Xpath)).SendKeys(FilterValue);
        }
        public static void ClickOnMoreFilter_InvestmentsPage(IWebDriver driver)
        {
            Thread.Sleep(1000);
            string Xpath = $"//descendant::button/descendant::span[contains(text(),'MORE FILTERS')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnStatusFilter_InvestmentsPage(IWebDriver driver)
        {

            string Xpath = $"//descendant::mat-label[contains(text(),'Investment Status')]/preceding::mat-select[1]|//descendant::mat-label[contains(text(),'Status')]/preceding::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnRefereshButton_InvestmentPage(IWebDriver driver)
        {
            string Xpath = $"(//descendant::button[contains(@mattooltip,'Refresh')]/descendant::span[1])[2]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void SelectStatusFromFilterDropDown_InvestmentsPage(IWebDriver driver,string StatusOption)
        {

            string Xpath = $"//descendant::span[text()='{StatusOption}']/preceding-sibling::mat-pseudo-checkbox";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static string CheckStatusOfInvestment_InvestmentsPage(IWebDriver driver,int RowNumber)
        {

            string Xpath = $"//tbody/descendant::tr[{RowNumber}]/descendant::td[contains(@data-label,'Status')]/descendant::mat-chip";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static IWebElement CheckInvestoreInList(IWebDriver driver, int RowNumber)
        {
            string Xpath = $"//descendant::tbody/descendant::tr[{RowNumber}]/descendant::a";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static string CheckInvestmentDetails_InvestmentsPage(IWebDriver driver, string KeyText)
        {
            string Xpath = $"//descendant::mat-card/descendant::div[text()='{KeyText}']/following-sibling::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static void ClickOnEditbutton_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//button/descendant::span[text()='Edit']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement ClickOneSignButton_CompanyeSign_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"(//button/descendant::span[contains(text(),'Click to eSign')])[2]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement ClickOneSignButton_InvestoreSign_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"(//button/descendant::span[contains(text(),'Click to eSign')])[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnConfirmButton_CompanyeSignButton_InvestoreSign_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::button/child::span[text()='CONFIRM']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
    public static IWebElement ClickOnConfirmButton_AdditionalInfoStep_InvestmentsPage(IWebDriver driver)
    {
      string Xpath = $"//descendant::button[descendant::div[contains(text(),'Confirm')]]|//descendant::button[descendant::div[contains(text(),'Proceed')]]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static string CheckInvestedAmoount_MakePaymentStep_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::span[contains(text(),'Amount to be Invested')]/span";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

           return driver.FindElement(By.XPath(Xpath)).Text.Trim();
        }
        public static void ClickOnConfirm_MakePaymentStep_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::mat-dialog-container/descendant::span[contains(text(),'Confirm')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void SelectMakePaymentType_InvestmentsPage(IWebDriver driver,string PaymentChannel)
        {
            string Xpath = $"//descendant::mat-dialog-container/descendant::span[contains(text(),'{PaymentChannel}')]/preceding-sibling::span";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            
        }
        public static IWebElement SelectElementForCommission_InvestmentsPage(IWebDriver driver, string SelectElementForCommission,int Index)
        {//Select Finder for Commission|Select Sales Rep for Commission
            string Xpath = $"//descendant::span[contains(text(),'{SelectElementForCommission}')]/ancestor::mat-card[1]/descendant::mat-list-option[{Index}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnDoubleClick_FinalizeStep_InvestmentsPage(IWebDriver driver, string ElementNameForCommission)
        {//Select Finder for Commission|Select Sales Rep for Commission
            string Xpath = $"//descendant::span[contains(text(),'{ElementNameForCommission}')]/ancestor::mat-card[1]/following::mat-icon[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnSetPermissionButton_FinalizeStep_InvestmentsPage(IWebDriver driver, string ElementNameForCommission)
        {//Select Finder for Commission|Select Sales Rep for Commission
            string Xpath = $"//descendant::span[contains(text(),'{ElementNameForCommission}')]/following::div[contains(text(),'Set Compensation')][1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void EnterPaymentRecieptDate_FinalizeStep_InvestmentsPage(IWebDriver driver, string Date)
        {
            string Xpath = $"//descendant::div[contains(text(),'Payment Method:')]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).SendKeys(Date);
        }
        public static void ClickOnSavePaymentRecieptDate_FinalizeStep_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[contains(text(),'Payment Method:')]/following::button/descendant::div[contains(text(),'Save')][1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnFinalizeButton_FinalizeStep_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[text()='Finalize']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnConfirmButton_FinalizeInvestment_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//interbiz-confirm-box/descendant::button/span[text()='CONFIRM' or text()='Confirm']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnNextButton_InvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"(//span[normalize-space()='NEXT'])[2]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
    public static void ClickOnUserButton_InvestorUser_InvestmentProcess(IWebDriver driver)
    {
      string Xpath = $"(//span[normalize-space()='User'])|(//span[normalize-space()='USER'])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static Boolean CheckFinderCommission_FinalizeStep_InvestmentsPage(IWebDriver driver,int commision)
        {
            string Xpath = $"//descendant::span[contains(text(),'Offering Level Finder Commission')]/following::div[contains(text(),'Tranche')]/following::div[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> ILCommission=driver.FindElements(By.XPath(Xpath));
            foreach(IWebElement tranche in ILCommission)
            {
                if (!tranche.Text.Contains(commision.ToString()))
                    return false;

            }
            return true;
        }
        public static void EnterFinderCommission_FinalizeStep_InvestmentsPage(IWebDriver driver,int Commission,int? TrancheNumber=1)
        {
            string Xpath = $"//descendant::div[contains(text(),'Finder 1:')]/following::input[{TrancheNumber}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).SendKeys(Commission.ToString());
        }
        public static void EnterSalesRepCommission_FinalizeStep_InvestmentsPage(IWebDriver driver,int Commission, int? TrancheNumber = 1)
        {
            string Xpath = $"//descendant::div[contains(text(),'Sales Rep 1:')]/following::input[{TrancheNumber}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).SendKeys(Commission.ToString());
        }
        public static void ClickOnSaveFinderCommission_FinalizeStep_InvestmentsPage(IWebDriver driver)
        {
            Thread.Sleep(1000);
            string Xpath = $"//descendant::div[contains(text(),'Finder 1:')]/following::div[contains(text(),'Save')][1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnSaveSaleRepCommission_FinalizeStep_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[contains(text(),'Sales Rep 1:')]/following::div[contains(text(),'Save')][1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static Boolean CheckInvestmentDate_InvestmentsPage(IWebDriver driver,string Date)
        {
            string Xpath = $"//descendant::tbody/descendant::tr[1]/td[contains(@class,'investmentDate')]/descendant::div[contains(text(),'{Date}')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }
        
        
        public static string CheckInvestmentAmount_InvestmentDetails_InvestmentsPage(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[2]/ancestor::mat-card[1]/descendant::div[contains(text(),'Investment Amount')]/following-sibling::div|(//span[contains(text(),'Tranche {TrancheNumber}')])/ancestor::mat-card[1]/descendant::div[contains(text(),'Investment Amount')]/following-sibling::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",","").ToString();
        }
        public static string CheckInvestmentAmountCompanyProfile_InvestmentDetails_InvestmentsPage(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::div[contains(text(),'Investment Amount')]/following-sibling::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",", "").ToString();
        }
        public static string CheckMonthlyIncomePercentage_InvestmentDetails_InvestmentsPage(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[2]/ancestor::mat-card[1]/descendant::div[contains(text(),'Monthly Income')]/following-sibling::div|(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::div[contains(text(),'Monthly Income')]/following-sibling::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text.Trim('%').ToString();
        }
        public static string CheckMonthlyIncomePercentageCompanyProfile_InvestmentDetails_InvestmentsPage(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"(//span[contains(text(),'Tranche {TrancheNumber}')])[1]/ancestor::mat-card[1]/descendant::div[contains(text(),'Monthly Income')]/following-sibling::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text.Trim('%').ToString();
        }
        //**************************************************************ForSalesRep_Element**********************************************************************************
        public static void SelectInvestor_InvestOnBehalfOfInvestor_InvestmentsPage(IWebDriver driver, string InvestorName)
        {
            string Xpath = $"//label[normalize-space()='Investor']/following::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            
            //driver.FindElement(By.XPath(Xpath)).Click();
            //driver.FindElement(By.XPath($"{Xpath}/following::input[contains(@placeholder,'Search')]")).SendKeys(InvestorName);
            //driver.FindElement(By.XPath($"//mat-dialog-actions/descendant::button[normalize-space()='{InvestorName}']"));
            //driver.FindElement(By.XPath("//mat-dialog-actions")).Click();
            driver.FindElement(By.XPath(Xpath)).SendKeys(InvestorName);
            Thread.Sleep(1000);
        }
        public static void SelectInvestorUser_InvestOnBehalfOfInvestor_InvestmentsPage(IWebDriver driver, string InvestorName)
        {
            string Xpath = $"//label[normalize-space()='Investor User']/following::mat-select[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            //SelectElement sel = new SelectElement(driver.FindElement(By.XPath(Xpath)));
            //sel.SelectByText(InvestorName);
            
            driver.FindElement(By.XPath(Xpath)).SendKeys(InvestorName);
            Thread.Sleep(1000);
        }
        public static void ClickOnInvest_InvestOnBehalfOfInvestor_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//mat-dialog-actions/descendant::button[normalize-space()='Invest']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(1000);
        }
    }
}
