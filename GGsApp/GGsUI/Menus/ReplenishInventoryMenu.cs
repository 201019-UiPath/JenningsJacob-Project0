using System;
using GGsDB;
using GGsDB.Models;

namespace GGsUI.Menus
{
    public class ReplenishInventoryMenu : IMenu
    {
        private string userInput;
        private bool showMenu = true;
        private IManagerRepo repo;

        public ReplenishInventoryMenu(IManagerRepo repo) {
            this.repo = repo;
        }
        public void Start()
        {
            do {
                Console.WriteLine("What kind of product are you adding?");
                Console.WriteLine("1.\tVideo Game");
                Console.WriteLine("2.\tGame Console");
                Console.WriteLine("0.\tExit");

                userInput = Console.ReadLine();
                switch (userInput)
                    {
                        case "1":
                            VideoGame newGame = AddVideoGame();
                            // repo.AddProductAsync(newGame);
                            break;
                        case "2":
                            GameConsole newGameConsole = AddGameConsole();
                            // repo = new GameConsoleRepo();
                            // repo.AddProductAsync(newGameConsole);
                            break;
                        case "0":
                            showMenu = false;
                            break;
                        default:
                            break;
                    }
            } while(showMenu);
        }

        /// <summary>
        /// Creates new video game object and takes in information from user
        /// </summary>
        /// <returns>New video games object to be passed to the repo</returns>
        public VideoGame AddVideoGame(){
            VideoGame videoGame = new VideoGame();
            Console.Write("Please enter the name of the game: ");
            videoGame.Name = Console.ReadLine();
            Console.Write("Please enter the cost of the game: ");
            videoGame.Cost = decimal.Parse(Console.ReadLine());
            Console.Write("Please enter the genre of the game: ");
            videoGame.Genre = Console.ReadLine();
            Console.Write("Please enter what platform the game is on: ");
            videoGame.Platform = Console.ReadLine();
            Console.Write("Please enter the game's ESRB rating: ");
            videoGame.ESRB = Console.ReadLine();

            return videoGame;
        }

        /// <summary>
        /// Create new game console object and takes in information from user
        /// </summary>
        /// <returns>New game object to be passed to the repo</returns>
        public GameConsole AddGameConsole(){
            GameConsole gameConsole = new GameConsole();
            Console.Write("Please enter the name of the console: ");
            gameConsole.Name = Console.ReadLine();
            Console.Write("Please enter the cost of the console: ");
            gameConsole.Cost = decimal.Parse(Console.ReadLine());
            Console.Write("How much storage does the console have (in TB): ");
            gameConsole.Cost = int.Parse(Console.ReadLine());
            string choice;
            do {
                Console.Write("Is this the digital edition? (Y/N): ");
                choice = Console.ReadLine();
           
                switch(choice) {
                case "Y":
                case "y":
                    gameConsole.IsDigitalEdition = true;
                    return gameConsole;
                case "N":
                case "n":
                    gameConsole.IsDigitalEdition = false;
                    return gameConsole;
                default:
                    Console.WriteLine("Please answer using Y/N");
                    break;
                }
            } while(!choice.Equals("Y") || !choice.Equals("N") || !choice.Equals("y") || !choice.Equals("n"));
            
            return gameConsole;
        }
    }
}