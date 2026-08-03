# Banking System - Sprint 2

## Overview
This project is a Windows Forms banking prototype developed across multiple sprints. Sprint 2 adds:
- MVC separation between the View and data management logic
- Customer create, read, update, and delete operations through a controller
- Custom banking exception handling for invalid transactions and insufficient funds
- Automated unit tests for deposit, withdraw, interest calculation, and fee application
- A branded customer management UI consistent with the Sprint 1 colour palette

## Solution Structure
- `GUI/` - Windows Forms application and banking model classes
- `GUI.Tests/` - MSTest suite for banking business logic
- `TESTING_LOGIC_DIAGRAM.md` - testing logic diagram and test case table

## Requirements
- Visual Studio 2022
- .NET 8 SDK for running the automated test project from the command line
- NuGet package restore enabled in Visual Studio

## Open the Solution
1. Open `Sahil_Ghangas_Sprint1.sln` in Visual Studio.
2. Restore NuGet packages if prompted.
3. Build the solution.

## Run the GUI
1. Set `GUI` as the startup project.
2. Press `F5` or select Start Debugging.
3. Use the customer list and account controls to add, edit, delete, deposit, withdraw, and calculate interest.

## Run the Unit Tests in Visual Studio
1. Open `Test > Test Explorer`.
2. Build the solution.
3. Click `Run All`.
4. Confirm all tests in `GUI.Tests` pass.

## Run the Unit Tests from Terminal
From the project root:
```powershell
dotnet test GUI.Tests/GUI.Tests.csproj --nologo -v minimal
```

## Manual Testing Checklist
- Add a customer and confirm it appears in the customer list.
- Modify the customer and confirm the updated name/contact display.
- Delete the customer and confirm it is removed.
- Deposit a valid amount and confirm the balance increases.
- Withdraw the exact balance and confirm the balance becomes zero.
- Withdraw `0` and confirm a friendly validation exception occurs.
- Withdraw beyond the Everyday account balance and confirm the Everyday-specific exception message.
- Withdraw beyond the Investment account balance and confirm the fee is applied and the Investment-specific exception message appears.
- Withdraw beyond the Omni overdraft limit by `0.01` and confirm the Omni-specific exception message appears.
- Calculate interest on Investment and Omni accounts and confirm balances update correctly.

## Notes
- The test project uses linked banking source files so it can run independently of the WinForms project.
- The repository should be cleaned before submission by removing `bin` and `obj` folders if you are packaging a ZIP.
