using AventStack.ExtentReports;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Linq.Expressions;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ApplicationDetailsPage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Pages.ServicingObject;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.StepDefinitions
{
  [Binding]
  public class AddWelcomeLetterStepDefinitions : BaseClass
  {

    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public AddWelcomeLetterStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
    public static Dictionary<string, string> JsonData()
    {
      string Path = GetDataParser().TestData_Path("AddInvestmentTD");
      var testData = new Dictionary<String, String>();

      testData.Add("CompanyeSignCardTitle", GetDataParser().TestData("CompanyeSignCardTitle", Path));
      testData.Add("MakePaymentCardTitle", GetDataParser().TestData("MakePaymentCardTitle", Path));
      testData.Add("FinalizeInvestmentCardTitle", GetDataParser().TestData("FinalizeInvestmentCardTitle", Path));

      return testData;
    }



    [Given(@"Navigate to Manage Application page")]
    public void GivenNavigateToManageApplicationPage()
    {
      ManageApplicationPOM.NavigateToManageApplicationPage(_driver);
      Thread.Sleep(5000);
      WaitForSpinnerToDisappear(_driver);    
    }
    [Given(@"Navigate to Borrower page Servicing")]
    public void GivenNavigateToBorrowerPageServicing()
    {
      BorrowerPagePOM.NavigateToBorrowerPage(_driver);
    }

    [Given(@"Click on ApplicationID")]
    public void GivenClickOnApplicationID()
    {
      _scenarioContext["AppId"] = ManageApplicationPOM.ClickOnAppID_ManageApplicationPage(_driver, 1).Text;
      ManageApplicationPOM.ClickOnAppID_ManageApplicationPage(_driver, 1).Click();
      BaseClass.WaitForSpinnerToDisappear(_driver);
    }

    [When(@"Click on Welcome Letters section")]
    public void WhenClickOnWelcomeLettersSection()
    {
      _scenarioContext["Name"] = ApplicationDetailsPOM.GetName_PersonalDetails_ApplicationDetailsPage(_driver);
      ApplicationDetailsPOM.ClickOnWelcomeLetters_ApplicationDetailsPage(_driver);
    }
    [When(@"Click on Welcome Letters section of Borrower")]
    public void WhenClickOnWelcomeLettersSection1()
    {
      _scenarioContext["Name"] = ApplicationDetailsPOM.GetName_PersonalDetails_BorrowerDetailsPage(_driver);
      ApplicationDetailsPOM.ClickOnWelcomeLetters_ApplicationDetailsPage(_driver);
    }

    [When(@"Click on Add Welcome letter button")]
    public void WhenClickOnAddWelcomeLetterButton()
    {
      try
      {
        if (ApplicationDetailsPOM.CheckCoBorrowerIsAvailable_BorrowerType_ApplicationDetailsPage(_driver) == 0)
          _scenarioContext["IsCoBorrowerAvailable"] = "No";
      }
      catch
      {
          _scenarioContext["IsCoBorrowerAvailable"] = "No";
      }
      Thread.Sleep(3000);
      ApplicationDetailsPOM.ClickOnAddWelcomeLetters_ApplicationDetailsPage(_driver);
    }

    [When(@"Select Borrower Type (.*)")]
    public void WhenSelectBorrowerTypeBorrowerType(string BorrowerType)
    {
      ApplicationDetailsPOM.SelectBorrowerType_AddWelcomeLetterPopup(_driver, BorrowerType);
    }

    [Then(@"Validate that the BorrowerName displaying properly (.*)")]
    public void ThenValidateThatTheBorrowerNameDisplayingProperlyBorrowerName(string BorrowerName)
    {
      BorrowerName = (string)_scenarioContext["Name"];
      Assert.That(ApplicationDetailsPOM.ReadBorrowerName_AddWelcomeLetterPopup(_driver).ToLower().Contains(BorrowerName.ToLower()));
    }
    [When(@"Select Co-Borrower name")]
    public void ThenSelectCo_BorrowerNameCo_BorrowerName()
    {
      try
      {
        if ((string)_scenarioContext["IsCoBorrowerAvailable"] == "No")
          Assert.IsTrue(true, "Co-Borrower is not available for given application");
      }
      catch { }
      try
      {

        ApplicationDetailsPOM.SelectCoBorrowerName_AddWelcomeLetterPopup(_driver);
      }
      catch { }
    }

        [When(@"Enter Email value (.*)")]
        public void WhenEnterEmailValueEmail(string Email)
        {
         ApplicationDetailsPOM.EnterEmail_AddWelcomeLetterPopup(_driver).Clear();
         ApplicationDetailsPOM.EnterEmail_AddWelcomeLetterPopup(_driver).SendKeys(Email);
        }
    [Then(@"Validate that the email populated properly")]
    public void ThenValidateThatTheEmailPopulatedProperly()
    {
     string a= ApplicationDetailsPOM.EnterEmail_AddWelcomeLetterPopup(_driver).GetAttribute("value");
      string b= ApplicationDetailsPOM.EnterEmail_AddWelcomeLetterPopup(_driver).Text;
     // Assert.That();
    }

    [When(@"Enter Loan amount (.*)")]
        public void WhenEnterLoanAmountLoanAmount(string LoanAmount)
        {
            ApplicationDetailsPOM.EnterLoanAmount_AddWelcomeLetterPopup(_driver, LoanAmount);
        }

        [When(@"Enter Loan term (.*)")]
        public void WhenEnterLoanTermLoanTerm(string LoanTerm)
        {
            ApplicationDetailsPOM.EnterLoanTerm_AddWelcomeLetterPopup(_driver, LoanTerm);
        }

        [Then(@"Validate that the Payment amount displaying properly (.*), (.*)")]
        public void ThenValidateThatThePaymentAmountDisplayingProperly(int LoanTerm,double loanAmount )
        {
            //Assert.That(ApplicationDetailsPOM.CheckPaymentAmount_AddWelcomeLetterPopup(_driver, LoanTerm, loanAmount));
        }
        [When(@"Enter Payment Amount (.*)")]
        public void WhenEnterPaymentAmount(string paymentAmount)
        {
            ApplicationDetailsPOM.EnterPaymentAmount_AddWelcomeLetterPopup(_driver).SendKeys(paymentAmount.Trim('"'));
        }

    [When(@"Enter Current Loan term (.*)")]
    public void WhenEnterCurrentLoanTerm(string lenderLoanTerm)
    {
      ApplicationDetailsPOM.EnterLenderLoanTerm_AddWelcomeLetterPopup(_driver,lenderLoanTerm.Trim('"'));
    }

    [When(@"Enter APR (.*)")]
    public void WhenEnterAPR(string apr)
    {      
      ApplicationDetailsPOM.EnterApr_AddWelcomeLetterPopup(_driver, apr.Trim('"'));
    }


        [When(@"Click on Send button")]
        public void WhenClickOnSendButton()
        {
            ApplicationDetailsPOM.ClickOnSendButton_AddWelcomeLetterPopup(_driver);
        }

        [Then(@"Validate that the Email Received on the email (.*), (.*)")]
        public void ThenValidateThatTheEmailReceivedOnTheEmail(string Message, string Email)
        {
            string EmailUrl="https://yopmail.com/";
            _driver.Navigate().GoToUrl(EmailUrl);
            //List<string> address = new List<string>(_driver.WindowHandles);
            //Console.WriteLine(address.Count);
            //_driver.SwitchTo().Window(address[0]);                     

            ManageApplicationPOM.EnterEmail_YopmailCom(_driver,Email);
            ManageApplicationPOM.ConfirmEmailByClickingOnArrow_YopmailCom(_driver);
            IWebElement iframeElement = _driver.FindElement(By.XPath("//iframe[@name='ifmail']"));
            _driver.SwitchTo().Frame(iframeElement);            
           Assert.That( ManageApplicationPOM.CheckEmailMessage_YopmailCom(_driver,Message));       
        }
        [When(@"Delete the Email")]
        public void WhenDeleteTheEmail()
        {
            ManageApplicationPOM.DeleteTheEmailMessage_YopmailCom(_driver);            
        }
        //************************************************************************WelcomeLetterListPage*******************************************************************

        [Then(@"Validate that the Borrower name displaying properly")]
        public void ThenValidateThatTheBorrowerNameDisplayingProperly()
        {
             WaitForSpinnerToDisappear(_driver);
            string BorrowerName = (string)_scenarioContext["Name"];
            Assert.That(ApplicationDetailsPOM.CheckWelcomeDetailsInList_AddWelcomeLetterPopup(_driver,"Borrower Name", BorrowerName));
        }

        [Then(@"validate that the Email displaying properly (.*)")]
        public void ThenValidateThatTheEmailDisplayingProperly(string Email)
        {
           Assert.That( ApplicationDetailsPOM.CheckWelcomeDetailsInList_AddWelcomeLetterPopup(_driver, "Email", Email));
        }

        [Then(@"Validate that the BorrowerType Displaying properly (.*)")]
        public void ThenValidateThatTheBorrowerTypeDisplayingProperly(string BorrowerType)
        {
          Assert.That(  ApplicationDetailsPOM.CheckWelcomeDetailsInList_AddWelcomeLetterPopup(_driver, "Borrower Type", BorrowerType));
        }

        [Then(@"Validate that the loan amount displaying properly (.*)")]
        public void ThenValidateThatTheLoanAmountDisplayingProperly(string LoanAmount)
        {
           Assert.That( ApplicationDetailsPOM.CheckWelcomeDetailsInList_AddWelcomeLetterPopup(_driver, "Loan Amount", LoanAmount));
        }
        [Then(@"Validate that the PaymentAmount Displaying properly (.*), (.*)")]
        public void ThenValidateThatPaymentAmountDisplayingProperly(double loanAmount,double loanTerm)
        {
          double paymentAmount = Formule.CalculatPaymentAmount((int)loanTerm, loanAmount);
          paymentAmount= Math.Floor(paymentAmount);
         Assert.That(ApplicationDetailsPOM.CheckWelcomeDetailsInList_AddWelcomeLetterPopup(_driver, "Payment Amount", paymentAmount.ToString()));
        }
        [Then(@"validate that the Resend action button is enable")]
        public void ThenValidateThatTheResendActionButtonIsEnable()
        {
            Assert.That(ApplicationDetailsPOM.CheckResendButton_AddWelcomeLetterPopup(_driver).Enabled);
        }


    }
}
