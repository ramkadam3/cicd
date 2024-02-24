using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Pages.ServicingObject;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.StepDefinitions.ServicingDefination
{
  [Binding]
  public class BorrowerDetailsDefination:BaseClass
  {

    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public BorrowerDetailsDefination(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
    public static Dictionary<string, string> JsonData()
    {
      string Path = GetDataParser().TestData_Path("ApplicationTD");
      var testData = new Dictionary<String, String>();
      
      testData.Add("PreferredMethodOfContact", GetDataParser().TestData("PreferredMethodOfContact", Path));

      return testData;
    }


    [Then(@"Validate that the Borrower details page show Personal details -Servicing- properly")]
    public void ThenValidateThatTheBorrowerDetailsPageShowDetailsServicingProperly()
    {
      IDictionary<string, string> personalDic = new Dictionary<string, string>();
      Thread.Sleep(2000);
      string[] dataKey = { "Name", "SSN", "Date Of Birth", "License State Code", "License No" };
      personalDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Personal Details", dataKey);

      Assert.IsTrue(personalDic[dataKey[0]].Contains($"{(string)_scenarioContext["PersonalFN"]} {(string)_scenarioContext["PersonalMN"]} {(string)_scenarioContext["PersonalLN"]}".ToUpper()), $"Validation failed for element {dataKey[0]}");
      string ssn = ((string)_scenarioContext["PersonalSSN"]);
      string us = (string)_scenarioContext["IsUSCitizen"];
      Assert.AreEqual(personalDic[dataKey[1]], ssn.Substring(ssn.Length - 4), $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(personalDic[dataKey[3]], (string)_scenarioContext["DriversLicenceStateCode"], $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(personalDic[dataKey[4]], (string)_scenarioContext["DriverLicence"], $"Validation failed for element {dataKey[4]}");

      // Assert.AreEqual(personalDic[dataKey[1]], (string)_scenarioContext["PersonalMN"], $"Validation failed for element {dataKey[1]}");
      // Assert.AreEqual(personalDic[dataKey[2]], (string)_scenarioContext["PersonalLN"], $"Validation failed for element {dataKey[2]}");
      //Assert.AreEqual(personalDic[dataKey[3]], (string)_scenarioContext["IsUSCitizen"], $"Validation failed for element {dataKey[3]}");
      
    }


    [Then(@"Validate that the Borrower details page of servicing show Contact details properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowContactDetailsProperly()
    {
      ExpandDetailsInnerCard_ExpansionType(_driver, "Contact Details");
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Email", "Alternative Email", "Phone Cell", "Phone Home", "Phone Other" };
      contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Contact Details", dataKey);
      
      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["ContactEmail"], $"Validation failed for element {dataKey[0]}");

      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["ContactAltEmail"], $"Validation failed for element {dataKey[1]}");

      Assert.AreEqual((contactDic[dataKey[2]]).Trim('(').Replace(")", "").Replace(" ", "").Replace("-", ""), (string)_scenarioContext["ContactPhone"], $"Validation failed for element {dataKey[2]}");

      Assert.AreEqual((contactDic[dataKey[3]]).Trim('(').Replace(")", "").Replace(" ", "").Replace("-", ""), (string)_scenarioContext["ContactHome"], $"Validation failed for element {dataKey[3]}");

      Assert.AreEqual((contactDic[dataKey[4]]).Trim('(').Replace(")", "").Replace(" ", "").Replace("-", ""), (string)_scenarioContext["ContactOther"], $"Validation failed for element {dataKey[4]}");
     

    }

    [When(@"Expand Address Card of Borrower details")]
    public void WhenExpandAddressCardOfBorrowerDetails()
    {
      ExpandDetailsInnerCard_ExpansionType(_driver, "Address");
    }
    [When(@"Close Card of Borrower details (.*)")]
    public void WhenCloseCardOfBorrowerDetails(string cardName)
    {
      CloseDetailsInnerCard_ExpansionType(_driver, cardName);
    }
    [When(@"Expand Card of Borrower details (.*)")]
    public void WhenExpandCardOfBorrowerDetails(string cardName)
    {
      ExpandDetailsInnerCard_ExpansionType(_driver, cardName);
    }

    [Then(@"Validate that the Borrower details page of Servicing show Physical Address properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowPhysicalAddressProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "State Code", "City", "Zip Code" };
      contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Physical Address", dataKey);
      
        
         //Assert.AreEqual(contactDic[dataKey[0]], "USA", $"Validation failed for element {dataKey[0]}");
        //Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["MailingState"], $"Validation failed for element {dataKey[0]}");
        Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["MailingCity"], $"Validation failed for element {dataKey[1]}");
      //Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["PhysicalState"], $"Validation failed for element {dataKey[1]}");
      //Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["PhysicalCity"], $"Validation failed for element {dataKey[2]}");
        Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["Zipcode"], $"Validation failed for element {dataKey[2]}");

        
      
    }

    [Then(@"Validate that the Borrower details page of Servicing show Other details properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowOtherDetailsProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "State Code", "City", "Zip Code" };
      contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Other", dataKey);
      
      string p = (string)_scenarioContext["OtherState"];
      
      //Assert.AreEqual(contactDic[dataKey[0]], "USA", $"Validation failed for element {dataKey[0]}");
      //Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["OtherState"], $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["OtherCity"]), $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["Zipcode"], $"Validation failed for element {dataKey[2]}");
      
    }

    [Then(@"Validate that the Borrower details page of Servicing show Mailing Address properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowMailingAddressProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "State Code", "City", "Zip Code" };
      contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails_UsingContains(_driver, "Mailing Address", dataKey);
      
      
      //Assert.AreEqual(contactDic[dataKey[0]], "USA", $"Validation failed for element {dataKey[0]}");
      //Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["MailingState"], $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["Zipcode"], $"Validation failed for element {dataKey[2]}");
         
    }

    [Then(@"Validate that the Borrower details page of Servicing show Reference details properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowReferenceDetailsProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Relationship", "First & Last Name", "Middle Initial","Email", "Phone","Address" };
      Thread.Sleep(3000);
      contactDic = (IDictionary<string, string>)BorrowerPagePOM.GetAddedData_BorrowerDetails_withSubCardName(_driver, "Reference", dataKey);
      
      string b = (string)_scenarioContext["Email"];  
      
        Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["Relationship"], $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(contactDic[dataKey[1]].Contains($"{(string)_scenarioContext["ReferenceFN"]}"), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(contactDic[dataKey[1]].Contains($"{(string)_scenarioContext["ReferenceLN"]}"), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["ReferenceMN"]), $"Validation failed for element {dataKey[2]}");      
        Assert.IsTrue(contactDic[dataKey[3]].Contains((string)_scenarioContext["Email"]), $"Validation failed for element {dataKey[3]}");
        Assert.AreEqual(contactDic[dataKey[4]], ((string)_scenarioContext["Phone"]).FormatAsPhoneNumber(), $"Validation failed for element {dataKey[4]}");
      

     
    }
    [Then(@"Validate that the Borrower details page of Servicing show Finance details properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowFinanceDetailsProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Amount", "Frequency", "Description", "Type"};
      Thread.Sleep(3000);
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Income", dataKey);

        string a = contactDic[dataKey[0]].RemoveCurrencyFormat();              
        string c= (string)_scenarioContext["FinanceNote"];
        string d= (string)_scenarioContext["IncomeType"];
        string f= (string)_scenarioContext["IncomeFrequency"];

      Assert.AreEqual(contactDic[dataKey[0]].RemoveCurrencyFormat(), (string)_scenarioContext["FinanceAmount"], $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains($"{(string)_scenarioContext["FinanceNote"]}"), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains($"{(string)_scenarioContext["IncomeType"]}"), $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(contactDic[dataKey[3]].Contains((string)_scenarioContext["IncomeFrequency"]), $"Validation failed for element {dataKey[3]}");
      
    }

    

    [Then(@"Validate that the Borrower details page of Servicing show Employment details properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowEmploymentDetailsProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Employer Name", "Employer Email", "Phone Number", "Employment Type", "Position", "No of Hours Per week", "Country", "State", "City", "Zip Code" };
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Employment Details", dataKey);
      
      string a = (string)_scenarioContext["EmployeeEmpName"];
      string b = (string)_scenarioContext["EmployeeEmail"];
      string c = (string)_scenarioContext["EmployeeState"];
      string e = (string)_scenarioContext["EmployeeCity"];
      //string d = (string)_scenarioContext["Zipcode"];
     

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["EmployeeEmpName"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["EmployeeEmail"], $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], ((string)_scenarioContext["EmployeePhone"]).FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");   
      Assert.AreEqual(contactDic[dataKey[3]], (string)_scenarioContext["EmployeeType"], $"Validation failed for element {dataKey[3]}");   
      Assert.AreEqual(contactDic[dataKey[4]], (string)_scenarioContext["Position"], $"Validation failed for element {dataKey[4]}");   
      Assert.AreEqual(contactDic[dataKey[5]], (string)_scenarioContext["HoursPerWeek"], $"Validation failed for element {dataKey[5]}");  
      Assert.AreEqual(contactDic[dataKey[6]], "USA", $"Validation failed for element {dataKey[6]}");  
      Assert.AreEqual(contactDic[dataKey[7]], (string)_scenarioContext["EmployeeState"], $"Validation failed for element {dataKey[7]}");   
      Assert.AreEqual(contactDic[dataKey[8]], (string)_scenarioContext["EmployeeCity"], $"Validation failed for element {dataKey[8]}");  
      Assert.AreEqual(contactDic[dataKey[9]], Zipcode, $"Validation failed for element {dataKey[9]}");
      
    }

    [Then(@"Validate that the Borrower details page of Servicing show Education details properly")]
    public void ThenValidateThatTheBorrowerDetailsPageOfServicingShowEducationDetailsProperly()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Education Level", "School", "School State" };
      contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Education Detail", dataKey);
      
      string a = (string)_scenarioContext["school"];
      

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["educationLevel"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["school"], $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["schoolState"], $"Validation failed for element {dataKey[2]}");
     
    }
    [Given(@"Navigate to Back Page")]
    public void GivenNavigateToBackPage()
    {
      NavigateToBackPage(_driver);
    }

  }
}
