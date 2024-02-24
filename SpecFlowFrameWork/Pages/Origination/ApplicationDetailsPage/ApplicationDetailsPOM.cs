using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yrefy_AutomationProject.Utility.CostumException;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage
{
    public class ApplicationDetailsPOM
    {
        public static string GetName_PersonalDetails_ApplicationDetailsPage(IWebDriver driver)
        {
            string Xpath = $"//div[normalize-space()='Name']/following-sibling::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath)).Text;
        }
    public static string GetName_PersonalDetails_BorrowerDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//div[normalize-space()='Name']/following-sibling::div";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Text;
    }
    public static void ClickOnWelcomeLetters_ApplicationDetailsPage(IWebDriver driver)
        {
            string Xpath = $"//a[normalize-space()='Welcome Letters']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement ClickOnBorrowerDetails_ApplicationDetailsPage(IWebDriver driver)
        {
            string Xpath = $"//a[normalize-space()='Borrower Details']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
    public static IWebElement ClickOnCoBorrowerDetails_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Co-Applicant Details']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnDocuments_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Documents']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnBorrowerDocuments_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Borrower Documents']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement ClickOnCoBorrowerDocuments_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Co-Borrower Documents']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static void SelectCoBorrowerNamed_ApplicationDetailsPage(IWebDriver driver,string CoBorrowerName)
    {
      string Xpath = $"//*[contains(text(),'{CoBorrowerName}')]/ancestor::div[@aria-selected][1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Thread.Sleep(1000);
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(3000);

    }

    //**************************************************************BorrowerDocument elements********************************************************************************
    public static IWebElement SelectRequiredDocuments_BorrowerDocumentPage(IWebDriver driver)
    {
      string Xpath = $"//mat-select[@placeholder='Select Required Document']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static void ClickOnAddDocument_BorrowerDocumentPage(IWebDriver driver)
    {
      string Xpath = $"//mat-select/following::button[descendant::mat-icon[(normalize-space()='add')]][1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static Boolean CheckDocumentField_BorrowerDocumentPage(IWebDriver driver,string documentPaper)
    {
      string Xpath = $"//mat-card/descendant::b[normalize-space()='{documentPaper}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Thread.Sleep(1000);
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Displayed;
    }
    public static int ChickUploadedDocument_BorrowerDocumentPage(IWebDriver driver, string documentPaper)
    {
      string Xpath = $"//mat-card/descendant::b[normalize-space()='{documentPaper}']/following::tbody[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Thread.Sleep(1000);
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElements(By.XPath($"{Xpath}/descendant::tr")).Count;
    }
    public static void ChickViewDocument_BorrowerDocumentPage(IWebDriver driver)
    {
      string Xpath = $"(//mat-icon[normalize-space()='find_in_page'])[last()]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Thread.Sleep(1000);
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ExpandMoreAction_BorrowerDocumentPage(IWebDriver driver)
    {
      string Xpath = $"(//mat-icon[normalize-space()='more_vert'])[last()]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Thread.Sleep(1000);
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ChickDownloadDocument_BorrowerDocumentPage(IWebDriver driver)
    {
      string Xpath = $"(//mat-icon[normalize-space()='download'])[last()]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Thread.Sleep(1000);
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static string ClickonUploadDocument_BorrowerDocumentPage(IWebDriver driver)
    {
      string Xpath = $"(//mat-card/descendant::span[normalize-space()='file_upload'][1])[last()]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Thread.Sleep(1000);
      string cardName = driver.FindElement(By.XPath($"{Xpath}/preceding::b[1]")).Text;
      driver.FindElement(By.XPath(Xpath)).Click();
      return cardName;
    }

    //********************************************************Element of Welcome letter ***********************************************************************************
        public static void ClickOnAddWelcomeLetters_ApplicationDetailsPage(IWebDriver driver)
        {
            string Xpath = $"//span[normalize-space()='Welcome letter']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
    public static int CheckCoBorrowerIsAvailable_BorrowerType_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//td[@data-label='Borrower Type'][contains(text(),'Co-Applicant')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      int count=driver.FindElements(By.XPath(Xpath)).Count();
      return count;
    }
    public static void SelectBorrowerType_AddWelcomeLetterPopup(IWebDriver driver,string BorrowerType)
        {
            string Xpath = $"//mat-dialog-content/descendant::mat-select[@formcontrolname='borrowerType']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(Xpath)).SendKeys(BorrowerType);

            Thread.Sleep(1000);
        }
        public static void SelectCoBorrowerName_AddWelcomeLetterPopup(IWebDriver driver,int? index=1)
        {
            string Xpath = $"//mat-dialog-content/descendant::mat-select[@formcontrolname='coBorrowerName']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            try
            {

            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath($"{Xpath}/following::mat-option[{index}]")).Click();
            }
            catch 
            {
                try
                {                                       
                throw new CustomException("Co-Applicant is not added here");
                }
                catch (CustomException e)
                {
                   throw e;
                }
                catch
                {
                    
                }                
            }
           
            

        }
        public static string ReadBorrowerName_AddWelcomeLetterPopup(IWebDriver driver)
        {
            string Xpath = $"//mat-dialog-content/descendant::input[@formcontrolname='borrowerName']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).GetAttribute("value");            
        }
        public static IWebElement EnterEmail_AddWelcomeLetterPopup(IWebDriver driver)
        {
            string Xpath = $"//mat-dialog-content/descendant::input[@formcontrolname='email']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

          return  driver.FindElement(By.XPath(Xpath));

        }
        public static void EnterLoanAmount_AddWelcomeLetterPopup(IWebDriver driver, string LoanAmount)
        {
            string Xpath = $"//mat-dialog-content/descendant::input[@formcontrolname='loanAmount']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            driver.FindElement(By.XPath(Xpath)).SendKeys(LoanAmount);
        }
    public static IWebElement EnterPaymentAmount_AddWelcomeLetterPopup(IWebDriver driver)
    {
      string Xpath = $"//mat-dialog-content/descendant::input[@formcontrolname='lenderLoanPayment']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static void ClickOnSendButton_AddWelcomeLetterPopup(IWebDriver driver)
        {
            string Xpath = $"//mat-dialog-actions/descendant::button[normalize-space()='Send']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();

        }
        public static void EnterLoanTerm_AddWelcomeLetterPopup(IWebDriver driver, string LoanTerm)
        {
            string Xpath = $"//mat-dialog-content/descendant::input[@formcontrolname='loanTerm']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).SendKeys(LoanTerm);

        }
    public static void EnterLenderLoanTerm_AddWelcomeLetterPopup(IWebDriver driver, string LoanTerm)
    {
      string Xpath = $"//mat-dialog-content/descendant::input[@formcontrolname='lenderLoanTerm']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).SendKeys(LoanTerm);
    }
    public static void EnterApr_AddWelcomeLetterPopup(IWebDriver driver, string apr)
    {
      string Xpath = $"//mat-dialog-content/descendant::input[@formcontrolname='lenderInterestRate']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).SendKeys(apr);
    }
    public static Boolean CheckPaymentAmount_AddWelcomeLetterPopup(IWebDriver driver, int loanTerm, double loanAmount)
        {
            string Xpath = $"//mat-dialog-content/descendant::input[last()]";
            //double PAmount = Math.Round(loanAmount / loanTerm,2);
            double pAmount=Formule.CalculatPaymentAmount(loanTerm, loanAmount);
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            if (driver.FindElement(By.XPath(Xpath)).Text.Contains(pAmount.ToString()))
                return true;
            else
                return false;
        }

        public static Boolean CheckWelcomeDetailsInList_AddWelcomeLetterPopup(IWebDriver driver, string ElementName,string ElementValue,int? RowNumber=1)
        {   //ElementName=Borrower Name|Email|Borrower Type|Loan Amount|
            string Xpath = $"//tbody/descendant::tr[{RowNumber}]/descendant::td[@data-label='{ElementName}']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text.Trim('$').Replace(",","").Contains(ElementValue);

        }
    
    public static IWebElement CheckResendButton_AddWelcomeLetterPopup(IWebDriver driver,int? RowNumber=1)
        {
            string Xpath = $"//tbody/descendant::tr[{RowNumber}]/descendant::button[contains(@title,'Resend')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
    //************************************************************************Loan details page*******************************************************************************************

      public static IWebElement ClickOnFinancialDetailsSection_ApplicationDetailsPage(IWebDriver driver)
      {
      string Xpath = $"//a[normalize-space()='Financial Details']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
      }
      public static IWebElement ClickOnLoanDetailsSection_ApplicationDetailsPage(IWebDriver driver)
      {
      string Xpath = $"//a[normalize-space()='Loan Details']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
      }
    public static IWebElement ClickOnNegotiateLoanDetailsSection_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Negotiate Loan']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }

    public static void ClickOnAddLoanButton_ApplicationDetailsPage(IWebDriver driver, int? RowNumber = 1)
      {
      string Xpath = $"//span[normalize-space()='Loan']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      }
    
      public static void ExpandInnerTableOfLoanTable_ApplicationDetailsPage(IWebDriver driver, int? RowNumber = 1)
      {
      string Xpath = $"(//tr/descendant::button/descendant::mat-icon[contains(text(),'expand')])[{RowNumber}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(2000);
      }
      public static void ClickOnDeletButton_LoanTable_ApplicationDetailsPage(IWebDriver driver, int? RowNumber = 0)
      {
      string Xpath = $"(//tr/descendant::button[contains(@title,'Delete Loan')])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      //driver.FindElement(By.XPath(Xpath)).Click();
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

      visibleElements[(int)RowNumber].Click();
      Thread.Sleep(2000);
      }
    public static void ClickOnConfirmDelete_DeletLoanPOPup_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//interbiz-confirm-box/descendant::button[child::span[text()='CONFIRM']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();      
      Thread.Sleep(2000);
    }
    public static void SelectValue_AddLoanPopup_ApplicationDetailsPage(IWebDriver driver,string fieldName,string Option)
      {
      string Xpath = $"//mat-dialog-container/descendant::mat-label[normalize-space()='{fieldName}']/preceding::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(Option);
      Thread.Sleep(2000);
    }
    

    public static void EnterInputValue_AddLoanPopup_ApplicationDetailsPage(IWebDriver driver, string elementName, string value)
      {//mat-dialog-container/descendant::mat-label[normalize-space()='{elementName}']/preceding::mat-select[1]
      string Xpath = $"//mat-dialog-container/descendant::mat-label[normalize-space()='{elementName}']/preceding::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(value);
      Thread.Sleep(2000);
       }
       public static void ClickOnButton_AddLoanDebtsPopup_ApplicationDetailsPage(IWebDriver driver, string buttonName)
       {
       string Xpath = $"//mat-dialog-container/descendant::button[normalize-space()='{buttonName}']";
       WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
       Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

       driver.FindElement(By.XPath(Xpath)).Click();
       Thread.Sleep(2000);
       }
    
      public static string CheckLoandetails_AddLoanPopup_ApplicationDetailsPage(IWebDriver driver,string cardName,string elementName, int RowNumber)
      {//Loan Type|Total Loan Amount|Status    //cardName=Federal Student Loans|Private Student Loans
      string Xpath = $"(//mat-card-title[descendant::b[contains(text(),'{cardName}')]]/following::tr/descendant::td[contains(@data-label,'{elementName}')])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

      string result = visibleElements[RowNumber-1].Text.ToString();
      
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));    
      return visibleElements[RowNumber-1].Text.Trim(' ').Trim('$').Replace(",","");
      }
       public static void ClickOnAddFile_Loandetails_ApplicationDetailsPage(IWebDriver driver,int buttonNumber)
       {
         string Xpath = $"//span[text()='file_upload']";
         WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));         
         IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
         IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
         visibleElements[buttonNumber].Click();
    }
    public static void CheckCardTitle_ApplicationDetailsPage(IWebDriver driver, string cardName)
    {
      string Xpath = $"//mat-card-title[descendant::b[contains(text(),'{cardName}')]]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));     
    }
    public static Boolean CheckUploadedFile_Loandetails_ApplicationDetailsPage(IWebDriver driver,string filename, int buttonNumber)
    {
      string Xpath = $"//td[@data-label='File Name']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

      string result = visibleElements[buttonNumber].Text.ToString();
      bool r=result.Contains(filename);
      return r;
    }
    //************************************************************************Debt details page*******************************************************************************************

    public static void ClickOnAddDebtsButton_ApplicationDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[normalize-space()='Debts']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(Xpath)));
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      Thread.Sleep(3000);
    }
    public static void SelectDebtsType_AddDebtsPopup_ApplicationDetailsPage(IWebDriver driver, string Option)
    {
      string Xpath = $"//mat-dialog-container/descendant::mat-label[normalize-space()='Debts Type']/preceding::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(Option);
      Thread.Sleep(2000);
    }
    public static void EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(IWebDriver driver, string elementName, string value)
    {
      string Xpath = $"//mat-dialog-container/descendant::mat-label[normalize-space()='{elementName}']/preceding::input[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).SendKeys(value);
      Thread.Sleep(2000);
    }
    public static string CheckDebtdetails_AddDebtsPopup_ApplicationDetailsPage(IWebDriver driver, string elementName, int RowNumber)
    {//Loan Type|Total Loan Amount|Status
      string Xpath = $"(//tr/descendant::td[contains(@data-label,'{elementName}')])[{RowNumber}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath)).Text.Trim(' ').Trim('$').Replace(",", "");
    }
    //**************************************************************Negotiation Element*************************************************************************
    public static void ClickOnAddNegotiationButton_ApplicationDetailsPage(IWebDriver driver, int? RowNumber = 1)
    {
      string Xpath = $"//span[normalize-space()='Negotiation']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
    }

    //************************************************************Income Details***********************************************************************************
    public static void NavigateToIncomeDetailsSection(IWebDriver driver)
    {
      string Xpath = $"//a[normalize-space()='Income Details']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
  }
}
