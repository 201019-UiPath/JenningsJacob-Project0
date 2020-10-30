using GGsDB.Models;
using GGsDB.Entities;
using System.Collections.Generic;

namespace GGsDB.Mappers
{
    public interface ICustomerMapper
    {
        Customer ParseCustomer(Customers customer);
        Customers ParseCustomer(Customer customers);
        List<Customer> ParseCustomer(List<Customers> customers);
        ICollection<Customers> ParseCustomer(ICollection<Customer> cusomers);
    }
}