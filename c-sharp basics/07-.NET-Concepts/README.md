# Unit 07 — .NET Core Concepts

This section is about the infrastructure that holds professional .NET applications together. Things like Dependency Injection, configuration, and logging aren't features you notice when they work — but everything falls apart without them.

## What's in here

- 01-DI.md — Dependency Injection and why it matters
- 02-NuGet.md — installing and managing packages
- 03-Configuration.md — appsettings.json, environment variables, ILogger

## Dependency Injection

DI is the pattern where a class doesn't create its own dependencies — they get passed in from outside. This makes code much easier to test and swap out.

Instead of:
```csharp
public class UserService {
    private Database db = new Database(); // tightly coupled
}
```

You do:
```csharp
public class UserService {
    private readonly IDatabase db;
    public UserService(IDatabase db) { this.db = db; } // injected
}
```

ASP.NET Core has a built-in DI container that wires this up automatically.

## NuGet

NuGet is the package manager for .NET. Installing a package:

```powershell
dotnet add package Newtonsoft.Json
```

All packages are listed in the `.csproj` file.

---

*Reference: [Dependency Injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)*
