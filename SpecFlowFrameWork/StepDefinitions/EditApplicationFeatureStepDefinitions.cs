using AventStack.ExtentReports;
using AventStack.ExtentReports.Utils;
using Bogus;
using Bogus.DataSets;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowFrameWork.Utility;
using System;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.Origination.ManageApplication;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class EditApplicationFeatureStepDefinitions:BaseClass
  {
    private readonly IWebDriver _driver;

    private ScenarioContext _scenarioContext;
    private ExtentTest _scenario;

    public EditApplicationFeatureStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
    {
      _driver = driver;
      _scenarioContext = scenarioContext;

    }
    public static Dictionary<string, string> JsonData()
    {
      string Path = GetDataParser().TestData_Path("ApplicationTD");
      var testData = new Dictionary<String, String>();

      testData.Add("PreferredMethodOfContact", GetDataParser().TestData("PreferredMethodOfContact", Path));
      testData.Add("IncomeType", GetDataParser().TestData("IncomeType", Path));
      testData.Add("IncomeFrequency", GetDataParser().TestData("IncomeFrequency", Path));
      testData.Add("IncomeAmount", GetDataParser().TestData("IncomeAmount", Path));
      testData.Add("DoyouhaveaSavingCheckingAccount", GetDataParser().TestData("DoyouhaveaSavingCheckingAccount", Path));

      return testData;
    }


    [When(@"Edit details of contact details step (.*), (.*)")]
        public void WhenEditDetailsOfContactDetailsStep(string Email, string BestTimeToCall)
        {
      var faker = new Faker();

      string email = faker.Person.Email;
      string altEmail = Email;
      string Phone = "1111111111";
      string home = "2222222222";
      string other = "3333333333";
      string PersonalFN = faker.Person.FirstName;
      string PersonalMN = "Trebor";
      string PersonalLN = "Uchake";

      _scenarioContext["PersonalFN"] = PersonalFN;
      _scenarioContext["PersonalMN"] = PersonalMN;
      _scenarioContext["PersonalLN"] = PersonalLN;
      _scenarioContext["ContactEmail"] = email;
      _scenarioContext["ContactAltEmail"] = Email;
      _scenarioContext["ContactPhone"] = Phone;
      _scenarioContext["ContactHome"] = home;
      _scenarioContext["ContactOther"] = other;

      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "First Name").SendKeys(PersonalFN);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Middle Name").SendKeys(PersonalMN);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Last Name").SendKeys(PersonalLN);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Email").Clear();
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Email").SendKeys(faker.Person.Email);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Alt. Email").Clear();
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Alt. Email").SendKeys(Email);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone cell").Clear();
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone cell").SendKeys(Phone);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone Home").Clear();
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone Home").SendKeys(home);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone Other").Clear();
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Phone Other").SendKeys(other);
      //AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "bestTimeToCall").Clear();
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "bestTimeToCall").SendKeys(BestTimeToCall);

      try
      {
        //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, JsonData()["AddressPreference"]).SendKeys("preferredAddress");
        AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, JsonData()["PreferredMethodOfContact"]).SendKeys("contact");
      }
      catch
      {

      }
    }

        [When(@"Edit details of Personal details step")]
        public void WhenEditDetailsOfPersonalDetailsStep()
        {
      var faker = new Faker();
      string PersonalSSN = "123456789";
      string Datee = Date.ToString("MM/dd/yyyy");
      string DriversLicenceStateCode = "GU";
      string DriverLicence = "4567";
      string borrowerName = "Edited";
      string maidenName = "Uchali";
      string previousName = "Bert";

      //Set data to scenario context
      _scenarioContext["PersonalSSN"] = PersonalSSN;
      _scenarioContext["Datee"] = Datee;
      _scenarioContext["DriversLicenceStateCode"] = DriversLicenceStateCode;
      _scenarioContext["DriverLicence"] = DriverLicence;
      _scenarioContext["BorrowerSource"] = borrowerName;
      _scenarioContext["MaidenName"] = maidenName;
      _scenarioContext["PreviousName"] = previousName;

      if (!AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "SSN").Enabled)
      {
        AddApicationPOM.ClickOnVisibilityButton_AddApplicationDetails(_driver);
        Thread.Sleep(3000);
      }

      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);    
                 
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Previous Name").SendKeys(previousName);     
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Maiden Name").SendKeys(maidenName);     
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "SSN").SendKeys(PersonalSSN);  
      Thread.Sleep(1000);
      int a=AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Date Of Birth").GetAttribute("value").Length;
        while (AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Date Of Birth").GetAttribute("value").Length != 0)
      {
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Date Of Birth").SendKeys(Keys.Backspace);   
      }
      Thread.Sleep(1000);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Date Of Birth").SendKeys(Datee);
      Thread.Sleep(1000);     
      while(AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Expiration Date").GetAttribute("value").Length != 0)
      {
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Expiration Date").SendKeys(Keys.Backspace);
      }
      Thread.Sleep(1000);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Expiration Date").SendKeys(Date.AddDays(1).ToString("MM/dd/yyyy"));
      Thread.Sleep(1000);      
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Number").SendKeys(DriverLicence);      
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Borrower Source").SendKeys(borrowerName);      
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "driversLicense").SendKeys(DriversLicenceStateCode);
      Thread.Sleep(1000);

     
    }

        [When(@"Edit details of Mailing Address")]
        public void WhenEditDetailsOfMailingAddress()
        {
      _scenarioContext["Zipcode"] = Zipcode;
      _scenarioContext["MailingState"] = State;
      _scenarioContext["MailingCity"] = City;
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street Address", "street");
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", Zipcode);
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "mailingState").SendKeys(State);
      Thread.Sleep(3000);
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "mailingCity").SendKeys(City);
     //_scenarioContext["MailingCity"]= AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "City",1);
      Thread.Sleep(1000);
    }

        [When(@"Edit details of Physical Address")]
        public void WhenEditDetailsOfPhysicalAddress()
        {
      _scenarioContext["PhysicalState"] = State;
      _scenarioContext["PhysicalCity"] = City;
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "physicalState").SendKeys(State);
      Thread.Sleep(1000);
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "physicalCity").SendKeys(City);
      Thread.Sleep(1000);
    }

        [When(@"Edit details of Other Address")]
        public void WhenEditDetailsOfOtherAddress()
        {
      _scenarioContext["OtherState"] = State;
      _scenarioContext["OtherCity"] = City;
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "otherState").SendKeys(State);
      Thread.Sleep(1000);
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "otherCity").SendKeys(City);
      Thread.Sleep(1000);
    }

        [When(@"Edit details of Reference Details (.*)")]
        public void WhenEditDetailsOfReferenceDetailsSpouse(string Relationship)
        {
      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Reference Details");
      var faker = new Faker();
      Thread.Sleep(2000);
      AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Relationship").SendKeys(Relationship);
      Thread.Sleep(1000);
      string FN = faker.Person.FirstName;
      string MI = "Rajwon";
      string LN = "kumbar";

      _scenarioContext["Relationship"] = Relationship;
      _scenarioContext["ReferenceFN"] = FN;
      _scenarioContext["ReferenceMN"] = MI;
      _scenarioContext["ReferenceLN"] = LN;
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "First Name", FN);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Middle Initial", MI);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Last Name", LN);

      Thread.Sleep(1000);
      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Reference Details","close");
    }

        [When(@"Edit details of Reference Contact details")]
        public void WhenEditDetailsOfReferenceContactDetails()
        {
      string Email = "Refernce@yopmail.com";
      string Phone = "1234567890";
      _scenarioContext["Email"] = Email;
      _scenarioContext["Phone"] = Phone;

      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Contact Details");
      Thread.Sleep(1000);
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Email", Email);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Phone", Phone);

      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Contact Details","close");
    }

        [When(@"Edit details of Reference Address details")]
        public void WhenEditDetailsOfReferenceAddressDetails()
        {
      string state = State2;
      string city = City2;
      _scenarioContext["State"] = state;
      _scenarioContext["City"] = city;
      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Address Details");
      Thread.Sleep(1000);
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", "street");
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", "85224");

      Thread.Sleep(1000);
      AddApicationPOM.SelectValueForMultipleField_AddApplicationDetails(_driver, "referenceState", new string[] { state });
      Thread.Sleep(2000);
      AddApicationPOM.SelectValueForMultipleField_AddApplicationDetails(_driver, "referenceCity", new string[] { city });
      Thread.Sleep(1000);

      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Address Details","close");
    }

        [When(@"Edit details of loan details step (.*), (.*)")]
        public void WhenEditDetailsOfLoanDetailsStepAESEducation(string Agency, string TypeOfLoan)
        {
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Loan Requested Amount").SendKeys("3000");
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Loan Term (In Months)").SendKeys("3");
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Aging (In Months)").SendKeys("500");
      Thread.Sleep(1000);
      _scenarioContext["AgencyValue"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "Agency", 1);
      Thread.Sleep(1000);

      AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Type Of Loan").SendKeys(TypeOfLoan);
      Thread.Sleep(1000);
      _scenarioContext["LoanCategory"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "Loan Category", 0);
      Thread.Sleep(1000);
    }

        [When(@"Edit details of Financial details (.*), (.*)")]
        public void WhenEditDetailsOfFinancialDetailsPaycheckWeekly(string IncomeType, string IncomeFrequency)
        {
      string amount = "40000";
      string note = "Noted";
      _scenarioContext["FinanceAmount"] = amount;
      _scenarioContext["FinanceNote"]=note;
      _scenarioContext["IncomeType"] = IncomeType;
      _scenarioContext["IncomeFrequency"] = IncomeFrequency;
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Income Amount").SendKeys(amount);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Notes").SendKeys(note);
      AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Income Type").SendKeys(IncomeType);
      Thread.Sleep(1000);
      AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Income Frequency").SendKeys(IncomeFrequency);
      Thread.Sleep(1000);
        }

        [When(@"Edit details of Employee details (.*)")]
        public void WhenEditDetailsOfEmployeeDetailsPartTimeEmployement(string EmploymentType)
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



      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employer Details");
      AddApicationPOM.SelectValueLoanDetails_AddApplicationDetails(_driver, "Employment Type").SendKeys(EmploymentType);
      Thread.Sleep(2000);
      if(!EmploymentType.ToLower().Contains("unemployed"))
      {
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Position").SendKeys(Position);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Employer Name").SendKeys(EmployerEmpName);
      Thread.Sleep(1000);
        if(!EmploymentType.ToLower().Contains("retired"))
        {
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Start Date").SendKeys(Date.AddYears(-2).ToString("MM/dd/yyyy"));
      if(AddApicationPOM.CheckThatBox_AddApplicationDetails(_driver,"Still Working").GetAttribute("aria-checked").Contains("false"))
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "End Date").SendKeys(Date.AddYears(-1).ToString("MM/dd/yyyy"));
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "No. of Hours Per Week").SendKeys(HoursPerWeek);
        }

        //if (EmploymentType.ToLower().Contains("retired"))
        //  AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "End Date").SendKeys(Date.AddYears(-1).ToString("MM/dd/yyyy"));
      }
      //AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employer Details","close");

    }

        [When(@"Edit details of Contact details")]
        public void WhenEditDetailsOfContactDetails()
        {
      string Phone = "4444444444";
      var faker = new Faker();
      string email = faker.Person.Email;

      _scenarioContext["EmployeeEmail"] = email;
      _scenarioContext["EmployeePhone"] = Phone;

      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employee Contact Details");
      Thread.Sleep(1000);
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Email", email);
      Thread.Sleep(1000);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Phone Number", "4444444444");

      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employee Contact Details","close");
    }

        [When(@"Edit details of Address details")]
        public void WhenEditDetailsOfAddressDetails()
        {
      
      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employee Address Details");
      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Street", "EmpStreet");
      AddApicationPOM.EnterInputValueToMultipleField_AddApplicationDetails(_driver, "Zipcode", "85224");
      _scenarioContext["EmployeeState"]=AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "State",1);
      Thread.Sleep(3000);
      _scenarioContext["EmployeeCity"]=AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "City",1);
      Thread.Sleep(1000);

      AddApicationPOM.ExpandEmploymentDetailsInnerCard_AddApplicationDetails(_driver, "Employee Address Details","close");
    }

        [When(@"Edit details of the Education details step (.*)")]
        public void WhenEditDetailsOfTheEducationDetailsStepAssociateDegree(string educationDegree)
        {
      string school = "BVM";
      string schoolState = "OxaBoxi";

      _scenarioContext["educationLevel"] = educationDegree;
      _scenarioContext["school"] = school;
      _scenarioContext["schoolState"] = schoolState;
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "educationLevel").SendKeys(educationDegree);
      Thread.Sleep(1000);
      try
      {

        _scenarioContext["school"]= AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "School",1);

        _scenarioContext["schoolState"] = AddApicationPOM.SelectOptionDetails_DropDown_AddApplicationDetails(_driver, "School State",1);
        while(AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Graduation / Separation Date").GetAttribute("value").Length!=0)
        {
          AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Graduation / Separation Date").SendKeys(Keys.Backspace);
        }
        AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Graduation / Separation Date").SendKeys(Date.AddYears(1).ToString());
      }
      catch { }
        }
    [When(@"Edit loan details using Edit loan button")]
    public void WhenEditLoanDetails()
    {
      string LoanTerm = "5";
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Loan Term (In Months)").Clear();
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Loan Term (In Months)").SendKeys(LoanTerm);
      _scenarioContext["LoanTerm"] = LoanTerm;

    }
    [When(@"Edit Required value to Personal details step")]
    public void WhenEditRequiredValueToPersonalDetailsStep()
    {  
    var faker = new Faker();
    string PersonalFN = faker.Person.FirstName;
    string PersonalMN = "Trebor";
    string PersonalLN = "Uchake";
    string PersonalSSN = "123456789";
    string Datee = Date.ToString("MM/dd/yyyy");
    string DriversLicenceStateCode = "GU";
    string DriverLicence = "4567";

    //Set data to scenario context
    _scenarioContext["PersonalFN"] = PersonalFN;
    _scenarioContext["PersonalMN"] = PersonalMN;
    _scenarioContext["PersonalLN"] = PersonalLN;
    _scenarioContext["PersonalSSN"] = PersonalSSN;
    _scenarioContext["Datee"] = Datee;
    _scenarioContext["DriversLicenceStateCode"] = DriversLicenceStateCode;
    _scenarioContext["DriverLicence"] = DriverLicence;


      if(!AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "SSN").Enabled)
      {
        AddApicationPOM.ClickOnVisibilityButton_AddApplicationDetails(_driver);
        Thread.Sleep(3000);
      }

      AddApicationPOM.ClearAllInput_AddApplicationDetails(_driver);
      //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "First Name").SendKeys(PersonalFN);        
      //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Middle Name").SendKeys(PersonalMN);    
      //AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Last Name").SendKeys(PersonalLN);
      
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Previous Name").SendKeys("Bert");     
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Maiden Name").SendKeys("Uchali");
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "SSN").SendKeys(PersonalSSN);      
      Thread.Sleep(1000);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Date Of Birth").SendKeys(Datee);     
      Thread.Sleep(1000);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Expiration Date").SendKeys(Date.AddDays(1).ToString("MM/dd/yyyy"));      
      Thread.Sleep(1000);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "License Number").SendKeys(DriverLicence);      
      Thread.Sleep(1000);
      AddApicationPOM.EnterInputValue_AddApplicationDetails(_driver, "Borrower Source").SendKeys("Source");     
      Thread.Sleep(1000);
      AddApicationPOM.SelectValue_AddApplicationDetails(_driver, "driversLicense").SendKeys(DriversLicenceStateCode);
      Thread.Sleep(1000);
      }

    [Given(@"Wait Until Load all element on Borrower details page")]
    public void GivenWaitUntilLoadAllElementOnBorrowerDetailsPage()
    {
      string Xpath = $"//mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = _driver.FindElements(By.XPath(Xpath));
      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


    }

  }
}
