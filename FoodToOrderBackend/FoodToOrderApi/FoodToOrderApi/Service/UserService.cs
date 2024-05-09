using FoodToOrderApi.Repository;
using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository repo;

        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }

        public List<User> GetUser()
        {
            return repo.GetUsers().ToList();
        }

        public User GetUserById(int id)
        {
            return repo.GetUserById(id);

        }


        public void UpdateUser(int id, User user)
        {


            repo.UpdateUser(id, user);
        }

        public void AddUser(User user)
        {
            repo.InsertUser(user);
        }

        public void DeleteUser(int id)
        {

            repo.DeleteUser(id);

        }

        public void save()
        {
            repo.save();
        }
    }
}
