using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        // 1. Locate the item tracking instance asynchronously
        var targetProduct = await _context.Products.FindAsync(id);
        
        if (targetProduct != null)
        {
            // 2. Queue structural removal within context state tracking
            _context.Products.Remove(targetProduct);
            
            // 3. Commit database adjustments permanently to server storage
            await _context.SaveChangesAsync();
        }

        // 4. Redirect focus back to target overview listing interface dashboard
        return RedirectToAction("Index");
    }

   [HttpPost]
[ValidateAntiForgeryToken] // Fix 1: Form hijacking prevention filter added
public async Task<IActionResult> Create(Product model)
{
    // Fix 2: Ensuring incoming form values pass constraint parameters
    if (!ModelState.IsValid)
    {
        // Re-renders the form with current input fields to display error diagnostics
        return View(model);
    }

    _context.Products.Add(model);
    await _context.SaveChangesAsync();
    
    return RedirectToAction("Index");
}
}

