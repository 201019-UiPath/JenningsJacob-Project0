using System;
using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;

namespace GGsUI.Menus
{
    public class ProductMenu : IMenu
    {
        private int userInput;
        private User user;
        private GGsContext context;
        private DBMapper mapper;
        private VideoGame selectedGame;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryItemService invetoryItemService;
        private IVideoGameRepo videoGameRepo;
        private VideoGameService videoGameService;
        private ProductDetailsMenu productDetailsMenu;
        public ProductMenu(ref User user, ref GGsContext context, DBMapper mapper)
        {
            this.user = user;
            this.context = context;
            this.mapper = mapper;

            this.inventoryItemRepo = new DBRepo(context, mapper);
            this.videoGameRepo = new DBRepo(context, mapper);

            this.invetoryItemService = new InventoryItemService(inventoryItemRepo);
            this.videoGameService = new VideoGameService(videoGameRepo);
        }
        public void Start()
        {
            do {
                Console.WriteLine("\nSelect a product");
                List<InventoryItem> items = invetoryItemService.GetAllInventoryItemByLocationId(user.locationId);
                foreach(var item in items) {
                    VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                    Console.Write($"{videoGame.id}. ");
                    videoGame.PrintInfo();
                    Console.WriteLine($"Quantity: {item.quantity}\n");
                }
                Console.WriteLine("\n0. Go back");

                userInput = Int32.Parse(Console.ReadLine());
                if (userInput == 0)
                    break;
                selectedGame = videoGameService.GetVideoGame(userInput);
                productDetailsMenu = new ProductDetailsMenu(ref user, selectedGame, ref context, mapper);
                productDetailsMenu.Start();
            } while (userInput != 0);
        }
    }
}