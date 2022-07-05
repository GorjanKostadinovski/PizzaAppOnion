using PizzaAppOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Storage.Database
{
    public static class PizzaDatabase
    {
        public static List<Pizza> PIZZAS = new List<Pizza>()
        {

            new Pizza() { Id = 1, Name = "Margherita", Price = 10m, IsOnPromotion = false },
            new Pizza() { Id = 2, Name = "Quatro Formagio", Price = 20m, IsOnPromotion = true },
            new Pizza() { Id = 3, Name = "Pepperoni", Price = 15m, IsOnPromotion = true }
        };

        public static int GetNextPizzaId()
        {
            return (PIZZAS.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
        }
    }
}
