# 🧠 ASP.NET Core Web API — COMPLETE MASTER NOTE

---

## 📌 1. What is a Web API?

A **Web API (`webapi`)** is a .NET project that:
*   Allows other applications to talk to it over **HTTP**.
*   Returns data (usually in **JSON** format).
*   Does NOT have a visible UI on its own (until you add a frontend).
*   Uses a **Web Server** (Kestrel) to listen for incoming requests.

👉 It is the **brain of modern web and mobile applications**.

---

## 📂 2. Project Structure

```text
MyApi/
│
├── Controllers/   (Where your logic lives)
│   └── WeatherController.cs
├── Program.cs     (Entry Point & Configuration)
├── appsettings.json (Configurations like DB connection strings)
├── MyApi.csproj
│
├── bin/   (final .exe or .dll output)
└── obj/   (temporary build files)
```

---

## 📄 3. The `Program.cs` Difference

Web API projects use the **Builder pattern** to configure the web server.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services (DI)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
```

---

## 🛠️ 4. Managing Web APIs (CLI)

### ✅ Create a new Web API
```bash
dotnet new webapi -n MyAwesomeApi
```

### ✅ Run the API
```bash
dotnet run
```
*   Your API will usually start at `https://localhost:5001`.

---

## 🔗 5. Controllers vs. Minimal APIs

| Feature | Controllers | Minimal APIs |
| :--- | :--- | :--- |
| **Structure** | Classes and Methods. | One-line mappings in `Program.cs`. |
| **Complexity** | Good for large, complex apps. | Good for small, fast microservices. |
| **Standard** | Long-standing industry standard. | Modern, lightweight alternative. |

---

## 🧪 6. Working with `appsettings.json`

This file is where we store **secrets** or **configurations** that can change without re-compiling the app.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDatabase;..."
  }
}
```

---

## 🚀 FINAL TAKEAWAYS

*   **Web APIs** communicate via **HTTP** and **JSON**.
*   They are the **Backend** of most modern apps.
*   The **Controller** is the most common way to organize API logic.
*   **Kestrel** is the built-in, lightning-fast web server for .NET.
