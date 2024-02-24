using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using SpecFlowFrameWork.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using SpecFlowFrameWork.Pages;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SpecFlowFrameWork.Driver;
using FluentAssertions;
using Yrefy_AutomationProject.Utility;
using FluentAssertions.Execution;
using NUnit.Framework.Interfaces;

namespace FinanceModule.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        public static ThreadLocal<ExtentReports> Extent = new ThreadLocal<ExtentReports>();
        private static ThreadLocal<IWebDriver> Driver = new ThreadLocal<IWebDriver>();


        public static DateTime Time = DateTime.Now;
        public static String Filename = "Screenshot_" + Time.ToString("h_mm_ss") + ".png";
        public static string LoginCredintial_Path = GetDataParser().TestData_Path("LoginCredentialsTD");
        public static string Test_Url = GetDataParser().TestData("Test_Url", LoginCredintial_Path);
        public static string TestUrl_Origination = GetDataParser().TestData("TestUrl_Origination", LoginCredintial_Path);
        public static string[] browser = GetDataParser().TestData("browser", LoginCredintial_Path).Split('|');
         Random random = new Random();
   




    private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;            
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
            


        }


        //***********This section Work when Sharable Browser for all scenario required for that use @BeforeFeatureLaunchBrow Tag**********************************************************

        [BeforeFeature("@BeforeFeatureLaunchBrow")]
        public static void BeforeFeatureLaunchBrowser(FeatureContext featureContext)
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.BrowserLaunch(Driver.Value, Test_Url,"Login");
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        [BeforeScenario("BeforeFeatureLaunchBrow")]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            IWebDriver driver = Driver.Value;
            Console.WriteLine("Running inside tagged hooks spec-flow");
            _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            //_scenarioContext["scenario"] = _scenario;
        }
        [AfterScenario("@BeforeFeatureLaunchBrow")]
        public void AfterScenarios(IWebDriver driver)
        {
            driver = _container.Resolve<IWebDriver>();
        }

        [AfterFeature("BeforeFeatureLaunchBrow")]
        public static void AfterFeatureBrowClose()
        {
            Console.WriteLine("Running after feature...");
            if (Driver.Value != null)
            {
                Driver.Value.Quit();
            }
        }

        //------------------------------------------------------------------------End-Section------------------------------------------------------------------------------------------------------



        //***********This section Work when independent Browser for each scenario required for that use @BeforeFeatureDontLaunch Tag**********************************************************

        [BeforeFeature("@BeforeFeatureDontLaunch")]
        public static void BeforeFeature(FeatureContext featureContext)
        { 
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }



        [BeforeScenario("@M2I")]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
             int randomIndex = random.Next(0, browser.Length);
             string randomItem = browser[randomIndex];
            BaseClass Basee = new BaseClass();
            Driver.Value = Basee.BrowserLaunch(Driver.Value, Test_Url, browser[randomIndex]);
            IWebDriver driver = Driver.Value;
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            Thread.Sleep(5000);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            scenarioContext["scenario"] = _scenario;
        }

        [AfterScenario("@BeforeFeatureDontLaunch")]
        public void AfterScenario(IWebDriver driver)
        {
            driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }     
        }


        [AfterFeature("@BeforeFeatureDontLaunch")]
        public static void AfterFeature(IWebDriver driver)
        {
            Console.WriteLine("Running after feature...");
        }
   
    //------------------------------------------------------------------------End-Section------------------------------------------------------------------------------------------------------
    //*********************When we want to launch browser in step definition***********************************
    [BeforeFeature("@WithoutLaunchBrowser")]
        public static void secondBeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }



        [BeforeScenario("@WithoutLaunchBrowser")]
        public void secondBeforeScenario(ScenarioContext scenarioContext)
        {         
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            _scenarioContext["scenario"] = _scenario;
             var assertionScope = new AssertionScope();
            _scenarioContext["assertionScope"] = assertionScope;
        }

        [AfterScenario("@WithoutLaunchBrowser")]
        public void secondAfterScenario(IWebDriver driver, ScenarioContext scenarioContext)
        {
            driver = _container.Resolve<IWebDriver>();
            if (scenarioContext.TryGetValue("assertionScope", out var assertionScope) && assertionScope is AssertionScope scope)
            {           
             scope.Dispose();
            }

            if (driver != null)
            {
                driver.Quit();
            }
        }


        [AfterFeature("@WithoutLaunchBrowser")]
        public static void secondAfterFeature(IWebDriver driver)
        {
            Console.WriteLine("Running after feature...");
        }

        //------------------------------------------------------------------------End-Section------------------------------------------------------------------------------------------------------
        
        //********************************************************This Methods used for Origination Test********************************************************************************************
        
        [BeforeScenario("@Origination")]
        public void FirstBeforeScenario1(ScenarioContext scenarioContext)
        {
           int randomIndex = random.Next(0, browser.Length);    
           string randomItem = browser[randomIndex];

            BaseClass Basee = new BaseClass();
            Driver.Value = Basee.BrowserLaunch(Driver.Value, TestUrl_Origination, browser[randomIndex]);
            IWebDriver driver = Driver.Value;
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            Thread.Sleep(5000);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            scenarioContext["scenario"] = _scenario;
         
         }



    //------------------------------------------------------------------------End-Section------------------------------------------------------------------------------------------------------


    [BeforeStep("@BeforeStep")]
        public void beforestep(ScenarioContext scenarioContext)
        {
            
            Console.WriteLine("Running before step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            Console.WriteLine("Running before step....");
            IWebDriver driver = _container.Resolve<IWebDriver>();
            

            switch (stepType)
            {
                case "Given":

                    scenarioContext["scenario"] = _scenario.CreateNode<Given>(stepName);
                    break;
                case "When":

                    scenarioContext["scenario"] = _scenario.CreateNode<When>(stepName);
                    break;
                case "Then":
                   
                    scenarioContext["scenario"] = _scenario.CreateNode<Then>(stepName);
                    break;
            }


        }
        [AfterStep("@BeforeStep")]
        public void afterStep(ScenarioContext scenarioContext)
        {


            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            Console.WriteLine("Running after step....");
            IWebDriver driver = _container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {                    
                if (stepType == "Given")
                {         
                _scenario.CreateNode<Given>(":- This Step").Pass("Passed Successfully", addScreenshot(driver, Filename));
                }
                else if (stepType == "When")
                {
                _scenario.CreateNode<When>(":- This Step").Pass("Passed Successfully", addScreenshot(driver, Filename));
                }
                else if (stepType == "Then")
                {
              _scenario.CreateNode<Then>(":- This Step").Pass("Passed Successfully", addScreenshot(driver, Filename));

          
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(":- This Step").Pass("Passed Successfully", addScreenshot(driver, Filename));
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(":- This Step").Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(":- This Step").Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(":- This Step").Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(":- This Step").Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
            }
        }

        [AfterStep("@AfterStep")]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            
            
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            Console.WriteLine("Running after step....");
            IWebDriver driver = _container.Resolve<IWebDriver>();
            

            //When scenario passed
            if (scenarioContext.TestError == null)
            {



                if (stepType == "Given")
                {                  
                     _scenario.CreateNode<Given>(stepName).Pass(scenarioContext.StepContext.StepInfo.Text.ToString(), addScreenshot(driver, Filename));
                }
                else if (stepType == "When")
                {                 
                     _scenario.CreateNode<When>(stepName).Pass(scenarioContext.StepContext.StepInfo.Text.ToString(), addScreenshot(driver, Filename));
                }
                else if (stepType == "Then")
                {                  
                     _scenario.CreateNode<Then>(stepName).Pass(scenarioContext.StepContext.StepInfo.Text.ToString(), addScreenshot(driver, Filename));
                     // _test=_scenario.CreateNode<Then>(scenarioContext.ScenarioInfo.Title);
                     // _test.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {                   
                    _scenario.CreateNode<And>(stepName).Pass(scenarioContext.StepContext.StepInfo.Text.ToString(), addScreenshot(driver, Filename));
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message, addScreenshot(driver, Filename));
                }
            }
        }


    }
}
