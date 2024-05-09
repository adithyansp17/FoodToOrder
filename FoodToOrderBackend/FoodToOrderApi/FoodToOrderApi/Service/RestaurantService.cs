using FoodToOrderApi.Repository;
using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository repo;

        public RestaurantService(IRestaurantRepository repo)
        {
            this.repo = repo;
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            repo.InsertRestaurant(restaurant);
        }

        public void DeleteRestaurant(int id)
        {
            repo.DeleteRestaurant(id);
        }

        public Restaurant GetRestaurantByID(int id)
        {
            var rest = repo.GetRestaurantByID(id);
            return rest;
        }

        public List<Restaurant> GetRestaurants()
        {
            return repo.GetRestaurants().ToList();
        }

        public void Save()
        {
            repo.Save();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            repo.UpdateRestaurant(restaurant);
        }
    }
}
