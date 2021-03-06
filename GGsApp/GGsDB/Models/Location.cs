using System.Collections.Generic;
namespace GGsDB.Models
{
    public class Location
    {
        public int id {get; set;}
        public string street {get; set;}
        public string city {get; set;}
        public string state {get; set;}
        public string zipCode {get; set;}
        public List<InventoryItem> inventory {get; set;}
    }
}