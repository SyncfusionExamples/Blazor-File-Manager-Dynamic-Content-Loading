# Change Blazor File Manager content for the different users

**Repository Description**  
This repository contains a **Blazor sample application** that demonstrates how to **change the content displayed in the Syncfusion Blazor File Manager for different users**.

The project provides a quick getting‑started setup where the File Manager content can vary based on user context, enabling user‑specific file views within a Blazor application.

## Project Overview
The purpose of this project is to help developers understand how to configure the Syncfusion **Blazor File Manager** so that different users see different file content. This is useful for scenarios that require per‑user file access, role‑based views, or customized content presentation.

## Features
- Integration of **Syncfusion Blazor File Manager**
- Display different file content for different users
- User‑specific file browsing experience
- Hosted Blazor WebAssembly app on **.NET 10**

## Prerequisites
Ensure the following requirements are met before running this project:
- Visual Studio 2022  
- **.NET 10.0 SDK**
- **SQL Server LocalDB** (the sample database `NORTHWND.MDF` is included in `Shared/App_Data`)
- Syncfusion Blazor packages
- Valid Syncfusion license key (if required)

## How to run the sample
1. Clone the Repository
```bash
git clone https://github.com/SyncfusionExamples/Blazor-File-Manager-Dynamic-Content-Loading.git
```
2. Open the solution file using Visual Studio 2022.
3. Restore the NuGet packages by rebuilding the solution.
4. Run the project.
5. Once the application starts, the Blazor File Manager displays content based on the currently configured user logic.

## Configuration
The logic for displaying different content per user is implemented within the Blazor application. You can extend this logic to:
- Load user‑specific files
- Apply role‑based access rules
- Customize File Manager behavior per user

## Documentation
- Blazor File Manager – Getting Started with WebAssembly App:
https://help.syncfusion.com/file-manager-sdk/blazor/getting-started-with-wasm-app
- Blazor Introduction:
https://blazor.syncfusion.com/documentation/introduction
- General Syncfusion documentation:
https://help.syncfusion.com/

## Additional Resources
- Syncfusion Blazor File Manager product overview:
https://www.syncfusion.com/blazor-components/blazor-file-manager

## Troubleshooting
- Ensure NuGet packages are restored successfully.
- Verify that SQL Server LocalDB is installed and running (`sqllocaldb info` in a terminal).
- Verify that the Syncfusion license key is registered.
- Rebuild the solution if changes are not reflected.
- Check application logs for runtime errors.

## Support
For detailed API references, user‑specific configuration guidance, and advanced Blazor File Manager scenarios, refer to the Syncfusion Blazor documentation links provided above.
