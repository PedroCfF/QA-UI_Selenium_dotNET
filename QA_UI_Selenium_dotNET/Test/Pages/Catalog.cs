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
            TestContext.WriteLine("Starting the test...");
            _behaviourManager.LoginPage.Navigate();
        }

        private void Login(User? user)
        {
            if (StandardUser != null)
            {
                Assert.True(_behaviourManager.LoginPage.VerifyLogin(StandardUser, true));
            }
            else
            {
                TestContext.WriteLine("User not found");
            }
        }

        [Test]
        public void MainElementsAreDisplayed()
        {
            Login(StandardUser);

            Assert.True(_behaviourManager.CatalogPage.VerifyNavbar());
            Assert.True(_behaviourManager.CatalogPage.verifyHeaderIsCorrect());
            Assert.True(_behaviourManager.CatalogPage.verifyInventoryIsCorrect());
        }
    }
}
