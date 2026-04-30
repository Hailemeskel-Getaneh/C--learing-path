# Unit 08 — Web Development with ASP.NET Core

This is the section where everything comes together and C# gets applied to the web. The goal is to build real HTTP APIs — the kind that mobile apps and frontend apps talk to.

## What's in here

- 01-WebAPI.md — Controllers, routing, HTTP verbs
- 02-EFCore.md — Entity Framework Core for database access
- 03-Auth.md — Authentication, middleware, and the request pipeline
- 04-Repository-Pattern.md — Repository and Unit of Work patterns

## ASP.NET Core basics

ASP.NET Core is the modern, cross-platform .NET web framework. You create a controller, add routes, and it handles the HTTP plumbing:

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase {
    [HttpGet]
    public IActionResult GetAll() {
        return Ok(products);
    }
}
```

A GET request to `/api/products` hits that method and returns JSON.

## Entity Framework Core

EF Core is an ORM — it lets you work with a database using C# objects instead of raw SQL. You define a model, create a migration, and it handles the database schema.

## What I plan to build

A Task Manager REST API with full CRUD, a database, and basic authentication.

---

*Reference: [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)*
