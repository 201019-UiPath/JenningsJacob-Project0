using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Customer : Person
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public int? LocationId {get; set;}
        public Location Location {get; set;}
        public List<Order> Orders {get; set;}
    }
}