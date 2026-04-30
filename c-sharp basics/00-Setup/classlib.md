# 🧠 Class Library Projects — COMPLETE MASTER NOTE

---

## 📌 1. What is a Class Library?

A **Class Library (`classlib`)** is a .NET project that:
*   **Cannot be run directly.** (It has no `Main()` method).
*   Contains reusable code (models, services, helpers).
*   Compiles into a **`.dll`** (Dynamic Link Library) file.
*   Is designed to be referenced by other projects (like Console Apps, Web APIs).

👉 It is the **foundation of modern software architecture** (Clean Architecture, Microservices).

---

## 📂 2. Project Structure

```text
MyLibrary/
│
├── MyLibrary.csproj
├── ServiceA.cs
├── ModelB.cs
│
├── bin/   (final .dll output)
└── obj/   (temporary build files)
```

---

## 📄 3. The `.csproj` Difference

Unlike a Console App, a Class Library does NOT have `<OutputType>Exe</OutputType>`. 

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework> <!-- Or netstandard2.1 for cross-compatibility -->
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

---

## 🛠️ 4. Managing Class Libraries (CLI)

### ✅ Create a new Class Library
```bash
dotnet new classlib -n MyCoolLibrary
```

### ✅ Reference it in another project
If you have a Console App that needs to use this library:

```bash
# Go to the Console App project folder
cd MyConsoleApp

# Add a reference to the Library project
dotnet add reference ../MyCoolLibrary/MyCoolLibrary.csproj
```

---

## 🔗 5. `.dll` vs `.exe`

| Feature | Class Library (`.dll`) | Console App (`.exe`) |
| :--- | :--- | :--- |
| **Execution** | Needs another app to run it. | Runs by itself. |
| **Entry Point** | No `Main()` method. | Has a `Main()` method. |
| **Purpose** | Reusable Logic / Models. | Presentation / Application Logic. |

---

## 🧠 6. When to use a Class Library?

1.  **Shared Logic**: If you have logic that needs to be used by both a **Web API** and a **Worker Service**.
2.  **Domain Models**: If you want to keep your data structures separate from your UI.
3.  **Modularization**: To break down a large app into smaller, manageable pieces (e.g., `Data.csproj`, `Services.csproj`, `UI.csproj`).

---

## 🚀 FINAL TAKEAWAYS

*   **Class Libraries** = Reusable code boxes.
*   They produce **`.dll`** files, not `.exe`.
*   They are **referenced**, never "run".
*   Essential for **Clean Architecture** and code reuse.
