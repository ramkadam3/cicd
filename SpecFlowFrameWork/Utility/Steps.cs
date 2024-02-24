using BoDi;
using FinanceModule.Hooks;
using OpenQA.Selenium;
using SpecFlowFrameWork.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowFrameWork.Utility
{
    [Binding]
    public class Steps:BaseClass
    {
        
        private IWebDriver _driver;
       

        private ScenarioContext _scenarioContext;
        // private readonly IThreadSafeTraceListener _traceListener;
        //LoginAutomationPage LoginAutomationPage;
        


        public Steps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this._driver =driver;
            this._scenarioContext = scenarioContext;            
        }
        public static Dictionary<string, string> JsonData()
        {
            string Path = GetDataParser().TestData_Path("LoginCredentialsTD");
            var testData = new Dictionary<String, String>();

            testData.Add("User_Email", GetDataParser().TestData("User_Email", Path));
            testData.Add("User_Password", GetDataParser().TestData("User_Password", Path));



     string Path1= GetDataParser().TestData_Path("RoleCredencialTD");
      testData.Add("SystemAdmin", GetDataParser().TestData("SystemAdmin", Path1));
      testData.Add("CompanyManager", GetDataParser().TestData("CompanyManager", Path1));
      testData.Add("BDFinder", GetDataParser().TestData("BDFinder", Path1));
      testData.Add("RIAFinder", GetDataParser().TestData("RIAFinder", Path1));
      testData.Add("FinderFinder", GetDataParser().TestData("FinderFinder", Path1));
      testData.Add("MRIAAdmin", GetDataParser().TestData("MRIAAdmin", Path1));
      testData.Add("MRIAUser", GetDataParser().TestData("MRIAUser", Path1));
      testData.Add("MRIAAccountManager", GetDataParser().TestData("MRIAAccountManager", Path1));
      testData.Add("MRIAAccountUser", GetDataParser().TestData("MRIAAccountUser", Path1));

      testData.Add("IndividualInvestor", GetDataParser().TestData("IndividualInvestor", Path1));
      testData.Add("Finder", GetDataParser().TestData("Finder", Path1));
      testData.Add("SalesRep", GetDataParser().TestData("SalesRep", Path1));
      testData.Add("LLCAdmin", GetDataParser().TestData("LLCAdmin", Path1));
      testData.Add("LLCUser", GetDataParser().TestData("LLCUser", Path1));

      testData.Add("ScorpAdmin", GetDataParser().TestData("ScorpAdmin", Path1));
      testData.Add("ScorpUser", GetDataParser().TestData("ScorpUser", Path1));
      testData.Add("PartnershipAdmin", GetDataParser().TestData("PartnershipAdmin", Path1));
      testData.Add("PartnershipUser", GetDataParser().TestData("PartnershipUser", Path1));

      testData.Add("CcorpAdmin", GetDataParser().TestData("CcorpAdmin", Path1));
      testData.Add("CcorpUser", GetDataParser().TestData("CcorpUser", Path1));
      testData.Add("TrustAdmin", GetDataParser().TestData("TrustAdmin", Path1));
      testData.Add("TrustUser", GetDataParser().TestData("TrustUser", Path1));
      testData.Add("IRAAdmin", GetDataParser().TestData("IRAAdmin", Path1));
      testData.Add("IRAUser", GetDataParser().TestData("IRAUser", Path1));
      return testData;
        }

        [Given(@"launch the application (.*)")]
        public void GivenLaunchTheApplication(string Browser)
        {
             BaseClass Basee = new BaseClass();
            _driver = Basee.BrowserLaunch(_driver, Test_Url);
            _driver.Manage().Window.Maximize();     
        }
        [Given(@"Enter Email_PassWord for Login (.*)")]
        public void EnterEmail_PasswordForLogin( string Email)
        {
            LoginPOM.EnterUsername(_driver, Email);
            LoginPOM.EnterPassword(_driver, JsonData()["User_Password"]);
            LoginPOM.ClickOnSubmitButton(_driver);
            WaitForSpinnerToDisappear(_driver);
        }

    [Given(@"Login to Profile (.*)")]
    public void LogintoProfile(string profileName)
    {
      if (profileName.ToLower().Contains("systemadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["SystemAdmin"]);
      if (profileName.ToLower().Contains("companymanager"))
      LoginPOM.EnterUsername(_driver, JsonData()["CompanyManager"]);
      if (profileName.ToLower().Contains("bdfinder"))
        LoginPOM.EnterUsername(_driver, JsonData()["BDFinder"]);
      if (profileName.ToLower().Contains("riafinder"))
        LoginPOM.EnterUsername(_driver, JsonData()["RIAFinder"]);
      if (profileName.ToLower().Contains("finderfinder"))
        LoginPOM.EnterUsername(_driver, JsonData()["FinderFinder"]);
      if (profileName.ToLower().Contains("mriaadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["MRIAAdmin"]);
      if (profileName.ToLower().Contains("mriauser"))
        LoginPOM.EnterUsername(_driver, JsonData()["MRIAUser"]);
      if (profileName.ToLower().Contains("mriaaccountmanager"))
        LoginPOM.EnterUsername(_driver, JsonData()["MRIAAccountManager"]);
      if (profileName.ToLower().Contains("mriaaccountuser"))
        LoginPOM.EnterUsername(_driver, JsonData()["MRIAAccountUser"]);
      if (profileName.ToLower().Contains("individualinvestor"))
        LoginPOM.EnterUsername(_driver, JsonData()["IndividualInvestor"]);
      if (profileName.ToLower()=="finder")
        LoginPOM.EnterUsername(_driver, JsonData()["Finder"]);
      if (profileName.ToLower().Contains("salesrep"))
        LoginPOM.EnterUsername(_driver, JsonData()["SalesRep"]);

      if (profileName.ToLower().Contains("llcadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["LLCAdmin"]);
      if (profileName.ToLower().Contains("lluser"))
        LoginPOM.EnterUsername(_driver, JsonData()["LLCUser"]);

      if (profileName.ToLower().Contains("scorpadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["ScorpAdmin"]);
      if (profileName.ToLower().Contains("scorpuser"))
        LoginPOM.EnterUsername(_driver, JsonData()["ScorpUser"]);
      if (profileName.ToLower().Contains("ccorpadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["CcorpAdmin"]);
      if (profileName.ToLower().Contains("ccorpuser"))
        LoginPOM.EnterUsername(_driver, JsonData()["CcorpUser"]);
      if (profileName.ToLower().Contains("partnershipadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["PartnershipAdmin"]);
      if (profileName.ToLower().Contains("partnershipuser"))
        LoginPOM.EnterUsername(_driver, JsonData()["PartnershipUser"]);

      if (profileName.ToLower().Contains("trustadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["TrustAdmin"]);
      if (profileName.ToLower().Contains("trustuser"))
        LoginPOM.EnterUsername(_driver, JsonData()["TrustUser"]);
      if (profileName.ToLower().Contains("iraadmin"))
        LoginPOM.EnterUsername(_driver, JsonData()["IRAAdmin"]);
      if (profileName.ToLower().Contains("irauser"))
        LoginPOM.EnterUsername(_driver, JsonData()["IRAUser"]);
      
       
      _scenarioContext["ProfileLogin"] = _driver.FindElement(By.XPath("//input[@id='email']")).GetAttribute("value");
      LoginPOM.EnterPassword(_driver, JsonData()["User_Password"]);
                      LoginPOM.ClickOnSubmitButton(_driver);
                      WaitForSpinnerToDisappear(_driver);
    }

    [When(@"Enter the User email")]
        public void WhenEnterTheEmail()
        {
            string Email = JsonData()["User_Email"];
            //LoginAutomationPage = new LoginAutomationPage(_driver);
            LoginPOM.EnterUsername(_driver,Email);
            Thread.Sleep(1000);
        }

        

        [When(@"Enter the User password")]
        private void WhenEnterThePassword()
        {
            string Password = JsonData()["User_Password"];
            LoginPOM.EnterPassword(_driver,Password);

        }
        [Given(@"Switch User-Account to (.*)")]
        public void GivenSwitchAccountToAtestmanagerYopmail_Com(string User_Email)
        {
            LoginPOM.Logout(_driver);
            LoginPOM.EnterUsername(_driver, User_Email);
            LoginPOM.EnterPassword(_driver, JsonData()["User_Password"]);
            LoginPOM.ClickOnSubmitButton(_driver);
            WaitForSpinnerToDisappear(_driver);

        }
    [Given(@"Logout the profile account")]
    public void GivenLogoutTheProfileAccount()
    {
      LoginPOM.Logout(_driver);
    }


  }
}
