using System.Collections.Generic;
namespace GGsDB.Models
{
    public class Cart
    {
        public int id {get; set;}
        public int userId {get; set;}
        public User user {get; set;}
        public List<CartItem> cartItems{get; set;}

    }
}