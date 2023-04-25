using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Selenium_1
{
    internal class ReportsManager
    {
        public static ExtentReports Instance { get; private set; }
        public static ExtentTest Test { get; set; }

        public static void SetupReport()
        {
            if (Instance == null)
            {
                Instance = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter("C:\\testing\\QA_UI_Selenium_dotNET\\QA_UI_Selenium_dotNET\\TestResults\\TestReports.html");
                Instance.AttachReporter(htmlReporter);
            }
        }

        public static void TearDownReport()
        {
            Instance.Flush();
        }
    }
}
