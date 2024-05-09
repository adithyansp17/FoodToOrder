using FoodToOrderDB;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private FoodToOrderWpfAdithyanContext context;

        public UserRepository(FoodToOrderWpfAdithyanContext injectedContext)
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
            return context.Users.AsNoTracking().Include(a=>a.Address).Include(c=>c.Cart).Include(o=>o.Orders).Where(u => u.id == userId).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.AsNoTracking().Include(a => a.Address).Include(c => c.Cart).Include(o => o.Orders).ToList();
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
            if (user.Orders is null)
            {
                user.Orders = [];
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
