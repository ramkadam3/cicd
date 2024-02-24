using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class DTICalculatorStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public DTICalculatorStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }

    [Given(@"Create Income for Application")]
    public void GivenCreateIncomeForApplication()
    {
      ApplicationDetailsPOM.NavigateToIncomeDetailsSection(_driver);
      IncomeExpenditurePOM.ClickOnAddIncomeButton_IncomedetailsPage(_driver).Click();
      SelectOption_DropDown(_driver,"Income Type", 1);
      SelectOption_DropDown(_driver, "Payment Frequency", 1);
      EnterInputValue(_driver,"Amount").SendKeys("10000");
      ApplicationDetailsPOM.ClickOnButton_AddLoanDebtsPopup_ApplicationDetailsPage(_driver, "Add");
    }
    

    [When(@"Click on DTI Calculator section")]
        public void WhenClickOnDTICalculatorSection()
        {
         IncomeExpenditurePOM.NavigateToDTICalculatorPage(_driver);
         BaseClass.WaitForSpinnerToDisappear(_driver);
        }

        [When(@"Click on DTI Calculator button")]
        public void WhenClickOnDTICalculatorButton()
        {
         IncomeExpenditurePOM.ClickOnDTICalculatorButton_DTICalculatorPage(_driver).Click();
         Thread.Sleep(3000);
        }

        [Then(@"Check that income is available on DTI Calculator popup")]
        public void ThenCheckThatIncomeIsAvailableOnDTICalculatorPopup()
        {
         IncomeExpenditurePOM.CheckExpansionOfPanel_DTIcalculatorPopup_DTICalculatorPage(_driver,"Select Income");
         Assert.IsTrue(IncomeExpenditurePOM.SelectCheck_DTICalculatorPage(_driver).Displayed, "The Income is not available for further calculation");
        }
    [When(@"Select the income checkbox")]
    public void WhenClickOnTheIncomeCheckbox()
    {
      //Income Frequency|Income Type|Income Amount|Borrower Type
      IncomeExpenditurePOM.SelectCheck_DTICalculatorPage(_driver).Click();
      _scenarioContext["IncomeFrequency"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Frequency");
      _scenarioContext["IncomeType"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Type");
      _scenarioContext["IncomeAmount"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Amount");
      _scenarioContext["BorrowerType"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Borrower Type");
      _scenarioContext["TotalIncome"] = Formule.CalculateAverageAndTotalIncome (IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Frequency"), double.Parse(IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Amount")), 1).Item3.ToString();
    }

    [Then(@"Check that Debt is available on DTI Calculator popup")]
    public void ThenCheckThatDebtIsAvailableOnDTICalculatorPopup()
    {
      IncomeExpenditurePOM.CheckExpansionOfPanel_DTIcalculatorPopup_DTICalculatorPage(_driver, "Select Debts");
      Assert.IsTrue(IncomeExpenditurePOM.SelectCheck_DTICalculatorPage(_driver).Displayed, "The Debts is not available for further calculation");
    }

    [When(@"Select debt in debt section")]
        public void WhenSelectDebtInDebtSection()
        {
        IncomeExpenditurePOM.CheckExpansionOfPanel_DTIcalculatorPopup_DTICalculatorPage(_driver, "Select Debts");
        IncomeExpenditurePOM.SelectCheck_DTICalculatorPage(_driver).Click();
        _scenarioContext["DebtAmount"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Debt Amount"); 
        }
    [Then(@"Validate that the Debt to Income Ratio calculated properly")]
    public void ThenValidateThatTheDebtToIncomeRatioCalculatedProperly()
    {
      string totalDebts = (string)_scenarioContext["DebtAmount"];
      string totalAnnualIncome = (string)_scenarioContext["TotalIncome"];

      string expected = Formule.CalculateDTIRatio(double.Parse(totalDebts),double.Parse(totalAnnualIncome));
      Assert.That(IncomeExpenditurePOM.ReadDTIRatioValue_DTICalculatorPopup(_driver).Contains(expected));
    }
    [When(@"Select Income Calculation id")]
    public void WhenSelectIncomeCalculationId()
    {
      IncomeExpenditurePOM.SelectIncomeCalculationId_DTIcalculatorPopup_DTICalculatorPage(_driver);
      Thread.Sleep(1000);
      _scenarioContext["IncomeFrequency"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Frequency");
      _scenarioContext["IncomeType"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Type");
      _scenarioContext["IncomeAmount"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Amount");
      _scenarioContext["BorrowerType"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Borrower Type");
      _scenarioContext["TotalIncome"] = Formule.CalculateAverageAndTotalIncome(IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Frequency"), double.Parse(IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Amount")), 1).Item3.ToString();
    }


    }
}
