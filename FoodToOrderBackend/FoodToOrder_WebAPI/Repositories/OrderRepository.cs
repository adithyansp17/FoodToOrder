using FoodToOrderAppWPF;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_WebAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
            private FoodToOrderWpfPraveenContext context;

            public OrderRepository(FoodToOrderWpfPraveenContext injectedContext)
            {
                context = injectedContext;
            }
            public void DeleteOrder(int orderId)
            {


                var order = GetOrderById(orderId);
                if (order == null)
                {
                    return;
                }

                context.Orders.Remove(order);

            }

            public void Dispose()
            {
                Console.WriteLine("Dispose");
            }

            public Order GetOrderById(int orderId)
            {
                return context.Orders.Include(d => d.arrDishes).Where(o => o.id == orderId).FirstOrDefault();
            }

            public IEnumerable<Order> GetOrders()
            {
                return context.Orders.ToList();
            }

            public void InsertOrder(Order order)
            {
                context.Orders.Add(order);
            }

            public void save()
            {
                context.SaveChanges();
            }

            public void UpdateOrder(int id, Order order)
            {
                if (id != order.id)
                {
                    return;
                }

                context.Orders.Update(order);
                try
                {
                    save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(id))
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }


            }
            private bool OrderExists(int id)
            {
                return GetOrders().Any(e => e.id == id);
            }
    }
}
