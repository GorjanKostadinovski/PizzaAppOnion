using PizzaAppOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Domain.Repositories
{
    public interface IOrderRepository
    {
        IReadOnlyList<Order> GetAllOrders();

        void GetAllOrdersToChange(int id,Order order );

        Order GetOrdersById(int id);

        void Insert(Order order);
    }
}
