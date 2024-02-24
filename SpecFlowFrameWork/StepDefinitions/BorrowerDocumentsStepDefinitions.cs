using AventStack.ExtentReports;
using NUnit.Framework;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class BorrowerDocumentsStepDefinitions:BaseClass
    {

    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public BorrowerDocumentsStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;

    }


        [When(@"Expand Document section")]
        public void WhenExpandDocumentSection()
        {
         ApplicationDetailsPOM.ClickOnDocuments_ApplicationDetailsPage(_driver).Click();
        }

        [Then(@"Check Borrower documents sub tab")]
        public void ThenCheckBorrowerAndCo_BorrowerDocuments()
        {
         Assert.That( ApplicationDetailsPOM.ClickOnBorrowerDocuments_ApplicationDetailsPage(_driver).Displayed);
        }
        [Then(@"Check Co-Borrower documents sub tab")]
        public void ThenCheckCoBorrowerAndCo_BorrowerDocuments()
        {
         Assert.That(ApplicationDetailsPOM.ClickOnCoBorrowerDocuments_ApplicationDetailsPage(_driver).Displayed);
        }

        [Given(@"Navigate to Borrower Document")]
        public void GivenNavigateToBorrowerDocument()
        {
         ApplicationDetailsPOM.ClickOnBorrowerDocuments_ApplicationDetailsPage(_driver).Click();
        }

        [Given(@"Navigate to Co-Borrower Document")]
        public void GivenNavigateToCoBorrowerDocument()
        {
         ApplicationDetailsPOM.ClickOnCoBorrowerDocuments_ApplicationDetailsPage(_driver).Click();
        }

        [When(@"Select document and add Document")] 
        public void WhenSelectDocumentAndAddDocument()
        {
         Thread.Sleep(3000);
         _scenarioContext["RequiredDocument"]= AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver,"Required Document",1);
      try
      {
        SelectOption_DropDown(_driver,"Select Year",1);
      }
      catch { }
         ApplicationDetailsPOM.ClickOnAddDocument_BorrowerDocumentPage(_driver);
        }

        [Then(@"Validate that the required document field getting added successfully")]
        public void ThenValidateThatTheRequiredDocumentFieldGettingAddedSuccessfully()
        {
          string documentPaper = (string)_scenarioContext["RequiredDocument"];
          Assert.That(ApplicationDetailsPOM.CheckDocumentField_BorrowerDocumentPage(_driver, documentPaper));
        }

    [When(@"Upload document using HandleOpenDialog (.*)")]
    public void WhenUploadDocumentUsingUploadDocumentButton(string fileName)
    {         
      HandleOpenDialog hndOpen = new HandleOpenDialog();
      string path = @$"{ProjectDirectory}\TestData";
      Thread.Sleep(3000);
      Thread.Sleep(1000);
      hndOpen.fileOpenDialog(path, $"{fileName}");
      Thread.Sleep(3000);
    }
    [When(@"Click on upload document")]
    public void WhenClickOnUploadDocument()
    {
     _scenarioContext["CardName"]= ApplicationDetailsPOM.ClickonUploadDocument_BorrowerDocumentPage(_driver);
    }    

    [Then(@"Validate that document uploaded properly")]
    public void ThenValidateThatDocumentUploadedProperly()
    {
      string cardName = (string)_scenarioContext["CardName"];
      int docNumber= ApplicationDetailsPOM.ChickUploadedDocument_BorrowerDocumentPage(_driver,cardName);
      Assert.That(docNumber>0);
    }
    [When(@"Click on View document button")]
    public void WhenClickOnViewDocumentButton()
    {
      try
      {
      ApplicationDetailsPOM.ChickViewDocument_BorrowerDocumentPage(_driver);
      }
      catch
      {
        ApplicationDetailsPOM.ExpandMoreAction_BorrowerDocumentPage(_driver);
        ApplicationDetailsPOM.ChickViewDocument_BorrowerDocumentPage(_driver);
      }
    }
    [Then(@"Validate that the document viewed successfully")]
    public void ThenValidateThatTheDocumentViewedSuccessfully()
    {
      Thread.Sleep(5000);
      ReadOnlyCollection<string> allWindowHandles = _driver.WindowHandles;
      _driver.SwitchTo().Window(_driver.WindowHandles.Last());
      _driver.SwitchTo().Window(_driver.WindowHandles.First());
    }

    [When(@"Click on Download document button")]
    public void WhenClickOnDownloadDocumentButton()
    {
      try
      {
      ApplicationDetailsPOM.ChickDownloadDocument_BorrowerDocumentPage(_driver);
      }
      catch
      {
        ApplicationDetailsPOM.ExpandMoreAction_BorrowerDocumentPage(_driver);
        ApplicationDetailsPOM.ChickDownloadDocument_BorrowerDocumentPage(_driver);
      }
    }


    }
}
