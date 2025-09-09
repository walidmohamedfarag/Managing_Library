

namespace ManagingLibrary
{ 
    delegate void RegisreationHandeller();
    internal class RegistrationInLibrary
    {
        static RegisreationHandeller handeller;
       
        public static void LogUpLibrary() //overloading on this method add parameters as string containing email and password
            //of admin if the the admin found dirctly entry the admin section (soon)
        {
            User user = new();
            Console.Write("enter the name: ");
            user.MemberName = Console.ReadLine();
            Console.Write("enter the email: ");
            user.MemberEmail = Console.ReadLine();
            Console.Write("enter the phone: ");
            user.MemberPhone = Console.ReadLine();
            Console.Write("enter the address: ");
            user.MemberAddress = Console.ReadLine();
            Console.Write("enter the password: ");
            user.Password = Console.ReadLine();
            Member.Members[user.MemberEmail] = user;
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
