using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace PlanMyJourney.Hooks
{
    [Binding]
    public class WebHooks
    {
        public static IWebDriver driver;

        [BeforeScenario]
        public static void BeforeScenario()
        {
            driver = new ChromeDriver();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }
    }
}
