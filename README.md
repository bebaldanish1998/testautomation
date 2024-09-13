Projects title: Test Automation
Project Description: Automate Create User, Edit User and Delete User flow.
How to run the suite:
1. Clone the repo.
2. Open the project in Visual Studio 2022.
3. Click on View and open Test Exporer.
4. Whole suite can be executed.

Automation framework:
1. Have set the priority for the test cases with the flow as Create, Edit, Delete
2. Running the browser value from config.json. (getting the url and headless value from config.json)
3. Added validations. example: After creating a user, validating all the fields again by searching with the same user.
4. Created a separate class for Actions where in in future, we can log all the steps in html report using extent report feature. (Currently only printing using Console.WriteLine)
5. Screenshots can also be taken at different pages. (not included in the framework)
   
