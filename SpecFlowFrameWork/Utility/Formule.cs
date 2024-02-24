using AventStack.ExtentReports;
using FluentAssertions.Equivalency;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace Yrefy_AutomationProject.Utility
{
    public class Formule
    {
        public static double NumberOfDaysInYear(double year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return 366;
            }
            else
            {
                return 365;
            }
            
        }
        
        public static double CalculateInterestDays(DateOnly investmentDate, DateOnly maturityDate, DateOnly processingDate)
        {
            int NoOfDays;
            try
            {
                if (processingDate.Year == investmentDate.Year && processingDate.Month == investmentDate.Month)
                    NoOfDays = DateTime.DaysInMonth(investmentDate.Year, investmentDate.Month) - investmentDate.Day + 1;
                else if (processingDate.Year == maturityDate.Year && processingDate.Month == maturityDate.Month)
                    NoOfDays = maturityDate.Day;
                
                else
                    NoOfDays = DateTime.DaysInMonth(processingDate.Year, processingDate.Month);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NoOfDays;
        }
        public static double CompoundInterestByMonth(double Principal,double annualInterestRate,double NumberOfdaysInMonth,double NumberOfDaysInYear)
        {
           double MonthlyInterest;
            try
            {
                MonthlyInterest = Math.Round((Principal * Math.Pow(1 + (annualInterestRate / (NumberOfDaysInYear * 100)), NumberOfdaysInMonth)-Principal),2);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Math.Round(MonthlyInterest,2);
        }
        public static DateOnly CalculateMaturityDate(int TrancheYear)
        {
            DateOnly MaturityDate = DateOnly.FromDateTime(DateTime.Now.AddYears(TrancheYear));
            return MaturityDate;
        }
        public static DateOnly CalculateReinvestmentDate(DateOnly investmentdate,int TranchNumber)
        {
            DateOnly ReinvestmentDate =investmentdate.AddYears(TranchNumber).AddDays(1);
            return ReinvestmentDate;
        }
        public static DateOnly CalculateProcessingDate(int monthsToAdd,int year,bool? Reinvest=false)
        {
            DateTime originalDate;
            if (Reinvest==true)
            {
              originalDate = DateTime.Now.AddDays(1);
            }else
            {
              originalDate = DateTime.Now;
            }
            DateTime NewDate = new DateTime(year, monthsToAdd, originalDate.Day);


            DateOnly DateOnly = DateOnly.FromDateTime(NewDate);
            return DateOnly;
      
        }
        public static double CalculatePayoutAmount(double Earning, double PercentPayout)
        {
            double Payout = Math.Round((Earning * PercentPayout / 100), 2);
            return Payout;
        }
        public static double CalculateEstimatedMonthlyIncome(double Principal,double InterestRate,double Bonus,double MonthlyCompound)
        {            
            double EstimatedMonthlyIncome = Math.Round((Principal * ((InterestRate+ Bonus)/100)*(double)Math.Round(30.00M / 365.0M, 5) * (MonthlyCompound/100)),2);
            return EstimatedMonthlyIncome;
        }
         public static double CalculatPaymentAmount(int loanTerm,double loanAmount)
         {
            double yrefyApr = 5.19 / (1 + Math.Exp(-(0.043) * ((double)loanTerm - 100)));
            yrefyApr = Math.Round(yrefyApr, 2);
            double PaybackAmount = loanAmount * (1 + (double)((double)(yrefyApr / 100) * (double)(loanTerm / 12)));
            return Math.Round(PaybackAmount / loanTerm,2);
         }
    public static (double,double, double, double) CalculateAverageAndTotalIncome(string IncomeFrequency,double SelectedIncomeAmount,int NumberOfSelectedIncomes)
    {

      double totalIncome =0;
      IncomeFrequency = IncomeFrequency.Replace("-", "");
if (IncomeFrequency == "Yearly")
        totalIncome = SelectedIncomeAmount;
      else if (IncomeFrequency == "Monthly")
        totalIncome = (SelectedIncomeAmount * 12);
      else if (IncomeFrequency == "SemiMonthly")
        totalIncome = (SelectedIncomeAmount * 24);
      else if (IncomeFrequency == "Weekly")
        totalIncome = (SelectedIncomeAmount * 52);
      else if (IncomeFrequency == "BiWeekly")
        totalIncome = (SelectedIncomeAmount * 26);
      else if (IncomeFrequency == "Quarterly")
        totalIncome = (SelectedIncomeAmount * 4);

      // 1.Average 
      double PA = Math.Round( totalIncome / NumberOfSelectedIncomes,2);
      double PM =Math.Round( PA / 12,2);

      // 2.Total 
      double TotalPA = Math.Round( totalIncome,2);
      double TotalPM =Math.Round( totalIncome / 12,2);

      return (PA,PM, TotalPA, TotalPM);

    }
    public static string CalculateDTIRatio(double totalDebts,double totalAnnualIncome)
    {
      double DTIRatio= Math.Round((totalDebts / totalAnnualIncome) * 100, 2);
      return DTIRatio.ToString();
    }


    




    }
}
