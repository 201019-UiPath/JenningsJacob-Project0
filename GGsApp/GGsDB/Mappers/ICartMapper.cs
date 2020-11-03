using GGsDB.Entities;
using GGsDB.Models;
using System.Collections.Generic;

namespace GGsDB.Mappers
{
    public interface ICartMapper
    {
        Cart ParseCart(Carts cart);
        Carts ParseCart(Cart cart); 
        List<Cart> ParseCart(ICollection<Carts> carts);
        ICollection<Carts> ParseCart(List<Cart> carts); 
    }
}