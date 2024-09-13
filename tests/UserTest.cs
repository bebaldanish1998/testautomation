using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testautomation.pages.commons;

namespace testautomation.tests
{
    public class UserTest : BaseSetup
    {

        [Test, Order(1)]
        public async Task CreateUser()
        {
            LoginPage loginpage = new LoginPage(page);
            HomePage homepage = new HomePage(page, firstName, lastName, emailId, phoneNumber, username);

            await loginpage.OpenApplication();
            await loginpage.LogIn();
            await homepage.NavigateToManageUsersPage();
            await homepage.CreateUser();
            await homepage.ValidateUserDetails();
        }

        [Test, Order(2)]
        public async Task EditUser()
        {
            LoginPage loginpage = new LoginPage(page);
            HomePage homepage = new HomePage(page, firstName, lastName, emailId, phoneNumber, username);

            await loginpage.OpenApplication();
            await loginpage.LogIn();
            await homepage.NavigateToManageUsersPage();
            await homepage.EditUser();
            await homepage.ValidateUserDetails();
        }

        [Test, Order(3)]
        public async Task DeleteUser()
        {
            LoginPage loginpage = new LoginPage(page);
            HomePage homepage = new HomePage(page, firstName, lastName, emailId, phoneNumber, username);

            await loginpage.OpenApplication();
            await loginpage.LogIn();
            await homepage.NavigateToManageUsersPage();
            await homepage.DeleteUser();

            // Delete functionality is not working
        }

    }
}
