using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowFrameWork.Utility;
using OpenQA.Selenium.Interactions;

namespace SpecFlowFrameWork.Pages.OfferingPagePOM
{
    public class OfferingPagePOM
    {

        public static void NavigateToOfferingPage(IWebDriver driver)
        {
            string Xpath = "//span[normalize-space()='Offerings']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

           driver.FindElement(By.XPath(Xpath)).Click();
            BaseClass.WaitForSpinnerToDisappear(driver);


        }
        public static void ClickOnSimulateMyInvestmentField(IWebDriver driver)
        {
            string Xpath = "//descendant::div[contains(text(),'Simulate My Investment')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
            BaseClass.WaitForSpinnerToDisappear(driver);


        }

        public static IWebElement EnterValueToSearch_OfferingPage(IWebDriver driver,string FilterName)
        {
            string Xpath = $"//label/mat-label[text()='{FilterName}']/preceding::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return  driver.FindElement(By.XPath(Xpath));
            


        }
        
        public static IWebElement CheckOfferInList(IWebDriver driver,int RowNumber)
        {
            string Xpath = $"//descendant::tbody/descendant::tr[{1}]/descendant::a";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));



        }
        public static void ClickOnApplyButton(IWebDriver driver)
        {
            string Xpath = $"//descendant::button/span[contains(text(),'APPLY') or contains(text(),'Apply')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Actions act =new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
            



        }

        ///******************************************************Simulator Elements*****************************************
        public static void ClickOnSimulateButton(IWebDriver driver,int ButtonNumber)
        {
            string Xpath = $"(//button/descendant::span[normalize-space()='SIMULATE'])[{ButtonNumber}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
        }
        public static void ClickOnSaveAndInvestButton(IWebDriver driver, int ButtonNumber)
        {
            string Xpath = $"(//button/descendant::span[normalize-space()='SAVE & INVEST NOW'])[{ButtonNumber}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
        }
        public static int CheckNumberOfYearTable_CalculationTable(IWebDriver driver)
        {
            string Xpath = $"(//mat-table)[1]/descendant::mat-row/descendant::span[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElements(By.XPath(Xpath)).Count();
        }
        public static int CheckNumberOfMonthTable_CalculationTable(IWebDriver driver,int RowNumber)
        {
            int[] Array = { 0, 2, 4, 6, 8, 10 };
            string Xpath = $"(//mat-table)[1]/descendant::mat-row[{Array[RowNumber]}]/descendant::tr";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElements(By.XPath(Xpath)).Count();
        }
        public static (IWebElement,string) ExpandYearTable_CalculationTable(IWebDriver driver,int YearRow)
        {
            int[] RowArray = {0,1,3,5,7,9,11,13,15,17,19,21}; 
            string Xpath = $"(//mat-table)[1]/descendant::mat-row[{RowArray[YearRow]}]/descendant::span[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            //Actions act = new Actions(driver);
            //act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
            return (driver.FindElement(By.XPath(Xpath)),driver.FindElement(By.XPath($"(//mat-table)[1]/descendant::mat-row[{RowArray[YearRow]}]/descendant::span[2]")).Text);
        }
        public static IDictionary<string, string> ReadYearData_CalculationTable(IWebDriver driver, int RowNumber)
        {
            int[] RowArray= {0, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
            string Xpath = $" (//mat-table)[1]/descendant::mat-row[{RowArray[RowNumber]}]/descendant::mat-cell/div[ not (descendant::span)]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> data = driver.FindElements(By.XPath(Xpath));
            Dictionary<string, string> myDict = new Dictionary<string, string>
            {
               
            {"Principal", data[0].Text.Trim('$').Replace(",", "")},
            {"Earning", data[1].Text.Trim('$').Replace(",", "")},
            {"Payout",  data[2].Text.Trim('$').Replace(",", "")},
            {"EndBalance", data[3].Text.Trim('$').Replace(",", "")}
            };
            
            return myDict;



        }
        public static IDictionary<string,string> ReadMonthlyData_CalculationTable(IWebDriver driver, int YearRow,int MonthRow)
        {
            int[] RowArray = { 0,2,4, 6, 8, 10,12, 14, 16, 18, 20,22 };
            string Xpath = $"(//mat-table)[1]/descendant::mat-row[{RowArray[YearRow]}]/descendant::tr[{MonthRow}]/td";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> data=driver.FindElements(By.XPath(Xpath));
            Dictionary<string, string> myDict = new Dictionary<string, string>
            {
                {"Month", data[0].Text.Trim('$').Replace(",","")},
            {"Principal", data[1].Text.Trim('$').Replace(",","")},
            {"Earning", data[2].Text.Trim('$').Replace(",", "")},
            {"Payout", data[3].Text.Trim('$').Replace(",", "")},
            {"EndBalance", data[4].Text.Trim('$').Replace(",", "")}
            };
           
            return myDict;
        }

        public static void EnterReInvestValue(IWebDriver driver,int ParentTrancheNumber,string ReinvestTrancheName,int ReinvestValue)
        {
            string Xpath = $"(//mat-card/descendant::span[contains(text(),'Tranche {ParentTrancheNumber}')])[1]/following::p[contains(text(),'{ReinvestTrancheName}')][1]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Clear();
            driver.FindElement(By.XPath(Xpath)).SendKeys(ReinvestValue.ToString());
        }
        public static void ExpandReInvestSection(IWebDriver driver, int ParentTrancheNumber)
        {
            string Xpath = $"(//mat-card/descendant::span[contains(text(),'Tranche {ParentTrancheNumber}')])[1]/following::p[contains(text(),'Re-invest on Maturity')][1]/following-sibling::span";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(2000); 
        }
        public static int CheckWithdrawAmount_ReinvestSection_Simulator(IWebDriver driver, int ParentTrancheNumber)
        {
            string Xpath = $"(//mat-card/descendant::span[contains(text(),'Tranche {ParentTrancheNumber}')])[1]/following::p[contains(text(),'Withdraw Amount')][1]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return Int32.Parse(driver.FindElement(By.XPath(Xpath)).GetAttribute("value"));           
            
        }
        public static void ClickOnTranche_CalculationTable_Simulator(IWebDriver driver, string TrancheName)
        {
            string Xpath = $"//div[contains(text(),'{TrancheName}')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(2000);

        }
        public static string CheckEstimatedMonthlyIncome_Simulator(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[contains(text(),' Estimated Monthly Income')][1]/following-sibling::h6";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Thread.Sleep(2000);
            return driver.FindElement(By.XPath(Xpath)).Text.Trim('$');

        }
    }
}
