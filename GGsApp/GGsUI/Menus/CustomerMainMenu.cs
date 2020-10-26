using System;

namespace GGsUI.Menus
{
    /// <summary>
    /// Main starting menu
    /// </summary>
    public class CustomerMainMenu:IMenu
    {
        private string userInput;
        private bool showMenu = true;
        private IMenu orderMenu = new PlaceOrderMenu();
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
                        // Console.Clear();
                        orderMenu.Start();
                        showMenu = false;
                        break;
                    case "2":
                        IMenu HistoryMenu = new OrderHistoryMenu();
                        HistoryMenu.Start();
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