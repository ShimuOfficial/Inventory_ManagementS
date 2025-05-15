using System.ComponentModel.DataAnnotations;
namespace InventorySystem.Models
{ }

public class Item
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int Quantity { get; set; }

    [Required]
    public int ReorderLevel { get; set; }

    public DateTime LastUpdated { get; set; }
}

