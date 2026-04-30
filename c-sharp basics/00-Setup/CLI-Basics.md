

# 🧠 .NET CLI (Command Line Interface) 

---

## 📌 Overview

The **.NET CLI (Command Line Interface)** is a powerful tool used to manage the entire lifecycle of .NET applications.

It allows you to:

* Create projects
* Build applications
* Run programs
* Manage dependencies (NuGet)
* Work with multiple projects
* Organize solutions
* Publish applications

👉 Most real-world .NET development can be done entirely from the terminal.

---

## ⚙️ 1. Basic Commands

---

### 🔹 Check SDK Version

```bash
dotnet --version
```

✔ Shows installed SDK version (e.g., `10.0.104`)

---

### 🔹 Show Help

```bash
dotnet --help
```

✔ Lists all available commands

---

### 🔹 List Project Templates

```bash
dotnet new list
```

Common templates:

* `console`
* `webapi`
* `mvc`
* `classlib`
* `gitignore`

---

## 🏗️ 2. Creating Projects

---

### 🔹 Create a Console App

```bash
dotnet new console -n MyProjectName
```

✔ Creates a new folder with:

* `.csproj`
* `Program.cs`

---

## 📦 3. Restore Dependencies

---

### 🔹 Restore Packages

```bash
dotnet restore
```

✔ Downloads all required **NuGet packages**

👉 This step:

* Reads `.csproj`
* Creates `project.assets.json` in `/obj`

---

## 🔨 4. Build (Compile) — IMPORTANT STEP

---

### 🔹 Build the Project

```bash
dotnet build
```

✔ Compiles your code
✔ Produces output in `/bin`
✔ Generates intermediate files in `/obj`

---

### 🧠 What happens during build?

* C# → IL (Intermediate Language)
* Dependencies resolved
* Generated files created:

  * GlobalUsings
  * AssemblyInfo

---

### 🎯 Why build first?

* Detect errors early
* Ensure project compiles correctly
* Separate compilation from execution

---

## ▶️ 5. Run the Application

---

### 🔹 Run Project

```bash
dotnet run
```

✔ Internally does:

1. `dotnet build`
2. Runs the compiled app

---

### ⚠️ Important Note

👉 If already built, it may skip rebuilding unless changes exist.

---

## 🔄 6. Development Productivity

---

### 🔹 Watch Mode

```bash
dotnet watch run
```

✔ Automatically:

* Detects file changes
* Rebuilds
* Reruns the app

👉 Very useful during development

---

## 📦 7. Managing Packages (NuGet)

---

### 🔹 Add Package

```bash
dotnet add package Newtonsoft.Json
```

✔ Adds dependency to `.csproj`

---

### 🔹 What happens internally?

* Updates `.csproj`
* Runs restore
* Updates `project.assets.json`

---

## 🧩 8. Working with Multiple Projects (VERY IMPORTANT)

---

### 🧠 Real-world apps rarely use a single project

Instead, they are split into:

```text
MyApp/
│
├── MyApp.Console/
├── MyApp.Services/
├── MyApp.Data/
└── MyApp.Models/
```

---

### 🎯 Why multiple projects?

* Separation of concerns
* Reusability
* Clean architecture
* Easier testing

---

## 📁 9. Solution (.sln) — Managing Multiple Projects

---

### 🔹 What is a Solution?

A **solution** is a container for multiple projects.

👉 Think of it as:

```text
Solution = Collection of Projects
```

---

### 🔹 Create a Solution

```bash
dotnet new sln -n MySolution
```

---

### 🔹 Add Projects to Solution

```bash
dotnet sln add MyApp.Console/MyApp.Console.csproj
dotnet sln add MyApp.Services/MyApp.Services.csproj
```

---

### 🔹 Build Entire Solution

```bash
dotnet build
```

✔ Builds all projects together

---

## 🔗 10. Project References (How Projects Work Together)

---

### 🔹 Add Reference

```bash
dotnet add MyApp.Console reference MyApp.Services
```

---

### 🧠 What this does

* Links projects together
* Allows one project to use another

---

### 🔍 Example

```csharp
using MyApp.Services;
```

✔ Now Console app can use Service classes

---

## 🧠 11. Dependency Flow Example

```text
Console App
   ↓
Services
   ↓
Data
   ↓
Models
```

👉 Higher layers depend on lower layers

---

## 📤 12. Publish Application

---

### 🔹 Publish

```bash
dotnet publish -c Release
```

✔ Creates optimized build for deployment

---

### Output:

```text
bin/Release/net8.0/publish/
```

---

## 🧠 13. Typical Development Workflow

---

### 1️⃣ Create project

```bash
dotnet new console -n ProjectName
```

---

### 2️⃣ Navigate into project

```bash
cd ProjectName
```

---

### 3️⃣ Open in VS Code

```bash
code .
```

---

### 4️⃣ Restore dependencies

```bash
dotnet restore
```

---

### 5️⃣ Build project

```bash
dotnet build
```

---

### 6️⃣ Run application

```bash
dotnet run
```

---

## 🧠 14. Multi-Project Workflow

---

### 1️⃣ Create solution

```bash
dotnet new sln -n MySolution
```

---

### 2️⃣ Create projects

```bash
dotnet new console -n MyApp.Console
dotnet new classlib -n MyApp.Services
```

---

### 3️⃣ Add to solution

```bash
dotnet sln add MyApp.Console
dotnet sln add MyApp.Services
```

---

### 4️⃣ Add references

```bash
dotnet add MyApp.Console reference MyApp.Services
```

---

### 5️⃣ Build all

```bash
dotnet build
```

---

### 6️⃣ Run main project

```bash
dotnet run --project MyApp.Console
```

---

## ⚡ 15. Advanced Useful Commands

---

### 🔹 Clean build files

```bash
dotnet clean
```

✔ Deletes `/bin` and `/obj`

---

### 🔹 Run specific project

```bash
dotnet run --project MyApp.Console
```

---

### 🔹 Check installed SDKs

```bash
dotnet --list-sdks
```

---

## 🧠 FINAL MENTAL MODEL

---

```text
dotnet new → create project
dotnet restore → download dependencies
dotnet build → compile code
dotnet run → execute program

Multiple projects → managed by solution (.sln)
Projects connected via references
```

---

## 🚀 KEY TAKEAWAYS

* Always think: **Restore → Build → Run**
* `.sln` manages multiple projects
* Projects communicate via **references**
* CLI can handle **entire development lifecycle**
* Multi-project structure is standard in real-world apps

---

