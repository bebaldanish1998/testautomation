using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testautomation.pages.pageobjects
{
    public class Home
    {

        public string selectSetupTab = "//li[@role='tablist']/a[text()='Setup']";
        public string manageTeamMembers = "[aria-label='Manage Team Members']";

        public string addTeamMember = "[title='Add Team Member'] em";
        public string firstName = "[id='firstName']";
        public string lastName = "[id='lastName']";
        public string emailId = "[id='email']";
        public string phone = "[id='phone']";
        public string role = "[id='memberRoleSelection']";

        public string username = "[id='username']";
        public string password = "[id='password']";
        public string confirmPassword = "[id='confirmPassword']";

        public string saveAndCloseButton = "//span[text()=' Save and Close ']";
        public string editButton = "//a[text()='Edit']";
        public string viewButton = "//a[text()='View']";
        public string deleteButton = "//button[text()=' Delete ']";
        public string confirmDeleteButton = "//h2[text()=' Wait! ']/following-sibling::div//button[text()=' Delete ']";
        public string searchTeamMebers = "input[placeholder='Search team members']";

        public string validateUserName = "//label[@for='username']/following-sibling::div";
        public string validateFirstName = "//label[@for='firstName']/following-sibling::div";
        public string validateLastName = "//label[@for='lastName']/following-sibling::div";
        public string validateEmail = "//label[@for='email']/following-sibling::div";
        public string validatePhone = "//label[@for='cellPhone']/following-sibling::div";
        public string validateRole = "//label[text()='Assign Role']/following-sibling::div/span";

    }
}
