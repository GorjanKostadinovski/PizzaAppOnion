using PizzaAppOnion.Contracts.ViewModels.Pizza;
using PizzaAppOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Contracts.Services
{
    public interface IPizzaService
    {
        IReadOnlyList<PizzaViewModel> GetAllPizzas();

        PizzaDetailsViewModel GetPizzaDetails(int id);

        Pizza GetPizza(int id);

        PizzaDetailsViewModel EditPizza(int id, PizzaDetailsViewModel pizza);

        void GetAllPizzaToDelete(int id,PizzaDetailsViewModel pizza);

        void CreateNew(PizzaDetailsViewModel pizza);
    }
}
