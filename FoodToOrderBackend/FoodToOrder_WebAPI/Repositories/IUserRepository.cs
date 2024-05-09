using FoodToOrderAppWPF;

namespace FoodToOrder_WebAPI.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        void InsertUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int userId);
        void save();

    }
}
