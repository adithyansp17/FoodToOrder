using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public interface IRestaurantService
    {
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurantByID(int id);
        void AddRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);
        void UpdateRestaurant(Restaurant restaurant);
        void Save();
    }
}
