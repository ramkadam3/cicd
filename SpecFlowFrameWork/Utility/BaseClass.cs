using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowFrameWork.Pages;
using System.IO;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using System.Diagnostics;
using SpecFlowFrameWork.Driver;
using Bogus;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using Yrefy_AutomationProject.Utility.CostumException;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace SpecFlowFrameWork.Utility
{
    public class BaseClass
    {
        public static JSonReader GetDataParser()
        {
            return new JSonReader();
        }
        private string path = GetDataParser().TestData_Path("LoginCredentialsTD");

        public static DateTime Time = DateTime.Now;
        public static String Filename = "Screenshot_" + Time.ToString("h_mm_ss") + ".png";

        public static string LoginCredintial_Path = GetDataParser().TestData_Path("LoginCredentialsTD");
        public static string Test_Url = GetDataParser().TestData("Test_Url", LoginCredintial_Path);
        public static string WorkingDirectory = Environment.CurrentDirectory;
        public static string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;





    //***********************************This variable use as reusable data*******************************************//
        Faker faker = new Faker();
        Random random = new Random();
       // string Name = faker.Person.FirstName;


        public static DateOnly Date = DateOnly.FromDateTime(Time);
        public static string Password = "Yrefy@123";
        public static string Zipcode = "85224";
        public static string State = "Alabama";
        public static string City = "Abanda";
        public static string State2 = "Alaska";
        public static string City2 = "Adak";
        public static string SSN = "987654321";
        public static string Phone = "9876543201";
        public static string Fax = "9865432587";
        public static string URL = "https://testsocialurl.com";




    public static IWebElement Success_Notification(IWebDriver Driver)
        {
            
            string Xpath = "//dynamic-view/div";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IWebElement Mes = Driver.FindElement(By.XPath(Xpath));
            
            return Mes;
        }
        public static void InvisibleSuccess_Notification(IWebDriver Driver)
        {
            //string Xpath = "//p[@class='notifier__notification-message ng-star-inserted']";
            string Xpath = " //dynamic-view/div";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));
        }
       

        public static long WaitForSpinnerToDisappear(IWebDriver driver)
        {
            string Xpath = "//mat-spinner|//mat-progress-spinner";
            Stopwatch stopwatch = new Stopwatch();
            WebDriverWait WaitShort = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            WebDriverWait WaitLong = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            try
            {
                stopwatch.Start();
                WaitShort.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
                WaitLong.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));

                stopwatch.Stop();
                var timeSpan = stopwatch.ElapsedMilliseconds;
                Console.WriteLine($"SpinnerTime {timeSpan}");

            }
            catch
            {

            }
                Thread.Sleep(2000);
                return stopwatch.ElapsedMilliseconds; 
        }
        public IWebDriver BrowserLaunch(IWebDriver driver,  string Test_Url,string? BrowserName="chrome")
        {
           
        dynamic capability = GetBrowserOption(BrowserName);
      //chromeOptions.AddArgument("--headless");
      
      //driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions.ToCapabilities());
            if (BrowserName.ToLower().Contains("chrome"))
             driver = new ChromeDriver(capability);
            if (BrowserName.ToLower().Contains("firefox"))
            driver = new FirefoxDriver(capability);
            if (BrowserName.ToLower().Contains("edge"))
             driver = new EdgeDriver(capability);
            if (BrowserName.ToLower().Contains("safari"))
             driver = new SafariDriver(capability);

             driver.Manage().Window.Maximize();
             driver.Navigate().GoToUrl(Test_Url);
           
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
    public MediaEntityModelProvider addScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            var screenshot = takesScreenshot.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }

        public static void Scroll(IWebDriver driver,string direction,int distance)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Scroll down vertically to 500 pixels
            // js.ExecuteScript("window.scrollBy(0, 500);");

            // Scroll right horizontally by 300 pixels
            if(direction.ToLower().Contains("up")|| direction.ToLower().Contains("down"))
                js.ExecuteScript($"window.scrollBy(0, {distance});");
            if (direction.ToLower().Contains("right")|| direction.ToLower().Contains("left"))
                js.ExecuteScript($"window.scrollTo({distance}, 0);");          
        }


    //*************************************************************Reusable Methods*****************************************************************************
    public static IWebElement EnterInputValue(IWebDriver driver, string ElementName,int? elementIndex=1)
    {
      string Xpath = $"(//mat-label[normalize-space()='{ElementName}']/preceding::input[1])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      return visibleElements[(int)elementIndex-1];
    }
    public static void WaitForPageToLoad(IWebDriver driver)
    {      
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
      //Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[contains(@class,'label-data')]")));
      Thread.Sleep(6000);
      
    }
    public static void WaitForToLoadAllData(IWebDriver driver)
    {///this method should be used on any details page

      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

      //Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[contains(@class,'label-data')]")));


      int visiblePercentage;

      Wait.Until((driver) =>
      {
        IReadOnlyCollection<IWebElement> allElements = driver.FindElements(By.XPath("//*[not(*)]"));//*[not(*)]
        int totalElements = allElements.Count;
        int visibleElements = 0;

        foreach (IWebElement element in allElements)
        {
          if (element.Displayed)
          {
            visibleElements++;
          }
        }

         visiblePercentage = (visibleElements * 100) / totalElements;
        return visiblePercentage >= 40;
      });

    }
    public static void EnterInputValueToMultipleField_AddApplicationDetails(IWebDriver driver, string ElementName, string InputValue)
    {//ElementName=First Name|Email|Alt. Email|Phone cell|Phone Home|Phone Other|Middle Name|Last Name|Previous Name|Maiden Name|SSN|Date Of Birth|License Number
      string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::input[1])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));


      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));


      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      int i = 0;
      foreach (IWebElement element in visibleElements)
      {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
        if (element.Enabled)
        {
          element.Clear();
          if (ElementName.ToLower().Contains("email"))
            element.SendKeys($"{InputValue}");
          else
            element.SendKeys($"{InputValue} {i}");
        }
        i++;
      }

    }
    public static string SelectOption_DropDown(IWebDriver driver, string ElementName, int ?selectByIndex=0,int? elementIndex=1)
    {
      string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::mat-select[1])[{elementIndex}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement element = elements.FirstOrDefault(element => element.Displayed);
      element.Click();
      Thread.Sleep(3000);
      IList<IWebElement> OptionList = new List<IWebElement>();
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-option[@tabindex='0']")));
      OptionList = driver.FindElements(By.XPath("//mat-option"));
      Thread.Sleep(3000);
      OptionList[(int)selectByIndex].Click();
      Thread.Sleep(2000);
      string q = element.Text;
      return element.Text;
    }
    public static string SelectOption_InputTypeDropDown(IWebDriver driver, string ElementName, int? selectByIndex = 0, int? elementIndex = 1)
    {
      string Xpath = $"(//mat-label[normalize-space()='{ElementName}']/preceding::input[1])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement element = elements.FirstOrDefault(element => element.Displayed);
      element.Click();
      Thread.Sleep(2000);
      IList<IWebElement> OptionList = new List<IWebElement>();
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//mat-option[@tabindex='0']")));
      OptionList = driver.FindElements(By.XPath("//mat-option"));
      Thread.Sleep(2000);
      OptionList[(int)selectByIndex].Click();
      Thread.Sleep(2000);
      string q = element.GetAttribute("value");
      return q;
    }
    public static string SelectOption_DropDown_Randomly(IWebDriver driver, string ElementName, int? elementIndex = 1)
    {
      Random random = new Random();
      int selectByIndex;
      string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::mat-select[1])[{elementIndex}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      
      IWebElement element = elements.FirstOrDefault(element => element.Displayed);
      Thread.Sleep(500);
      element.Click();
      Thread.Sleep(2000);
      IList<IWebElement> OptionList = new List<IWebElement>();
      OptionList = driver.FindElements(By.XPath("//mat-option"));
      Thread.Sleep(2000);
      selectByIndex = random.Next(1, OptionList.Count);
      OptionList[selectByIndex].Click();
      Thread.Sleep(2000);
      string q = element.Text;
      return element.Text;
    }
    public static IWebElement SelectValue_Sendkey(IWebDriver driver, string ElementName)
    {
      string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::mat-select[1])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath));
    }
    public static IWebElement SelectValueOfVisible_Sendkey(IWebDriver driver, string ElementName,int? elementNumber=1)
    {
      string Xpath = $"(//mat-label[contains(text(),'{ElementName}')]/preceding::mat-select[1])";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
     IList< IWebElement> element = elements.Where(element => element.Displayed).ToList();
      return element[(int)elementNumber-1];
    }
    public static string CheckAddeddetails_byRowColumnArranged(IWebDriver driver, string elementName, int RowNumber)
    {//Loan Type|Total Loan Amount|Status
      string Xpath = $"(//tr/descendant::td[contains(@data-label,'{elementName}')])[{RowNumber}]";
     
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));


      IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed&&element.Enabled);
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return visibleElement.Text.Trim(' ').Trim('$').Replace(",", "");
    }
    public static string CheckAddeddetailsWithTableName_byRowColumnArranged(IWebDriver driver,string tableName, string columnName, int rowNumber)
    {
      string Xpath = $"//b[normalize-space()='{tableName}']/following::tbody/descendant::tr[{rowNumber}]/descendant::td[@data-label='{columnName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed && element.Enabled);
      return visibleElement.Text.Trim(' ').Trim('$').Replace(",", "");
    }
    public static IDictionary GetAddedData_BorrowerDetails_AddApplicationDetails_withExpansionCard(IWebDriver driver, string cardName, string[] ElementRequired)
    {//Education Details|Employment Details|Reference Details|Mailing Address|Other|Physical Address etc
      string Xpath;

      Xpath = $"//*[normalize-space()='{cardName}']/ancestor::mat-expansion-panel[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

      foreach (IWebElement element in visibleElements)
      {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
        for (int i = 0; i < ElementRequired.Length; i++)
        {

          string XpathKey = $"{Xpath}/descendant::div[normalize-space()='{ElementRequired[i]}']/following-sibling::div[contains(@class,'label-data')]";
          string Key = ElementRequired[i];
          Thread.Sleep(500);
          string KeyValue = driver.FindElement(By.XPath(XpathKey)).Text;
          //string KeyValue = element.FindElement(By.XPath(XpathKey)).Text;
          DataDic.Add(Key, KeyValue);
        }

      }

      return (IDictionary)DataDic;
    }
    public static IWebElement ClickOnActionButton_byRowColumnArranged(IWebDriver driver, string buttonName, int RowNumber)
    {//Loan Type|Total Loan Amount|Status
      string Xpath = $"(//tr/descendant::td/descendant::button[@title='{buttonName}'])[{RowNumber}]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static void ClearAllInput(IWebDriver driver)
    {
      string Xpath = $"//input";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      

      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

      foreach (IWebElement element in visibleElements)
      {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        if (element.Displayed && element.Enabled)
        {
          executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
          try
          {
            element.Click();
            
          for (int i = 0; i <= 50; i++)
          {
            element.SendKeys(Keys.Backspace);
          }
          for (int i = 0; i <= 50; i++)
          {
            element.SendKeys(Keys.Delete);
          }
          }
          catch { }
        }
      }

    }
    public static void ExpandDetailsInnerCard_ExpansionType(IWebDriver driver, string cardName)
    {//CardName=Employee Details|Contact Details|Address Details
      string Xpath = $"//*[normalize-space()='{cardName}']/ancestor::mat-expansion-panel-header[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed);

      if (visibleElement != null)
      {
        string Degree = visibleElement.GetAttribute("aria-expanded");        
        if (Degree.Contains("false"))
          visibleElement.Click();
      }
      else
      {
        Console.WriteLine("No visible element found.");
      }

    }
    public static void CloseDetailsInnerCard_ExpansionType(IWebDriver driver, string cardName)
    {//CardName=Employee Details|Contact Details|Address Details
      string Xpath = $"//*[normalize-space()='{cardName}']/ancestor::mat-expansion-panel-header[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed);

      if (visibleElement != null)
      {
        string Degree = visibleElement.GetAttribute("aria-expanded");
        if (Degree.Contains("true"))
          visibleElement.Click();
      }
      else
      {
        Console.WriteLine("No visible element found.");
      }

    }
    public static void ExpandDetailsInnerCard_AddApplicationDetails(IWebDriver driver, string cardName)
    {//CardName=Employee Details|Contact Details|Address Details
      string Xpath = $"//b[normalize-space()='{cardName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", driver.FindElement(By.XPath(Xpath)));
      //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));
      IWebElement visibleElement = elements.FirstOrDefault(element => element.Displayed);

      if (visibleElement != null)
      {
        string Degree = visibleElement.GetAttribute("style");

        if (!Degree.Contains("180"))
          visibleElement.Click();
      }
      else
      {
        Console.WriteLine("No visible element found.");
      }

    }
    public static string SelectOption_ByCheck(IWebDriver driver,string selectName, int? index = 1)
    {
      string Xpath = $"//mat-select[@formcontrolname='{selectName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      try
      {
        driver.FindElement(By.XPath(Xpath)).Click();
        Thread.Sleep(2000);
        for (int i = 1; i <= index; i++)
        {          
          driver.FindElement(By.XPath($"{Xpath}/following::mat-option[{i}]")).Click();
        }
        
      }
      catch
      {
        try
        {
          throw new CustomException("Co-Applicant is not added here");
        }
        catch (CustomException e)
        {
          throw e;
        }
        catch
        {

        }
      }
      return driver.FindElement(By.XPath($"{Xpath}/descendant::span/span")).Text;


    }
    public static IWebElement ClickOnSelectField(IWebDriver driver, string selectName)
    {
      string Xpath = $"//mat-select[@formcontrolname='{selectName}']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
      return driver.FindElement(By.XPath(Xpath));
    }
    public static IDictionary GetAddedData_AddedDetails(IWebDriver driver, string cardName, string[] ElementRequired)
    {//Education Details|Employment Details|Reference Details|Mailing Address|Other|Physical Address etc
      string Xpath;

      Xpath = $"//*[normalize-space()='{cardName}']/ancestor::mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      //IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();
      IWebElement element = elements.FirstOrDefault(element => element.Displayed);
      //foreach (IWebElement element in visibleElements)
      {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
        for (int i = 0; i < ElementRequired.Length; i++)
        {

          string XpathKey = $"{Xpath}/descendant::div[normalize-space()='{ElementRequired[i]}']/following::div[contains(@class,'label-data')][1]";
          string Key = ElementRequired[i];
          Thread.Sleep(500);
          string KeyValue = driver.FindElement(By.XPath(XpathKey)).Text;
          //string KeyValue = element.FindElement(By.XPath(XpathKey)).Text;
          DataDic.Add(Key, KeyValue);
        }

      }

      return (IDictionary)DataDic;
    }
    public static IDictionary GetAddedData_BorrowerDetails_withSubCardName(IWebDriver driver, string cardName, string[] ElementRequired)
    {//Education Details|Employment Details|Reference Details|Mailing Address|Other|Physical Address etc
      string Xpath;

      Xpath = $"(//*[contains(text(),'{cardName}')])[last()]/ancestor::mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      if (elements.Count > 0)
      {
        Actions actions = new Actions(driver);
        actions.MoveToElement(elements[0]);
        actions.Perform();
      }

      IWebElement visibleElements = elements.FirstOrDefault(element => element.Displayed);

      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
      executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", visibleElements);
      for (int i = 0; i < ElementRequired.Length; i++)
      {
        string XpathKey;
        string Key = ElementRequired[i];
        if(Key=="Account Number")
          XpathKey = $"{Xpath}/descendant::*[normalize-space()='{ElementRequired[i]}'][1]/following-sibling::*[contains(@class,'label-data')][1]";
        else
         XpathKey = $"{Xpath}/descendant::*[contains(text(),'{ElementRequired[i]}')][1]/following-sibling::*[contains(@class,'label-data')]";
        Thread.Sleep(500);
        string KeyValue = driver.FindElement(By.XPath(XpathKey)).Text;
        //string KeyValue = element.FindElement(By.XPath(XpathKey)).Text;
        DataDic.Add(Key, KeyValue);
      }

      return (IDictionary)DataDic;
    }
    public static IDictionary GetAddedData_BorrowerDetails_AddApplicationDetails(IWebDriver driver, string cardName, string[] ElementRequired)
    {//Education Details|Employment Details|Reference Details|Mailing Address|Other|Physical Address etc
      string Xpath;

      Xpath = $"//*[normalize-space()='{cardName}']/ancestor::mat-card[1]";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

      IList<IWebElement> elements = driver.FindElements(By.XPath(Xpath));

      IDictionary<string, string> DataDic = new Dictionary<string, string>();

      
      IList<IWebElement> visibleElements = elements.Where(element => element.Displayed).ToList();

      foreach (IWebElement element in visibleElements)
      {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
        for (int i = 0; i < ElementRequired.Length; i++)
        {

          string XpathKey = $"{Xpath}/descendant::div[normalize-space()='{ElementRequired[i]}'][1]/following-sibling::div[contains(@class,'label-data')]";
          string Key = ElementRequired[i];
          Thread.Sleep(500);
          string KeyValue = driver.FindElement(By.XPath(XpathKey)).Text;
          //string KeyValue = element.FindElement(By.XPath(XpathKey)).Text;
          DataDic.Add(Key, KeyValue);
        }

      }

      return (IDictionary)DataDic;
    }
    public static void NavigateToBackPage(IWebDriver driver)
    {
      string Xpath = "//mat-icon[normalize-space()='chevron_left']";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      driver.FindElement(By.XPath(Xpath)).Click();
      BaseClass.WaitForSpinnerToDisappear(driver);
    }
    public static Boolean CheckThatCheckBoxStatus(IWebDriver driver, string ElementName)
    {//ElementName=Is US Citizen|Is Permanent Residence|Still Working
      string Xpath = $"//span[contains(text(),'{ElementName}')]/preceding::label[1]/child::span[1]/child::input";
      WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

      return driver.FindElement(By.XPath(Xpath)).GetAttribute("aria-checked").Contains("true");
    }
  }
}
