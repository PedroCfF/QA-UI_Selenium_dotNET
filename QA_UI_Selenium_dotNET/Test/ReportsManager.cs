using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Test
{

    internal class ReportsManager
    {
        public static ExtentReports? ReportInstance { get; private set; }
        public static ExtentTest? Test { get; set; }

        public static void SetupReport()
        {
            if (ReportInstance == null)
            {
                ReportInstance = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter("C:\\testing\\QA_UI_Selenium_dotNET\\QA_UI_Selenium_dotNET\\TestResults\\TestReports.html");
                ReportInstance.AttachReporter(htmlReporter);
            }
        }

        public static void TearDownReport()
        {
            if(ReportInstance != null)
            {
                ReportInstance.Flush();
            }
        }

        public static ExtentTest CreateTestReport()
        {
            return Test = ReportInstance.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public static void AddResultsToReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    Test.Pass("Test passed");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    Test.Fail("Test failed: " + TestContext.CurrentContext.Result.Message);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Warning:
                    Test.Warning("Test warning: " + TestContext.CurrentContext.Result.Message);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    Test.Skip("Test skipped: " + TestContext.CurrentContext.Result.Message);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Inconclusive:
                    Test.Info("Test inconclusive: " + TestContext.CurrentContext.Result.Message);
                    break;
                default:
                    Test.Info("Unknown test status: " + status);
                    break;
            }
        }
    }
}
