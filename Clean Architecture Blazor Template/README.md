 # Clean Architecture Solution Template
<br/>

This is a solution template for creating a Single Page App (SPA) with Blazor and ASP.NET Core following the principles of Clean Architecture.

## Technologies
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* Blazor
* MediatR
* AutoMapper
* FluentValidation
* NUnit, FluentAssertions, Moq & Respawn

## Getting Started

1. Install the latest [.NET Core SDK](https://dotnet.microsoft.com/download)
3. Start with latest version of Visual Studio or Visual Studio Code 

### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **WebUI/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

- `--project src/Infrastructure` (optional if in this folder)
- `--startup-project src/WebUI`
- `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\WebUI --output-dir Persistence\Migrations`

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebUI

Client and Sever projects is a single page application based on Blazor and ASP.NET Core 3.1. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.
Shared project contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers.

## License

This project is licensed with the [MIT license](LICENSE).
