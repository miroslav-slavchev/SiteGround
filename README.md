Installation steps:

Prerequisites:
 - Powershell installed https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.5
 - .NET 8.0 installed
 - Visual Studio (if you want to run the test by Vs test explorer, debug, etc.)

Playwright:
 - Navigate to SiteGround.Tests project(folder) and open a terminal
 - run command: `pwsh bin/Debug/net8.0/playwright.ps1 install`

Test Execution:
 - Command line:
   - Navigate to SiteGround solution (folder) and open a terminal.
   - run command `dotnet build`
   - Navigate to SiteGround.Tests project(folder) and open a terminal.
   - run command: `dotnet test`
- Visual Studio
   - Build Solution

     ![image](https://github.com/user-attachments/assets/2209892b-a95d-42a4-a717-a3123e115eb9)

   - Open Test explorer (ToolBar -> Test -> Test Explorer):

     ![image](https://github.com/user-attachments/assets/6732d50f-3e78-48e9-ba39-1a91ba83d388)

   - In the Test explorer - right-click on the Email tests and click Run:

     ![image](https://github.com/user-attachments/assets/0cbc119a-8968-4453-b84e-4a4dbdd7fa8f)
 
