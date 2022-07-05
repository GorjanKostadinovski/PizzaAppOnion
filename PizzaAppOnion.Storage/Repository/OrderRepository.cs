

using PizzaAppOnion.Domain.Entities;
using PizzaAppOnion.Domain.Repositories;
using PizzaAppOnion.Storage.Database;

namespace PizzaAppOnion.Storage.Repository
{
    public class OrderRepository : IOrderRepository
    {
        
        public IReadOnlyList<Order> GetAllOrders()
        {
            return OrderDatabase.ORDERS;
        }

        public Order GetOrdersById(int id)
        {
            return OrderDatabase.ORDERS.FirstOrDefault(x =>x.Id == id);
        }

        public void GetAllOrdersToChange( int id,Order order )
        {
            order = OrderDatabase.ORDERS.FirstOrDefault(x => x.Id == id);
            OrderDatabase.ORDERS.Remove(order);
        }

        public void Insert (Order order)
        {
            
            order.Id = OrderDatabase.GetNextPizzaId();
            
            OrderDatabase.ORDERS.Add(order);
        }
        
    }
}
