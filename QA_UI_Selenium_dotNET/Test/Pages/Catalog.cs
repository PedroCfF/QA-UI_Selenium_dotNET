using QA_UI_Selenium_dotNET.Behaviour;
using QA_UI_Selenium_dotNET.Behaviour.Pages;
using QA_UI_Selenium_dotNET.Models;
using QA_UI_Selenium_dotNET.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Test.Pages
{
    public class CatalogTests : BaseTest
    {
        public User? StandardUser { get; } = UserTestData.GetUserByUsername("standard_user");

        [SetUp]
        public void TestSetup()
        {
            _behaviourManager.LoginPage.Navigate();
        }

        [Test]
        public void MainElementsAreDisplayed()
        {
            if (StandardUser != null)
            {
                Assert.True(_behaviourManager.LoginPage.VerifyLogin(StandardUser, true));
            }
            else
            {
                Assert.Fail("User not found");
            }

            Assert.True(_behaviourManager.CatalogPage.VerifyNavbar());
        }
    }
}
