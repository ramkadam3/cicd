using AventStack.ExtentReports;
using Bogus;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Pages.ParticipantPage;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class ParticipantStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public ParticipantStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
    [Given(@"Navigate to Participant page")]
        public void GivenNavigateToParticipantPage()
        {
         ParticipantPagePOM.NavigateToParticipantPage(_driver);
        }

        [When(@"Click on Add participant button")]
        public void WhenClickOnAddParticipantButton()
        {
         ParticipantPagePOM.ClickOnAddParticipantButton_ParticipantPage(_driver);
        }

         Faker faker= new Faker();
        [When(@"Provide Participant name to popup")]
        public void WhenProvideParticipantNameToPopup()
        {
         string fName=faker.Person.FirstName;
         _scenarioContext["FName"]=fName;
         ApplicationDetailsPOM.EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(_driver,"Participant Name", fName);
        }

        [When(@"Provide Email to the popup")]
        public void WhenProvideEmailToThePopup()
        {
          string email=faker.Person.Email;
          ApplicationDetailsPOM.EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(_driver, "Email", email);
        }

        [When(@"Provide Password to the popup (.*)")]
        public void WhenProvidePasswordToThePopup(string password)
        {      
         ApplicationDetailsPOM.EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(_driver, "Password", password);
        }
    [Then(@"Validate that the participant name displaying properly on participant page")]
    public void ThenValidateThatTheParticipantNameDisplayingProperlyOnParticipantPage()
    {
      Assert.That( ParticipantPagePOM.CheckDataOfParticipant_ParticipantPage(_driver, (string)_scenarioContext["FName"]));
    }

    [Then(@"Validate that the participant email displaying properly on participant page")]
    public void ThenValidateThatTheParticipantEmailDisplayingProperlyOnParticipantPage()
    {
      Assert.That (ParticipantPagePOM.CheckDataOfParticipant_ParticipantPage(_driver, (string)_scenarioContext["Email"]));
    }
    [When(@"Click on delete button")]
    public void WhenClickOnDeleteButton()
    {
      _scenarioContext["PreName"]= CheckAddeddetails_byRowColumnArranged(_driver,"Name",1);
      //_scenarioContext["deletCount"] =ParticipantPagePOM.CheckDeleteButton_ParticipantPage(_driver).Item2;
      ParticipantPagePOM.CheckDeleteButton_ParticipantPage(_driver).Item1.Click();
      ApplicationDetailsPOM.ClickOnConfirmDelete_DeletLoanPOPup_ApplicationDetailsPage(_driver);
    }
    [Then(@"Validate that the Participant has been deleted successfully")]
    public void ThenValidateThatTheParticipantHasBeenDeletedSuccessfully()
    {     
     // Assert.That((int)_scenarioContext["deletCount"] != ParticipantPagePOM.CheckDeleteButton_ParticipantPage(_driver).Item2);
      Assert.That((string)_scenarioContext["PreName"] != CheckAddeddetails_byRowColumnArranged(_driver, "Name", 1));
    }

  }
}
