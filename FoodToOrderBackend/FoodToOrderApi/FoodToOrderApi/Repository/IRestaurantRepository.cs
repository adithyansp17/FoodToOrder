using FoodToOrderDB;
using System.Net;

namespace FoodToOrderApi.Repository
{
    public interface IRestaurantRepository :IDisposable
    {
        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurantByID(int id);
        void InsertRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);
        void Save();
    }
}
