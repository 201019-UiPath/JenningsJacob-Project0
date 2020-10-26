using System;

namespace GGsUI.Menus
{
    public class ManagerMenu : IMenu
    {  
        private string userInput;
        private bool showMenu = true;
        private ReplenishInventoryMenu repMenu = new ReplenishInventoryMenu();
        public void Start()
        {
            do {
                Console.WriteLine("Welcome back! Please select an option");
                Console.WriteLine("1.\tReplenish Inventory");
                Console.WriteLine("2.\tView Order History");
                Console.WriteLine("0.\tExit");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        repMenu.Start();
                        showMenu = false;
                        break;
                    case "2":
                        showMenu = false;
                        break;
                    case "0":
                        showMenu = false;
                        break;
                    default:
                        break;
                }
            } while(showMenu);
        }

        public void AddInventory() {
            Console.WriteLine("What kind of product are you adding?");
            Console.WriteLine("1.\tVideo Game");
            Console.WriteLine("2.\tGame Console");
            Console.WriteLine("3.\tShirt");
            Console.WriteLine("0.\tExit");
        }
    }
}