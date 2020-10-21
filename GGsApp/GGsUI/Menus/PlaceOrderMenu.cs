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
            Console.WriteLine("1. Oakland, California");
            Console.WriteLine("2. Seattle, Washington");
            Console.WriteLine("3. Las Vegas, Nevada");
            Console.WriteLine("4. Chicago, Illinois");
            Console.WriteLine("5. Miami, Florida");
        }
    }
}