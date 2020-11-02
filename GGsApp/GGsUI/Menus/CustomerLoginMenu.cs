using System;
using GGsDB;
using GGsDB.Models;
using GGsLib;

namespace GGsUI.Menus
{
    public class CustomerLoginMenu : IMenu
    {
        private string email;
        private readonly ICustomerRepo repo;
        private readonly CustomerService customerService;
        private readonly CustomerMainMenu mainMenu;

        public CustomerLoginMenu(ICustomerRepo repo)
        {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.mainMenu = new CustomerMainMenu(repo);
        }
        public void Start()
        {
            Customer customer = new Customer();
            Console.Write("Please enter your email: ");
            email = Console.ReadLine();
            customer = customerService.GetCustomerByEmail(email);
            Console.WriteLine($"Welcome back {customer.FirstName}");
            mainMenu.Start();
        }
    }
}