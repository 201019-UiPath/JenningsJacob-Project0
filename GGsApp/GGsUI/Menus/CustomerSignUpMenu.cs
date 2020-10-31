using System;
using GGsDB;
using GGsDB.Models;
using GGsLib;

namespace GGsUI.Menus
{
    public class CustomerSignUpMenu : IMenu
    {
        private string userInput;
        private ICustomerRepo repo;
        private CustomerService customerService;
        private CustomerMainMenu mainMenu;
        public CustomerSignUpMenu(ICustomerRepo repo)
        {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.mainMenu = new CustomerMainMenu(repo);
        }
        public void Start()
        {
            Console.WriteLine("Thank you for signing up, please fill in the following information");
            Customer newCustomer = GetCustomerInfo();
            customerService.AddCustomer(newCustomer);
        }

        public Customer GetCustomerInfo()
        {
            Customer customer = new Customer();
            Console.Write("Enter your first name:\t");
            customer.FirstName = Console.ReadLine();
            Console.Write("Enter your last name:\t");
            customer.LastName = Console.ReadLine();
            Console.Write("Enter your email:\t");
            // TODO: input validation on email
            customer.Email = Console.ReadLine();
            Console.Write("Enter your age:\t\t");
            customer.Age = Int32.Parse(Console.ReadLine());
            customer.Location = GetLocationInfo();
            
            return customer;
        }

        public Location GetLocationInfo()
        {
            Location location = new Location();
            Console.Write("Enter your street address:\t");
            location.Street = Console.ReadLine();
            Console.Write("Enter your city:\t");
            location.City = Console.ReadLine();
            Console.Write("Enter your state acronym (e.g. CA):\t");
            location.State = Console.ReadLine();
            Console.Write("Enter your zip code:\t\t");
            location.ZipCode = Int32.Parse(Console.ReadLine());

            return location;
        }
    }
}