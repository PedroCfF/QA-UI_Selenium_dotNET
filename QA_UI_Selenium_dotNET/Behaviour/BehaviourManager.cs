using OpenQA.Selenium;
using QA_UI_Selenium_dotNET.Behaviour.Pages;
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

        public BehaviourManager(IWebDriver driver)
        {
            LoginPage = new LoginPage(driver);
            CatalogPage = new CatalogPage(driver);
        }
    }
}
