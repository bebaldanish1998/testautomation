using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testautomation.pages.pageobjects
{
    public class Login
    {

        public string usernameField = "input[id='UserName']";
        public string passwordField = "input[id='Password']";
        public string signInButton = "button[id='loginBtn']";

        public string acceptTermsAndCondition = "[id='isTermsAccepted']";
        public string submitButton = "//button[text()=' Submit ']";

    }
}
