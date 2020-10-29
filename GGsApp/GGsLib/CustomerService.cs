using GGsDB;
using GGsDB.Models;

namespace GGsLib
{
    public class CustomerService
    {
        private ICustomerRepo repo;
        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }
        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = repo.GetCustomerByEmail(email);
            return customer;
        }
    }
}