# 03 — Authentication & Authorization

For database security, you must control who can Read or Write to your tables.

## 1. Authentication (Who are you?)
Verifying the user's identity (usually via a JWT Token).

## 2. Authorization (What can you do?)
Checking if the identified user has the right **Roles** or **Permissions**.

### Implementation in Controller
```csharp
[Authorize(Roles = "Admin")] // Only admins can reach this
[HttpPost]
public async Task<IActionResult> CreateProduct([FromBody] ProductDto dto) 
{
    // ...
}
```

## 🔐 Security Best Practices for DB
1. **Never store plain passwords**: Always hash them before saving to the DB.
2. **Use SQL Parameters**: EF Core does this automatically, which prevents **SQL Injection** attacks.
3. **Role-Based Access Control (RBAC)**: Ensure a standard User cannot delete another User's data.

---
*Reference: [Overview of ASP.NET Core authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/)*
