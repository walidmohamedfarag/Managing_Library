
namespace ManagingLibrary
{
    internal class Member 
    {
       public string? MemberName { get; set; }
       public string? MemberEmail { get; set; }
       public int MemberId { get; set; }
       public string? Password { get; set; }

       public static Dictionary<string, Member> Members = new Dictionary<string, Member>();
       
    }
}
