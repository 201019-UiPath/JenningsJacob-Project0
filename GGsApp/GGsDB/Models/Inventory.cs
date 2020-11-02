using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Products = new List<Product>();
        }
        public int Id {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public List<Product> Products {get; set;}
    }
}