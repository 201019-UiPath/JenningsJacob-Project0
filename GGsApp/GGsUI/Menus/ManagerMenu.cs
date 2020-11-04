using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;
using System;
using System.Collections.Generic;
using Serilog;

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
                        Log.Information("Entering Edit Inventory Menu");
                        break;
                    case "2":
                        User newUser = GetManagerDetails();
                        // TODO: Encolse in try-catch block for exception handling
                        userService.AddUser(newUser);
                        break;
                    case "0":
                        Console.WriteLine("Exiting application. Have a good day");
                        Log.Information("Exiting Applicaton");
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
            newUser.type = User.userType.Manager;
            string choice = "";
            
            Console.Write("\nEnter name: ");
            newUser.name = Console.ReadLine();

            Console.Write("Enter email: ");
            newUser.email = Console.ReadLine();

            Console.WriteLine("\nEnter a store location: ");
            do {
                try {
                    List<Location> locations = locationService.GetAllLocations();
                    foreach(var l in locations)
                    {
                        Console.WriteLine($"{l.id}. {l.city}, {l.state}");
                    }
                    choice = Console.ReadLine();
                    Console.WriteLine("0. Go Back");
                    if (choice.Equals("0"))
                        break;
                    else
                    {
                        newUser.locationId = Int32.Parse(choice);
                        newUser.location = locationService.GetLocationById(newUser.locationId);
                        break;
                    }
                        
                } catch (Exception e)
                {
                    Log.Error($"Error occured while trying to get all locations");
                    Log.Error(e.Message);
                    continue;
                }
            } while (!choice.Equals("0"));
            
            return newUser;
        }
    }
}