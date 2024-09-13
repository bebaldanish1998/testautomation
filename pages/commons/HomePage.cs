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
    public class HomePage : Base
    {
        private IPage page;

        public HomePage(IPage page) => this.page = page;

        public async Task NavigateToManageUsersPage()
        {
            Home home = new Home();

            await ClickElement(page, home.selectSetupTab, "Setup Tab");
            await ClickElement(page, home.manageTeamMembers, "Manage Team Members Button");
        }

        public async Task CreateUser(string firstName, string lastName, string emailId, string phoneNumber, string username)
        {
            Home home = new Home();

            try
            {
                await ClickElement(page, home.addTeamMember, "Add Team Member");
                await FillUserData(firstName, lastName, emailId, phoneNumber, username);
                await page.WaitForTimeoutAsync(2_000);
                await ClickElement(page, home.saveAndCloseButton, "Save and Close Button");
                await page.WaitForTimeoutAsync(5_000);
                await ValidateUserDetails(firstName, lastName, emailId, phoneNumber, username);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create new user" + ex.Message);
            }
            
        }

        public async Task FillUserData(string firstName, string lastName, string emailId, string phoneNumber, string username)
        {
            Home home = new Home();

            await FillData(page, home.firstName, firstName, "First Name");
            await FillData(page, home.lastName, lastName, "Last Name");
            await FillData(page, home.emailId, emailId, "Email Id");
            await FillData(page, home.phone, phoneNumber, "Phone Number");
            await FillData(page, home.username, username, "Username");
            await FillData(page, home.password, "Automation123", "Password");
            await FillData(page, home.confirmPassword, "Automation123", "Confirm Password");
        }

        public async Task EditUser(string firstName, string lastName, string emailId, string username)
        {
            Home home = new Home();

            string phoneNumber = "651741" + new Random().Next(4000, 7000).ToString();

            try
            {
                await FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
                await page.Keyboard.PressAsync("Enter");
                await page.WaitForTimeoutAsync(3_000);
                await ClickElement(page, home.editButton, "Edit Button");
                await EditPhoneNumber(phoneNumber);
                await page.WaitForTimeoutAsync(2_000);
                await ClickElement(page, home.saveAndCloseButton, "Save and Close Button");
                await ValidateUserDetails(firstName, lastName, emailId, phoneNumber, username);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to edit User Information" + ex.Message);
            }
        }

        public async Task EditPhoneNumber(string phoneNumber)
        {
            Home home = new Home();

            await FillData(page, home.phone, phoneNumber, "Phone Number");
        }

        public async Task ValidateUserDetails(string firstName, string lastName, string emailId, string phoneNumber, string username)
        {
            Home home = new Home();

            await FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForTimeoutAsync(5_000);
            await ClickElement(page, home.viewButton, "View Button");

            await AssertText(page, home.validateFirstName, firstName);
            await AssertText(page, home.validateLastName, lastName);
            await AssertText(page, home.validateEmail, emailId);
            string getPhoneNumber = await GetText(page, home.validatePhone, "Phone Number");
            Assert.AreEqual(phoneNumber, new Regex("[() ]").Replace(getPhoneNumber, "").Replace("-", ""));
            await AssertText(page, home.validateUserName, username);

        }

        public async Task DeleteUser(string firstName, string lastName)
        {
            Home home = new Home();

            try
            {
                await FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
                await page.WaitForTimeoutAsync(3_000);
                await ClickElement(page, home.editButton, "Edit Button");

                await ClickElement(page, home.deleteButton, "Delete Button");
                await ClickElement(page, home.confirmDeleteButton, "Confirm Delete Button");
                await ClickElement(page, home.saveAndCloseButton, "Save and Close Button");

                await FillData(page, home.searchTeamMebers, $"{lastName}, {firstName}", "Search Team Member");
                await page.WaitForTimeoutAsync(3_000);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to Delete User" + ex.ToString());
            }

        }

    }
}
