using FoodToOrderDB;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderApi.Repository
{
    public class CartRepository : ICartRepository
    {
        private FoodToOrderWpfAdithyanContext context;

        public CartRepository(FoodToOrderWpfAdithyanContext injectedContext)
        {
            context = injectedContext;
        }
        public void DeleteCart(int cartId)
        {


            var cart = GetCartById(cartId);
            if (cart == null)
            {
                return;
            }

            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public Cart GetCartById(int cartId)
        {
            //return context.Carts.Include(c=>c.cartdish).ThenInclude(d=>d.dish).Include(u=>u.User).Where(c => c.id == cartId).FirstOrDefault();
            return context.Carts.AsNoTracking().Include(c => c.cartdish).Where(c => c.id == cartId).FirstOrDefault();
                
        }

        public IEnumerable<Cart> GetCarts()
        {
            return context.Carts.AsNoTracking().Include(c => c.cartdish).ToList();
        }

        public void InsertCart(Cart cart)
        {
            context.Carts.Add(cart);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdateCart(int id, Cart cart)
        {
            if (id != cart.id)
            {
                return;
            }
            var cartold = GetCartById(id);
            foreach (var c in cartold.cartdish) 
            {
                context.CartDish.Remove(c);
            }
            //context.SaveChanges();
            //context.Entry(cart).State = EntityState.Detached;
            //context.Entry(cartold).State = EntityState.Detached;
            foreach (var c in cart.cartdish)
            {
                if(c.quantity > 0)
                {
                    context.CartDish.Add(c);
                }
            }


            context.SaveChanges();

            context.Entry(cart).State = EntityState.Detached;
            context.Entry(cartold).State = EntityState.Detached;
            //    context.Entry(cart).State = EntityState.Modified;

            context.Carts.Update(cart);
            


        }
        private bool CartExists(int id)
        {
            return GetCarts().Any(e => e.id == id);
        }

    }
}


