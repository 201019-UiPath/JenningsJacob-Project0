using System;
using GGsDB;
using GGsDB.Mappers;
using GGsDB.Entities;

namespace GGsUI.Menus
{
    public class MainMenu : IMenu
    {
        private string userInput;
        private CustomerLoginMenu customerLoginMenu;
        private ManagerLoginMenu managerLoginMenu;
        private CustomerSignUpMenu customerSignUpMenu;

        public MainMenu(GGsContext context, IMapper mapper)
        {
            // TODO: add messaging service
            this.customerLoginMenu = new CustomerLoginMenu(new DBRepo(context, mapper));
            // this.managerLoginMenu = new ManagerLoginMenu(new DBRepo(context));
            this.customerSignUpMenu = new CustomerSignUpMenu(new DBRepo(context, mapper));
        }
        public void Start()
        {
            do {
                Console.WriteLine("Welcome to GGs! How can I help you today?");
                // Options
                Console.WriteLine("1.\tLogin as Customer");
                Console.WriteLine("2.\tLogin as Manager");
                Console.WriteLine("3.\tSign Up Customer");
                Console.WriteLine("4.\tSign Up Manager");
                Console.WriteLine("0.\tExit");
                userInput = Console.ReadLine();
                switch(userInput) {
                    case "0":
                        Console.WriteLine("Exiting application. Have a good day!");
                        break;
                    case "1":
                        // IMenu loginMenu = new LoginMenu();
                        customerLoginMenu.Start();
                        break;
                    case "2":
                        // TODO: Login manager
                        break;
                    case "3":
                        customerSignUpMenu.Start();
                        break;
                    case "4":
                        // TODO: manager sign up menu
                        break;
                    default:
                        Console.WriteLine("Please select an option from the menu");
                        break;
                }
            } while (!userInput.Equals("0"));
        }
    }
}