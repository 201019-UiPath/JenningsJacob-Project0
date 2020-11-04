using System;
using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Models;
using GGsDB.Mappers;
using GGsDB.Repos;
using GGsLib;
using Serilog;

namespace GGsUI.Menus
{
    public class WelcomeMenu : IMenu
    {
        private string userInput;
        private User user;
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
                        user = SignIn();
                        if (user.type == User.userType.Customer)
                        {
                            customerMenu = new CustomerMenu(ref user, ref context, mapper);
                            customerMenu.Start();
                            Log.Information("Entering Customer Menu");
                        } else {
                            managerMenu = new ManagerMenu(ref user, ref context, userRepo, locationRepo);
                            managerMenu.Start();
                            Log.Information("Entering Manager Menu");
                        }
                        break;

                    case "2":
                        user = SignUp();
                        try {
                            userService.AddUser(user);
                            User newUser = InitializeUser(user.email);
                            customerMenu = new CustomerMenu(ref newUser, ref context, mapper);
                            customerMenu.Start();
                            Log.Information($"Succesfully created user: {user.name}");
                            Log.Information("Entering Customer Menu");
                        } catch(Exception e)
                        {
                            Log.Error(e.Message);
                            Console.WriteLine(e.Message);
                            continue;
                        }
                        break;

                    case "0" :
                        Console.WriteLine("Goodbye!");
                        Log.Information("Exiting Application...");
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
            do {
                Console.Write("Enter Email:");
                email = Console.ReadLine();

                try {
                    user = InitializeUser(email);
                    break;
                } catch (Exception e) {
                    Log.Error($"Error occured hwen initializing user with: {user.email}");
                    Log.Error(e.Message);
                    continue;
                }
            } while(true);
            return user;
        }
        /// <summary>
        /// Prints instructions for creating new user.
        /// </summary>
        /// <returns>New user</returns>
        public User SignUp()
        {
            User newUser = new User();
            string choice;

            newUser.type = User.userType.Customer;

            Console.Write("Enter name: ");
            newUser.name = Console.ReadLine();

            Console.Write("Enter email: ");
            newUser.email = Console.ReadLine();

            Console.WriteLine("Enter a preferred location: ");
                List<Location> locations = locationService.GetAllLocations();
                foreach(var l in locations)
                {
                    Console.WriteLine($"{l.id}. {l.city}, {l.state}");
                }
                choice = Console.ReadLine();
                newUser.locationId = Int32.Parse(choice);
            return newUser;
        }
        private User InitializeUser(string email)
        {
            User newUser = userService.GetUserByEmail(email);
            newUser.cart = new Cart();
            newUser.location = locationService.GetLocationById(newUser.locationId);
            return newUser;
        }
    }
}