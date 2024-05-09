using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public interface IUserService
    {
        List<User> GetUser();
        User GetUserById(int id);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
        void AddUser(User user);
        void save();
    }
}
