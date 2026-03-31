# 🧠 Unit Test Projects — COMPLETE MASTER NOTE

---

## 📌 1. What is a Unit Test Project?

A **Unit Test Project (`xunit`, `nunit`, `mstest`)** is a .NET project that:
*   Tests your code to catch bugs and ensure quality.
*   Runs in a **test environment** (not accessible by your app users).
*   Follows the **AAA Pattern** (Arrange, Act, Assert).
*   Does not produce an app you can run — it produces **test results**.

👉 It is the **safety net** for your codebase.

---

## 📂 2. Project Structure (Standard Naming)

If your project is `MyApp.Core`, your test project should be `MyApp.Core.Tests`.

```text
MyApp.Core.Tests/
│
├── AppTests.cs
├── MyApp.Core.Tests.csproj
│
├── bin/   (test output)
└── obj/
```

---

## 📄 3. The AAA Pattern (Explained)

Every good test follows three steps:

```csharp
[Fact] // xUnit metadata tag
public void Add_TwoNumbers_ReturnsSum()
{
    // 1. Arrange (Set up your data)
    var calc = new Calculator();
    int x = 5, y = 10;

    // 2. Act (Perform the action)
    int result = calc.Add(x, y);

    // 3. Assert (Check if it's correct)
    Assert.Equal(15, result);
}
```

---

## 🛠️ 4. Managing Test Projects (CLI)

### ✅ Create a new Test Project (xUnit is the modern standard)
```bash
dotnet new xunit -n MyApp.Tests
```

### ✅ Link it to the project being tested
```bash
# Go to the Test project folder
cd MyApp.Tests

# Add reference to the project you're testing
dotnet add reference ../MyApp.Core/MyApp.Core.csproj
```

### ✅ Run all tests
```bash
dotnet test
```

---

## 🔗 5. Common Testing Frameworks

| Framework | Popularity | Style |
| :--- | :--- | :--- |
| **xUnit** | ⭐⭐⭐ Highly Professional. | Uses `[Fact]` and `[Theory]`. |
| **NUnit** | ⭐⭐⭐ Industry Veteran. | Uses `[Test]`. |
| **MSTest** | ⭐⭐ Microsoft Default. | Uses `[TestClass]` and `[TestMethod]`. |

---

## 🧪 6. Pro Tip: Theory (Para-meterized Tests)

If you have many inputs for the same test, use `[Theory]`.

```csharp
[Theory]
[InlineData(1, 1, 2)]
[InlineData(2, 2, 4)]
[InlineData(5, 5, 10)]
public void Add_MultipleInputs_ReturnsCorrectSum(int a, int b, int expected)
{
    var calc = new Calculator();
    var result = calc.Add(a, b);
    Assert.Equal(expected, result);
}
```

---

## 🚀 FINAL TAKEAWAYS

*   **Unit Tests** ensure your code works as expected.
*   **xUnit** is the modern favorite for C# development.
*   Use `dotnet test` to run your entire test suite.
*   Always use the **AAA Pattern** for clean, readable tests.
