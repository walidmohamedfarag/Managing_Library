
namespace ManagingLibrary
{
    internal class Book : Item
    {
        
        public string? ISBN { get; set; }

        public int NumberOfPages { get; set; }

        

        public string GetIsbn()
        {
            string _isbn = "0123456789123";
            char[] temp = new char[13];
            
            for (int index = 0; index < _isbn.Length; index++)
            {
                Random random = new Random();
                int randomIndex = random.Next(0,_isbn.Length);
                char[] number = _isbn.ToCharArray();
                temp[index] = number[randomIndex];
            }
            return string.Join("", temp);
        }

        public override void StoreItem(Item item)
        {
            Book book = (Book)item;
            Items.Add(book.Id, book);
        }
    }
}
