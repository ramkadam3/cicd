using AventStack.ExtentReports;
using Bogus;
using CsvHelper;
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
    public class AddCo_BorrowerStepDefinitions:BaseClass
    {

        private readonly IWebDriver _driver;

        private ScenarioContext _scenarioContext;
        private ExtentTest _scenario;

        public AddCo_BorrowerStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;

        }
        public static Dictionary<string, string> JsonData()
        {
            string Path = GetDataParser().TestData_Path("ApplicationTD");
            var testData = new Dictionary<String, String>();
           
          testData.Add("SSN", GetDataParser().TestData("SSN", Path));

      return testData;
        }



        [When(@"Order the loans in (.*)")]
        public void WhenOrderLoansInDescending(string? Order= "descending")
        {
           Order = Order.Trim('"');
           string jam = ManageApplicationPOM.ArrangeLoanInOrder_ManageApplicationPage(_driver).GetAttribute("aria-sort");
            while (!ManageApplicationPOM.ArrangeLoanInOrder_ManageApplicationPage(_driver).GetAttribute("aria-sort").ToLower().Contains(Order.ToLower().Trim('"')))
            {
             ManageApplicationPOM.ArrangeLoanInOrder_ManageApplicationPage(_driver).Click();
             Thread.Sleep(5000);
             BaseClass.WaitForSpinnerToDisappear(_driver);
            }
              
        }



        [When(@"Click on the Co-Borrower button")]
        public void WhenClickOnTheCo_BorrowerButton()
        {
            Thread.Sleep(5000);
            AddCoBorrowerPOM.ClickOnAddCoBorrowerButton_ApplicationDetailsPage(_driver).Click();
            WaitForSpinnerToDisappear(_driver);
            Thread.Sleep(5000);
        }
        [Then(@"Validate that the Co-Borrower button navigate to Add Co-Borrower process")]
        
        public void ThenValidateThatTheCo_BorrowerButtonNavigateToAddCo_BorrowerProcess()
        {            
            Assert.IsTrue(AddCoBorrowerPOM.CheckHeadline_AddCoBorrowerPage(_driver), "Failed: Navigate to Add Co-Borrower process");
        }
        [When(@"Select the All Load Id")]
        public void WhenSelectTheLoanId()
        {
            AddCoBorrowerPOM.SelectAllLoanId_AddCoBorrowerPage(_driver);
        }
        [When(@"Select the Loan Id (.*)")]
        public void WhenSelectTheLoanIdLoanId(string LoanId)
        {
            LoanId = (string)_scenarioContext["AppId"];
            AddCoBorrowerPOM.SelectLoanId_AddCoBorrowerPage(_driver, LoanId);
        }

        [Given(@"Navigate to Co-Borrower section of application (.*)")]
        public void GivenNavigateToCo_BorrowerSectionOfApplication(string CoApplicant)
        {
           BaseClass.WaitForSpinnerToDisappear(_driver);
      CoApplicant = CoApplicant.Trim('"').Trim('<').Trim('>');
     

          if(CoApplicant.Contains("CoApplicant"))
          {
        CoApplicant = ((string)_scenarioContext["PersonalFN"]).ToUpper();
          }
      
     
          Thread.Sleep(2000);
          try
          {
           Assert.IsTrue( ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).GetAttribute("class").Contains("active"),"Unable to navigate to Co-Borrower details");
          }
          catch
          {
           ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).Click();
           BaseClass.WaitForSpinnerToDisappear(_driver);
          }
           ApplicationDetailsPOM.SelectCoBorrowerNamed_ApplicationDetailsPage(_driver, CoApplicant);
           BaseClass.WaitForSpinnerToDisappear(_driver);
        }
    [Given(@"Navigate to Co-Borrower section of application's when no Co-Borrower name")]
    public void GivenNavigateToCo_BorrowerSectionOfApplicationsWhenNoCo_BorrowerName()
    {
      BaseClass.WaitForSpinnerToDisappear(_driver);
      Thread.Sleep(2000);
      try
      {
        Assert.IsTrue(ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).GetAttribute("class").Contains("active"), "Unable to navigate to Co-Borrower details");
      }
      catch
      {
        ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).Click();
        BaseClass.WaitForSpinnerToDisappear(_driver);
      }
    }

    
    [Then(@"Validate that the Borrower details page show Co-Borrower Details properly")]
    
    public void ThenValidateThatTheBorrowerDetailsPageShowDetailsProperly()
    {
      IDictionary<string, string> personalDic = new Dictionary<string, string>();
      Thread.Sleep(7000);
      string[] dataKey = { "Name", "Previous Name", "Maiden Name", JsonData()["SSN"], "Date Of Birth", "License State Code", "License No","Borrower Source" };
      personalDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Co-Borrower Details", dataKey);
      
      //Assert.IsTrue(personalDic[dataKey[0]].Contains( ($"{(string)_scenarioContext["PersonalFN"]} {(string)_scenarioContext["PersonalMN"]} {(string)_scenarioContext["PersonalLN"]}").ToUpper()), $"Validation failed for element {dataKey[0]}");

      string ssn = ((string)_scenarioContext["PersonalSSN"]);     
            
      Assert.AreEqual(personalDic[dataKey[1]], (string)_scenarioContext["PreviousName"], $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(personalDic[dataKey[2]], (string)_scenarioContext["MaidenName"], $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(personalDic[dataKey[3]].Contains( ssn.Substring(ssn.Length - 4)), $"Validation failed for element {dataKey[3]}");
      //Assert.AreEqual(personalDic[dataKey[3]], (string)_scenarioContext["IsUSCitizen"], $"Validation failed for element {dataKey[6]}");
      Assert.AreEqual(personalDic[dataKey[5]], (string)_scenarioContext["DriversLicenceStateCode"], $"Validation failed for element {dataKey[5]}");
      Assert.AreEqual(personalDic[dataKey[6]], (string)_scenarioContext["DriverLicence"], $"Validation failed for element {dataKey[6]}");
      Assert.AreEqual(personalDic[dataKey[7]], (string)_scenarioContext["BorrowerSource"], $"Validation failed for element {dataKey[7]}");
    }
    [Then(@"Validate that the Co-Borrower details page show Education details properly")]

    public void ThenValidateThatTheBorrowerDetailsPageShowEducationDetailsProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Education Level", "School", "School State" };
      contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Education Details", dataKey);
      
      string a = (string)_scenarioContext["school"];
      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["educationLevel"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["school"], $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["schoolState"], $"Validation failed for element {dataKey[2]}");
    }
    //********************************************************************Swap to Borrower***********************************************************************************



    [Then(@"Check that the Borrower has a CoBorrower then Click on it")]
    public void ThenCheckThatTheBorrowerHasACoBorrower()
    {
      int i=1;
      bool visible=false;
      while (!visible)
      {
      try {
          ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).Click();
          visible=true;
          }
         catch (Exception ex)
          {
          i++;
          ManageApplicationPOM.NavigateToManageApplicationPage(_driver);
          BaseClass.WaitForSpinnerToDisappear(_driver);
          ManageApplicationPOM.ClickOnAppID_ManageApplicationPage(_driver, i).Click();          
          }
      }
         EscrowDetailsPOM.NavigateToEscrowDetailsPage(_driver).Click();
      
    }
    [Then(@"Check that the Borrower has a CoBorrower then Click on it Borrower details")]
    public void ThenCheckThatTheBorrowerHasACoBorrower1()
    {
      int i = 1;
      bool visible = false;
      while (!visible)
      {
        try
        {
          ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).Click();
          visible = true;
        }
        catch (Exception ex)
        {
          i++;
          ManageApplicationPOM.NavigateToManageApplicationPage(_driver);
          BaseClass.WaitForSpinnerToDisappear(_driver);
          ManageApplicationPOM.ClickOnAppID_ManageApplicationPage(_driver, i).Click();          
        }
      }

    }
    [Then(@"Check that the Borrower has a CoBorrower, Create it if not")]
    public void ThenCheckThatTheBorrowerHasACoBorrowerCreateItIfNot()
    {
      try
      {
        ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).Click();       
      }
      catch 
      {   
        AddCoBorrowerPOM.ClickOnAddCoBorrowerButton_ApplicationDetailsPage(_driver).Click();
        WaitForSpinnerToDisappear( _driver);  
        var faker = new Faker();
        string fName = faker.Person.FirstName;
        Thread.Sleep(2000);
        
        AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "First Name").SendKeys(fName);
        AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Email").SendKeys(faker.Person.Email);
        AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone cell").SendKeys("1234567890");
        AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Preferred Method Of Contact").SendKeys("contact");
        AddApicationPOM.ClickOnSaveAndNextButton(_driver);
        Thread.Sleep(3000);
        NavigateToBackPage(_driver);
        WaitForSpinnerToDisappear(_driver);
        ApplicationDetailsPOM.ClickOnCoBorrowerDetails_ApplicationDetailsPage(_driver).Click();
      }
    }

    [When(@"Click on the Swap to Borrower button")]
    public void WhenClickOnTheSwapToBorrowerButton()
    {
      IDictionary<string, string> personalDic = new Dictionary<string, string>();
      Thread.Sleep(2000);
      string[] dataKey = { "Name" };
      personalDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Co-Borrower Details", dataKey);
      _scenarioContext["CoBorrowerFName"] = personalDic[dataKey[0]];
      AddApicationPOM.ClickOnSwapToBorrower_CoBorrowerDetailsPage(_driver);
    }

    

    [Then(@"Validate Co-Borrower swapped to Borrower successfully")]
    public void ThenValidateCo_BorrowerSwappedToBorrowerSuccessfully()
    {
      ApplicationDetailsPOM.ClickOnBorrowerDetails_ApplicationDetailsPage(_driver).Click();
      IDictionary<string, string> personalDic = new Dictionary<string, string>();
      Thread.Sleep(2000);
      string[] dataKey = { "Name" };
      personalDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Personal Details", dataKey);
      Assert.AreEqual(personalDic[dataKey[0]], (string)_scenarioContext["CoBorrowerFName"]);

    }
    [When(@"Click on Confirm button")]
    public void WhenClickOnConfirmButton()
    {
      Thread.Sleep(4000);
      ApplicationDetailsPOM.ClickOnConfirmDelete_DeletLoanPOPup_ApplicationDetailsPage(_driver);
    }


    //******************************************************************Activate Inactivate Co-Borrower**********************************************************************



    [When(@"Click on Active_Inactive Toggle button")]
    public void WhenClickOnActive_InactiveToggleButton()
    {
      IDictionary<string, string> personalDic = new Dictionary<string, string>();
      Thread.Sleep(2000);
      string[] dataKey = { "Name" };
      personalDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Co-Borrower Details", dataKey);

      _scenarioContext["FName"] = personalDic[dataKey[0]];
      _scenarioContext["CoBorrowerStatusOrignally"]= AddApicationPOM.ClickOnActivationOfCoBorrower_CoBorrowerDetailsPage(_driver);
    }

    [Then(@"Validate that Co-Borrower deactivated successfully")]
    public void ThenValidateThatCo_BorrowerDeactivatedSuccessfully()
    {
      Thread.Sleep(4000);
      
      if (((string)_scenarioContext["CoBorrowerStatusOrignally"]).Contains("active"))
        Assert.That( AddApicationPOM.GetActivationStatusOfCoBorrower_CoBorrowerDetailsPage(_driver).Contains("inactive"));
    }

    [Then(@"Validate that Co-Borrower activated successfully")]
    public void ThenValidateThatCo_BorrowerActivatedSuccessfully()
    {
      Thread.Sleep(4000);

      if (((string)_scenarioContext["CoBorrowerStatusOrignally"]).Contains("inactive"))
        Assert.That(AddApicationPOM.GetActivationStatusOfCoBorrower_CoBorrowerDetailsPage(_driver).Contains("active"));
    }

    [Then(@"Validate that status of Co-Borrower could not affected by canceling the process")]
    public void ThenValidateThatStatusOfCo_BorrowerCouldNotAffectedByCancelingTheProcess()
    {
      Thread.Sleep(4000);
      Assert.That(AddApicationPOM.GetActivationStatusOfCoBorrower_CoBorrowerDetailsPage(_driver).Contains((string)_scenarioContext["CoBorrowerStatusOrignally"]));
    }

    [Then(@"Validate that the deactivated Co-Borrower has not swapping facility")]
    public void ThenValidateThatTheDeactivatedCo_BorrowerHasNotSwappingFacility()
    {
      try
      {

        AddApicationPOM.ClickOnSwapToBorrower_CoBorrowerDetailsPage(_driver);
        Assert.IsTrue(false, "Failed, Swapping is available for in active co-borrower");
      }
      catch
      {
        Assert.IsTrue(true, "Swapping is not available for in active co-borrower");
      }
    }
    //*******************************************************************Edit Co-Borrower ***********************************************************************************
    [When(@"Click on Edit button")]
    public void WhenClickOnEditButton()
    {
      AddCoBorrowerPOM.ClickOnEditButton_ApplicationDetailsPage(_driver).Click();
      WaitForPageToLoad(_driver);
    }

  }
}
