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
        private CustomerMenu customerMenu;
        public ChangeLocationMenu(ref User user, ref GGsContext context, DBMapper mapper)
        {
            this.user = user;
            this.context = context;
            this.mapper = mapper;
            
            this.userRepo = new DBRepo(context, mapper);
            this.locationRepo = new DBRepo(context, mapper);

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
        }
        public void Start() 
        {
            do {
                Console.WriteLine("\nSelect a location:");
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
                customerMenu = new CustomerMenu(ref user, ref context, mapper);
                customerMenu.Start();
                break;
            }while(userInput != 0);
        }
        public void UpdateLocation(int id) {
            user = userService.UpdateUser(user, id);
            user.location = locationService.GetLocationById(id);
            Console.WriteLine($"New location: {user.location.street}, {user.location.city}, {user.location.state} {user.location.zipCode}");
        }
    }
}