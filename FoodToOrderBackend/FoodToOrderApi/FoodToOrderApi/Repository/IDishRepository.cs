using FoodToOrderDB;

namespace FoodToOrderApi.Repository
{
    public interface IDishRepository : IDisposable
    {
        IEnumerable<Dish> GetDishes();
        Dish GetDishByID(int id);
        void InsertDish(Dish dish);
        void UpdateDish(Dish dish);
        void DeleteDish(int id);
        void Save();
    }
}
