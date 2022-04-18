using HtmlAgilityPack;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 100,
        });
        var context = await browser.NewContextAsync();

        // Open new page
        var page = await context.NewPageAsync();

        // Go to https://www.storia.ro/ro/cautare/vanzare/apartament/bucuresti
        await page.GotoAsync("https://www.storia.ro/ro/cautare/vanzare/apartament/bucuresti");

        // Click button:has-text("Accept")
        await page.Locator("button:has-text(\"Accept\")").ClickAsync();

        var websiteName = "https://www.storia.ro";
        var web = new HtmlWeb();
        var doc = web.Load(page.Url);
        HtmlNodeCollection parentId = doc.DocumentNode.SelectNodes("//*[@class='css-p74l73 es62z2j17']/a");

        // Closing popup
        var list = page.Locator("//span[contains(@class, 'spinner__loading')]|//div[@id='confirmation']").WaitForAsync();

        foreach (var item in parentId)
        {
            var link = websiteName + item.GetAttributeValue("href", String.Empty);
            await page.GotoAsync(link);

            var innerLink = web.Load(link);
            var listing = innerLink.DocumentNode.SelectSingleNode(".//*[@class='css-wj4wb2 emxfhao1']").InnerText.Trim();
            Console.WriteLine(listing);
            await page.GoBackAsync();
        }
        web.Load(page.Url);
    }
}