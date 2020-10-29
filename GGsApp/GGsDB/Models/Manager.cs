namespace GGsDB.Models
{
    public class Manager : Person
    {
        public int LocationId{get; set;}
        public Location StoreAddress{get; set;}
    }
}