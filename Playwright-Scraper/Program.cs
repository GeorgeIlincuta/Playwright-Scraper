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
        });
        var context = await browser.NewContextAsync();

        // Open new page
        var page = await context.NewPageAsync();

        // Go to https://www.storia.ro/ro/cautare/vanzare/apartament/bucuresti
        await page.GotoAsync("https://www.storia.ro/ro/cautare/vanzare/apartament/bucuresti");

        // Click button:has-text("Accept")
        await page.Locator("button:has-text(\"Accept\")").ClickAsync();

        // Click text=Apartament finalizat 2 camere cu gradina Metrou 1 Decembrie 1918
        await page.RunAndWaitForNavigationAsync(async () =>
        {
            await page.Locator("text=Apartament finalizat 2 camere cu gradina Metrou 1 Decembrie 1918").ClickAsync();
        });
    }
}
