using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testautomation.actions;
using testautomation.pages.pageobjects;

namespace testautomation.pages.commons
{
    public class LoginPage : Base
    {

        private IPage page;

        public LoginPage(IPage page) => this.page = page;

        public async Task OpenApplication()
        {
            string url = Base.ReadConfig("url");
            await page.GotoAsync(url);
        }

        public async Task LogIn()
        {
            Login login = new Login();

            string username = Base.ReadConfig("username");
            string password = Base.ReadConfig("password");

            await FillData(page, login.usernameField, username, "Username");
            await FillData(page, login.passwordField, password, "Password");
            await ClickElement(page, login.signInButton, "Sign In Button");

            await page.WaitForTimeoutAsync(5_000);
        }

        public async Task AcceptTerms_Condition()
        {
            Login login = new Login();

            await ClickCheckbox(page, login.acceptTermsAndCondition, "Username");
            await ClickElement(page, login.submitButton, "Submit Button");
        }

    }
}
