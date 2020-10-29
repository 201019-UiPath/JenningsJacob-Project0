using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Customer : Person
    {
        public int LocationId{get; set;}
        public Location HomeAddress{get; set;}
        public Order Order {get; set;}
    }
}