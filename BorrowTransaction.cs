
namespace ManagingLibrary
{
    internal class BorrowTransaction
    {
        public Item Item { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Member Member { get; set; }

        public static List<BorrowTransaction> borrowTransactions = new List<BorrowTransaction>();
    }
}
