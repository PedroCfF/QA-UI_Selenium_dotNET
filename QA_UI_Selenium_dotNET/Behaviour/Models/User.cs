﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_UI_Selenium_dotNET.Models
{
    public class User
    {
        public string? userName { get; set; }
        public string? password { get; set; }

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

    }
}
