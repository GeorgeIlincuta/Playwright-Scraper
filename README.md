# Playwright-Scraper
Web scraping using Playwright. To add Playwright to the project:

Add project dependency
```console
dotnet add package Microsoft.Playwright
```
Build the project
```console
dotnet build
```
Install required browsers - replace "net6.0" with actual output folder name, for example "test"
```console
pwsh bin\Debug\net6.0\playwright.ps1 install
```
If the pwsh command does not work (example pwsh command not recognized), make sure to use an up-to-date version of PowerShell.
```console
dotnet tool update --global PowerShell
```
---
Record scripts
```console
pwsh bin\Debug\net6.0\playwright.ps1 codegen
```
