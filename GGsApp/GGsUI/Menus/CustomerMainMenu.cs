using System;
using GGsDB;

namespace GGsUI.Menus
{
    /// <summary>
    /// Main starting menu
    /// </summary>
    public class CustomerMainMenu:IMenu
    {
        private string userInput;
        private ICustomerRepo repo;
        private bool showMenu = true;
        private IMenu orderMenu = new PlaceOrderMenu();
        public CustomerMainMenu(ICustomerRepo repo)
        {
            this.repo = repo;
        }
        public void Start(){
            
            do {
                Console.WriteLine("Welcome to GGs! How can I help you today?");
                // Options
                Console.WriteLine("1.\tPlace Order");
                Console.WriteLine("2.\tView Order History");
                Console.WriteLine("3.\tExit");

                userInput = Console.ReadLine();
                
                switch(userInput) {
                    case "1":
                        orderMenu.Start();
                        showMenu = false;
                        break;
                    case "2":
                        // TODO: view order history
                        break;
                    case "3":
                        Console.WriteLine("Exiting");
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please select a menu item.");
                        break;
                }
            } while (showMenu);
        }
    }
}