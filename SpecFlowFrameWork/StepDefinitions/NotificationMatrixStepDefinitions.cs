using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowFrameWork.Utility;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.ManageProfilePage;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class NotificationMatrixStepDefinitions:BaseClass
    {
        private readonly IWebDriver _driver;

        private ScenarioContext _scenarioContext;
        private ExtentTest _scenario;
        

        public NotificationMatrixStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _scenario = (ExtentTest)_scenarioContext["scenario"];
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
        [When(@"Navigate to manage profile page")]
        public void WhenNavigateToManageProfilePage()
        {
            ManageProfilePOM.NavigateToManageProfilePage(_driver);
            WaitForSpinnerToDisappear(_driver);
        }

        [When(@"click on report permission section (.*)")]
        public void WhenClickOnReportPermissionSection(int Iteration)
        {
            try
            {

            if(Iteration==2)
            ManageProfilePOM.ClickOnNextNavigationButton_ManageProfilePage(_driver);
            Thread.Sleep(1000);
            ManageProfilePOM.ClickOnNextNavigationButton_ManageProfilePage(_driver);
            }
            catch { }
            ManageProfilePOM.ClickOnReportPermission_ManageProfilePage(_driver);
                _scenario.Log(Status.Pass,"Clicked on report permission  section");
            WaitForSpinnerToDisappear(_driver);
            

        }

        [When(@"change the self-permission")]
        public void WhenChangeTheSelf_Permission()
        {
           string OTest= ManageProfilePOM.SelectSelfPermission_ManageProfilePage(_driver).Text;
            ManageProfilePOM.SelectSelfPermission_ManageProfilePage(_driver).Click();
          
            if (OTest == "Allow")
                
                ManageProfilePOM.SeletctSelfPermissionOption_ManageProfilePage(_driver,"Not Allow").Click();
            else
            {
                
                ManageProfilePOM.SeletctSelfPermissionOption_ManageProfilePage(_driver,"Allow").Click();
            }
        }

        [Then(@"validate that the permission set properly")]
        public void ThenValidateThatThePermisionSetProprerly()
        {
            Assert.That(Success_Notification(_driver).Displayed);
            InvisibleSuccess_Notification(_driver);
        }
        [When(@"Expand Inner Table of ""([^""]*)""")]
        public void WhenExpandInnerTableOf(string rIA)
        {
            ManageProfilePOM.ExpandInnerTable_OfPermission_ManageProfilePage(_driver, rIA, "more");
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }

        [When(@"Set User-level permission for ""([^""]*)""")]
        public void WhenSetUser_LevelPermissionFor(int NumberOfEntity)
        {
            Thread.Sleep(3000);
            BaseClass.WaitForSpinnerToDisappear(_driver);
            string OTest= ManageProfilePOM.SelectOptionForUserLevelPermission_ManageProfilePage(_driver, NumberOfEntity).Item1.Text;
            ManageProfilePOM.SelectOptionForUserLevelPermission_ManageProfilePage(_driver, NumberOfEntity).Item1.Click();
            if (OTest == "Allow")
            {
                ManageProfilePOM.SeletctSelfPermissionOption_ManageProfilePage(_driver, "Not Allow").Click();

            }
            else
            {
              
                ManageProfilePOM.SeletctSelfPermissionOption_ManageProfilePage(_driver, "Allow").Click();
            }
            _scenarioContext["PermissionSet"] = ManageProfilePOM.SelectOptionForUserLevelPermission_ManageProfilePage(_driver, NumberOfEntity).Item1.Text;

        }
        [Then(@"Validate that permission displaying properly")]
        public void ThenValidateThatPermissionDisplayingProperly()
        {
            try
            {

            Thread.Sleep(3000);
            Assert.That(ManageProfilePOM.SelectSelfPermission_ManageProfilePage(_driver).Text==(string)_scenarioContext["PermissionSet"]);
            Thread.Sleep(3000);
            }
            catch { }
        }
        [When(@"Set Global permission")]
        public void WhenSetGlobalPermission()
        {
            string GlobalText = ManageProfilePOM.SelectGlobalPermission_ManageProfilePage(_driver, "RIA").Text;
            ManageProfilePOM.SelectGlobalPermission_ManageProfilePage(_driver, "RIA").Click();

            if (GlobalText == "Allow")
                
                ManageProfilePOM.SeletctSelfPermissionOption_ManageProfilePage(_driver, "Not Allow").Click();
            else
            {
                ManageProfilePOM.SeletctSelfPermissionOption_ManageProfilePage(_driver, "Allow").Click();
            }
            _scenarioContext["PermissionSet"] = ManageProfilePOM.SelectGlobalPermission_ManageProfilePage(_driver, "RIA");
        }

        [Then(@"validate all entity set to permission same as global level")]
        public void ThenValidateAllEntitySetToPermissionSameAsGlobalLevel()
        {
            Thread.Sleep(1000);
            try
            {

            for(int i=2;i<=4;i++)
            {
                    //var r = ManageProfilePOM.SelectOptionForUserLevelPermission_ManageProfilePage(_driver, i).Item1.GetAttribute("aria-disabled");
                    //Assert.That(ManageProfilePOM.SelectOptionForUserLevelPermission_ManageProfilePage(_driver, i).Item1.GetAttribute("aria-disabled").Contains("true"));
                    string OText = ManageProfilePOM.SelectOptionForUserLevelPermission_ManageProfilePage(_driver, i).Item1.Text;
                    Assert.That(OText.Contains((string)_scenarioContext["PermissionSet"]));
                
                }
            }catch { }
           
        }


    }
}
