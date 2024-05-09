using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public interface IDishService
    {
        List<Dish> GetDishes();
        Dish GetDishByID(int id);
        void AddDish(Dish dish);
        void DeleteDish(int id);
        void UpdateDish(Dish dish);
        void Save();
    }
}
