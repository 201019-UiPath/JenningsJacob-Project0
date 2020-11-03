namespace GGsDB.Models
{
    public class CartItem
    {
        public int id {get; set;}
        public int cartId {get; set;}
        public Cart cart {get; set;}
        public int videoGameId {get; set;}
        public VideoGame videoGame {get; set;}
        public int quantity {get; set;}
    }
}