using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SpecFlowFrameWork.Utility
{
    public class ExtentReport:BaseClass
    {
        //public static DateTime Time = DateTime.Now;
        //public static String Filename = "Screenshot_" + Time.ToString("h_mm_ss") + ".png";
        public static ExtentReports _extentReports;

        [ThreadStatic]
         public static ExtentTest _feature;
        [ThreadStatic]
       public static ExtentTest _scenario;
    

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
        public static String screenshotsPath = dir.Replace("bin\\Debug\\net6.0", "Screenshots");

        public static void ExtentReportInit()
        {
            if (Directory.Exists(screenshotsPath))
            {
                Directory.Delete(screenshotsPath, true);
            }

            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;

            Directory.CreateDirectory(screenshotsPath);
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
           
            htmlReporter.Config.ReportName = "ExtentReport";
            htmlReporter.Config.DocumentTitle = "ExtentReport";
            htmlReporter.Config.CSS="css-string";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

           _extentReports = new ExtentReports();

            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Yrefy");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
            _extentReports.AttachReporter(htmlReporter);

           
          
            



        }

        public static void ExtentReportTearDown()
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string reportName = "ExtentReport_" + timestamp;
           // Instance.Flush();
            _extentReports.Flush();
            // Rename the report file
            string defaultReportFile = Path.Combine(testResultPath, "index.html");
           string renamedReportFile = Path.Combine(testResultPath, reportName + ".html");
           
            File.Move(defaultReportFile, renamedReportFile);
        }
        
        public MediaEntityModelProvider addScreenshot(IWebDriver driver, string screenshotName)
        {




            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            var screenshot = takesScreenshot.GetScreenshot().AsBase64EncodedString;




            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }
    }
}
