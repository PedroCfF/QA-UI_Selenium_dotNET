using OpenQA.Selenium;
using QA_Selenium_1;
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
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ReportsManager.SetupReport();
        }

        protected IWebDriver Driver;
        public BehaviourManager _behaviourManager;

        [SetUp]
        public void Setup()
        {
            Driver = WebDriverManager.CreateWebDriver();

            _behaviourManager = new BehaviourManager(Driver);
            ReportsManager.Test = ReportsManager.Instance.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void Cleanup()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    ReportsManager.Test.Pass("Test passed");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    ReportsManager.Test.Fail("Test failed: " + TestContext.CurrentContext.Result.Message);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Warning:
                    ReportsManager.Test.Warning("Test warning: " + TestContext.CurrentContext.Result.Message);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    ReportsManager.Test.Skip("Test skipped: " + TestContext.CurrentContext.Result.Message);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Inconclusive:
                    ReportsManager.Test.Info("Test inconclusive: " + TestContext.CurrentContext.Result.Message);
                    break;
                default:
                    ReportsManager.Test.Info("Unknown test status: " + status);
                    break;
            }

            Driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportsManager.TearDownReport();
        }
    }
}
