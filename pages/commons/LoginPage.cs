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
    public class LoginPage
    {

        private IPage page;

        public LoginPage(IPage page) => this.page = page;

        public async Task OpenApplication()
        {
            string url = Actions.ReadConfig("url");
            await page.GotoAsync(url);
        }

        public async Task LogIn()
        {
            Login login = new Login();
            Actions actions = new Actions();

            string username = Actions.ReadConfig("username");
            string password = Actions.ReadConfig("password");

            await actions.FillData(page, login.usernameField, username, "Username");
            await actions.FillData(page, login.passwordField, password, "Password");
            await actions.ClickElement(page, login.signInButton, "Sign In Button");

            await page.WaitForTimeoutAsync(5_000);
        }

        public async Task AcceptTerms_Condition()
        {
            Login login = new Login();
            Actions actions = new Actions();

            await actions.ClickCheckbox(page, login.acceptTermsAndCondition, "Username");
            await actions.ClickElement(page, login.submitButton, "Submit Button");
        }

    }
}
