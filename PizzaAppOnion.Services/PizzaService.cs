using PizzaAppOnion.Contracts.Services;
using PizzaAppOnion.Contracts.ViewModels.Pizza;
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
    public class PizzaService : IPizzaService
    {
        public readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IReadOnlyList<PizzaViewModel> GetAllPizzas()
        {
            IReadOnlyList<Pizza> dbPizzas = _pizzaRepository.GetAllPizzas();

            return dbPizzas.Select(x => x.ToPizzaViewModel()).ToArray();
        }

        public void GetAllPizzaToDelete(int id,PizzaDetailsViewModel pizza)
        {

            _pizzaRepository.GetAllPizzasToChange(id,pizza.ToPizza());
        }

        public PizzaDetailsViewModel GetPizzaDetails(int id)
        {
            Pizza dbPizzas = _pizzaRepository.GetPizzaById(id);
            return dbPizzas.ToPizzaDetailsViewModel();
        }

        public Pizza GetPizza(int id)
        {
            Pizza dbPizza = _pizzaRepository.GetPizzaById(id);
            return dbPizza;
        }

        public PizzaDetailsViewModel EditPizza(int id, PizzaDetailsViewModel pizza)
        {
            Pizza dbPizzas = _pizzaRepository.GetPizzaById(id);
            dbPizzas.IsOnPromotion = pizza.IsOnPromotion;
            dbPizzas.Name = pizza.PizzaName;
            dbPizzas.Price = pizza.Price;
            return dbPizzas.ToPizzaDetailsViewModel();
        }

        public void CreateNew(PizzaDetailsViewModel pizza)
        {
            _pizzaRepository.Insert(pizza.ToPizza());
        }
    }
}
