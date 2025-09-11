
namespace ManagingLibrary
{
    internal class Member 
    {
       public string? MemberName { get; set; }
       public string? MemberEmail { get; set; }
        public string? MemberPhone { get; set; }
        public string? MemberAddress { get; set; }
       public string? Password { get; set; }

       public static Dictionary<string, Member> Members { get; private set; } = new Dictionary<string, Member>();

        public static void StoreMember(Member member)
        {
            if(member.Password.Length <= 8)
            {
                Console.Write("password must have the greater than or equal 8\nenter password again: ");
                member.Password = Console.ReadLine();
            }
            Members.Add(member.MemberEmail, member);
        }

    }
}
