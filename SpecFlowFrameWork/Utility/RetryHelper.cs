using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Yrefy_AutomationProject.Utility
{
  public static class RetryHelper
  {

    public static void RetryAction(Action<ScenarioContext> action, int maxRetries)
    {
      int retries = maxRetries;

      while (retries > 0)
      {
        try
        {
          action.Invoke(ScenarioContext.Current);
          // If the action succeeds, break out of the loop
          break;
        }
        catch (Exception ex)
        {
          //ScenarioContext.Current.ScenarioInfo($"Action failed. Retrying... {retries} attempts remaining.");
          retries--;

          // Optionally, you might want to log the exception for debugging purposes
         // ScenarioContext.Current.Scenario.Log($"Exception: {ex.Message}");
        }
      }

      // If all retries are exhausted and the action still fails, throw an exception
      if (retries == 0)
      {
        Assert.Fail("Action failed even after retrying.");
      }
    }


  }
}
