namespace GGsDB
{
    public class Location
    {
        public string Street{get; set;}
        public string City{get; set;}
        public string State{get; set;}
        public int ZipCode{get; set;}
        public void PrintFullAddress(){
            System.Console.WriteLine($"{Street}, {City}, {State}, {ZipCode}");
        }
    }
}