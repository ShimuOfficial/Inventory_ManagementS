using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using InventorySystem.Data;
using InventorySystem.Models;

[Authorize]

public class InventoryController : Controller
{

    private readonly ApplicationDbContext _context;

    public InventoryController(ApplicationDbContext _context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var items = await _context.Items.ToListAsync();
        return View(items);
    }

    public async Task<IActionResult> LowStock()
    {
        var lowStock = await _context.Items
            .Where(i => i.Quantity <= i.ReorderLevel)
            .ToListAsync();

        return View(lowStock);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStock(int itemId, int quantity)
    {
        var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
        if (item != null)
        {
            item.Quantity = quantity;
            item.LastUpdated = DateTime.Now;

            _context.StockMovements.Add(new StockMovement
            {
                ItemId = item.Id,
                QuantityChanged = quantity,
                UpdatedBy = User.Identity.Name,
                Timestamp = DateTime.Now
            });

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}

