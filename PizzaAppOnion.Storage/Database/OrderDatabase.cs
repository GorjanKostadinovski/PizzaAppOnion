using PizzaAppOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Storage.Database
{
    public static class OrderDatabase
    {
        public static List<Order> ORDERS = new List<Order>()
        {
            new Order(){Id = 1 , Pizzas = new List<Pizza>(){ PizzaDatabase.PIZZAS[0],PizzaDatabase.PIZZAS[1] },  IsDelivered = true},
            new Order(){Id = 2 , Pizzas = new List<Pizza>(){ PizzaDatabase.PIZZAS[1],PizzaDatabase.PIZZAS[2] },  IsDelivered = false},
            new Order(){Id = 3 , Pizzas = new List<Pizza>(){ PizzaDatabase.PIZZAS[2],PizzaDatabase.PIZZAS[2] },  IsDelivered = false},
            new Order(){Id = 4 , Pizzas = new List<Pizza>(){ PizzaDatabase.PIZZAS[2],PizzaDatabase.PIZZAS[1] },  IsDelivered = true},
            new Order(){Id = 5 , Pizzas = new List<Pizza>(){ PizzaDatabase.PIZZAS[0],PizzaDatabase.PIZZAS[0] },  IsDelivered = true}
        };

        public static int GetNextPizzaId()
        {
            return (ORDERS.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
        }
    }
}
