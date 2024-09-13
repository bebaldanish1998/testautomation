using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Joins;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using testautomation.actions;
using testautomation.pages.pageobjects;

namespace testautomation.pages.commons
{
    public class HomePage
    {
        private IPage page;

        string firstName;
        string lastName;
        string emailId;
        string username;
        string phoneNumber;

        public HomePage(IPage page, string firstName, string lastName, string emailId, string phoneNumber, string username)
        {
            this.page = page;
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailId = emailId;
            this.phoneNumber = phoneNumber;
            this.username  = username;
        }

        public async Task NavigateToManageUsersPage()
        {
            Home home = new Home();
            Actions actions = new Actions();

            await actions.ClickElement(page, home.selectSetupTab, "Setup Tab");
            await actions.ClickElement(page, home.manageTeamMembers, "Manage Team Members Button");
        }

        public async Task CreateUser()
        {
            Home home = new Home();
            Actions actions = new Actions();

            await actions.ClickElement(page, home.addTeamMember, "Add Team Member");

            //await actions.SelectValue(page, home.role, " Teacher ", "Member Role");
            await actions.FillData(page, home.firstName, firstName, "First Name");
            await actions.FillData(page, home.lastName, lastName, "Last Name");
            await actions.FillData(page, home.emailId, emailId, "Email Id");
            await actions.FillData(page, home.phone, phoneNumber, "Phone Number");
            await actions.FillData(page, home.username, username, "Username");
            await actions.FillData(page, home.password, "Automation123", "Password");
            await actions.FillData(page, home.confirmPassword, "Automation123", "Confirm Password");

            await page.WaitForTimeoutAsync(2_000);
            await actions.ClickElement(page, home.saveAndCloseButton, "Save and Close Button");
        }

        public async Task EditUser()
        {
            Home home = new Home();
            Actions actions = new Actions();

            phoneNumber = "651741" + new Random().Next(4000, 7000).ToString();

            await actions.FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForTimeoutAsync(3_000);
            await actions.ClickElement(page, home.editButton, "Edit Button");
            await actions.FillData(page, home.phone, phoneNumber, "Phone Number");

            await page.WaitForTimeoutAsync(2_000);
            await actions.ClickElement(page, home.saveAndCloseButton, "Save and Close Button");
        }

        public async Task ValidateUserDetails()
        {
            Home home = new Home();
            Actions actions = new Actions();

            await actions.FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForTimeoutAsync(5_000);
            await actions.ClickElement(page, home.viewButton, "View Button");

            await actions.AssertText(page, home.validateFirstName, firstName);
            await actions.AssertText(page, home.validateLastName, lastName);
            await actions.AssertText(page, home.validateEmail, emailId);
            string getPhoneNumber = await actions.GetText(page, home.validatePhone, "Phone Number");
            Assert.AreEqual(phoneNumber, new Regex("[() ]").Replace(getPhoneNumber, "").Replace("-", ""));
            await actions.AssertText(page, home.validateUserName, username);

        }

        public async Task DeleteUser()
        {
            Home home = new Home();
            Actions actions = new Actions();

            await actions.FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
            await page.WaitForTimeoutAsync(3_000);
            await actions.ClickElement(page, home.editButton, "Edit Button");

            await actions.ClickElement(page, home.deleteButton, "Delete Button");
            await actions.ClickElement(page, home.confirmDeleteButton, "Confirm Delete Button");
            await actions.ClickElement(page, home.saveAndCloseButton, "Save and Close Button");

            await actions.FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
            await page.WaitForTimeoutAsync(3_000);
        }

    }
}
