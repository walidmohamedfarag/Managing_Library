namespace ManagingLibrary
{
    internal class Program
    {
        public delegate void LowStockHandler();
        static void Main(string[] args)
        {
            Library.FillItemInLibrary();
            Users.EntryLibrary();
            Library.ShowReportation();
        }
    }
}
