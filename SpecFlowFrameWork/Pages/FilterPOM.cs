using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace SpecFlowFrameWork.Pages
{
    public class FilterPOM
    {
        public static void ClickOnApplyButton(IWebDriver driver)
        {
            string Xpath = $"//descendant::button/span[contains(text(),'APPLY') or contains(text(),'Apply')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath(Xpath))).Click().Build().Perform();
        }
        public static void ClickClearbutton_Filter(IWebDriver driver)
        {
            string Xpath = $"//descendant::button/span[contains(text(),'CLEAR') or contains(text(),'Clear')]";
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));

            driver.FindElement(By.XPath(Xpath)).Click();
        }

    }
}
