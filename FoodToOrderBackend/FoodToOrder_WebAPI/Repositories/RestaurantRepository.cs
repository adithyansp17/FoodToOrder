using FoodToOrderAppWPF;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_WebAPI.Repositories
{
    public class RestaurantRepository : IRestaurant
    {
        private FoodToOrderWpfPraveenContext context;

        public RestaurantRepository(FoodToOrderWpfPraveenContext injectedContext)
        {
            context = injectedContext;
        }
        public void DeleteRestaurant(int restId)
        {


            var restaurant = GetRestaurantById(restId);
            if (restaurant == null)
            {
                return;
            }

            context.Restaurants.Remove(restaurant);

        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public Restaurant GetRestaurantById(int restId)
        {
            return context.Restaurants.Where(r => r.Id == restId).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return context.Restaurants.ToList();
        }

        public void InsertRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return;
            }

            context.Restaurants.Update(restaurant);
            try
            {
                save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }


        }
        private bool RestaurantExists(int id)
        {
            return GetRestaurants().Any(e => e.Id == id);
        }
    }
}
