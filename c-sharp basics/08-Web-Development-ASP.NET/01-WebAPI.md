# 01 — Web API (The Entry Point)

In modern backend architecture, the Web API is just a "thin layer." Its only job is to receive an HTTP request and hand it over to a **Service**.

## The Controller Structure

A clean controller should **not** have database logic (SQL/DbContext) directly inside it.

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase 
{
    private readonly IProductService _service;

    // We inject the service, not the DbContext
    public ProductsController(IProductService service) 
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) 
    {
        var product = await _service.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
}
```

## Key Responsibilities of Web API:
1. **Routing**: Defining the URL (e.g., `/api/products`).
2. **Model Binding**: Converting the JSON from the user into a C# object.
3. **Validation**: Checking if the input is correct (e.g., `[Required]`).
4. **HTTP Status Codes**: Returning `200 OK`, `404 Not Found`, or `500 Server Error`.

---
*Reference: [Create a Web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api)*
