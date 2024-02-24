using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowFrameWork.Driver
{
    public class WebDriverHelper
    {
    [ThreadStatic]
        private IWebDriver driver;       

        //private ScenarioContext _scenarioContext;
        public WebDriverHelper(IWebDriver _driver,ScenarioContext scenarioContext)
        {   this.driver = _driver;
            //this._scenarioContext = scenarioContext;
        }
        public IWebDriver SetUp(string BrowserName, string Test_Url)
        {
            dynamic capability = GetBrowserOption(BrowserName);            
            driver = new ChromeDriver(capability);
            //_scenarioContext.Set(driver, "WebDriver");
            driver.Navigate().GoToUrl(Test_Url);
            driver.Manage().Window.Maximize();
            return driver;
        }


        private dynamic GetBrowserOption(string BrowserName)
        {
            if (BrowserName.ToLower().Contains("firefox"))
                return new FirefoxOptions();
            if (BrowserName.ToLower().Contains("edge"))
                return new EdgeOptions();
            if (BrowserName.ToLower().Contains("safari"))
                return new SafariOptions();
            else
            {
                return new ChromeOptions();
            }
        }


    

    public  IWebDriver GetDriver()
    {
      if (driver == null)
      {        
        driver = new ChromeDriver();
      }
      return driver;
    }


  }
}
