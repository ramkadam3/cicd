using AventStack.ExtentReports;
using NUnit.Framework;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using System.Data;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class LoanDetailsStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public LoanDetailsStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;

    }
       public static Dictionary<string, string> JsonData()
       {
      string Path = GetDataParser().TestData_Path("AddInvestmentTD");
      var testData = new Dictionary<String, String>();

      //testData.Add("CompanyeSignCardTitle", GetDataParser().TestData("CompanyeSignCardTitle", Path));
      //testData.Add("MakePaymentCardTitle", GetDataParser().TestData("MakePaymentCardTitle", Path));
      //testData.Add("FinalizeInvestmentCardTitle", GetDataParser().TestData("FinalizeInvestmentCardTitle", Path));

      return testData;
       }


       [Given(@"Expand Finance details section")]
        public void GivenExpandFinanceDetailsSection()
        {     
        ApplicationDetailsPOM.ClickOnFinancialDetailsSection_ApplicationDetailsPage(_driver).Click();    
        }   

    [Given(@"Navigate to the Loan details section")]
        public void GivenNavigateToTheLoanDetailsSection()
        {     
        ApplicationDetailsPOM.ClickOnLoanDetailsSection_ApplicationDetailsPage(_driver).Click();
        BaseClass.WaitForSpinnerToDisappear(_driver);
        }
    [Given(@"Navigate to the Negotiate Loan details section")]
    public void GivenNavigateToTheNegotiateLoanDetailsSection()
    {
      ApplicationDetailsPOM.ClickOnNegotiateLoanDetailsSection_ApplicationDetailsPage(_driver).Click();
      BaseClass.WaitForSpinnerToDisappear(_driver);
    }

    [When(@"Click on the Add Loan button")]
        public void WhenClickOnTheAddLoanButton()
        {   
        ApplicationDetailsPOM.ClickOnAddLoanButton_ApplicationDetailsPage(_driver);            
        }

        [When(@"Provide required details to the add loan pop-up and save it (.*), (.*)")]
        public void WhenProvideRequiredDetailsToTheAddLoanPop_UpAndSaveIt(string loanType,string loanCategory)
        {       
         string aging = "25";
         string LAmont = "4500";
        _scenarioContext["Aging"] = aging;
        _scenarioContext["LoanAmount"] = LAmont;
        
         ApplicationDetailsPOM.SelectValue_AddLoanPopup_ApplicationDetailsPage(_driver,"Loan Type", loanType);
         ApplicationDetailsPOM.EnterInputValue_AddLoanPopup_ApplicationDetailsPage(_driver,"Total Loan Amount","4500");
         AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver,"Originator Loan Agency",1);
         ApplicationDetailsPOM.EnterInputValue_AddLoanPopup_ApplicationDetailsPage(_driver, "Aging (In Months)", "25");
         ApplicationDetailsPOM.SelectValue_AddLoanPopup_ApplicationDetailsPage(_driver, "Loan Category", loanCategory);
         ApplicationDetailsPOM.ClickOnButton_AddLoanDebtsPopup_ApplicationDetailsPage(_driver, "Add");
        }

        [Then(@"Validate that the Loan added successfully (.*), (.*)")]
        public void ThenValidateThatTheLoanAddedSuccessfully(string loanType,string cardName)
        {
      ApplicationDetailsPOM.CheckCardTitle_ApplicationDetailsPage(_driver, cardName);
      Thread.Sleep(1000);

      string lt = ApplicationDetailsPOM.CheckLoandetails_AddLoanPopup_ApplicationDetailsPage(_driver, cardName, "Status", 1);
      Assert.That(ApplicationDetailsPOM.CheckLoandetails_AddLoanPopup_ApplicationDetailsPage(_driver, cardName, "Loan Type", 1).Contains(loanType));
      Assert.That(ApplicationDetailsPOM.CheckLoandetails_AddLoanPopup_ApplicationDetailsPage(_driver, cardName, "Status", 1).Contains("Application"));
      Assert.That(ApplicationDetailsPOM.CheckLoandetails_AddLoanPopup_ApplicationDetailsPage(_driver, cardName, "Aging", 1).Contains((string)_scenarioContext["Aging"]));
      Assert.That(ApplicationDetailsPOM.CheckLoandetails_AddLoanPopup_ApplicationDetailsPage(_driver, cardName, "Total Loan Amount", 1).Contains((string)_scenarioContext["LoanAmount"]));
        }

        [Then(@"Validate that the Add button navigate to the Add loan popup")]
         public void ThenValidateThatTheAddButtonNavigateToTheAddLoanPopup()
         {   
         }
    [Given(@"Expand Inner table of loan details")]
    public void GivenExpandInnerTableOfLoanDetails()
    {     
      ApplicationDetailsPOM.ExpandInnerTableOfLoanTable_ApplicationDetailsPage(_driver);
      Thread.Sleep(2000);
    }

    [When(@"Upload document (.*),(.*)")]
    public void WhenUploadDocument(string doc,string fileName)
    {     
      doc = doc.Trim('"');
      ApplicationDetailsPOM.ClickOnAddFile_Loandetails_ApplicationDetailsPage(_driver,1);
      Thread.Sleep(3000);
      HandleOpenDialog hndOpen = new HandleOpenDialog();      
      string path = @$"{ProjectDirectory}\TestData";
      Thread.Sleep(1000);
      hndOpen.fileOpenDialog(path, $"{fileName}");          
    }

       [Then(@"Validate that the document uploaded successfully (.*)")]
       public void ThenValidateThatTheDocumentUploadedSuccessfully(string fileName)
       {      
      Thread.Sleep( 10000 );      
      Assert.IsTrue( ApplicationDetailsPOM.CheckUploadedFile_Loandetails_ApplicationDetailsPage(_driver, fileName, 1),"Validation failed of uploaded document");
       }

    [When(@"Click on Delete loan button")]
    public void WhenClickOnDeleteLoanButton()
    {Thread.Sleep( 5000);
      ApplicationDetailsPOM.ClickOnDeletButton_LoanTable_ApplicationDetailsPage( _driver );
      ApplicationDetailsPOM.ClickOnConfirmDelete_DeletLoanPOPup_ApplicationDetailsPage(_driver);
    }

  }
}
