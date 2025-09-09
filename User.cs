
using static ManagingLibrary.Program;

namespace ManagingLibrary
{
    internal class User : Member
    {

        public static void EntryLibrary() //move to library class
        {
            // login or logup in library to buy or borrow
            Console.Write("welcome , if you want to buy books or magazines you must to log the library....\n" +
                "now, you want to login(if you want to have a email) | logup(if you not have a email) (login/logup): ");
            string? response = Console.ReadLine();
            if(response?.ToLower() == "login") // if you have email you can login
                RegistrationInLibrary.LogIn();
            else if(response?.ToLower() == "logup")
                RegistrationInLibrary.LogUpLibrary();
        }

        public override bool StoreMenber(Member member)
        {
            bool checkEmail = false;
            if (!member.MemberEmail.ToLower().EndsWith(".user"))
                return checkEmail;
            Members.Add(member.MemberEmail, member);
            return true;
        }
    }
}
