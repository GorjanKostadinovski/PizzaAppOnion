using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public int PizzaId { get; set; }

        public bool IsDelivered { get; set; }

        public  decimal CalculateTotalPrice()
        {
            return Pizzas?.Sum(x => x.Price) ?? 10;
        }

        public Order()
        {
            Pizzas = new List<Pizza>();
        }

    }
}
