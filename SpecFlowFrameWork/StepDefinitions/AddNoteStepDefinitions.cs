using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowFrameWork.Pages.InvstmentsPagePOM;
using SpecFlowFrameWork.Pages.OfferingPagePOM;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Pages.Origination.TaskQueuePage;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class AddNoteStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;
    private FeatureContext _featureContext;

    public AddNoteStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext,FeatureContext featureContext
      )
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
      _featureContext = featureContext;
    }

        [Given(@"Navigate to the Notes section")]
        public void GivenNavigateToTheNotesSection()
        {     
         NotesPOM.NavigateToNotesPage(_driver).Click();
        }
        [When(@"Click on Add Note button")]
        public void WhenClickOnAddNoteButton()
        {
          NotesPOM.ClickOnAddNotesButton_NotesPage(_driver).Click();
        }
        [When(@"Select the value by check (.*), (.*)")]
        public void WhenSelectTheValueByCheckNoteAction(string selectName,int numberOfOption)
        {
          Thread.Sleep(3000);
          selectName = selectName.Trim('"');
          _scenarioContext[selectName] = SelectOption_ByCheck(_driver, selectName, numberOfOption);    
      
        }
    [When(@"Click on Add button")]
    public void WhenClickOnAddButton()
    {
      Thread.Sleep(5000);
      NotesPOM.ClickOnAddbutton_NotesPage(_driver).Click();
    }
    [Then(@"Click on Select (.*)")]
    public void ThenClickOnSelect(string selectName)
    {
      selectName= selectName.Trim('"');
      Actions act=new Actions(_driver);
      act.MoveToElement(ClickOnSelectField(_driver, selectName)).Click().Build().Perform();     
    }
    [Then(@"Validate that the Add button navigates to Create Task pop-up")]
    public void ThenValidateThatTheAddButtonNavigatesToCreateTaskPop_Up()
    {
      Assert.That(EnterInputValue(_driver, "Due Date").Displayed);
    }

    [When(@"Provide Input value to the Create task pop-up")]
    public void WhenProvideInputValueToTheCreateTaskPop_Up()
    {
      string discription = "Task Created After Note";
      EnterInputValue(_driver,"Due Date").SendKeys(Date.ToString());
      Thread.Sleep(1000);
      _scenarioContext["AssignTaskTo"]= SelectOption_DropDown(_driver, "Assign Task To",1);
      
      Thread.Sleep(1000);
      _scenarioContext["TaskPriority"] = SelectOption_DropDown(_driver, "Task Priority", 1);
   
      Thread.Sleep(1000);
      _scenarioContext["TaskDescription"] = discription;
     
      TakQueuePOM.EnterInputTextarea_TaskQueuePage(_driver).SendKeys(discription);
    }

    [Then(@"Validate that the Added Note displaying properly")]
    public void ThenValidateThatTheAddedNoteDisplayingProperly()
    { 
      Assert.That(NotesPOM.CheckAddedNoteDetails_NotesPage(_driver, (string)_scenarioContext["noteAction"]));
      Assert.That(NotesPOM.CheckAddedNoteDetails_NotesPage(_driver, (string)_scenarioContext["noteResult"]));
      Assert.That(NotesPOM.CheckAddedNoteDetails_NotesPage(_driver, (string)_scenarioContext["Description"]));
    }
    [When(@"Click on Reply to Note button")]
    public void WhenClickOnReplyToNoteButton()
    {
      NotesPOM.ClickOnReplyButton_NotesPage(_driver);
    }
    [When(@"Provide Description to the Add Reply Note Pop-up")]
    public void WhenProvideDescriptionToTheAddReplyNotePop_Up()
    {
      string discription = "Reply added to the Note";
      _scenarioContext["ReplyDescription"] = discription;
      TakQueuePOM.EnterInputTextarea_TaskQueuePage(_driver).SendKeys(discription);
      TakQueuePOM.ClickOnButton_Popup_TaskQueuePage(_driver,"Confirm Reply");
    }

    [Then(@"Validate that Reply note added successfully")]
    public void ThenValidateThatReplyNoteAddedSuccessfully()
    {
      Assert.That(NotesPOM.CheckAddedNoteDetails_NotesPage(_driver, (string)_scenarioContext["ReplyDescription"]));
    }
    [Then(@"Validate that the Created Task during Add Note is reflecting properly in Queue list page")]
    public void ThenValidateThatTheCreatedTaskDuringAddNoteIsReflectingProperlyInQueueListPage()
    {
      BaseClass.WaitForSpinnerToDisappear(_driver);
     //search Task with date
      InvestmentPagePOM.EnterInputToFilter_InvestmentsPage(_driver, "Created On", Date.ToString("MM/dd/yyyy"));
      InvestmentPagePOM.EnterInputToFilter_InvestmentsPage(_driver, "Due Date", Date.ToString("MM/dd/yyyy"));
      OfferingPagePOM.ClickOnApplyButton(_driver);
      OfferingPagePOM.ClickOnApplyButton(_driver);
      BaseClass.WaitForSpinnerToDisappear(_driver);
     //validate task
      string[] elementlist = { "Assigned To", "Task Priority", "Task Description" };
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      contactDic = (IDictionary<string, string>)TakQueuePOM.GetAddedTaskData_TaskQueuePage(_driver, elementlist);
      string a = (string)_scenarioContext["AssignTaskTo"];
      string b = (string)_scenarioContext["TaskDescription"];
      string c = (string)_scenarioContext["TaskPriority"];
      Assert.That(contactDic[elementlist[0]].Contains((string)_scenarioContext["AssignTaskTo"]));
      Assert.That(contactDic[elementlist[1]].Contains((string)_scenarioContext["TaskPriority"]));
      Assert.That(((string)_scenarioContext["TaskDescription"]).Contains(contactDic[elementlist[2]].Trim('.')));
    }


  }
}
