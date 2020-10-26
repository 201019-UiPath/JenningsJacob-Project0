using System;
using GGsUI.Menus;

namespace GGsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMenu menu = new WelcomeMenu();

            // IMenu menu = new CustomerMainMenu();
            
            IMenu menu = new ManagerMenu();
            menu.Start();

        }
    }
}
