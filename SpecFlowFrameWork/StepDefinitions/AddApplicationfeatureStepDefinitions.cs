using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Bogus;
using Bogus.DataSets;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using System;
using System.Linq;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;
using Yrefy_AutomationProject.Pages.ServicingObject;
using Yrefy_AutomationProject.Utility;
using Yrefy_AutomationProject.Utility.CostumException;
using static System.Net.Mime.MediaTypeNames;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class AddApplicationfeatureStepDefinitions:BaseClass
    {
        private readonly IWebDriver _driver;

        private ScenarioContext _scenarioContext;
        private ExtentTest _scenario;
        
        public AddApplicationfeatureStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;

        }
        public static Dictionary<string, string> JsonData()
        {
      string Path = GetDataParser().TestData_Path("ApplicationTD");
      var testData = new Dictionary<String, String>();

        testData.Add("PreferredMethodOfContact", GetDataParser().TestData("PreferredMethodOfContact", Path));
        testData.Add("SSN", GetDataParser().TestData("SSN", Path));
        testData.Add("State", GetDataParser().TestData("State", Path));
        testData.Add("City", GetDataParser().TestData("City", Path)); 
        testData.Add("Address", GetDataParser().TestData("Address", Path));
        testData.Add("EmployerAddress", GetDataParser().TestData("EmployerAddress", Path));
        testData.Add("DoyouhaveaSavingCheckingAccount", GetDataParser().TestData("DoyouhaveaSavingCheckingAccount", Path));

      return testData;
        }

        [When(@"Click on Add-Application button")]
        public void WhenClickOnAdd_ApplicationButton()
        {
            AddApicationPOM.ClickOnAddApplicationButton(_driver).Click();
            WaitForSpinnerToDisappear(_driver);
        }
    


              [Given(@"Create an Application with Contact details")]
        public void GivenCreateAnApplicationWithContactDetails()
    {
      var faker = new Faker();
      string fName = faker.Person.FirstName;

      AddApicationPOM.ClickOnAddApplicationButton(_driver).Click();
      Thread.Sleep(4000);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "First Name").SendKeys(fName);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Email").SendKeys(faker.Person.Email);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone cell").SendKeys("1234567890");
      AddApicationPOM.ClickOnSaveAndNextButton(_driver);
    }

    [When(@"Provide required details to contact details step (.*), (.*)")]
        public void WhenProvideRequiredDetailsToContactDetailsStep(string Email,string BestTimeToCall)
        {
            var faker = new Faker();

            string fName=faker.Person.FirstName;
            string mName = "Mn";
            string lName = faker.Person.LastName;
            string email = faker.Person.Email;
            string altEmail = Email;
            string Phone = "1111111111";
            string home = "2222222222";
            string other = "3333333333";

            _scenarioContext["PersonalFN"] = fName;
            _scenarioContext["PersonalMN"] = mName;
            _scenarioContext["PersonalLN"] = lName;
            _scenarioContext["ContactEmail"] = email;
            _scenarioContext["ContactAltEmail"] = Email;
            _scenarioContext["ContactPhone"] = Phone;
            _scenarioContext["ContactHome"] = home;
            _scenarioContext["ContactOther"] = other;


            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "First Name").SendKeys(fName);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Middle Name").SendKeys(mName);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Last Name").SendKeys(lName);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver,"Email").SendKeys(faker.Person.Email);
      
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Alt. Email").SendKeys(Email);
 
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone cell").SendKeys(Phone);
   
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone Home").SendKeys(home);
      
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone Other").SendKeys(other);
      
            AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "bestTimeToCall").SendKeys(BestTimeToCall);

      try
      {
        //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, JsonData()["AddressPreference"]).SendKeys("preferredAddress");
        _scenarioContext["PreferredMethodOfContact"]=SelectOption_DropDown_Randomly(_driver, JsonData()["PreferredMethodOfContact"]);
      }
      catch
      {

      }
    }

        [Then(@"Validate that navigated to Add-application page")]
        public void ThenValidateThatNavigatedToAdd_ApplicationPage()
        {
            
        }

        [When(@"Click on Save & Next button")]
        public void WhenClickOnSaveNextButton()
        {
            AddApicationPOM.ClickOnSaveAndNextButton(_driver);      
        }
        [Then(@"Click on Confirm popup")]
        public void ThenClickOnConfirmPopup()
    {
      try
      {
        AddApicationPOM.ClickOnConfirmButton_EmplyerConfirmationPopup_AddApplicationDetails(_driver);
      }
      catch { }
        }

    [When(@"Provide Required value to Personal details step")]
        public void WhenProvideRequiredValueToPersonalDetailsStep()
        {
            var faker = new Faker();
            string PersonalFN = faker.Person.FirstName;
            string PersonalMN = "Trebor";
            string PersonalLN = "Uchake";
            string PersonalSSN = "123456789";
            string Datee = Date.ToString("MM/dd/yyyy");
            string DriversLicenceStateCode = "GU";
            string DriverLicence = "4567";
            string previousName = "Bert";
            string maidenName = "Uchali";
      string borrowerSource = "Source";

            //Set data to scenario context
            
            _scenarioContext["PersonalSSN"] = PersonalSSN;
            _scenarioContext["Datee"] = Datee;
            _scenarioContext["DriversLicenceStateCode"] = DriversLicenceStateCode;
            _scenarioContext["DriverLicence"] = DriverLicence;
            _scenarioContext["PreviousName"] = previousName;
            _scenarioContext["MaidenName"] = maidenName;
            _scenarioContext["BorrowerSource"]= borrowerSource;


      if (!AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "SSN").Enabled)
      {
        AddApicationPOM.ClickOnVisibilityButton_AddApplicationDetails(_driver);
        Thread.Sleep(3000);
      }

      //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "First Name").SendKeys(PersonalFN);        
      //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Middle Name").SendKeys(PersonalMN);    
      //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Last Name").SendKeys(PersonalLN);    
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Previous Name").SendKeys(previousName);     
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Maiden Name").SendKeys(maidenName);     
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "SSN").SendKeys(PersonalSSN);
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Date Of Birth").SendKeys(Datee); 
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Expiration Date").SendKeys(Date.AddDays(1).ToString("MM/dd/yyyy"));
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Number").SendKeys(DriverLicence);     
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Borrower Source").SendKeys(borrowerSource);   
            AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "driversLicense").SendKeys(DriversLicenceStateCode);
            Thread.Sleep(1000);
           _scenarioContext["DoYouHaveAccount"]= SelectOption_DropDown_Randomly(_driver, JsonData()["DoyouhaveaSavingCheckingAccount"]);
        }

        [When(@"Check IsUSCistizen")]
        public void WhenCheckIsUSCistizen()
        {
            AddApicationPOM.ClickOnRadiobutton_AddApplicationDetails(_driver, "Is US Citizen").Click();
      if(AddApicationPOM.ClickOnRadiobutton_AddApplicationDetails(_driver, "Is US Citizen").GetAttribute("class").Contains("checked"))
            _scenarioContext["IsUSCitizen"] = "Yes";
      else
        _scenarioContext["IsUSCitizen"] = "-";
        }

        [When(@"Check IsPermaanentResidence")]
        public void WhenCheckIsPermaanentResidence()
        {
            AddApicationPOM.ClickOnRadiobutton_AddApplicationDetails(_driver, "Is Permanent Resident").Click();
      if (AddApicationPOM.ClickOnRadiobutton_AddApplicationDetails(_driver, "Is Permanent Resident").GetAttribute("class").Contains("checked"))
        _scenarioContext["IsUSCitizen"] = "-";
      else
        _scenarioContext["IsUSCitizen"] = "Yes";
    }
        [When(@"Provide Required details to Mailing Address")]
        public void WhenProvideRequiredDetailsToMailingAddress()
        {
            _scenarioContext["Zipcode"] = Zipcode;
            _scenarioContext["MailingState"] = State;
            _scenarioContext["MailingCity"] = City;
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street Address", "street");
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
            Thread.Sleep(3000);
            SelectValueOfVisible_Sendkey(_driver, "State",1).SendKeys(State);
            Thread.Sleep(3000);
            SelectValueOfVisible_Sendkey(_driver, "City",1).SendKeys(City);
            Thread.Sleep(1000);
        }

        [When(@"Provide Required details to Physical Address")]
        public void WhenProvideRequiredDetailsToPhysicalAddress()
        {
      Thread.Sleep(3000);
      _scenarioContext["PhysicalState"] = State;
            _scenarioContext["PhysicalCity"] = City;
      SelectValueOfVisible_Sendkey(_driver, "State", 2).SendKeys(State);
      Thread.Sleep(3000);
      SelectValueOfVisible_Sendkey(_driver, "City", 2).SendKeys(City);
      Thread.Sleep(1000);
        }

        [When(@"Check the SameAsmailingAddress")]
        public void WhenCheckTheSameAsmailingAddress()
        {
            AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Same as Mailing Address");
        }

        [When(@"Provide Required details to Other Address")]
        public void WhenProvideRequiredDetailsToOtherAddress()
        {
            _scenarioContext["OtherState"]= State;
            _scenarioContext["OtherCity"]= City;
      SelectValueOfVisible_Sendkey(_driver, "State", 3).SendKeys(State);
      Thread.Sleep(2000);
      SelectValueOfVisible_Sendkey(_driver, "City", 3).SendKeys(City);
      Thread.Sleep(1000);
        }

       
       
        
        [When(@"Provide Required details to Reference Details (.*)")]
        public void WhenProvideRequiredDetailsToReferenceDetails(string Relationship)
        {
            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Reference Details");
            var faker = new Faker();
            Thread.Sleep(2000);
            SelectValueOfVisible_Sendkey(_driver, "Relationship").SendKeys(Relationship);
            Thread.Sleep(1000);
            string FN= faker.Person.FirstName;
            string MI= "Rajwon";
            string LN= "kumbar";
           
            _scenarioContext["Relationship"] = Relationship;
            _scenarioContext["ReferenceFN"] = FN;
            _scenarioContext["ReferenceMN"] = MI;
            _scenarioContext["ReferenceLN"] = LN;
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "First Name", FN);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Middle Initial",MI);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Last Name", LN);
            
            Thread.Sleep(1000);
        }

        [When(@"Provide Required details to Reference Contact details")]
        public void WhenProvideRequiredDetailsToReferenceContactDetails()
        {
            string Email = "Refernce@yopmail.com";
            string Phone = "1234567890";
            _scenarioContext["Email"] = Email;
            _scenarioContext["Phone"] = Phone;

            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Contact Details");
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Email",Email);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Phone",Phone);
            
        }

        [When(@"Provide Required details to Reference Address details")]
        public void WhenProvideRequiredDetailsToReferenceAddressDetails()
        {
            string state =State2;
            string city = City2;
            _scenarioContext["State"]= state;
            _scenarioContext["City"]= city;
            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Address Details");
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", "street");
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", "85224");
            
            Thread.Sleep(1000);
            SelectValueOfVisible_Sendkey(_driver, "State").SendKeys(state);
            Thread.Sleep(3000);
            SelectValueOfVisible_Sendkey(_driver, "City").SendKeys(city);      
            Thread.Sleep(1000);
        }


        [When(@"Provide Required details to loan details step (.*), (.*)")]
        public void WhenProvideRequiredDetailsToLoanDetailsStep(string Agency,string TypeOfLoan)
        {
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Loan Requested Amount").SendKeys("3000");
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Loan Term (In Months)").SendKeys("3");
            Thread.Sleep(1000);
           _scenarioContext["AgencyValue"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "Agency",1);
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Aging (In Months)").SendKeys("30");
            AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Type Of Loan").SendKeys(TypeOfLoan);
            Thread.Sleep(1000);
            AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Loan Category").SendKeys("Federal Student Loan");
            Thread.Sleep(1000);
    }
    [Then(@"Validate success-notification displaying if applicant address is not filled")]
    public void ThenValidateSuccess_NotificationDisplayingIfApplicantAddressIsNotFilled()
    {
     
    }

    [When(@"Click on Add loan button")]
        public void WhenClickOnAddLoanButton()
        {
            AddApicationPOM.ClickOnAddLoan_AddApplicationDetails(_driver);
            Thread.Sleep(1000);
        }
        [When(@"Click on Add Reference button")]
        public void WhenClickOnAddReferenceButton()
        {
            AddApicationPOM.ClickOnAddReference_AddApplicationDetails(_driver);
            
        }

        [Then(@"Validate that Add Loan button working properly")]
        public void ThenValidateThatAddLoanButtonWorkingProperly()
        {
            
        }
        [When(@"Provide Required details to Financial details (.*), (.*)")]
        public void WhenProvideRequiredDetailsToFinancialDetails(string IncomeType,string IncomeFrequency)
        {
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Income Amount").SendKeys("40000");
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Notes").SendKeys("Noted");
            AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Income Type").SendKeys(IncomeType);
            Thread.Sleep(1000);
            AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Income Frequency").SendKeys(IncomeFrequency);
            Thread.Sleep(1000);
        }
        [When(@"Click on Add Income button")]
        public void WhenClickOnAddIncomeButton()
        {
            AddApicationPOM.ClickOnAddIncome_AddApplicationDetails(_driver);
            Thread.Sleep(1000);
        }
        [Then(@"Validate that the Add income button working properly")]
        public void ThenValidateThatTheAddIncomeButtonWorkingProperly()
        {
           
        }
        [When(@"Provide Required details to Employee details (.*)")]
        public void WhenProvideRequiredDetailsToEmploymentDetails(string EmploymentType)
        {
      string EmployerEmpName;
      string Position;
      if (EmploymentType.ToLower().Contains("unemployed"))
      {
        EmployerEmpName = "Unemployed";
        Position = "None";
      }
      else
      {
        EmployerEmpName = "EmprN";
        Position = "AutoEng";
      }
      string HoursPerWeek = "40";


      _scenarioContext["EmployeeEmpName"] = EmployerEmpName;
      _scenarioContext["Position"] = Position;
      _scenarioContext["HoursPerWeek"] = HoursPerWeek;
      _scenarioContext["EmployeeType"] = EmploymentType;



            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver,"Employer Details");
            Thread.Sleep(2000);
            AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
            AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Employment Type").SendKeys(EmploymentType);
            Thread.Sleep(3000);
      if (!EmploymentType.ToLower().Contains("unemployed"))
             {
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Employer Name").SendKeys(EmployerEmpName);
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Position").SendKeys(Position);

                AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "No. of Hours Per Week").SendKeys(HoursPerWeek);
                Thread.Sleep(1000);
                AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Start Date").SendKeys(Date.AddYears(-2).ToString("MM/dd/yyyy"));
        if (EmploymentType.ToLower().Contains("retired"))
        {
          //if (AddApicationPOM.CheckThatBox_AddApplicationDetails(_driver, "Still Working").GetAttribute("aria-checked").Contains("false"))
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "End Date").SendKeys(Date.AddYears(-1).ToString("MM/dd/yyyy"));
        }
      }
        }

        [Then(@"Validate that Still Working check invisible by providing End date")]
        public void ThenValidateThatStillWorkingCheckInvisibleAfterProvidingEndDate()
        {
          string a = (string)_scenarioContext["EmployeeType"];
          if (!(((string)_scenarioContext["EmployeeType"]).ToLower().Contains("unemployed")||((string)_scenarioContext["EmployeeType"]).ToLower().Contains("retired")))
          {
       
                for (int i= AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "End Date").GetAttribute("value").Length;i>=0;i--)
                {
                 AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "End Date").SendKeys(Keys.Backspace);
                }
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "End Date").SendKeys(Date.AddYears(-1).ToString("MM/dd/yyyy"));
            try
            {
                AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver,"Still Working");
                     try
                     {

                                   Assert.That(false);
                     }
                     catch
                     {

                                            try
                                            {
                    
                                                throw new CustomException("Still working field not getting disabled");
                                            }
                                            catch (CustomException e)
                                            {
                                                throw e;
                                            }
                
                     }
            }
            catch
            {
            }
          }
      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employer Details", "close");
    }
    [Then(@"Validate that the input field reflected as per Employment Type (.*)")]
    public void ThenValidateThatTheInputFieldReflectedAsPerEmploymentType(string employmentType)
    {
      if (employmentType.ToLower().Contains("unemployed"))
        Assert.That(AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Employer Name").GetAttribute("value").ToLower().Contains("unemployed"));
      if (employmentType.ToLower().Contains("self employed"))
        Assert.That(AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Employer Name").GetAttribute("value").Contains((string)_scenarioContext["PersonalFN"]));
      if (employmentType.ToLower().Contains("retired"))
        Assert.That(true);


    }

    [Then(@"Validate that End Date field getting disabled by checked Still working")]
        public void ThenValidateThatEndDateFieldGettingDisabledByCheckedStillWorking()
        {
          if(!(((string)_scenarioContext["EmployeeType"]).ToLower().Contains("unemployed")||((string)_scenarioContext["EmployeeType"]).ToLower().Contains("retired")))
          {

            AddApicationPOM.ClickOnCheckBox_AddApplicationDetails(_driver, "Still Working");
            Thread.Sleep(2000);
            try
            {
                AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "End Date").SendKeys(Date.AddYears(-1).ToString("MM/dd/yyyy"));
                try
                {
                        Assert.That(false);
                }
                catch
                {
                    try
                    {
                        throw new CustomException("Still working field not getting disabled");
                    }
                    catch (CustomException e)
                    {
                        throw e;
                    }
                }
            }
            catch
            {
            }
          }
      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employer Details", "close");
    }

        [When(@"Provide Required details to Contact details")]
        public void WhenProvideRequiredDetailsToContactDetails()
        {
            string Phone = "4444444444";
            var faker= new Faker();
            string email = faker.Person.Email;

            _scenarioContext["EmployeeEmail"] = email;
            _scenarioContext["EmployeePhone"] = Phone;

            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employee Contact Details");
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Email", email);
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Phone Number", "4444444444");
        }

        [When(@"Provide Required details to Address details")]
        public void WhenProvideRequiredDetailsToAddressDetails()
        {
            _scenarioContext["EmployeeState"] = State;
            //_scenarioContext["EmployeeCity"] = City;
            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employee Address Details");
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver,"Street","EmpStreet");
            SelectValueOfVisible_Sendkey(_driver, "State").SendKeys(State);
            Thread.Sleep(2000);     
            SelectValueOfVisible_Sendkey(_driver,"City").SendKeys(City);
            Thread.Sleep(1000);
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", "85224");
        }

        [Given(@"Wait until success notification invisible")]
        public void GivenWaitUntilSuccessNotificationInvisible()
        {
            Thread.Sleep(1000);
            InvisibleSuccess_Notification(_driver);

        }
        [When(@"Provide Required details to the Education details step (.*)")]
        public void WhenProvideRequiredDetailsToTheEducationDetailsStep(string educationDegree)
        {
            string school = "BVM";
            string schoolState = "OxaBoxi";

            _scenarioContext["educationLevel"] = educationDegree;
            AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "educationLevel").SendKeys(educationDegree);
            Thread.Sleep(1000);
            try
            {
            BaseClass.Scroll(_driver,"Up",400);
            Thread.Sleep(1000);
           _scenarioContext["school"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "School",1);
            Thread.Sleep(4000);
           _scenarioContext["schoolState"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "School State", 1);          
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Graduation / Separation Date").SendKeys(Date.AddYears(1).ToString("MM/dd/yyyy"));
            }
            catch { }
        }
        [When(@"Click on Save\(Green\) button")]
        public void WhenClickOnSaveGreenButton()
        {
            Thread.Sleep(3000);
            AddApicationPOM.ClickOnSaveButton_AddApplicationDetails(_driver);
        }
    
    [Then(@"Validate that the Confirm pop-up displaying properly for less than 2 yr experience the Application")]
    public void ThenValidateThatTheConfirmPop_UpDisplayingProperlyForLessThanYrExperienceTheApplication()
    {
      try
      {
      AddApicationPOM.ClickOnConfirmButton_EmplyerConfirmationPopup_AddApplicationDetails(_driver);      
      }
      catch { }
    }


        [When(@"Click on Back Button")]
        public void WhenClickOnBackButton()
        {
            _scenarioContext["StepNumber"]= AddApicationPOM.CheckSelectedStepNumber_Step(_driver);
            AddApicationPOM.ClickOnBackButton_AddApplicationDetails(_driver);
            Thread.Sleep(1000);
        }

        [Then(@"Validate that the Back button navigate to back step")]
        public void ThenValidateThatTheBackButtonNavigateToBackStep()
        {
            Thread.Sleep(1000);
            string LastStepNumber = (string)_scenarioContext["StepNumber"];
            string CurrentStepNumber = AddApicationPOM.CheckSelectedStepNumber_Step(_driver);
            Assert.That(!LastStepNumber.Contains(CurrentStepNumber));

        }

        [Then(@"Validate that the Same as mailing address working properly")]
        public void ThenValidateThatTheSameAsMailingAddressWorkingProperly()
        {
           
        }


        [When(@"Click on the Cancel button")]
        public void WhenClickOnTheCancelButton()
        {
            AddApicationPOM.ClickOnCancelButton_AddApplicationDetails(_driver);
        }

        [Then(@"Validate that the Cancel button navigate to Application list page")]
        public void ThenValidateThatTheCancelButtonNavigateToApplicationListPage()
        {
            Assert.That(AddApicationPOM.ClickOnAddApplicationButton(_driver).Displayed);
        }
        [Then(@"Validate that the Cancel button navigate to Borrower details page")]
        public void ThenValidateThatTheCancelButtonNavigateToApplicationListPage1()
        {
        Assert.That(AddCoBorrowerPOM.ClickOnAddCoBorrowerButton_ApplicationDetailsPage(_driver).Displayed);
        }

        [When(@"Click on Add Application step (.*)")]
        public void WhenClickOnAddApplicationStep(string stepName)
        {
            AddApicationPOM.ClickOnAddApplication_Step(_driver, stepName.Trim('"'));
            WaitForSpinnerToDisappear(_driver);
            Thread.Sleep(5000);
        }
        [Given(@"Click on Edit loan button")]
        public void GivenClickOnEditLoanButton()
        {
            AddApicationPOM.ClickOnEditLoan_AddApplicationDetails(_driver);
        }

        [When(@"Edit loan details")]
        public void WhenEditLoanDetails()
        {
            string LoanTerm = "5";
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver,"Loan Term (In Months)").Clear();
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Loan Term (In Months)").SendKeys(LoanTerm);
            _scenarioContext["LoanTerm"] = LoanTerm;
        }
        [Given(@"Click on Edit Reference button")]
        public void GivenClickOnEditReferenceButton()
        {
            AddApicationPOM.ClickOnEditReference_AddApplicationDetails (_driver);
            Thread.Sleep(1000);
        }

        [When(@"Edit Reference details")]
        public void WhenEditReferenceDetails()
        {
            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Reference Details");
            var faker = new Faker();
            Thread.Sleep(2000);            
            string FN = faker.Person.FirstName;       
                       
            _scenarioContext["ReferenceFirstName"] = FN;            
            AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "First Name", FN);
        }

        [Then(@"Validate that loan updated properly")]
        public void ThenValidateThatLoanUpdatedProperly()
        {
            BaseClass.Success_Notification(_driver);
        }

        [When(@"Click on Edit button of added card of application")]
        public void WhenClickOnEditFinanceButton()
        {
            AddApicationPOM.ClickOnEditFinance_AddApplicationDetails(_driver);
        }

        [When(@"Edit finance details")]
        public void WhenEditFinanceDetails()
        {
            string IncomeAmount = "50000";
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Income Amount").Clear();
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Income Amount").SendKeys(IncomeAmount);
            _scenarioContext["LoanTerm"] = IncomeAmount;
        }

        [Then(@"Validate that Finance updated properly")]
        public void ThenValidateThatFinanceUpdatedProperly()
        {
            BaseClass.Success_Notification(_driver);
        }

        [When(@"Click on Edit Employment button")]
        public void WhenClickOnEditEmploymentButton()
        {
            AddApicationPOM.ClickOnEditEmployment_AddApplicationDetails(_driver);
        }

        [When(@"Edit Employment details")]
        public void WhenEditEmploymentDetails()
        {
            string EmpName = "EmpNEdited";
            AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employer Details");
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Employer Name").Clear();
            AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Employer Name").SendKeys(EmpName);
            _scenarioContext["LoanTerm"] = EmpName;
        }

        [When(@"Click on Add Employment button")]
        public void WhenClickOnAddEmploymentButton()
        {
            AddApicationPOM.ClickOnAddEmployment_AddApplicationDetails(_driver);
        }
        [Given(@"Click on Delete button")]
        public void GivenClickOnDeleteButton()
        {
                int j=AddApicationPOM.CheckNumberOfDetailsCard_AddApplicationDetails(_driver);
             _scenarioContext["No.OfCard"]=j.ToString();
            AddApicationPOM.ClickOnDeletButton_AddApplicationDetails(_driver);
        }
    [Given(@"Click on Delete button Until only one card remain")]
    public void GivenClickOnDeleteButtonUntilonlyonecardremain()
    {
      int j = AddApicationPOM.CheckNumberOfDetailsCard_AddApplicationDetails(_driver);
      for(int i=j;i>1;i--)
      {
      AddApicationPOM.ClickOnDeletButton_AddApplicationDetails(_driver);
      }

    }

    [Then(@"Validate that the Item deleted successfully")]
        public void ThenValidateThatTheItemDeletedSuccessfully()
        {
            string NoOfCard = (string)_scenarioContext["No.OfCard"];
            int NewNoOfCard= AddApicationPOM.CheckNumberOfDetailsCard_AddApplicationDetails(_driver);
            Assert.That(NoOfCard.Contains((NewNoOfCard+1).ToString()));
        }
        [Then(@"Validate that data displaying properly on Added Card")]
        public void ThenValidateThatDataDisplayingProperlyOnAddedCard()
        {
            IDictionary<string, string>GetData= new Dictionary<string, string>();
            GetData = (IDictionary<string,string>)AddApicationPOM.GetAddedData_AddApplicationDetails(_driver, new string[] {"Relationship","First Name","Middle Initial","Last Name","Email","Country","State","City" });
            //Assert.Multiple(() =>
            //{
                
             Assert.That(GetData["Relationship"].Contains((string)_scenarioContext["Relationship"]));
              string s = (string)_scenarioContext["ReferenceFN"];
             Assert.That(GetData["First Name"].Contains((string)_scenarioContext["ReferenceFN"]));
             Assert.That(GetData["Middle Initial"].Contains((string)_scenarioContext["ReferenceMN"]));
             Assert.That(GetData["Email"].Contains((string)_scenarioContext["Email"]));
             Assert.That(GetData["Country"].Contains("USA"));
             Assert.That(GetData["State"].Contains((string)_scenarioContext["State"]));
             Assert.That(GetData["City"].Contains((string)_scenarioContext["City"]));
             Assert.That(GetData["Last Name"].Contains((string)_scenarioContext["ReferenceLN"]));
            //});
            

        }

        [Then(@"Validate that the Borrower details page show Personal details properly")]
        public void ThenValidateThatTheBorrowerDetailsPageShowDetailsProperly()
        {
            IDictionary<string, string> personalDic = new Dictionary<string, string>();
            Thread.Sleep(10000);
            string[] dataKey = { "Name", JsonData()["SSN"], "Date Of Birth", "Is US Citizen", "Drivers License State Code", "Drivers License #" };
             personalDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver,"Personal Details", dataKey);
             
                Assert.IsTrue(personalDic[dataKey[0]].Contains($"{(string)_scenarioContext["PersonalFN"]} {(string)_scenarioContext["PersonalMN"]} {(string)_scenarioContext["PersonalLN"]}".ToUpper()), $"Validation failed for element {dataKey[0]}");
               // Assert.AreEqual(personalDic[dataKey[1]], (string)_scenarioContext["PersonalMN"], $"Validation failed for element {dataKey[1]}");
               // Assert.AreEqual(personalDic[dataKey[2]], (string)_scenarioContext["PersonalLN"], $"Validation failed for element {dataKey[2]}");
                string ssn = ((string)_scenarioContext["PersonalSSN"]);
                 string us = (string)_scenarioContext["IsUSCitizen"];
                Assert.IsTrue(personalDic[dataKey[1]].Contains( ssn.Substring(ssn.Length-4)), $"Validation failed for element {dataKey[1]}");
                Assert.AreEqual(personalDic[dataKey[3]], (string)_scenarioContext["IsUSCitizen"], $"Validation failed for element {dataKey[3]}");
                Assert.AreEqual(personalDic[dataKey[4]], (string)_scenarioContext["DriversLicenceStateCode"], $"Validation failed for element {dataKey[4]}");
                Assert.AreEqual(personalDic[dataKey[5]], (string)_scenarioContext["DriverLicence"], $"Validation failed for element {dataKey[5]}");

           
            
        }
   

        [Then(@"Validate that the Borrower details page show Contact details properly")]
    
        public void ThenValidateThatTheBorrowerDetailsPageShowContactDetailsProperly()
        {
            //AddApicationPOM.ClickOnShowMore_BorrowerDetails_AddApplicationDetails(_driver);
            IDictionary<string, string> contactDic = new Dictionary<string, string>();

            string[] dataKey = { "Email", "Alternative Email", "Phone", "Home Number", "Other Number" };
            contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Contact Details", dataKey);
           // Assert.Multiple(() =>
           // {              
      

                Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["ContactEmail"], $"Validation failed for element {dataKey[0]}");
      
     
                Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["ContactAltEmail"], $"Validation failed for element {dataKey[1]}");

     
                Assert.AreEqual((contactDic[dataKey[2]]).Trim('(').Replace(")", "").Replace(" ", "").Replace("-", ""),(string)_scenarioContext["ContactPhone"], $"Validation failed for element {dataKey[2]}");

      
                Assert.AreEqual((contactDic[dataKey[3]]).Trim('(').Replace(")", "").Replace(" ", "").Replace("-", ""), (string)_scenarioContext["ContactHome"], $"Validation failed for element {dataKey[3]}");

     
                Assert.AreEqual((contactDic[dataKey[4]]).Trim('(').Replace(")", "").Replace(" ", "").Replace("-", ""), (string)_scenarioContext["ContactOther"], $"Validation failed for element {dataKey[4]}");

      

           // });
        }
    [When(@"Click on show more")]
    public void WhenClickOnShowMore()
    {
      Thread.Sleep(1000);
      AddApicationPOM.ClickOnShowMore_BorrowerDetails_AddApplicationDetails(_driver);
    }
    [Then(@"Validate that the Borrower details page show Physical Address properly")]
    
        public void ThenValidateThatTheBorrowerDetailsPageShowPhysicalAddressProperly()
        {
            
            IDictionary<string, string> contactDic = new Dictionary<string, string>();

            string[] dataKey = {"Country", JsonData()["State"],JsonData()["City"], "Zip Code" };
            contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Physical Address", dataKey);
        try
        {
            //Assert.Multiple(() =>
            //{
                Assert.AreEqual(contactDic[dataKey[0]], "USA", $"Validation failed for element {dataKey[0]}");
                Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["MailingState"], $"Validation failed for element {dataKey[1]}");
                Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["MailingCity"], $"Validation failed for element {dataKey[2]}");
              
             
                //Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["PhysicalState"], $"Validation failed for element {dataKey[1]}");
                //Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["PhysicalCity"], $"Validation failed for element {dataKey[2]}");
                Assert.IsTrue(contactDic[dataKey[3]].Contains( (string)_scenarioContext["Zipcode"]), $"Validation failed for element {dataKey[3]}");

            //});
         }catch { }
        }
    [Then(@"Validate that the Borrower details page show Other details properly")]
    
        public void ThenValidateThatTheBorrowerDetailsPageShowOtherDetailsProperly()
        {
            IDictionary<string, string> contactDic = new Dictionary<string, string>();

            string[] dataKey = { "Country", JsonData()["State"], JsonData()["City"], "Zip Code" };
            contactDic = (IDictionary<string, string>)GetAddedData_BorrowerDetails_AddApplicationDetails_withExpansionCard(_driver, "Other", dataKey);
      
                string a = (string)_scenarioContext["OtherState"];
                Assert.AreEqual(contactDic[dataKey[0]], "USA", $"Validation failed for element {dataKey[0]}");
                Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["OtherState"], $"Validation failed for element {dataKey[1]}");
                Thread.Sleep(3000);
                Assert.IsTrue(contactDic[dataKey[2]].Contains( (string)_scenarioContext["OtherCity"]), $"Validation failed for element {dataKey[2]}");
                Assert.AreEqual(contactDic[dataKey[3]], (string)_scenarioContext["Zipcode"], $"Validation failed for element {dataKey[3]}");
        
        }
    [Then(@"Validate that the Borrower details page show Mailing Address properly")]
    
        public void ThenValidateThatTheBorrowerDetailsPageShowMailingAddressProperly()
        {
            IDictionary<string, string> contactDic = new Dictionary<string, string>();

            string[] dataKey = { "Country", JsonData()["State"], JsonData()["City"], "Zip Code" };
            contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Mailing Address", dataKey);
            //Assert.Multiple(() =>
            //{
                Assert.AreEqual(contactDic[dataKey[0]], "USA", $"Validation failed for element {dataKey[0]}");
                Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["MailingState"], $"Validation failed for element {dataKey[1]}");
                Assert.IsTrue(contactDic[dataKey[2]].Contains( (string)_scenarioContext["MailingCity"]), $"Validation failed for element {dataKey[2]}");
                Assert.AreEqual(contactDic[dataKey[3]], (string)_scenarioContext["Zipcode"], $"Validation failed for element {dataKey[3]}");
            //});
        }
    [Then(@"Validate that the Borrower details page show Reference details properly")]
    
        public void ThenValidateThatTheBorrowerDetailsPageShowReferenceDetailsProperly()
        {
            IDictionary<string, string> contactDic = new Dictionary<string, string>();

            string[] dataKey = { "Relationship", "First Name", "Middle Name", "Last Name","Email","Phone Number", JsonData()["Address"] };
            contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Reference Details", dataKey);
           // Assert.Multiple(() =>
           // {
               string e = ((string)_scenarioContext["Phone"]).FormatAsPhoneNumber();
     
                Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["Relationship"], $"Validation failed for element {dataKey[0]}");
                Assert.IsTrue(contactDic[dataKey[1]].Contains( (string)_scenarioContext["ReferenceFN"]), $"Validation failed for element {dataKey[1]}");
                Assert.IsTrue(contactDic[dataKey[2]].Contains((string)_scenarioContext["ReferenceMN"]), $"Validation failed for element {dataKey[2]}");
                Assert.IsTrue(contactDic[dataKey[3]].Contains((string)_scenarioContext["ReferenceLN"]), $"Validation failed for element {dataKey[3]}");
                Assert.IsTrue(contactDic[dataKey[4]].Contains((string)_scenarioContext["Email"]), $"Validation failed for element {dataKey[4]}");
                Assert.AreEqual(contactDic[dataKey[5]], ((string)_scenarioContext["Phone"]).FormatAsPhoneNumber(), $"Validation failed for element {dataKey[5]}");
                Assert.IsTrue(contactDic[dataKey[6]].Contains( "USA"), $"Validation failed for element {dataKey[6]}");
                Assert.IsTrue(contactDic[dataKey[6]].Contains( (string)_scenarioContext["State"]), $"Validation failed for element {dataKey[6]}");
                Assert.IsTrue(contactDic[dataKey[6]].Contains((string)_scenarioContext["City"]), $"Validation failed for element {dataKey[6]}");
                Assert.IsTrue(contactDic[dataKey[6]].Contains( (string)_scenarioContext["Zipcode"]), $"Validation failed for element {dataKey[6]}");

           // });
        }
    [Then(@"Validate that the Borrower details page show Employment details properly")]
    
        public void ThenValidateThatTheBorrowerDetailsPageShowEmploymentDetailsProperly()
        {
            IDictionary<string, string> contactDic = new Dictionary<string, string>();

            string[] dataKey = { "Employer Name", "Employer Email", "Phone Number", "Employment Type", "Position", "No of Hours Per week", JsonData()["EmployerAddress"] };
            contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Employment Details", dataKey);
           // Assert.Multiple(() =>
           // {              
                Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["EmployeeEmpName"], $"Validation failed for element {dataKey[0]}");
                Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["EmployeeEmail"], $"Validation failed for element {dataKey[1]}");
                Assert.AreEqual(contactDic[dataKey[2]], ((string)_scenarioContext["EmployeePhone"]).FormatAsPhoneNumber(), $"Validation failed for element {dataKey[2]}");
                Assert.AreEqual(contactDic[dataKey[3]], (string)_scenarioContext["EmployeeType"], $"Validation failed for element {dataKey[3]}");
                Assert.AreEqual(contactDic[dataKey[4]], (string)_scenarioContext["Position"], $"Validation failed for element {dataKey[4]}");
                Assert.AreEqual(contactDic[dataKey[5]], (string)_scenarioContext["HoursPerWeek"], $"Validation failed for element {dataKey[5]}");//
                Assert.IsTrue(contactDic[dataKey[6]].Contains( "USA"), $"Validation failed for element {dataKey[6]}");
                Assert.IsTrue(contactDic[dataKey[6]].Contains( (string)_scenarioContext["EmployeeState"]), $"Validation failed for element {dataKey[6]}");
                Assert.IsTrue(contactDic[dataKey[6]].Contains( (string)_scenarioContext["EmployeeCity"]), $"Validation failed for element {dataKey[6]}");
                Assert.IsTrue(contactDic[dataKey[6]].Contains( (string)_scenarioContext["Zipcode"]), $"Validation failed for element {dataKey[6]}");
           // });
        }
    [Then(@"Validate that the Borrower details page show Education details properly")]
    
        public void ThenValidateThatTheBorrowerDetailsPageShowEducationDetailsProperly()
        {
            IDictionary<string, string> contactDic = new Dictionary<string, string>();

            string[] dataKey = { "Education Level", "School Name", "School State"};
            contactDic = (IDictionary<string, string>)AddApicationPOM.GetAddedData_BorrowerDetails_AddApplicationDetails(_driver, "Education Details", dataKey);
          
                Assert.AreEqual(contactDic[dataKey[0]], (string)_scenarioContext["educationLevel"], $"Validation failed for element {dataKey[0]}");
                Assert.AreEqual(contactDic[dataKey[1]], (string)_scenarioContext["school"], $"Validation failed for element {dataKey[1]}");
                Assert.AreEqual(contactDic[dataKey[2]], (string)_scenarioContext["schoolState"], $"Validation failed for element {dataKey[2]}");                         
           
        }

      [When(@"Click on Edit-Application button")]
      public void WhenClickOnEdit_ApplicationButton()
      {
       AddApicationPOM.ClickOnEditApplicationButton_AddApplicationDetails(_driver,1);
      WaitForSpinnerToDisappear(_driver);
    }

    //************************************************************************BorrowerPage of Servicing*******************************************************************************
    [When(@"Click on The Edit button")]
    public void WhenClickOnTheEditButton()
    {
      BorrowerPagePOM.ClickOnEiditButton_BorrowerPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }

  }
}
