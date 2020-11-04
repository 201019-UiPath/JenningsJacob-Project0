using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using System;

namespace GGsUI.Menus
{
    public class CustomerMenu : IMenu
    {
        private string userInput;
        private User user;
        private GGsContext context;
        private DBMapper mapper;
        private ProductMenu productsMenu;
        private OrderHistoryMenu orderHistoryMenu;
        private ChangeLocationMenu changeLocationMenu;
        private CartMenu cartMenu;
        public CustomerMenu(ref User user, ref GGsContext context, DBMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.user = user;

            this.orderHistoryMenu = new OrderHistoryMenu(ref user, ref context);
            this.changeLocationMenu = new ChangeLocationMenu(ref user, ref context, mapper);
            this.productsMenu = new ProductMenu(ref user, ref context, mapper);
            this.cartMenu = new CartMenu(ref user, ref context, mapper);
        }
        public void Start()
        {
            Console.WriteLine($"\nWelcome back {user.name}. What would you like to do?");
            do {
                Console.WriteLine("\n1. View Video Games");
                Console.WriteLine("2. View Order History");
                Console.WriteLine("3. Change Location");
                Console.WriteLine("4. View Cart");
                Console.WriteLine("0. Exit");

                userInput = Console.ReadLine();

                switch(userInput) {
                    case "1":
                        productsMenu.Start();
                        break;
                    case "2":
                        orderHistoryMenu.Start();
                        break;
                    case "3":
                        changeLocationMenu.Start();
                        break;
                    case "4":
                        cartMenu.Start();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            } while(!userInput.Equals("0"));
        }
    }
}