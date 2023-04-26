using AventStack.ExtentReports;
using OpenQA.Selenium;
using QA_Selenium_1.Test;
using QA_UI_Selenium_dotNET.Behaviour.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Behaviour.Pages.Catalog
{

    //TODO: Add checks (tryCatch) and logs

    public class CatalogPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://www.saucedemo.com";
        private ExtentTest _testReport;

        By IconMenuLocator = By.Id("react-burger-menu-btn");
        private IWebElement IconMenu => _driver.FindElement(IconMenuLocator);

        By AppLogoLocator = By.XPath("//div[@class='app_logo']");
        private IWebElement AppLogo => _driver.FindElement(AppLogoLocator);

        By IconCartLocator = By.Id("shopping_cart_container");
        private IWebElement IconCart => _driver.FindElement(IconCartLocator);

        By InventoryContainerLocator = By.Id("inventory_container");
        private IWebElement InventoryContainer => _driver.FindElement(InventoryContainerLocator);

        By HeaderTitleLocator = By.XPath("//div[@id='header_container']//span[text()='Products']");
        private IWebElement HeaderTitle => _driver.FindElement(HeaderTitleLocator);

        By CatalogFilterLocator = By.XPath("//div[@class='right_component']//span[@class='select_container']");
        private IWebElement CatalogFilter => _driver.FindElement(CatalogFilterLocator);

        By InventoryItemLocator = By.ClassName("inventory_item");
        private IReadOnlyList<IWebElement> InventoryItems => _driver.FindElements(InventoryItemLocator);

        By FooterLocator = By.ClassName("footer");
        private IWebElement Footer => _driver.FindElement(FooterLocator);

        private bool pageIsLoaded()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, InventoryContainerLocator);
                _testReport.Log(Status.Pass, "Catalog Page was properly loaded");
                return true;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, "Catalog Page was not properly loaded || " + e);
                return false;
            }
        }

        private bool HasListOfItems(IReadOnlyList<IWebElement> list)
        {
            foreach (IWebElement element in list)
            {
                if (!IsItem(element)) return false;
            }

            return true;
        }

        private bool IsItem(IWebElement item)
        {
            IWebElement itemImage = item.FindElement(By.XPath(".//descendant::img[@class='inventory_item_img']"));
            IWebElement itemDescription = item.FindElement(By.XPath(".//div[@class='inventory_item_description']"));

            return TestingUtils.IsElementVisible(itemImage) && TestingUtils.IsElementVisible(itemDescription);
        }

        public CatalogPage(IWebDriver driver, ExtentTest testReport)
        {
            _driver = driver;
            _testReport = testReport;
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public bool VerifyNavbar()
        {
            if (!pageIsLoaded()) return false;

            if (TestingUtils.IsElementVisible(IconMenu) && TestingUtils.IsElementVisible(AppLogo) && TestingUtils.IsElementVisible(IconCart))
            {
                _testReport.Pass("Navbar elements are correct");
                return true;
            }

            _testReport.Fail("Some elements lacking in Navbar");
            return false;
        }

        public bool verifyHeaderIsCorrect()
        {
            if (!pageIsLoaded()) return false;

            if (TestingUtils.IsElementVisible(HeaderTitle) && TestingUtils.IsElementVisible(CatalogFilter))
            {
                _testReport.Pass("Header elements are correct");
                return true;
            }

            _testReport.Fail("Some elements lacking in Header");
            return false;

        }

        //TODO: verify that list lenght is more than 1 and less than 20

        public bool verifyInventoryIsCorrect()
        {
            if (!pageIsLoaded()) return false;

            if (HasListOfItems(InventoryItems))
            {
                _testReport.Pass("Inventory elements are correct");
                return true;
            }

            _testReport.Fail("Some elements lacking in Inventory");
            return false;
        }

        public bool verifyFooterIsCorrect()
        {
            if (!pageIsLoaded()) return false;

            if (TestingUtils.IsElementVisible(Footer))
            {
                _testReport.Pass("Footer elements are correct");
                return true;
            }

            _testReport.Fail("Some elements lacking in Footer");
            return false;
        }
    }
}
