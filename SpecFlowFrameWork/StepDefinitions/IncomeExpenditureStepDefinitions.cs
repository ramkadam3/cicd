using AventStack.ExtentReports;
using Bogus.DataSets;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class IncomeExpenditureStepDefinitions
    {
    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public IncomeExpenditureStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
       [Given(@"Click on the Income and Expenditure details section")]
       public void GivenClickOnTheIncomeAndExpenditureDetailsSection()
       {
        IncomeExpenditurePOM.NavigateToIncomeExpenditurePage(_driver);
        BaseClass.WaitForSpinnerToDisappear(_driver);
       }
       [Given(@"Click on Add income button")]
       public void GivenClickOnAddIncomeButton()
       {
        IncomeExpenditurePOM.ClickOnAddIncome_IncomeExpenditurePage(_driver).Click();
       }
    [Given(@"Click on Add Expenditure button")]
    public void GivenClickOnAddExpenditureButton()
    {
      IncomeExpenditurePOM.ClickOnAddExpenditure_IncomeExpenditurePage(_driver).Click();
    }

    [Given(@"Select Borrower-CoBorrower")]
    public void GivenSelectBorrower_CoBorrower()
    {
      Thread.Sleep(3000);
      AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver,"Select Borrower/Co-Borrower",0);
      Thread.Sleep(1000);
    }

    [When(@"Select Income Type (.*)")]
        public void WhenEnterIncomeType(string incomeType)
        {
        IncomeExpenditurePOM.SelectValue_AddIncomePopup_ApplicationDetailsPage(_driver,"Income Type",incomeType);
        }

        [When(@"Select payment frequency (.*)")]
        public void WhenSelectPaymentFrequency(string paymentFrequency)
        {
            IncomeExpenditurePOM.SelectValue_AddIncomePopup_ApplicationDetailsPage(_driver, "Payment Frequency", paymentFrequency);
        }

        [When(@"Enter Amount and Note (.*)")]
        public void WhenEnterAmountAndNote(string amount)
        {
          string note = "Note@1235";
         IncomeExpenditurePOM.EnterInputValue_AddIncomePopup_ApplicationDetailsPage(_driver,"Amount", amount);
         IncomeExpenditurePOM.EnterInputValue_AddIncomePopup_ApplicationDetailsPage(_driver,"Note", note);
         _scenarioContext["Note"] = note;
        }
    
    [When(@"Select Expenditure type (.*)")]
    public void WhenSelectExpenditureType(string expenditureType)
    {
      IncomeExpenditurePOM.SelectValue_AddIncomePopup_ApplicationDetailsPage(_driver, "Expenditure Type", expenditureType);
    }

    [When(@"Select Expenditure frequency (.*)")]
    public void WhenSelectExpenditureFrequency(string expenditureFrequency)
    {
      IncomeExpenditurePOM.SelectValue_AddIncomePopup_ApplicationDetailsPage(_driver, "Expenditure Frequency", expenditureFrequency);
    }

    [When(@"Enter Payment date")]
    public void WhenEnterPaymentDate()
    {
      DateTime d=DateTime.Now;
      IncomeExpenditurePOM.EnterInputValue_AddIncomePopup_ApplicationDetailsPage(_driver, "Payment Date", d.ToString("MM/dd/yyyy"));
    }

    [Then(@"Click on Add button")]
        public void ThenClickOnAddButton()
        {
         IncomeExpenditurePOM.ClickOnAddButton_AddIncomePopup_ApplicationDetailsPage(_driver);
        }
    [Then(@"Validate that income type displaying properly on Income page (.*)")]
    public void ThenValidateThatIncomeTypeDisplayingProperlyOnIncomePage(string incomeType)
    {
      Thread.Sleep(5000);
      Assert.That(IncomeExpenditurePOM.CheckData_AddedIncome_IncomePage(_driver,"Income Type").Contains(incomeType));
    }

    [Then(@"Validate that Income Frequency displaying properly on Income page (.*)")]
    public void ThenValidateThatIncomeFrequencyDisplayingProperlyOnIncomePage(string incomeFrequency)
    {
      Assert.That(IncomeExpenditurePOM.CheckData_AddedIncome_IncomePage(_driver, "Income Frequency").Contains(incomeFrequency));
    }

          [Then(@"Validate that Income Amount displaying properly on Income page (.*)")]
          public void ThenValidateThatIncomeAmountDisplayingProperlyOnIncomePage(double amount)
          {
            Assert.That(IncomeExpenditurePOM.CheckIncomeAmount_AddedIncome_IncomePage(_driver,amount.ToString("N2")));
          }

      [Then(@"Validate that Notes displaying properly on Income page")]
      public void ThenValidateThatNotesDisplayingProperlyOnIncomePage()
      {
        string note = (string)_scenarioContext["Note"];
        Assert.That(IncomeExpenditurePOM.CheckData_AddedIncome_IncomePage(_driver, "Notes").Contains(note));      
      }
      [When(@"Click on delete income button")]
       public void WhenClickOnDeleteIncomeButton()
       {
        _scenarioContext["DeleteCount"]=  IncomeExpenditurePOM.CheckDeleteButton_AddedIncome_IncomePage(_driver).ToString();
        IncomeExpenditurePOM.ClickOnDeleteButton_AddedIncome_IncomePage(_driver);
        ApplicationDetailsPOM.ClickOnConfirmDelete_DeletLoanPOPup_ApplicationDetailsPage(_driver);
       }
    [When(@"Click on delete Expenditure button")]
    public void WhenClickOnDeleteExpenditureButton()
    {  IncomeExpenditurePOM.ClickOnAddExpenditure_IncomeExpenditurePage(_driver);
      _scenarioContext["DeleteCount"] = IncomeExpenditurePOM.CheckDeleteButton_AddedExpenditure_IncomePage(_driver).ToString();
      IncomeExpenditurePOM.ClickOnDeleteButton_AddedExpenditure_IncomePage(_driver);
      ApplicationDetailsPOM.ClickOnConfirmDelete_DeletLoanPOPup_ApplicationDetailsPage(_driver);
    }
    

    [Then(@"Validate that the income has been deleted successfully")]
    public void ThenValidateThatTheIncomeHasBeenDeletedSuccessfully()
    {
      int newDeleteCount = IncomeExpenditurePOM.CheckDeleteButton_AddedIncome_IncomePage(_driver);
      string a = (string)_scenarioContext["DeleteCount"];
      Assert.That(!newDeleteCount.ToString().Contains((string)_scenarioContext["DeleteCount"]));
    }

    //Expenditure
    [Then(@"Validate that Expenditure type displaying properly on Income page (.*)")]
    public void ThenValidateThatExpenditureTypeDisplayingProperlyOnIncomePageUtilities(string expenditureType)
    {
      IncomeExpenditurePOM.ClickOnAddExpenditure_IncomeExpenditurePage(_driver);
      Assert.That(IncomeExpenditurePOM.CheckData_AddedIncome_IncomePage(_driver,"Expenditure Type").Contains(expenditureType));
    }

    [Then(@"Validate that Expenditure Frequency displaying properly on Income page (.*)")]
    public void ThenValidateThatExpenditureFrequencyDisplayingProperlyOnIncomePageMonthly(string expenditureFrequency)
    {
      Assert.That(IncomeExpenditurePOM.CheckData_AddedIncome_IncomePage(_driver, "Expenditure Frequency").Contains(expenditureFrequency.Replace(" ","")));
    }

    [Then(@"Validate that Expenditure Amount displaying properly on Income page (.*)")]
    public void ThenValidateThatExpenditureAmountDisplayingProperlyOnIncomePage(double amount)
    {
      Assert.That(IncomeExpenditurePOM.CheckAmount_AddedExpenditure_IncomePage(_driver, amount.ToString("N2")));
    }

    [Then(@"Validate that Notes displaying properly on Expenditure page")]
    public void ThenValidateThatNotesDisplayingProperlyOnExpenditurePage()
    {
      string note = (string)_scenarioContext["Note"];
      Assert.That(IncomeExpenditurePOM.CheckData_AddedIncome_IncomePage(_driver, "Notes").Contains(note));
    }
    [Then(@"Validate that the Expenditure has been deleted successfully")]
    public void ThenValidateThatTheexpenditureHasBeenDeletedSuccessfully()
    {
      int newDeleteCount = IncomeExpenditurePOM.CheckDeleteButton_AddedExpenditure_IncomePage(_driver);
      string a = (string)_scenarioContext["DeleteCount"];
      Assert.That(!newDeleteCount.ToString().Contains((string)_scenarioContext["DeleteCount"]));      
    }
  }
}
