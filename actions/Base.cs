using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace testautomation.actions
{
    public class Base
    {

        public async Task ClickElement(IPage page, string locator, string element)
        {
            await page.Locator(locator).ClickAsync();
            Console.WriteLine($"Clicked on element: { element }");
        }

        public async Task<string> GetText(IPage page, string locator, string element)
        {
            string text = await page.Locator(locator).InnerTextAsync();
            Console.WriteLine($"Text fetched from element: {element} is {text}");
            return text;
        }

        public async Task FillData(IPage page, string locator, string value, string element)
        {
            await page.Locator(locator).FillAsync(value);
            Console.WriteLine($"Fill Data {value} on element: {element}");
        }

        public async Task ClickCheckbox(IPage page, string locator, string element)
        {
            await page.Locator(locator).CheckAsync();
            Console.WriteLine($"Clicked on checkbox: {element}");
        }

        public async Task SelectValue(IPage page, string locator, string value, string element)
        {
            await page.Locator(locator).SelectOptionAsync(value);
        }

        public async Task AssertText(IPage page, string locator, string expectedText)
        {
            string actualText = await page.Locator(locator).InnerTextAsync();
            Assert.AreEqual(expectedText, actualText);
            Console.WriteLine($"Expected Result: {expectedText}  Actual Result {actualText}");
        }

        public static string ReadConfig(string key)
        {
            string currentPath = Directory.GetCurrentDirectory();
            if (currentPath != null)
            {
                DirectoryInfo debugPath = Directory.GetParent(currentPath);
                if (debugPath != null)
                {
                    DirectoryInfo folderPath = debugPath.Parent.Parent;
                    var jsonContent = File.ReadAllText(Path.Combine(folderPath.FullName, "config.json"));
                    IDictionary<string, string> keyValuePairs = JsonSerializer.Deserialize<IDictionary<string, string>>(jsonContent);
                    return keyValuePairs[key];
                }
            }

            return "";
        }

    }
}
