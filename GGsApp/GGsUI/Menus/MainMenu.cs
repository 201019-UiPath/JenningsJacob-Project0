using System;

namespace GGsUI.Menus
{
    /// <summary>
    /// Main starting menu
    /// </summary>
    public class MainMenu:IMenu
    {
        public void Start(){
            Console.WriteLine("Welcome to GGs! How can I help you today?");
            // Options
            Console.WriteLine("1.\tPlace Order");
            Console.WriteLine("2.\tView Order History");
            Console.WriteLine("0.\tExit");

            switch(Int32.Parse(Console.ReadLine())) {
                case 0:
                    Console.WriteLine("Exiting");
                    break;
                case 1:
                    IMenu OrderMenu = new PlaceOrderMenu();
                    OrderMenu.Start();
                    break;
                case 2:
                    IMenu HistoryMenu = new OrderHistoryMenu();
                    HistoryMenu.Start();
                    break;
                default:
                    Console.WriteLine("Invalid Input, Please select a menu item");
                    Int32.Parse(Console.ReadLine());
                    break;
            }
        }
    }
}