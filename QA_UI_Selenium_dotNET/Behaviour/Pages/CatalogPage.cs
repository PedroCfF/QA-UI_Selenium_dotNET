using OpenQA.Selenium;
using QA_UI_Selenium_dotNET.Behaviour.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Behaviour.Pages
{

    //TODO: Add checks (tryCatch) and logs

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


        public CatalogPage(IWebDriver driver)
        {
            _driver = driver;
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

            return (TestingUtils.IsElementVisible(itemImage) && TestingUtils.IsElementVisible(itemDescription));
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public Boolean VerifyNavbar()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, InventoryContainerLocator);

                return (TestingUtils.IsElementVisible(IconMenu) &&
                TestingUtils.IsElementVisible(AppLogo) &&
                TestingUtils.IsElementVisible(IconCart));
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("Some elements are not present in Navbar || " + e);
                return false;
            }            
        }

        public Boolean verifyHeaderIsCorrect()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, InventoryContainerLocator);

                return (TestingUtils.IsElementVisible(HeaderTitle) &&
                TestingUtils.IsElementVisible(CatalogFilter));
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("Some elements are not present in Header || " + e);
                return false;
            }
        }

        public Boolean verifyInventoryIsCorrect()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, InventoryContainerLocator);

                return (HasListOfItems(InventoryItems));
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("Some elements are not present in Inventory || " + e);
                return false;
            }
        }

        public Boolean verifyFooterIsCorrect()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, InventoryContainerLocator);

                return (TestingUtils.IsElementVisible(Footer));
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("Some elements are not present in Footer || " + e);
                return false;
            }
        }
    }
}
