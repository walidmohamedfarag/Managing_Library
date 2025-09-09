namespace ManagingLibrary
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Library.FillItemInLibrary();
            User.EntryLibrary();
            Library.ShowReportation();
        }
    }
}
