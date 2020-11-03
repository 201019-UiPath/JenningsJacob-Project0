using System;
using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;


namespace GGsUI.Menus
{
    public class ChangeLocationMenu : IMenu
    {
        private int userInput;
        private User user;
        private GGsContext context;
        private DBMapper mapper;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private IUserRepo userRepo;
        private UserService userService;
        private ICartRepo cartRepo;
        private CartService cartService;
        public ChangeLocationMenu(User user, GGsContext context, DBMapper mapper)
        {
            this.user = user;
            this.context = context;
            this.mapper = mapper;
            
            this.userRepo = new DBRepo(context, mapper);
            this.locationRepo = new DBRepo(context, mapper);
            this.cartRepo = new DBRepo(context, mapper);

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
            this.cartService = new CartService(cartRepo);
        }
        public void Start()
        {
            do {
                List<Location> locations = locationService.GetAllLocations();
                foreach (var l in locations)
                {
                    Console.WriteLine($"{l.id}. {l.city}, {l.state}");
                }
                Console.WriteLine("0. Cancel");
                userInput = Int32.Parse(Console.ReadLine());
                if (userInput == 0)
                    break;
                UpdateLocation(userInput);
            }while(userInput != 0);
        }
        public void UpdateLocation(int id) {
            user.locationId = id;
            userService.UpdateUser(user);

            Cart cart = cartService.GetCartByUserId(user.id);
            cartService.DeleteCart(cart);

            Cart newCart = new Cart();
            newCart.userId = user.id;
            cartService.AddCart(newCart);
        }
    }
}