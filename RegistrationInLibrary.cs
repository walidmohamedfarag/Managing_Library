

namespace ManagingLibrary
{ 
    internal class RegistrationInLibrary
    {
       
        static void LogUpLibrary() 
        {
            Member member = new();
            Console.Write("enter the name: ");
            member.MemberName = Console.ReadLine();
            Console.Write("enter the email: ");
            member.MemberEmail = Console.ReadLine();
            Console.Write("enter the phone: ");
            member.MemberPhone = Console.ReadLine();
            Console.Write("enter the address: ");
            member.MemberAddress = Console.ReadLine();
            Console.Write("enter the password: ");
            member.Password = Console.ReadLine();
            Member.Members[member.MemberEmail] = member;
            Console.WriteLine("\t\t~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t\tyou are logup successfully\n\t\t~~~~~~~~~~~~~~~~~~~~");
            if (member.MemberEmail.ToLower().EndsWith(".user"))
            {
                Library.ShowIntersted();
                Library.OperationLibrary();
            }
            else if (member.MemberEmail.ToLower().EndsWith(".admin"))
            {
                Library.ShowAdminSection();
            }
        }

        static void LogIn()
        {
            //enter password and email
            Console.Write("please enetr the email: ");
            string email = Console.ReadLine();
            Console.Write("please enetr the password: ");
            string password = Console.ReadLine();

            //check on password and email

            if (Member.Members.ContainsKey(email) && Member.Members[email].Password ==
                password && email.ToLower().EndsWith(".user"))
            {
                Library.ShowIntersted();
                Library.OperationLibrary();
            }
            else if (Member.Members.ContainsKey(email) && Member.Members[email].Password ==
                password && email.ToLower().EndsWith(".admin"))
                Library.ShowAdminSection();
            else
                Console.WriteLine("email or password incorrect");

        }

        public static void EntryLibrary() //move to library class
        {
          

            // login or logup members in library to buy or borrow
            Console.Write("welcome , if you want to buy books or magazines you must to log the library....\n" +
                "now, you want to login(if you want to have a email) | logup(if you not have a email) (login/logup): ");
            string? response = Console.ReadLine();
            if (response?.ToLower() == "login") // if you have email you can login
                RegistrationInLibrary.LogIn();
            else if (response?.ToLower() == "logup") // if not have email you can logup
                RegistrationInLibrary.LogUpLibrary();
        }

      

    }
}
