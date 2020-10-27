using System.Collections.Generic;

namespace GGsDB
{
    public class Customer : Person
    {
        public Location HomeAddress{get; set;}
        public List<Product> Products{get; set;}
    }
}