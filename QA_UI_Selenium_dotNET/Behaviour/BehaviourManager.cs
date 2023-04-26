using AventStack.ExtentReports;
using OpenQA.Selenium;
using QA_UI_Selenium_dotNET.Behaviour.Pages.Catalog;
using QA_UI_Selenium_dotNET.Behaviour.Pages.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Behaviour
{
    public class BehaviourManager
    {
        public LoginPage LoginPage { get; }
        public CatalogPage CatalogPage { get; }

        public BehaviourManager(IWebDriver driver, ExtentTest testReport)
        {
            LoginPage = new LoginPage(driver, testReport);
            CatalogPage = new CatalogPage(driver, testReport);
        }
    }
}
