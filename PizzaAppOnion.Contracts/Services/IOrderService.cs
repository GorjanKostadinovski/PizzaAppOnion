using PizzaAppOnion.Contracts.ViewModels.Order;
using PizzaAppOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Contracts.Services
{
    public interface IOrderService
    {
        IReadOnlyList<OrderViewModel> GetAllOrders();

        OrderDetailsViewModel GetOrdersDetails(int id);

        Order GetOrder(int id);

        OrderDetailsViewModel EditOrder(int id, OrderDetailsViewModel order);

        void DeleteOrder(int id,OrderDetailsViewModel order);

        void CreateNew(OrderDetailsViewModel order);

    }
}
