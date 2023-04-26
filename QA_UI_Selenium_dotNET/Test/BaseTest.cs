using AventStack.ExtentReports;
using OpenQA.Selenium;
using QA_Selenium_1.Test;
using QA_UI_Selenium_dotNET.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Test
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        private ExtentTest TestReport;
        public BehaviourManager _behaviourManager;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ReportsManager.SetupReport();
        }

        [SetUp]
        public void Setup()
        {
            Driver = WebDriverManager.CreateWebDriver();
            TestReport = ReportsManager.CreateTestReport();
            _behaviourManager = new BehaviourManager(Driver,TestReport);

            ReportsManager.CreateTestReport();
        }

        [TearDown]
        public void Cleanup()
        {
            ReportsManager.AddResultsToReport();   
            Driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportsManager.TearDownReport();
        }

        
    }
}
