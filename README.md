# QStack Solution

QStack is a multi-project solution that provides a comprehensive platform for user management, data access, real-time communication, and cross-platform client integration. It brings together several key components to build a full-featured application ecosystem.

## Overview

- **Web UI (qsBlaze):**  
  An ASP.NET Core web project using Razor components and pages. It handles user interface rendering, data display, and interactive features.

- **Data Access (DataAccessLibrary):**  
  Provides lightweight data operations using SQL and Dapper. It implements CRUD operations, user data retrieval, and role management.

- **Authentication (QStackAuth):**  
  A dedicated authentication project managing secure user sign-ins, role-based access, and identity services.

- **Desktop Client (WpfClient):**  
  A Windows Presentation Foundation (WPF) application designed to offer a rich desktop experience for the QStack ecosystem.

- **Mobile Client (MAUI):**  
  Leverages .NET MAUI to provide a cross-platform mobile application.

## Key Features

- **Comprehensive User Management:**  
  - Register new users and retrieve registered user details using interfaces like `qsBlaze/qsBlaze/Data/UserInfo/IAppUserData.cs`  
  - Edit user details and update roles, as implemented in `qsBlaze/Data/UserInfo/AppUserData.cs`

- **Robust Data Access Layer:**  
  - Efficient database operations via a dedicated data access library.  
  - Utilizes Dapper and ADO.NET to provide streamlined data processing.

- **Modern Web UI:**  
  - Built with Razor Pages and Blazor components.  
  - Dynamic data retrieval and display for a responsive user experience.

- **Secure Authentication & Authorization:**  
  - Role-based security built into the authentication service.  
  - Integration with Microsoft Identity Web and appropriate NuGet packages for secure operations.

- **Real-Time Communication:**  
  - Support for SignalR to enable live, real-time updates and interactions.  
  - See the SignalR README for more details.

- **Cross-Platform and Multi-Target Build:**  
  - Supports both .NET 6.0 and .NET 8.0 targets.  
  - Includes projects for web, desktop, and mobile clients to cover a wide range of deployment scenarios.

## Getting Started

- **Build and Run:**  
  Open the solution file in Visual Studio Code. Use the integrated build tasks (via `npm run build` if applicable or through VSBuild) to compile the projects.

- **Explore the Projects:**  
  Each project folder contains its own set of documentation and configuration files. Refer to individual README files in subdirectories for additional details and change logs.

## Additional Information

- This repository leverages several third-party NuGet packages such as Dapper, Microsoft.Data.SqlClient, SignalR, and Microsoft Identity Web to ensure high performance and secure user experience.
- For a deeper dive into the code, check out the data access interfaces and implementations in the DataAccessLibrary, as well as the UI components in the qsBlaze project.
