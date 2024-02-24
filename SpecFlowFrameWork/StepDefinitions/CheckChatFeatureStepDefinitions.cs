using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Driver;
using SpecFlowFrameWork.Pages;
using SpecFlowFrameWork.Utility;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace SpecFlowFrameWork.StepDefinitions
{
    [Binding]
    public class CheckChatFeatureStepDefinitions
    {
        private string Path;
        
        private readonly IWebDriver Driver;
       
        private ScenarioContext _scenarioContext;
       
         public CheckChatFeatureStepDefinitions(IWebDriver driver,ScenarioContext scenarioContext)
        {

            this.Driver = driver;
            this._scenarioContext = scenarioContext;
            
        }

        [Given(@"Navigate to Manage account page")]
        public void GivenNavigateToManageAccountPage()
        {
           
            ManageAccountPOM.NavigateToManageAccountPage(Driver);
            
            BaseClass.WaitForSpinnerToDisappear(Driver);
           
        }

        [Then(@"Enter Input to the Name field in filte (.*)")]
        public void ThenEnterInputToTheNameFieldInFilte(string Input)
        {
            BaseClass.WaitForSpinnerToDisappear(Driver);
            ManageAccountPOM.EnterInputToNameFieldPage(Driver).SendKeys(Input);
           
        }




        [When(@"click on Add new investor account button")]
        public void WhenClickOnAddNewInvestorAccountButton()
        {
            ManageAccountPOM.ClickOnAddInvestoreButton(Driver);           
        }

        [Then(@"Validate that it navigate to the Add investor page")]
        public void ThenValidateThatItNavigateToTheAddInvestorPage()
        {
            Assert.That(ManageAccountPOM.CheckNavigatedToAddInvestorPage(Driver).Displayed);            
        }
       

    }
}

