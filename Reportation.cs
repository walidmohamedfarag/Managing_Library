
namespace ManagingLibrary
{
    
    internal class Reportation
    {
        public void ReportCountSales()
        {
            Console.WriteLine("<<< sales operation >>>");
            foreach (var item in SaleTransaction.salesTransactions)
            {
                if (item.Item.Category.ToLower() == "book")
                {
                    Book book = (Book)item.Item;
                    Console.Write($"category: {book.Category}\nISBN:{book._ISBN}\ncount of item {book.Title} = {item.Quantity}\n" +
                    $"sales date: {item.SaleDate} " +
                    $"total price = {item.TotalPrice}\n");
                }
                else if (item.Item.Category.ToLower() == "magazine")
                {
                    Magazine magazine = (Magazine)item.Item;
                    Console.Write($"category: {magazine.Category}\nIssue number:{magazine._IssueNumber}\ncount of item {magazine.Title} = {item.Quantity}\n" +
                    $"sales date: {item.SaleDate} " +
                    $"total price = {item.TotalPrice}\n");
                }
                Console.WriteLine("------------------------------\n");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }

        public void ReportCountBorrow()
        {
            Console.WriteLine("<<< borrow operation >>>");
            foreach (var item in BorrowTransaction.borrowTransactions)
            {
                Console.Write($"borrow on: {item.BorrowDate} | return date: {item.ReturnDate} | of item:{item.Item.Title}\n" +
                $"borrow return: {item.ReturnDate}\n borrow member: {item.Member.MemberName}\n member email: {item.Member.MemberEmail}\n");
                Console.WriteLine("------------------------------\n");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }


    }
}
