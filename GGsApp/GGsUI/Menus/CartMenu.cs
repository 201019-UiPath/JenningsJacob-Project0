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
        public CartMenu(User user, GGsContext context, IUserRepo userRepo, ILocationRepo locationRepo,
            IInventoryItemRepo inventoryItemRepo, IVideoGameRepo videoGameRepo, ICartRepo cartRepo, 
            ICartItemRepo cartItemRepo, IOrderRepo orderRepo, ILineItemRepo lineItemRepo)
        {
            this.user = user;
            this.context = context;
            this.mapper = new DBMapper();

            this.userRepo = userRepo;
            this.locationRepo = locationRepo;
            this.inventoryItemRepo = inventoryItemRepo;
            this.videoGameRepo = videoGameRepo;
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;
            this.orderRepo = orderRepo;
            this.lineItemRepo = lineItemRepo;

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
                    vg.PrintInfo();
                }

                Console.WriteLine("Select an option: ");
                Console.WriteLine("1. Purchase items in cart");
                Console.WriteLine("2. Edit items in cart");
                Console.WriteLine("0. Exit");
                userInput = Console.ReadLine();

                switch(userInput) {
                    case "1":
                        MakePurchase();
                        break;
                    case "2":
                        // editCartMenu.Start();
                        break;
                    case "0":
                        Console.WriteLine("Exiting");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;  
                }
            } while(!userInput.Equals("0"));
        }
        public void MakePurchase()
        {
            Cart cart = cartService.GetCartByUserId(user.id);
            List<CartItem> items = cartItemService.GetAllCartItems(cart.id);

            Order order = new Order();
            decimal totalCost = 0;

            order.userId = user.id;
            order.locationId = user.locationId;
            DateTime orderDate = order.orderDate = DateTime.Now;
            orderService.AddOrder(order);

            Order newOrder = orderService.GetOrderByDate(orderDate);

            foreach (var item in items)
            {
                VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                LineItem lineItem = new LineItem();
                lineItem.orderId = newOrder.id;
                lineItem.videoGameId = item.videoGameId;
                lineItem.price = videoGame.cost;
                lineItem.quantity = item.quantity;

                totalCost += (videoGame.cost * item.quantity);

                lineItemService.AddLineItem(lineItem);
                cartItemService.DeleteCartItem(item);

                InventoryItem inventoryItem = inventoryItemService.GetInventoryItem(user.locationId, videoGame.id);
                inventoryItem.quantity--;
                inventoryItemService.UpdateInventoryItem(inventoryItem);
            }

            order.totalCost = totalCost;
            orderService.UpdateOrder(newOrder);
            Console.WriteLine("Your has completed, thank you again");
        }
    }
}