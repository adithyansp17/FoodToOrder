using FoodToOrderAppWPF;

namespace FoodToOrder_WebAPI.Services
{
    public interface ICartService
    {
            List<Cart> GetCarts();
            Cart GetCartById(int id);
            void UpdateCart(int id, Cart cart);
            void DeleteCart(int id);
            void AddCart(Cart cart);
            void save();
    }
}
