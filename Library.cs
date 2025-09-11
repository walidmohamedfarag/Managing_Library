
using static ManagingLibrary.Program;

namespace ManagingLibrary
{
    internal class Library
    {
        static string? caregory = string.Empty;
        public static void ShowAdminSection()//add feature (soon) fill if you admin
        {
            Book book;
            Magazine magazine;
            int exsitApp;
            do
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                Console.Write("\t\t1.add the book\n\t\t2.add the magazine\n\t\t3.exsite\n" +
                    "Please enter the number operation you want to do: ");
                int enterNumberOperation = int.Parse(Console.ReadLine());
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                if (enterNumberOperation == 1)
                {
                    book = new Book();
                    book.ISBN = book.GetIsbn();
                    Console.Write("enter the title of book: ");
                    book.Title = Console.ReadLine();
                    book.Category = "book";
                    Console.Write("enter the price of book: ");
                    book.Price = decimal.Parse(Console.ReadLine());
                    Console.Write("enter the quantity of book: ");
                    book.Quantity = int.Parse(Console.ReadLine());
                    Console.Write("enter the number of pages of book: ");
                    book.NumberOfPages = int.Parse(Console.ReadLine());
                    Console.Write("enter the id of book: ");
                    book.Id = int.Parse(Console.ReadLine());
                    book.StoreItem(book);
                }
                else if (enterNumberOperation == 2)
                {
                    magazine = new Magazine();
                    Console.Write("enter the title of magazine: ");
                    magazine.Title = Console.ReadLine();
                    magazine.Category = "magazine";
                    Console.Write("enter the price of magazine: ");
                    magazine.Price = decimal.Parse(Console.ReadLine());
                    Console.Write("enter the quantity of magazine: ");
                    magazine.Quantity = int.Parse(Console.ReadLine());
                    Console.Write("enter the id of magazine: ");
                    magazine.Id = int.Parse(Console.ReadLine());
                    magazine.IssueNumber = magazine._IssueNumber;
                    Random random = new Random();
                    magazine.IssueDate = DateTime.Now.AddMonths(-random.Next(1, 12));
                    magazine.StoreItem(magazine);
                }
                exsitApp = enterNumberOperation;
            } while(exsitApp != 3);
        }
        
        public static void ShowIntersted()
        {
            Console.Write("please tell me about intreasted you(book/magazine): ");
            caregory = Console.ReadLine();
            if (caregory.ToLower() == "book") // if book show all book in library
                ShowAllBookInLibrary();
            else if (caregory.ToLower() == "magazine") // if magazine show all magazine in library
                ShowAllMagazineInLibrary();
        }
        
        static void ShowAllBookInLibrary()
        {
            foreach(var item in Item.Items.Values)
            {
                if(item.Category == "book")
                {
                    Book book = (Book) item;
                    Console.Write($"title: {book.Title}\t| id: {book.Id}\t| ISBN: {book._ISBN}\t| peice: {book.Price}\t| number of page: {book.NumberOfPages}\n");
                }
            }
        }
        static void ShowAllMagazineInLibrary()
        {
            foreach (var item in Item.Items.Values)
            {
                if (item.Category == "magazine")
                {
                    Magazine magazine = (Magazine)item;
                    Console.Write($"title: {magazine.Title}\t| id: {magazine.Id}\t| issue number: {magazine._IssueNumber}\t| peice: {magazine.Price}" +
                        $"\t| issue date: {magazine.IssueDate}\n");
                }
            }
        }
        static void SalesItem()
        {
            string exite = string.Empty;
            do
            {
                SaleTransaction saleTransaction = new SaleTransaction();
                saleTransaction.SaleDate = DateTime.Now;
                Console.Write("enter the quantity you want to sale: ");
                saleTransaction.Quantity = int.Parse(Console.ReadLine());
                if (caregory.ToLower() == "book")
                {
                    Console.Write("enter the id of book: ");
                    int idBook = int.Parse(Console.ReadLine());
                    if (Item.Items.ContainsKey(idBook))
                    {
                        saleTransaction.Item = Item.Items[idBook];
                        if (saleTransaction.Quantity <= Item.Items[idBook].Quantity)
                        {
                            saleTransaction.TotalPrice = saleTransaction.Quantity * Item.Items[idBook].Price;
                            SaleTransaction.salesTransactions.Add(saleTransaction);
                            Item.Items[idBook].Quantity = Item.Items[idBook].Quantity - saleTransaction.Quantity;
                        }
                        else
                            Console.WriteLine("the transiaction is field (problem in quantity or price)");
                    }
                }
                else if (caregory.ToLower() == "magazine")
                {
                    Console.Write("enter the id of magazine: ");
                    int idMagazine = int.Parse(Console.ReadLine());
                    if (Item.Items.ContainsKey(idMagazine))
                    {
                        saleTransaction.Item = Item.Items[idMagazine];
                        if (saleTransaction.Quantity < Item.Items[idMagazine].Quantity)
                        {
                            saleTransaction.TotalPrice = saleTransaction.Quantity * Item.Items[idMagazine].Price;
                            SaleTransaction.salesTransactions.Add(saleTransaction);
                            Item.Items[idMagazine].Quantity = Item.Items[idMagazine].Quantity - saleTransaction.Quantity;
                        }
                        else
                            Console.WriteLine("the transiaction is field (problem in quantity or price)");
                    }
                }
                Console.Write("you want to sale any item more(yes/no): ");
                string _exite = Console.ReadLine();
                Console.WriteLine("\n");
                exite = _exite;
            } while (exite.ToLower() == "yes");
        }

        static void BorrowItem()
        {
            BorrowTransaction borrowTransaction = new BorrowTransaction();
            borrowTransaction.BorrowDate = DateTime.Now;
            borrowTransaction.ReturnDate = DateTime.Now.AddMonths(1);
            Console.Write("enter the email of member: ");
            borrowTransaction.Member = Member.Members[Console.ReadLine()];
            if (caregory.ToLower() == "book")
            {
                Console.Write("enter the id of book: ");
                int idBook = int.Parse(Console.ReadLine());
                if (Item.Items.ContainsKey(idBook))
                {
                    borrowTransaction.Item = Item.Items[idBook];
                    BorrowTransaction.borrowTransactions.Add(borrowTransaction);
                }
                else
                    Console.WriteLine("the id of book is not correct");
            }
            else if (caregory.ToLower() == "magazine")
            {
                Console.Write("enter the id of magazine: ");
                int idMagazine = int.Parse(Console.ReadLine());
                if (Item.Items.ContainsKey(idMagazine))
                {
                    borrowTransaction.Item = Item.Items[idMagazine];
                    BorrowTransaction.borrowTransactions.Add(borrowTransaction);
                }
                else
                    Console.WriteLine("the id of magazine is not correct");
            }
            else
                Console.WriteLine("the type of item is not correct");
        }

        public static void ShowReportation()
        {
            Reportation reportation = new Reportation();
            LowStockHandler lowStockHandler = reportation.ReportCountSales;
            lowStockHandler += reportation.ReportCountBorrow;
            lowStockHandler += reportation.ItemsLowStock;
            lowStockHandler.Invoke();
        }

        public static void OperationLibrary()
        {
            string exiteApp = string.Empty;
            do
            {
                Console.Write("enter the operation you want to do (sale/borrow/exite): ");
                string operation = Console.ReadLine();
                if (operation.ToLower() == "sale")
                    SalesItem();
                else if (operation.ToLower() == "borrow")
                    BorrowItem();
                exiteApp = operation;
            } while(exiteApp.ToLower() != "exite");
        }

    }
}
