
namespace ManagingLibrary
{
    internal abstract class Item
    {
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public int Id { get; set; }

        public static Dictionary<int, Item> Items = new Dictionary<int, Item>();

        public abstract void StoreItem(Item item);


    }
}
