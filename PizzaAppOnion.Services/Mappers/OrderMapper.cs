using PizzaAppOnion.Contracts.ViewModels.Order;
using PizzaAppOnion.Domain.Entities;

namespace PizzApp.Models.Mappers
{
    public static class OrderMapper
    { 
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                TotalPrice = order.CalculateTotalPrice(),
                
                
            };       
        }

        public static OrderListViewModel ToOrderListViewModel(this List<Order> orders)
        {
            return new OrderListViewModel
            {
                Orders = orders.Select(x => x.ToOrderViewModel()).ToList()
            };
        }

        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel()
            {
                Id = order.Id,
                Price = order.CalculateTotalPrice(),
                IsDelivered = order.IsDelivered,
                
            };

        }
        public static Order ToOrder(this OrderDetailsViewModel order)
        {
            return new Order()
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                
            };
        }
    }
}
