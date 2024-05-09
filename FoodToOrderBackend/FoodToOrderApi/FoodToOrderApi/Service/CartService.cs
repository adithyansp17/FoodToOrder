using FoodToOrderApi.Repository;
using FoodToOrderDB;

namespace FoodToOrderApi.Service
{

    public class CartService : ICartService
    {

        //IUser = IUserRepository
        private readonly ICartRepository repo;

        public CartService(ICartRepository repo)
        {
            this.repo = repo;
        }

        public List<Cart> GetCarts()
        {
            return repo.GetCarts().ToList();
        }

        public Cart GetCartById(int id)
        {
            return repo.GetCartById(id);

        }


        public void UpdateCart(int id, Cart cart)
        {


            repo.UpdateCart(id, cart);
        }

        public void AddCart(Cart cart)
        {
            repo.InsertCart(cart);
        }

        public void DeleteCart(int id)
        {

            repo.DeleteCart(id);

        }

        public void save()
        {
            repo.save();
        }

    }
}
