using FoodToOrderDB;

namespace FoodToOrderApi.Repository
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
