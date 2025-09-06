
namespace ManagingLibrary
{
    internal class Magazine : Item
    {
        public int _IssueNumber
        {
            get
            {
                Random random = new Random();
                return random.Next(100, 500);
            }
        }
        public int IssueNumber;
        public DateTime IssueDate { get; set; }

        public override void StoreItem(Item item)
        {
            Magazine magazine = (Magazine)item;
            Items.Add(magazine.Id, magazine);
        }
    }
}
