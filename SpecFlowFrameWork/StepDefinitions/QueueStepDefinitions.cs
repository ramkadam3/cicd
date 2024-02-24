using AventStack.ExtentReports;
using Bogus;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Pages.Origination.TaskQueuePage;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class QueueStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public QueueStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
        Faker faker =new Faker();
        [Given(@"Navigate to Task Queue page")]
        public void GivenNavigateToTaskQueuePage()
        {
         TakQueuePOM.NavigateToTaskQueuePage(_driver);
        }

        [When(@"Click on Add Task button")]
        public void WhenClickOnAddTaskButton()
        {
         TakQueuePOM.ClickOnAddTaskButton_TaskQueuePage(_driver);
        }
    [When(@"Select Application id on Popup")]
    public void WhenSelectApplicationIdOnPopup()
    {Thread.Sleep(2000);
      _scenarioContext["ApplicationId"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "Application Id", 1);
      Thread.Sleep(2000);
    }

    [When(@"Provide Due date to popup")]
    public void WhenProvideDueDateToPopup()
    {
      DateTime date = DateTime.Now;
      string d = date.ToString("MM/dd/yyyy");
      _scenarioContext["DueDate"] =d;
      ApplicationDetailsPOM.EnterInputValue_AddDebtsPopup_ApplicationDetailsPage(_driver, "Due Date", d);
    }

    [When(@"Provide input to Assign task field")]
    public void WhenProvideInputToAssignTaskField()
    {
     _scenarioContext["AssignTaskTo"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver,"Assign Task To",1);
      Thread.Sleep(2000);
    }

    [When(@"Provide input to Assign priority (.*)")]
    public void WhenProvideInputToAssignPriority(string priority)
    {
      _scenarioContext["TaskPriority"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "Task Priority", 1);
      Thread.Sleep(2000);
    }

    [When(@"Provide description to popup")]
    public void WhenProvideDescriptionToPopup()
    {
      string discription = "adcdefghijkl";
      _scenarioContext["Description"] = discription;
      TakQueuePOM.EnterInputTextarea_TaskQueuePage(_driver).SendKeys(discription);
    }

    [Then(@"Click on the Create button")]
    public void ThenClickOnTheCreateButton()
    {
      TakQueuePOM.ClickOnCreateButton_AddIncomePopup_TaskQueuePage(_driver);
    }

    [Then(@"Validate that Task reflects data properly in Queue list page")]
    public void ThenValidateThatTaskReflectsDataProperlyInQueueListPage()
    {
      BaseClass.WaitForSpinnerToDisappear(_driver);
      string[] elementlist = { "Assigned To","Task Priority","Task Description" };
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      contactDic= (IDictionary<string, string>)TakQueuePOM.GetAddedTaskData_TaskQueuePage(_driver, elementlist);
      string a= (string)_scenarioContext["AssignTaskTo"];
      string b = (string)_scenarioContext["Description"];
      string c = (string)_scenarioContext["TaskPriority"];
      Assert.That(contactDic[elementlist[0]].Contains((string)_scenarioContext["AssignTaskTo"]));
      Assert.That(contactDic[elementlist[1]].Contains((string)_scenarioContext["TaskPriority"]));
      Assert.That(contactDic[elementlist[2]].Contains((string)_scenarioContext["Description"]));    
    }
    [When(@"Click on Assign Task button")]
    public void WhenClickOnAssignTaskButton()
    {     
      TakQueuePOM.ClickOnButton_ActionItem_TaskQueuePage(_driver,"Assign Task");
    }

    [When(@"Select Assign task to on Select member pop-up")]
    public void WhenSelectAssignTaskToOnSelectMemberPop_Up()
    {
      _scenarioContext["AssigneTask"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "Assign Task To", 3);
      Thread.Sleep(2000);
      TakQueuePOM.ClickOnButton_Popup_TaskQueuePage(_driver,"Assign");
    }

    [Then(@"Validate that the Assigned Task updated properly")]
    public void ThenValidateThatTheAssignedTaskUpdatedProperly()
    {
      string[] elementlist = { "Assigned To" };
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      contactDic = (IDictionary<string, string>)TakQueuePOM.GetAddedTaskData_TaskQueuePage(_driver, elementlist);

      Assert.That(contactDic[elementlist[0]].Contains((string)_scenarioContext["AssigneTask"]));
    }

    [When(@"Click on Edit Task button")]
    public void WhenClickOnEditTaskButton()
    {                             
      TakQueuePOM.ClickOnButton_ActionItem_TaskQueuePage(_driver, "Edit Task");
    }

    [When(@"Edit Task details")]
    public void WhenEditTaskDetails()
    {
      Thread.Sleep(5000);
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      DateTime date = DateTime.Now.Date.AddDays(1);
      string d = date.ToString("MM-dd-yyyy");
      _scenarioContext["DueDate"] = d;
      TakQueuePOM.EnterInputValue_QueuePage(_driver, "Due Date", d);
      Thread.Sleep(2000);
      _scenarioContext["TaskPriority"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "Task Priority", 2);
      string discription = "Description updated";
      _scenarioContext["Description"] = discription;
      TakQueuePOM.EnterInputTextarea_TaskQueuePage(_driver).Clear();
      TakQueuePOM.EnterInputTextarea_TaskQueuePage(_driver).SendKeys(discription);
      TakQueuePOM.ClickOnButton_Popup_TaskQueuePage(_driver, "Update");
      Thread.Sleep(2000);

    }

    [Then(@"Validate that the Task updated successfully")]
    public void ThenValidateThatTheTaskUpdatedSuccessfully()
    {
      BaseClass.WaitForSpinnerToDisappear(_driver);
      string[] elementlist = { "Assigned To", "Task Priority", "Task Description" };
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      contactDic = (IDictionary<string, string>)TakQueuePOM.GetAddedTaskData_TaskQueuePage(_driver, elementlist);           
      Assert.That(contactDic[elementlist[1]].Contains((string)_scenarioContext["TaskPriority"]));
      Assert.That(contactDic[elementlist[2]].Contains((string)_scenarioContext["Description"]));
    }

    [When(@"Click on Change status action and Change the status (.*)")]
    public void WhenClickOnChangeStatusActionAndChangeTheStatus(string status)
    {
      TakQueuePOM.ChangeStatusButton_ActionItem_TaskQueuePage(_driver, status);
    }

    [Then(@"Validate that the status changed successfully (.*)")]
    public void ThenValidateThatTheStatusChangedSuccessfully(string status)
    {
      
      BaseClass.WaitForSpinnerToDisappear(_driver);
      string[] elementlist = { "Status" };
      IDictionary<string, string> Dic = new Dictionary<string, string>();
      Dic = (IDictionary<string, string>)TakQueuePOM.GetAddedTaskData_TaskQueuePage(_driver, elementlist);
      Assert.That(status.Replace(" ","").Contains(Dic[elementlist[0]]));
    }

  }
}
