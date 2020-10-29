using GGsDB.Models;

namespace GGsDB
{
    public interface ICustomerRepo
    {
        Customer GetCustomerByEmail(string email);
        void AddCustomerAsync(Customer customer);
    }
}