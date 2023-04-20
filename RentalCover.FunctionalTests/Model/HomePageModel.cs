using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RentalCover.FunctionalTests.Model
{
     class HomePageModel
    {
        #region Properties
        private readonly IWebDriver _driver;
        public HomePageModel(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _quoteDestinationCountryWebElement
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".QuoteForm-destination-select.form-control.ui-autocomplete-input.Field-input"));
            }
        }

        private IWebElement _acceptCookiesWebElement
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".cky-btn.cky-btn-accept"));
            }
        }

        private IWebElement _quoteFromDateWebElement
        {
            get
            {
                return _driver.FindElement(By.Id("QuoteForm_FromDate-datepicker"));
            }
        }

        private IWebElement _quoteToDateWebElement
        {
            get
            {
                return _driver.FindElement(By.Id("QuoteForm_ToDate-datepicker"));
            }
        }

        private IWebElement _quoteChangeFromCountryWebElement
        {
            get
            {
                return _driver.FindElement(By.CssSelector("[href*='#QuoteForm-country-field']"));
            }
        }

        private IWebElement _quoteFromCountryWebElement
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".QuoteForm-country-select.form-control.ui-autocomplete-input.Field-input"));
            }
        }

        private IWebElement _quoteChangeVehicalTypeWebElement
        {
            get
            {
                return _driver.FindElement(By.CssSelector("[href*='#QuoteForm-vehicleType-field']"));

            }
        }

        private IWebElement _quoteVehicleTypeWebElement
        {
            get
            {
                return _driver.FindElement(By.Id("QuoteForm_VehicleType"));
            }
        }

        private IWebElement _getInstantQuoteWebElement
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".QuoteForm-submit.Form-submit.btn.btn-warning.btn-lg.btn-block"));
            }
        }


        #endregion


        public void ClickQuoteDestinationCountry()
        {
            _quoteDestinationCountryWebElement.Click();
        }

        public void SetQuoteDestinationCountry(string qutoeDestinationCountry)
        {

            _quoteDestinationCountryWebElement.SendKeys(qutoeDestinationCountry);
        }

        public void ClickAcceptCookies()
        {
            _acceptCookiesWebElement.Click();
        }

        public void ClickQuoteFromDate()
        {
            _quoteFromDateWebElement.Click();
        }

        public void SetQuoteFromDate(string quoteFromDate)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].removeAttribute('readonly','readonly')", _driver.FindElement(By.Id("QuoteForm_FromDate-datepicker")));
            _quoteFromDateWebElement.Clear();
            _quoteFromDateWebElement.SendKeys(quoteFromDate);
        }

        public void ClickQuoteToDate()
        {
            _quoteToDateWebElement.Click();
        }

        public void SetQuoteToDate(string quoteToDate)
        {

            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].removeAttribute('readonly','readonly')",_driver.FindElement(By.Id("QuoteForm_ToDate-datepicker")));
            _quoteToDateWebElement.Clear();
            _quoteToDateWebElement.SendKeys(quoteToDate);
        }

        public void ClickChangeCountry()
        {
            _quoteChangeFromCountryWebElement.Click();
        }

        public void ClickQuoteFromCountry()
        {
            _quoteFromCountryWebElement.Click();
        }


        public void SetQuoteFromCountry(string qutoeFromCountry)
        {

            _quoteFromCountryWebElement.SendKeys(qutoeFromCountry);
        }

        

         public void ClickChangeVehicleType()
        {
            _quoteChangeVehicalTypeWebElement.Click();
        }

        public void ClickQuoteVehicleType()
        {
            _quoteVehicleTypeWebElement.Click();
        }
        public void SetQuoteVehicleType(string strVehicleType)
        {
            SelectElement se = new SelectElement(_quoteVehicleTypeWebElement);
            bool bFound = false;
            int index = 0;
            foreach (IWebElement option in se.Options)
            {
                
                if ((option.Text).ToLower() == strVehicleType.ToLower())
                {
                    bFound = true;
                    break;
                }
                index++;
            }

            if (bFound == true)
                se.SelectByIndex(index);
            else
                se.SelectByText("4x4"); 
         
        }
        
        public void ClickGetInstantQuote()
        {
            _getInstantQuoteWebElement.Click();
        }

    }
}
