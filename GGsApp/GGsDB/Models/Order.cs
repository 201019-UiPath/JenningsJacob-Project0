using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }
        public int Id {get; set;}
        public int? CustomerId {get; set;}
        public Customer Customer {get; set;}
        public List<Product> Products {get; set;}
    }
}