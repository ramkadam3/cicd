using AventStack.ExtentReports.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class EscrowDetailsStepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;

    public EscrowDetailsStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
    public static Dictionary<string, string> JsonData()
    {
      string Path = GetDataParser().TestData_Path("EscrowDetailsTD");
      var testData = new Dictionary<String, String>();

      testData.Add("SelectBorrowerName", GetDataParser().TestData("SelectBorrowerName", Path));
      testData.Add("EscrowStartDate", GetDataParser().TestData("EscrowStartDate", Path));
      testData.Add("NoOfEscrowPayments", GetDataParser().TestData("NoOfEscrowPayments", Path));
      testData.Add("PaymentFrequency", GetDataParser().TestData("PaymentFrequency", Path));
      testData.Add("ScheduleEscrowAmount", GetDataParser().TestData("ScheduleEscrowAmount", Path));
      testData.Add("FirstPaymentDay", GetDataParser().TestData("FirstPaymentDay", Path));
      testData.Add("SecondPaymentDay", GetDataParser().TestData("SecondPaymentDay", Path));
      //**********************************************************************************************************************************************//
      testData.Add("EscrowAccountBalance", GetDataParser().TestData("EscrowAccountBalance", Path));
      testData.Add("EscrowLength", GetDataParser().TestData("EscrowLength", Path));
      testData.Add("SuccessfulEscrowPayments", GetDataParser().TestData("SuccessfulEscrowPayments", Path));
      testData.Add("FailedEscrowPayments", GetDataParser().TestData("FailedEscrowPayments", Path));
      testData.Add("NextPaymentDate", GetDataParser().TestData("NextPaymentDate", Path));
      testData.Add("PreviousPaymentDate", GetDataParser().TestData("PreviousPaymentDate", Path));

      return testData;
    }

    [Then(@"Check that the (.*) Schedule Escrow button is available, Click on button if available")]
    public void ThenCheckThatTheEditScheduleEscrowButtonIsAvailable(string buttonName)
    {
      buttonName = buttonName.Trim('"');
      int i = 1;
      bool visible = false;

      while (!visible)
      {
        try
        {
          Thread.Sleep(2000);
          Assert.IsTrue(EscrowDetailsPOM.ClickOnScheduleEscrowButton_EscrowDetailsPage(_driver, buttonName).Displayed, $"{buttonName} Schedule Escrow button is not available");
          EscrowDetailsPOM.ClickOnScheduleEscrowButton_EscrowDetailsPage(_driver, buttonName).Click();
          visible = true;
          Thread.Sleep(3000);
        }
        catch (Exception ex)
        {
          i++;
          ManageApplicationPOM.NavigateToManageApplicationPage(_driver);
          BaseClass.WaitForSpinnerToDisappear(_driver);
          ManageApplicationPOM.ClickOnAppID_ManageApplicationPage(_driver, i).Click();
          EscrowDetailsPOM.NavigateToEscrowDetailsPage(_driver).Click();
        }
      }
    }

        [When(@"Provide details to Schedule Escrow pop-up (.*), (.*)")]
        public void WhenProvideDetailsToScheduleEscrowPop_Up(string frequency,string escrowAmount)
        {
        Thread.Sleep(3000);
        _scenarioContext["BorrowerName"] = SelectOption_DropDown(_driver, JsonData()["SelectBorrowerName"],0);
        EnterInputValue(_driver, JsonData()["EscrowStartDate"]).SendKeys(Date.ToString());
        SelectValue_Sendkey(_driver, JsonData()["PaymentFrequency"]).SendKeys(frequency);
      if("monthly".Contains(frequency.ToLower()))
      {//frequency.ToLower().Contains("semi monthly")
        SelectValue_Sendkey(_driver, JsonData()["FirstPaymentDay"]).SendKeys("10");
        if(frequency.ToLower().Contains("semi monthly"))
        SelectValue_Sendkey(_driver, JsonData()["SecondPaymentDay"]).SendKeys("12");
      }
        EnterInputValue(_driver, JsonData()["ScheduleEscrowAmount"]).SendKeys(escrowAmount);
        }
    [When(@"Edit details of Schedule Escrow pop-up (.*), (.*)")]
    public void WhenEditDetailsOfScheduleEscrowPop_Up(string frequency, string escrowAmount)
    {
      Thread.Sleep(3000);
      ClearAllInput(_driver);
      _scenarioContext["BorrowerName"] = SelectOption_DropDown(_driver, JsonData()["SelectBorrowerName"], 0);
      //EnterInputValue(_driver, JsonData()["EscrowStartDate"]).SendKeys(Date.ToString());
      SelectValue_Sendkey(_driver, JsonData()["PaymentFrequency"]).SendKeys(frequency);
      if ("monthly".Contains(frequency.ToLower()))
      {//frequency.ToLower().Contains("semi monthly") ||
        SelectValue_Sendkey(_driver, JsonData()["FirstPaymentDay"]).SendKeys("10");
        if (frequency.ToLower().Contains("semi monthly"))
          SelectValue_Sendkey(_driver, JsonData()["SecondPaymentDay"]).SendKeys("12");
      }
      EnterInputValue(_driver, JsonData()["ScheduleEscrowAmount"]).SendKeys(escrowAmount);
    }

        [Then(@"Validate that the No of Escrow payments field shows default value two and it is disabled")]
        public void ThenValidateThatTheNo_OfEscrowPaymentsFieldShowsDefaultValueAndItIsDisabled()
        {
          string s=EnterInputValue(_driver, JsonData()["NoOfEscrowPayments"]).GetAttribute("value");
          Assert.That(s.Contains("2"));
        }
        [Then(@"Validate that the Escrow Start date field is disabled by default")]
        public void ThenValidateThatTheEscrowStartDateFieldIsDisabledByDefault()
        {
          Assert.That(!EnterInputValue(_driver, JsonData()["EscrowStartDate"]).Enabled);
        }

        [Then(@"Click on the Set button")]
        
        public void ThenClickOnTheSetButton()
        {
         EscrowDetailsPOM.ClickOnSetButton_AddAchdetailsPopup(_driver);
        }

       [Then(@"Validate that the Added Escrow details displaying properly (.*), (.*)")]
       public void ThenValidateThatTheAddedEscrowDetailsDisplayingProperly(string frequency, double amount)
       {
              if (frequency.ToLower().Contains("semi monthly"))
              frequency = "Semi-Monthly";

            Thread.Sleep(3000);
            IDictionary<string, string> escrowDic = new Dictionary<string, string>();
            ExpandDetailsInnerCard_ExpansionType(_driver, "Escrow Schedule Details");
            string[] dataKey = { "Minimum no. of Escrow Payments", "Schedule Escrow Amount", "Payment Frequency", "Escrow Start Date" };
            escrowDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Escrow Schedule Details", dataKey);
            
            Assert.That(escrowDic[dataKey[0]].Contains("2"));
            Assert.That(escrowDic[dataKey[1]].Contains(amount.ToString("N2")));
            Assert.That(escrowDic[dataKey[2]].Contains(frequency));
            string b = Date.ToString("MM-dd-yyyy");
            Assert.That(escrowDic[dataKey[3]].Contains(Date.ToString("MM-dd-yyyy")));   
       }
    [Then(@"Validate that the Edited Escrow details displaying properly (.*), (.*)")]
    public void ThenValidateThatTheEditedEscrowDetailsDisplayingProperlyWeekly(string frequency, double amount)
    {
      if (frequency.ToLower().Contains("semi monthly"))
        frequency = "Semi-Monthly";

      Thread.Sleep(3000);
      IDictionary<string, string> escrowDic = new Dictionary<string, string>();
      ExpandDetailsInnerCard_ExpansionType(_driver, "Escrow Schedule Details");
      string[] dataKey = { "Minimum no. of Escrow Payments", "Schedule Escrow Amount", "Payment Frequency", "Escrow Start Date" };
      escrowDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Escrow Schedule Details", dataKey);

      Assert.That(escrowDic[dataKey[0]].Contains("2"));
      Assert.That(escrowDic[dataKey[1]].Contains(amount.ToString("N2")));
      Assert.That(escrowDic[dataKey[2]].Contains(frequency));      
    }

    [Then(@"Validate that the Card of Escrow details displaying properly")]
    public void ThenValidateThatTheCardOfEscrowDetailsDisplayingProperly()
    {
      ExpandDetailsInnerCard_ExpansionType(_driver, "Escrow Payment Details");
      ExpandDetailsInnerCard_ExpansionType(_driver, "Escrow Schedule Details");
      ExpandDetailsInnerCard_ExpansionType(_driver, "ACH Setup");
      ExpandDetailsInnerCard_ExpansionType(_driver, "Escrow History");
    }

    [Then(@"Validate that the Card show proper data")]
    public void ThenValidateThatTheCardShowProperData()
    {
      IDictionary<string, string> escrowDic = new Dictionary<string, string>();
      ExpandDetailsInnerCard_ExpansionType(_driver, "Escrow Schedule Details");
      string[] dataKey = { "Minimum no. of Escrow Payments", "Schedule Escrow Amount", "Payment Frequency", "Escrow Start Date" };
      escrowDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Escrow Schedule Details", dataKey);
      Assert.That(!escrowDic[dataKey[0]].IsNullOrEmpty());
      Assert.That(!escrowDic[dataKey[1]].IsNullOrEmpty());
      Assert.That(!escrowDic[dataKey[2]].IsNullOrEmpty());
      Assert.That(!escrowDic[dataKey[3]].IsNullOrEmpty());
    }


  }
}
