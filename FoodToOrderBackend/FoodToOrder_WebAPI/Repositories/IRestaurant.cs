using FoodToOrderAppWPF;

namespace FoodToOrder_WebAPI.Repositories
{
    public interface IRestaurant : IDisposable
    {
            IEnumerable<Restaurant> GetRestaurants();
            Restaurant GetRestaurantById(int restId);
            void InsertRestaurant(Restaurant restaurant);
            void UpdateRestaurant(int id, Restaurant restaurant);
            void DeleteRestaurant(int restId);
            void save();


    }
}
