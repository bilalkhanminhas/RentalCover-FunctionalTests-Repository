using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace RentalCover.FunctionalTests.Model
{
    class PolicyInfoAndPaymentPageModel
    {
        #region Properties
        private readonly IWebDriver _driver;
        public PolicyInfoAndPaymentPageModel(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _proceedtoPaymentWebElement
        {
            get
            {
                return _driver.FindElement(By.CssSelector("[href*='#confirm-pay']"));
            }
        }

        #endregion

        public bool PaymentPageConfirmed()
        {
            return (_proceedtoPaymentWebElement != null ? true : false);
        }
    }

    

}
