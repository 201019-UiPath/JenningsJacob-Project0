using System;
using GGsDB;

namespace GGsUI.Menus
{
    public class ReplenishInventoryMenu : IMenu
    {
        private string userInput;
        private bool showMenu = true;
        public void Start()
        {
            do {
                Console.WriteLine("What kind of product are you adding?");
                Console.WriteLine("1.\tVideo Game");
                Console.WriteLine("2.\tGame Console");
                Console.WriteLine("3.\tShirt");
                Console.WriteLine("0.\tExit");

                userInput = Console.ReadLine();
                switch (userInput)
                    {
                        case "1":
                            AddVideoGame();
                            // showMenu = false;
                            break;
                        case "2":
                            showMenu = false;
                            break;
                        case "3":
                            showMenu = false;
                            break;
                        case "0":
                            showMenu = false;
                            break;
                        default:
                            break;
                    }
            } while(showMenu);
        }

        public void AddVideoGame(){
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
        }
    }
}