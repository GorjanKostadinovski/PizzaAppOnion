using PizzaAppOnion.Domain.Entities;
using PizzaAppOnion.Domain.Repositories;
using PizzaAppOnion.Storage.Database;
using PizzApp.Models.Mappers;

namespace PizzaAppOnion.Storage.Repository
{
    public class PizzaRepository :IPizzaRepository
    {
        public IReadOnlyList<Pizza> GetAllPizzas()
        {
            return PizzaDatabase.PIZZAS;
        }

        public Pizza GetPizzaById(int id)
        {
            return PizzaDatabase.PIZZAS.FirstOrDefault(x => x.Id == id);
        }

        public void GetAllPizzasToChange(int id,Pizza pizza)
        {
            pizza = PizzaDatabase.PIZZAS.FirstOrDefault(x => x.Id == id);
            PizzaDatabase.PIZZAS.Remove(pizza);
        }

        public void Insert(Pizza pizza)
        {
            pizza.Id = PizzaDatabase.GetNextPizzaId();
            PizzaDatabase.PIZZAS.Add(pizza);
        }
    }
}
