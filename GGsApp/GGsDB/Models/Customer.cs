using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Customer : Person
    {
        public Location HomeAddress{get; set;}
        public Order Order {get; set;}
    }
}