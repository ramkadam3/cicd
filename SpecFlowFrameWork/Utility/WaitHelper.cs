using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;


namespace SpecFlowFrameWork.Utility
{
    public static class WaitHelper
    {
        public static void cExplicitWait(IWebDriver driver, By eleIdentifier, int timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.IgnoreExceptionTypes(typeof(Exception));
                wait.Until(ExpectedConditions.ElementToBeClickable(eleIdentifier));

            }
            catch (Exception e)
            {
                Console.WriteLine("Report-wait timeout!! Couldn't find element-" + e.Message);

                throw new Exception(e.Message);
            }

        }
        public static void cAlertIsPresent(IWebDriver driver, int timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.AlertIsPresent());

            }
            catch (Exception e)
            {
                Console.WriteLine("Report-wait timeout!! Couldn't find element-" + e.Message);

                throw new Exception(e.Message);
            }

        }
        public static void cElementExists(IWebDriver driver, By eleIdentifier, int timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.IgnoreExceptionTypes(typeof(Exception));
                wait.Until(ExpectedConditions.ElementExists(eleIdentifier));

            }
            catch (Exception e)
            {
                Console.WriteLine("Report-wait timeout!! Couldn't find element-" + e.Message);

                throw new Exception(e.Message);
            }

        }
        public static void cExplicitWaitForElementIsVisible(IWebDriver driver, By eleIdentifier, int timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(eleIdentifier));


            }
            catch (Exception e)
            {
                Console.WriteLine("Report-wait timeout!! Couldn't find element-" + e.Message);

                throw new Exception(e.Message);
            }

        }



        public static IWebElement cFindElement(IWebDriver driver, By eleIdentifier, int timeOutInSeconds)
        {
            try
            {
                cExplicitWait(driver, eleIdentifier, timeOutInSeconds);
                IWebElement locatedElement = driver.FindElement(eleIdentifier);
                return locatedElement;
            }
            catch (Exception e)
            {
                Console.WriteLine("Report-wait timeout!! Couldn't find element-" + e.Message);
                throw new Exception(e.Message);
            }

        }

        public static void cExplicitlyWaitForAbsence(IWebDriver driver, By eleIdentifier, int timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(eleIdentifier));
            }
            catch (Exception e)
            {
                Console.WriteLine("Report-wait timeout!! Element still exists in the page- " + e.Message);
                throw new Exception(e.Message);
            }
        }
        public static void cExplicitlyWaitForElementToBeClickable(IWebDriver driver, By eleIdentifier, int timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.Until(ExpectedConditions.ElementToBeClickable(eleIdentifier));
            }
            catch (Exception e)
            {
                Console.WriteLine("Report-wait timeout!! Element still exists in the page- " + e.Message);
                throw new Exception(e.Message);
            }
        }

        public static void cWaitForLoader(IWebDriver driver, int timeOutInSeconds)
        {
            try
            {
                cExplicitlyWaitForAbsence(driver, By.XPath("//div[@class='loader']"), timeOutInSeconds);

            }
            catch (Exception e)
            {
                cFindElement(driver, By.XPath("//div[@class='loader']"), 10);
            }
        }
        public static void cWaitForSpinner(IWebDriver driver, int timeOutInSeconds)
        {
            try
            {
                cExplicitlyWaitForAbsence(driver, By.XPath("//i[contains(@class,'spinner')]"), timeOutInSeconds);

            }
            catch (Exception e)
            {
                cFindElement(driver, By.XPath("//i[contains(@class,'spinner')]"), 10);
            }
        }

        public static void cScrollIntoViewUsingJavaScriptExecutor(IWebDriver driver, By eleIdentifier)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement elementToFind = cFindElement(driver, eleIdentifier, 20);
            js.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", elementToFind);
            cExplicitWait(driver, eleIdentifier, 20);
        }

    }
}
