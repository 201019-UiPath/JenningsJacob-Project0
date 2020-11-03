using GGsDB.Repos;
using GGsDB.Models;
using System.Collections.Generic;

namespace GGsLib
{
    public class CartItemService
    {
        private ICartItemRepo repo;
        public CartItemService(ICartItemRepo repo)
        {
            this.repo = repo;
        }
        public void AddCartItem(CartItem item)
        {
            repo.AddCartItem(item);
        }
        public void DeleteCartItem(CartItem item)
        {
            repo.DeleteCartItem(item);
        }
        public List<CartItem> GetAllCartItems(int id)
        {
            return repo.GetAllCartItems(id);
        }
        public CartItem GetCartItemById(int id)
        {
            return repo.GetCartItemById(id);
        }
        public void UpdateCartItem(CartItem item)
        {
            repo.UpdateCartItem(item);
        }
        
    }
}