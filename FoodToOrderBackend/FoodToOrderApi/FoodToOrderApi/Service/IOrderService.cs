using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order GetOrderById(int id);
        void UpdateOrder(int id, Order order);
        void DeleteOrder(int id);
        void AddOrder(Order order);
        void save();
    }
}
