using System;
using GGsUI.Menus;
using GGsDB;

namespace GGsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMenu menu = new WelcomeMenu();

            // IMenu menu = new CustomerMainMenu();
            
            IMenu menu = new MainMenu(new GGsContext());
            menu.Start();
        }
    }
}
