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
        private ICartRepo cartRepo;
        private CartService cartService;
        private ICartItemRepo cartItemRepo;
        private CartItemService cartItemService;
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
            this.cartRepo = new DBRepo(context, mapper);
            this.cartItemRepo = new DBRepo(context, mapper);
            this.orderRepo = new DBRepo(context, mapper);
            this.lineItemRepo = new DBRepo(context, mapper);

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
            this.inventoryItemService = new InventoryItemService(inventoryItemRepo);
            this.videoGameService = new VideoGameService(videoGameRepo);
            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
            this.orderService = new OrderService(orderRepo);
            this.lineItemService = new LineItemService(lineItemRepo);

            this.editCartMenu = new EditCartMenu();
        }
        
        public void Start()
        {
            do {
                Cart cart = cartService.GetCartByUserId(user.id);
                List<CartItem> items = cartItemService.GetAllCartItems(cart.id);

                Console.WriteLine("Current items in cart:");
                foreach (var item in items)
                {
                    VideoGame vg = videoGameService.GetVideoGame(item.videoGameId);
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
                        Order newOrder = orderService.MakePurchase(user, cartService, cartItemService, videoGameService, lineItemService, inventoryItemService);
                        Console.WriteLine("\nOrder Receipt:");
                        orderService.GenerateReceipt(newOrder, locationService, lineItemService, videoGameService);
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
    }
}