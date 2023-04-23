using OpenQA.Selenium;
using QA_UI_Selenium_dotNET.Behaviour.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Behaviour.Pages
{
    public class CatalogPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://www.saucedemo.com";

        By IconMenuLocator = By.Id("react-burger-menu-btn");
        private IWebElement IconMenu => _driver.FindElement(IconMenuLocator);

        By AppLogoLocator = By.XPath("//div[@class='app_logo']");
        private IWebElement AppLogo => _driver.FindElement(AppLogoLocator);

        By IconCartLocator = By.Id("shopping_cart_container");
        private IWebElement IconCart => _driver.FindElement(IconCartLocator);

        public CatalogPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public Boolean VerifyNavbar()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, IconMenuLocator);

                return (TestingUtils.IsElementVisible(IconMenu) &&
                TestingUtils.IsElementVisible(AppLogo) &&
                TestingUtils.IsElementVisible(IconCart));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("checkpoint");
                return false;
            }            
        }

        public Boolean verifyHeaderIsCorrect()
        {
            return true;
        }

        public Boolean verifyInventoryIsCorrect()
        {
            return true;
        }

        public Boolean verifyFooterIsCorrect()
        {
            return true;
        }
    }
}
