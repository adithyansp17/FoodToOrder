using FoodToOrderAppWPF;

namespace FoodToOrder_WebAPI.Repositories
{
    public interface IOrderRepository
    {
            IEnumerable<Order> GetOrders();
            Order GetOrderById(int orderId);
            void InsertOrder(Order order);
            void UpdateOrder(int id, Order order);
            void DeleteOrder(int orderId);
            void save();

    }
}
