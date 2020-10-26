using System;

namespace GGsUI.Menus
{
    public class WelcomeMenu : IMenu
    {
        public void Start()
        {
            string userInput;
            do {
                Console.WriteLine("Welcome to GGs! How can I help you today?");
                // Options
                Console.WriteLine("1.\tLogin");
                Console.WriteLine("2.\tSign Up");
                Console.WriteLine("0.\tExit");
                userInput = Console.ReadLine();
                switch(userInput) {
                    case "0":
                        Console.WriteLine("Exiting application. Have a good day!");
                        break;
                    case "1":
                        IMenu loginMenu = new LoginMenu();
                        loginMenu.Start();
                        break;
                    case "2":
                        // TODO: open sign up menu
                        break;
                    default:
                        Console.WriteLine("Please select an option from the menu");
                        break;
                }
            } while (!userInput.Equals("0"));
        }
    }
}