using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver _driver = new ChromeDriver();
           // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Url = "https://duckduckgo.com/";
            _driver.Manage().Window.Maximize();
            Console.WriteLine("Go to " + _driver.Url.ToString());

            /*
             //div[1]/div[3]/div/div[2]
             */

            Console.WriteLine("Search C#");
            var search = _driver.FindElement(By.Id("search_form_input_homepage"));
                search.SendKeys("c#");

            Console.WriteLine("click button search");
            _driver.FindElement(By.Id("search_button_homepage")).Click();

            Console.WriteLine("find first link");
            _driver.FindElement(By.LinkText("https://docs.microsoft.com/en-us/dotnet/csharp/")).Click();

            //Thread.Sleep(TimeSpan.FromSeconds(2));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.Id("c-guide")));

            //var text = _driver.FindElement(By.Id("c-guide")).Text;

            bool itIsUrl = _driver.Url.Contains("csharp");
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            Console.WriteLine(itIsUrl);

            if (itIsUrl)
            {
                screenshot.SaveAsFile("C:\\PitDevelop\\C#\\WebDriver1\\Screenshot\\SearchCompleted.jpg");
            }
            else
            {
                screenshot.SaveAsFile("C:\\PitDevelop\\C#\\WebDriver1\\Screenshot\\SearchFAIL.jpg");
            }

            _driver.Quit();
            Console.ReadLine();
        }
    }
}
