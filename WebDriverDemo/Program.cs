using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://duckduckgo.com/";
            _driver.Manage().Window.Maximize();
            Console.WriteLine("Go to " + _driver.Url.ToString());

            Console.WriteLine("Search C#");
            _driver.FindElement(By.Id("search_form_input_homepage")).SendKeys("c#");

            Console.WriteLine("click button search");
            _driver.FindElement(By.Id("search_button_homepage")).Click();

            Console.WriteLine("find first link");
            _driver.FindElement(By.LinkText("https://docs.microsoft.com/en-us/dotnet/csharp/")).Click();

            bool itIsUrl = _driver.Url.Contains("csharp");
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

            if (itIsUrl)
            {
                screenshot.SaveAsFile("C:\\PitDevelop\\C#\\WebDriver1\\Screenshot\\SearchCompleted.jpg");
            }
            else
            {
                screenshot.SaveAsFile("C:\\PitDevelop\\C#\\WebDriver1\\Screenshot\\SearchFAIL.jpg");
            }
            


        }
    }
}
