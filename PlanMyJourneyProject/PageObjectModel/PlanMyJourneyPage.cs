using System;
using OpenQA.Selenium;
using PlanMyJourney.Hooks;

namespace PlanMyJourney.PageObjectModel
{
    internal class PlanMyJourneyPage
    {
        #region Locators

        public IWebDriver driver;

        private By FromTextField = By.Id("InputFrom");
        private By ToTextField = By.Id("InputTo");
        private By PlanMyJourneyButton = By.Id("plan-journey-button");
        private By AcceptCookie = By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
        private By DoneButton_Cookie = By.XPath("//button[contains(@onclick,'endCookieProcess()')]");
        private By LastBreadCrumb = By.XPath("//span[@class='last-breadcrumb']");
        private By JourneyResultSummary = By.XPath("//div[@class='journey-result-summary']");
        private By Changetime = By.LinkText("change time");
        private By ArrivingLabel = By.Id("arriving");
        private By EditJourney = By.LinkText("Edit journey");
        private By ClearSearch = By.XPath("//*[@id='search-filter-form-0']/div/div/a");
        private By InvalidSearchError = By.XPath("//li[@class='field-validation-error']");
        private By RecentsTab = By.XPath("//*[@id='jp-recent-tab-jp']/a");
        private By PlanMyJourney = By.LinkText("Plan a journey");
        private By RecentSearchResults = By.XPath("//*[@id='jp-recent-content-jp-']/a");
        #endregion

        #region Constructor

        public PlanMyJourneyPage()
        {
            driver = WebHooks.driver;
        }
        #endregion

        #region Actions

        public void ClickAcceptCookie()
        {
            driver.FindElement(AcceptCookie).Click();
            driver.FindElement(DoneButton_Cookie).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void EnterFromLocation(String from)
        {
            driver.FindElement(FromTextField).SendKeys(from);
        }

        public void EnterToLocation(String to)
        {
            driver.FindElement(ToTextField).SendKeys(to);
        }

        public void ClickPlanMyJourneyButton()
        {
            driver.FindElement(PlanMyJourneyButton).Click();
        }

        public string checkPage()
        {
            IWebElement element = driver.FindElement(LastBreadCrumb);
            return element.Text;
        }

        public String getJourneyDetails()
        {
            IWebElement element = driver.FindElement(JourneyResultSummary);
            return element.Text;
        }

        public String getInputError(String field)
        {
            IWebElement element = driver.FindElement(By.XPath("//span[@id='Input" + field + "-error']"));
            return element.Text;
        }

        public void ClickChangeTime()
        {
            driver.FindElement(Changetime).Click();
        }

        public void checkArrivingLabel()
        {
            driver.FindElement(ArrivingLabel).Click();
        }

        public void ClickEditJourney()
        {
            driver.FindElement(EditJourney).Click();
        }

        public void ClearFromField()
        {
            driver.FindElement(ClearSearch).Click();
        }

        public String InvalidSearchErrorDetails()
        {
            IWebElement element = driver.FindElement(InvalidSearchError);
            return element.Text;
        }

        public void ClickRecentsTab()
        {
            driver.FindElement(RecentsTab).Click();
        }

        public void NavigateToPlanAJourney()
        {
            driver.FindElement(PlanMyJourney).Click();
        }

        public String GetRecentlySearchedToLocation()
        {
            IWebElement element = driver.FindElement(RecentSearchResults);
            Console.WriteLine(element.GetAttribute("data-from"));
            return element.GetAttribute("data-from");
        }


        #endregion
    }
}
