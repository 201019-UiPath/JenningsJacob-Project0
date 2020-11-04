using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;
using System;
using System.Collections.Generic;

namespace GGsUI.Menus
{
    public class CartMenu : IMenu
    {
        private string userInput;
        private GGsContext context;
        private DBMapper mapper;
        private User user;
        private IUserRepo userRepo;
        private UserService userService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryItemService inventoryItemService;
        private IVideoGameRepo videoGameRepo;
        private VideoGameService videoGameService;
        private IOrderRepo orderRepo;
        private OrderService orderService;
        private ILineItemRepo lineItemRepo;
        private LineItemService lineItemService;
        private EditCartMenu editCartMenu;
        private CustomerMenu customerMenu;
        public CartMenu(ref User user, ref GGsContext context, DBMapper mapper)
        {
            this.user = user;
            this.context = context;
            this.mapper = new DBMapper();

            this.userRepo = new DBRepo(context, mapper);
            this.locationRepo = new DBRepo(context, mapper);
            this.inventoryItemRepo = new DBRepo(context, mapper);
            this.videoGameRepo = new DBRepo(context, mapper);
            this.orderRepo = new DBRepo(context, mapper);
            this.lineItemRepo = new DBRepo(context, mapper);

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
            this.inventoryItemService = new InventoryItemService(inventoryItemRepo);
            this.videoGameService = new VideoGameService(videoGameRepo);
            this.orderService = new OrderService(orderRepo);
            this.lineItemService = new LineItemService(lineItemRepo);

            this.editCartMenu = new EditCartMenu();
        }
        
        public void Start()
        {
            do {
                Console.WriteLine("Current items in cart:");
                foreach (var item in user.cart.cartItems)
                {
                    VideoGame vg = item.videoGame;
                    Console.Write($"{item.quantity}x\t");
                    vg.PrintInfo();
                }

                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1. Purchase items in cart");
                // Console.WriteLine("2. Edit items in cart");
                Console.WriteLine("0. Go Back");
                userInput = Console.ReadLine();

                switch(userInput) {
                    case "1":
                        Order newOrder = orderService.MakePurchase(user, videoGameService, lineItemService, inventoryItemService);
                        Console.WriteLine("\nOrder Receipt:");
                        GenerateReceipt(newOrder);
                        Console.WriteLine("\nYour has completed, thank you again");
                        customerMenu = new CustomerMenu(ref user, ref context, mapper);
                        customerMenu.Start();
                        break;
                    case "2":
                        // editCartMenu.Start();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;  
                }
            } while(!userInput.Equals("0"));
        }
        public void GenerateReceipt(Order newOrder)
        {
            Location location = locationService.GetLocationById(newOrder.locationId);
            Console.WriteLine($"Date: {newOrder.orderDate}\tTotal: ${newOrder.totalCost}\tLocation: {location.city}, {location.state}");

            Console.WriteLine("Line items:");
            List<LineItem> newItems = lineItemService.GetAllLineItemsById(newOrder.id);
            foreach(var item in newItems)
            {
                VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                Console.Write($"{item.quantity}x\t");
                videoGame.PrintInfo();
            }
        }
    }
}