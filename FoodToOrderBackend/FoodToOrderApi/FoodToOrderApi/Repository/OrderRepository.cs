using FoodToOrderDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace FoodToOrderApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private FoodToOrderWpfAdithyanContext context;

        public OrderRepository(FoodToOrderWpfAdithyanContext injectedContext)
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
            return context.Orders.AsNoTracking().Where(o => o.id == orderId).Include(od => od.orderdish).ThenInclude(d => d.dish).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.AsNoTracking().Include(od => od.orderdish).ThenInclude(d => d.dish).ToList();
        }

        public void InsertOrder(Order order)
        {
            foreach(var o in order.orderdish)
            {
                o.dish = null;
            }
            context.Orders.Add(order);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdateOrder(int id, Order order)
        {

            var tempOrder = context.Orders.Include(od => od.orderdish)
                                          .AsNoTracking()
                                          .Where(o => o.id == id)
                                          .FirstOrDefault();

            foreach (var o in tempOrder.orderdish)
            {
                o.order = null;
            }
            foreach (var odish in order.orderdish)
            {
                odish.dish = null;
            }


            foreach (var odish in order.orderdish)
            {
               
                bool check = tempOrder.orderdish.Where(od => (od.d_id == odish.d_id)).IsNullOrEmpty();
                if (check)
                {
                    context.OrderDish.Add(odish);
                }
            }

            context.Entry(order).State = EntityState.Detached;
            context.Entry(tempOrder).State = EntityState.Detached;

            foreach (var odish in tempOrder.orderdish)
            {
                bool check = order.orderdish.Where(od => (od.d_id == odish.d_id)).IsNullOrEmpty();
                if (check)
                {
                    context.OrderDish.Remove(odish);

                }
            }
            
            context.Entry(order).State = EntityState.Detached;
            context.Entry(tempOrder).State = EntityState.Detached;


            context.Orders.Update(order);
            save();

        }
        private bool OrderExists(int id)
        {
            return GetOrders().Any(e => e.id == id);
        }
    }
}
