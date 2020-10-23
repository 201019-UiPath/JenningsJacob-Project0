using System;

namespace GGsUI.Menus
{
    public class LoginMenu : IMenu
    {
        string email;
        string password;
        public void Start()
        {
            Console.Write("Please enter your email: ");
            email = Console.ReadLine();
            Console.Write("Please enter your password: ");
            password = Console.ReadLine();
        }
    }
}