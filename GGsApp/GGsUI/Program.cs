using System;
using GGsUI.Menus;

namespace GGsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMenu startMenu = new WelcomeMenu();
            // startMenu.Start();

            IMenu menu = new CustomerMainMenu();
            menu.Start();
        }
    }
}
