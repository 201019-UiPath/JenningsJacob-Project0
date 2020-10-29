using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Inventory
    {
        public int Id {get; set;}
        public int LocaitonId {get; set;}
        public int GameConsoleId{get; set;}
        public int VideoGameId{get; set;}
        public Location StoreLocaton {get; set;}
        public List<Product> Products {get; set;}
    }
}