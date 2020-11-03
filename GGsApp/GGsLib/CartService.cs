using GGsDB.Models;
using GGsDB.Repos;
namespace GGsLib
{
    public class CartService
    {
        private ICartRepo repo;
        public CartService(ICartRepo repo)
        {
            this.repo = repo;
        }
        public void AddCart(Cart cart)
        {
            repo.AddCart(cart);
        }
        public void DeleteCart(Cart cart)
        {
            repo.DeleteCart(cart);
        }
        public Cart GetCartById(int id)
        {
            return repo.GetCartById(id);
        }
        public Cart GetCartByUserId(int id)
        {
            return repo.GetCartByUserId(id);
        }
        public void UpdateCart(Cart cart)
        {
            repo.UpdateCart(cart);
        }
    }
}