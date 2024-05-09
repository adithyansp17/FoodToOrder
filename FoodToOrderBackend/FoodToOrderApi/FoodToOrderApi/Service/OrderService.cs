using FoodToOrderApi.Repository;
using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository repo;

        public OrderService(IOrderRepository repo)
        {
            this.repo = repo;
        }

        public List<Order> GetOrders()
        {
            return repo.GetOrders().ToList();
        }

        public Order GetOrderById(int id)
        {
            return repo.GetOrderById(id);

        }


        public void UpdateOrder(int id, Order order)
        {


            repo.UpdateOrder(id, order);
        }

        public void AddOrder(Order order)
        {
            repo.InsertOrder(order);
        }

        public void DeleteOrder(int id)
        {

            repo.DeleteOrder(id);

        }

        public void save()
        {
            repo.save();
        }

    }
}
