using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_UI_Selenium_dotNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace QA_UI_Selenium_dotNET.Test.Data
{
    public static class UserTestData
    {
        public static IEnumerable<User> Users
        {
            get
            {
                yield return new User("standard_user", "secret_sauce");
                yield return new User("locked_out_user", "secret_sauce");
                yield return new User("problem_user", "secret_sauce");
                yield return new User("performance_glitch_user", "secret_sauce");
            }
        }

        public static User? GetUserByUsername(string username)
        {
            return Users.FirstOrDefault(user => user.userName == username);
        }
    }
}
