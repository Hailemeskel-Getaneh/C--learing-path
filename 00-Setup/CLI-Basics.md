# The .NET CLI

Most of my day-to-day work happens in the terminal. The .NET CLI (command line interface) is how you create projects, run code, and manage packages.

## Commands I use the most

**Create a new console project:**
```powershell
dotnet new console -n MyProjectName
```

**Run a project (from inside the project folder):**
```powershell
dotnet run
```

**Build without running (to check for errors):**
```powershell
dotnet build
```

**Restore missing packages:**
```powershell
dotnet restore
```

**See what project templates are available:**
```powershell
dotnet new list
```

## Useful tip

`dotnet watch run` is great for development. It monitors your files and automatically re-runs the app when you save changes — no need to manually restart.

## The basic workflow

1. `dotnet new console -n ProjectName` — create the project
2. `cd ProjectName` — navigate into it
3. Open in VS Code: `code .`
4. Write your code in `Program.cs`
5. `dotnet run` to test it
