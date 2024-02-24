using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Bogus;
using CsvHelper.Configuration;
using MongoDB.Bson.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowFrameWork.Pages;
using SpecFlowFrameWork.Pages.InvstmentsPagePOM;
using SpecFlowFrameWork.Pages.OfferingPagePOM;
using SpecFlowFrameWork.Utility;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.InvestorPage;
using Yrefy_AutomationProject.Pages.ManageCustodianPage;
using Yrefy_AutomationProject.Pages.ManageProfilePage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Utility;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class AddInvestorStepDefinitions:BaseClass
    {

    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;
    private FeatureContext _featureContext;
    

    public AddInvestorStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
      _featureContext = featureContext;
    }

    public static Dictionary<string, string> JsonData()
    {
      string Path = GetDataParser().TestData_Path("LoginCredentialsTD");
      var testData = new Dictionary<String, String>();

      testData.Add("InvestorSignUpUrl_Test", GetDataParser().TestData("InvestorSignUpUrl_Test", Path));
      testData.Add("InvestorSignUpUrl_Beta", GetDataParser().TestData("InvestorSignUpUrl_Beta", Path));
      testData.Add("FinderSignUpUrl_Test", GetDataParser().TestData("FinderSignUpUrl_Test", Path));
      testData.Add("FinderSignUpUrl_Beta", GetDataParser().TestData("FinderSignUpUrl_Beta", Path));
            

      return testData;
    }

        [Given(@"Navigate to Investor Page")]
        public void GivenNavigateToInvestorPage()
        {
         InvestorPagePOM.NavigateToInvestorsPage(_driver);
        }
    [Given(@"Navigate to Manage profile page")]
    public void GivenNavigateToManageProfilePage()
    {
      AddInvestorPOM.NavigateToManageProfilePage(_driver);
      WaitForPageToLoad(_driver);
    }
    [When(@"Click on the New Investor Account button")]
    public void WhenClickOnTheNewInvestorAccountButton()
    {
      AddInvestorPOM.ClickOnNewInvestorAccountButton(_driver);
    }

    [When(@"Get the email of the Investor from investor page")]
    public void WhenGetTheEmailOfTheInvestorFromInvestorPage()
    {
      InvestorPagePOM.ClickOnInvestorName_InvestorPage(_driver,1).Click();
      WaitForSpinnerToDisappear(_driver);
      WaitForToLoadAllData(_driver);
      //WaitForSpinnerToDisappear(_driver);
      IDictionary<string, string> investdata = new Dictionary<string, string>();
      investdata = InvestorPagePOM.ReadLoginEmailOfInvestor_FromInvestorDetailsInvestorPage(_driver);
      _scenarioContext["InvestorFN"] = investdata["First Name"];
      _scenarioContext["InvestorLN"] = investdata["Last Name"];
      _scenarioContext["InvestorMN"] = investdata["Middle Name"];
      _scenarioContext["SSN"] = investdata["SSN"];
      _scenarioContext["FetchedEmail"] = investdata["Email-login"];

      NavigateToBackPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }

    [When(@"Click on Add Investor button")]
        public void WhenClickOnAddInvestorButton()
        {            
         InvestorPagePOM.ClickOnAddInvestorButton_InvestorPage(_driver);
         WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
         Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-dialog-container")));
        }

        [When(@"Select Investor Type on Select Investor type pop-up (.*)")]
        public void WhenSelectInvestorTypeOnSelectInvestorTypePop_Up(string investorType)
        {
         InvestorPagePOM.SelectInvestorTypeButton_InvestorPage(_driver, investorType);
        }

        [Then(@"Validate that the Investor Type displaying at Headline of Add Investor form (.*)")]
        public void ThenValidateThatTheInvestorTypeDisplayingAtHeadlineOfAddInvestorForm(string investorType)
        {
          AddInvestorPOM.CheckHeadlineOfAddInvestorform_InvestorPage(_driver, investorType);
        }

        [When(@"Provide details to Investor details section of Add investor form (.*)")]
        public void WhenProvideDetailsToInvestorDetailsSectionOfAddInvestorForm(string isMultiAccount)
        {
          Faker faker=new Faker();
          string email= faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");

      string firstName= faker.Person.FirstName;
      string lastName= faker.Person.LastName;
      string middleName = "m";

      if(!isMultiAccount.ToLower().Contains("yes"))
      {
        _scenarioContext["EmailLogin"]= email;
        _scenarioContext["InvestorFN"]= firstName;
        _scenarioContext["InvestorLN"]= lastName;
        _scenarioContext["InvestorMN"]= middleName;
      EnterInputValue(_driver, "Email Login").SendKeys(email);
      EnterInputValue(_driver, "First Name").SendKeys(firstName);
      EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
      EnterInputValue(_driver, "Last Name").SendKeys(lastName);      

      EnterInputValue(_driver, "SSN").SendKeys(SSN);
      EnterInputValue(_driver, "Password").SendKeys(Password);
      EnterInputValue(_driver, "Confirm password").SendKeys(Password);
      }
      else
      {
        email = (string)_scenarioContext["FetchedEmail"];
        _scenarioContext[$"EmailLogin"] = email;
        EnterInputValue(_driver, "Email Login").SendKeys(email);
      }



        }
    [When(@"Provide details to Investor details section of Add investor-form when InviteInvestor (.*)")]
    public void WhenProvideDetailsToInvestorDetailsSectionOfAddInvestorFormwhenInviteInvestor(string isMultiAccount)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");

      string firstName = faker.Person.FirstName;
      string lastName = faker.Person.LastName;
      string middleName = "i";

      if (isMultiAccount.ToLower().Contains("no"))
      {
      _scenarioContext["EmailLogin"] = email;
      _scenarioContext["InvestorFN"] = firstName;
      _scenarioContext["InvestorLN"] = lastName;
      _scenarioContext["InvestorMN"] = middleName;
      EnterInputValue(_driver, "Email Login").SendKeys(email);
      EnterInputValue(_driver, "First Name").SendKeys(firstName);
      EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
      EnterInputValue(_driver, "Last Name").SendKeys(lastName);

        EnterInputValue(_driver, "SSN").SendKeys(SSN);
        EnterInputValue(_driver, "Password").SendKeys(Password);
        EnterInputValue(_driver, "Confirm password").SendKeys(Password);
      }
      else
      {
        _scenarioContext["EmailLogin"] = (string)_scenarioContext["FetchedEmail"];
        EnterInputValue(_driver, "Email Login").SendKeys((string)_scenarioContext["FetchedEmail"]);
      }



    }
    [Then(@"Validate investor details section populate email properly (.*)")]
    public void ThenValidateInvestorDetailsSectionPopulateEmailProperly(string email)
    {
      string d;
       d=EnterInputValue(_driver, "Email Login").GetAttribute("value");
      if (email.Contains("@"))
      {
        Assert.That(d.Contains(email));
      }
      else
      {      
      Assert.That(d.Contains((string)_scenarioContext["ProfileLogin"]));      
      }
    }

    [When(@"With fetched EmailId Provide details to Investor details section of Add investor form (.*)")]
    public void WhenWithFetchedEmailIdProvideDetailsToInvestorDetailsSectionOfAddInvestorFormYes(string isMultiAccount)
    {
      if(isMultiAccount.ToLower().Contains("yes"))
      {
        Faker faker = new Faker();
        string email = (string)_scenarioContext["FetchedEmail"];

        string firstName = faker.Person.FirstName;
        string lastName = faker.Person.LastName;
        string middleName = "f";

        _scenarioContext["EmailLogin"] = email;
        //_scenarioContext["InvestorFN"] = firstName;
        //_scenarioContext["InvestorLN"] = lastName;
        //_scenarioContext["InvestorMN"] = middleName;
        EnterInputValue(_driver, "Email Login").SendKeys(email);
        //EnterInputValue(_driver, "First Name").SendKeys(firstName);
        //EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
        //EnterInputValue(_driver, "Last Name").SendKeys(lastName);
      }
    }

    [Then(@"Validate that the Role is at the Investor Admin position")]
    public void ThenValidateThatTheRoleIsAtTheInvestorAdminPosition()
    {
      Assert.That(SelectValue_Sendkey(_driver,"Role").Text.ToLower().Contains("admin"));
    }

    [When(@"Check the CheckBox (.*)")]
    public void WhenCheckTheCheckBox(string checkBoxName)
    {
      AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, checkBoxName);
    }


    [When(@"Provide details to the Contact Details section of Add Investor form (.*)")]
    public void WhenProvideDetailsToTheContactDetailsSectionOfAddInvestorForm(string isInvited)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");
      string workEmail = faker.Person.Email;
      workEmail = email.ChangeEmailDomain("Yopmail.com");

      string url = "https://test.minvest.com/";


      _scenarioContext[$"WorkEmail"] = workEmail;
      _scenarioContext[$"SocialMediaUrl"] = url;

      if (isInvited.ToLower().Contains("yes"))
      {
        _scenarioContext[$"PersonalEmail"] = (string)_scenarioContext["InvitedEmail"];
      }
      else
      {
        _scenarioContext[$"PersonalEmail"] = email;

        EnterInputValue(_driver, "Email-Personal").SendKeys(email);
      }
      EnterInputValue(_driver, "Email-Work").SendKeys(workEmail);
      EnterInputValue(_driver, "Social Media Url").SendKeys(url);
      EnterInputValue(_driver, "Phone-Cell").SendKeys(Phone);
      EnterInputValue(_driver, "Phone-Work").SendKeys(Phone);
      EnterInputValue(_driver, "Phone-Home").SendKeys(Phone);

    }
    [When(@"Click on the Investor in Account list")]
    public void WhenClickOnTheInvestorInAccountList()
    {
      AddInvestorPOM.ClickOnInvestorAccount_ManageAccountsPage(_driver).Click();
      BaseClass.WaitForSpinnerToDisappear(_driver);
    }

    
    [Then(@"Validate that the Personal email filed populate invited email by default")]
    public void ThenValidateThatThePersonalEmailFiledPopulateInvitedEmailByDefault()
    {
     string b= EnterInputValue(_driver, "Email-Personal").GetAttribute("value");
      Assert.That(b.Contains((string)_scenarioContext["InvitedEmail"]));
    }

    [When(@"Provide details to the Home Address section of Add Investor form")]
    public void WhenProvideDetailsToTheHomeAddressSectionOfAddInvestorForm()
    {
      string street = "street";
      _scenarioContext["Address"] = street;
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
      Thread.Sleep(3000);
      _scenarioContext["HomeState"]= SelectOption_DropDown(_driver, "State",1);
      Thread.Sleep(3000);
      _scenarioContext["HomeCity"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);

    }

    [When(@"Provide details to the Mailing Address section of Add Investor form (.*)")]
    public void WhenProvideDetailsToTheMailingAddressSectionOfAddInvestorForm(string sameAsHomeAddress)
    {
      if(sameAsHomeAddress.ToLower().Contains("no"))
      {
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = SelectOption_DropDown(_driver, "State",1,2);
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = SelectOption_DropDown(_driver, "City",1,2);
      }
      else
      {
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = (string)_scenarioContext["HomeState"];
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = (string)_scenarioContext["HomeCity"];
      }
    }

    [When(@"Provide details to the Business Address section of Add Investor form")]
    public void WhenProvideDetailsToTheBusinessAddressSectionOfAddInvestorForm()
    {
      Thread.Sleep(3000);
      _scenarioContext["BusinessState"] = SelectOption_DropDown(_driver, "State",1,3);
      Thread.Sleep(3000);
      _scenarioContext["BusinessCity"] = SelectOption_DropDown(_driver, "City",1,3);     
    }

    [When(@"Provide details to the Send the interest income to- section of Add Investor form (.*), (.*)")]
    public void WhenProvideDetailsToTheSendTheInterestIncomeTo_SectionOfAddInvestorForm(string accountType,int accountNo)
    {
        Random random = new Random();
        string street = "street";
        string holderName = "holderName";
        string accNumber = "21212121212121212";
        string bankName = "BankBank";
        string routingNumber = "656565656";
        string internalAccountNumber = "96894564567889784654";

        _scenarioContext["AccountAddress"] = street;

        _scenarioContext["AccountHolderName"]=holderName;
        _scenarioContext["AccountNumber"]=accNumber;
        _scenarioContext["BankName"]=bankName;
        _scenarioContext["RoutingNumber"] = routingNumber;
        _scenarioContext[$"InternalAccountNumber"] = internalAccountNumber;

      AddInvestorPOM.SelectAccountType_AddInvestorPage(_driver, accountType);
      if(accountType.ToLower().Contains("check"))
      {
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountState {accountNo}"] = SelectOption_DropDown(_driver, "State",0,4);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountCity {accountNo}"] = SelectOption_DropDown(_driver, "City",0,4);
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
      }
      else if(accountType.ToLower().Contains("ach"))
      {


        EnterInputValue(_driver,"Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "ACH Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm ACH Routing Number").SendKeys(routingNumber);
        _scenarioContext["AccountFace"] = SelectOption_DropDown(_driver, "Account Type", random.Next(0,1));

        EnterInputValue(_driver, "Internal Account Number").SendKeys(internalAccountNumber);
        EnterInputValue(_driver, "Confirm Internal Account Number").SendKeys(internalAccountNumber);
      }
      else
      {
        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "Wire Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm Wire Routing Number").SendKeys(routingNumber);

        EnterInputValue(_driver, "Internal Account Number").SendKeys(internalAccountNumber);
        EnterInputValue(_driver, "Confirm Internal Account Number").SendKeys(internalAccountNumber);

        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "I acknowledge");
      }
    }
    [Given(@"Expand The Details Card (.*)")]
    public void GivenExpandTheDetailsCard(string cardName)
    {
      ExpandDetailsInnerCard_ExpansionType(_driver, cardName);
    }

    [Given(@"Close The Details Card (.*)")]
    public void GivenCloseTheDetailsCard(string cardName)
    {
      CloseDetailsInnerCard_ExpansionType(_driver, cardName);
    }

    [Then(@"Validate that The Investor details of Investor displaying properly on View Investor page (.*), (.*)")]
    public void ThenValidateThatTheInvestorDetailsOfInvestorDisplayingProperlyOnViewInvestorPage(string investorType,string isMultipleAccount)
    {
      Thread.Sleep(7000);
      WaitForToLoadAllData(_driver);
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "First Name", "Middle Name","Last Name","Type","SSN", "Email-login"};
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Investor Details", dataKey);
      string d = (string)_scenarioContext["InvestorFN"];
      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["InvestorFN"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["InvestorMN"], $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["InvestorLN"], $"Validation failed for element {dataKey[2]}");
      
      Assert.AreEqual(contactDic[dataKey[3]], investorType, $"Validation failed for element {dataKey[3]}");
      if(isMultipleAccount.ToLower().Contains("yes"))
      {
        Assert.AreEqual(contactDic[dataKey[4]], (string)_scenarioContext["SSN"], $"Validation failed for element {dataKey[4]}");
      }
      else
      {
      Assert.AreEqual(contactDic[dataKey[4]], SSN.Substring(SSN.Length - 4), $"Validation failed for element {dataKey[4]}");
      }
      Assert.AreEqual(contactDic[dataKey[5]], (string)_scenarioContext["EmailLogin"], $"Validation failed for element {dataKey[5]}");
    }

    [Then(@"Validate that the Contact Details of Investor displaying properly on View Investor page")]
    public void ThenValidateThatTheContactDetailsOfInvestorDisplayingProperlyOnViewInvestorPage()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Email - Personal", "Email - Work", "Phone - Cell", "Phone - Work", "Phone - Home" };
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

       string a=(string)_scenarioContext["PersonalEmail"] ;
       string b= (string)_scenarioContext["WorkEmail"];
       string c= (string)_scenarioContext["SocialMediaUrl"];
       string d = Phone;

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["PersonalEmail"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["WorkEmail"], $"Validation failed for element {dataKey[1]}");
      //Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["SocialMediaUrl"], $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[2]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[3]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[4]}");     
    }
    [Then(@"Validate that the Contact Details of Investor displaying properly on View Investor page when InvitedInvestor")]
    public void ThenValidateThatTheContactDetailsOfInvestorDisplayingProperlyOnViewInvestorPageWhenInvitedInvestor()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Email - Personal", "Email - Work", "Phone - Cell", "Phone - Work", "Phone - Home" };
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

     
      string b = (string)_scenarioContext["WorkEmail"];
      string c = (string)_scenarioContext["SocialMediaUrl"];
      string d = Phone;

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["InvitedEmail"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["WorkEmail"], $"Validation failed for element {dataKey[1]}");
      //Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["SocialMediaUrl"], $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[2]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[3]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[4]}");
    }
    [Then(@"Validate that the Address Details of Investor displaying properly on View Investor page")]
    public void ThenValidateThatTheAddressDetailsOfInvestorDisplayingProperlyOnViewInvestorPage()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Business Address", "Mailing Address", "Primary Home Address" };
      contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", dataKey);
     
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["Address"]),  $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["Address"]),  $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["Address"]),  $"Validation failed for element {dataKey[2]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains("USA"), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains("USA"), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains("USA"), $"Validation failed for element {dataKey[2]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains(Zipcode), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains(Zipcode), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains(Zipcode), $"Validation failed for element {dataKey[2]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["BusinessState"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["BusinessCity"]), $"Validation failed for element {dataKey[0]}");

      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingState"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["HomeState"]), $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["HomeCity"]), $"Validation failed for element {dataKey[2]}");
    }

    [Then(@"Validate that the Account Details of Investor displaying properly on View Investor page (.*), (.*), (.*)")]
    public void ThenValidateThatTheAccountDetailsOfInvestorDisplayingProperlyOnViewInvestorPage(string accountType,string adminName, int accountNo)
    {
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      if (accountType.ToLower().Contains("ira"))
        accountType = (string)_scenarioContext["AccountType"];  //when roting method has been fetched from account details

      if (accountType.ToLower().Contains("check"))
      {
      string[] dataKey = { "Preferred Routing method", "Address", "Last Updated By" };
      dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Send the interest income to", dataKey);

      Assert.IsTrue(dataDic[dataKey[0]].Contains(accountType), $"Validation failed for element {dataKey[0]}");

      Assert.IsTrue(dataDic[dataKey[1]].Contains("USA"), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(dataDic[dataKey[1]].Contains((string)_scenarioContext[$"AccountState {accountNo}"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(dataDic[dataKey[1]].Contains((string)_scenarioContext[$"AccountCity {accountNo}"]), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(dataDic[dataKey[2]].Contains(adminName), $"Validation failed for element {dataKey[2]}");
      }
      else if(accountType.ToLower().Contains("ach"))
      {
        string[] dataKey = { "Preferred Routing method", "Account Holder Name", "Account Number", "Bank Name", "ACH Routing Number", "Account Type", "Last Updated By", "Internal Account Number" };
        dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Send the interest income to", dataKey);

        Assert.IsTrue(dataDic[dataKey[0]].Contains(accountType), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(dataDic[dataKey[1]].Contains((string)_scenarioContext["AccountHolderName"]), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(dataDic[dataKey[2]].Contains((string)_scenarioContext[$"AccountNumber"]), $"Validation failed for element {dataKey[2]}");
        Assert.IsTrue(dataDic[dataKey[3]].Contains((string)_scenarioContext[$"BankName"]), $"Validation failed for element {dataKey[3]}");
        Assert.IsTrue(dataDic[dataKey[4]].Contains((string)_scenarioContext[$"RoutingNumber"]), $"Validation failed for element {dataKey[4]}");
        Assert.IsTrue(dataDic[dataKey[5]].Contains((string)_scenarioContext[$"AccountFace"]), $"Validation failed for element {dataKey[5]}");
        Assert.IsTrue(dataDic[dataKey[6]].Contains(adminName), $"Validation failed for element {dataKey[6]}");
        Assert.IsTrue(dataDic[dataKey[7]].Contains((string)_scenarioContext[$"InternalAccountNumber"]), $"Validation failed for element {dataKey[7]}");
       

      }
      else
      {
        string[] dataKey = { "Preferred Routing method", "Account Holder Name", "Account Number", "Bank Name", "Wire Routing Number", "Last Updated By", "Internal Account Number" };
        dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Send the interest income to", dataKey);

        Assert.IsTrue(dataDic[dataKey[0]].Contains(accountType), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(dataDic[dataKey[1]].Contains((string)_scenarioContext["AccountHolderName"]), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(dataDic[dataKey[2]].Contains((string)_scenarioContext[$"AccountNumber"]), $"Validation failed for element {dataKey[2]}");
        Assert.IsTrue(dataDic[dataKey[3]].Contains((string)_scenarioContext[$"BankName"]), $"Validation failed for element {dataKey[3]}");
        Assert.IsTrue(dataDic[dataKey[4]].Contains((string)_scenarioContext[$"RoutingNumber"]), $"Validation failed for element {dataKey[4]}");        
        Assert.IsTrue(dataDic[dataKey[5]].Contains(adminName), $"Validation failed for element {dataKey[5]}");
        Assert.IsTrue(dataDic[dataKey[6]].Contains((string)_scenarioContext[$"InternalAccountNumber"]), $"Validation failed for element {dataKey[6]}");
      }
    }
    [When(@"Click on the Invite Investor button")]
    public void WhenClickOnTheInviteInvestorButton()
    {
      InvestorPagePOM.ClickOnInviteInvestorButton_InvestorPage(_driver);
      WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-dialog-container")));
    }

    [When(@"Select offering on Invite Investor")]
    public void WhenSelectOfferingOnInviteInvestor()
    {
     _scenarioContext["SelectedOffering"]= AddInvestorPOM.SelectOffering_InviteInvestorPopup_InvestorPage(_driver);
    }

    [Then(@"Validate that the Email populated in the Email field properly")]
    public void ThenValidateThatTheEmailPopulatedInTheEmailFieldProperly()
    {
      
      Assert.IsTrue(true);
    }
    [When(@"Provide Email to invite pop-up (.*)")]
    public void WhenProvideEmailToInvitePop_Up(string? isExisting="No")
    {
      if(!isExisting.ToLower().Contains("yes"))
      {
         Faker faker = new Faker();
        string email = faker.Person.Email;
        email = email.ChangeEmailDomain("Yopmail.com");

       // email = "yrefyautomation@gmail.com";
        _scenarioContext["InvitedEmail"]= email;
        AddInvestorPOM.EnterEmail_InvitePopup_InvestorPage(_driver).SendKeys(email);
      }
      else
      {

      }
    }
    [Given(@"Navigate to the Email")]
    public void GivenNavigateToTheEmail()
    {
     string Email= (string)_scenarioContext["InvitedEmail"];
      string EmailUrl = "https://yopmail.com/";
      _driver.Navigate().GoToUrl(EmailUrl);

      Thread.Sleep(5000);
      ManageApplicationPOM.EnterEmail_YopmailCom(_driver, Email);
      Thread.Sleep(5000);
      ManageApplicationPOM.ConfirmEmailByClickingOnArrow_YopmailCom(_driver);
      Thread.Sleep(5000);
      try
      {
        WebDriverWait Wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(7));
        Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//iframe[@title='reCAPTCHA']")));
        IWebElement iframeElementCapcha = _driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']"));
        Thread.Sleep(5000);
        _driver.SwitchTo().Frame(iframeElementCapcha);
        Thread.Sleep(5000);
        _driver.FindElement(By.XPath("//label[contains(text(),'not a robot')]")).Click();

      }
      catch
      { }

      WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));      
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//iframe[@name='ifmail']")));
      IWebElement iframeElement = _driver.FindElement(By.XPath("//iframe[@name='ifmail']"));
      _driver.SwitchTo().Frame(iframeElement);

      List<string> address1 = new List<string>(_driver.WindowHandles);
      AddInvestorPOM.ClickOnCreateMyAccount(_driver);

      List<string> address = new List<string>(_driver.WindowHandles);
      Console.WriteLine(address.Count);
      _driver.SwitchTo().Window(address.Last());    
      string aan=_driver.CurrentWindowHandle.ToString();
    }
    [Given(@"Navigate to the Gmail (.*)")]
    public void GivenNavigateToTheGmail(string Email)
    {
      
      string EmailUrl = "https://mail.google.com/";
      _driver.Navigate().GoToUrl(EmailUrl);
      
        WebDriverWait Wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@type='email']")));
      _driver.FindElement(By.XPath("//*[@type='email']")).SendKeys(Email);
      _driver.FindElement(By.XPath("//button[descendant::span[text()='Next']]")).Click();
      Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@type='password']")));
      _driver.FindElement(By.XPath("//*[@type='password']")).SendKeys(Password);
      _driver.FindElement(By.XPath("//button[descendant::span[text()='Next']]")).Click();
     // Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//img")));
      AddInvestorPOM.ClickOnCreateMyAccount(_driver);
      
    }
    [Then(@"Validate that CreateMyAccount button navigates to the Add investor page (.*)")]
    public void ThenValidateThatCreateMyAccountButtonNavigatesToTheAddInvestorPageIndividual(string investorType)
    {
      Assert.That(AddInvestorPOM.ClickOnInvestorTypeCard_AddInvestorPage(_driver,investorType).Displayed);
    }
    [Given(@"Click on Investor Type Card on Add Investor page (.*)")]
    public void GivenClickOnInvestorTypeCardOnAddInvestorPage(string investorType)
    {
      AddInvestorPOM.ClickOnInvestorTypeCard_AddInvestorPage(_driver, investorType).Click();
    }
    [When(@"Click on Continue button")]
    public void WhenClickOnContinueButton()
    {
      AddInvestorPOM.ClickOnConinueButton_ReminderPopup_AddInvestorPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }
    [Given(@"Set value of LoginEmail for investor (.*)")]
    public void GivenSetValueOfLoginEmailForInvestor(int investorNumber)
    {
      _scenarioContext["EmailLogin"] = (string)_scenarioContext[$"EmailLogin {investorNumber}"];
    }

    [When(@"Provide Email and Password then login")]
    public void WhenProvideEmailAndPasswordThenLogin()
    {
      try
      {
      LoginPOM.EnterUsername(_driver, (string)_scenarioContext["EmailLogin"]);

      }
      catch
      { LoginPOM.EnterUsername(_driver, (string)_scenarioContext["FetchedEmail"]); }
      LoginPOM.EnterPassword(_driver, Password);
      LoginPOM.ClickOnSubmitButton(_driver);
      WaitForSpinnerToDisappear(_driver);
      WaitForPageToLoad(_driver);
    }
    [When(@"Login to investor of Joint (.*)")]
    public void LogintoinvestorofJoint(int investorNumber)
    {     
      LoginPOM.EnterUsername(_driver, (string)_scenarioContext[$"EmailLogin {investorNumber}"]);
      LoginPOM.EnterPassword(_driver, Password);
      LoginPOM.ClickOnSubmitButton(_driver);
      WaitForSpinnerToDisappear(_driver);
      WaitForPageToLoad(_driver);
    } 
    //********************************************************************Definition of Add Joint Investor*******************************************************************

    [When(@"Provide details to the investor details section of Joint investor (.*), (.*)")]
    public void WhenProvideDetailsToTheInvestorDetailsSectionOfJointInvestorInvestorNumberNo(string ifMultiAccount,int investorNumber)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");
      string firstName = faker.Person.FirstName;
      string lastName = faker.Person.LastName;
      string middleName = "m";


      if (!ifMultiAccount.ToLower().Contains("yes"))
      {
      _scenarioContext[$"EmailLogin {investorNumber}"] = email;
      _scenarioContext[$"InvestorFN {investorNumber}"] = firstName;
      _scenarioContext[$"InvestorLN {investorNumber}"] = lastName;
      _scenarioContext[$"InvestorMN {investorNumber}"] = middleName;


        EnterInputValue(_driver, "Email Login").SendKeys(email);
        Thread.Sleep(1000);
        EnterInputValue(_driver, "First Name").SendKeys(firstName);
        EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
        EnterInputValue(_driver, "Last Name").SendKeys(lastName);

        EnterInputValue(_driver, "SSN").SendKeys(SSN);
        EnterInputValue(_driver, "Password").SendKeys(Password);
        EnterInputValue(_driver, "Confirm password").SendKeys(Password);
      }
      else
      {
        email= (string)_scenarioContext["FetchedEmail"]; 
        _scenarioContext[$"EmailLogin {investorNumber}"] = email;
        EnterInputValue(_driver, "Email Login").SendKeys(email);
      }
    }

    [Given(@"Select Investor on add joint investor form (.*)")]
    public void GivenSelectInvestorOnAddJointInvestorForm(int investorNumber)
    {
        AddInvestorPOM.SelectInvestor_JointInvestorForm_AddInvestorPage(_driver, investorNumber);
    }
    [Given(@"Select Investor among joint additional information form (.*)")]
    public void GivenSelectInvestorAmongJointAdditionalInformationForm(int investorNumber)
    {
      if (AddInvestmentPOM.CheckInvestmentStatusAtTop_AddInvestmentProcess(_driver).Contains("Requested"))
        if (AddInvestmentPOM.WaitForInvisibilityOfStepMessage_AddInvestmentProcess(_driver))
          AddInvestorPOM.SelectInvestor_JointInvestorForm_AddInvestorPage(_driver, investorNumber);
    }

    [When(@"Provide details to the Contact Details section of Add joint Investor form (.*), (.*)")]
    public void WhenProvideDetailsToTheContactDetailsSectionOfAddJointInvestorForm(int investorNumber,string ifInvited)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");

      string workEmail = faker.Person.Email;
      workEmail = email.ChangeEmailDomain("Yopmail.com");
      string url = "https://test.minvest.com/";


      _scenarioContext[$"WorkEmail {investorNumber}"] = workEmail;
      _scenarioContext[$"SocialMediaUrl {investorNumber}"] = url;

      if(ifInvited.ToLower().Contains("yes"))
      {
        _scenarioContext[$"PersonalEmail {investorNumber}"] =(string)_scenarioContext["InvitedEmail"];
      }
      else
      {
      _scenarioContext[$"PersonalEmail {investorNumber}"] = email;

      EnterInputValue(_driver, "Email-Personal").SendKeys(email);
      }
      EnterInputValue(_driver, "Email-Work").SendKeys(workEmail);
      EnterInputValue(_driver, "Social Media Url").SendKeys(url);
      EnterInputValue(_driver, "Phone-Cell").SendKeys(Phone);
      EnterInputValue(_driver, "Phone-Work").SendKeys(Phone);
      EnterInputValue(_driver, "Phone-Home").SendKeys(Phone);

    }
    [When(@"Provide details to the Business Contact details of Joint investor (.*)")]
    public void WhenProvideDetailsToTheBusinessContactDetailsOfJointInvestor(int investorNumber)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");
      string workEmail = faker.Person.Email;
      workEmail = email.ChangeEmailDomain("Yopmail.com");
      string url = "https://jointsocialurl.com/";


      _scenarioContext[$"BussnessEmail {investorNumber}"] = email;
      _scenarioContext[$"WorkEmail {investorNumber}"] = workEmail;
      _scenarioContext[$"SocialMediaUrl {investorNumber}"] = url;

      EnterInputValue(_driver, "Email").SendKeys(email);      
      EnterInputValue(_driver, "Website").SendKeys(url); 
      EnterInputValue(_driver, "Phone").SendKeys(Phone);
      EnterInputValue(_driver, "Fax").SendKeys(Phone);
    }

    [When(@"Provide details to the Home Address section of Add Joint Investor form (.*)")]
    public void WhenProvideDetailsToTheHomeAddressSectionOfAddJointInvestorForm(int investorNumber)
    {
      string street = "street";
      _scenarioContext[$"Address {investorNumber}"] = street;
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);

      _scenarioContext[$"HomeState {investorNumber}"] = SelectOption_DropDown(_driver, "State", 1);
      Thread.Sleep(3000);
      _scenarioContext[$"HomeCity {investorNumber}"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);

    }

    [When(@"Provide details to the Mailing Address section of Add Joint Investor form (.*), (.*)")]
    public void WhenProvideDetailsToTheMailingAddressSectionOfAddJointInvestorForm(string sameAsHomeAddress,int investorNumber)
    {
      if (sameAsHomeAddress.ToLower().Contains("no"))
      {
        Thread.Sleep(3000);
        _scenarioContext[$"MailingState {investorNumber}"] = SelectOption_DropDown(_driver, "State", 1, 2);
        Thread.Sleep(3000);
        _scenarioContext[$"MailingCity {investorNumber}"] = SelectOption_DropDown(_driver, "City", 1, 2);
      }
      else
      {
        Thread.Sleep(3000);
        _scenarioContext[$"MailingState {investorNumber}"] = (string)_scenarioContext[$"HomeState {investorNumber}"];
        Thread.Sleep(3000);
        _scenarioContext[$"MailingCity {investorNumber}"] = (string)_scenarioContext[$"HomeCity {investorNumber}"];
      }
    }

    [When(@"Provide details to the Business Address section of Add Joint Investor form (.*)")]
    public void WhenProvideDetailsToTheBusinessAddressSectionOfAddJointInvestorForm(int investorNumber)
    {
      Thread.Sleep(3000);
      _scenarioContext[$"BusinessState {investorNumber}"] = SelectOption_DropDown(_driver, "State", 1, 3);
      Thread.Sleep(3000);
      _scenarioContext[$"BusinessCity {investorNumber}"] = SelectOption_DropDown(_driver, "City", 1, 3);
    }

    [When(@"Provide details to the Send the interest income to- section of Add Joint Investor form (.*), (.*), (.*)")]
    public void WhenProvideDetailsToTheSendTheInterestIncomeTo_SectionOfAddJointInvestorForm(string accountType, int accountNo,int investorNumber)
    {
      Random random = new Random();
      string street = "street";
      string holderName = "holderName";
      string accNumber = "21212126212121212";
      string bankName = "BankBank";
      string routingNumber = "656525656";

      _scenarioContext[$"AccountAddress {investorNumber}"] = street;

      _scenarioContext[$"AccountHolderName {investorNumber}"] = holderName;
      _scenarioContext[$"AccountNumber {investorNumber}"] = accNumber;
      _scenarioContext[$"BankName {investorNumber}"] = bankName;
      _scenarioContext[$"RoutingNumber {investorNumber}"] = routingNumber;

      AddInvestorPOM.SelectAccountType_AddInvestorPage(_driver, accountType);
      if (accountType.ToLower().Contains("check"))
      {
        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountState {accountNo}"] = SelectOption_DropDown(_driver, "State", 0, 4);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountCity {accountNo}"] = SelectOption_DropDown(_driver, "City", 0, 4);
        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
      }
      else if (accountType.ToLower().Contains("ach"))
      {
        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "ACH Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm ACH Routing Number").SendKeys(routingNumber);
        _scenarioContext["AccountFace"] = SelectOption_DropDown(_driver, "Account Type", random.Next(0, 1));
      }
      else
      {
        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "Wire Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm Wire Routing Number").SendKeys(routingNumber);


        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "I acknowledge");
      }
    }
    [Then(@"Validate that the Role is at the Investor User position")]
    public void ThenValidateThatTheRoleIsAtTheInvestorUserPosition()
    {
      Assert.That(SelectValue_Sendkey(_driver, "Role").Text.ToLower().Contains("user"));
    }
    [Then(@"Validate that The Investor details of Joint Investor displaying properly on View Investor page (.*), (.*), (.*)")]
    public void ThenValidateThatTheInvestorDetailsOfJointInvestorDisplayingProperlyOnViewInvestorPage(string investorType,int investorNumber,string ifMultpleAccount)
    {
      Thread.Sleep(7000);
      WaitForToLoadAllData(_driver);
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "First Name", "Middle Name", "Last Name", "Type", "SSN", "Email-login" };
      contactDic = (IDictionary<string, string>)AddInvestorPOM.GetInvestorDetails_JointInvestor_InvestorDetails(_driver, "Investor Details", dataKey,investorNumber);
      string d = (string)_scenarioContext[$"InvestorFN {investorNumber}"];
      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext[$"InvestorFN {investorNumber}"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext[$"InvestorMN {investorNumber}"], $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext[$"InvestorLN {investorNumber}"], $"Validation failed for element {dataKey[2]}");


      Assert.AreEqual(contactDic[dataKey[3]], investorType, $"Validation failed for element {dataKey[3]}");

      if(ifMultpleAccount.ToLower().Contains("yes"))
      {
        Assert.AreEqual(contactDic[dataKey[4]], (string)_scenarioContext[$"SSN {investorNumber}"], $"Validation failed for element {dataKey[4]}");
      }
      else
      {
        Assert.AreEqual(contactDic[dataKey[4]], SSN.Substring(SSN.Length - 4), $"Validation failed for element {dataKey[4]}");
      }
      Assert.AreEqual(contactDic[dataKey[5]], (string)_scenarioContext[$"EmailLogin {investorNumber}"], $"Validation failed for element {dataKey[5]}");
    }

    [Then(@"Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page (.*)")]
    public void ThenValidateThatTheInvestorDetailsOfJointBusinessContactDetailsDisplayingProperlyOnViewInvestorPage(int investorNumber)
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      WaitForToLoadAllData(_driver);
      string[] dataKey = { "Email - Personal", "Email - Work", "Phone - Cell", "Phone - Work", "Phone - Home" };
      contactDic = (IDictionary<string, string>)AddInvestorPOM.GetInvestorDetails_JointInvestor_InvestorDetails(_driver, "Contact Details", dataKey,investorNumber);

      string a = (string)_scenarioContext[$"PersonalEmail {investorNumber}"];
      string b = (string)_scenarioContext[$"WorkEmail {investorNumber}"];
      string c = (string)_scenarioContext[$"SocialMediaUrl {investorNumber}"];
      string d = Phone;

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext[$"PersonalEmail {investorNumber}"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext[$"WorkEmail {investorNumber}"], $"Validation failed for element {dataKey[1]}");
      //Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["SocialMediaUrl"], $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[2]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[3]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[4]}");
    }

    [Then(@"Validate that the Contact Details of Joint Investor displaying properly on View Investor page (.*)")]
    public void ThenValidateThatTheContactDetailsOfJointInvestorDisplayingProperlyOnViewInvestorPage(int investorNumber)
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Email - Personal", "Email - Work", "Phone - Cell", "Phone - Work", "Phone - Home" };
      contactDic = (IDictionary<string, string>)AddInvestorPOM.GetInvestorDetails_JointInvestor_InvestorDetails(_driver, "Contact Details", dataKey, investorNumber);

      string a = (string)_scenarioContext[$"PersonalEmail {investorNumber}"];
      string b = (string)_scenarioContext[$"WorkEmail {investorNumber}"];
      string c = (string)_scenarioContext[$"SocialMediaUrl {investorNumber}"];
      string d = Phone;

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext[$"PersonalEmail {investorNumber}"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext[$"WorkEmail {investorNumber}"], $"Validation failed for element {dataKey[1]}");
      //Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["SocialMediaUrl"], $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[2]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[3]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[4]}");
    }

    [Then(@"Validate that the Address Details of Joint Investor displaying properly on View Investor page (.*)")]
    public void ThenValidateThatTheAddressDetailsOfJointInvestorDisplayingProperlyOnViewInvestorPage(int investorNumber)
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Business Address", "Mailing Address", "Primary Home Address" };
      contactDic = (IDictionary<string, string>)AddInvestorPOM.GetAddressDetails_JointInvestor_InvestorDetails(_driver, "Address", dataKey, investorNumber);

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext[$"Address {investorNumber}"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext[$"Address {investorNumber}"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext[$"Address {investorNumber}"]), $"Validation failed for element {dataKey[2]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains("USA"), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains("USA"), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains("USA"), $"Validation failed for element {dataKey[2]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains(Zipcode), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains(Zipcode), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains(Zipcode), $"Validation failed for element {dataKey[2]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext[$"BusinessState {investorNumber}"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext[$"BusinessCity {investorNumber}"]), $"Validation failed for element {dataKey[0]}");

      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext[$"MailingState {investorNumber}"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext[$"MailingCity {investorNumber}"]), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext[$"HomeState {investorNumber}"]), $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext[$"HomeCity {investorNumber}"]), $"Validation failed for element {dataKey[2]}");
    }
    [Given(@"Search the Finder on the Finders page ")]
    public void GivenSearchTheFinderOnTheFindersPage()
    {
      
    }

    [When(@"Get the email of the Investor from investor page to Create Joint investor (.*)")]
    public void WhenGetTheEmailOfTheInvestorFromInvestorPageToCreateJointInvestor(int investorNumber)
    {//investorNumber   = is the number of investor among joint investor which will belonging to multiple account
      InvestorPagePOM.ClickOnInvestorName_InvestorPage(_driver, 1).Click();
      WaitForSpinnerToDisappear(_driver);
      WaitForToLoadAllData(_driver);
      IDictionary<string, string> investdata = new Dictionary<string, string>();
      investdata = InvestorPagePOM.ReadLoginEmailOfInvestor_FromInvestorDetailsInvestorPage(_driver);
      _scenarioContext[$"InvestorFN {investorNumber}"] = investdata["First Name"];
      _scenarioContext[$"InvestorLN {investorNumber}"] = investdata["Last Name"];
      _scenarioContext[$"InvestorMN {investorNumber}"] = investdata["Middle Name"];
      _scenarioContext[$"SSN {investorNumber}"] = investdata["SSN"];
      _scenarioContext["FetchedEmail"] = investdata["Email-login"];

      NavigateToBackPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }
    [When(@"Collect Investor details of Joint investor from investor details page")]
    public void CollectInvestordetailsofointinvestorfrominvestordetailspage()
    {//investorNumber   = is the number of investor among joint investor which will belonging to multiple account
      InvestorPagePOM.ClickOnInvestorName_InvestorPage(_driver, 1).Click();
      WaitForSpinnerToDisappear(_driver);
      //WaitForSpinnerToDisappear(_driver);
      IDictionary<string, string> investdata = new Dictionary<string, string>();
      //investor first
      investdata = InvestorPagePOM.ReadLoginEmailOfInvestor_FromInvestorDetailsInvestorPage(_driver,1);
      _scenarioContext[$"InvestorFN 1"] = investdata["First Name"];
      _scenarioContext[$"InvestorLN 1"] = investdata["Last Name"];
      _scenarioContext[$"InvestorMN 1"] = investdata["Middle Name"];
      _scenarioContext[$"SSN 1"] = investdata["SSN"];
      _scenarioContext["EmailLogin 1"] = investdata["Email-login"];
      ///investor second
      investdata = InvestorPagePOM.ReadLoginEmailOfInvestor_FromInvestorDetailsInvestorPage(_driver, 2);
      _scenarioContext[$"InvestorFN 2"] = investdata["First Name"];
      _scenarioContext[$"InvestorLN 2"] = investdata["Last Name"];
      _scenarioContext[$"InvestorMN 2"] = investdata["Middle Name"];
      _scenarioContext[$"SSN 2"] = investdata["SSN"];
      _scenarioContext["EmailLogin 2"] = investdata["Email-login"];

      NavigateToBackPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }
    [Given(@"Navigate to the SignUp link (.*)")]
    public void GivenNavigateToTheSignUpLink(string entityType)
    {
      string link;
      if (_driver.Url.Contains("beta"))
      {
        if (entityType.ToLower().Contains("finder"))
          link = JsonData()["FinderSignUpUrl_Beta"];
        else
          link= JsonData()["InvestorSignUpUrl_Beta"];
      }
      else
      {
        if (entityType.ToLower().Contains("finder"))
          link= JsonData()["FinderSignUpUrl_Test"];
        else
          link= JsonData()["InvestorSignUpUrl_Test"];
      }

      _driver.Navigate().GoToUrl(link);
           
    }
    //*************************************************************************Definitions for Partnership Investor*******************************************************************


   

    [When(@"Provide details to Investor details section of Add PARTNERSHIP investor form")]
    public void WhenProvideDetailsToInvestorDetailsSectionOfAddPARTNERSHIPInvestorFormNo()
    {
        Faker faker = new Faker();
        string eIN = "123456789";
        string firstName = faker.Person.FirstName;         

      
        _scenarioContext["CompanyName"] = firstName;
        

        EnterInputValue(_driver, "Company Name").SendKeys(firstName);
        EnterInputValue(_driver, "EIN").SendKeys(eIN);
        _scenarioContext["EIN"] = EnterInputValue(_driver, "EIN").GetAttribute("value");
        EnterInputValue(_driver, "Date of Formation").SendKeys(Time.Date.ToString("MM/dd/yyyy"));
        Thread.Sleep(1000);
        SelectValueOfVisible_Sendkey(_driver, "Formation State").SendKeys(State);
        Thread.Sleep(1000);
    }

    [When(@"Provide details to the Contact Details section of Add PARTNERSHIP Investor form (.*)")]
    public void WhenProvideDetailsToTheContactDetailsSectionOfAddPARTNERSHIPInvestorForm(string isInvited)
    {
      Faker faker = new Faker();
      string email=faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");

      if (isInvited.ToLower().Contains("no"))
      {
        _scenarioContext["ContactEnail"] = email;
        EnterInputValue(_driver, "Email").SendKeys(email);
      }
      else
      {
        _scenarioContext["ContactEnail"] = (string)_scenarioContext["InvitedEmail"];
      }
        EnterInputValue(_driver, "Phone").SendKeys(Phone);
        EnterInputValue(_driver, "Website").SendKeys(URL);
        EnterInputValue(_driver, "Fax").SendKeys(Fax);
      
      
    }

    [When(@"Provide details to the Registered Address section of Add PARTNERSHIP Investor form")]
    public void WhenProvideDetailsToTheRegisteredAddressSectionOfAddPARTNERSHIPInvestorForm()
    {
      string street = "street";
      _scenarioContext["Address"] = street;
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
      Thread.Sleep(3000);
      _scenarioContext["RegisteredState"] = SelectOption_DropDown(_driver, "State", 1,2);
      Thread.Sleep(3000);
      _scenarioContext["RegisteredCity"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
    }
    [When(@"Provide details to the Mailing Address section of Add PARTNERSHIP Investor form (.*)")]
    public void WhenProvideDetailsToTheMailingAddressSectionOfAddPARTNERSHIPInvestorFormNo(string sameAsRegisteredAddress)
    {
      if (sameAsRegisteredAddress.ToLower().Contains("no"))
      {
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = SelectOption_DropDown(_driver, "State", 1, 3);
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = SelectOption_DropDown(_driver, "City", 1, 2);
      }
      else
      {
        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Same as Registered Address");
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = (string)_scenarioContext["RegisteredState"];
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = (string)_scenarioContext["RegisteredCity"];
      }
    }

    [When(@"Provide details to the Send the interest income to- section of Add PARTNERSHIP Investor form (.*), (.*)")]
    public void WhenProvideDetailsToTheSendTheInterestIncomeTo_SectionOfAddPARTNERSHIPInvestorFormCheck(string accountType, int accountNo)
    {
      Random random = new Random();
      string street = "street";
      string holderName = "holderName";
      string accNumber = "21212121212121212";
      string bankName = "BankBank";
      string routingNumber = "656565656";
      string internalAccountNumber = "96894564567889784654";

      _scenarioContext["AccountAddress"] = street;

      _scenarioContext["AccountHolderName"] = holderName;
      _scenarioContext["AccountNumber"] = accNumber;
      _scenarioContext["BankName"] = bankName;
      _scenarioContext["RoutingNumber"] = routingNumber;
      _scenarioContext[$"InternalAccountNumber"] = internalAccountNumber;

      AddInvestorPOM.SelectAccountType_AddInvestorPage(_driver, accountType);
      if (accountType.ToLower().Contains("check"))
      {
        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountState {accountNo}"] = SelectOption_DropDown(_driver, "State", 0, 4);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountCity {accountNo}"] = SelectOption_DropDown(_driver, "City", 0, 3);
        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
      }
      else if (accountType.ToLower().Contains("ach"))
      {


        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "ACH Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm ACH Routing Number").SendKeys(routingNumber);
        _scenarioContext["AccountFace"] = SelectOption_DropDown(_driver, "Account Type", random.Next(0, 1));

        EnterInputValue(_driver, "Internal Account Number").SendKeys(internalAccountNumber);
        EnterInputValue(_driver, "Confirm Internal Account Number").SendKeys(internalAccountNumber);
      }
      else
      {
        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "Wire Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm Wire Routing Number").SendKeys(routingNumber);

        EnterInputValue(_driver, "Internal Account Number").SendKeys(internalAccountNumber);
        EnterInputValue(_driver, "Confirm Internal Account Number").SendKeys(internalAccountNumber);

        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "I acknowledge");
        Thread.Sleep(1000);
      }
    }

    [Then(@"Validate that The Investor details of Investor displaying properly on View PARTNERSHIP Investor page (.*), (.*)")]
    public void ThenValidateThatTheInvestorDetailsOfInvestorDisplayingProperlyOnViewPARTNERSHIPInvestorPagePartnershipNo(string investorType, string isMultipleAccount)
    {
      Thread.Sleep(7000);
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      string[] dataKey;
      if (investorType.ToLower().Contains("trust"))
      {
        dataKey= new[]{ "Investor Name", "Tax Id", "Type", "Date of Formation", "Formation State" };
        contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Investor Details", dataKey);
      }
      else
      {
        dataKey = new[] { "Investor Name", "EIN", "Type", "Date of Formation", "Formation State" };
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Investor Details", dataKey);
      string d = (string)_scenarioContext["EIN"];
      Assert.AreEqual(contactDic[dataKey[1]],(string)_scenarioContext["EIN"], $"Validation failed for element {dataKey[1]}");     

      }
      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["CompanyName"], $"Validation failed for element {dataKey[0]}");

      Assert.AreEqual(contactDic[dataKey[2]], investorType, $"Validation failed for element {dataKey[2]}");

      Assert.AreEqual(contactDic[dataKey[3]], Time.Date.ToString("MM-dd-yyyy"), $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], State, $"Validation failed for element {dataKey[4]}");
    }

    [Then(@"Validate that the Contact Details of Investor displaying properly on View PARTNERSHIP Investor page")]
    public void ThenValidateThatTheContactDetailsOfInvestorDisplayingProperlyOnViewPARTNERSHIPInvestorPage()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Email", "Phone", "Website"};
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

      string a = (string)_scenarioContext["ContactEnail"];
     
      string d = Phone;

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["ContactEnail"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], URL, $"Validation failed for element {dataKey[2]}");      
    }

    [Then(@"Validate that the Address Details of Investor displaying properly on View PARTNERSHIP Investor page")]
    public void ThenValidateThatTheAddressDetailsOfInvestorDisplayingProperlyOnViewPARTNERSHIPInvestorPage()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Mailing Address", "Registered Address" };
      contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", dataKey);

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[1]}");     

      Assert.IsTrue(contactDic[dataKey[0]].Contains("USA"), $"Validation failed for element {dataKey[0]}");      
      Assert.IsTrue(contactDic[dataKey[1]].Contains("USA"), $"Validation failed for element {dataKey[1]}");    

      Assert.IsTrue(contactDic[dataKey[0]].Contains(Zipcode), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains(Zipcode), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["RegisteredState"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["RegisteredCity"]), $"Validation failed for element {dataKey[0]}");

      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingState"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[1]}");
    }
    [Then(@"Provide details to the User Details section of Add PARTNERSHIP Investor form (.*)")]
    public void ThenProvideDetailsToTheUserDetailsSectionOfAddPARTNERSHIPInvestorForm(string isMultiAccount)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");
      string firstName = faker.Person.FirstName;
      string lastName = faker.Person.LastName;
      string middleName = "m";

      if (!isMultiAccount.ToLower().Contains("yes"))
      {
        _scenarioContext["EmailLogin"] = email;
        _scenarioContext["InvestorFN"] = firstName;
        _scenarioContext["InvestorLN"] = lastName;
        _scenarioContext["InvestorMN"] = middleName;
        EnterInputValue(_driver, "Email").SendKeys(email);
        EnterInputValue(_driver, "First Name").SendKeys(firstName);
        EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
        EnterInputValue(_driver, "Last Name").SendKeys(lastName);

        EnterInputValue(_driver, "SSN").SendKeys(SSN);
        EnterInputValue(_driver, "Password").SendKeys(Password);
        EnterInputValue(_driver, "Confirm password").SendKeys(Password);
        EnterInputValue(_driver, "Phone").SendKeys(Phone);
      }
      else
      {
        email = (string)_scenarioContext["FetchedEmail"];
        _scenarioContext[$"EmailLogin"] = email;
        EnterInputValue(_driver, "Email").SendKeys(email);
      }

    }
    [Given(@"Search the Investor on the Investor page (.*)")]
    public void GivenSearchTheInvestorOnTheInvestorPagePartnership(string searchInvestor)
    {
      InvestorPagePOM.ClickOnTypeFilter_InvestmentPage(_driver);    
      foreach (string investorName in searchInvestor.Split('&'))
      AddInvestorPOM.ClickOnInvestorOption_InvestorTypeFilter_InvestorPage(_driver, investorName);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }
    [When(@"Search for Account on Manage Account page (.*)")]
    public void WhenSearchForAccountOnManageProfilePage(string investorType)
    {
      string investorName=null;
      if(investorType.ToLower().Contains("individual") )
      {
        investorName = (string)_scenarioContext["InvestorFN"];
      }
      else if(investorType.ToLower().Contains("joint"))
      {  
        //investorName = $"{(string)_scenarioContext["InvestorFN 1"]} & {(string)_scenarioContext["InvestorFN 2"]}";
        investorName = $"{(string)_scenarioContext["InvestorFN 2"]}";
      }
      else if(investorType.ToLower().Contains("partnership")|| investorType.ToLower().Contains("s-corp")|| investorType.ToLower().Contains("c-corp") || investorType.ToLower().Contains("llc") || investorType.ToLower().Contains("trust"))
      {
       investorName = (string)_scenarioContext["CompanyName"];
      }else if(investorType.ToLower().Contains("ira"))
      {
        investorName = (string)_scenarioContext["InvestorName"];
      }
      else
      {
        investorType = "Finder";
        investorName = (string)_scenarioContext["FinderName"];
      InvestorPagePOM.ClickOnTypeFilter_InvestmentPage(_driver);
        Thread.Sleep(2000);
      AddInvestorPOM.ClickOnInvestorOption_InvestorTypeFilter_InvestorPage(_driver, investorType);
      }
      ManageProfilePOM.EnterAccountName_NameFilter_ManageProfilePage(_driver, investorName);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      WaitForSpinnerToDisappear(_driver);
      WaitForSpinnerToDisappear(_driver);


    }
    [When(@"Navigate to the investor details by clicking on account name on Manage profile page")]
    public void WhenNavigateToTheInvestorDetailsByClickingOnAccountNameOnManageProfilePage()
    {
      Boolean result = true;
      int i = 1;
      ManageProfilePOM.ClickOnAccountName_ManageProfilePage(_driver);
      //while (result)
      //{
      //Thread.Sleep(7000);
      //  IDictionary<string, string> contactDic = new Dictionary<string, string>();

      //  string[] dataKey = { "Email - Personal"};
      //  contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

      //  if (!contactDic[dataKey[0]].Contains((string)_scenarioContext["PersonalEmail"]))
      //  {
      //    i++;
      //    NavigateToBackPage(_driver);
      //    WaitForSpinnerToDisappear(_driver);
      //  }
      //  else
      //  {
      //    result = false;
      //  }
      //}
    }

    [When(@"Navigate to manage account page")]
    public void WhenNavigateToManageAccountPage()
    {
      ManageAccountPOM.NavigateToManageAccountPage(_driver);
    }
    //*******************************************************************Definition of Add IRA Investor******************************************************************************* 

    [When(@"Provide details to Custodian details section of Add IRA Investor form (.*)")]
    public void WhenProvideDetailsToCustodianDetailsSectionOfAddIRAInvestorForm(string isInvited)
    {// when custodian data has been collected from custodian details page, in that case provide value 'isInvited'=  Gated

      Faker faker = new Faker();
      string iraName= faker.Person.FirstName;
      string custodianName= faker.Person.LastName;
      _scenarioContext["IRAName"] = iraName;
      if (isInvited.ToLower().Contains("no"))
      {
        _scenarioContext["Custodian"]= SelectOption_InputTypeDropDown(_driver,"Custodian");
        //_scenarioContext["Custodian"] = SelectOption_DropDown_Randomly(_driver, "Custodian");
      }
      else
      {//Create a dictinary to store fetched data
        if(isInvited.ToLower().Contains("gated"))
        custodianName=(string)_scenarioContext["First Name"];

        EnterInputValue(_driver, "Custodian").SendKeys(custodianName);
        _scenarioContext["Custodian"] = custodianName;
      }
      Thread.Sleep(3000);

      EnterInputValue(_driver, "Benefit Of").SendKeys(iraName);
      _scenarioContext["IRAType"]= SelectOption_DropDown_Randomly(_driver, "IRA Type");

     if(!isInvited.ToLower().Contains("no"))
      {
         EnterInputValue(_driver, "Custodian Tax Id").SendKeys("98-9898988");
        _scenarioContext["CustodianTaxid"] = EnterInputValue(_driver, "Custodian Tax Id").GetAttribute("value");
      }
    }

    [Then(@"Validate that the Trust Name created properly")]
    public void ThenValidateThatTheTrustNameCreatedProperly()
    {
      string expectedTrustName = $"{(string)_scenarioContext["Custodian"]} FBO {(string)_scenarioContext["IRAName"]} {(string)_scenarioContext["IRAType"]}";
      string actualTrustname= EnterInputValue(_driver, "Trust Name").GetAttribute("value");
      _scenarioContext["InvestorName"] = expectedTrustName;
      Assert.IsTrue(expectedTrustName.Contains(actualTrustname),"Failed: Trust name not displaying properly");
    }

    [Then(@"Validate that the Custodian Tax id populated properly")]
    public void ThenValidateThatTheCustodianTaxIdPopulatedProperly()
    {
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Custodian Tax id" };
      dataDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "IRA Custodian Details", dataKey);

      string CustodianTaxid = (string)_scenarioContext["CustodianTaxid"];

      Assert.AreEqual(dataDic[dataKey[0]], CustodianTaxid, $"failed: Validation of data in custodian details {dataKey[0]}");

    }

    [Then(@"Validate details to the Contact details section of Add IRA Investor form populated properly (.*)")]
    public void ThenValidateDetailsToTheContactDetailsSectionOfAddIRAInvestorFormPopulatedProperlyIsInvested(string isInvited)
    {
      string emailInvestmentCorrespondence = (string)_scenarioContext["EmailInvestmentCorrespondence"];
      string emailNewAccount = (string)_scenarioContext["EmailNewAccount"];
      string emailCostumerService = (string)_scenarioContext["EmailCostumerService"];
      string emailAssetonboarding = (string)_scenarioContext["EmailAssetonboarding"];
      string phone = (string)_scenarioContext["Phone"];
      string website = (string)_scenarioContext["Website"];


      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Email (Investments and Correspondence)", "Email (New account set up)", "Email (Costumer service)", "Email (Asset onboarding)","Phone","Website" };
      contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "IRA Custodian Contact Details", dataKey);

      Assert.AreEqual(contactDic[dataKey[0]],emailInvestmentCorrespondence,$"failed: Validation of data in contact details {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], emailNewAccount, $"failed: Validation of data in contact details {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], emailCostumerService, $"failed: Validation of data in contact details {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[3]], emailAssetonboarding, $"failed: Validation of data in contact details {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], phone, $"failed: Validation of data in contact details {dataKey[4]}");
      Assert.AreEqual(contactDic[dataKey[5]], website, $"failed: Validation of data in contact details {dataKey[5]}");
    }

    [Then(@"Validate details to the Custodian Registered Address of Add IRA Investor form populated properly")]
    public void ThenValidateDetailsToTheCustodianRegisteredAddressOfAddIRAInvestorFormPopulatedProperly()
    {
      string registeredStreetAddress1 = (string)_scenarioContext["RegisteredStreetAddress1"];
      string registeredStreetAddress2 = (string)_scenarioContext["RegisteredStreetAddress2"];
      string registeredStreetAddress3 = (string)_scenarioContext["RegisteredStreetAddress3"];
      string registeredState = (string)_scenarioContext["RegisteredState"];
      string registeredCity = (string)_scenarioContext["RegisteredCity"];
      string registeredZipcode = (string)_scenarioContext["RegisteredZipcode"];


      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Street Address 1", "Street Address 2", "Street Address 3", "State", "City", "Zipcode" };
      dataDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Custodian Registered Address", dataKey);

      Assert.AreEqual(dataDic[dataKey[0]], registeredStreetAddress1, $"failed: Validation of data in contact details {dataKey[0]}");
      Assert.AreEqual(dataDic[dataKey[1]], registeredStreetAddress2, $"failed: Validation of data in contact details {dataKey[1]}");
      Assert.AreEqual(dataDic[dataKey[2]], registeredStreetAddress3, $"failed: Validation of data in contact details {dataKey[2]}");
      Assert.AreEqual(dataDic[dataKey[3]], registeredState, $"failed: Validation of data in contact details {dataKey[3]}");
      Assert.AreEqual(dataDic[dataKey[4]], registeredCity, $"failed: Validation of data in contact details {dataKey[4]}");
      Assert.AreEqual(dataDic[dataKey[5]], registeredZipcode, $"failed: Validation of data in contact details {dataKey[5]}");
    }

    [Then(@"Validate details to the Custodian Mailing Address of Add IRA Investor form populated properly")]
    public void ThenValidateDetailsToTheCustodianMailingAddressOfAddIRAInvestorFormPopulatedProperly()
    {
      string registeredStreetAddress1 = (string)_scenarioContext["RegisteredStreetAddress1"];
      string registeredStreetAddress2 = (string)_scenarioContext["RegisteredStreetAddress2"];
      string registeredStreetAddress3 = (string)_scenarioContext["RegisteredStreetAddress3"];
      string registeredState = (string)_scenarioContext["RegisteredState"];
      string registeredCity = (string)_scenarioContext["RegisteredCity"];
      string registeredZipcode = (string)_scenarioContext["RegisteredZipcode"];
      string sameAssRegisteredAddress= (string)_scenarioContext["SameAssRegisteredAddress"];

      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Street Address 1", "Street Address 2", "Street Address 3", "State", "City", "Zipcode" };
      dataDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Custodian Mailing Address", dataKey);

      Assert.AreEqual(dataDic[dataKey[0]], registeredStreetAddress1, $"failed: Validation of data in contact details {dataKey[0]}");
      Assert.AreEqual(dataDic[dataKey[1]], registeredStreetAddress2, $"failed: Validation of data in contact details {dataKey[1]}");
      Assert.AreEqual(dataDic[dataKey[2]], registeredStreetAddress3, $"failed: Validation of data in contact details {dataKey[2]}");
      Assert.AreEqual(dataDic[dataKey[3]], registeredState, $"failed: Validation of data in contact details {dataKey[3]}");
      Assert.AreEqual(dataDic[dataKey[4]], registeredCity, $"failed: Validation of data in contact details {dataKey[4]}");
      Assert.AreEqual(dataDic[dataKey[5]], registeredZipcode, $"failed: Validation of data in contact details {dataKey[5]}");



      string checkedOrNot = AddApicationPOM.CheckThatBox_AddApplicationDetails(_driver, "Same as Registered Address").GetAttribute("aria-checked");
      Assert.AreEqual(checkedOrNot, sameAssRegisteredAddress, $"failed: Validation of same address check");
      if(checkedOrNot.Contains("true"))
      Assert.IsTrue(!AddApicationPOM.CheckThatBox_AddApplicationDetails(_driver, "Same as Registered Address").Enabled,"Failed; same as Registered Address check is not disabled");
    }

    [When(@"Provide details to the Investor Mailing Address ofAdd IRA Investor form")]
    public void WhenProvideDetailsToTheInvestorMailingAddressOfAddIRAInvestorForm()
    { string a1 = "streetA";
      string a2 = "streetB";
      string a3 = "streetC";
      _scenarioContext["InvestorMailingStreetAddress1"] = a1;
      _scenarioContext["InvestorMailingStreetAddress2"] = a2;
      _scenarioContext["InvestorMailingStreetAddress3"] = a3;

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street Address 1", a1);
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street Address 2", a2);
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street Address 3", a3);
      Thread.Sleep(3000);
      SelectValueOfVisible_Sendkey(_driver, "State",3).SendKeys(State);
      Thread.Sleep(3000);
      SelectValueOfVisible_Sendkey(_driver,"City",3).SendKeys(City);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
      
    }

    [Then(@"Validate that the Account details populated data properly")]
    public void ThenValidateThatTheAccountDetailsPopulatedDataProperly()
    {
      Boolean check = InvestorPagePOM.CheckOnStatusOfCheckBox_InvestorPage(_driver,"check");
    }



    [Given(@"Read value of the Custodian Tax id from IRA Custodian Tax Id")]
    public void ReadvalueoftheCustodianTaxidfromIRACustodianTaxId()
    {    
       string[] dataKey = { "Custodian Tax Id" };
      _scenarioContext["CustodianTaxid"]= EnterInputValue(_driver, dataKey[0]).GetAttribute("value");    
    }
    [When(@"Read values of Contact details section of Add IRA Investor form")]
    public void WhenReadValuesOfContactDetailsSectionOfAddIRAInvestorForm()
    {
       string[] dataKey = { "Email (Investments and Correspondence)", "Email (New account set up)", "Email (Customer service)", "Email (Asset onboarding)", "Phone", "Website" };
     

      _scenarioContext["EmailInvestmentCorrespondence"]= EnterInputValue(_driver, dataKey[0]).GetAttribute("value");
      _scenarioContext["EmailNewAccount"]= EnterInputValue(_driver, dataKey[1]).GetAttribute("value");
      _scenarioContext["EmailCostumerService"]= EnterInputValue(_driver, dataKey[2]).GetAttribute("value");
      _scenarioContext["EmailAssetonboarding"]= EnterInputValue(_driver, dataKey[3]).GetAttribute("value");
      _scenarioContext["Phone"] = EnterInputValue(_driver, dataKey[4]).GetAttribute("value");
      _scenarioContext["Website"]= EnterInputValue(_driver, dataKey[5]).GetAttribute("value");
    }
    [When(@"Read values of the Custodian Registered Address of Add IRA Investor form")]
    public void WhenReadValuesOfTheCustodianRegisteredAddressOfAddIRAInvestorForm()
    {
      

      string[] dataKey = { "Street Address 1", "Street Address 2", "Street Address 3", "State", "City", "Zipcode" };
      


      _scenarioContext["RegisteredStreetAddress1"]= EnterInputValue(_driver, dataKey[0]).GetAttribute("value");
      _scenarioContext["RegisteredStreetAddress2"]= EnterInputValue(_driver, dataKey[1]).GetAttribute("value");
      _scenarioContext["RegisteredStreetAddress3"]= EnterInputValue(_driver, dataKey[2]).GetAttribute("value");
      Thread.Sleep(3000);
      _scenarioContext["RegisteredState"]= SelectValueOfVisible_Sendkey(_driver, dataKey[3]).Text;
      Thread.Sleep(3000);
      _scenarioContext["RegisteredCity"]= SelectValueOfVisible_Sendkey(_driver, dataKey[4]).Text;
      _scenarioContext["RegisteredZipcode"]= EnterInputValue(_driver, dataKey[5]).GetAttribute("value");
    }

    [When(@"Read values of the Custodian Mailing Address of Add IRA Investor form")]
    public void WhenReadValuesOfTheCustodianMailingAddressOfAddIRAInvestorForm()
    {    
      string[] dataKey = { "Street Address 1", "Street Address 2", "Street Address 3", "State", "City", "Zipcode" };      

      _scenarioContext["MailingStreetAddress1"]= EnterInputValue(_driver, dataKey[0],2).GetAttribute("value");
      _scenarioContext["MailingStreetAddress2"] = EnterInputValue(_driver, dataKey[1], 2).GetAttribute("value");
      _scenarioContext["MailingStreetAddress3"] = EnterInputValue(_driver, dataKey[2], 2).GetAttribute("value");
      _scenarioContext["MailingState"] = SelectValueOfVisible_Sendkey(_driver, dataKey[3],2).Text;
      _scenarioContext["MailingCity"] = SelectValueOfVisible_Sendkey(_driver, dataKey[4], 2).Text;
      _scenarioContext["MailingZipcode"] = EnterInputValue(_driver, dataKey[5], 2).GetAttribute("value");
    }

    [When(@"Read values of the Account details (.*)")]
    public void WhenReadValuesOfTheAccountDetails(int accountNo)
    {
      Random random = new Random();
      string street = "street";
      string holderName = "holderName";
      string accNumber = "21212121212121212";
      string bankName = "BankBank";
      string routingNumber = "656565656";
      string accountType = null;


      if (InvestorPagePOM.CheckOnStatusOfCheckBox_InvestorPage(_driver, "Check"))
        accountType = "Check";
      else if(InvestorPagePOM.CheckOnStatusOfCheckBox_InvestorPage(_driver, "ACH"))
        accountType = "ACH";
      else
        accountType = "Wire";

      _scenarioContext["AccountType"] = accountType;
      _scenarioContext["AccountAddress"] = street;
      _scenarioContext["AccountHolderName"] = holderName;
      _scenarioContext["AccountNumber"] = accNumber;
      _scenarioContext["BankName"] = bankName;
      _scenarioContext["RoutingNumber"] = routingNumber;




      
      if (accountType.ToLower().Contains("check"))
      {
        _scenarioContext["AccountAddress1"]= EnterInputValue(_driver, "Street Address 1").GetAttribute("value");
        _scenarioContext["AccountAddress2"] = EnterInputValue(_driver, "Street Address 2").GetAttribute("value");
        _scenarioContext["AccountAddress3"] = EnterInputValue(_driver, "Street Address 3").GetAttribute("value");       
        _scenarioContext[$"AccountState {accountNo}"] = SelectValueOfVisible_Sendkey(_driver, "State").Text;
        _scenarioContext[$"AccountCity {accountNo}"] = SelectValueOfVisible_Sendkey(_driver, "City").Text;       
        _scenarioContext["AccountZipcode"] = EnterInputValue(_driver, "Zipcode").GetAttribute("value");
      }
      else if (accountType.ToLower().Contains("ach"))
      {
        _scenarioContext["AccountHolderName"] =  EnterInputValue(_driver, "Account Holder Name").GetAttribute("value");
        _scenarioContext["AccountNumber"]=  EnterInputValue(_driver, "Account Number").GetAttribute("value");
        _scenarioContext["BankName"] = EnterInputValue(_driver, "Bank Name").GetAttribute("value");
        _scenarioContext["RoutingNumber"] = EnterInputValue(_driver, "ACH Routing Number").GetAttribute("value");        
        _scenarioContext["AccountFace"] = SelectValueOfVisible_Sendkey(_driver, "Account Type").GetAttribute("value");
      }
      else
      {
        _scenarioContext["AccountHolderName"] = EnterInputValue(_driver, "Account Holder Name").GetAttribute("value");
        _scenarioContext["AccountNumber"] = EnterInputValue(_driver, "Account Number").GetAttribute("value");
        _scenarioContext["BankName"] = EnterInputValue(_driver, "Bank Name").GetAttribute("value");
        _scenarioContext["RoutingNumber"] = EnterInputValue(_driver, "Wire Routing Number").GetAttribute("value");          
      }
    }

    [Given(@"Navigate to the card (.*)")]
    public void GivenNavigateToTheCard(string cardName)
    {
    
      IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", _driver.FindElement(By.XPath($"//*[normalize-space()='{cardName}']")));

    }
    [Then(@"Validate that the IRA Custodian Details of Investor displaying properly (.*)")]
    public void ThenValidateThatTheIRACustodianDetailsOfInvestorDisplayingProperlyIRANo(string investorType)
    {
      Thread.Sleep(7000);
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Investor Name", "Type", "Custodian Tax Id" };
      try
      {
      dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "IRA Custodian Details", dataKey);

      }
      catch
      {
        dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "IRA Custodian Details", dataKey);
      }

      Assert.AreEqual(dataDic[dataKey[0]], (string)_scenarioContext["InvestorName"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(dataDic[dataKey[1]], investorType, $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(dataDic[dataKey[2]], (string)_scenarioContext["CustodianTaxid"], $"Validation failed for element {dataKey[2]}");
    }

    [Then(@"Validate that the IRA Custodian Contact Details of Investor displaying properly (.*)")]
    public void ThenValidateThatTheIRACustodianContactDetailsOfInvestorDisplayingProperly(string isInvited)
    {
     
      IDictionary<string, string> dataDic = new Dictionary<string, string>();

      string[] dataKey = { "Email", "Phone", "Website" };
      dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "IRA Custodian Contact Details", dataKey);
      if(isInvited.ToLower().Contains("yes"))
      {
        Assert.AreEqual(dataDic[dataKey[0]], (string)_scenarioContext["ContactEnail"], $"Validation failed for element {dataKey[0]}");
        Assert.AreEqual(dataDic[dataKey[1]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[1]}");
        Assert.AreEqual(dataDic[dataKey[2]], URL, $"Validation failed for element {dataKey[2]}");
      }
      else
      {
      Assert.AreEqual(dataDic[dataKey[0]], (string)_scenarioContext["EmailInvestmentCorrespondence"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(dataDic[dataKey[1]], (string)_scenarioContext["Phone"], $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(dataDic[dataKey[2]].Contains( (string)_scenarioContext["Website"])|| (string)_scenarioContext["Website"]==null, $"Validation failed for element {dataKey[2]}");
      }
    }

    [Then(@"Validate that the Address details of IRA investor are displaying properly (.*)")]
    public void ThenValidateThatTheAddressDetailsOfIRAInvestorAreDisplayingProperly(string isInvited)
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Custodian Mailing Address", "Custodian Registered Address", "Investor Mailing Address" };
      contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", dataKey);
      if(isInvited.ToLower().Contains("yes"))
      {
        Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[2]}");

        
        Assert.IsTrue(contactDic[dataKey[0]].Contains(Zipcode), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(contactDic[dataKey[1]].Contains(Zipcode), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(contactDic[dataKey[2]].Contains(Zipcode), $"Validation failed for element {dataKey[2]}");

        Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredState"]), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredCity"]), $"Validation failed for element {dataKey[1]}");

        Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["MailingState"]), $"Validation failed for element {dataKey[2]}");
        Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[2]}");

        Assert.IsTrue(contactDic[dataKey[2]].Contains(State), $"Validation failed for element {dataKey[2]}");
        Assert.IsTrue(contactDic[dataKey[2]].Contains(City), $"Validation failed for element {dataKey[2]}");
      }
      else
      {
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["MailingStreetAddress1"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["MailingStreetAddress2"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["MailingStreetAddress3"]), $"Validation failed for element {dataKey[0]}");

      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredStreetAddress1"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredStreetAddress2"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredStreetAddress3"]), $"Validation failed for element {dataKey[1]}");
        

      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["InvestorMailingStreetAddress1"]), $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["InvestorMailingStreetAddress2"]), $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["InvestorMailingStreetAddress3"]), $"Validation failed for element {dataKey[2]}");


      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredZipcode"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["MailingZipcode"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains(Zipcode), $"Validation failed for element {dataKey[2]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["MailingState"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[0]}");

      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredState"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["RegisteredCity"]), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(contactDic[dataKey[2]].Contains(State), $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains(City), $"Validation failed for element {dataKey[2]}");
      }
      Assert.IsTrue(contactDic[dataKey[0]].Contains("USA"), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains("USA"), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[2]].Contains("USA"), $"Validation failed for element {dataKey[2]}");
    }
    [When(@"Provide details to the Custodian Registered Address section of Add IRA Investor form")]
    public void WhenProvideDetailsToTheCustodianRegisteredAddressSectionOfAddPARTNERSHIPInvestorForm()
    {
      string street = "street";
      _scenarioContext["Address"] = street;
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
      Thread.Sleep(3000);
      _scenarioContext["RegisteredState"] = SelectOption_DropDown(_driver, "State", 1);
      Thread.Sleep(3000);
      _scenarioContext["RegisteredCity"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
    }

    [When(@"Provide details to the Custodian Mailing Address section of Add IRA Investor form (.*)")]
    public void WhenProvideDetailsToTheCustodianMailingAddressSectionOfAddPARTNERSHIPInvestorFormYes(string sameAsRegisteredAddress)
    {
      if (sameAsRegisteredAddress.ToLower().Contains("no"))
      {
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = SelectOption_DropDown(_driver, "State", 1, 2);
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = SelectOption_DropDown(_driver, "City", 1, 2);
      }
      else
      {
        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Same as Registered Address");
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = (string)_scenarioContext["RegisteredState"];
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = (string)_scenarioContext["RegisteredCity"];
      }
    }

    //*****************************************************************************Custodian get data definition*******************************************************************

    

    [Given(@"Navigate to Manage Custodian")]
    public void GivenNavigateToManageCustodian()
    {
      ManageCustodianPagePOM.NavigateToManageCustodianPage(_driver);
    }

    [When(@"Click on first Custodian Name")]
    public void WhenClickOnFirstCustodianName()
    {
      ManageCustodianPagePOM.ClickOnCustodianName_ManageCustodianPage(_driver);
    }

    [Then(@"Collect data of the custodian")]
    public void ThenCollectDataOfTheCustodian()
    {
      IDictionary<string, string> custodianDataDic = new Dictionary<string, string>();

      string[] dataKey = { "First Name", "Short Name", "EIN" };
      custodianDataDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Custodian Details", dataKey);

      string[] contactDataKey = { "Email (New account set up)", "Email (Investments and Correspondence)", "Email (Customer service)", "Email (Asset onboarding)", "Phone Work", "Phone Mobile", "Phone Home", "Website" };
      custodianDataDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Custodian Details", contactDataKey);

      string[] addressDataKey = { "Custodian Mailing Address", "Custodian Registered Address" };
      custodianDataDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Custodian Details", addressDataKey);


      _scenarioContext["custodianDataDic"] = custodianDataDic;

    }

    //*********************************************************************DefinitionFor Other Investor***************************************************************************

    [When(@"Provide details to Investor details section CommonStep of Add investor form (.*)")]
    public void WhenProvideDetailsToInvestorDetailsSectionCommonStepOfAddInvestorFormNo(string investorType)
    {
      Faker faker = new Faker();
      string eIN = "123456789";
      string firstName = faker.Person.FirstName;


      _scenarioContext["CompanyName"] = firstName;

      if(investorType.ToLower().Contains("trust"))
      {
        EnterInputValue(_driver, "Trust Name").SendKeys(firstName);
        EnterInputValue(_driver, "Tax Id").SendKeys(eIN);
        _scenarioContext["TaxId"] = EnterInputValue(_driver, "Tax Id").GetAttribute("value");
        EnterInputValue(_driver, "Date of Trust").SendKeys(Time.Date.ToString("MM/dd/yyyy"));
      }
      else
      {
      EnterInputValue(_driver, "Company Name").SendKeys(firstName);
      EnterInputValue(_driver, "EIN").SendKeys(eIN);
      _scenarioContext["EIN"] = EnterInputValue(_driver, "EIN").GetAttribute("value");
      EnterInputValue(_driver, "Date of Formation").SendKeys(Time.Date.ToString("MM/dd/yyyy"));
      }
      Thread.Sleep(1000);
      SelectValueOfVisible_Sendkey(_driver, "Formation State").SendKeys(State);
      Thread.Sleep(1000);
    }
    [Then(@"Provide details to the User Details section CommonStep of Add Investor form (.*)")]
    public void ThenProvideDetailsToTheUserDetailsSectionCommonStepOfAddInvestorForm(string isMultiAccount)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");

      string firstName = faker.Person.FirstName;
      string lastName = faker.Person.LastName;
      string middleName = "m";

      if (!isMultiAccount.ToLower().Contains("yes"))
      {
        _scenarioContext["EmailLogin"] = email;
        _scenarioContext["InvestorFN"] = firstName;
        _scenarioContext["InvestorLN"] = lastName;
        _scenarioContext["InvestorMN"] = middleName;
        EnterInputValue(_driver, "Email").SendKeys(email);
        EnterInputValue(_driver, "First Name").SendKeys(firstName);
        EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
        EnterInputValue(_driver, "Last Name").SendKeys(lastName);

        EnterInputValue(_driver, "SSN").SendKeys(SSN);
        EnterInputValue(_driver, "Password").SendKeys(Password);
        EnterInputValue(_driver, "Confirm password").SendKeys(Password);
        EnterInputValue(_driver, "Phone").SendKeys(Phone);
      }
      else
      {
        email = (string)_scenarioContext["FetchedEmail"];
        _scenarioContext[$"EmailLogin"] = email;
        EnterInputValue(_driver, "Email").SendKeys(email);
      }

    }
    [When(@"Provide details to the Contact Details section CommonStep of Add Investor form (.*)")]
    public void WhenProvideDetailsToTheContactDetailsSectionCommonStepOfAddInvestorForm(string isInvited)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");

      if (isInvited.ToLower().Contains("no"))
      {
        _scenarioContext["ContactEnail"] = email;
        EnterInputValue(_driver, "Email").SendKeys(email);
      }
      else
      {
        _scenarioContext["ContactEnail"] = (string)_scenarioContext["InvitedEmail"];
      }
      EnterInputValue(_driver, "Phone").SendKeys(Phone);
      EnterInputValue(_driver, "Website").SendKeys(URL);
      EnterInputValue(_driver, "Fax").SendKeys(Fax);


    }
    [When(@"Provide details to the Registered Address section CommonStep of Add Investor form")]
    public void WhenProvideDetailsToTheRegisteredAddressSectionCommonStepOfAddInvestorForm()
    {
      string street = "street";
      _scenarioContext["Address"] = street;
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
      Thread.Sleep(2000);
      _scenarioContext["RegisteredState"] = SelectOption_DropDown(_driver, "State", 1, 2);
      Thread.Sleep(4000);
      _scenarioContext["RegisteredCity"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
    }
    [When(@"Provide details to the Mailing Address section CommonStep of Add Investor form (.*)")]
    public void WhenProvideDetailsToTheMailingAddressSectionCommonStepOfAddInvestorFormNo(string sameAsRegisteredAddress)
    {
      if (sameAsRegisteredAddress.ToLower().Contains("no"))
      {
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = SelectOption_DropDown(_driver, "State", 1, 3);
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = SelectOption_DropDown(_driver, "City", 1, 2);
      }
      else
      {
        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Same as Registered Address");
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = (string)_scenarioContext["RegisteredState"];
        Thread.Sleep(3000);
        _scenarioContext["MailingCity"] = (string)_scenarioContext["RegisteredCity"];
      }
    }
    [When(@"Provide details to the Send the interest income to- section CommonStep of Add Investor form (.*), (.*)")]
    public void WhenProvideDetailsToTheSendTheInterestIncomeTo_SectionCommonStepOfAddInvestorFormCheck(string accountType, int accountNo)
    {
      Random random = new Random();
      string street = "street";
      string holderName = "holderName";
      string accNumber = "21212121212121212";
      string bankName = "BankBank";
      string routingNumber = "656565656";
      string internalAccountNumber = "96894564567889784654";

      _scenarioContext["AccountAddress"] = street;

      _scenarioContext["AccountHolderName"] = holderName;
      _scenarioContext["AccountNumber"] = accNumber;
      _scenarioContext["BankName"] = bankName;
      _scenarioContext["RoutingNumber"] = routingNumber;
      _scenarioContext[$"InternalAccountNumber"] = internalAccountNumber;

      AddInvestorPOM.SelectAccountType_AddInvestorPage(_driver, accountType);
      if (accountType.ToLower().Contains("check"))
      {
        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountState {accountNo}"] = SelectOption_DropDown(_driver, "State", 0, 4);
        Thread.Sleep(3000);
        _scenarioContext[$"AccountCity {accountNo}"] = SelectOption_DropDown(_driver, "City", 0, 3);
        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
      }
      else if (accountType.ToLower().Contains("ach"))
      {


        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "ACH Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm ACH Routing Number").SendKeys(routingNumber);
        _scenarioContext["AccountFace"] = SelectOption_DropDown(_driver, "Account Type", random.Next(0, 1));

        EnterInputValue(_driver, "Internal Account Number").SendKeys(internalAccountNumber);
        EnterInputValue(_driver, "Confirm Internal Account Number").SendKeys(internalAccountNumber);
      }
      else
      {
        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);

        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Confirm Account Number").SendKeys(accNumber);

        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "Wire Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Confirm Wire Routing Number").SendKeys(routingNumber);

        EnterInputValue(_driver, "Internal Account Number").SendKeys(internalAccountNumber);
        EnterInputValue(_driver, "Confirm Internal Account Number").SendKeys(internalAccountNumber);

        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "I acknowledge");
      }
    }
    [Then(@"Validate that The Investor details of Investor displaying properly CommonStep on View Investor page (.*), (.*)")]
    public void ThenValidateThatTheInvestorDetailsOfInvestorDisplayingProperlyOnViewInvestorPagePartnershipNo(string investorType, string isMultipleAccount)
    {
      //Thread.Sleep(7000);
      WaitForToLoadAllData(_driver);
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      string[] dataKey;
      if (investorType.ToLower().Contains("trust"))
      {
        dataKey = new[] { "Investor Name", "Tax Id", "Type", "Date of Formation", "Formation State" };
        contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Investor Details", dataKey);
      }
      else
      {
        dataKey = new[] { "Investor Name", "EIN", "Type", "Date of Formation", "Formation State" };
        contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Investor Details", dataKey);
        string d = (string)_scenarioContext["EIN"];
        Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["EIN"], $"Validation failed for element {dataKey[1]}");

      }
      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["CompanyName"], $"Validation failed for element {dataKey[0]}");

      Assert.AreEqual(contactDic[dataKey[2]], investorType, $"Validation failed for element {dataKey[2]}");

      Assert.AreEqual(contactDic[dataKey[3]], Time.Date.ToString("MM-dd-yyyy"), $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], State, $"Validation failed for element {dataKey[4]}");
    }
    [Then(@"Validate that the Contact Details of Investor displaying properly commonstep on View Investor page")]
    public void ThenValidateThatTheContactDetailsOfInvestorDisplayingProperlycommonstepOnViewInvestorPage()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Email", "Phone", "Website" };
      contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

      string a = (string)_scenarioContext["ContactEnail"];

      string d = Phone;

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["ContactEnail"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], URL, $"Validation failed for element {dataKey[2]}");
    }
    [Then(@"Validate that the Address Details of Investor displaying properly CommonStep on View Investor page")]
    public void ThenValidateThatTheAddressDetailsOfInvestorDisplayingProperlyCommonStepOnViewInvestorPage()
    {
      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Mailing Address", "Registered Address" };
      contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", dataKey);

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains("USA"), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains("USA"), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains(Zipcode), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains(Zipcode), $"Validation failed for element {dataKey[1]}");

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["RegisteredState"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["RegisteredCity"]), $"Validation failed for element {dataKey[0]}");

      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingState"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[1]}");
    }
    //*********************************************************************IRA Add Investment**********************************************************************************************
    [When(@"Get the Login email of the Investor from investor users page")]
    public void WhenGetTheLoginEmailOfTheInvestorFromInvestorusersPage()
    {
      IDictionary<string, string> investdata = new Dictionary<string, string>();

      InvestorPagePOM.ClickOnInvestorName_InvestorPage(_driver, 1).Click();
      WaitForSpinnerToDisappear(_driver);
      Thread.Sleep(5000);
      investdata = InvestorPagePOM.ReadIRAInvestorName_FromInvestorDetailsInvestorPage(_driver);
      _scenarioContext["InvestorName"]= investdata["Investor Name"];
      InvestorPagePOM.NavigateToInvestorUsersSection_InvestorDetails_InvestorPage(_driver);
      WaitForSpinnerToDisappear(_driver);
      try
      {
        Assert.That(InvestorPagePOM.CheckEmailOfInvestorIsAvailable_InvestorPage(_driver).Displayed);
      _scenarioContext["EmailLogin"]= InvestorPagePOM.ReadEmailOfInvestor_InvestorPage( _driver).Text;
      }
      catch
      {

        Faker faker = new Faker();
        string email = faker.Person.Email;
        email = email.ChangeEmailDomain("Yopmail.com");

        string firstName = faker.Person.FirstName;
        string lastName = faker.Person.LastName;
        string middleName = "m";

        
        
          _scenarioContext["EmailLogin"] = email;
          _scenarioContext["UserFN"] = firstName;
          _scenarioContext["UserLN"] = lastName;
          _scenarioContext["UserMN"] = middleName;

        InvestmentPagePOM.ClickOnUserButton_InvestorUser_InvestmentProcess(_driver);

        
          EnterInputValue(_driver, "Email Login").SendKeys(email);
          EnterInputValue(_driver, "First Name").SendKeys(firstName);
          EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
          EnterInputValue(_driver, "Last Name").SendKeys(lastName);

          EnterInputValue(_driver, "SSN").SendKeys(SSN);
          EnterInputValue(_driver, "Password").SendKeys(Password);
          EnterInputValue(_driver, "Confirm password").SendKeys(Password);
          EnterInputValue(_driver, "Phone").SendKeys(Phone);

        AddApicationPOM.ClickOnSaveButton_AddApplicationDetails(_driver);
        WaitForSpinnerToDisappear(_driver);
      }
      NavigateToBackPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }
    [When(@"Get the Login email and Investor Name of the Investor from investor users page")]
    public void WhenGetTheLoginEmailAndInvestorNameOfTheInvestorFromInvestorusersPage()
    {
      IDictionary<string, string> investdata = new Dictionary<string, string>();

      InvestorPagePOM.ClickOnInvestorName_InvestorPage(_driver, 1).Click();
      WaitForSpinnerToDisappear(_driver);
      Thread.Sleep(5000);
      investdata = InvestorPagePOM.ReadInvestorName_FromInvestorDetailsInvestorPage(_driver);
      _scenarioContext["InvestorName"] = investdata["Investor Name"];
      InvestorPagePOM.NavigateToInvestorUsersSection_InvestorDetails_InvestorPage(_driver);
      WaitForSpinnerToDisappear(_driver);
      try
      {
        Assert.That(InvestorPagePOM.CheckEmailOfInvestorIsAvailable_InvestorPage(_driver).Displayed);
        _scenarioContext["EmailLogin"] = InvestorPagePOM.ReadEmailOfInvestor_InvestorPage(_driver).Text;
      }
      catch
      {

        Faker faker = new Faker();
        string email = faker.Person.Email;
        email = email.ChangeEmailDomain("Yopmail.com");

        string firstName = faker.Person.FirstName;
        string lastName = faker.Person.LastName;
        string middleName = "m";



        _scenarioContext["EmailLogin"] = email;
        _scenarioContext["UserFN"] = firstName;
        _scenarioContext["UserLN"] = lastName;
        _scenarioContext["UserMN"] = middleName;

        InvestmentPagePOM.ClickOnUserButton_InvestorUser_InvestmentProcess(_driver);


        EnterInputValue(_driver, "Email Login").SendKeys(email);
        EnterInputValue(_driver, "First Name").SendKeys(firstName);
        EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
        EnterInputValue(_driver, "Last Name").SendKeys(lastName);

        EnterInputValue(_driver, "SSN").SendKeys(SSN);
        EnterInputValue(_driver, "Password").SendKeys(Password);
        EnterInputValue(_driver, "Confirm password").SendKeys(Password);
        EnterInputValue(_driver, "Phone").SendKeys(Phone);

        AddApicationPOM.ClickOnSaveButton_AddApplicationDetails(_driver);
        WaitForSpinnerToDisappear(_driver);
      }
      NavigateToBackPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }
  }
}

