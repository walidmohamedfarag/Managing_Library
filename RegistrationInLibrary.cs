

namespace ManagingLibrary
{ 
    internal class RegistrationInLibrary
    {
        static Dictionary<string, Member> members = new Dictionary<string, Member>();
        
        delegate void RegisreationHandeller();
        static RegisreationHandeller handeller;
       

        public static void LogUpLibrary()
        {
            Member member = new();
            Console.Write("enter the name: ");
            member.MemberName = Console.ReadLine();
            Console.Write("enter the id: ");
            member.MemberId = int.Parse(Console.ReadLine());
            Console.Write("enter the email: ");
            member.MemberEmail = Console.ReadLine();
            Console.Write("enter the password: ");
            member.Password = Console.ReadLine();
            Member.Members[member.MemberEmail] = member;
            Console.WriteLine("\t\t~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t\tyou are logup successfully\n\t\t~~~~~~~~~~~~~~~~~~~~");
            handeller = Library.ShowIntersted;
            handeller += Library.OperationLibrary;
            handeller.Invoke();
        }

        public static void LogIn()
        {
            //enter password and email
            Console.Write("please enetr the email: ");
            string email = Console.ReadLine();
            Console.Write("please enetr the password: ");
            string password = Console.ReadLine();

            //check on password and email
            Func<string,string,bool> CheckLogInLibrary = (_email,_password) =>
            Member.Members.ContainsKey(_email) && Member.Members[_email].Password == _password;
            if (CheckLogInLibrary(email, password))
                handeller.Invoke();
            else
                Console.WriteLine("email or password incorrect");

        }

    }
}
