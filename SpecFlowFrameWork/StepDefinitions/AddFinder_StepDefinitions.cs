using AventStack.ExtentReports;
using Bogus;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.FedCm;
using OpenQA.Selenium.Support.UI;
using SpecFlowFrameWork.Pages.InvstmentsPagePOM;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.FindersPage;
using Yrefy_AutomationProject.Pages.InvestorPage;
using Yrefy_AutomationProject.Pages.ManageProfilePage;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class AddFinder_StepDefinitions:BaseClass
    {
    private readonly IWebDriver _driver;
    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public AddFinder_StepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;
    }
        [Given(@"Navigate to the Manage Finders page")]
        public void GivenNavigateToTheManageFindersPage()
        {
          FinderPagePOM.NavigateToFindersPage(_driver);
        }

        [When(@"Click on the Add Finder button")]
        public void WhenClickOnTheAddFinderButton()
        {
         FinderPagePOM.ClickOnTheAddFinderButton(_driver);
        }
    [Given(@"Search the Finder on the Finders page (.*)")]
    public void GivenSearchTheFinderOnTheFindersPage(string finderNames)
    {
      InvestorPagePOM.ClickOnTypeFilter_InvestmentPage(_driver);
      foreach (string finderName in finderNames.Split('&'))
      AddInvestorPOM.ClickOnInvestorOption_InvestorTypeFilter_InvestorPage(_driver, finderName);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }

    [Given(@"Get LoginEmail of Existing Finder from finders page")]
    public void GivenGetLoginEmailOfExistingFinderFromFindersPage()
    {      
      InvestorPagePOM.ClickOnInvestorName_InvestorPage(_driver, 1).Click();
      WaitForSpinnerToDisappear(_driver);
      WaitForSpinnerToDisappear(_driver);
      IDictionary<string, string> investdata = new Dictionary<string, string>();
      investdata = FinderPagePOM.ReadLoginEmailOfInvestor_FromFinderDetailsFinderPage(_driver);
      _scenarioContext[$"FinderName"] = investdata["Name"];
      _scenarioContext[$"SSN"] = investdata["SSN (Last 4 Digits)"];
      _scenarioContext[$"Type"] = investdata["Type"];     
      _scenarioContext["FetchedEmail"] = investdata["Email-login"];

      NavigateToBackPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }

        [When(@"Provide details to the finder details section of Add finder form (.*), (.*), (.*)")]
        public void WhenProvideDetailsToTheFinderDetailsSectionOfAddFinderForm(string isMultiAccount,string finderType,string isInvited)
        {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");
      string firstName = faker.Person.FirstName;
      string lastName = faker.Person.LastName;
      string middleName = "m";
      string eIN = "945632196";

      if(isInvited.ToLower().Contains("no"))
      SelectValue_Sendkey(_driver, "Type").SendKeys(finderType);

         Thread.Sleep(1000);

        if(finderType.ToLower().Contains("mria"))
        {
           if (!isMultiAccount.ToLower().Contains("yes"))
           {
          _scenarioContext["CompanyName"] = firstName;
          EnterInputValue(_driver, "EIN").SendKeys(eIN);
          EnterInputValue(_driver, "Company Name").SendKeys(firstName);
          _scenarioContext["EIN"] = EnterInputValue(_driver, "EIN").GetAttribute("value");
          EnterInputValue(_driver, "Date of Incorporation").SendKeys(Time.Date.ToString("MM/dd/yyyy"));
          SelectValueOfVisible_Sendkey(_driver, "Incorporation State").SendKeys(State);
           }
           else
            {
          _scenarioContext["CompanyName"] = firstName;
          _scenarioContext["FinderName"] = firstName;
          EnterInputValue(_driver, "EIN").SendKeys(eIN);
          EnterInputValue(_driver, "Company Name").SendKeys(firstName);
          _scenarioContext["EIN"] = EnterInputValue(_driver, "EIN").GetAttribute("value");
          EnterInputValue(_driver, "Date of Incorporation").SendKeys(Time.Date.ToString("MM/dd/yyyy"));
          SelectValueOfVisible_Sendkey(_driver, "Incorporation State").SendKeys(State);
          //************************
          AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Check this checkbox if user belongs to multiple accounts.");
          email = (string)_scenarioContext["FetchedEmail"];
          _scenarioContext[$"EmailLogin"] = email;
          EnterInputValue(_driver, "Email Login").SendKeys(email);
            }
      }
        else if(finderType.ToLower()=="ria")
        {

             if (!isMultiAccount.ToLower().Contains("yes"))
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
              AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Check this checkbox if user belongs to multiple accounts.");
              email = (string)_scenarioContext["FetchedEmail"];
             _scenarioContext[$"EmailLogin"] = email;
              EnterInputValue(_driver, "Email Login").SendKeys(email);
            }
        }
        else //if(finderType.ToLower().Contains("bd"))
        {
          if (!isMultiAccount.ToLower().Contains("yes"))
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
          AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Check this checkbox if user belongs to multiple accounts.");
          email = (string)_scenarioContext["FetchedEmail"];
          _scenarioContext[$"EmailLogin"] = email;
          EnterInputValue(_driver, "Email Login").SendKeys(email);
          }
        }

        }

        [When(@"Provide details to the Contact details section of Add finder form (.*), (.*)")]
        public void WhenProvideDetailsToTheContactDetailsSectionOfAddFinderForm(string isInvited,string finderType)
        {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");
      string personalEmail = faker.Person.Email;
      personalEmail = email.ChangeEmailDomain("Yopmail.com");
      string url=faker.Person.Website;

        if(finderType.ToLower().Contains("mria"))
        {
           if(isInvited.ToLower().Contains("yes"))
           {
          _scenarioContext[$"Email"] = (string)_scenarioContext["InvitedEmail"];
           }
           else
           {
          _scenarioContext[$"Email"] = personalEmail;
          EnterInputValue(_driver, "Email").SendKeys(personalEmail);
           }
          
          EnterInputValue(_driver, "Phone").SendKeys(Phone);
          EnterInputValue(_driver, "Website").SendKeys(URL);
        }
        else if(finderType.ToLower()=="ria")
        {
          _scenarioContext[$"PersonalEmail"] = email;      
          if (isInvited.ToLower().Contains("yes"))
          {
            _scenarioContext[$"WorkEmail"] = (string)_scenarioContext["InvitedEmail"];        
          }
          else
          {
            _scenarioContext[$"WorkEmail"] = personalEmail;
            EnterInputValue(_driver, "Email-Work").SendKeys(personalEmail);     
          }
      
           EnterInputValue(_driver, "Email-Personal").SendKeys(email);
           EnterInputValue(_driver, "Phone-Cell").SendKeys(Phone);
           EnterInputValue(_driver, "Phone-Work").SendKeys(Phone);
           EnterInputValue(_driver, "Phone-Home").SendKeys(Phone);
      
        }
      else //if (finderType.ToLower() == "bd")
      {
        _scenarioContext[$"PersonalEmail"] = email;
        if (isInvited.ToLower().Contains("yes"))
        {
          _scenarioContext[$"WorkEmail"] = (string)_scenarioContext["InvitedEmail"];
        }
        else
        {
          _scenarioContext[$"WorkEmail"] = personalEmail;
          EnterInputValue(_driver, "Email-Work").SendKeys(personalEmail);
        }

        EnterInputValue(_driver, "Email-Personal").SendKeys(email);
        EnterInputValue(_driver, "Phone-Cell").SendKeys(Phone);
        EnterInputValue(_driver, "Phone-Work").SendKeys(Phone);
        EnterInputValue(_driver, "Phone-Home").SendKeys(Phone);

      }


    }
    [Given(@"Provide details to the Physical Address section to Add MRIA form")]
    public void GivenProvideDetailsToThePhysicalAddressSection()
    {
      string street = "street";
      _scenarioContext["Address"] = street;
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);

      Thread.Sleep(3000);
      _scenarioContext["PhysicalState"] = SelectOption_DropDown(_driver, "State", 1,2);
      Thread.Sleep(3000);
      _scenarioContext["PhysicalCity"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
    }

    [Given(@"Provide details to the Business Address section")]
        public void GivenProvideDetailsToTheBusinessAddressSection()
        {
        string street = "street";
        _scenarioContext["Address"] = street;
        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);
      Thread.Sleep(3000);
        _scenarioContext["BusinessState"] = SelectOption_DropDown(_driver, "State", 1);
      Thread.Sleep(3000);
      _scenarioContext["BusinessCity"] = SelectOption_DropDown(_driver, "City", 1);

        EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
        }

        [Given(@"Provide details to the Mailing Address section (.*)")]
        public void GivenProvideDetailsToTheMailingAddressSection(string sameAsBusinessAddress)
        {
         if (sameAsBusinessAddress.ToLower().Contains("no"))
         {
           _scenarioContext["SameasBusinessAddress"] = false;
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = SelectOption_DropDown(_driver, "State", 1, 2);
        Thread.Sleep(2000);
           _scenarioContext["MailingCity"] = SelectOption_DropDown(_driver, "City", 1, 2);
         }
         else
         {
           _scenarioContext["SameasBusinessAddress"] = true;
            AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Same as Business Address");
        Thread.Sleep(3000);
        _scenarioContext["MailingState"] = (string)_scenarioContext["BusinessState"];
        Thread.Sleep(2000);
        _scenarioContext["MailingCity"] = (string)_scenarioContext["BusinessCity"];
         }
        }

        [Given(@"Provide Bank account details to Add finder form (.*)")]
        public void GivenProvideBankAccountDetailsToAddFinderForm(string accountType)
        {
         Random random = new Random();
         string street = "street";
         string holderName = "holderName";
         string accNumber = "21212121212121212";
         string bankName = "BankBank";
         string routingNumber = "656565656";
         string wireRoutingNumber = "787878787";
      string internalAccountNumber = "96894564567889784654";

        _scenarioContext["AccountAddress"] = street;
        _scenarioContext["AccountHolderName"] = holderName;
        _scenarioContext["AccountNumber"] = accNumber;
        _scenarioContext["BankName"] = bankName;
        _scenarioContext["RoutingNumber"] = routingNumber;
        _scenarioContext["WireRoutingNumber"] = wireRoutingNumber;
        _scenarioContext[$"InternalAccountNumber"] = internalAccountNumber;

      FinderPagePOM.ClickOnAccountTypeButton_BankAccountDetails_FinderPage(_driver, accountType);

        EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);
        EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
        EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
        EnterInputValue(_driver, "ACH Routing Number").SendKeys(routingNumber);
        EnterInputValue(_driver, "Wire Routing Number").SendKeys(wireRoutingNumber);
      _scenarioContext["ACHRoutingNumber"] = EnterInputValue(_driver, "ACH Routing Number").Text;
      _scenarioContext["WireRoutingNumber"] = EnterInputValue(_driver, "Wire Routing Number").Text;

      EnterInputValue(_driver, "Internal Account Number").SendKeys(internalAccountNumber);
      EnterInputValue(_driver, "Confirm Internal Account Number").SendKeys(internalAccountNumber);
        }

        [Then(@"Validate that the status displaying properly at the top (.*)")]
        public void ThenValidateThatTheStatusDisplayingProperlyAtTheTop(string statusName)
        {
         WaitForPageToLoad(_driver);
         Thread.Sleep(2000);
         Assert.That( FinderPagePOM.CheckStatusOfFinder_finderDetails_FinderPage(_driver, statusName));
        }

        [Then(@"Validate that the Finder details section displaying data properly on the finder details page (.*), (.*)")]
        public void ThenValidateThatTheFinderDetailsSectionDisplayingDataProperlyOnTheFinderDetailsPage(string finderType, string isMultipleAccount)
        {
         //Thread.Sleep(7000);
         WaitForToLoadAllData(_driver);
         IDictionary<string, string> contactDic = new Dictionary<string, string>();
      if (finderType.ToLower().Contains("mria"))
      {
        string[] dataKey = { "Name", "Type", "EIN", "Date of Incorporation", "Incorporation State" };
        contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Finder Details", dataKey);
     

        Assert.AreEqual(contactDic[dataKey[0]], $"{(string)_scenarioContext["CompanyName"]}", $"Validation failed for element {dataKey[0]}");
        Assert.AreEqual(contactDic[dataKey[1]], finderType, $"Validation failed for element {dataKey[1]}");
        Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["EIN"], $"Validation failed for element {dataKey[2]}");
        Assert.AreEqual(contactDic[dataKey[3]], Time.Date.ToString("MM-dd-yyyy"), $"Validation failed for element {dataKey[3]}");
        Assert.AreEqual(contactDic[dataKey[4]], State, $"Validation failed for element {dataKey[3]}");

      }
      else
      {

      string[] dataKey = { "Name", "Type", "SSN (Last 4 Digits)", "Email-login" };
          contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Finder Details", dataKey);

      //string d = $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorMN"]} {(string)_scenarioContext["InvestorLN"]}";
      
      Assert.AreEqual(contactDic[dataKey[1]], finderType, $"Validation failed for element {dataKey[1]}");
           if (isMultipleAccount.ToLower().Contains("yes"))
           {
             Assert.AreEqual(contactDic[dataKey[0]], $"{(string)_scenarioContext["FinderName"]}", $"Validation failed for element {dataKey[0]}");
             Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["SSN"], $"Validation failed for element {dataKey[2]}");
           }
           else
           {
             Assert.AreEqual(contactDic[dataKey[0]], $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorMN"]} {(string)_scenarioContext["InvestorLN"]}", $"Validation failed for element {dataKey[0]}");
             Assert.AreEqual(contactDic[dataKey[2]], SSN.Substring(SSN.Length - 4), $"Validation failed for element {dataKey[2]}");
           }
             Assert.AreEqual(contactDic[dataKey[3]], (string)_scenarioContext["EmailLogin"], $"Validation failed for element {dataKey[3]}");
      }
        }

        [Then(@"Validate that the Contact details section displaying data properly on the finder details page (.*), (.*)")]
        public void ThenValidateThatTheContactDetailsSectionDisplayingDataProperlyOnTheFinderDetailsPage(string isInvited,string finderType)
        {
          IDictionary<string, string> contactDic = new Dictionary<string, string>();
         if (finderType.ToLower().Contains("mria"))
         {
        string[] dataKey = { "Email","Website" , "Phone" };
        contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

        Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["Email"], $"Validation failed for element {dataKey[0]}");
        Assert.AreEqual(contactDic[dataKey[1]], URL, $"Validation failed for element {dataKey[1]}");
        Assert.AreEqual(contactDic[dataKey[2]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");
         }
         else
         {

          string[] dataKey = { "Email - Personal", "Email - Work", "Phone - Cell", "Phone - Work", "Phone - Home" };
          contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

        if(isInvited.ToLower().Contains("invited"))
         {
          _scenarioContext["WorkEmail"] = (string)_scenarioContext["InvitedEmail"];
         }
      string a = (string)_scenarioContext["PersonalEmail"];
      string b = (string)_scenarioContext["WorkEmail"]; 
      string d = Phone;

      Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["PersonalEmail"], $"Validation failed for element {dataKey[0]}");
      Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["WorkEmail"], $"Validation failed for element {dataKey[1]}");
      Assert.AreEqual(contactDic[dataKey[2]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");
      Assert.AreEqual(contactDic[dataKey[3]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[3]}");
      Assert.AreEqual(contactDic[dataKey[4]], Phone.FormatAsPhoneNumber(), $"Validation failed for element {dataKey[4]}");
         }
        }

        [Then(@"Validate that the Address section displaying data properly on the finder details page (.*)")]
        public void ThenValidateThatTheAddressSectionDisplayingDataProperlyOnTheFinderDetailsPage(string finderType)
        {
      if(finderType.ToLower().Contains("mria"))
      {
        IDictionary<string, string> contactDic = new Dictionary<string, string>();
        string[] dataKey = { "Physical Address"};
        contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", dataKey);

        Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(contactDic[dataKey[0]].Contains("USA"), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(contactDic[dataKey[0]].Contains(Zipcode), $"Validation failed for element {dataKey[0]}");

        Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["PhysicalState"]), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["PhysicalCity"]), $"Validation failed for element {dataKey[0]}");
      }
      else
      {

      IDictionary<string, string> contactDic = new Dictionary<string, string>();

      string[] dataKey = { "Business Address", "Mailing Address"};
      contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", dataKey);

      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["Address"]), $"Validation failed for element {dataKey[1]}");
      

      Assert.IsTrue(contactDic[dataKey[0]].Contains("USA"), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains("USA"), $"Validation failed for element {dataKey[1]}");
      

      Assert.IsTrue(contactDic[dataKey[0]].Contains(Zipcode), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[1]].Contains(Zipcode), $"Validation failed for element {dataKey[1]}");
      
        //required validation on same as businesaddress
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["BusinessState"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(contactDic[dataKey[0]].Contains((string)_scenarioContext["BusinessCity"]), $"Validation failed for element {dataKey[0]}");
        if((Boolean)_scenarioContext["SameasBusinessAddress"])
        {
          Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["BusinessState"]), $"Validation failed for element {dataKey[1]}");
          Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["BusinessCity"]), $"Validation failed for element {dataKey[1]}");
        }
        else
        {
          Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingState"]), $"Validation failed for element {dataKey[1]}");
          Assert.IsTrue(contactDic[dataKey[1]].Contains((string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[1]}");           

        }
      }
        }

        [Then(@"Validate that the Bank Account details section displaying data properly on the finder details page (.*), (.*)")]
        public void ThenValidateThatTheBankAccountDetailsSectionDisplayingDataProperlyOnTheFinderDetailsPage(string accountType, int accountNo)
        {
        IDictionary<string, string> dataDic = new Dictionary<string, string>();
        if (accountType.ToLower().Contains("ira"))               //this is the IRA investor
        accountType = (string)_scenarioContext["AccountType"];  //when roting method has been fetched from account details    
            
        string[] dataKey = { "Account Holder Name", "Account Number", "Bank Name", "ACH Routing Number", "Wire Routing Number", "Account Type" , "Internal Account Number" };
        dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Bank Account Details", dataKey);

        Assert.IsTrue(dataDic[dataKey[0]].Contains((string)_scenarioContext["AccountHolderName"]), $"Validation failed for element {dataKey[0]}");
        Assert.IsTrue(dataDic[dataKey[1]].Contains((string)_scenarioContext[$"AccountNumber"]), $"Validation failed for element {dataKey[1]}");
        Assert.IsTrue(dataDic[dataKey[2]].Contains((string)_scenarioContext[$"BankName"]), $"Validation failed for element {dataKey[2]}");
        Assert.IsTrue(dataDic[dataKey[3]].Contains((string)_scenarioContext[$"RoutingNumber"]), $"Validation failed for element {dataKey[3]}");
        Assert.IsTrue(dataDic[dataKey[4]].Contains((string)_scenarioContext[$"WireRoutingNumber"]), $"Validation failed for element {dataKey[4]}");
        Assert.IsTrue(dataDic[dataKey[5]].Contains(accountType), $"Validation failed for element {dataKey[5]}");
        Assert.IsTrue(dataDic[dataKey[6]].Contains((string)_scenarioContext[$"InternalAccountNumber"]), $"Validation failed for element {dataKey[6]}");
       }
    [When(@"Click on the Invite Finder button")]
    public void WhenClickOnTheInviteFinderButton()
    {
      FinderPagePOM.ClickOnInviteFinderButton_FinderPage(_driver);
      WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-dialog-container")));
    }
    [Given(@"Click on Finder Type Card on Add Finder page (.*)")]
    public void GivenClickOnFinderTypeCardOnAddFinderPage(string finderType)
    {
      AddInvestorPOM.ClickOnInvestorTypeCard_AddInvestorPage(_driver, finderType).Click();
    }
    [Then(@"Validate that CreateMyAccount button navigates to the Add finder page (.*)")]
    public void ThenValidateThatCreateMyAccountButtonNavigatesToTheAddFinderPage(string finderType)
    {
      Assert.That(AddInvestorPOM.ClickOnInvestorTypeCard_AddInvestorPage(_driver, finderType).Displayed);
    }
    [Then(@"Validate that the Finder Type displaying at Headline of Add Finder form (.*)")]
    public void ThenValidateThatTheFinderTypeDisplayingAtHeadlineOfAddFinderForm(string finderType)
    {
      AddInvestorPOM.CheckHeadlineOfAddInvestorform_InvestorPage(_driver, finderType);
    }
    [When(@"Navigate to the finder details by clicking on account name on Manage profile page (.*)")]
    public void WhenNavigateToTheFinderDetailsByClickingOnAccountNameOnManageProfilePage(string finderType)
    {
      Boolean result = true;
      string[] dataKey;
      int i = 1;
      while (result)
      {
        ManageProfilePOM.ClickOnAccountName_ManageProfilePage(_driver, i);
        WaitForPageToLoad(_driver);
        IDictionary<string, string> contactDic = new Dictionary<string, string>();

        if(finderType.ToLower()=="mria")
        {
          dataKey = new string[]{ "Email" };
          contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);
          if (!contactDic[dataKey[0]].Contains((string)_scenarioContext["Email"]))
          {
            i++;
            NavigateToBackPage(_driver);
            WaitForSpinnerToDisappear(_driver);
          }
          else
          {
            result = false;
          }
        }
        else
        {

        dataKey = new string[] { "Email - Personal" };
        contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", dataKey);

        if (!contactDic[dataKey[0]].Contains((string)_scenarioContext["PersonalEmail"]))
        {
          i++;
          NavigateToBackPage(_driver);
          WaitForSpinnerToDisappear(_driver);
        }
        else
        {
          result = false;
        }
        }
      }
    }


    [When(@"Search for the status finder (.*)")]
    public void WhenSearchForTheInitiatedStatusFinder(string statusName)
    {
      InvestmentPagePOM.ClickOnMoreFilter_InvestmentsPage(_driver);
      Thread.Sleep(1000);
      FinderPagePOM.ClickOnStatusFilter_FinderPage(_driver);
      AddInvestorPOM.ClickOnInvestorOption_InvestorTypeFilter_InvestorPage(_driver, statusName);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      InvestorPagePOM.ClickOnApplyButton_InvestmentPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }

    [When(@"Click on the finder name")]
    public void WhenClickOnTheFinderName()
    {
      ManageProfilePOM.ClickOnAccountName_ManageProfilePage(_driver, 1);
      WaitForPageToLoad(_driver);
      IDictionary<string, string> contactDic = new Dictionary<string, string>();
      string[] dataKey = { "Name" };
      contactDic = (IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Finder Details", dataKey);

      _scenarioContext["FinderName"]= contactDic["Name"];
    }

    [When(@"Click on the Approve button")]
    public void WhenClickOnTheApproveButton()
    {
      FinderPagePOM.ClickOnApproveButton_finderDetails_FinderPage(_driver);
    }

    //***********************************************************************************MRIA finder Definition********************************************************************




    [When(@"Provide details to the User details section of Add finder form (.*), (.*)")]
    public void WhenProvideDetailsToTheUserDetailsSectionOfAddFinderFormNoMRIA(string isMultiAccount,string finderType)
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

    //******************************************************************************Edit_Finder_Definition****************************************************************************



    [Given(@"Navigate to the Finder details page of first finder")]
    public void GivenNavigateToTheFinderDetailsPageOfFirstFinder()
    {
      ManageProfilePOM.ClickOnAccountName_ManageProfilePage(_driver);
      WaitForSpinnerToDisappear(_driver);
     WaitForToLoadAllData(_driver);
      Thread.Sleep(1000);
    }

    [Given(@"Get Finder Details from Finder details page (.*)")]
    public void GivenGetFinderDetailsFromFinderDetailsPage(string finderType)
    {
      WaitForPageToLoad(_driver);
      IDictionary<string, string> finderDetailsDic = new Dictionary<string, string>();

      if(finderType.ToLower()=="mria")
      {
        string[] finderDataKey = { "Name", "Type", "EIN", "Date of Incorporation", "Incorporation State" };
        finderDetailsDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Finder Details", finderDataKey);

        string[] ContactdataKey = { "Email", "Phone", "Website"};
        finderDetailsDic.MergeDictionaries((IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", ContactdataKey));

        string[] AddressdataKey = { "Physical Address"};
        finderDetailsDic.MergeDictionaries((IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", AddressdataKey));

       }
      else
      {

      string[] finderDataKey = { "Name", "Type", "SSN (Last 4 Digits)", "Email-login" };
      finderDetailsDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Finder Details", finderDataKey);

      string[] ContactdataKey = { "Email - Personal", "Email - Work", "Phone - Cell", "Phone - Work", "Phone - Home" };
      finderDetailsDic.MergeDictionaries( (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Contact Details", ContactdataKey));

      string[] AddressdataKey = { "Business Address", "Mailing Address" };
      finderDetailsDic.MergeDictionaries((IDictionary<string, string>)GetAddedData_AddedDetails(_driver, "Address", AddressdataKey));

      }

      string[] bankAccountdataKey = { "Account Holder Name", "Account Number", "Bank Name", "ACH Routing Number", "Wire Routing Number", "Account Type", "Internal Account Number" };
      finderDetailsDic.MergeDictionaries((IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Bank Account Details", bankAccountdataKey));

      _scenarioContext["FinderDetailsDic"] = finderDetailsDic;
    }

    [Then(@"Validate that the finder details section of edit Finder form populate data properly (.*), (.*), (.*)")]
    public void ThenValidateThatTheFinderDetailsSectionOfEditFinderFormPopulateDataProperlyNoRIANo(string isMultipleAccount,string finderType, string isInvited)
    {
      IDictionary<string, string> finderDetailsDic = (Dictionary<string, string>)_scenarioContext["FinderDetailsDic"];
      
        string T= SelectValue_Sendkey(_driver, "Type").Text;
      if(finderType.ToLower()=="mria")
      {
        string N = EnterInputValue(_driver, "Company Name").GetAttribute("value");
        string E = EnterInputValue(_driver, "EIN").GetAttribute("value");
        string D = EnterInputValue(_driver, "Date of Incorporation").GetCssValue("value");
        string S = SelectValueOfVisible_Sendkey(_driver, "Incorporation State").Text;

        Assert.IsTrue(finderDetailsDic["Type"].Contains(T), $"Failed, Value of finder details not populated properly");
        Assert.IsTrue(finderDetailsDic["EIN"].Contains(E), $"Failed, Value of finder details not populated properly");
        Assert.IsTrue(finderDetailsDic["Date of Incorporation"].Contains(D), $"Failed, Value of finder details not populated properly");
        Assert.IsTrue(finderDetailsDic["Incorporation State"].Contains(S), $"Failed, Value of finder details not populated properly");
        
      }
      else
      {
        string E=EnterInputValue(_driver, "Email Login").GetAttribute("value");
        string F=EnterInputValue(_driver, "First Name").GetAttribute("value");
        string M=EnterInputValue(_driver, "Middle Name").GetAttribute("value");
        string L=EnterInputValue(_driver, "Last Name").GetAttribute("value");
        string S=EnterInputValue(_driver, "SSN").GetAttribute("value");

        Assert.IsTrue(finderDetailsDic["Type"].Contains(T),$"Failed, Value of finder details not populated properly");
        Assert.IsTrue(finderDetailsDic["Email-login"].Contains(E), $"Failed, Value of finder details not populated properly");
        Assert.IsTrue(finderDetailsDic["Name"].Contains(F), $"Failed, Value of finder details not populated properly");
        Assert.IsTrue(finderDetailsDic["Name"].Contains(M), $"Failed, Value of finder details not populated properly");
        Assert.IsTrue(finderDetailsDic["Name"].Contains(L), $"Failed, Value of finder details not populated properly");
        Assert.IsTrue(S.Contains(finderDetailsDic["SSN (Last 4 Digits)"]), $"Failed, Value of finder details not populated properly");
      }
          
    }

    [Then(@"Validate that the Contact details section of edit Finder form populate data properly (.*), (.*)")]
    public void ThenValidateThatTheContactDetailsSectionOfEditFinderFormPopulateDataProperlyNoRIA(string isInvited, string finderType)
    {
      IDictionary<string, string> finderDetailsDic = (Dictionary<string, string>)_scenarioContext["FinderDetailsDic"];

      if(finderType.ToLower()=="mria")
      {
        string E = EnterInputValue(_driver, "Email").GetAttribute("value");
        string P = EnterInputValue(_driver, "Phone").GetAttribute("value");
        string W = EnterInputValue(_driver, "Website").GetAttribute("value");

        Assert.IsTrue(finderDetailsDic["Email"].Contains(E), $"Failed, Value of Contact details not populated properly");
        Assert.IsTrue(finderDetailsDic["Phone"].Contains(P), $"Failed, Value of Contact details not populated properly");
        Assert.IsTrue(finderDetailsDic["Website"].Contains(W), $"Failed, Value of Contact details not populated properly");
      }
      else
      {
      string W = EnterInputValue(_driver, "Email-Work").GetAttribute("value");
      string P = EnterInputValue(_driver, "Email-Personal").GetAttribute("value");
      string PW = EnterInputValue(_driver, "Phone-Work").GetAttribute("value");
      string PC = EnterInputValue(_driver, "Phone-Cell").GetAttribute("value");
      string PH = EnterInputValue(_driver, "Phone-Home").GetAttribute("value");

      Assert.IsTrue(finderDetailsDic["Email - Work"].Contains(W), $"Failed, Value of Contact details not populated properly");
      Assert.IsTrue(finderDetailsDic["Email - Personal"].Contains(P), $"Failed, Value of Contact details not populated properly");
      Assert.IsTrue(finderDetailsDic["Phone - Work"].Contains(PW), $"Failed, Value of Contact details not populated properly");
      Assert.IsTrue(finderDetailsDic["Phone - Cell"].Contains(PC), $"Failed, Value of Contact details not populated properly");
      Assert.IsTrue(finderDetailsDic["Phone - Home"].Contains(PH), $"Failed, Value of Contact details not populated properly");
      }
    }
    [Then(@"Validate that the Physical Address section of Edit finder form populate data properly")]
    public void ThenValidateThatThePhysicalAddressSectionOfEditFinderFormPopulateDataProperly()
    {
      IDictionary<string, string> finderDetailsDic = (Dictionary<string, string>)_scenarioContext["FinderDetailsDic"];

      string S1 = EnterInputValue(_driver, "Street Address 1").GetAttribute("value");
      string S2 = EnterInputValue(_driver, "Street Address 2").GetAttribute("value");
      string S3 = EnterInputValue(_driver, "Street Address 3").GetAttribute("value");
      string C = SelectValue_Sendkey(_driver, "Country").Text;
      string S = SelectValue_Sendkey(_driver, "State").Text;
      string Ct = SelectValue_Sendkey(_driver, "City").Text;
      string Z = EnterInputValue(_driver, "Zipcode").GetAttribute("value");

      Assert.IsTrue(finderDetailsDic["Physical Address"].Contains(S1), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Physical Address"].Contains(S2), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Physical Address"].Contains(S3), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Physical Address"].Contains(C), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Physical Address"].Contains(S), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Physical Address"].Contains(Ct), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Physical Address"].Contains(Z), $"Failed, Value of Address details not populated properly");
    }
    [Then(@"Validate that the Business Address section of Edit finder form populate data properly")]
    public void ThenValidateThatTheBusinessAddressSectionOfEditFinderFormPopulateDataProperly()
    {
      IDictionary<string, string> finderDetailsDic = (Dictionary<string, string>)_scenarioContext["FinderDetailsDic"];


      string S1 = EnterInputValue(_driver, "Street Address 1").GetAttribute("value");
      string S2= EnterInputValue(_driver, "Street Address 2").GetAttribute("value");
      string S3 = EnterInputValue(_driver,"Street Address 3").GetAttribute("value");
      string C = SelectValue_Sendkey(_driver, "Country").Text;
      string S = SelectValue_Sendkey(_driver, "State").Text;
      string Ct = SelectValue_Sendkey(_driver, "City").Text;
      string Z = EnterInputValue(_driver, "Zipcode").GetAttribute("value");

      Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S1), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S2), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S3), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Business Address"].Contains(C), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Business Address"].Contains(Ct), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Business Address"].Contains(Z), $"Failed, Value of Address details not populated properly");

    }

    [Then(@"Validate that the Mailing Address section of Edit finder form populate data properly")]
    public void ThenValidateThatTheMailingAddressSectionOfEditFinderFormPopulateDataProperly()
    {
      IDictionary<string, string> finderDetailsDic = (Dictionary<string, string>)_scenarioContext["FinderDetailsDic"];


      string S1 = EnterInputValue(_driver, "Street Address 1",2).GetAttribute("value");
      string S2 = EnterInputValue(_driver, "Street Address 2",2).GetAttribute("value");
      string S3 = EnterInputValue(_driver, "Street Address 3", 2).GetAttribute("value");
      string C = SelectValueOfVisible_Sendkey(_driver, "Country",2).Text;
      string S = SelectValueOfVisible_Sendkey(_driver, "State",2).Text;
      string Ct = SelectValueOfVisible_Sendkey(_driver, "City",2).Text;
      string Z = EnterInputValue(_driver, "Zipcode", 2).GetAttribute("value");

      if(finderDetailsDic["Business Address"].Contains(S2))
      {

        Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S1), $"Failed, Value of Address details not populated properly");
        Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S2), $"Failed, Value of Address details not populated properly");
        Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S3), $"Failed, Value of Address details not populated properly");
        Assert.IsTrue(finderDetailsDic["Business Address"].Contains(C), $"Failed, Value of Address details not populated properly");
        Assert.IsTrue(finderDetailsDic["Business Address"].Contains(S), $"Failed, Value of Address details not populated properly");
        Assert.IsTrue(finderDetailsDic["Business Address"].Contains(Ct), $"Failed, Value of Address details not populated properly");
        Assert.IsTrue(finderDetailsDic["Business Address"].Contains(Z), $"Failed, Value of Address details not populated properly");

        Assert.That(CheckThatCheckBoxStatus(_driver, "Same as Business Address"));

      }
      else
      {

      Assert.IsTrue(finderDetailsDic["Mailing Address"].Contains(S1), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Mailing Address"].Contains(S2), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Mailing Address"].Contains(S3), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Mailing Address"].Contains(C), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Mailing Address"].Contains(S), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Mailing Address"].Contains(Ct), $"Failed, Value of Address details not populated properly");
      Assert.IsTrue(finderDetailsDic["Mailing Address"].Contains(Z), $"Failed, Value of Address details not populated properly");

      Assert.IsTrue(!CheckThatCheckBoxStatus(_driver, "Same as Business Address"),"Failed, the check Same as Business Address is Unchecked");

      }

    }

    [Then(@"Validate that the Bank account details of Edit finder form populate data properly")]
    public void ThenValidateThatTheBankAccountDetailsOfEditFinderFormPopulateDataProperly()
    {
      IDictionary<string, string> finderDetailsDic = (Dictionary<string, string>)_scenarioContext["FinderDetailsDic"];
              
      string N = EnterInputValue(_driver, "Account Holder Name").GetAttribute("value");
      string Nu = EnterInputValue(_driver, "Account Number").GetAttribute("value");
      string B = EnterInputValue(_driver, "Bank Name").GetAttribute("value");
      string AR = EnterInputValue(_driver, "ACH Routing Number").GetAttribute("value");
      string WR = EnterInputValue(_driver, "Wire Routing Number").GetAttribute("value");
      string IA = EnterInputValue(_driver, "Internal Account Number").GetAttribute("value");
      Assert.That(FinderPagePOM.Check_CheckBoxOfAccountType_BankAccountDetails_FinderPage(_driver,finderDetailsDic["Account Type"]));
      Assert.IsTrue(finderDetailsDic["Account Holder Name"].Contains(N), $"Failed, Value of Bank details not populated properly");
      Assert.IsTrue(finderDetailsDic["Account Number"].Contains(Nu), $"Failed, Value of Bank details not populated properly");
      Assert.IsTrue(finderDetailsDic["Bank Name"].Contains(B), $"Failed, Value of Bank details not populated properly");
      Assert.IsTrue(finderDetailsDic["ACH Routing Number"].Contains(AR), $"Failed, Value of Bank details not populated properly");
      Assert.IsTrue(finderDetailsDic["Wire Routing Number"].Contains(WR), $"Failed, Value of Bank details not populated properly");
      Assert.IsTrue(finderDetailsDic["Internal Account Number"].Contains(IA), $"Failed, Value of Internal Bank details not populated properly");
    }

    [When(@"Edit details to the finder details section of Add finder form (.*), (.*), (.*)")]
    public void WhenEditDetailsToTheFinderDetailsSectionOfAddFinderForm(string isMultiAccount, string finderType, string isInvited)
    {
      Faker faker = new Faker();
      string email = faker.Person.Email;
      email = email.ChangeEmailDomain("Yopmail.com");
      string firstName = faker.Person.FirstName;
      string lastName = faker.Person.LastName;
      string middleName = "EditedM";
      string eIN = "65-4123845";

     

        

      Thread.Sleep(1000);

      if (finderType.ToLower().Contains("mria"))
      {
          _scenarioContext["CompanyName"] = firstName;
          EnterInputValue(_driver, "EIN").SendKeys(eIN);
          EnterInputValue(_driver, "Company Name").SendKeys(firstName);
          _scenarioContext["EIN"] = EnterInputValue(_driver, "EIN").GetAttribute("value");
          EnterInputValue(_driver, "Date of Incorporation").SendKeys(Time.Date.ToString("MM/dd/yyyy"));
          SelectValueOfVisible_Sendkey(_driver, "Incorporation State").SendKeys(State);
        
      }     
      else 
      {
      
          _scenarioContext["InvestorFN"] = firstName;
          _scenarioContext["InvestorLN"] = lastName;
          _scenarioContext["InvestorMN"] = middleName;
          _scenarioContext["EmailLogin"]= EnterInputValue(_driver, "Email Login").GetAttribute("value");
          EnterInputValue(_driver, "First Name").SendKeys(firstName);
          EnterInputValue(_driver, "Middle Name").SendKeys(middleName);
          EnterInputValue(_driver, "Last Name").SendKeys(lastName);

          EnterInputValue(_driver, "SSN").SendKeys(SSN);
          
        
      }

    }

    [Given(@"Clear the All input value")]
    public void GivenClearTheAllInputValue()
    {
      ClearAllInput(_driver);
    }

    [Given(@"Edit details to the Business Address section")]
    public void GivenEditDetailsToTheBusinessAddressSection()
    {
      string street = "edit";
      _scenarioContext["Address"] = street;
      Boolean checkcheck=CheckThatCheckBoxStatus(_driver, "Same as Business Address");
      Boolean SameasBusinessAddress= checkcheck;

      //business address
     if (checkcheck)
      {
        //first the checkbox should be unchecked to clear mailing details  
        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Same as Business Address");
        SameasBusinessAddress = false;     
      }

      ClearAllInput( _driver); 
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);

      _scenarioContext["BusinessState"] = SelectOption_DropDown(_driver, "State", 1);
      _scenarioContext["BusinessCity"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
      //same as business adress
      if (!checkcheck)
      {
        AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Same as Business Address");
        SameasBusinessAddress = true;
      }
        _scenarioContext["SameasBusinessAddress"] = SameasBusinessAddress;

      //mailing Address
      if (SameasBusinessAddress)
      {      
        _scenarioContext["MailingState"] = (string)_scenarioContext["BusinessState"];
        _scenarioContext["MailingCity"] = (string)_scenarioContext["BusinessCity"];
      }
      else
      {
        _scenarioContext["MailingState"] = SelectOption_DropDown(_driver, "State", 1, 2);
        _scenarioContext["MailingCity"] = SelectOption_DropDown(_driver, "City", 1, 2);
      }
    }
    [Given(@"Edit details to the Physical Address section to Edit MRIA form")]
    public void GivenEditDetailsToThePhysicalAddressSection()
    {
      string street = "edit";
      _scenarioContext["Address"] = street;
      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", street);

      _scenarioContext["PhysicalState"] = SelectOption_DropDown(_driver, "State", 1, 2);
      _scenarioContext["PhysicalCity"] = SelectOption_DropDown(_driver, "City", 1);

      EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
    }

    [Given(@"Edit Bank account details to Add finder form (.*)")]
    public void GivenEditBankAccountDetailsToAddFinderForm(string accountType)
    {
      Random random = new Random();
      string street = "edit";
      string holderName = "editHolderName";
      string accNumber = "41414141414141414";
      string bankName = "editBankBank";
      string routingNumber = "848484848";
      string wireRoutingNumber = "626262626";

      if (FinderPagePOM.Check_CheckBoxOfAccountType_BankAccountDetails_FinderPage(_driver, "Savings"))
        accountType = "Checking";
      else
        accountType = "Savings";

      _scenarioContext["AccountAddress"] = street;
      _scenarioContext["AccountHolderName"] = holderName;
      _scenarioContext["AccountNumber"] = accNumber;
      _scenarioContext["BankName"] = bankName;
      _scenarioContext["RoutingNumber"] = routingNumber;
      _scenarioContext["WireRoutingNumber"] = wireRoutingNumber;
      _scenarioContext["AccountType"] = accountType;

      FinderPagePOM.ClickOnAccountTypeButton_BankAccountDetails_FinderPage(_driver, accountType);

      EnterInputValue(_driver, "Account Holder Name").SendKeys(holderName);
      EnterInputValue(_driver, "Account Number").SendKeys(accNumber);
      EnterInputValue(_driver, "Bank Name").SendKeys(bankName);
      EnterInputValue(_driver, "ACH Routing Number").SendKeys(routingNumber);
      EnterInputValue(_driver, "Wire Routing Number").SendKeys(wireRoutingNumber);
      _scenarioContext["ACHRoutingNumber"] = EnterInputValue(_driver, "ACH Routing Number").Text;
      _scenarioContext["WireRoutingNumber"] = EnterInputValue(_driver, "Wire Routing Number").Text;
    }
    [Then(@"Validate that the Edited Bank Account details section displaying data properly on the finder details page (.*)")]
    public void ThenValidateThatTheEditedBankAccountDetailsSectionDisplayingDataProperlyOnTheFinderDetailsPage(int accountNo)
    {
      IDictionary<string, string> dataDic = new Dictionary<string, string>();
                  
       string accountType = (string)_scenarioContext["AccountType"];  //when roting method has been fetched from account details    

      string[] dataKey = { "Account Holder Name", "Account Number", "Bank Name", "ACH Routing Number", "Wire Routing Number", "Account Type" };
      dataDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_withSubCardName(_driver, "Bank Account Details", dataKey);

      Assert.IsTrue(dataDic[dataKey[0]].Contains((string)_scenarioContext["AccountHolderName"]), $"Validation failed for element {dataKey[0]}");
      Assert.IsTrue(dataDic[dataKey[1]].Contains((string)_scenarioContext[$"AccountNumber"]), $"Validation failed for element {dataKey[1]}");
      Assert.IsTrue(dataDic[dataKey[2]].Contains((string)_scenarioContext[$"BankName"]), $"Validation failed for element {dataKey[2]}");
      Assert.IsTrue(dataDic[dataKey[3]].Contains((string)_scenarioContext[$"RoutingNumber"]), $"Validation failed for element {dataKey[3]}");
      Assert.IsTrue(dataDic[dataKey[4]].Contains((string)_scenarioContext[$"WireRoutingNumber"]), $"Validation failed for element {dataKey[4]}");
      Assert.IsTrue(dataDic[dataKey[5]].Contains(accountType), $"Validation failed for element {dataKey[5]}");
    }
  }
}
