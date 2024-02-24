using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class IncomeCalculatorStepDefinitions
    {
    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public IncomeCalculatorStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
        [When(@"Click on Income Calculator section")]
        public void WhenClickOnIncomeCalculatorSection()
        {
         IncomeExpenditurePOM.NavigateToIncomeCalculatorPage(_driver);
         BaseClass.WaitForSpinnerToDisappear(_driver);
        }
    [When(@"Click on income calculator button")]
    public void WhenClickOnIncomeCalculatorButton()
    {
      IncomeExpenditurePOM.ClickOnIncomeCalculatorButton_IncomeCalculatorPage(_driver).Click();
      Thread.Sleep(3000);
    }

    [Then(@"Check that income is available on income calculator popup")]
    public void ThenCheckThatIncomeIsAvailableOnIncomeCalculatorPopup()
    {
      Assert.IsTrue(IncomeExpenditurePOM.CheckIncomeCheck_IncomeCalculatorPage(_driver).Displayed,"The Income is not available for further calculation");      
    }

    [When(@"Click on the income checkbox")]
    public void WhenClickOnTheIncomeCheckbox()
    {
      //Income Frequency|Income Type|Income Amount|Borrower Type
      IncomeExpenditurePOM.CheckIncomeCheck_IncomeCalculatorPage(_driver).Click();
      _scenarioContext["IncomeFrequency"] = IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Frequency");
      _scenarioContext["IncomeType"]= IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Type");
      _scenarioContext["IncomeAmount"]= IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Income Amount");
      _scenarioContext["BorrowerType"]= IncomeExpenditurePOM.ReadDataOfIncome_IncomeCalculatorPopup(_driver, "Borrower Type");
    }

    [When(@"Click on the calculate button")]
    public void WhenClickOnTheCalculateButton()
    {
      IncomeExpenditurePOM.ClickOnCalculationButton_IncomeCalculatorPopup(_driver,"Calculate");
    }
    [When(@"Click on the calculate and save button")]
    public void WhenClickOnTheCalculatesaveButton()
    {      
      IncomeExpenditurePOM.ClickOnCalculationButton_IncomeCalculatorPopup(_driver, "Calculate & Save");
    }

    [Then(@"Validate that the Average value calculated properly")]
    public void ThenValidateThatTheAverageValueCalculatedProperly()
    { string iamount = (string)_scenarioContext["IncomeAmount"];
      double amount = double.Parse(iamount);
      double Expected = Formule.CalculateAverageAndTotalIncome((string)_scenarioContext["IncomeFrequency"], amount, 1).Item1;
      double Expected2 = Formule.CalculateAverageAndTotalIncome((string)_scenarioContext["IncomeFrequency"], amount, 1).Item2;
      string actual = IncomeExpenditurePOM.ReadCalculatedValue_IncomeCalculatorPopup(_driver, "Average");

      Assert.That(IncomeExpenditurePOM.ReadCalculatedValue_IncomeCalculatorPopup(_driver,"Average").Contains(Expected.ToString()));
      Assert.That(IncomeExpenditurePOM.ReadCalculatedValue_IncomeCalculatorPopup(_driver, "Average").Contains(Expected2.ToString()));
    }

    [Then(@"Validate that the Total value calculated properly")]
    public void ThenValidateThatTheTotalValueCalculatedProperly()
    {
      string iamount = (string)_scenarioContext["IncomeAmount"];
      double amount = double.Parse(iamount);
      double Expected = Formule.CalculateAverageAndTotalIncome((string)_scenarioContext["IncomeFrequency"], amount, 1).Item3;
      double Expected2 = Formule.CalculateAverageAndTotalIncome((string)_scenarioContext["IncomeFrequency"], amount, 1).Item4;
      string actual = IncomeExpenditurePOM.ReadCalculatedValue_IncomeCalculatorPopup(_driver, "Total");      
      Assert.That(IncomeExpenditurePOM.ReadCalculatedValue_IncomeCalculatorPopup(_driver, "Total").Contains(Expected.ToString()));
      Assert.That(IncomeExpenditurePOM.ReadCalculatedValue_IncomeCalculatorPopup(_driver, "Total").Contains(Expected2.ToString()));
    }
    [When(@"Close The Popup")]
    public void WhenCloseThePopup()
    {
      IncomeExpenditurePOM.CloseThePopup(_driver);
    }

  }
}
