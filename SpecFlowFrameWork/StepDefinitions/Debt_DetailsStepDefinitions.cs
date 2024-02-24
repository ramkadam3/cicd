using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class Debt_DetailsStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

        public Debt_DetailsStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
         _driver = driver;
         _scenarioContext = scenarioContext;
        }

        [When(@"Click on add Debts button")]
        public void WhenClickOnAddDebtsButton()
        {
         ApplicationDetailsPOM.ClickOnAddDebtsButton_ApplicationDetailsPage(_driver);
        }
        [When(@"Provide required details to the Add debts pop-up and save it (.*)")]
        public void WhenProvideRequiredDetailsToTheAddDebtsPop_UpAndSaveIt(string debtType)
        {
           int amount = 45213;
           string note = "noted";
           _scenarioContext["Amount"]=amount.ToString();
           _scenarioContext["Note"] = note;
           _scenarioContext["DebtType"] = debtType;

           ApplicationDetailsPOM.SelectDebtsType_AddDebtsPopup_ApplicationDetailsPage(_driver,debtType);
           ApplicationDetailsPOM.EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(_driver, "Amount", amount.ToString());
           ApplicationDetailsPOM.EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(_driver, "Note", note);
           ApplicationDetailsPOM.ClickOnButton_AddLoanDebtsPopup_ApplicationDetailsPage(_driver, "Add");
        }
    [Given(@"Create Debt for Application")]
    public void GivenCreateDebtForApplication()
    {
      ApplicationDetailsPOM.ClickOnLoanDetailsSection_ApplicationDetailsPage(_driver).Click();
      BaseClass.WaitForSpinnerToDisappear(_driver);
      ApplicationDetailsPOM.ClickOnAddDebtsButton_ApplicationDetailsPage(_driver);


      SelectOption_DropDown(_driver, "Debts Type", 1);
      ApplicationDetailsPOM.EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(_driver, "Amount", "45213");
      ApplicationDetailsPOM.ClickOnButton_AddLoanDebtsPopup_ApplicationDetailsPage(_driver, "Add");
    }
    [Then(@"Validate that the debt details displaying properly (.*), (.*)")]
       public void ThenValidateThatTheDebtDetailsDisplayingProperlyRent(string debtsType,string cardName)
       {
        ApplicationDetailsPOM.CheckCardTitle_ApplicationDetailsPage(_driver, cardName);
        Thread.Sleep(1000);
        string a = (string)_scenarioContext["Amount"];
        Assert.That(ApplicationDetailsPOM.CheckDebtdetails_AddDebtsPopup_ApplicationDetailsPage(_driver, "Debt Type", 1).Contains(debtsType));
        Assert.That(ApplicationDetailsPOM.CheckDebtdetails_AddDebtsPopup_ApplicationDetailsPage(_driver, "Notes", 1).Contains((string)_scenarioContext["Note"]));
        Assert.That(ApplicationDetailsPOM.CheckDebtdetails_AddDebtsPopup_ApplicationDetailsPage(_driver, "Debt Amount", 1).Contains((string)_scenarioContext["Amount"]));
       }

    }
}
