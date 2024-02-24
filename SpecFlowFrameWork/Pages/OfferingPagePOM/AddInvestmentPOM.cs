using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using NUnit.Framework;

namespace SpecFlowFrameWork.Pages.OfferingPagePOM
{
    public class AddInvestmentPOM
    {

        public static void ClickOnInvestNowField(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[contains(text(),'Invest Now')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
    public static string SelectOption_DropDown_InvestmentPage(IWebDriver driver, string ElementName, int selectByIndex, int? elementIndex = 1)
    {
      string Xpath = $"//label[contains(text(),'{ElementName}')]/following::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement element = elements.FirstOrDefault(element => element.Displayed);

      element.Click();
      Thread.Sleep(2000);
      IList<IWebElement> OptionList = new List<IWebElement>();
      OptionList = driver.FindElements(By.XPath("//mat-option"));
      Thread.Sleep(2000);
      OptionList[selectByIndex].Click();
      Thread.Sleep(2000);
      string q = element.Text;
      return element.Text;
    }
    public static IWebElement SelectInvestorAccount_Sendkey(IWebDriver driver, string ElementName)
    {
      string Xpath = $"//label[contains(text(),'Account')]/following::mat-select[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static void ClickOnInvestForAnInvestorField(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[contains(text(),'Invest for an Investor')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static IWebElement ClickOnEditbutton_InvestmentsPage(IWebDriver driver)
        {
            string Xpath = $"//button/descendant::span[text()='Edit']";
            Thread.Sleep(10000);
            //WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement ClickOnInvestmentStepTitle(IWebDriver driver,string StepName)
        {
            string Xpath = $"//descendant::span[contains(text(),'{StepName}')]/ancestor::mat-step-header";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnSaveNextButton_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"(//span[normalize-space()='SAVE & NEXT'])[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
    public static void ClickOnInvestButton_SelectInvestorAccountForInvestment_AddInvestmentProcess(IWebDriver driver)
    {
      string Xpath = $"(//button/descendant::span[normalize-space()='Invest'])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
     
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      Actions act = new Actions(driver);
      act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
    }
    public static IWebElement EnterInvestmentAmount_AddInvestmentProcess(IWebDriver driver,int TrancheNumber)
        {
            string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[text()='Investment Amount'][1]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));            
            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement EnterInputToTrancheField_AddInvestmentProcess(IWebDriver driver, int TrancheNumber,string InputFieldName)
        {
            string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[contains(text(),'{InputFieldName}')][1]/following::input[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
    public static IWebElement ReadValueOfTrancheField_AddInvestmentProcess(IWebDriver driver, int TrancheNumber, string FieldName)
    {
      string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[contains(text(),'{FieldName}')][1]/following-sibling::h6";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement CheckEstimatedMonthlyIncome_AddInvestmentProcess(IWebDriver driver, int TrancheNumber)
        {
            string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[contains(text(),'Estimated Monthly Income')][1]/following-sibling::h6";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ScrollCompoundIncomeBar_AddInvestmentProcess(IWebDriver driver, int TrancheNumber, int ScrollTo)
        {
            string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::div[contains(@class,'mat-slider-thumb')][1]/child::div[2]";
            string CurrentPositionXpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::div[contains(@class,'mat-slider-track-wrapper')][1]";
            string DestXpath = $"//descendant::span[text()='Tranche 1']/following::div[contains(@class,'mat-slider-track-fill') and contains(@style,'{ScrollTo}')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            int num= driver.FindElement(By.XPath(CurrentPositionXpath)).Size.Width;
            int DesiredPosition =( num * ScrollTo/100);
            Actions act=new Actions(driver);
            act.ClickAndHold(driver.FindElement(By.XPath(Xpath))).MoveByOffset(-num, 0).Release().Perform();
            Thread.Sleep(500);
            act.ClickAndHold(driver.FindElement(By.XPath(Xpath))).MoveByOffset(DesiredPosition,0).Release().Perform();
        }
        public static string CheckEstimatedMonthlyIncome_AddInvestmentProcess(IWebDriver driver, string TrancheNumber)
        {
            string Xpath = $"//descendant::span[text()='Tranche {TrancheNumber}']/following::p[contains(text(),'Estimated Monthly Income')][1]/following-sibling::h6";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text;
        }
        public static IWebElement ClickOnConfirmButton_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//mat-dialog-container/descendant::span[contains(text(),'CONFIRM') or contains(text(),'CONFIRM') ]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }

        //Investor eSign section element
        public static IWebElement ClickOneSignButton_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//button/descendant::span[contains(text(),'Click to eSign')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            return driver.FindElement(By.XPath(Xpath));
        }


        public static IList<IWebElement> CheckDocumentsOnInvestoreesignStep_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//yrefy-workspace-is-mandatory-document/descendant::span[not (contains(text(),'*'))]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElements(By.XPath(Xpath));
        }

        public static IWebElement ClickOnContinue_DocumentPage_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::button[contains(text(),'Continue')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickToSign_AddInvestmentProcess(IWebDriver driver,int? elementNumber=1)
        {
            string Xpath = $"(//descendant::input[contains(@placeholder,'Click here to sign')]/following::div[contains(@aria-label,'Click')])[{elementNumber}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                            
             Actions act=new Actions(driver);
             IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
             executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
             driver.FindElement(By.XPath(Xpath)).Click();
             //act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click();      
             //act.Perform();          

        }
    public static void ClickToSignRemainingField_AddInvestmentProcess(IWebDriver driver)
    {
      string Xpath = $"(//descendant::input[contains(@placeholder,'Click here to sign')])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      //IWebElement element = elements.FirstOrDefault(element => element.Displayed);

      foreach (IWebElement element in elements)
      {

        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
        Thread.Sleep(2000);
        Actions act = new Actions(driver);
        act.MoveToElement(element).Click();
        act.Perform();
      }
      //driver.FindElement(By.XPath(Xpath)).Click();

    }
    public static void ClickOnNextButton_AdobeDoc_AddInvestmentProcess(IWebDriver driver)
    {
      string Xpath = $"//descendant::button[descendant::div[text()='Next']]|//descendant::button[descendant::div[text()='Start']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
     
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      Actions act = new Actions(driver);
      act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();

    }
    public static IWebElement EnterValueToAdobeDocument_AddInvestmentProcess(IWebDriver driver, int? elementNumber = 1)
    {
      string Xpath = $"(//descendant::input[contains(@placeholder,'Click here to sign')])[{elementNumber}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));    

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      Actions act = new Actions(driver);
      Thread.Sleep(1000);
      act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Build().Perform();
      return driver.FindElement(By.XPath(Xpath));
    }

    public static IWebElement AddSignForDocument_AddInvestmentProcess(IWebDriver driver)
        {
            Thread.Sleep(1000);
            string Xpath = $"//descendant::input[contains(@placeholder,'signature')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnApplyButton_DocumentSign_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::button[contains(text(),'Apply')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IWebElement element = elements.FirstOrDefault(element => element.Displayed);          

            element.Click();
        }
    public static void ClickOnCloseButton_DocumentSign_AddInvestmentProcess(IWebDriver driver)
    {
      string Xpath = $"//descendant::button[contains(text(),'Close')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement element = elements.FirstOrDefault(element => element.Displayed);

      element.Click();
    }
    public static void AddPrintedName_Document_AddInvestmentProcess(IWebDriver driver,string InputValue)
        {
            string Xpath = $"//descendant::input[contains(@type,'text') and contains(@name,'Custom Field')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).SendKeys(InputValue);
        }
        public static void ClickToSign_Document_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::button[contains(text(),'Click to Sign')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

             driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void DocumentSpinnerDisappear_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[contains(@class,'spinner large')]";
            
            Stopwatch stopwatch = new Stopwatch();
            WebDriverWait WaitShort = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            WebDriverWait WaitLong = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                stopwatch.Start();
                WaitShort.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                WaitLong.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));

                stopwatch.Stop();
                var timeSpan = stopwatch.ElapsedMilliseconds;


            }
            catch
            {

            }
        }
        public static void ClickOnRefereshButton_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::button[contains(@mattooltip,'Refresh')]/descendant::span[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
            Thread.Sleep(5000);
        }
        public static void ClickOnDownloadButton_AddInvestmentProcess(IWebDriver driver,int RowNumber)
        {
            string Xpath = $"(//tbody/descendant::button[contains(@title,'Download')])[{RowNumber}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnViewDocumentButton_AddInvestmentProcess(IWebDriver driver,int RowNumber)
        {
            string Xpath = $"(//tbody/descendant::button[contains(@title,'View Document')])[{RowNumber}]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnNextButton_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//span[normalize-space()='NEXT']/parent::button|//span[normalize-space()='Next']/parent::button";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement element = elements.FirstOrDefault(element => element.Displayed);
      element.Click();

      Thread.Sleep(5000);            
        }

        //Investor Accreditation section
        public static string CheckAccreditionStatus_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[contains(text(),'Accreditation Status')]/following-sibling::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

           return driver.FindElement(By.XPath(Xpath)).Text.Trim();
        }
        public static Boolean CheckAccreditionButton_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[contains(text(),'Accreditation Letter')]/parent::div/descendant::button";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> ButoonList= driver.FindElements(By.XPath(Xpath));
            Boolean result = true;
            foreach (IWebElement E in ButoonList)
            {
                if(!E.Enabled)
                return  result = false;
            }
            return result;


        }
        public static Boolean CheckInvestmentStatusAtTop_AddInvestmentProcess(IWebDriver driver,string InvestmentStatus)
        {//InvestmentStatus=InvestorSigned
            string Xpath = $"//descendant::mat-chip[contains(.,'{InvestmentStatus}')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Displayed;
        }

    public static string CheckInvestmentStatusAtTop_AddInvestmentProcess(IWebDriver driver)
    {//InvestmentStatus=InvestorSigned
      string Xpath = $"//descendant::mat-chip";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).Text;
    }
    public static IWebElement CheckCompanyeSign_MakePayment_FinalizeSectionMessage_AddInvestmentProcess(IWebDriver driver)
        {
            string Xpath = $"//descendant::div[@aria-expanded='true']/descendant::div[contains(@class,'card-title')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
    public static Boolean WaitForInvisibilityOfStepMessage_AddInvestmentProcess(IWebDriver driver)
    {
      string Xpath = $"//descendant::div[@aria-expanded='true']/descendant::div[contains(@class,'card-title')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
     return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));

      
    }
    public static IWebElement ClickOnAccreditationLetterButton_AccreditationStep_AddInvestmentProcess(IWebDriver driver)
        {
         string Xpath = $"//p-fileupload/descendant::span[text()='Accreditation Letter']";
         WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
         Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

         return driver.FindElement(By.XPath(Xpath));
        }
  }
}
