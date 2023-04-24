using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_UI_Selenium_dotNET.Behaviour.Utils;
using QA_UI_Selenium_dotNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Behaviour.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://www.saucedemo.com/";

        private IWebElement EmailInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement SubmitButton => _driver.FindElement(By.Id("login-button"));
        private IWebElement LoginErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));
        private IWebElement Inventory => _driver.FindElement(By.Id("inventory_container"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
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

        public Boolean VerifyLogin(User user, Boolean yes)
        {
            Login(user);

            if (yes)
            {
                if (TestingUtils.IsElementVisible(Inventory))
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (!TestingUtils.IsElementVisible(LoginErrorMessage))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
