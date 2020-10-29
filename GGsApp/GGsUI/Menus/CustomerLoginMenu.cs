using System;
using GGsDB;
using GGsLib;

namespace GGsUI.Menus
{
    public class CustomerLoginMenu : IMenu
    {
        private string userInput;
        private string email;
        private ICustomerRepo repo;
        private CustomerService customerService;

        public CustomerLoginMenu(ICustomerRepo repo)
        {
            this.repo = repo;
        }
        public void Start()
        {
            Console.Write("Please enter your email: ");
            email = Console.ReadLine();
            try{
                customerService.GetCustomerByEmail(email);
            } catch(NullReferenceException e) {
                Console.WriteLine("This email is incorrect, please try again");
            }
            

        }
    }
}