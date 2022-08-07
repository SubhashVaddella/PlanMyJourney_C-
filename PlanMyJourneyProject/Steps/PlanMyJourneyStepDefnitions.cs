using System;
using TechTalk.SpecFlow;
using PlanMyJourney.Hooks;
using OpenQA.Selenium;
using PlanMyJourney.PageObjectModel;
using NUnit.Framework;

namespace PlanMyJourney.Steps
{
    [Binding]
    public class PlanMyJourneyStepDefinitions
    {
        public IWebDriver driver = WebHooks.driver;
        String websiteURL = "https://tfl.gov.uk/";
        PlanMyJourneyPage _planMyJourneyPage = new PlanMyJourneyPage(); 
       // PlanMyJourneyPage _planMyJourneyPage = new PlanMyJourneyPage();

        [Given(@"I navigate to Transport for London website")]
        public void GivenINavigateToTransportForLondonWebsite()
        {
            driver.Navigate().GoToUrl(websiteURL);
            driver.Manage().Window.Maximize();
            _planMyJourneyPage.ClickAcceptCookie();
        }

        [Given(@"I select valid From ""([^""]*)"" and To ""([^""]*)"" Locations")]
        [Then(@"I select valid From ""([^""]*)"" and To ""([^""]*)"" Locations")]
        public void GivenISelectValidFromAndToLocations(string from, string to)
        {
            _planMyJourneyPage.EnterToLocation(to);
            _planMyJourneyPage.EnterFromLocation(from);
        }

        [When(@"I click on Plan my journey Button")]
        [Given(@"I click on Plan my journey Button")]
        [When(@"I click on update journey Button")]
        public void WhenIClickOnPlanMyJourneyButton()
        {
            _planMyJourneyPage.ClickPlanMyJourneyButton();
        }

        [Then(@"""([^""]*)"" page should be returned")]
        public void ThenPageShouldBeReturned(string expectedPage)
        {
            Assert.AreEqual(_planMyJourneyPage.checkPage(), expectedPage);

        }

        [Then(@"Journey results show details for ""([^""]*)"" and ""([^""]*)""")]
        public void ThenJourneyResultsShowDetailsForAnd(string from, string to)
        {
            Assert.That(_planMyJourneyPage.getJourneyDetails(), Does.Contain(from));
            Assert.That(_planMyJourneyPage.getJourneyDetails(), Does.Contain(to));
        }

        [Then(@"Error is displayed stating missing required ""([^""]*)"" - ""([^""]*)""")]
        public void ThenErrorIsDisplayedStatingMissingRequired_(string fields, string error)
        {
            Assert.AreEqual(_planMyJourneyPage.getInputError(fields), error);
        }

        [Then(@"Journey is planned based on ""([^""]*)""")]
        public void ThenJourneyIsPlannedBasedOn(string travel)
        {
            Assert.That(_planMyJourneyPage.getJourneyDetails(), Does.Contain(travel));
        }

        [Given(@"change time functionality is selected")]
        public void WhenChangeTimeFunctionalityIsSelected()
        {
            _planMyJourneyPage.ClickChangeTime();
        }

        [Then(@"Arrival Time option should be available")]
        public void ThenArrivalTimeOptionShouldBeAvailable()
        {
            _planMyJourneyPage.checkArrivingLabel();
        }

        [When(@"I select Edit Journey button")]
        public void WhenISelectEditJourneyButton()
        {
            _planMyJourneyPage.ClickEditJourney();
        }

        [When(@"I Update From ""([^""]*)"" location")]
        public void WhenIUpdateFromLocation(string location)
        {
            _planMyJourneyPage.ClearFromField();
            _planMyJourneyPage.EnterFromLocation(location);
        }

        [Then(@"Error should be displayed - ""([^""]*)""")]
        public void ThenErrorShouldBeDisplayed_(string error)
        {
            Assert.That(_planMyJourneyPage.InvalidSearchErrorDetails(), Does.Contain(error));

        }

        [When(@"I click on Recents tab on Plan my journey page")]
        public void WhenIClickOnRecentsTabOnPlanMyJourneyPage()
        {
            _planMyJourneyPage.ClickRecentsTab();
        }

        [When(@"I navigate back to Plan my Journey")]
        public void WhenINavigateBackToPlanMyJourney()
        {
            _planMyJourneyPage.NavigateToPlanAJourney();
        }

        [Then(@"Recently serched journey should be available")]
        public void ThenRecentlySerchedJourneyShouldBeAvailable()
        {
            _planMyJourneyPage.GetRecentlySearchedToLocation();
        }



    }
}

