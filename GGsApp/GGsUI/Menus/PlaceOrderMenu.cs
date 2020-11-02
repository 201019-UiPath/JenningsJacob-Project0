using System;
using GGsDB;
using GGsDB.Models;

namespace GGsUI.Menus
{
    /// <summary>
    /// Menu to place order
    /// </summary>
    public class PlaceOrderMenu:IMenu
    {
        private string userInput;
        private bool showMenu = true;
        private IInventoryRepo repo;
        private InventoryMenu inventoryMenu;
        public PlaceOrderMenu(IInventoryRepo repo)
        {
            this.repo = repo;
            this.inventoryMenu = new InventoryMenu(repo);
        }
        public void Start() {  
            Console.WriteLine("\nIn order to place an order, please select one of our locations");
            foreach (var i in repo.GetAllInventories())
            {
                Console.WriteLine($"{i.Id}.\t{i.City}, {i.State}");
            }
            userInput = Console.ReadLine();
            printProducts();
        }

        public void printProducts()
        {
            int counter = 1;

            Console.WriteLine("\nVideo Games:");
            foreach (var p in repo.GetAllProducts(Int32.Parse(userInput)))
            {
                if (p is VideoGame) 
                {
                    VideoGame vg = (VideoGame) p;
                    Console.WriteLine($"{counter++}.\t{vg.Name}\t{vg.Cost}\t{vg.Genre}\t{vg.Platform}");
                }
            }
            Console.WriteLine("\n Game Consoles:");
            counter = 1;
            foreach (var p in repo.GetAllProducts(Int32.Parse(userInput)))
            {
                if (p is GameConsole) 
                {
                    GameConsole gc = (GameConsole) p;
                    Console.WriteLine($"{counter++}.\t{gc.Name}\t{gc.Cost}\t{gc.Storage}TB");
                }
            }
        }
    }
}