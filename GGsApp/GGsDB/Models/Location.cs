using System.Collections.Generic;

namespace GGsDB.Models
{
    public class Location
    {
        public int Id {get; set;}
        public string Street{get; set;}
        public string City{get; set;}
        public string State{get; set;}
        public int ZipCode{get; set;}
        public List<Customer> Customers {get; set;}
        public void PrintFullAddress(){
            System.Console.WriteLine($"{Street}, {City}, {State}, {ZipCode}");
        }
    }
}