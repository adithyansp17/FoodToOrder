using FoodToOrderDB;

namespace FoodToOrderApi.Service
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
