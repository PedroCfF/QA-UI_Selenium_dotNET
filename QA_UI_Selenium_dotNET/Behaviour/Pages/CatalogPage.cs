using AventStack.ExtentReports;
using OpenQA.Selenium;
using QA_UI_Selenium_dotNET.Test;
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
            Dictionary<string, By> navbarElements = new Dictionary<string, By>
            {
                { "Icon menu", IconMenuLocator },
                { "App logo", AppLogoLocator },
                { "Icon cart", IconCartLocator }
            };

            if (!PageIsLoaded()) return false;
            if (!AllElementsDisplayed(navbarElements)) return false;

            _testReport.Log(Status.Pass, "Nav bar is correct");

            return true;
        }

        public bool verifyHeaderIsCorrect()
        {
            Dictionary<string, By> headerElements = new Dictionary<string, By>
            {
                { "Header title", HeaderTitleLocator },
                { "Catalog filter", CatalogFilterLocator }
            };

            if (!PageIsLoaded()) return false;
            if (!AllElementsDisplayed(headerElements)) return false;

            _testReport.Log(Status.Pass, "Header is correct");

            return true;
        }

        public bool verifyInventoryIsCorrect()
        {
            if (!PageIsLoaded()) return false;
            if (!HasListOfItems(InventoryItems)) return false;

            _testReport.Log(Status.Pass, "Inventory is correct");

            return true;
        }

        public bool verifyFooterIsCorrect()
        {
            Dictionary<string, By> footerElements = new Dictionary<string, By>
            {
                { "Footer", FooterLocator }
            };

            if (!PageIsLoaded()) return false;
            if (!AllElementsDisplayed(footerElements)) return false;

            _testReport.Log(Status.Pass, "Footer is correct");

            return true;
        }

        private bool PageIsLoaded()
        {
            bool pageLoaded = true;

            try
            {
                TestingUtils.WaitForElement(_driver, InventoryContainerLocator);
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, "Catalog Page was not properly loaded || " + e);
                pageLoaded = false;  
            }

            return pageLoaded;
        }

        public bool AllElementsDisplayed(Dictionary<string, By> elements)
        {
            bool allElementsVisible = true;

            foreach (var kvp in elements)
            {
                string elementName = kvp.Key;
                By locator = kvp.Value;

                try
                {
                    IWebElement element = _driver.FindElement(locator);
                    if (!TestingUtils.IsElementVisible(element))
                    {
                        _testReport.Log(Status.Fail, $"{elementName} is not visible");
                        allElementsVisible = false;
                    }
                }
                catch (NoSuchElementException e)
                {
                    _testReport.Log(Status.Fail, $"{elementName} not found || {e}");
                    allElementsVisible = false;
                }
            }

            return allElementsVisible;
        }

        private bool HasListOfItems(IReadOnlyList<IWebElement> list)
        {
            bool hasList = true;

            foreach (IWebElement element in list)
            {
                try
                {
                    if (!IsItem(element))
                    {
                        _testReport.Log(Status.Fail, $"{element} is not a proper item of the list");
                        hasList = false;
                    }
                }
                catch (NoSuchElementException e)
                {
                    _testReport.Log(Status.Fail, $"{element} not found || {e}");
                    hasList = false;
                }

            }

            return hasList;
        }

        private bool IsItem(IWebElement item)
        {
            IWebElement itemImage = item.FindElement(By.XPath(".//descendant::img[@class='inventory_item_img']"));
            IWebElement itemDescription = item.FindElement(By.XPath(".//div[@class='inventory_item_description']"));

            return TestingUtils.IsElementVisible(itemImage) && TestingUtils.IsElementVisible(itemDescription);
        }
    }
}
