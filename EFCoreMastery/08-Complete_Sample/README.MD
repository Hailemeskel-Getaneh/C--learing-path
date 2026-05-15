ProductSupplierSolution
│
├── ProductSupplier.Domain
│   ├── Entities
│   ├── Interfaces
│   └── Common
│
├── ProductSupplier.Infrastructure
│   ├── Data
│   ├── Configurations
│   ├── Repositories
│   └── Migrations
│
└── ProductSupplier.ConsoleApp (optional testing)

//Later we can add other projects

├── ProductSupplier.API
├── ProductSupplier.Application
├── ProductSupplier.UI

# 📘 Product & Supplier Backend Architecture Setup Note

This note summarizes the complete project setup and architecture structure for a Product–Supplier backend system using:

* C#
* .NET
* EF Core
* SQLite
* Repository Pattern
* Fluent API
* Clean Layered Architecture

This note focuses on:

* project setup
* folders
* file structure
* package installation
* references
* architecture flow

without implementation code inside files.

---

# 📘 1. Create Solution

Create the solution:

```bash id="cmd01"
dotnet new sln -n ProductSupplierSolution
```

---

# 📘 2. Create Projects

---

# ✅ Domain Project

Contains:

* entities
* interfaces
* business rules
* common abstractions

```bash id="cmd02"
dotnet new classlib -n ProductSupplier.Domain
```

---

# ✅ Infrastructure Project

Contains:

* EF Core
* DbContext
* repositories
* database logic
* Fluent API configurations

```bash id="cmd03"
dotnet new classlib -n ProductSupplier.Infrastructure
```

---

# ✅ Console Application

Temporary testing application.

Used to:

* test repositories
* run CRUD operations
* configure DI
* execute migrations

```bash id="cmd04"
dotnet new console -n ProductSupplier.ConsoleApp
```

---

# 📘 3. Add Projects to Solution

```bash id="cmd05"
dotnet sln add ProductSupplier.Domain
dotnet sln add ProductSupplier.Infrastructure
dotnet sln add ProductSupplier.ConsoleApp
```

---

# 📘 4. Add Project References

---

# Infrastructure depends on Domain

```bash id="cmd06"
dotnet add ProductSupplier.Infrastructure reference ProductSupplier.Domain
```

---

# ConsoleApp depends on Infrastructure

```bash id="cmd07"
dotnet add ProductSupplier.ConsoleApp reference ProductSupplier.Infrastructure
```

---

# 📘 5. Install Required Packages

Packages add extra functionality to a .NET project.
In this architecture, we need packages for:

* EF Core
* SQLite database access
* migrations
* dependency injection
* hosting
* configuration management

---

# 📂 ProductSupplier.Infrastructure

Install EF Core packages:

```bash id="cmd08"
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

## ✅ Microsoft.EntityFrameworkCore

Core EF Core package.

Provides:

* DbContext
* DbSet
* LINQ querying
* change tracking
* SaveChangesAsync
* entity configuration APIs
* relationship management

This is the main ORM engine used to communicate with the database.

Without this package:

* EF Core cannot function.

---

## ✅ Microsoft.EntityFrameworkCore.Sqlite

SQLite database provider for EF Core.

Purpose:

* allows EF Core to work with SQLite databases
* translates EF Core operations into SQLite SQL commands

Provides:

* `UseSqlite()`
* SQLite-specific database behavior

Without this package:

* EF Core would not know how to connect to SQLite.

---

## ✅ Microsoft.EntityFrameworkCore.Tools

Provides EF Core command-line tools.

Used for:

* migrations
* database updates
* schema generation

Enables commands like:

```bash id="cmd10"
dotnet ef migrations add InitialCreate
```

and:

```bash id="cmd11"
dotnet ef database update
```

Without this package:

* migration commands will not work.

---

# 📂 ProductSupplier.ConsoleApp

Install hosting/configuration packages:

```bash id="cmd09"
dotnet add package Microsoft.Extensions.Hosting
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
```

---

## ✅ Microsoft.Extensions.Hosting

Provides the generic host system.

Purpose:

* creates application infrastructure
* manages application startup
* integrates dependency injection and configuration together

Used through:

```csharp id="host01"
Host.CreateDefaultBuilder(args)
```

This package gives console apps features similar to ASP.NET Core applications.

---

## ✅ Microsoft.Extensions.DependencyInjection

Provides the Dependency Injection (DI) container.

Used to:

* register services
* register repositories
* inject dependencies automatically

Examples:

* DbContext injection
* repository injection

Allows usage like:

```csharp id="di01"
services.AddScoped<IProductRepository, ProductRepository>();
```

Without this package:

* services must be created manually everywhere.

---

## ✅ Microsoft.Extensions.Configuration

Provides configuration management.

Used to:

* read application settings
* access connection strings
* load configuration values

Allows access to:

```csharp id="config01"
context.Configuration.GetConnectionString("DefaultConnection")
```

Without this package:

* appsettings.json values cannot be accessed easily.

---

## ✅ Microsoft.Extensions.Configuration.Json

Adds JSON configuration support.

Purpose:

* allows reading configuration from `appsettings.json`

Without this package:

* `.json` configuration files are not supported automatically.

This package works together with:

```text id="jsonsupport01"
Microsoft.Extensions.Configuration
```

to load JSON settings into the application.


---

# 📘 6. Suggested Folder Structure

---

# 📂 ProductSupplier.Domain

```text id="tree01"
ProductSupplier.Domain
│
├── Common
│
├── Entities
│
└── Interfaces
```

---

# 📂 ProductSupplier.Infrastructure

```text id="tree02"
ProductSupplier.Infrastructure
│
├── Data
│
├── Configurations
│
├── Repositories
│
└── Migrations
```

---

# 📂 ProductSupplier.ConsoleApp

```text id="tree03"
ProductSupplier.ConsoleApp
│
├── appsettings.json
│
└── Program.cs
```

---

# 📘 7. Domain Layer Files

---

# 📂 Common

---

## BaseEntity.cs

Contains:

* shared entity properties
* auditing fields
* soft delete logic
* shared entity behavior

Examples of responsibilities:

* Id
* CreatedAt
* UpdatedAt
* IsDeleted

---

# 📂 Entities

---

## Product.cs

Represents product domain entity.

Should contain:

* product properties
* encapsulation
* validation logic
* stock operations
* business methods

---

## Supplier.cs

Represents supplier domain entity.

Should contain:

* supplier properties
* validation logic
* contact management behavior

---

# 📂 Interfaces

---

## IProductRepository.cs

Defines:

* CRUD contracts for Product
* async repository operations

---

## ISupplierRepository.cs

Defines:

* CRUD contracts for Supplier
* async repository operations

---

# 📘 8. Infrastructure Layer Files

---

# 📂 Data

---

## ApplicationDbContext.cs

Main EF Core DbContext.

Responsibilities:

* database connection
* DbSets
* model configuration registration
* auditing interception
* SaveChanges override

---

# 📂 Configurations

---

## ProductConfiguration.cs

Contains Fluent API mapping for Product.

Responsibilities:

* table configuration
* property rules
* precision
* relationships
* constraints
* query filters

---

## SupplierConfiguration.cs

Contains Fluent API mapping for Supplier.

Responsibilities:

* property configuration
* relationships
* table settings
* query filters

---

# 📂 Repositories

---

## ProductRepository.cs

Implements Product repository logic.

Responsibilities:

* CRUD operations
* querying
* eager loading
* persistence logic

---

## SupplierRepository.cs

Implements Supplier repository logic.

Responsibilities:

* CRUD operations
* supplier queries
* related data loading

---

# 📂 Migrations

Automatically generated by EF Core.

Contains:

* database schema history
* migration files
* model snapshots

Do NOT create manually.

---

# 📘 9. Console Application Files

---

## appsettings.json

Stores:

* connection strings
* configuration settings

SQLite example:

* Data Source=ProductSupplier.db

---

## Program.cs

Application startup entry point.

Responsibilities:

* configure dependency injection
* register DbContext
* register repositories
* build host
* execute testing logic

---

# 📘 10. SQLite Database Configuration

Connection string example:

```json id="json01"
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=ProductSupplier.db"
  }
}
```

---

# 📘 11. appsettings.json Copy Configuration

Inside ConsoleApp `.csproj`:

```xml id="xml01"
<ItemGroup>
  <None Update="appsettings.json">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

Purpose:

* copy JSON file to output directory during build

---

# 📘 12. Migration Commands

---

# Create Migration

```bash id="cmd10"
dotnet ef migrations add InitialCreate --project ProductSupplier.Infrastructure --startup-project ProductSupplier.ConsoleApp
```

---

# Update Database

```bash id="cmd11"
dotnet ef database update --project ProductSupplier.Infrastructure --startup-project ProductSupplier.ConsoleApp
```

---

# 📘 13. Architecture Flow

```text id="flow01"
Console App / UI
        ↓
Repository Interfaces
        ↓
Repository Implementations
        ↓
DbContext
        ↓
SQLite Database
```

---

# 📘 14. Layer Responsibilities

---

# Domain Layer

Should contain:

* business logic
* entities
* interfaces
* validations
* encapsulation

Should NOT contain:

* EF Core
* database logic
* SQL
* UI code

---

# Infrastructure Layer

Should contain:

* EF Core
* repositories
* database configuration
* Fluent API
* migrations

Depends on Domain layer.

---

# Console Application

Temporary execution/testing layer.

Used for:

* testing repositories
* running CRUD operations
* configuring services

---

# 📘 15. Important Concepts Used

This architecture includes:

✅ Layered Architecture
✅ Separation of Concerns
✅ Repository Pattern
✅ Encapsulation
✅ Rich Domain Model
✅ Fluent API
✅ Dependency Injection
✅ EF Core
✅ SQLite
✅ Soft Delete
✅ Auditing
✅ Async CRUD Operations

---

# 📘 16. Future Improvements

Possible next enhancements:

* Generic Repository
* Unit Of Work
* Service Layer
* DTOs
* AutoMapper
* Validation Library
* Logging
* Transactions
* Exception Handling
* Seed Data
* API Layer
* Authentication
* Pagination
* Specification Pattern
