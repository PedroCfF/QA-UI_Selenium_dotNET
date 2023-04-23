using OpenQA.Selenium;
using QA_UI_Selenium_dotNET.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Test
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        public BehaviourManager _behaviourManager;

        [SetUp]
        public void Setup()
        {
            Driver = WebDriverManager.CreateWebDriver();
            _behaviourManager = new BehaviourManager(Driver);
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}
