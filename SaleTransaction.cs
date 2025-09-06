
namespace ManagingLibrary
{
    internal class SaleTransaction
    {
        public Item? Item { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public static List<SaleTransaction> salesTransactions = new List<SaleTransaction>();

    
    }
}
