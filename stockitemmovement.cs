namespace InventorySystem.Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int QuantityChanged { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime Timestamp { get; set; }

        public Item Item { get; set; }
    }

}
