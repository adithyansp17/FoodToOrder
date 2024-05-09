using FoodToOrderDB;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FoodToOrderApi.Repository
{
    public class DishRepository : IDishRepository
    {

        private readonly FoodToOrderWpfAdithyanContext context;

        public DishRepository(FoodToOrderWpfAdithyanContext context)
        {
            this.context = context;
        }
        public void DeleteDish(int id)
        {
            var r = context.Dishes.AsNoTracking().Where(x => x.id == id).FirstOrDefault();
            context.Dishes.Remove(r);
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        public Dish GetDishByID(int id)
        {
            return context.Dishes.AsNoTracking().Where(a => a.id == id).FirstOrDefault();
        }

        public IEnumerable<Dish> GetDishes()
        {
            return context.Dishes.ToList();
        }

        public void InsertDish(Dish dish)
        {
            context.Dishes.Add(dish);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateDish(Dish dish)
        {
            context.Dishes.Update(dish);
        }
    }
}
