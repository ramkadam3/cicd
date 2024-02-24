using AventStack.ExtentReports;
using Bogus;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.FedCm;
using OpenQA.Selenium.DevTools.V113.HeapProfiler;
using SpecFlowFrameWork.Utility;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
  
    public class AddACHStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;  

    public AddACHStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
    public static Dictionary<string, string> JsonData()
    {
      string Path = GetDataParser().TestData_Path("AddACHTD");
      var testData = new Dictionary<String, String>();

      testData.Add("FN", GetDataParser().TestData("FN", Path));
      testData.Add("LN", GetDataParser().TestData("LN", Path));
      testData.Add("BankName", GetDataParser().TestData("BankName", Path));
      testData.Add("BankAddressL1", GetDataParser().TestData("BankAddressL1", Path));
      testData.Add("BankAddressL2", GetDataParser().TestData("BankAddressL2", Path));
      testData.Add("Country", GetDataParser().TestData("Country", Path));
      testData.Add("State", GetDataParser().TestData("State", Path));
      testData.Add("City", GetDataParser().TestData("City", Path));
      testData.Add("Zipcode", GetDataParser().TestData("Zipcode", Path));
      testData.Add("AccountHolderType", GetDataParser().TestData("AccountHolderType", Path));
      testData.Add("RoutingNumber", GetDataParser().TestData("RoutingNumber", Path));
      testData.Add("AccountNumber", GetDataParser().TestData("AccountNumber", Path));
      testData.Add("AccountType", GetDataParser().TestData("AccountType", Path));
      testData.Add("PaymentMode", GetDataParser().TestData("PaymentMode", Path));
      testData.Add("BillingAddressL1", GetDataParser().TestData("BillingAddressL1", Path));
      testData.Add("BillingAddressL2", GetDataParser().TestData("BillingAddressL2", Path));
      
      return testData;
    }
    Faker faker = new Faker();
    Random random = new Random();

    [Given(@"Navigate to the Escrow Details section")]
        public void GivenNavigateToTheEscrowDetailsSection()
        {
         EscrowDetailsPOM.NavigateToEscrowDetailsPage(_driver).Click();
         BaseClass.WaitForSpinnerToDisappear(_driver);
        }

        [When(@"Click on Add ACH button")]
        public void WhenClickOnAddACHButton()
        {
         EscrowDetailsPOM.ClickOnAddACHButton_EscrowDetailsPage(_driver).Click();
        }
    [When(@"Click on Add Schedule Escrow button")]
    public void WhenClickOnScheduleEscrowButton()
    {
      EscrowDetailsPOM.ClickOnAddACHButton_EscrowDetailsPage(_driver).Click();
    }

    [Then(@"Validate that Add ACH button navigates to the Add ACH details pop-up")]
        public void ThenValidateThatAddACHButtonNavigatesToTheAddACHDetailsPop_Up()
        {
         Assert.That( BaseClass.EnterInputValue(_driver,"First Name").Displayed);            
        }
        [When(@"Provide input to the Add ACH Details pop-up (.*), (.*), (.*)")]
        public void WhenProvideInputToTheAddACHDetailsPop_Up(string accountHolderType,string accountType,string paymentMode)
        {
      
      


                  string achFN=faker.Person.FirstName;
                  string achLN="faker";
                  string achBankName="fakeBank";
                  string achAddressL1="FakeAddressL1";
                  string achAddressL2="fakeAddressL2";
                  string achAddressL3= "FakeAddressS1";
                  string achAddressL4= "FakeAddressS2";
                  string RoutingNumber= "3030-8799-5";
                  string AccountNumber= "6565-6565-6565-6565";
                  
                  _scenarioContext["achFN"] = achFN;
                  _scenarioContext["achLN"] = achLN;
                  _scenarioContext["achBankName"] = achBankName;
                  _scenarioContext["BankAddressLineOne"]= achAddressL1;
                  _scenarioContext["BankAddressLineTwo"] = achAddressL2;
                  _scenarioContext["AddressLineOne"] = achAddressL3;
                  _scenarioContext["AddressLineTwo"] = achAddressL4;
                  _scenarioContext["RoutingNumber"]= RoutingNumber;
                  _scenarioContext["AccountNumber"]= AccountNumber;









         EnterInputValue(_driver, JsonData()["FN"]).SendKeys(achFN);
         EnterInputValue(_driver, JsonData()["LN"]).SendKeys(achLN);
         EnterInputValue(_driver, JsonData()["BankName"]).SendKeys(achBankName);
         EnterInputValue(_driver, JsonData()["BankAddressL1"]).SendKeys(achAddressL1);
         EnterInputValue(_driver, JsonData()["BankAddressL2"]).SendKeys(achAddressL2);
         Thread.Sleep(1000);
         _scenarioContext["BankState"]= SelectOption_DropDown(_driver, JsonData()["State"], 1, 1);
         Thread.Sleep(3000);
         _scenarioContext["BankCity"]= SelectOption_DropDown(_driver, JsonData()["City"], 1, 1);
         EnterInputValue(_driver, JsonData()["Zipcode"]).SendKeys(Zipcode);
         SelectValue_Sendkey(_driver, JsonData()["AccountHolderType"]).SendKeys(accountHolderType);
         EnterInputValue(_driver, JsonData()["RoutingNumber"]).SendKeys(RoutingNumber);
         EnterInputValue(_driver, JsonData()["AccountNumber"]).SendKeys(AccountNumber);
         SelectValue_Sendkey(_driver, JsonData()["AccountType"]).SendKeys(accountType);
         _scenarioContext["PaymentMode"]= EscrowDetailsPOM.ClickOnPaymentMode_EscrowDetailsPage(_driver, paymentMode);


         Thread.Sleep(1000);
         EnterInputValue(_driver, JsonData()["BillingAddressL1"]).SendKeys(achAddressL3);
         Thread.Sleep(3000);
         EnterInputValue(_driver, JsonData()["BillingAddressL2"]).SendKeys(achAddressL4);
         _scenarioContext["BillingState"] = SelectOption_DropDown(_driver, JsonData()["State"], 2, 2);
         _scenarioContext["BillingCity"] = SelectOption_DropDown(_driver, JsonData()["City"], 2, 2);
         EnterInputValue(_driver, JsonData()["Zipcode"],2).SendKeys(Zipcode);

    }
    [When(@"Edit details of ACH (.*), (.*), (.*)")]
    public void WhenEditDetailsOfACHPersonalSavingYes(string accountHolderType, string accountType, string paymentMode)
    {
      string achFN = faker.Person.FirstName;
      string achLN = "faker";
      string achBankName = "EditBank";
      string achAddressL1 = "EditedAddressL1";
      string achAddressL2 = "EditedAddressL2";
      string achAddressL3 = "EditAddressS1";
      string achAddressL4 = "EditAddressS2";
      string RoutingNumber = "3030-8799-5";
      string AccountNumber = "1111-1111-1111-1111";

      _scenarioContext["achFN"] = achFN;
      _scenarioContext["achLN"] = achLN;
      _scenarioContext["achBankName"] = achBankName;
      _scenarioContext["BankAddressLineOne"] = achAddressL1;
      _scenarioContext["BankAddressLineTwo"] = achAddressL2;
      _scenarioContext["AddressLineOne"] = achAddressL3;
      _scenarioContext["AddressLineTwo"] = achAddressL4;
      _scenarioContext["RoutingNumber"] = RoutingNumber;
      _scenarioContext["AccountNumber"] = AccountNumber;

      ClearAllInput(_driver);
      EnterInputValue(_driver, JsonData()["FN"]).SendKeys(achFN);
      EnterInputValue(_driver, JsonData()["LN"]).SendKeys(achLN);
      EnterInputValue(_driver, JsonData()["BankName"]).SendKeys(achBankName);
      EnterInputValue(_driver, JsonData()["BankAddressL1"]).SendKeys(achAddressL1);
      EnterInputValue(_driver, JsonData()["BankAddressL2"]).SendKeys(achAddressL2);
      Thread.Sleep(1000);
      _scenarioContext["BankState"] = SelectOption_DropDown(_driver, JsonData()["State"], 1, 1);
      Thread.Sleep(3000);
      _scenarioContext["BankCity"] = SelectOption_DropDown(_driver, JsonData()["City"], 1, 1);
      EnterInputValue(_driver, JsonData()["Zipcode"]).SendKeys(Zipcode);
      SelectValue_Sendkey(_driver, JsonData()["AccountHolderType"]).SendKeys(accountHolderType);
      EnterInputValue(_driver, JsonData()["RoutingNumber"]).SendKeys(RoutingNumber);
      EnterInputValue(_driver, JsonData()["AccountNumber"]).SendKeys(AccountNumber);
      SelectValue_Sendkey(_driver, JsonData()["AccountType"]).SendKeys(accountType);
      _scenarioContext["PaymentMode"] = EscrowDetailsPOM.ClickOnPaymentMode_EscrowDetailsPage(_driver, paymentMode);


      Thread.Sleep(1000);
      EnterInputValue(_driver, JsonData()["BillingAddressL1"]).SendKeys(achAddressL3);
      Thread.Sleep(3000);
      EnterInputValue(_driver, JsonData()["BillingAddressL2"]).SendKeys(achAddressL4);
      _scenarioContext["BillingState"] = SelectOption_DropDown(_driver, JsonData()["State"], 2, 2);
      Thread.Sleep(3000);
      _scenarioContext["BillingCity"] = SelectOption_DropDown(_driver, JsonData()["City"], 2, 2);
      EnterInputValue(_driver, JsonData()["Zipcode"], 2).SendKeys(Zipcode);
    }


    [When(@"Save the details")]
    public void WhenSaveTheDetails()
    {
      EscrowDetailsPOM.ClickOnSaveButton_AddAchdetailsPopup(_driver);
      WaitForSpinnerToDisappear(_driver);
      Thread.Sleep(1000); 
    }
    [Then(@"Validate that data of Added ACH displaying properly (.*), (.*)")]
    public void ThenValidateThatDataOfAddedACHDisplayingProperly(string accountType,string accOwnerType)
    {
      
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Account Number", 1).Contains((string)_scenarioContext["AccountNumber"]));
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Routing Number", 1).Contains((string)_scenarioContext["RoutingNumber"]));
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Account Type", 1).Contains(accountType));
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Account Owner Type", 1).Contains(accOwnerType));
    }
    [When(@"Click on Edit action button")]
    public void WhenClickOnEditActionButton()
    {
      ExpandDetailsInnerCard_AddApplicationDetails(_driver, "ACH Setup");
      ClickOnActionButton_byRowColumnArranged(_driver,"Edit",1).Click();
    }
    [Then(@"Validate that Add ACH button navigates to the Edit ACH details pop-up")]
    public void ThenValidateThatAddACHButtonNavigatesToTheEditACHDetailsPop_Up()
    {
      Assert.That(BaseClass.EnterInputValue(_driver, "First Name").Displayed);
    }
    [When(@"Click on ACH Changes button")]
    public void WhenClickOnACHChangesButton()
    {
      ClickOnActionButton_byRowColumnArranged(_driver, "ACH Changes History", 1).Click();
    }
    [When(@"Click on Delete button")]
    
    public void WhenClickOnDeleteButton()
    {   
        ExpandDetailsInnerCard_AddApplicationDetails(_driver, "ACH Setup");
        ClickOnActionButton_byRowColumnArranged(_driver, "Delete", 1).Click();      
    }


    [Then(@"Validate that ACH Changes pop-up show changes properly (.*)")]
    public void ThenValidateThatACHChangesPop_UpShowChangesProperly(string accountType)
    {               
      string name=$"{(string)_scenarioContext["achFN"]} {(string)_scenarioContext["achLN"]}";
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Account Holder Name", 1).Contains(name));      
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Account Type", 1).Contains(accountType));      
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Account Number", 1).Contains((string)_scenarioContext["AccountNumber"]));      
      Assert.That(CheckAddeddetails_byRowColumnArranged(_driver, "Routing Number", 1).Contains((string)_scenarioContext["RoutingNumber"]));
    }
   


  }
}
