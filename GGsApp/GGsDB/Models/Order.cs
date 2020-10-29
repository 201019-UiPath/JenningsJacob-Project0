using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Order
    {
        public int Id {get; set;}
        public int GameConsoleId {get; set;}
        public int VideoGameId {get; set;}
        public List<Product> Items {get; set;}
        public int LocationId {get; set;}
        public Location StoreAddress {get; set;}
        
    }
}