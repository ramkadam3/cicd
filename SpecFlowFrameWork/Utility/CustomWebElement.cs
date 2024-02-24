using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Yrefy_AutomationProject.Utility
{
  public class CustomWebElement : IWebElement
  {
    private readonly IWebElement _element;

    

    public CustomWebElement(IWebElement element)
    {
      _element = element;
    }

    public string TagName => throw new NotImplementedException();

    public string Text => throw new NotImplementedException();

    public bool Enabled => throw new NotImplementedException();

    public bool Selected => throw new NotImplementedException();

    public Point Location => throw new NotImplementedException();

    public Size Size => throw new NotImplementedException();

    public bool Displayed => throw new NotImplementedException();

    // Override the Clear method
    public void Clear()
    {
      try
      {

        _element.Click();
      }
      catch { }
      for (int i = 0; i <= 50; i++)
      {
        _element.SendKeys(Keys.Backspace);
      }
      for (int i = 0; i <= 50; i++)
      {
        _element.SendKeys(Keys.Delete);
      }
    }

    public void Click()
    {
      throw new NotImplementedException();
    }

    public IWebElement FindElement(By by)
    {
      throw new NotImplementedException();
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
      throw new NotImplementedException();
    }

    public string GetAttribute(string attributeName)
    {
      throw new NotImplementedException();
    }

    public string GetCssValue(string propertyName)
    {
      throw new NotImplementedException();
    }

    public string GetDomAttribute(string attributeName)
    {
      throw new NotImplementedException();
    }

    public string GetDomProperty(string propertyName)
    {
      throw new NotImplementedException();
    }

    public ISearchContext GetShadowRoot()
    {
      throw new NotImplementedException();
    }

    public void SendKeys(string text)
    {
      throw new NotImplementedException();
    }

    public void Submit()
    {
      throw new NotImplementedException();
    }
  }
}
