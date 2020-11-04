using GGsDB.Entities;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;
using System;
using System.Collections.Generic;

namespace GGsUI.Menus
{
    public class EditInventoryMenu : IMenu
    {
        private string userInput;
        private int locationId;
        private InventoryItem selectedItem;
        private User user;
        private GGsContext context;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryItemService inventoryService;
        private IVideoGameRepo videoGameRepo;
        private VideoGameService videoGameService;
        public EditInventoryMenu(ref User user, ref GGsContext context, ILocationRepo locationRepo,IInventoryItemRepo inventoryItemRepo,IVideoGameRepo videoGameRepo)
        {
            this.user = user;
            this.context = context;

            this.locationRepo = locationRepo;
            this.inventoryItemRepo = inventoryItemRepo;
            this.videoGameRepo = videoGameRepo;

            this.locationService = new LocationService(locationRepo);
            this.inventoryService = new InventoryItemService(inventoryItemRepo);
            this.videoGameService = new VideoGameService(videoGameRepo);
        }

        public void Start()
        {
            do {
                Console.WriteLine("\nSelect an inventory to manage");
                List<Location> locations = locationService.GetAllLocations();
                foreach(var l in locations)
                {
                    Console.WriteLine($"{l.id}. {l.city}, {l.state}");
                }
                Console.WriteLine("0. Exit");
                userInput = Console.ReadLine();
                locationId = Int32.Parse(userInput);

                switch(userInput) {
                    case "1":
                        EditInventory(1);
                        break;
                    case "2":
                        EditInventory(2);
                        break;
                    case "3":
                        EditInventory(3);
                        break;
                    case "4":
                        EditInventory(4);
                        break;
                    case "5":
                        EditInventory(5);
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            } while (!userInput.Equals("0"));
        }

        public void EditInventory(int id)
        {
            string choice;
            do {
                Console.WriteLine("\nPick an item to update:");
                List<InventoryItem> items = inventoryService.GetAllInventoryItemByLocationId(locationId);
                foreach (var item in items)
                {
                    VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                    Console.Write($"{videoGame.id}. ");
                    videoGame.PrintInfo();
                    Console.WriteLine($"Quantity: {item.quantity}");
                }
                Console.WriteLine("\n0. Go Back");
                choice = Console.ReadLine();
                if (choice.Equals("0"))
                    break;
                else
                    ReplenishStock(Int32.Parse(choice));
            } while(!choice.Equals("0"));
        }
        /// <summary>
        /// Asks the user how much of a certain item they wish to replenish
        /// This is business logic that probaly belongs in GGsLib
        /// </summary>
        /// <param name="id">The videoGameId of the item they wish to replenish</param>
        public void ReplenishStock(int id)
        {
            selectedItem = inventoryService.GetInventoryItem(locationId, id);
            Console.WriteLine("\nHow many more items would you like to add?");
            int quantity = Int32.Parse(Console.ReadLine());

            // selectedItem.quantity += amount;
            inventoryService.ReplenishInventoryItem(selectedItem, quantity);
        }
    }
}