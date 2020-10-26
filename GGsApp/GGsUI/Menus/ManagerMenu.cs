using System;

namespace GGsUI.Menus
{
    public class ManagerMenu : IMenu
    {  
        private bool showMenu = true;
        public void Start()
        {
            do {
                Console.WriteLine("Welcome back! Please select an option");
                Console.WriteLine("1.\tReplenish Inventory");
                Console.WriteLine("2.\tView Order History");
                Console.WriteLine("0.\tExit");
            } while(showMenu);
        }
    }
}