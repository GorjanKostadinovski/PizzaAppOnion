
using PizzaAppOnion.Contracts.ViewModels.Pizza;

namespace PizzaAppOnion.Contracts.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }

        public decimal Price { get; set; }

        public bool IsDelivered { get; set; }

    }
}
