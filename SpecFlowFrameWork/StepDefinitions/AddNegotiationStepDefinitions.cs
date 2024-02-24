using AventStack.ExtentReports;
using AventStack.ExtentReports.Utils;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class AddNegotiationStepDefinitions:BaseClass
    {

    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;
    private FeatureContext _featureContext;
    private ExtentTest _scenario;

    public AddNegotiationStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
      _featureContext = featureContext;
    }


        [When(@"Select Loan among private student loan")]
        public void WhenSelectLoanAmongPrivateStudentLoan()
        {
         NegotiationPOM.SelectLoan_Negotiation_LoanDetailsPage(_driver);
        _scenarioContext["LoanID"] = NegotiationPOM.GetData_Negotiation_LoanDetailsPage(_driver, "Loan ID");
        _scenarioContext["LoanAmount"] = NegotiationPOM.GetData_Negotiation_LoanDetailsPage(_driver,"Total Loan Amount");
        }

        [Given(@"Click on Add Negotiation button")]
        public void GivenClickOnAddNegotiationButton()
        {
         NegotiationPOM.ClickOnAddNegotiationButton_LoanDetailsPage(_driver);
        }

        [Then(@"Validate that the Add Negotiation displaying Loan ID properly")]
        public void ThenValidateThatTheAddNegotiationDisplayingLoanIDProperly()
        {
         string b=EnterInputValue(_driver, "Loan Id").GetAttribute("value");
         Assert.That(!EnterInputValue(_driver, "Loan Id").Enabled);
        }

        [Then(@"Validate that the Total amount displaying properly")]
        public void ThenValidateThatTheTotalAmountDisplayingProperly()
        {
        string b = EnterInputValue(_driver, "Total Amount").GetAttribute("value");
        Assert.That(!EnterInputValue(_driver, "Total Amount").Enabled);
        }

        [When(@"Provide Negotiation name to Add Negotiation field")]
        public void WhenProvideNegotiationNameToAddNegotiationField()
        {
          string negotiName = "negotiationName";
          _scenarioContext["NegotiationName"] = negotiName;      
          EnterInputValue(_driver,"Negotiation Name").SendKeys(negotiName);            
        }
    [Then(@"Validate that the Added Negotiation details displaying properly")]
    public void ThenValidateThatTheAddedNegotiationDetailsDisplayingProperly()
    {
      string NN= NegotiationPOM.ReadDataNegotiation_NegotiationTable_LoanDetailsPage(_driver,"Negotiation Name");
      string sNN = (string)_scenarioContext["NegotiationName"];
      Assert.That(NN.Contains(sNN));          
    }
    [When(@"Click on The Action Button (.*)")]
    public void WhenClickOnTheActionButton(string buttonName)
    {//done|close|edit|view|
      buttonName = buttonName.Trim('"').ToLower();
      NegotiationPOM.ClickOnActionItem_NegotiationTable_LoanDetailsPage(_driver,buttonName);
  
    }
    [When(@"Enter value to the (.*), (.*)")]
    public void WhenEnterValueToThe(string columnName,double value)
    {
      columnName = columnName.Trim('"');
      NegotiationPOM.EnterValueToColumnCell_NegotiationTable_LoanDetailsPage(_driver, columnName).Clear();
      NegotiationPOM.EnterValueToColumnCell_NegotiationTable_LoanDetailsPage(_driver, columnName).SendKeys(value.ToString());
    }
    [Then(@"Validate that the Edit bit amount is not possible when Proposed Bid is greater than Agency Offer (.*)")]
    public void ThenValidateThatTheEditBitAmountIsNotPossibleWhenProposedBidIsGreaterThanAgencyOffer(string message)
    {
      Assert.That(BaseClass.Success_Notification(_driver).Text.Contains(message.Trim('"')) || BaseClass.Success_Notification(_driver).Text.Contains(message.Trim('"').ToLower()));
    }

    [Then(@"Validate that the Close button is working fine")]
    public void ThenValidateThatTheCloseButtonIsWorkingFine()
    {
      
    }
    [Then(@"Validate that the navigation History pop-up displaying data properly (.*)")]
    public void ThenValidateThatTheNavigationHistoryPop_UpDisplayingDataProperly(string name)
    {
      Thread.Sleep(5000);
      string gb = CheckAddeddetailsWithTableName_byRowColumnArranged(_driver, "Negotiation History", "Negotiation Name",1);
      string dd = CheckAddeddetailsWithTableName_byRowColumnArranged(_driver, "Negotiation History", "Negotiation Date", 1);
      Assert.That(gb.Contains(name));
      Assert.That(dd.Contains(Date.ToString("MM-dd-yyyy")));
    }

    [Then(@"Validate that the inner table displaying LoanID properly")]
    public void ThenValidateThatTheInnerTableDisplayingLoanIDProperly()
    {
      Assert.That(!NegotiationPOM.GetData_NegotiationInnerTable_LoanDetailsPage(_driver,"loanId").IsNullOrEmpty()); 
    }

    [Then(@"Validate that the inner table displaying Loan Amount properly")]
    public void ThenValidateThatTheInnerTableDisplayingLoanAmountProperly()
    {     
      Assert.That(!NegotiationPOM.GetData_NegotiationInnerTable_LoanDetailsPage(_driver, "loanAmount").IsNullOrEmpty());
    }

    [Then(@"Validate that the inner table displaying Agency properly")]
    public void ThenValidateThatTheInnerTableDisplayingAgencyProperly()
    {
      Assert.That(!NegotiationPOM.GetData_NegotiationInnerTable_LoanDetailsPage(_driver, "loanAgency").IsNullOrEmpty());
    }

    [Then(@"Validate that the inner table displaying Loan Type properly")]
    public void ThenValidateThatTheInnerTableDisplayingLoanTypeProperly()
    {
      Assert.That(!NegotiationPOM.GetData_NegotiationInnerTable_LoanDetailsPage(_driver, "loanType").IsNullOrEmpty());
    }


  }
}
