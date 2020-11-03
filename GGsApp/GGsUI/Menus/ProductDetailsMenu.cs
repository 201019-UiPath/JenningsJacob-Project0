using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;
using System;

namespace GGsUI.Menus
{
    public class ProductDetailsMenu : IMenu
    {
        private string userInput;
        private User user;
        private VideoGame videoGame;
        private GGsContext context;
        private DBMapper mapper;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryItemService inventoryItemService;
        private ICartRepo cartRepo;
        private CartService cartService;
        private ICartItemRepo cartItemRepo;
        private CartItemService cartItemService;
        public ProductDetailsMenu(ref User user, VideoGame videoGame, ref GGsContext context, DBMapper mapper)
        {
            this.user = user;
            this.videoGame = videoGame;
            this.context = context;
            this.mapper = mapper;

            this.inventoryItemRepo = new DBRepo(context, mapper);
            this.cartRepo = new DBRepo(context, mapper);
            this.cartItemRepo = new DBRepo(context, mapper);

            this.inventoryItemService = new InventoryItemService(inventoryItemRepo);
            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
        }
        public void Start()
        {
            do {
                InventoryItem item = inventoryItemService.GetInventoryItem(user.locationId, videoGame.id);
                int quantity = item.quantity;

                Console.WriteLine("\nSelected Product: ");
                videoGame.PrintInfo();
                Console.WriteLine("1. Add to cart");
                Console.WriteLine("0. Go back");

                userInput = Console.ReadLine();

                if (userInput.Equals("1"))
                {
                    int q;

                    Console.WriteLine("How many would you like to buy?");
                    q = Int32.Parse(Console.ReadLine());

                    CartItem cartItem = new CartItem();
                    Cart userCart = cartService.GetCartByUserId(user.id);
                    cartItem.cartId = userCart.id;
                    cartItem.videoGameId = videoGame.id;
                    cartItem.quantity = q;
                    cartItemService.AddCartItem(cartItem);
                    break;
                }
                else if (userInput.Equals("0"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
            } while(!userInput.Equals("0"));
        }
    }
}