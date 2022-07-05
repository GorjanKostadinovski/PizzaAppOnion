using PizzaAppOnion.Contracts.Services;
using PizzaAppOnion.Contracts.ViewModels.Order;
using PizzaAppOnion.Domain.Entities;
using PizzaAppOnion.Domain.Repositories;
using PizzApp.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Services
{
    public class OrderService :IOrderService
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IPizzaRepository _pizzaRepository;

        public OrderService(IOrderRepository orderRepository,IPizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }
        

        public IReadOnlyList<OrderViewModel> GetAllOrders()
        {
            IReadOnlyList<Order> dbOrder = _orderRepository.GetAllOrders();
            return dbOrder.Select(x => x.ToOrderViewModel()).ToArray();
        }

        public void  DeleteOrder(int id,OrderDetailsViewModel order)
        {
            
            _orderRepository.GetAllOrdersToChange(id,order.ToOrder());
        }

        public OrderDetailsViewModel GetOrdersDetails(int id)
        {
            Order dbOrders = _orderRepository.GetOrdersById(id);
            return dbOrders.ToOrderDetailsViewModel();
        }

        public Order  GetOrder(int id)
        {
            Order dbOrders = _orderRepository.GetOrdersById(id);
            return dbOrders;
        }

        public OrderDetailsViewModel EditOrder(int id  , OrderDetailsViewModel order)
        {
            Order dbOrders = _orderRepository.GetOrdersById(id);
            dbOrders.IsDelivered = order.IsDelivered;
            return dbOrders.ToOrderDetailsViewModel();
        }

        public void  CreateNew(OrderDetailsViewModel order)
        {
            Pizza pizza = _pizzaRepository.GetPizzaById(order.PizzaId);
            Order orderToInsert = new Order()
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                PizzaId = order.PizzaId,
                Pizzas = new List<Pizza>() { pizza },
            };
           


            _orderRepository.Insert(orderToInsert);
        }

        



    }
}
