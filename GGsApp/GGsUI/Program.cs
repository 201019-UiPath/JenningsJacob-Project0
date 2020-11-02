using System;
using GGsUI.Menus;
using GGsDB.Mappers;
using GGsDB.Entities;

namespace GGsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMenu menu = new WelcomeMenu();

            // IMenu menu = new CustomerMainMenu();
            
            IMenu menu = new MainMenu(new GGsContext(), new DBMapper());
            menu.Start();
        }
    }
}
