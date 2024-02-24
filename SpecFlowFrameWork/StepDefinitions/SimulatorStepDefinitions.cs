using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SpecFlowFrameWork.Pages.OfferingPagePOM;
using SpecFlowFrameWork.Utility;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Yrefy_AutomationProject.Utility;

namespace Yrefy_AutomationProject.StepDefinitions
{
    [Binding]
    public class SimulatorStepDefinitions:BaseClass
    {
        private readonly IWebDriver _driver;

        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        private ExtentTest _scenario;


        public SimulatorStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext,FeatureContext featureContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            

        }
        [When(@"Click on the Simulate My investment section")]
        public void WhenClickOnTheSimulateMyInvestmentSection()
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            OfferingPagePOM.ClickOnSimulateMyInvestmentField(_driver);
            Thread.Sleep(4000);
            _scenario.Log(Status.Pass,"Clicked on the Simulate my simulate field");
            _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
        }

        [When(@"Provide required value to the input field")]
        public void WhenProvideRequiredValueToTheInputField()
        {
            
        }

        [When(@"Click on Simulate button")]
        public void WhenClickOnSimulateButton()
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            OfferingPagePOM.ClickOnSimulateButton(_driver, 2);
            Thread.Sleep(4000);
            _scenario.Log(Status.Pass, "Clicked on the Simulate button");
            _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));

        }

        [Then(@"Validate data of calculation table (.*), (.*), (.*), (.*)")]
        public void ThenValidateDataOfCalculationTable(double InitialBalance,double AnnualInterestRate,double monthlyIncome,string InvestOrReInvest)
        {
                _scenario = (ExtentTest)_scenarioContext["scenario"];
            string[] Month = { "No","Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            try
            {
                if(InvestOrReInvest.ToLower().Contains("reinvest"))
                {
                    IDictionary<string, string> ReadYearDataDic = OfferingPagePOM.ReadYearData_CalculationTable(_driver, 1);
                    InitialBalance = double.Parse(ReadYearDataDic["Principal"]);
                }
                int NumberOfYear=OfferingPagePOM.CheckNumberOfYearTable_CalculationTable(_driver);
                for (int i=1;i<=NumberOfYear;i++)
                {
                    OfferingPagePOM.ExpandYearTable_CalculationTable(_driver,i).Item1.Click();
                    Thread.Sleep(2000);
                    string Year =OfferingPagePOM.ExpandYearTable_CalculationTable(_driver, i).Item2;
                    _scenario.Log(Status.Pass,$"{Year} Year table expanded");
                    _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
                    Thread.Sleep(2000);
                    int NumberOfMonth=OfferingPagePOM.CheckNumberOfMonthTable_CalculationTable(_driver, i);
                    for(int j=1;j<=NumberOfMonth;j++)
                    {

                        try
                        {
                            
                            //Validate All data of table for the year
                            IDictionary<string,string>ReadMonthDataDic= OfferingPagePOM.ReadMonthlyData_CalculationTable(_driver,i,j);
                           int DaysInMonth= DateTime.DaysInMonth(int.Parse(Year), Array.IndexOf(Month, ReadMonthDataDic["Month"]));
                            try
                            {
                                Assert.That(ReadMonthDataDic["Principal"].Contains(InitialBalance.ToString()));
                                _scenario.Log(Status.Pass, $"{Year} Year Inner-table {ReadMonthDataDic["Month"]} month Principal {ReadMonthDataDic["Principal"]} displaying properly");
                                
                                    

                            }catch (Exception e)
                            {
                                _scenario.Log(Status.Fail, $"Failed : {Year} Year Inner-table {ReadMonthDataDic["Month"]} month Principal {ReadMonthDataDic["Principal"]} not displaying properly Error: "+e.Message);
                                _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
                                throw e;
                            }
                            try
                            { 
                                
                                DateOnly investmentDate=DateOnly.FromDateTime(DateTime.Now);
                                DateOnly MaturityDate;
                                DateOnly ProcessingDate;

                                if (InvestOrReInvest.ToLower().Contains("reinvest"))
                                {   
                                    string ReInvestyrs =(string)_scenarioContext["TrancheName"];
                                    string ParentTrancheYr = (string)_scenarioContext["ParentTrancheNumber"];
                                    // MaturityDate = Formule.CalculateMaturityDate(Int32.Parse(ReInvestyrs), 1);
                                    MaturityDate = Formule.CalculateMaturityDate(Int32.Parse(ReInvestyrs));
                                    ProcessingDate = Formule.CalculateProcessingDate(Array.IndexOf(Month, ReadMonthDataDic["Month"]), int.Parse(Year),true);
                                    investmentDate = Formule.CalculateReinvestmentDate(investmentDate, Int32.Parse(ParentTrancheYr));
                                }
                                else
                                {
                                    //MaturityDate = Formule.CalculateMaturityDate(1,0);
                                    MaturityDate = Formule.CalculateMaturityDate(1);
                                    ProcessingDate = Formule.CalculateProcessingDate(Array.IndexOf(Month, ReadMonthDataDic["Month"]), int.Parse(Year));
                                }
                                
                                       
                                Double NumberOfDayInYear = Formule.NumberOfDaysInYear(double.Parse(Year));


                                double NumberOfDayInMonthForInterest = Formule.CalculateInterestDays(investmentDate, MaturityDate, ProcessingDate);
                                double Earning = Formule.CompoundInterestByMonth(InitialBalance, AnnualInterestRate, NumberOfDayInMonthForInterest, NumberOfDayInYear);
                               
                                Assert.That(ReadMonthDataDic["Earning"].Contains(Earning.ToString()));


                                _scenario.Log(Status.Pass, $"{Year} Year Inner-table {ReadMonthDataDic["Month"]} month {ReadMonthDataDic["Earning"]} Earning displaying properly");



                                try
                               {
                                    double Payout;
                                    if (InvestOrReInvest.ToLower().Contains("reinvest"))
                                        Payout = 0.00;
                                    else
                                       Payout = Formule.CalculatePayoutAmount(Earning, monthlyIncome);
                                     Assert.That(ReadMonthDataDic["Payout"].Contains(Payout.ToString()));
                                    _scenario.Log(Status.Pass, $"{Year} Year Inner-table {ReadMonthDataDic["Month"]} month {ReadMonthDataDic["Payout"]} Payout displaying properly");
                                    
                                    try
                                    {
                                        double EndBalance = Math.Round(InitialBalance - Payout + Earning,2);
                                        Assert.That(ReadMonthDataDic["EndBalance"].Contains(EndBalance.ToString()));
                                        _scenario.Log(Status.Pass, $"{Year} Year Inner-table {ReadMonthDataDic["Month"]} month {ReadMonthDataDic["EndBalance"]} EndBalance displaying properly");
                                    }
                                    catch(Exception e)
                                    {
                                        _scenario.Log(Status.Fail, $"Failed: {Year} Year Inner-table {ReadMonthDataDic["Month"]} month {ReadMonthDataDic["EndBalance"]} EndBalance not displaying properly Error: "+e);
                                        _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
                                    }
                                    finally
                                    {
                                        InitialBalance = Math.Round(double.Parse(ReadMonthDataDic["EndBalance"]), 2);
                                        _featureContext["InitialBalance"] = InitialBalance;
                                    }
                                
                                }
                                catch (Exception e)
                                {
                                    _scenario.Log(Status.Fail, $"Failed: {Year} Year Inner-table {ReadMonthDataDic["Month"]} month {ReadMonthDataDic["Payout"]} Payout not displaying properly Error: "+e.Message);
                                    _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
                                    throw e;
                                }





                            }
                            catch (Exception e)
                            {
                                _scenario.Log(Status.Fail, $"Failed: {Year} Year Inner-table {ReadMonthDataDic["Month"]} month {ReadMonthDataDic["Earning"]} Earning not displaying properly Error: "+ e.Message);
                                
                                _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
                                throw e;
                            }

                            

                        }
                        catch(Exception e)
                        {
                            throw e;
                        }
                    }


                }
                

            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        [When(@"Enter re-investment value to tranche (.*), (.*), (.*)")]
        public void WhenEnterRe_InvestmentValueToTrancheTrancheNameRe_InvestmentValue(int ParentTrancheNumber,string TrancheName,int ReInvestmentValue)
        {
            OfferingPagePOM.ExpandReInvestSection(_driver, ParentTrancheNumber);
            OfferingPagePOM.EnterReInvestValue(_driver, ParentTrancheNumber, TrancheName, ReInvestmentValue);

        }

        [Then(@"Validate that the withdraw section show value properly (.*), (.*)")]
        public void ThenValidateThatTheWithdrawSectionShowValueProperlyRe_InvestmentValue(int ParentTrancheNumber,int ReInvestmentValue)
        { 
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            int Withdraw = 100 - ReInvestmentValue;
            try
            {

            Assert.That(OfferingPagePOM.CheckWithdrawAmount_ReinvestSection_Simulator(_driver, ParentTrancheNumber)== Withdraw);
            _scenario.Log(Status.Pass,"Withdraw amount displaying properly");
            _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
                _scenarioContext["ParentTrancheNumber"] = ParentTrancheNumber.ToString();
            }
            catch(Exception e)
            {
                _scenario.Log(Status.Fail, "Failed:Withdraw amount not displaying properly Error: "+ e.Message);
                _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
                throw e;
            }
        }
        [When(@"Click on Tranche in calculation table (.*)")]
        public void WhenClickOnTrancheInCalculationTableSLPTranche( string TrancheName)
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
               OfferingPagePOM.ClickOnTranche_CalculationTable_Simulator(_driver, TrancheName);
                _scenario.Log(Status.Pass, "Clicked on TrancheName in calculation table");
               _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
            
            _scenarioContext["TrancheName"] = TrancheName[TrancheName.Length - 1].ToString();
        }

        [Then(@"Validate that the Estimated monthly income calculated properly (.*), (.*), (.*), (.*), (.*)")]
        public void ThenValidateThatTheEstimatedMonthlyIncomeCalculatedProperly(int ParentTrancheNumber,double Principal,double InterestRate,double Bonus,double MonthlyIncome)
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            double MonthlyCompound = 100 - MonthlyIncome;
            try
            {

            double CalculatedEstimatedMonthlyIncome = Formule.CalculateEstimatedMonthlyIncome(Principal, InterestRate, Bonus, MonthlyCompound);
            double EstimatedMonthlyIncome= double.Parse(OfferingPagePOM.CheckEstimatedMonthlyIncome_Simulator(_driver, ParentTrancheNumber));
            double d = Math.Abs(EstimatedMonthlyIncome - CalculatedEstimatedMonthlyIncome);
             Assert.IsTrue(Math.Abs(EstimatedMonthlyIncome - CalculatedEstimatedMonthlyIncome) <0.011, "Estimated income calculation done Incorrectly");
            //Assert.AreEqual(EstimatedMonthlyIncome,CalculatedEstimatedMonthlyIncome, "Estimated income calculation done Incorrectly");
                _scenario.Log(Status.Pass,"Estimated monthly income calculated properly");
                _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
            }
            catch (Exception e)
            {
                _scenario.Log(Status.Fail, "Estimated monthly income did not calculated properly Error: " + e);
                _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
                throw e;
            }
        }

        [When(@"Click on the SAVE & INVEST NOW Button")]
        public void WhenClickOnButton()
        {
           
            OfferingPagePOM.ClickOnSaveAndInvestButton(_driver,2);
           
            Thread.Sleep(3000);
        }

        [Then(@"Validate that SAVE & INVEST NOW button navigate to investment process")]
        public void ThenValidateThatSAVEINVESTNOWButtonNavigateToInvestmentProcess()
        {
            _scenario = (ExtentTest)_scenarioContext["scenario"];
            try
            {
                 Assert.That(AddInvestmentPOM.ClickOnInvestmentStepTitle(_driver,"Investment Details").Displayed);
                _scenario.Log(Status.Pass, "The Save & Invest now button navigated to investment process");
                _scenario.Log(Status.Pass, addScreenshot(_driver, Filename));
                

            }
            catch (Exception e)
            {
                _scenario.Log(Status.Fail, "The Save & Invest now button did not navigated to investment process Error: "+e.Message);
                _scenario.Log(Status.Fail, addScreenshot(_driver, Filename));
                throw e;
            }

        }



    }
}
