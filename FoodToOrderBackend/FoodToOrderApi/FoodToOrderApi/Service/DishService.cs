using FoodToOrderApi.Repository;
using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public class DishService : IDishService
    {
        private readonly IDishRepository repo;

        public DishService(IDishRepository repo)
        {
            this.repo = repo;
        }
        public void AddDish(Dish dish)
        {
            repo.InsertDish(dish);
        }

        public void DeleteDish(int id)
        {
            repo.DeleteDish(id);
        }

        public Dish GetDishByID(int id)
        {
            return repo.GetDishByID(id);
        }

        public List<Dish> GetDishes()
        {
            return repo.GetDishes().ToList();
        }

        public void Save()
        {
            repo.Save();
        }

        public void UpdateDish(Dish dish)
        {
            repo.UpdateDish(dish);  
        }
    }
}
