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
    public class LoginTests : BaseTest
    {
        public User? StandardUser { get; } = UserTestData.GetUserByUsername("standard_user");
        public User? LockedOutUser { get; } = UserTestData.GetUserByUsername("locked_out_user");
        public User? ProblemUser { get; } = UserTestData.GetUserByUsername("problem_user");
        public User? PerformanceGlitchUser { get; } = UserTestData.GetUserByUsername("performance_glitch_user");

        [SetUp]
        public void TestSetup()
        {
            _behaviourManager.LoginPage.Navigate();
        }

        [Test]
        public void StandardUserCanLoginSuccessfully()
        {
            if (StandardUser != null)
            {
                Assert.True(_behaviourManager.LoginPage.VerifyLogin(StandardUser, true));
            }
            else
            {
                Assert.Fail("User not found");
            }
        }

        [Test]
        public void LockedOutUserCannotLoginSuccessfully()
        {
            if (LockedOutUser != null)
            {
                Assert.True(_behaviourManager.LoginPage.VerifyLogin(LockedOutUser, false));
            }
            else
            {
                Assert.Fail("User not found");
            }
        }

        [Test]
        public void ProblemUserCanLoginSuccessfully()
        {
            if (ProblemUser != null)
            {
                Assert.True(_behaviourManager.LoginPage.VerifyLogin(ProblemUser, true));
            }
            else
            {
                Assert.Fail("User not found");
            }
        }

        [Test]
        public void PerformanceGlitchUserCanLoginSuccessfully()
        {
            if (PerformanceGlitchUser != null)
            {
                Assert.True(_behaviourManager.LoginPage.VerifyLogin(PerformanceGlitchUser, true));
            }
            else
            {
                Assert.Fail("User not found");
            }
        }
    }
}
