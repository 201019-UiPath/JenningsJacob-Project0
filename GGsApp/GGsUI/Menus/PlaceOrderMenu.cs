using System;

namespace GGsUI.Menus
{
    /// <summary>
    /// Menu to place order
    /// </summary>
    public class PlaceOrderMenu:IMenu
    {
        private string userInput;
        private bool showMenu = true;
        public void Start() {
            do
            {
                Console.WriteLine("\nIn order to place an order, please select one of our locations:");
                // TODO: replace hardcoded locations with persisted data
                //       probbaly want to make a foreach loop to display a menu item for each location
                // Options
                Console.WriteLine("1.\tOakland, California");
                Console.WriteLine("2.\tSeattle, Washington");
                Console.WriteLine("3.\tLas Vegas, Nevada");
                Console.WriteLine("4.\tChicago, Illinois");
                Console.WriteLine("5.\tMiami, Florida");
                
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        showMenu = false;
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            } while (showMenu);            
        }
    }
}