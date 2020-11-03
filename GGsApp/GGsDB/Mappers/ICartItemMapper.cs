using GGsDB.Entities;
using GGsDB.Models;
using System.Collections.Generic;

namespace GGsDB.Mappers
{
    public interface ICartItemMapper
    {
        CartItem ParseCartItem(Cartitems item);
        Cartitems ParseCartItem(CartItem item);
        List<CartItem> ParseCartItem(ICollection<Cartitems> item);
        ICollection<Cartitems> ParseCartItem(List<CartItem> item);
    }
}