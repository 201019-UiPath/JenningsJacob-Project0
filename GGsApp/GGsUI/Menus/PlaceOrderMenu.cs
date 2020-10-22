using System;

namespace GGsUI.Menus
{
    /// <summary>
    /// Menu to place order
    /// </summary>
    public class PlaceOrderMenu:IMenu
    {
        public void Start() {
            Console.WriteLine("\nIn order to place an order, please select one of our locations:");
            // TODO: replace hardcoded locations with persisted data
            //       probbaly want to make a foreach loop to display a menu item for each location
            // Options
            Console.WriteLine("1.\tOakland, California");
            Console.WriteLine("2.\tSeattle, Washington");
            Console.WriteLine("3.\tLas Vegas, Nevada");
            Console.WriteLine("4.\tChicago, Illinois");
            Console.WriteLine("5.\tMiami, Florida");
        }
    }
}