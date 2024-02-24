using AventStack.ExtentReports;
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
    public class CreaditReportStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public CreaditReportStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;

    }
        [When(@"Navigate to the Credit Report section")]
        public void WhenNavigateToTheCreditReportSection()
        {
         CreditReportPOM.NavigateToCreditReportPage(_driver).Click();
        }

        [Then(@"Validate that the Add credit report button is displaying on credit report section")]
        public void ThenVAlidateThatTheAddCreditReportButtonIsDisplayingOnCreditReportSection()
        {
         Assert.That(CreditReportPOM.ClickOnAddCreditReportButton_CreditReportPage(_driver).Displayed);
        }

        [When(@"Click on the Add Credit Report button")]
        public void WhenClickOnTheAddCreditReportButton()
        {
         CreditReportPOM.ClickOnAddCreditReportButton_CreditReportPage(_driver).Click();
         Thread.Sleep(3000);
        }
        [When(@"Select among Drop-down(.*), (.*)")]
        public void WhenSelectOptionIndex(string selectName,int? index=1)
        {
         selectName = selectName.Trim('"');
        _scenarioContext[$"{selectName}"]= SelectOption_DropDown(_driver, selectName.Trim('"'), (int)index);
        }
        [When(@"Click on Fetch button")]
        public void WhenClickOnFetchButton()
        {
         CreditReportPOM.ClickOnFetchbutton_creditreportPage(_driver).Click();   
        }
    [Then(@"Validate that the Add Credit report pop-up shows selected borrower name properly")]
    public void ThenValidateThatTheAddCreditReportPop_UpShowsSelectedBorrowerNameProperly()
    {
      CreditReportPOM.CheckBorrowerNameOnPopup_creditreportPage(_driver, (string)_scenarioContext["Select Borrower"]);
    }

    [Then(@"Validate that the fetch button is getting enabled by checked the check-box")]
    public void ThenValidateThatTheFetchButtonIsGettingEnabledByCheckedTheCheck_Box()
    {
      CreditReportPOM.ClickOnCheckOnPopup_creditreportPage(_driver).Click();
      Assert.That(CreditReportPOM.ClickOnFetchbutton_creditreportPage(_driver).Enabled);
    }
    [Then(@"Validate that the Credit Report displaying label properly")]
    public void ThenValidateThatTheCreditReportDisplayingLabelProperly()
    {
      string[] labelList = { "Personal Information", "Profile Summary", "Score Summary", "Public Records", "Creditors" };
      foreach (string label in labelList)
      {
       Assert.That( CreditReportPOM.CheckLabelsOnCreditReportPopup_creditreportPage(_driver, label));
      }
    }

    [When(@"Click on The Credit Report Action Button")]
    public void WhenClickOnTheCreditReportActionButton()
    {
      
    CreditReportPOM.ClickOnCreditReportActionItem_creditreportPage(_driver,1);
    }

  }
}
