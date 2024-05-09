using FoodToOrderDB;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FoodToOrderApi.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private FoodToOrderWpfAdithyanContext context;

        public RestaurantRepository(FoodToOrderWpfAdithyanContext context)
        {
            this.context = context;
        }

        public void DeleteRestaurant(int id)
        {
            var r = context.Restaurants.AsNoTracking().Include(d => d.dishlist).Include(a => a.arrAddress).Where(x => x.id == id).FirstOrDefault();
            context.Restaurants.Remove(r);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Disposed");
        }

        public Restaurant GetRestaurantByID(int id)
        {
            return context.Restaurants.AsNoTracking().Include(d => d.dishlist).Include(a => a.arrAddress).Where(a => a.id == id).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return context.Restaurants.Include(d=>d.dishlist).Include(a=>a.arrAddress).ToList();
        }

        public void InsertRestaurant(Restaurant restaurant)
        {
            Console.WriteLine(restaurant.rName);
            Console.WriteLine(context.Restaurants.FirstOrDefault());
            context.Restaurants.Add(restaurant);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Update(restaurant);
            try
            {
                Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(restaurant.id))
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
            return GetRestaurants().Any(e => e.id == id);
        }
    }
}
