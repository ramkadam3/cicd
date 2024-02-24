using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowFrameWork.Pages;
using OpenQA.Selenium;
using SpecFlowFrameWork.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FinanceModule.Hooks;
using TechTalk.SpecFlow.Tracing;
using AventStack.ExtentReports.Gherkin.Model;
using System.Buffers.Text;
using OpenQA.Selenium.Chrome;
using SpecFlowFrameWork.Driver;
using Yrefy_AutomationProject.Driver;
using BoDi;

namespace SpecFlowFrameWork.StepDefinitions
{
    
    [Binding]
    public class LoginAutomationStepDefinitions : ExtentReport
    {
        //private string Path;
        private JToken TestDataSet;
        private IWebDriver _driver;
        
        private ScenarioContext _scenarioContext;
        
        private ExtentTest scenario;
    private readonly IObjectContainer _container;

    public LoginAutomationStepDefinitions( IWebDriver driver, IObjectContainer container,ScenarioContext scenarioContext)
        {
            this._driver = driver;
            _scenarioContext = scenarioContext;
            _container = container;
            this.scenario = (ExtentTest)_scenarioContext["scenario"];
        }


        public static Dictionary<string,string> JsonData()
        {
            string Path = GetDataParser().TestData_Path("LoginCredentialsTD");
            var testData = new Dictionary<String,String>();
      testData.Add("TestUrl", GetDataParser().TestData("Test_Url", Path));
      testData.Add("User_Email", GetDataParser().TestData("User_Email", Path));
            testData.Add("User_Password", GetDataParser().TestData("User_Password", Path));

            return testData;
        }
        


        [When(@"enter the email (.*)")]
        public void WhenEnterTheEmail(String email)
        {
            //scenario = scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
           // LoginAutomationPage = new LoginAutomationPage(driver);
            LoginPOM.EnterUsername(_driver, email);
            Thread.Sleep(1000);
           
            _scenarioContext["email"] = email;
            //_traceListener.WriteTestOutput("Enter email - login");
            //scenario.CreateNode<Scenario>($"Document '{doc.Text}' is displaying properly on Investor accreditation step");
            scenario.Log(Status.Pass, "Log",addScreenshot(_driver, Filename));
            scenario.Log(Status.Pass,"Log");

        }

        [When(@"enter the password (.*)")]
        public void WhenEnterThePasswordXoALPftM(string password)
        {
            
            LoginPOM.EnterPassword(_driver, password);
            _scenarioContext["password"] = password;
            //_traceListener.WriteTestOutput("Enter password - login");
        }


        [When(@"click on submit button")]
        public void WhenClickOnSubmitButton()
        {
            LoginPOM.ClickOnSubmitButton(_driver);
           // _traceListener.WriteTestOutput("click on submit - login");
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }

        [Then(@"verify Home page")]
        public void WhenVerifyHomePage()
        {
           
            string Email=JsonData()["User_Email"];
            string Password = JsonData()["User_Password"];

      if (Email == (string)_scenarioContext["email"] && Password == (string)_scenarioContext["password"])
      {
        Assert.That(LoginPOM.verifyLogoforHomePage(_driver));
      }
      else
      {

        Assert.That(LoginPOM.CheckErrorMessageforLogin(_driver));

      }

     // Assert.That(LoginPOM.verifyLogoforHomePage(_driver));
    }



    ////**************************************************************************Unwanted********************************************************************************************

    [Given(@"Launch browser (.*)")]
    public void GivenLaunchBrowser(string Browser)
    {
      _driver = WebDriverFactory.GetDriver();
      _scenarioContext["driver"] = _driver;
      _container.RegisterInstanceAs<IWebDriver>(_driver);
      _driver.Manage().Window.Maximize();
      _driver.Navigate().GoToUrl(JsonData()["TestUrl"]);
    }

  }
}
