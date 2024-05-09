using FoodToOrderDB;

namespace FoodToOrderApi.Repository
{
    public interface ICartRepository : IDisposable

    {
        IEnumerable<Cart> GetCarts();
        Cart GetCartById(int cartId);
        void InsertCart(Cart cart);
        void UpdateCart(int id, Cart cart);
        void DeleteCart(int cartId);
        void save();


    }
}
