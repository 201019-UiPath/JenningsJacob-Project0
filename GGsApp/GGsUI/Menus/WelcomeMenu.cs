using System;
using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Models;
using GGsDB.Mappers;
using GGsDB.Repos;
using GGsLib;

namespace GGsUI.Menus
{
    public class WelcomeMenu : IMenu
    {
        private string userInput;
        private GGsContext context;
        private DBMapper mapper;
        private UserService userService;
        private IUserRepo userRepo;
        private LocationService locationService;
        private ILocationRepo locationRepo;
        private CustomerMenu customerMenu;
        private ManagerMenu managerMenu;
        // public WelcomeMenu(ref GGsContext context, DBMapper mapper, IUserRepo userRepo, ICartRepo cartRepo, ILocationRepo locationRepo)
        public WelcomeMenu(ref GGsContext context, DBMapper mapper, IUserRepo userRepo, ILocationRepo locationRepo)
        {
            this.context = context;
            this.mapper = mapper;

            this.userRepo = userRepo;
            // this.cartRepo = cartRepo;
            this.locationRepo = locationRepo;

            userService = new UserService(userRepo);
            locationService = new LocationService(locationRepo);
        }
        public void Start()
        {
            do{               
                System.Console.WriteLine("\nWelcome to GGs! Please select an option: ");

                //Welcome Menu options
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("0. Exit");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1" :
                        User user = SignIn();
                        if (user.type == User.userType.Customer)
                        {
                            customerMenu = new CustomerMenu(ref user, ref context, mapper);
                            customerMenu.Start();
                        } else {
                            managerMenu = new ManagerMenu(ref user, ref context, userRepo, locationRepo);
                            managerMenu.Start();
                        }
                        break;

                    case "2":
                        User newUser = SignUp();
                        try {
                            userService.AddUser(newUser);
                            customerMenu = new CustomerMenu(ref newUser, ref context, mapper);
                            customerMenu.Start();
                        } catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                        
                        break;

                    case "0" :
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        // ValidationService.InvalidInput();
                        break;
                }

            } while(!userInput.Equals("0"));
        }
        /// <summary>
        /// Prints instructions for users to sign in and creates new cart
        /// </summary>
        /// <returns>Signed in user</returns>
        public User SignIn()
        {
            string email;
            User user = new User();

            Console.Write("Enter Email:");
            email = Console.ReadLine();

            try {
                user = userService.GetUserByEmail(email);
                if (user.type == User.userType.Customer)
                {
                    try {
                        // Delete previous 
                        user.cart = new Cart();
                        user.cart.cartItems.Clear();
                        // cartService.DeleteCart(cartService.GetCartByUserId(user.id));
                    } catch (InvalidOperationException){
                        // Handle exception
                    }
                    finally {
                        // Create new card and add to DB
                        // Cart newCart = new Cart();
                        // newCart.userId = user.id;
                        // cartService.AddCart(newCart);
                    }
                }
            } catch (ArgumentException) {
                // Log error and restart
            }

            return user;
        }
        /// <summary>
        /// Prints instructions for creating new user.
        /// </summary>
        /// <returns>New user</returns>
        public User SignUp()
        {
            User newUser = new User();
            bool showMenu = true;
            string choice;

            newUser.type = User.userType.Customer;

            Console.Write("Enter name: ");
            newUser.name = Console.ReadLine();

            Console.Write("Enter email: ");
            newUser.email = Console.ReadLine();

            Console.WriteLine("Enter a preferred location: ");
            do {
                List<Location> locations = locationService.GetAllLocations();
                foreach(var l in locations)
                {
                    Console.WriteLine($"{l.id}. {l.city}, {l.state}");
                }
                choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        newUser.locationId = 1;
                        showMenu = false;
                        break;
                    case "2":
                        newUser.locationId = 2;
                        showMenu = false;
                        break;
                    case "3":
                        newUser.locationId = 3;
                        showMenu = false;
                        break;
                    case "4":
                        newUser.locationId = 4;
                        showMenu = false;
                        break;
                    case "5":
                        newUser.locationId = 5;
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (showMenu);

            // Cart newCart = new Cart();
            // newCart.userId = newUser.id;
            // cartService.AddCart(newCart);
            return newUser;
            
        }
    }
}