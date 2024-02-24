using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Collections;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;

namespace Yrefy_AutomationProject.Pages.Origination.ManageApplication
{
    public class AddApicationPOM
    {
        public static IWebElement ClickOnAddApplicationButton(IWebDriver driver)
        {
            string Xpath = "//span[normalize-space()='Application']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static void ClickOnAddApplication_Step(IWebDriver driver,string StepName)
        {//StepName=Loan Details|Personal Details|Contact Details|Financial Details|Employment Details|Education Details|
            string Xpath = $"//div[contains(text(),'{StepName}')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed);

              if (visibleElement != null)
              {
                visibleElement.Click();
              }
              else
              {
        Console.WriteLine("No visible element found.");
              }
     
        }
        public static void ClickOnEditLoan_AddApplicationDetails(IWebDriver driver,int? EditButtonNumber=0)
        {
            string Xpath = $"(//mat-icon[normalize-space()='edit' or normalize-space()='Edit'])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
           
           IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
           IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      if (visibleElements.Count > 0) 
           visibleElements[(int)EditButtonNumber].Click();      
        }
        public static void ClickOnEditFinance_AddApplicationDetails(IWebDriver driver, int? EditButtonNumber = 0)
        {
            string Xpath = $"(//mat-icon[normalize-space()='edit' or normalize-space()='Edit'])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      if (visibleElements.Count > 0)
        visibleElements[(int)EditButtonNumber].Click();
        }
        public static void ClickOnEditReference_AddApplicationDetails(IWebDriver driver, int? EditButtonNumber = 0)
        {
            string Xpath = $"(//mat-icon[normalize-space()='edit' or normalize-space()='Edit'])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      if (visibleElements.Count != 0)
      {

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElements[(int)EditButtonNumber]);
            visibleElements[(int)EditButtonNumber].Click();
      }
        }
        public static void ClickOnEditEmployment_AddApplicationDetails(IWebDriver driver, int? EditButtonNumber = 1)
        {
            string Xpath = $"(//mat-icon[normalize-space()='edit' or normalize-space()='Edit'])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
           

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
            if (visibleElements.Count > 0)
            visibleElements[(int)EditButtonNumber-1].Click();
        }
        public static void ClickOnDeletButton_AddApplicationDetails(IWebDriver driver, int? EditButtonNumber = 1)
        {
            string Xpath = $"(//mat-icon[normalize-space()='delete' or normalize-space()='Delete'])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
           

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      if (visibleElements.Count > 0)
        visibleElements[(int)EditButtonNumber - 1].Click();
        }
        public static int CheckNumberOfDetailsCard_AddApplicationDetails(IWebDriver driver, int? EditButtonNumber = 1)
        {
            string Xpath = $"(//mat-icon[normalize-space()='delete' or normalize-space()='Delete'])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));


            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

            return visibleElements.Count();
        }
        public static IWebElement ClickOnAddApplicationByNumber_Step(IWebDriver driver, int StepNumber)
        {
            string Xpath = $"//span[text()='{StepNumber}']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static string CheckSelectedStepNumber_Step(IWebDriver driver)
        {
            string Xpath = $"//div[contains(@class,'selected')]/descendant::span[text()]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath)).Text.Trim(' ');
        }
        public static void ClickOnSaveAndNextButton(IWebDriver driver)
        {
            string Xpath = $"//button/descendant::div[normalize-space()='Save & Next']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            


            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));            
            IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed);

            if (visibleElement != null)
            {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElement);
        visibleElement.Click();
            }
            else
            {
                Console.WriteLine("No visible element found.");
            }

        }
    public static IWebElement EnterInputValue_AddApplicationDetails(IWebDriver driver, string ElementName)
    {//ElementName=First Name|Email|Alt. Email|Phone cell|Phone Home|Phone Other|Middle Name|Last Name|Previous Name|Maiden Name|SSN|Date Of Birth|License Number
      string Xpath = $"(//mat-label[normalize-space()='{ElementName}']/preceding::input[1])[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static void ClickOnVisibilityButton_AddApplicationDetails(IWebDriver driver)
    {
      string Xpath = $"//mat-icon[contains(text(),'visibility')]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
    public static void ClearAllInput_AddApplicationDetails(IWebDriver driver)
    {
      string Xpath = $"//input";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      Thread.Sleep(5000);

      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      
      foreach (IWebElement element in visibleElements)
      {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        if (element.Displayed&&element.Enabled)
        {
          executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
          try
          {

          element.Click();
          }
          catch { }
          for(int i=0;i<=50;i++)
          {
            element.SendKeys(Keys.Backspace);
          }
          for (int i = 0; i <= 50; i++)
          {
            element.SendKeys(Keys.Delete);
          }
        }
      }
      
    }
        public static void EnterInputValueToMultipleField_AddApplicationDetails(IWebDriver driver, string ElementName,string InputValue)
        {//ElementName=First Name|Email|Alt. Email|Phone cell|Phone Home|Phone Other|Middle Name|Last Name|Previous Name|Maiden Name|SSN|Date Of Birth|License Number
            string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::input[1])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

            
            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
            int i=0;
            foreach(IWebElement element in visibleElements)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
                if(element.Enabled)
                {
                element.Clear();
                if(ElementName.ToLower().Contains("email"))
                    element.SendKeys($"{InputValue}");
                else
                element.SendKeys($"{InputValue} {i}");  
                }
                i++;
        Thread.Sleep(1000);
            }        
            
        }
        public static IWebElement SelectValue_AddApplicationDetails(IWebDriver driver, string ElementName)
        {//ElementName=bestTimeToCall|driversLicense
            string Xpath = $"//mat-select[@formcontrolname='{ElementName}']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
        public static IWebElement SelectValueLoanDetails_AddApplicationDetails(IWebDriver driver, string ElementName)
        {//ElementName=bestTimeToCall|driversLicense
            string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::mat-select[1])";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            return driver.FindElement(By.XPath(Xpath));
        }
    public static string SelectOptionDetails_DropDown_AddApplicationDetails(IWebDriver driver, string ElementName,int selectByIndex)
    {//ElementName=bestTimeToCall|driversLicense
      string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::mat-select[1])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement element= elements.FirstOrDefault(element => element.Displayed);

      element.Click();
      Thread.Sleep(2000);
      IList<IWebElement> OptionList = new List<IWebElement>();
      OptionList=driver.FindElements(By.XPath("//mat-option"));
      OptionList[selectByIndex].Click();
      Thread.Sleep(2000);
      string q= element.Text;
      return element.Text;
    }
        public static IWebElement SelectValueForMultipleField_AddApplicationDetails(IWebDriver driver, string ElementName, string[]DataArray)
        {
            string Xpath = $"//mat-select[@formcontrolname='{ElementName}']";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
            int i = 0;
            foreach (IWebElement element in visibleElements)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
                element.SendKeys(DataArray[i]);
                i++;
            }
            return driver.FindElement(By.XPath(Xpath));
        }
            public static void ClickOnCheckBox_AddApplicationDetails(IWebDriver driver, string ElementName)
           {//ElementName=Is US Citizen|Is Permanent Residence
            string Xpath = $"//span[contains(text(),'{ElementName}')]/preceding::label[1]/child::span[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

             driver.FindElement(By.XPath(Xpath)).Click();
            }
         public static IWebElement ClickOnRadiobutton_AddApplicationDetails(IWebDriver driver, string ElementName)
         {
          //ElementName=Is US Citizen|Is Permanent Residence
          string Xpath = $"//span[text()='{ElementName}']/ancestor::mat-radio-button";
          WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
          Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

          return  driver.FindElement(By.XPath(Xpath));
         }
         public static IWebElement CheckThatBox_AddApplicationDetails(IWebDriver driver, string ElementName)
         {//ElementName=Is US Citizen|Is Permanent Residence|Still Working
          string Xpath = $"//span[contains(text(),'{ElementName}')]/preceding::label[1]/child::span[1]/child::input";
          WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
          Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

          return driver.FindElement(By.XPath(Xpath));
         }
        public static void ClickOnAddLoan_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"//span[contains(text(),'Loan')]/ancestor::button[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnAddReference_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"//span[contains(text(),'Reference')]/ancestor::button[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnAddIncome_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"//span[contains(text(),'Income')]/ancestor::button[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnAddEmployment_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"//span[contains(text(),'Employment')]/ancestor::button[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
          IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
          Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
          executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));

          driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnSaveButton_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"(//div[normalize-space()='Save'])[1]/ancestor::button|(//button[descendant::div[normalize-space()='Save']])[1]|(//button[descendant::div[normalize-space()='SAVE']])[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      
            driver.FindElement(By.XPath(Xpath)).Click();
        }
    public static void ClickOnConfirmButton_EmplyerConfirmationPopup_AddApplicationDetails(IWebDriver driver)
    {
      string Xpath = $"//mat-dialog-container/descendant::button[descendant::span[normalize-space()='CONFIRM']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }
        public static void ClickOnEditApplicationButton_AddApplicationDetails(IWebDriver driver,int RowNumber)
        {
          string Xpath = $"//tr[{RowNumber}]/descendant::button[@title='Edit']";      
          WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
          Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

          driver.FindElement(By.XPath(Xpath)).Click();
          Thread.Sleep(5000);
        }
        public static void ClickOnShowMore_BorrowerDetails_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"//button[descendant::span[contains(.,'Show More')]]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed);
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
           // Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElement);
      visibleElement.Click();
        }
        public static void ExpandEmploymentDetailsInnerCard_AddApplicationDetails(IWebDriver driver,string cardName,string? rotation="open")
        {
            //CardName=Employee Details|Contact Details|Address Details
            string Xpath = $"//b[normalize-space()='{cardName}']/following::span[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
            IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed);

            if (visibleElement != null)
            {
            string Degree = visibleElement.GetAttribute("style");

            if(rotation=="open")
               {
                 if (!Degree.Contains("180"))
                   visibleElement.Click();
               }
              else
               {
                 if (Degree.Contains("180"))
                    visibleElement.Click();
               }
      }
            else
            {
                Console.WriteLine("No visible element found.");
            }
            //driver.FindElement(By.XPath(Xpath)).Click();
        }
        public static void ClickOnBackButton_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"//span[normalize-space()='Back']/parent::button[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));


            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
            int i = 0;
            foreach (IWebElement element in visibleElements)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
                element.Click();
                
                i++;
            }
            
        }
        public static void ClickOnCancelButton_AddApplicationDetails(IWebDriver driver)
        {
            string Xpath = $"//span[normalize-space()='Cancel']/parent::button[1]|//span[normalize-space()='CANCEL']/parent::button[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));


            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
            int i = 0;
            foreach (IWebElement element in visibleElements)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
                element.Click();
                i++;
            }

        }
        public static IDictionary GetAddedData_AddApplicationDetails(IWebDriver driver, string[] ElementRequired)
        {
            string Xpath = $"//div[contains(text(),'Added')]/parent::div/parent::div";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

            IDictionary<string, string> DataDic=new Dictionary<string,string>();

            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
            // IWebElement visibleElement = elements.LastOrDefa(element => element.Displayed);
            foreach (IWebElement element in visibleElements)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
                for (int i=0;i<ElementRequired.Length;i++)
                {
                    
                 string XpathKey = $"//descendant::div[normalize-space()='{ElementRequired[i]}']/following-sibling::div[contains(@class,'label-data')]";
                 string Key= ElementRequired[i];
                 string KeyValue= element.FindElement(By.XPath(XpathKey)).Text;
                 DataDic.Add(Key,KeyValue);
                }

            }

                return (IDictionary)DataDic;
        }
        public static IDictionary GetAddedData_BorrowerDetails_AddApplicationDetails(IWebDriver driver,string cardName, string[] ElementRequired)
        {//Education Details|Employment Details|Reference Details|Mailing Address|Other|Physical Address etc
            string Xpath;
           
            Xpath = $"//*[normalize-space()='{cardName}']/ancestor::mat-expansion-panel[1]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

            IDictionary<string, string> DataDic = new Dictionary<string, string>();

            IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

            foreach (IWebElement element in visibleElements)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
                for (int i = 0; i < ElementRequired.Length; i++)
                {

                    string XpathKey = $"{Xpath}/descendant::div[normalize-space()='{ElementRequired[i]}']/following-sibling::div[contains(@class,'label-data')]";
                    string Key = ElementRequired[i];
                    Thread.Sleep(500);
                     string KeyValue=driver.FindElement(By.XPath(XpathKey)).Text;    
                    //string KeyValue = element.FindElement(By.XPath(XpathKey)).Text;
                    DataDic.Add(Key, KeyValue);
                }

            }

            return (IDictionary)DataDic;
        }
    public static IDictionary GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(IWebDriver driver, string cardName, string[] ElementRequired)
    {//Education Details|Employment Details|Reference Details|Mailing Address|Other|Physical Address etc
      string Xpath;

      Xpath = $"//b[normalize-space()='{cardName}']/ancestor::mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);

     
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElements);
        for (int i = 0; i < ElementRequired.Length; i++)
        {

          string XpathKey = $"{Xpath}/descendant::div[contains(text(),'{ElementRequired[i]}')][1]/following-sibling::div[contains(@class,'label-data')]";
          string Key = ElementRequired[i];
          Thread.Sleep(500);
          string KeyValue = driver.FindElement(By.XPath(XpathKey)).Text;
          //string KeyValue = element.FindElement(By.XPath(XpathKey)).Text;
          DataDic.Add(Key, KeyValue);
        }      

      return (IDictionary)DataDic;
    }
    //*****************************************************************Swap to Borrower**************************************************************************************
    public static void ClickOnSwapToBorrower_CoBorrowerDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//button[descendant::span[text()='Swap to Borrower']]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      driver.FindElement(By.XPath(Xpath)).Click();
    }





    //*****************************************************************Activate Inactivate Co-Borrower**************************************************************************************


    public static void SetActivationOfCoBorrower_CoBorrowerDetailsPage(IWebDriver driver,string stateRequired)
    {
      string Xpath = $"//mat-slide-toggle";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IWebElement element= driver.FindElement(By.XPath(Xpath));

      if(stateRequired.ToLower().Contains("active"))
        if(!element.GetAttribute("class").Contains("checked"))
           element.Click();

      if(stateRequired.ToLower().Contains("inactive"))
        if (element.GetAttribute("class").Contains("checked"))
           element.Click();
    }
    public static string GetActivationStatusOfCoBorrower_CoBorrowerDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//mat-slide-toggle";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IWebElement element = driver.FindElement(By.XPath(Xpath));


      if (element.GetAttribute("class").Contains("checked"))
        return "active";
      else
        return "inactive";   
    }
    public static string ClickOnActivationOfCoBorrower_CoBorrowerDetailsPage(IWebDriver driver)
    {
      string Xpath = $"//mat-slide-toggle";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IWebElement element = driver.FindElement(By.XPath(Xpath));


      if (element.GetAttribute("class").Contains("checked"))
      {
        element.Click() ;
        return "active";
      }
      else
      {
        element.Click();
        return "inactive";
      }
    }

  }
}
