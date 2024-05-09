using FoodToOrderAppWPF;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FoodToOrderWpfPraveenContext context;

        public UserRepository(FoodToOrderWpfPraveenContext injectedContext)
        {
            context = injectedContext;
        }
        public void DeleteUser(int userId)
        {


            var user = GetUserById(userId);
            if (user == null)
            {
                return;
            }

            context.Users.Remove(user);

        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public User GetUserById(int userId)
        {
            return context.Users.Where(u => u.id == userId).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdateUser(int id, User user)
        {
            if (id != user.id)
            {
                return;
            }

            context.Users.Update(user);
            try
            {
                save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }


        }
        private bool UserExists(int id)
        {
            return GetUsers().Any(e => e.id == id);
        }
    }
}
