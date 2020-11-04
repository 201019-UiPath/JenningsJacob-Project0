using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;
using System;
using System.Collections.Generic;

namespace GGsUI.Menus
{
    public class ManagerMenu : IMenu
    {
        private string userInput;
        private GGsContext context;
        private DBMapper mapper;
        private User user;
        private IUserRepo userRepo;
        private ILocationRepo locRepo;
        private UserService userService;
        private LocationService locationService;
        private EditInventoryMenu menu;
        public ManagerMenu(ref User user, ref GGsContext context, IUserRepo userRepo, ILocationRepo locRepo)
        {
            this.user = user;
            this.context = context;
            this.mapper = new DBMapper();

            this.userRepo = userRepo;
            this.locRepo = locRepo;
            
            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locRepo);

            this.menu = new EditInventoryMenu(ref user, ref context, new DBRepo(context, mapper), new DBRepo(context, mapper), new DBRepo(context, mapper));
        }
        public void Start() 
        {
            do {
                Console.WriteLine($"\nWelcome back {user.name}!");
                Console.WriteLine("1. Manage inventory");
                Console.WriteLine("2. Create new manager");
                Console.WriteLine("0. Exit");
                
                userInput = Console.ReadLine(); 
                switch(userInput)
                {
                    case "1":
                        menu.Start();
                        break;
                    case "2":
                        User newUser = GetManagerDetails();
                        userService.AddUser(newUser);
                        break;
                    case "0":
                        Console.WriteLine("Exiting application. Have a good day");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            } while(!userInput.Equals("0"));
        }
        public User GetManagerDetails()
        {
            User newUser = new User();
            user.type = User.userType.Manager;
            string choice;
            bool showMenu = true;
            
            Console.Write("\nEnter name: ");
            newUser.name = Console.ReadLine();

            Console.Write("Enter email: ");
            newUser.email = Console.ReadLine();

            Console.WriteLine("\nEnter a store location: ");
            do {
                List<Location> locations = locationService.GetAllLocations();
                foreach(var l in locations)
                {
                    Console.WriteLine($"{l.id}. {l.street} {l.city}, {l.state} {l.zipCode}");
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
            
            return newUser;
        }
    }
}