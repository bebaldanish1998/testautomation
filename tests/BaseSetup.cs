using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testautomation.actions;

namespace testautomation.tests
{
    public class BaseSetup
    {

        public IPlaywright playwright;
        public IBrowserContext browserContext;
        public IPage page;

        public static string firstName = "";
        public static string lastName = "";
        public static string emailId = "";
        public static string username = "";
        public static string phoneNumber = "";

        [OneTimeSetUp]
        public static void GenerateRandomValues()
        {
            string[] firstNames = { "Abu", "Demo", "Michael", "Raju", "Johnson", "John", "Brendon", "Wayne", "Shawn", "Starc", "Marsh", "Sanjay", "Siva", "Yogesh", "Karthik" };
            string[] lastNames = { "Alcazar", "Mike", "David", "Nick", "Nelson", "John", "Shivam", "Warne", "Indril", "Joseph", "Mitch", "Raj", "Suresh", "Irfan", "Rahul" };

            int num = new Random().Next(14);
            firstName = firstNames[num];
            num = new Random().Next(14);
            lastName = lastNames[num];

            int randomNum = new Random().Next(5000);
            emailId = $"{firstName}{lastName}{num}@demo.com";
            username = $"{firstName}{lastName}{randomNum}";

            phoneNumber = "651452" + new Random().Next(1000, 4000).ToString();

        }

        [SetUp]
        public async Task Setup()
        {
            string browserName = Base.ReadConfig("browser");
            bool headless = bool.Parse(Base.ReadConfig("headless"));

            playwright = await Playwright.CreateAsync();
            browserContext = await playwright.Chromium.LaunchPersistentContextAsync("", new BrowserTypeLaunchPersistentContextOptions() { Headless = headless, Channel = browserName });
            var pages = browserContext.Pages;

            page = pages[0];
        }

        [TearDown]
        public async Task TearDown()
        {
            await page.CloseAsync();
        }

    }
}
