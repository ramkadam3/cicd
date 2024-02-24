using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Bogus.DataSets;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using SeleniumExtras.WaitHelpers;
using SpecFlowFrameWork.Pages;
using SpecFlowFrameWork.Pages.InvstmentsPagePOM;
using SpecFlowFrameWork.Pages.OfferingPagePOM;
using SpecFlowFrameWork.Utility;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Pages.InvestorPage;
using Yrefy_AutomationProject.Pages.InvstmentsPagePOM;
using Yrefy_AutomationProject.Pages.ManageProfilePage;
using Yrefy_AutomationProject.Utility;

namespace SpecFlowFrameWork.StepDefinitions
{
    [Binding]
    public class AddInvestmentStepDefinitions:BaseClass
    {
        private readonly IWebDriver _driver;

        private ScenarioContext _scenarioContext;
        private ExtentTest _scenario;

        public AddInvestmentStepDefinitions(IWebDriver driver,ScenarioContext scenarioContext)
        {
            _driver=driver;
            _scenarioContext=scenarioContext;
            
        }
        public static Dictionary<string, string> JsonData()
        {
            string Path = GetDataParser().TestData_Path("AddInvestmentTD");
            var testData = new Dictionary<String, String>();

            testData.Add("CompanyeSignCardTitle", GetDataParser().TestData("CompanyeSignCardTitle", Path));
            testData.Add("MakePaymentCardTitle", GetDataParser().TestData("MakePaymentCardTitle", Path));
            testData.Add("FinalizeInvestmentCardTitle", GetDataParser().TestData("FinalizeInvestmentCardTitle", Path));

      testData.Add("DOB", GetDataParser().TestData("DOB", Path));
      testData.Add("DOBc", GetDataParser().TestData("DOBc", Path));
      testData.Add("State", GetDataParser().TestData("State", Path));
      testData.Add("Signer", GetDataParser().TestData("Signer", Path));
      testData.Add("HearAbout", GetDataParser().TestData("HearAbout", Path));
      testData.Add("RelationshipToManager", GetDataParser().TestData("RelationshipToManager", Path));
      testData.Add("BusinessName", GetDataParser().TestData("BusinessName", Path));
      testData.Add("Position", GetDataParser().TestData("Position", Path));

      return testData;
        }

        [Given(@"Navigate to offering page of investor profile")]
        public void GivenNavigateToOfferingPageOfInvestoreProfile()
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            OfferingPagePOM.NavigateToOfferingPage(_driver);
            BaseClass.WaitForSpinnerToDisappear(_driver);
            _scenario.Log(Status.Pass, "Navigated to the offering page");
            _scenario.Log(Status.Pass,addScreenshot(_driver,Filename));

    }
    
    [Given(@"Navigate to the Add invest field (.*)")]
    public void GivenNavigateToTheAddInvestField(string SearchValue)
    {
      string accountName;
      
      //provide value to the accountName
      try
      {
        try
        {
          if (((string)_scenarioContext["InvestorMN"]).Contains("-"))
          {
            accountName = $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorLN"]}";
          }
          else
          {
            accountName = $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorMN"]} {(string)_scenarioContext["InvestorLN"]}";
          }
        }
        catch
        {
          try
          {
            if (((string)_scenarioContext["InvestorMN 1"]).Contains("-"))
            {
              accountName = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorLN 1"]}";
            }
            else
            {
              accountName = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorMN 1"]} {(string)_scenarioContext["InvestorLN 1"]}";
            }
          }
          catch
          {
            if (((string)_scenarioContext["InvestorMN 2"]).Contains("-"))
            {
              accountName = $"{(string)_scenarioContext["InvestorFN 2"]} {(string)_scenarioContext["InvestorLN 2"]}";
            }
            else
            {
              accountName = $"{(string)_scenarioContext["InvestorFN 2"]} {(string)_scenarioContext["InvestorMN 2"]} {(string)_scenarioContext["InvestorLN 2"]}";
            }
          }
        }
      }
      catch
      {
        

        accountName = $"{(string)_scenarioContext["InvestorName"]}";
        
      }



      //first check that the account is as of required type
      //if not, then switch to there
      try
      {
        ManageAccountPOM.NavigateToManageAccountPage(_driver);
        WaitForSpinnerToDisappear(_driver);
        Assert.That(ManageAccountPOM.SwitchToThisAccount_ManageAccountPage(_driver,accountName).Displayed);
        ManageAccountPOM.SwitchToThisAccount_ManageAccountPage(_driver, accountName).Click();
        WaitForSpinnerToDisappear(_driver);
        InvisibleSuccess_Notification(_driver);

      }
      catch
      {
      }

      //navigate to the offering
      try
      {
        OfferingPagePOM.NavigateToOfferingPage(_driver);
        BaseClass.WaitForSpinnerToDisappear(_driver);
        OfferingPagePOM.EnterValueToSearch_OfferingPage(_driver, "Name").SendKeys(SearchValue);      
        OfferingPagePOM.ClickOnApplyButton(_driver);
        BaseClass.WaitForSpinnerToDisappear(_driver);
        OfferingPagePOM.CheckOfferInList(_driver, 1).Click();
        BaseClass.WaitForSpinnerToDisappear(_driver);
      }
      catch
      {
        AddInvestorPOM.NavigateToManageProfilePage(_driver);
        WaitForPageToLoad(_driver);
        ManageProfilePOM.ClickOnProceedToInvestButton_ManageProfilePage(_driver);
        WaitForPageToLoad(_driver);
      }
    }
    [Given(@"Navigate With InvestorName And OfferingName to the Add invest field (.*), (.*)")]
    public void GivenNavigateToTheAddInvestFieldWithInvestorNameAndOfferingName(string accountName, string SearchValue)
    {


     



      //first check that the account is as of required type
      //if not, then switch to there
      try
      {
        ManageAccountPOM.NavigateToManageAccountPage(_driver);
        WaitForSpinnerToDisappear(_driver);
        Assert.That(ManageAccountPOM.SwitchToThisAccount_ManageAccountPage(_driver, accountName).Displayed);
        ManageAccountPOM.SwitchToThisAccount_ManageAccountPage(_driver, accountName).Click();
        WaitForSpinnerToDisappear(_driver);
        InvisibleSuccess_Notification(_driver);

      }
      catch
      {
      }

      //navigate to the offering
      try
      {
        OfferingPagePOM.NavigateToOfferingPage(_driver);
        BaseClass.WaitForSpinnerToDisappear(_driver);
        OfferingPagePOM.EnterValueToSearch_OfferingPage(_driver, "Name").SendKeys(SearchValue);
        OfferingPagePOM.ClickOnApplyButton(_driver);
        BaseClass.WaitForSpinnerToDisappear(_driver);
        OfferingPagePOM.CheckOfferInList(_driver, 1).Click();
        BaseClass.WaitForSpinnerToDisappear(_driver);
      }
      catch
      {
        AddInvestorPOM.NavigateToManageProfilePage(_driver);
        WaitForPageToLoad(_driver);
        ManageProfilePOM.ClickOnProceedToInvestButton_ManageProfilePage(_driver);
        WaitForPageToLoad(_driver);
      }
    }
    [When(@"Search for Offer in offering list (.*)")]
        public void WhenSearchForOfferInOfferingListAdobeTestOffering( string SearchValue)
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            OfferingPagePOM.EnterValueToSearch_OfferingPage(_driver,"Name").SendKeys(SearchValue);
            _scenario.Log(Status.Pass, "Enter Value for search");
            
            OfferingPagePOM.ClickOnApplyButton(_driver);
            _scenario.Log(Status.Pass, "Clicked on the Apply button");
            BaseClass.WaitForSpinnerToDisappear(_driver);
            _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
        }

        [When(@"Click on Offer")]
        public void WhenClickOnOffer()
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            OfferingPagePOM.CheckOfferInList(_driver,1).Click();
            _scenario.Log(Status.Pass, "Clicked on the offer name");
            BaseClass.WaitForSpinnerToDisappear( _driver);  
            _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
        }

        [When(@"Click on Add investment field (.*)")]
        public void WhenClickOnAddInvestmentField(string investorNameOrType)
        {
           if(investorNameOrType == "null")
           {

             if (((string)_scenarioContext["InvestorMN"]).Contains("-"))
             {
          investorNameOrType = $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorLN"]}";
             }
             else
             {
          investorNameOrType = $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorMN"]} {(string)_scenarioContext["InvestorLN"]}";
             }
           }
      else if(investorNameOrType.ToLower().Contains("joint")&& !investorNameOrType.ToLower().Contains("automation"))
      {
        if(investorNameOrType.ToLower().Contains("1"))
        {

           if (((string)_scenarioContext["InvestorMN 1"]).Contains("-"))
           {
            investorNameOrType = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorLN 1"]}";
           }
           else
           {
            investorNameOrType = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorMN 1"]} {(string)_scenarioContext["InvestorLN 1"]}";
           }
        }
        else
        {
          if (((string)_scenarioContext["InvestorMN 2"]).Contains("-"))
          {
            investorNameOrType = $"{(string)_scenarioContext["InvestorFN 2"]} {(string)_scenarioContext["InvestorLN 2"]}";
          }
          else
          {
            investorNameOrType = $"{(string)_scenarioContext["InvestorFN 2"]} {(string)_scenarioContext["InvestorMN 2"]} {(string)_scenarioContext["InvestorLN 2"]}";
          }

        }
      }
      else if ((investorNameOrType.ToLower().Contains("ira")|| "trust_c-corp_s-corp_partnership_llc".Contains(investorNameOrType.ToLower())) && !investorNameOrType.ToLower().Contains("automation"))
      {
        investorNameOrType = $"{(string)_scenarioContext["InvestorName"]}";
      }
      
        AddInvestmentPOM.ClickOnInvestNowField(_driver);

          try
          {
            AddInvestmentPOM.SelectInvestorAccount_Sendkey(_driver,"Account").SendKeys(investorNameOrType);
            AddInvestmentPOM.ClickOnInvestButton_SelectInvestorAccountForInvestment_AddInvestmentProcess(_driver);
            Thread.Sleep(2000);
          }
          catch { }
            BaseClass.WaitForSpinnerToDisappear( _driver);
        }
       
        [When(@"Click on Invest for an Investor field")]
        public void WhenClickOnInvestForAnInvestorField()
        {
            AddInvestmentPOM.ClickOnInvestForAnInvestorField(_driver);
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }
        [When(@"Select Investor To invest on behalf of the investor (.*)")]
        public void WhenSelectInvestorToInvestOnBehalfOfTheInvestor(string InvestorName)
        {
            InvestorName=InvestorName.Trim('"');
            InvestmentPagePOM.SelectInvestor_InvestOnBehalfOfInvestor_InvestmentsPage(_driver,InvestorName);
            InvestmentPagePOM.SelectInvestorUser_InvestOnBehalfOfInvestor_InvestmentsPage(_driver, InvestorName);
            InvestmentPagePOM.ClickOnInvest_InvestOnBehalfOfInvestor_InvestmentsPage(_driver);
        }


        [Then(@"Validate InvestNow field navigate to the investment process")]
        public void ThenValidateInvestNowFieldNavigateToTheInvestmwntProcess()
        {
            Assert.That(AddInvestmentPOM.EnterInvestmentAmount_AddInvestmentProcess(_driver,1).Displayed);
        }

        [When(@"Enter Investment Less than minimum investment amount required (.*)")]
        public void WhenEnterInvestmentLessThanMinimumInvestmentAmountRequired(string LessInvestmentAmount)
        {
            AddInvestmentPOM.EnterInvestmentAmount_AddInvestmentProcess(_driver, 1).Clear();
            AddInvestmentPOM.EnterInvestmentAmount_AddInvestmentProcess(_driver,1).SendKeys(LessInvestmentAmount);
        }

        [When(@"Click on Save button")]
        public void WhenClickOnSaveButton()
        {
           AddInvestmentPOM.ClickOnSaveNextButton_AddInvestmentProcess( _driver);
        }

        [Then(@"Validate that Alert notification displaying for Minimum investment amount")]
        public void ThenValidateThatAlertNotificationDisplayingForMinimumInvestmentAmount()
        {
            BaseClass.Success_Notification(_driver);
        }

        [Given(@"Enter Investment amount more than minimum amount (.*), (.*)")]
        public void GivenEnterInvestmentAmountMoreThanMinimumAmount(string InvestmentAmount,string ParentTrancheNumber)
        {
           _scenario = (ExtentTest)_scenarioContext["scenario"];
            int a = int.Parse(ParentTrancheNumber.Trim('"'));
            AddInvestmentPOM.EnterInvestmentAmount_AddInvestmentProcess(_driver,a).Clear();
            AddInvestmentPOM.EnterInvestmentAmount_AddInvestmentProcess(_driver, a).SendKeys(InvestmentAmount);
           _scenario.Log(Status.Pass, $"Entered Investment amount {InvestmentAmount}");
           _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));

        }

        [When(@"Enter Value in Monthly income field (.*), (.*)")]
        public void WhenEnterValueInMonthlyIncomeField(string InputValue,string ParentTrancheNumber)
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            int a = int.Parse(ParentTrancheNumber.Trim('"'));
            try
            {

            AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, a, "Monthly Income").Clear();
            AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, a, "Monthly Income").SendKeys(InputValue);
            _scenario.Log(Status.Pass, $"Entered value in monthly income field {InputValue}");
            _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
            }catch (Exception e)
            {
                _scenario.Log(Status.Fail, $"Entered value in monthly income field {InputValue} Error: "+e);
                _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
            }
        }
    [Then(@"Get InvestmentDetails from investment details section of investment (.*)")]
    public void ThenGetInvestmentDetailsFromInvestmentDetailsSectionOfInvestment(int trancheNumber)
    {
      Thread.Sleep(1000);
      _scenarioContext[$"InterestRate {trancheNumber}"] = InvestmentDetailsPagePOM.CheckIntrestRate_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber);
      _scenarioContext[$"EffectiveInterestRate {trancheNumber}"] = AddInvestmentPOM.ReadValueOfTrancheField_AddInvestmentProcess(_driver, trancheNumber, "Effective Interest Yield").Text.Trim('%').RemoveFractionIfWhole();
      _scenarioContext[$"Bonus {trancheNumber}"] = AddInvestmentPOM.ReadValueOfTrancheField_AddInvestmentProcess(_driver, trancheNumber, "Bonus").Text.Trim('%').RemoveFractionIfWhole();
      //_scenarioContext[$"MaturityDate {trancheNumber}"] = AddInvestmentPOM.ReadValueOfTrancheField_AddInvestmentProcess(_driver, trancheNumber, "Maturity Date").Text;
      _scenarioContext[$"MonthlyIncome {trancheNumber}"] = AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, trancheNumber, "Monthly Income").GetAttribute("value").Trim('%').RemoveFractionIfWhole();
      _scenarioContext[$"EstimatedMonthlyIncome {trancheNumber}"] = AddInvestmentPOM.ReadValueOfTrancheField_AddInvestmentProcess(_driver, trancheNumber, "Estimated Monthly Income").Text.Trim('$').RemoveFractionIfWhole();
   

    }

        [Then(@"validate Monthly compound field show correct value (.*)")]
        public void ThenValidateMonthlyCompaundFieldShowCorrectValue(string Value)
        {
            string v = AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, 1, "Monthly Compound").GetAttribute("value");
            Assert.That(AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, 1, "Monthly Compound").GetAttribute("value").Contains(Value));
        }

        [Then(@"Validate Estimated monthly income field show correct value (.*)")]
        public void ThenValidateEstimatatedMonthalyIncomeFieldShowCorrectValue(string Value)
        {
            string v = AddInvestmentPOM.CheckEstimatedMonthlyIncome_AddInvestmentProcess(_driver, 1).Text;
            AddInvestmentPOM.CheckEstimatedMonthlyIncome_AddInvestmentProcess(_driver, 1).Text.Contains(Value);
        }

        [Given(@"Enter value in the Monthly compound field (.*)")]
        public void GivenEnterValueInTheMonthlyCompoundField(string InputValue)
        {
            AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, 1, "Monthly Compound").Clear();
            AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, 1, "Monthly Compound").SendKeys(InputValue);
        }

        [Then(@"Validate monthly income field shows correct value (.*)")]
        public void ThenValidateMonthlyIncomeFieldShowsCorrectValue(string Value)
        {
            Assert.That(AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, 1, "Monthly Income").GetAttribute("value").Contains(Value));
        }

        [Given(@"Scroll the Bar to new position")]
        public void GivenScrollTheBarToNewPosition()
        {
            AddInvestmentPOM.ScrollCompoundIncomeBar_AddInvestmentProcess(_driver,1,25);
        }

        [Then(@"validate that Monthly income and Monthly compound  section show correct value")]
        public void ThenValidateThatMonthlyIncomeAndMonthlyCompoundSectionShowCorrectValue()
        {
            Assert.That(AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, 1, "Monthly Income").GetAttribute("value").Contains(25.ToString()));
            Assert.That(AddInvestmentPOM.EnterInputToTrancheField_AddInvestmentProcess(_driver, 1, "Monthly Compound").GetAttribute("value").Contains((100-25).ToString()));
        }

        [Then(@"Click on Save button")]
        public void ThenClickOnSaveButton()
        {
            AddInvestmentPOM.ClickOnSaveNextButton_AddInvestmentProcess(_driver);
        }

        [Then(@"Validate that Save investment details popup comes up")]
        public void ThenValidateThtaSaveInvestmentDetailsPopupComesUp()
        {
            Assert.That(AddInvestmentPOM.ClickOnConfirmButton_AddInvestmentProcess(_driver).Displayed);
        }

        [Then(@"Click on confirm button")]
        public void ThenClickOnConfirmButton()
        {
            AddInvestmentPOM.ClickOnConfirmButton_AddInvestmentProcess(_driver).Click();
        }

        [Then(@"Validate success-notification displaying")]
        public void ThenValidateSuccess_NotificationDisplaying()
        {
           Assert.That( BaseClass.Success_Notification(_driver).Displayed);
        }
        [Then(@"Validate success-notification Successfully (.*)")]
        public void ThenValidateSuccess_NotificationDisplaying1(string Message)
        {  
          try
          {
            Assert.That(BaseClass.Success_Notification(_driver).Text.Contains(Message.Trim('"'))||BaseClass.Success_Notification(_driver).Text.Contains( Message.Trim('"').ToLower()));
          }
          catch (Exception e)
          {
           Assert.IsTrue(false, BaseClass.Success_Notification(_driver).Text);
          }
        }

        [Then(@"validate it navigated to investor eSign section")]
        public void ThenValidateItNavigatedToInvestoreESignSection()
        {
            Assert.That(AddInvestmentPOM.ClickOneSignButton_AddInvestmentProcess(_driver).Displayed);
        }



        [Then(@"Validate that the investor eSign section displays details properly")]
        public void ThenValidateThatTheInvestorESignSectionDisplaysDetailsProperly()
        {
            IList<IWebElement>DocList=AddInvestmentPOM.CheckDocumentsOnInvestoreesignStep_AddInvestmentProcess(_driver);
            

            foreach (IWebElement doc in DocList)
            {
                Assert.That(true);
                //_scenario.CreateNode<Then>($"Document '{doc.Text}' is displaying properly on Investor accreditation step");
            }
            
        }

        [Then(@"Investment Created Successfully")]
        public void ThenInvestmentCreatedSuccessfully()
        {
            
        }


        [Given(@"Click on eSign button")]
        public void GivenClickOnESignButton()
        {
            Thread.Sleep(4000);
            AddInvestmentPOM.ClickOneSignButton_AddInvestmentProcess(_driver).Click();
        }

        [Then(@"Validate that the redirecting alert displaying")]
        public void ThenValidateThatTheRedirectingAlertDisplaying()
        {Thread.Sleep(1000);
            Assert.That(BaseClass.Success_Notification(_driver).Displayed);
            BaseClass.WaitForSpinnerToDisappear(_driver);
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }

        [Then(@"Complete eSign process (.*)")]
        public void ThenCompleteESignProcess(string investorType)
        {
            Thread.Sleep(5000);
            List<string> address = new List<string>(_driver.WindowHandles);
            Console.WriteLine(address.Count);
            _driver.SwitchTo().Window(address[1]);
            Thread.Sleep(2000);
            AddInvestmentPOM.DocumentSpinnerDisappear_AddInvestmentProcess(_driver);
            AddInvestmentPOM.ClickOnContinue_DocumentPage_AddInvestmentProcess(_driver).Click();
          //AddInvestmentPOM.AddPrintedName_Document_AddInvestmentProcess(_driver, "AutoInvestor");
      WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
        int i = 0;
        while (i<30)
            {
              AddInvestmentPOM.ClickOnNextButton_AdobeDoc_AddInvestmentProcess(_driver);
              i++;
            }
     
        Dictionary<string, int> adobeDictionary = new Dictionary<string, int>();

        Boolean visibilityOfElelement = true;

        if (investorType.ToLower().Contains("joint"))
          investorType = "Individual";
       else if (investorType.ToLower().Contains("c-corp"))
        investorType = "C Corporation";
       else if (investorType.ToLower().Contains("s-corp"))
        investorType = "S Corporation";
      //int attributeNumber = adobeDictionary[investorType];

      Actions act = new Actions(_driver);
        IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;

        Thread.Sleep(2000);

        //Apply Initial
        try
        {

          i = 0;
          while (visibilityOfElelement && i < 4)
          {
            try
            {
              i++;
              executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", _driver.FindElement(By.XPath("//descendant::input[@placeholder='Initials']")));
              Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//descendant::input[@placeholder='Initials']")));
              act.MoveToElement(_driver.FindElement(By.XPath("//descendant::input[@placeholder='Initials']"))).Click().Build().Perform();
              Thread.Sleep(2000);
              act.MoveToElement(_driver.FindElement(By.XPath("//descendant::input[contains(@placeholder,'Type your initials')]"))).Click().Build().Perform();
              visibilityOfElelement = false;

            }
            catch
            {
            try
            {
              AddInvestmentPOM.ClickOnCloseButton_DocumentSign_AddInvestmentProcess(_driver);
            }
            catch { }

          }
          }
          Thread.Sleep(2000);
          act.MoveToElement(_driver.FindElement(By.XPath("//descendant::input[contains(@placeholder,'Type your initials')]"))).SendKeys("I").Build().Perform();
          Thread.Sleep(2000);
          AddInvestmentPOM.ClickOnApplyButton_DocumentSign_AddInvestmentProcess(_driver);

        }
        catch { }


        Thread.Sleep(2000);

      try
      {

        visibilityOfElelement = true;
        i = 0;
        while (visibilityOfElelement && i < 4)
        {
          i++;
          try
          {

            AddInvestmentPOM.ClickToSign_AddInvestmentProcess(_driver);
            Thread.Sleep(2000);
            AddInvestmentPOM.AddSignForDocument_AddInvestmentProcess(_driver).SendKeys("Investor");
            visibilityOfElelement = false;
          }
          catch { }
        }
        Thread.Sleep(2000);
        AddInvestmentPOM.ClickOnApplyButton_DocumentSign_AddInvestmentProcess(_driver);
        Thread.Sleep(2000);
      }
      catch
      { }

        visibilityOfElelement = true;
        i = 0;
        while (visibilityOfElelement && i < 4)
        {
        i++ ;
        try
        {

          Thread.Sleep(2000);
          AddInvestmentPOM.ClickToSign_AddInvestmentProcess(_driver, 2);
          Thread.Sleep(2000);

          AddInvestmentPOM.ClickToSign_AddInvestmentProcess(_driver, 3);
          Thread.Sleep(2000);
          visibilityOfElelement = false;
        }
        catch
        { }
        }
        visibilityOfElelement = true;
        i = 0;
        while (visibilityOfElelement && i < 3)
        {i++ ;
      try
      {


         
          AddInvestmentPOM.ClickToSign_AddInvestmentProcess(_driver,4);
          
          visibilityOfElelement = false;
      }
      catch
      { }
        }
        visibilityOfElelement = true;
        i = 0;
        while (visibilityOfElelement && i < 3)
        {
        i++ ;
      try
      {



          AddInvestmentPOM.ClickToSign_AddInvestmentProcess(_driver,5);

          visibilityOfElelement = false;
      }
      catch
      { }
        }
      ////Apply Investor Type
      try
        {

          visibilityOfElelement = true;
          i = 0;
          while (visibilityOfElelement && i < 3)
          {
            i++;
            try
            {

              executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", _driver.FindElement(By.XPath($"//input[contains(@value,'{investorType}')]/parent::div")));
              //Thread.Sleep(2000);
              _driver.FindElement(By.XPath($"//input[contains(@value,'{investorType}')]/parent::div")).Click();
              visibilityOfElelement = false;
            }
            catch { }
          }
          Thread.Sleep(2000);
        }
        catch { }


        AddInvestmentPOM.ClickToSign_Document_AddInvestmentProcess(_driver);
            AddInvestmentPOM.DocumentSpinnerDisappear_AddInvestmentProcess(_driver);
            _driver.Close();
            _driver.SwitchTo().Window(address[0]);
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }
   
    [Then(@"Validate that the eSign completion displaying successfully")]
        public void ThenValidateThatTheESignCompletionDisplayingSuccessfully()
        {
            //Assert.That(BaseClass.Success_Notification(_driver).Displayed);
            AddInvestmentPOM.ClickOnRefereshButton_AddInvestmentProcess(_driver);      
            BaseClass.WaitForSpinnerToDisappear(_driver);
            _driver.Navigate().Refresh();
            BaseClass.WaitForSpinnerToDisappear(_driver);
            Thread.Sleep(3000);
        }

        [Then(@"Validate that the View Document Action item working properly")]
        public void ThenValidateThatTheViewDocumentActionItemWorkingProperly()
        {
            AddInvestmentPOM.ClickOnViewDocumentButton_AddInvestmentProcess(_driver,1);
            BaseClass.WaitForSpinnerToDisappear( _driver);
            List<string> address = new List<string>(_driver.WindowHandles);

            Console.WriteLine(address.Count);
            _driver.SwitchTo().Window(address[1]);
            _driver.Close();
            _driver.SwitchTo().Window(address[0]);

        }

        [Then(@"Validate that the Download document Action item working properly")]
        public void ThenValidateThatTheDownloadDocumentActionItemWorkingProperly()
        {
            AddInvestmentPOM.ClickOnDownloadButton_AddInvestmentProcess(_driver,1);
            Thread.Sleep(3000);
            string oneW=_driver.CurrentWindowHandle.ToString();
            Assert.That(ChromeOptionsAndCustomeBrowser.CheckDownoloadFile(_driver, "PPM.pdf"));
            string twoW=_driver.CurrentWindowHandle.ToString();
            if(oneW==twoW)
            {
        Assert.IsTrue(true,"The file has not been downloaded successfully");
            }
               

        }

        [When(@"Click on Next button")]
        public void WhenClickOnNextButton()
        {
            Thread.Sleep(4000);
            AddInvestmentPOM.ClickOnNextButton_AddInvestmentProcess(_driver);
        }
        [When(@"Click on Next-button investment page")]
        public void WhenClickOnNext_ButtonInvestmentPage()
        {
            InvestmentPagePOM.ClickOnNextButton_InvestmentProcess(_driver);
        }

        [Then(@"Validate that it navigates to the Investment Accreditation section")]
        public void ThenValidateThatItNavigatesToTheInvestmentAccreditationSection()
        {
            BaseClass.WaitForSpinnerToDisappear(_driver);
            AddInvestmentPOM.CheckAccreditionButton_AddInvestmentProcess(_driver);
           Assert.That( AddInvestmentPOM.CheckAccreditionButton_AddInvestmentProcess(_driver));
        }
    [When(@"Upload Accreditation letter on Accreditation step")]
    public void WhenUploadAccreditationLetterOnAccreditationStep()
    {
      AddInvestmentPOM.ClickOnAccreditationLetterButton_AccreditationStep_AddInvestmentProcess( _driver).Click();

    }

    [Then(@"Validate that status of investment updated properly at top of the page (.*)")]
        public void ThenValidateThatStatusOfInvestmentUpdatedProperlyAtTopOfThePage(string InvestmentStatus)
        {
            Thread.Sleep(2000);
            InvestmentStatus=InvestmentStatus.Trim('"');
           Assert.That( AddInvestmentPOM.CheckInvestmentStatusAtTop_AddInvestmentProcess(_driver, InvestmentStatus));
        }

        [Then(@"Check that it shows details properly")]
        public void ThenCheckThatItShowsDetailsProperly()
        {
           Assert.That("current|pending".Contains(AddInvestmentPOM.CheckAccreditionStatus_AddInvestmentProcess(_driver).ToLower()));//current|pending
    }

        [Then(@"Check that the download and view document action item working properly")]
        public void ThenCheckThatTheDownloadAndViewDocumentActionItemWorkingProperly()
        {
            Assert.That(AddInvestmentPOM.CheckAccreditionButton_AddInvestmentProcess(_driver));
        }

        [Then(@"Validate that it navigates to the Company eSign field")]
        public void ThenValidateThatItNavigatesToTheCompanyESignField()
        {
            Assert.That(AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver,"Company eSign").GetAttribute("aria-selected").Contains("true"));
        }
        [Then(@"Validate that the Company eSign, Make Payment, Finalize Investment sections are not accessible to investor till Company-signature")]
        public void ThenValidateThatTheCompanyESignMakePaymentFinalizeInvestmentSectionsAreNotAccessableToInvestoreTillCompany_Signature()
        { string SectionString = "Company eSign|Make Payment|Finalize Investment";
            //string data=JsonData()["CompanyeSignCardTitle"];
            string[] MessageText = { JsonData()["CompanyeSignCardTitle"], JsonData()["MakePaymentCardTitle"], JsonData()["FinalizeInvestmentCardTitle"] };
            
            
                int i = -1;
            foreach (string section in SectionString.Split('|'))
            {
                i++;

                AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, section).Click();
                try
                {
                    Thread.Sleep(2000);
                    string k = AddInvestmentPOM.CheckCompanyeSign_MakePayment_FinalizeSectionMessage_AddInvestmentProcess(_driver).Text.ToLower();
                    Assert.That(AddInvestmentPOM.CheckCompanyeSign_MakePayment_FinalizeSectionMessage_AddInvestmentProcess(_driver).Text.ToLower().Contains(MessageText[i].ToLower()));
                }
                catch { }

            }
        }

        [Given(@"Navigate to investments page")]
        public void GivenNavigateToInvestmentsPage()
        {
            InvestmentPagePOM.NavigateToInvestmentPage(_driver);
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }

        [When(@"Search for Investor name (.*),(.*)")]
        public void WhenSearchForInvestorNameAugust(string InvestoreName,string InvestmentStatus)
        {//Investor Signed
            InvestmentStatus= InvestmentStatus.Trim('"');

      try
      {
        if((string)_scenarioContext["InvestorMN"]!="-")
        InvestoreName = $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorMN"]} {(string)_scenarioContext["InvestorLN"]}";
        else
          InvestoreName = $"{(string)_scenarioContext["InvestorFN"]} {(string)_scenarioContext["InvestorLN"]}";
      }
      catch
      {}

      try
      {
        InvestoreName = (string)_scenarioContext["InvestorName"];
      }
      catch { }




      if (InvestoreName != "null")
        InvestmentPagePOM.EnterInputToFilter_InvestmentsPage(_driver,"Name", InvestoreName);
      try
      {
        if (InvestmentStatus != "null")
          InvestmentPagePOM.ClickOnStatusFilter_InvestmentsPage(_driver);
      }
      catch
      {
        //if in more filter
        if (InvestmentStatus != "null")
        {
          InvestmentPagePOM.ClickOnMoreFilter_InvestmentsPage(_driver);
          InvestmentPagePOM.ClickOnStatusFilter_InvestmentsPage(_driver);
        }
      }
            Thread.Sleep(1000);
            if(InvestmentStatus!="null")
            InvestmentPagePOM.SelectStatusFromFilterDropDown_InvestmentsPage(_driver, InvestmentStatus);
            Thread.Sleep(1000);
            OfferingPagePOM.ClickOnApplyButton(_driver);
            OfferingPagePOM.ClickOnApplyButton(_driver);
            BaseClass.WaitForSpinnerToDisappear(_driver);
            
        }

    [When(@"Search for Joint investor with status on Investment page (.*)")]
    public void WhenSearchForJointInvestorWithStatusOnInvestmentPage(string InvestmentStatus)
    {//with Name and status
      string InvestoreName;
      if (InvestmentStatus.ToLower().Contains("1"))
      {

        if (((string)_scenarioContext["InvestorMN 1"]).Contains("-"))
        {
          InvestoreName = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorLN 1"]}";
        }
        else
        {
          InvestoreName = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorMN 1"]} {(string)_scenarioContext["InvestorLN 1"]}";
        }
      }
      else
      {
        if (((string)_scenarioContext["InvestorMN 2"]).Contains("-"))
        {
          InvestoreName = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorLN 1"]} & {(string)_scenarioContext["InvestorFN 2"]} {(string)_scenarioContext["InvestorLN 2"]}";
        }
        else
        {
          InvestoreName = $"{(string)_scenarioContext["InvestorFN 1"]} {(string)_scenarioContext["InvestorMN 1"]} {(string)_scenarioContext["InvestorLN 1"]} & {(string)_scenarioContext["InvestorFN 2"]} {(string)_scenarioContext["InvestorMN 2"]} {(string)_scenarioContext["InvestorLN 2"]}";
        }

      }

      if (InvestoreName != "null")
        InvestmentPagePOM.EnterInputToFilter_InvestmentsPage(_driver, "Name", InvestoreName);


      try
      {
        InvestmentPagePOM.ClickOnStatusFilter_InvestmentsPage(_driver);
      }
      catch
      {
        //if in more filter
        InvestmentPagePOM.ClickOnMoreFilter_InvestmentsPage(_driver);
        InvestmentPagePOM.ClickOnStatusFilter_InvestmentsPage(_driver);
      }
      Thread.Sleep(1000);

      if (InvestmentStatus != "null")
        InvestmentPagePOM.SelectStatusFromFilterDropDown_InvestmentsPage(_driver, InvestmentStatus);
      Thread.Sleep(1000);
      OfferingPagePOM.ClickOnApplyButton(_driver);
      OfferingPagePOM.ClickOnApplyButton(_driver);
      BaseClass.WaitForSpinnerToDisappear(_driver);

    }

    [When(@"Search name of Investor on Investor page with investor status and Type (.*), (.*)")]
    public void SearchforInvestornameonInvestorpagewithinvestorstatusandType(string status,string investorType)
    {//Investor Signed
      

      
      try
      {
        InvestmentPagePOM.ClickOnStatusFilter_InvestmentsPage(_driver);
      }
      catch
      {
        //if in more filter
        InvestmentPagePOM.ClickOnMoreFilter_InvestmentsPage(_driver);
        InvestmentPagePOM.ClickOnStatusFilter_InvestmentsPage(_driver);
      }
      Thread.Sleep(1000);
      if (status != "null")
        InvestmentPagePOM.SelectStatusFromFilterDropDown_InvestmentsPage(_driver, status);
      Thread.Sleep(1000);

      OfferingPagePOM.ClickOnApplyButton(_driver);
      InvestorPagePOM.ClickOnTypeFilter_InvestmentPage(_driver);
      Thread.Sleep(1000);
      foreach (string type in investorType.Split('&'))
        AddInvestorPOM.ClickOnInvestorOption_InvestorTypeFilter_InvestorPage(_driver, type);


      OfferingPagePOM.ClickOnApplyButton(_driver);
      OfferingPagePOM.ClickOnApplyButton(_driver);
      BaseClass.WaitForSpinnerToDisappear(_driver);

    }
    [When(@"Search investment with Name, Offering, Status on Investment page (.*), (.*), (.*)")]
    public void WhenSearchInvestmentWithNameOfferingStatusOnInvestmentPage(string investorName,string offering, string investmentStatus )
    {
      if (investorName != "null")
        EnterInputValue(_driver, "Investor Name").SendKeys(investorName);
      if (offering != "null")
        EnterInputValue(_driver,"Offering Name").SendKeys(offering);

      InvestmentPagePOM.ClickOnMoreFilter_InvestmentsPage(_driver);
      InvestmentPagePOM.ClickOnStatusFilter_InvestmentsPage(_driver);
      if (investmentStatus != "null")
        InvestmentPagePOM.SelectStatusFromFilterDropDown_InvestmentsPage(_driver, investmentStatus);


      OfferingPagePOM.ClickOnApplyButton(_driver);
      OfferingPagePOM.ClickOnApplyButton(_driver);
      BaseClass.WaitForSpinnerToDisappear(_driver);
    }
    [When(@"Get investment name from investment page")]
    public void WhenGetInvestmentNameFromInvestmentPage()
    {
      _scenarioContext["InvestorName"]= InvestorPagePOM.ClickOnInvestorName_InvestorPage(_driver, 1).GetAttribute("textContent").Trim('.');
    }
    [When(@"Navigate to the investment page")]
    public void WhenNavigateToTheInvestmentPage()
    {
      InvestmentPagePOM.NavigateToInvestmentPage(_driver);
      WaitForSpinnerToDisappear(_driver);
    }

    [Then(@"Validate that the status of Investment reflecting properly (.*)")]
        public void ThenValidateThatTheStatusOfInvestmentReflectingProperly(string InvestmentStatus)
        {
            Assert.That(InvestmentPagePOM.CheckStatusOfInvestment_InvestmentsPage(_driver,1).ToLower().Contains(InvestmentStatus.ToLower()));

        }

        [Given(@"Click on Investment name in investment list")]
        public void GivenClickOnInvestmentNameInInvestmentList()
        {
            InvestmentPagePOM.CheckInvestoreInList(_driver,1).Click();
            Thread.Sleep(7000);
        }

        [When(@"Click on Investment Details step")]
        public void WhenClickOnInvestmentDetailsStep()
        {
            Thread.Sleep(5000);
            AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver,"Investment Details").Click();  
            Thread.Sleep(2000);
        }

        [Then(@"Validate that Investment Details section display record properly (.*),(.*),(.*),(.*)")]
        public void ThenValidateThatInvestmentDetailsSectionDisplayRecordProperly(string InvestmentAmount,string MonthlyIncome,string MonthlyCompound,string EstimatedIncome)
        {
            string KeyTexts = "Investment Amount|Monthly Income|Monthly Compound|Estimated Monthly Income";
            //string[] ValueTexts = { InvestmentAmount , MonthlyIncome, MonthlyCompound , EstimatedIncome };
            string[] ValueTexts = { "1,000", MonthlyIncome, MonthlyCompound, EstimatedIncome };
            int i = -1;
            foreach(string keyText in KeyTexts.Split('|'))
            {
                i++;
                try
                {
                    string t = InvestmentPagePOM.CheckInvestmentDetails_InvestmentsPage(_driver, keyText);
                    string j = ValueTexts[i].Trim();
            Assert.That(t.Contains(j));
                }
                catch { }
            }

        }

        [When(@"Click on Investor eSign step")]
        public void WhenClickOnInvestorESignStep()
        {
            AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Investor eSign").Click();
            Thread.Sleep(2000);
        }

        [Then(@"Validate that Investor eSign section reflecting record properly")]
        public void ThenValidateThatInvestorESignSectionReflectingRecordProperly()
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            try
            {

            Assert.That(InvestmentPagePOM.ClickOneSignButton_InvestoreSign_InvestmentsPage(_driver).Displayed);
                _scenario.Log(Status.Fail, "Failed, eSign button displaying on investor eSign section even on signed by investor");
                
            }
            catch
            {
                _scenario.Log(Status.Pass, " eSign button is not displaying on investor eSign section on signed by investor");
            }
        }

        [When(@"Click on Investor accreditation step")]
        public void WhenClickOnInvestorAccreditationStep()
        {
            AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Investor Accreditation").Click();
            Thread.Sleep(2000);
        }
    [When(@"Complete the Accreditation of investment at company side")]
    public void WhenCompleteTheAccreditationOfInvestmentAtCompanySide()
    {
      SelectValue_Sendkey(_driver, "Accreditation Status").SendKeys("Current");
      EnterInputValue(_driver, "Accreditation Expiry Date").SendKeys(Date.ToString("MM/dd/yyyy"));
    }


    [Then(@"Validate that the Accreditation details reflects record properly")]
        public void ThenValidateThatTheAccreditationDetailsReflectsRecordProperly()
        {
         Assert.That("current|pending".Contains(AddInvestmentPOM.CheckAccreditionStatus_AddInvestmentProcess(_driver).ToLower()));//current|pending    
        }

        [When(@"Click on Company eSign step")]
        public void WhenClickOnCompanyESignStep()
        {
            Thread.Sleep(4000);
            AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Company eSign").Click();
            Thread.Sleep(2000);
        }
        [When(@"Click on Make Payment step")]
        public void WhenClickOnMakePaymentStep()
        {
            Thread.Sleep(5000);
            AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Make Payment").Click();
            BaseClass.WaitForSpinnerToDisappear(_driver);
            Thread.Sleep(5000);
        }


        [When(@"Click on Click to eSign button")]
        public void WhenClickOnClickToESignButton()
    {
      try
      {

            InvestmentPagePOM.ClickOneSignButton_CompanyeSign_InvestmentsPage(_driver).Click();
            BaseClass.WaitForSpinnerToDisappear(_driver);
        //BaseClass.Success_Notification(_driver);
      }
      catch
      {
        // if eSign button is not available in company sign section
        try
        {
          Console.WriteLine("eSign button is not available in company sign section");
          Thread.Sleep(4000);
        AddInvestmentPOM.ClickOnNextButton_AddInvestmentProcess(_driver);
        InvestmentPagePOM.ClickOnConfirmButton_CompanyeSignButton_InvestoreSign_InvestmentsPage(_driver);
        }
        catch { }
      }
            
        }

        [Then(@"Complete Company eSign process")]
        public void ThenCompleteCompanyESignProcess()
        {

            Thread.Sleep(5000);
            List<string> address = new List<string>(_driver.WindowHandles);
            Console.WriteLine(address.Count);
            _driver.SwitchTo().Window(address[1]);
      Boolean visibilityOfElelement = true;
      Thread.Sleep(2000);
      AddInvestmentPOM.ClickOnContinue_DocumentPage_AddInvestmentProcess(_driver).Click();
      int i = 0;
      while (i < 8)
      {
        AddInvestmentPOM.ClickOnNextButton_AdobeDoc_AddInvestmentProcess(_driver);
        i++;
      }

      while (visibilityOfElelement)
      {
        try
        {

            AddInvestmentPOM.ClickToSign_AddInvestmentProcess(_driver);
            AddInvestmentPOM.AddSignForDocument_AddInvestmentProcess(_driver).SendKeys("CompanyManager");
            AddInvestmentPOM.ClickOnApplyButton_DocumentSign_AddInvestmentProcess(_driver);
          visibilityOfElelement = false;
        }
        catch { }
      }
      Thread.Sleep(2000);

        visibilityOfElelement = true;
        i= 0;
      while(visibilityOfElelement&&i<3)
        {
        i++;

          try
          {
            AddInvestmentPOM.ClickToSign_AddInvestmentProcess(_driver,2);
            visibilityOfElelement=false;
            AddInvestmentPOM.ClickOnCloseButton_DocumentSign_AddInvestmentProcess(_driver);
          }
          catch { }      
      
        }
            AddInvestmentPOM.ClickToSign_Document_AddInvestmentProcess(_driver);
            AddInvestmentPOM.DocumentSpinnerDisappear_AddInvestmentProcess(_driver);
            _driver.Close();
            _driver.SwitchTo().Window(address[0]);
        }

        [Then(@"validate that Company eSign completion reflected properly")]
        public void ThenValidateThatCompanyESignCompletionReflectedProperly()
        {
            BaseClass.WaitForSpinnerToDisappear(_driver);
            InvestmentPagePOM.ClickOnRefereshButton_InvestmentPage(_driver);
            Thread.Sleep(2000);
       BaseClass.WaitForSpinnerToDisappear(_driver);
      _driver.Navigate().Refresh();
            BaseClass.WaitForSpinnerToDisappear(_driver);
            
        }
        
        [When(@"Click on Confirm button of make payment")]
        public void WhenClickOnConfirmButtonOfMakePayment()
        {
            
           
            InvestmentPagePOM.ClickOnConfirmButton_CompanyeSignButton_InvestoreSign_InvestmentsPage(_driver);
            Thread.Sleep(5000);
        }
    [Then(@"If the additional info has been saved then confirm and proceed it")]
    public void ThenValidateThatItNavigatesToTheAdditionalInfoSectionOfAddInvestmentFlow()
    {
      Thread.Sleep(3000);
      try
      {
        
          if (AddInvestmentPOM.WaitForInvisibilityOfStepMessage_AddInvestmentProcess(_driver))
          {
          Assert.That( InvestmentPagePOM.ClickOnConfirmButton_AdditionalInfoStep_InvestmentsPage(_driver).Displayed);
          Thread.Sleep(3000);
        InvestmentPagePOM.ClickOnConfirmButton_AdditionalInfoStep_InvestmentsPage(_driver).Click();
        AddInvestmentPOM.ClickOnConfirmButton_AddInvestmentProcess(_driver).Click();
          }
      }
      catch
      {

      }
    }

    [When(@"Click on Confirm and Proceed button")]
    public void WhenClickOnConfirmAndProceedButton()
    {
      InvestmentPagePOM.ClickOnConfirmButton_AdditionalInfoStep_InvestmentsPage(_driver).Click();
    }

    [Then(@"validate that it navigate to the Make payment step")]
        public void ThenValidateThatItNavigateToTheMakePaymentStep()
        {
            Thread.Sleep(5000);
            Assert.That(AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver,"Make Payment").GetAttribute("aria-selected").Contains("true"));
            
        }
        
        [Given(@"Select payment channel from popup (.*)")]
        public void GivenSelectPaymentChannelFromPopupCheck(string PaymentChannel)
        {
            
            InvestmentPagePOM.SelectMakePaymentType_InvestmentsPage(_driver, PaymentChannel.Trim('"'));
            InvestmentPagePOM.ClickOnConfirm_MakePaymentStep_InvestmentsPage(_driver);
            Thread.Sleep(5000);
        }
    [Then(@"Validate that the second Investor can't make the payment (.*)")]
    public void ThenValidateThatTheSecondInvestorCantMakeThePayment(string Message)
    {
      try
      {
        Assert.That(BaseClass.Success_Notification(_driver).Text.Contains(Message.Trim('"')) || BaseClass.Success_Notification(_driver).Text.Contains(Message.Trim('"').ToLower()));
      }
      catch (Exception e)
      {
        Assert.IsTrue(false, BaseClass.Success_Notification(_driver).Text);
      }
    }

    [Then(@"validate that it navigate to finalize payment step")]
        public void ThenValidateThatItNavigateToFinalizePaymentStep()
        {
            //AddInvestmentPOM.CheckInvestmentStatusAtTop_AddInvestmentProcess(_driver, "Amount Transferred");
            Thread.Sleep(3000);
            Assert.That(AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Finalize Investment").GetAttribute("aria-selected").Contains("true"));
        }

        [Given(@"Click on Finalize Investments step")]
        public void GivenClickOnFinalizeInvestmentsStep()
        {
            AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Finalize Investment").Click();
        }

        [When(@"Enter Payment Receipt Date and Save")]
        public void WhenEnterPaymentRecieptDateAndSave()
        {
            DateTime Time = DateTime.Now;
            InvestmentPagePOM.EnterPaymentRecieptDate_FinalizeStep_InvestmentsPage(_driver, Time.ToString("MM/dd/yyyy"));
            InvestmentPagePOM.ClickOnSavePaymentRecieptDate_FinalizeStep_InvestmentsPage(_driver);
            WaitForSpinnerToDisappear(_driver);
            Thread.Sleep(5000);
        }

        [When(@"Select Finder for commission")]
        public void WhenSelectFinderForCommissionAndSetCommission()
        {
      WaitForSpinnerToDisappear(_driver);
      InvestmentPagePOM.SelectElementForCommission_InvestmentsPage(_driver, "Select Finder for Compensation", 1).Click();
            InvestmentPagePOM.ClickOnDoubleClick_FinalizeStep_InvestmentsPage(_driver, "Select Finder for Compensation");
            BaseClass.InvisibleSuccess_Notification(_driver);
            Thread.Sleep(4000);
            InvestmentPagePOM.ClickOnSetPermissionButton_FinalizeStep_InvestmentsPage(_driver, "Select Finder for Compensation");
            Thread.Sleep(4000);

        }

        [When(@"Select Sales Rep for Commission")]
        public void WhenSelectSalesRepForCommissionAndSetCommission()
        {
            InvestmentPagePOM.SelectElementForCommission_InvestmentsPage(_driver, "Select Sales Rep for Compensation", 1).Click();
            InvestmentPagePOM.ClickOnDoubleClick_FinalizeStep_InvestmentsPage(_driver, "Select Sales Rep for Compensation");
            BaseClass.InvisibleSuccess_Notification(_driver);
            
            Thread.Sleep(4000);
            InvestmentPagePOM.ClickOnSetPermissionButton_FinalizeStep_InvestmentsPage(_driver, "Select Sales Rep for Compensation");
            Thread.Sleep(4000);
        }

        [Then(@"Click on Finalize button")]
        public void ThenClickOnFinalizeButton()
        {
            InvestmentPagePOM.ClickOnFinalizeButton_FinalizeStep_InvestmentsPage(_driver);
        }
        [Then(@"Validate that success-notification displaying properly")]
        public void ThenValidateThatSuccess_NotificationDisplayingProperly()
        {
            Assert.That(BaseClass.Success_Notification(_driver).Displayed);
        }
        [Then(@"Finalize the investment by clicking on confirm button")]
        public void ThenFinalizeTheInvestmentByClickingOnConfirmButton()
        {
            InvestmentPagePOM.ClickOnConfirmButton_FinalizeInvestment_InvestmentsPage(_driver);
        }

        [Then(@"Check Finder commission displaying properly")]
        public void ThenCheckFinderCommissionDisplayingProperly()
        {
            Assert.That(InvestmentPagePOM.CheckFinderCommission_FinalizeStep_InvestmentsPage(_driver,1));
        }
        

        [When(@"SetCommision for Finder")]
        public void WhenSetCommisionForFinder()
        {
            InvestmentPagePOM.EnterFinderCommission_FinalizeStep_InvestmentsPage(_driver,1);
            InvestmentPagePOM.ClickOnSaveFinderCommission_FinalizeStep_InvestmentsPage(_driver);
        }

        [When(@"SetCommission for Sales Rep")]
        public void WhenSetCommissionForSalesRep()
        {
            InvestmentPagePOM.EnterSalesRepCommission_FinalizeStep_InvestmentsPage(_driver,1);
            InvestmentPagePOM.ClickOnSaveSaleRepCommission_FinalizeStep_InvestmentsPage(_driver);
        }
        [Then(@"Validate that the status of investment got updated")]
        public void ThenValidateThatTheStatusOfInvestmentGotUpdated()
        {
            Assert.That(InvestmentPagePOM.CheckInvestmentDate_InvestmentsPage(_driver,DateTime.Now.ToString("MM-dd-yyyy")));
        }

        [Given(@"Navigate to Manage investment page")]
        public void GivenNavigateToManageInvestmentPage()
        {
            ManageInvestmentPagePOM.NavigateToManageInvestmentPage(_driver);
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }




        //*************************************************************DefinitionsOf_Edit-Investment******************************************************************************************

        [Given(@"Click on Investment details section")]
        public void GivenClickOnInvestmentDetailsSection()
        {
            AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Investment Details").Click();
            Thread.Sleep(4000);
        }

        [Given(@"Click on Edit-Investment button")]
        public void GivenClickOnEdit_InvestmentButton()
        {
            Actions act = new Actions(_driver);
            act.MoveToElement(AddInvestmentPOM.ClickOnEditbutton_InvestmentsPage(_driver)).Click().Build().Perform();
        
            Thread.Sleep(2000);
        }
        [Then(@"Validate that the Edit button is not available for the investment")]
        public void ThenValidateThatTheEditButtonIsNotAvailableForTheInvestment()
        {
            bool Result=false;
            try
            {

                Result = AddInvestmentPOM.ClickOnEditbutton_InvestmentsPage(_driver).Displayed;
                    Assert.Fail();
            }
            catch { Assert.That(!Result); }
           
        }


        [Then(@"Validate that Edit button navigate to the investment detail step of investment")]
        public void ThenValidateThatEditButtonNavigateToTheInvestmentDetailStepOfInvestment()
        {            
            Assert.That(AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver, "Investment Details").GetAttribute("aria-selected").Contains("true"));            
        }

        [When(@"Click on View investment")]
        public void WhenClickOnViewInvestment()
        {
            ManageInvestmentPagePOM.ClickOnViewInvestment_ManageInvestmentPage(_driver);
            BaseClass.WaitForSpinnerToDisappear(_driver);
        }

        [Given(@"Edit Investment amount more than minimum amount (.*), (.*)")]
        public void GivenEditInvestmentAmountMoreThanMinimumAmount(string InvestmentAmount, string ParentTrancheNumber)
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            int a = int.Parse(ParentTrancheNumber.Trim('"'));
            Edit_Investment.EnterInvestmentAmount_AddInvestmentProcess(_driver, a).Clear();
            Edit_Investment.EnterInvestmentAmount_AddInvestmentProcess(_driver, a).SendKeys(InvestmentAmount);
            _scenario.Log(Status.Pass, $"Entered Investment amount {InvestmentAmount}");
            _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
        }

        [When(@"Edit Value in Monthly income field (.*), (.*)")]
        public void WhenEnterValueInMonthlyIncomeField2(string InputValue, string ParentTrancheNumber)
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            int a = int.Parse(ParentTrancheNumber.Trim('"'));
            try
            {

                Edit_Investment.EnterInputToTrancheField_AddInvestmentProcess(_driver, a, "Monthly Income").Clear();
                Edit_Investment.EnterInputToTrancheField_AddInvestmentProcess(_driver, a, "Monthly Income").SendKeys(InputValue);
                _scenario.Log(Status.Pass, $"Entered value in monthly income field {InputValue}");
                _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
            }
            catch (Exception e)
            {
                _scenario.Log(Status.Fail, $"Entered value in monthly income field {InputValue} Error: " + e);
                _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
            }
            Thread.Sleep(2000);
        }

        [Then(@"Validate Edited Estimated monthly income field show correct value (.*)")]
        public void ThenValidateEstimatatedMonthalyIncomeFieldShowCorrectValue2(string Value)
        {
            string v = Edit_Investment.CheckEstimatedMonthlyIncome_AddInvestmentProcess(_driver, 1).Text;
            Assert.That(Edit_Investment.CheckEstimatedMonthlyIncome_AddInvestmentProcess(_driver, 1).Text.Contains(Value));
        }

        [Then(@"validate that the Make Payment show correct Edited Amount (.*), (.*)")]
        public void ThenValidateThatTheMakePaymentShowCorrectEditedAmount(int InvestementAmount, int EditedInvestmentAmount)
        {
            int TotalAmount = InvestementAmount+EditedInvestmentAmount;
            Assert.That(Edit_Investment.CheckAmountTobeInvested_EditInvestmentProcess(_driver).Contains(TotalAmount.ToString()));
           
        }
        [When(@"SetCommision for Finder for multiple Tranche (.*)")]
        public void WhenSetCommisionForFinder2(string TrancheNumber)
        {for(int i=1;i<=Int32.Parse(TrancheNumber.Trim('"'));i++)
            {

            InvestmentPagePOM.EnterFinderCommission_FinalizeStep_InvestmentsPage(_driver, 1,i);
            }
            InvestmentPagePOM.ClickOnSaveFinderCommission_FinalizeStep_InvestmentsPage(_driver);
        }
        [When(@"SetCommission for Sales Rep for multiple Tranche (.*)")]
        public void WhenSetCommissionForSalesRep2(string TrancheNumber)
        {
            for(int i=1;i<= Int32.Parse(TrancheNumber.Trim('"'));i++)
            {
            InvestmentPagePOM.EnterSalesRepCommission_FinalizeStep_InvestmentsPage(_driver, 1, i);

            }
            InvestmentPagePOM.ClickOnSaveSaleRepCommission_FinalizeStep_InvestmentsPage(_driver);
        }
        [When(@"Clear the investment Filter")]
        public void WhenClearTheInvestmentFilter()
        {
            FilterPOM.ClickClearbutton_Filter(_driver);
        }
        [When(@"Validate the Invested amount reflected properly (.*),(.*),(.*)")]
        public void WhenValidateTheInvestedAmountReflectedProperly(string TrancheNumber,string Amount1,string Amount2)
        {
            for(int i=1;i<=Int32.Parse(TrancheNumber.Trim('"'));i++)
            {
            string getText = InvestmentDetailsPagePOM.CheckInvestmentAmount_InvestedInvestment_InvestmentDetailsPage(_driver, i);
            Assert.IsTrue(getText.Contains(Amount1)||getText.Contains(Amount2));
            }
        }

        [When(@"Validate that the Monthly income % displaying properly (.*),(.*),(.*)")]
        public void WhenValidateThatTheMonthlyIncomeDisplayingProperly(string TrancheNumber,string Percent1,string Percent2)
        {
            for (int i = 1; i <= Int32.Parse(TrancheNumber.Trim('"')); i++)
            {
                string getText = InvestmentDetailsPagePOM.CheckMonthlyIncomePercentage_InvestedInvestment_InvestmentDetailsPage(_driver, i);
                Assert.IsTrue(getText.Contains(Percent1) || getText.Contains(Percent2));
            }
        }
        [When(@"Get Investment details (.*)")]
        public void WhenGetInvestmentDetails(string TrancheNumber)
        {
            Thread.Sleep(5000);
            int a = Int32.Parse(TrancheNumber.Trim('"'));
            _scenarioContext["InvestmentAmount"] = InvestmentPagePOM.CheckInvestmentAmount_InvestmentDetails_InvestmentsPage(_driver,a);
            Thread.Sleep(2000);
            _scenarioContext["MonthlyIncome"] = InvestmentPagePOM.CheckMonthlyIncomePercentage_InvestmentDetails_InvestmentsPage(_driver,a);
            Thread.Sleep(2000);
        }
        [Given(@"Get Investment details on Company profile (.*)")]
        public void WhenGetInvestmentDetails2(string TrancheNumber)
        {
            Thread.Sleep(5000);
            _scenarioContext["InvestmentAmount"] = InvestmentPagePOM.CheckInvestmentAmountCompanyProfile_InvestmentDetails_InvestmentsPage(_driver, Int32.Parse(TrancheNumber.Trim('"')));
            _scenarioContext["MonthlyIncome"] = InvestmentPagePOM.CheckMonthlyIncomePercentageCompanyProfile_InvestmentDetails_InvestmentsPage(_driver, Int32.Parse(TrancheNumber.Trim('"')));

        }
        [Then(@"Validate that simulator displaying proper data (.*)")]
        public void ThenValidateThatSimulatorDisplayingProperData(string TrancheNumber)
        {
            int Tranche = Int32.Parse(TrancheNumber.Trim('"'));
            string GetInvestedAmount = Edit_Investment.EnterInvestmentAmount_AddInvestmentProcess(_driver, Int32.Parse(TrancheNumber.Trim('"'))).GetAttribute("value");
            string GetMonthlyPrecentage = Edit_Investment.EnterInputToTrancheField_AddInvestmentProcess(_driver, Int32.Parse(TrancheNumber.Trim('"')), "Monthly Income").GetAttribute("value");
            string ExpectedInvestmentAmount = (string)_scenarioContext["InvestmentAmount"];
            string ExpectedMonthlyIncome = (string)_scenarioContext["MonthlyIncome"];
            Assert.That(ExpectedInvestmentAmount.Trim('$').Replace(",", "").Contains(GetInvestedAmount.Trim('$').Replace(",","")));
            Assert.That(ExpectedMonthlyIncome.Trim('$').Replace(",", "").Contains(GetMonthlyPrecentage.Trim('$').Replace(",", "")));


        }
        [When(@"Edit Simulator data (.*)")]
        public void WhenEditSimulatorData(string TrancheNumber)
        {
            int tranche = Int32.Parse(TrancheNumber.Trim('"'));
            _scenario = (ExtentTest)_scenarioContext["scenario"];

            string ExpectedInvestmentAmount = (string)_scenarioContext["InvestmentAmount"];
            string ExpectedMonthlyIncome = (string)_scenarioContext["MonthlyIncome"];
            double A = double.Parse(ExpectedInvestmentAmount.Trim('$').Replace(",", "")) + 100;
            Edit_Investment.EnterInvestmentAmount_AddInvestmentProcess(_driver, tranche).Clear();
            Edit_Investment.EnterInvestmentAmount_AddInvestmentProcess(_driver, tranche).SendKeys(A.ToString());
            _scenarioContext["EditedInvestmentAmount"]= Edit_Investment.EnterInvestmentAmount_AddInvestmentProcess(_driver, Int32.Parse(TrancheNumber.Trim('"'))).GetAttribute("value");
            double B = double.Parse(ExpectedMonthlyIncome.Trim('%'));
            B = B + 10;
            Edit_Investment.EnterInputToTrancheField_AddInvestmentProcess(_driver, tranche, "Monthly Income").Clear();
            Edit_Investment.EnterInputToTrancheField_AddInvestmentProcess(_driver, tranche, "Monthly Income").SendKeys(B.ToString());
            _scenarioContext["EditedMonthlyIncome"]= Edit_Investment.EnterInputToTrancheField_AddInvestmentProcess(_driver, Int32.Parse(TrancheNumber.Trim('"')), "Monthly Income").GetAttribute("value");
        }

    //***************************************************************Validation of data on Investment details page****************************************************************

    [Then(@"Validate that the Investment Details section displaying properly (.*)")]
    public void ThenValidateThatTheInvestmentDetailsSectionDisplayingProperly(string numberOfTrancheInvested)
    {
      WaitForSpinnerToDisappear(_driver);
      _scenarioContext["InvestmentDate"] = InvestmentDetailsPagePOM.CheckDateOfInvested_InvestmentDetailsPage(_driver);
      string a = InvestmentDetailsPagePOM.CheckNumberOFTranchInvested_InvestmentDetailsPage(_driver);
      Assert.That(InvestmentDetailsPagePOM.CheckNumberOFTranchInvested_InvestmentDetailsPage(_driver).Contains(numberOfTrancheInvested));
    }

    [Then(@"Validate that the Tranche details section displaying properly (.*), (.*)")]
    public void ThenValidateThatTheTrancheDetailsSectionDisplayingProperly(string amount, int trancheNumber)
    {
      string effectiveInterestRate = ((string)_scenarioContext[$"EffectiveInterestRate {trancheNumber}"]);
      string bonus = (string)_scenarioContext[$"Bonus {trancheNumber}"];
      string monthlyIncome = (string)_scenarioContext[$"MonthlyIncome {trancheNumber}"];
      string interestRate = (string)_scenarioContext[$"InterestRate {trancheNumber}"];
      

      string maturityDate = Date.AddYears(trancheNumber).ToString("MMMM dd, yyyy");



      Assert.IsTrue(InvestmentDetailsPagePOM.CheckIntrestRate_InvestedInvestment_InvestmentDetailsPage(_driver,trancheNumber).Contains(interestRate));
      Assert.IsTrue(InvestmentDetailsPagePOM.CheckInvestmentAmount_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber).Contains(amount),"Investment amount not displaying properly");
      Assert.IsTrue(InvestmentDetailsPagePOM.CheckEffectiveInterestRate_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber).Contains(effectiveInterestRate),"Effective interest rate displaying incorrectly");
      Assert.IsTrue(InvestmentDetailsPagePOM.CheckBonus_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber).Contains(bonus),"Bonus displaying incorrectly");
      Assert.IsTrue(InvestmentDetailsPagePOM.CheckMaturityDate_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber).Contains(maturityDate),"Maturity date displaying incorrectly");
      Assert.IsTrue(InvestmentDetailsPagePOM.CheckMonthlyIncomePercentage_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber).Contains(monthlyIncome),"Monthly income displaying incorrectly");

    }
    [Then(@"Validate that Reinvestment Section displaying details properly (.*), (.*), (.*), (.*)")]
    public void ThenValidateThatReinvestmentSectionDisplayingDetailsProperly(int trancheNumber,Boolean isReInvested, int reInvestedTrancheNumber,string reInvestedValue)
    {
      string redeemedAmount;
      int.Parse(reInvestedValue);
      WaitForSpinnerToDisappear(_driver);
      try
      {

      InvestmentDetailsPagePOM.ExpandReinvestmentField_InvestmentDetailsPage(_driver, trancheNumber);
      }
      catch { }
      if(isReInvested)
      {
      Assert.IsTrue(InvestmentDetailsPagePOM.CheckReinvestedvalue_InvestmentDetailsPage(_driver, trancheNumber, reInvestedTrancheNumber).Contains(reInvestedValue),"ReInvested value not reflected properly");
      Assert.IsTrue(InvestmentDetailsPagePOM.CheckReddemedAmountOnMaturity_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber).Contains((100-int.Parse(reInvestedValue)).ToString()),"Redeemed Amount displaying incorrectly");

      }
      else
      {
        Assert.IsTrue(InvestmentDetailsPagePOM.CheckReddemedAmountOnMaturity_InvestedInvestment_InvestmentDetailsPage(_driver, trancheNumber).Contains("100"), "Redeemed Amount displaying incorrectly");
      }

      
    }
    [Then(@"Validate Re-Investment value and Withdraw value are displaying properly on simulator of respective Tranche (.*), (.*), (.*)")]
    public void ThenValidateRe_InvestmentValueAndWithdrawValueAreDisplayingProperlyOnSimulatorOfRespectiveTranche(int trancheNumber, int reInvestedTrancheNumber, string reInvestedValue)
    {
      string redeemedAmount;
      int.Parse(reInvestedValue);
      try
      {

        InvestmentDetailsPagePOM.ExpandReinvestmentFieldOfSimulator_InvestmentDetailsPage(_driver, trancheNumber);
      }
      catch { }
      
        Assert.IsTrue(InvestmentDetailsPagePOM.Read_ReinvestmentValueOfSimulatorTrancheField_InvestmentdetailsPage(_driver, trancheNumber, reInvestedTrancheNumber).Text.Contains(reInvestedValue), "ReInvested value not reflected properly");
        Assert.IsTrue(InvestmentDetailsPagePOM.Read_Reinvestment_WithrowAmountOnSimulatorTrancheField_InvestmentdetailsPage(_driver, trancheNumber).Text.Contains((100 - int.Parse(reInvestedValue)).ToString()), "Redeemed Amount displaying incorrectly");

     
    }

    [Then(@"Validate that the Monthly Income Breakdown displaying properly")]
    public void ThenValidateThatTheMonthlyIncomeBreakdownDisplayingProperly()
    {
     
    }

    [Then(@"Validate that the Return Simulator displaying data properly (.*), (.*)")]
    public void ThenValidateThatTheReturnSimulatorDisplayingDataProperly(int trancheNumber,string amount)
    {
      string value=InvestmentDetailsPagePOM.EnterInputToTrancheField_InvestmentDetailsPage(_driver, trancheNumber, "Monthly Income").GetAttribute("value");

      string effectiveInterestRate = (string)_scenarioContext[$"EffectiveInterestRate {trancheNumber}"];
      string bonus = (string)_scenarioContext[$"Bonus {trancheNumber}"];
      string maturityDate = Date.AddYears(trancheNumber).ToString("MMMM dd, yyyy");
      string monthlyIncome = (string)_scenarioContext[$"MonthlyIncome {trancheNumber}"];
      string estimatedIncome = (string)_scenarioContext[$"EstimatedMonthlyIncome {trancheNumber}"];
   

      Assert.IsTrue(InvestmentDetailsPagePOM.EnterInputToTrancheField_InvestmentDetailsPage(_driver, trancheNumber, "Investment Amount").GetAttribute("value").Replace(",","").Contains(amount), "Investment amount not displaying properly");
      Assert.IsTrue(InvestmentDetailsPagePOM.ReadValueOfSimulatorTrancheField_InvestmentdetailsPage(_driver, trancheNumber, "Effective Interest Yield").Text.Contains(effectiveInterestRate), "Effective interest rate displaying incorrectly");
      Assert.IsTrue(InvestmentDetailsPagePOM.ReadValueOfSimulatorTrancheField_InvestmentdetailsPage(_driver, trancheNumber, "Bonus").Text.Contains(bonus), "Bonus displaying incorrectly");
      Assert.IsTrue(InvestmentDetailsPagePOM.ReadValueOfSimulatorTrancheField_InvestmentdetailsPage(_driver, trancheNumber, "Maturity Date").Text.Contains(maturityDate), "Maturity date displaying incorrectly");
      Assert.IsTrue(InvestmentDetailsPagePOM.EnterInputToTrancheField_InvestmentDetailsPage(_driver, trancheNumber, "Monthly Income").GetAttribute("value").Contains(monthlyIncome), "Monthly income displaying incorrectly");
      Assert.IsTrue(InvestmentDetailsPagePOM.ReadValueOfSimulatorTrancheField_InvestmentdetailsPage(_driver, trancheNumber, "Estimated Monthly Income").Text.Contains(estimatedIncome), "Redeemed Amount displaying incorrectly");
    }




    //********************************************************************AdditionalInformation Definition********************************************************
    [When(@"Fill the Additional information form (.*)")]
    public void WhenFillTheAdditionalInformationForm(string investorType)
    {
      Thread.Sleep(5000);
      if (AddInvestmentPOM.CheckInvestmentStatusAtTop_AddInvestmentProcess(_driver).Contains("Requested"))
        if (AddInvestmentPOM.WaitForInvisibilityOfStepMessage_AddInvestmentProcess(_driver))
        {
          if("individual|joint|ira".Contains( investorType.ToLower()))
          {
            if("individual".Contains(investorType.ToLower()))
              EnterInputValue(_driver, JsonData()["DOB"]).SendKeys(Date.ToString("MM/dd/yyyy"));
            else
            EnterInputValue(_driver, JsonData()["DOBc"]).SendKeys(Date.ToString("MM/dd/yyyy"));
          }
      SelectValue_Sendkey(_driver, JsonData()["State"]).SendKeys(State);
      EnterInputValue(_driver, JsonData()["Signer"]).SendKeys("Signer");

      EnterInputValue(_driver, JsonData()["HearAbout"]).SendKeys("HearAbout");
      EnterInputValue(_driver, JsonData()["RelationshipToManager"]).SendKeys("RelationshipToManager");
      EnterInputValue(_driver, JsonData()["BusinessName"]).SendKeys("Yrefy");
      EnterInputValue(_driver, JsonData()["Position"]).SendKeys("Admin");
        }
    }

  [When(@"Fill the Additional info form for joint")]
  public void WhenFillTheAdditionalInformationFormForJoint()
  {
    Thread.Sleep(5000);

      if (AddInvestmentPOM.CheckInvestmentStatusAtTop_AddInvestmentProcess(_driver).Contains("Requested"))
        if (AddInvestmentPOM.WaitForInvisibilityOfStepMessage_AddInvestmentProcess(_driver))
        {
          EnterInputValue(_driver, JsonData()["DOBc"]).SendKeys(Date.ToString("MM/dd/yyyy"));
          SelectValue_Sendkey(_driver, JsonData()["State"]).SendKeys(State);
        EnterInputValue(_driver, JsonData()["Signer"]).SendKeys("Signer");

        EnterInputValue(_driver, JsonData()["HearAbout"]).SendKeys("HearAbout");
        EnterInputValue(_driver, JsonData()["RelationshipToManager"]).SendKeys("RelationshipToManager");
        EnterInputValue(_driver, JsonData()["BusinessName"]).SendKeys("Yrefy");
        EnterInputValue(_driver, JsonData()["Position"]).SendKeys("Admin");
      }
  }
    //***************************************************************Re Investment Definitions******************************************************************************************

    [When(@"Click on Update Investment button on investment details page")]
    public void WhenClickOnUpdateInvestmentButtonOnInvestmentDetailsPage()
    {
      InvestmentDetailsPagePOM.ClickOnUpdateInvestmentButton_InvestmentDetailsPage(_driver);
    }
    [Given(@"Expand the Reinvestment field (.*)")]
    public void GivenExpandTheReinvestmentField(int trancheNumber)
    {     
      InvestmentDetailsPagePOM.ExpandReinvestmentField_InvestmentDetailsPage(_driver, trancheNumber);

    }

    [When(@"Enter the ReInvestent value to the ReInvestment field for Tranche (.*), (.*), (.*)")]
    public void WhenEnterTheReInvestentValueToTheReInvestmentFieldForTranche(int trancheNumber, int reInvestedTrancheNumber, string reInvestedValue)
    {
      InvestmentDetailsPagePOM.EnterReinvestedvalue_InvestmentDetailsPage(_driver,trancheNumber,reInvestedTrancheNumber,reInvestedValue);
    }
    [Given(@"Clear the Reinvested Value (.*)")]
    public void GivenClearTheReinvestedValue(int trancheNumber)
    {
      InvestmentDetailsPagePOM.ClearAllReInvestedValue_InvestmentDetailsPage(_driver, trancheNumber);
    }



  }
}
