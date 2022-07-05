using PizzaAppOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppOnion.Domain.Repositories
{
    public interface IPizzaRepository
    {
        IReadOnlyList<Pizza> GetAllPizzas();

        void GetAllPizzasToChange(int id,Pizza pizza);

        Pizza GetPizzaById(int id);

        void Insert(Pizza pizza);
    }
}
