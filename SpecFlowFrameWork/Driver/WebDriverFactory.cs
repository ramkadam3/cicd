using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yrefy_AutomationProject.Driver
{
  public static class WebDriverFactory
  {
    [ThreadStatic]
    private static IWebDriver driver;

    public static IWebDriver GetDriver()
    {
      if (driver == null)
      {
        // Initialize a new WebDriver instance (e.g., ChromeDriver)
        driver = new ChromeDriver();
      }
      return driver;
    }
  }
}
