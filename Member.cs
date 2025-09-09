
namespace ManagingLibrary
{
    internal abstract class Member 
    {
       public string? MemberName { get; set; }
       public string? MemberEmail { get; set; }
        public string? MemberPhone { get; set; }
        public string? MemberAddress { get; set; }
       public string? Password { get; set; }

       public static Dictionary<string, Member> Members = new Dictionary<string, Member>();

        public abstract bool StoreMenber(Member member);
       
    }
}
