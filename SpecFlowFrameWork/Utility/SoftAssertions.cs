using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yrefy_AutomationProject.Utility
{
    public class SoftAssertions
    {

    private List<string> errors = new List<string>();

    public void AddAssertion(bool condition, string message)
    {
      if (!condition)
      {
        errors.Add(message);
      }
    }

    public void AssertAll()
    {
      if (errors.Count > 0)
      {
        string errorMessage = "Soft assertions failed:\n" + string.Join("\n", errors);
        NUnit.Framework.Assert.Fail(errorMessage);
      }
    }



  }
}
