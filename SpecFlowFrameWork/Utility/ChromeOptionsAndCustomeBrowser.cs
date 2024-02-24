using SpecFlowFrameWork.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Xml.Linq;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowFrameWork.Utility
{

    public static class ChromeOptionsAndCustomeBrowser
    {

        public static Boolean CheckDownoloadFile(IWebDriver driver, string fileName)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles.Last());

            }
            catch { }
            string DownloadLink = "File:///C:/Users/User/Downloads";
            //string DownloadLink = "File:///C:/Users/prata/Downloads";
            
            driver.Navigate().GoToUrl(DownloadLink);
            

            Thread.Sleep(3000);
            bool value = IsFileDownloaded(fileName);
            Assert.IsTrue(value, "The file was not downloaded");
            if (value)
            {
                DeleteDownloadedFile(fileName);
                //Assert.Pass("Downloaded file has been checked and deleted successfully.");
            }
            else
            {
                Assert.Fail("The file was not downloaded or could not be found.");
            }
            driver.Close();
            int a = driver.WindowHandles.Count();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            return value;
        }
        private static bool IsFileDownloaded(string fileName)
        {
            string filePath = @"C:\Users\User\Downloads\" + fileName + "";
           // string downloadPath = @"C:\Users\prata\Downloads";
           // string filePath = Path.Combine(downloadPath, fileName);
            Boolean value= File.Exists(filePath);
            return value;
        }

        private static void DeleteDownloadedFile(string fileName)
        {
            //string downloadPath = @"C:\Users\prata\Downloads";
           string downloadPath = @"C:\Users\User\Downloads";
           string filePath = Path.Combine(downloadPath, fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"File {fileName} has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"File {fileName} does not exist in the download directory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the file: {ex.Message}");
            }
        }

    }
}

