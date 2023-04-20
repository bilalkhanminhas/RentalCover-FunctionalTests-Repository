using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RentalCover.FunctionalTests.Model;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace RentalCover.FunctionalTests
{
   
    [Binding]
    public class QuotesSteps
    {
        private WebDriver _driver;
        private HomePageModel _homePageModel;
        private PolicyInfoAndPaymentPageModel _policyInfoAndPaymentPageModel;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _homePageModel = new HomePageModel(_driver);
            _policyInfoAndPaymentPageModel = new PolicyInfoAndPaymentPageModel(_driver);
        }

        [AfterScenario]
        public void Cleanup()
        {
            _driver.Quit();
        }

        [Given(@"I browse to the Rental Cover Homepage '(.*)'")]
        public void GivenIBrowseToTheRentalCoverHomepage(string strHomepage)
        {
            _driver.Url = strHomepage;
        }


        [When(@"I select the country where I am renting the vehicle '(.*)'")]
        public void WhenISelectTheCountryWhereIAmRentingTheVehicle(string strCountryRenting)
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".cky-btn.cky-btn-accept")));
            _homePageModel.ClickAcceptCookies();
            _homePageModel.ClickQuoteDestinationCountry();
            _homePageModel.SetQuoteDestinationCountry(strCountryRenting);
        }

        [When(@"I select the to and from dates '(.*)' '(.*)'")]
        public void WhenISelectTheToAndFromDates(string strFromDate, string strToDate)
        {
            DateTime fromDate = DateTime.Parse(strFromDate);
            DateTime today = DateTime.Today;
            Assert.IsTrue(fromDate > today, "Select a future date");

            _homePageModel.ClickQuoteFromDate();
            _homePageModel.SetQuoteFromDate(strFromDate);

            DateTime ToDate = DateTime.Parse(strToDate);
            Assert.IsTrue(ToDate > today, "Select a future date");
            Assert.IsTrue(ToDate >= fromDate, "To Date needs to be greater than equal to From Date");

            _homePageModel.ClickQuoteToDate();
            _homePageModel.SetQuoteToDate(strToDate);
        }


        [When(@"I select my country of residence '(.*)'")]
        public void WhenISelectMyCountryOfResidence(string strCountryLiving)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _homePageModel.ClickChangeCountry();
            _homePageModel.ClickQuoteFromCountry();
            _homePageModel.SetQuoteFromCountry(strCountryLiving);
        }

        [When(@"I select the vehicle I want to rent '(.*)'")]
        public void WhenISelectTheVehicleIWantToRent(string strVehicleType)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _homePageModel.ClickChangeVehicleType();
            _homePageModel.ClickQuoteVehicleType();
            _homePageModel.SetQuoteVehicleType(strVehicleType);
        }


        
        [When(@"I click the Get Instant Quote button")]
        public void WhenIClickTheGetInstantQuoteButton()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _homePageModel.ClickGetInstantQuote();
        }

        [Then(@"I am taken to the Policy Information & Payment page")]
        public void ThenIAmTakenToThePolicyInformationPaymentPage()
        {
         
            Assert.IsTrue(_policyInfoAndPaymentPageModel.PaymentPageConfirmed());

        }
    }
}
