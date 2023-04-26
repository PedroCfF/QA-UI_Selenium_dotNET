using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Selenium_1.Test;
using QA_UI_Selenium_dotNET.Behaviour.Utils;
using QA_UI_Selenium_dotNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Behaviour.Pages.Login
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly ExtentTest _testReport;
        private readonly string _url = "https://www.saucedemo.com/";

        private IWebElement EmailInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement SubmitButton => _driver.FindElement(By.Id("login-button"));
        private IWebElement LoginErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));
        private IWebElement Inventory => _driver.FindElement(By.Id("inventory_container"));



        public LoginPage(IWebDriver driver, ExtentTest testReport)
        {
            _driver = driver;
            _testReport = testReport;
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public void Login(User user)
        {
            EmailInput.SendKeys(user.userName);
            PasswordInput.SendKeys(user.password);
            SubmitButton.Click();
        }

        public bool VerifyLogin(User user, bool yes)
        {
            Login(user);

            if (yes)
            {
                if (TestingUtils.IsElementVisible(Inventory))
                {
                    _testReport.Pass("Test passed");
                    return true;
                }

                _testReport.Fail("Test failed. Inventory element is not visible");
                return false;
            }
            else
            {
                if (TestingUtils.IsElementVisible(LoginErrorMessage))
                {
                    _testReport.Pass("Test passed");
                    return true;
                }
                _testReport.Fail("Test failed. Inventory element is visible");
                return false;
            }
        }
    }
}
