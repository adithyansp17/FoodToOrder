using FoodToOrderAppWPF;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_WebAPI.Repositories
{
    public class CartRepository : ICartRepository
    {
            private FoodToOrderWpfPraveenContext context;

            public CartRepository(FoodToOrderWpfPraveenContext injectedContext)
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

            }

            public void Dispose()
            {
                Console.WriteLine("Dispose");
            }

            public Cart GetCartById(int cartId)
            {
                return context.Carts.Include(d=>d.arrDishes).Where(c => c.id == cartId).FirstOrDefault();
            }

            public IEnumerable<Cart> GetCarts()
            {
                return context.Carts.ToList();
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

                context.Carts.Update(cart);
                try
                {
                    save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(id))
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }


            }
            private bool CartExists(int id)
            {
                return GetCarts().Any(e => e.id == id);
            }
        
    }
}
