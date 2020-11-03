using System.Collections.Generic;
using GGsDB.Models;

namespace GGsDB.Repos
{
    public interface ICartItemRepo
    {
        void AddCartItem(CartItem item);
        void UpdateCartItem(CartItem item);
        CartItem GetCartItemById(int id);
        List<CartItem> GetAllCartItems(int id);
        void DeleteCartItem(CartItem item);
    }
}