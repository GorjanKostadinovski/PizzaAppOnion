using PizzaAppOnion.Contracts.ViewModels.Pizza;
using PizzaAppOnion.Domain.Entities;

namespace PizzApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToPizzaViewModel (this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                PizzaName = pizza.Name,
            };
        }

        public static PizzaListViewModel ToPizzaListViewModel(this List<Pizza> pizza)
        {
            return new  PizzaListViewModel
            {
                Pizzas = pizza.Select(x => x.ToPizzaViewModel()).ToList()
            };
        }
        public static PizzaDetailsViewModel ToPizzaDetailsViewModel(this Pizza pizza)
        {
            return new PizzaDetailsViewModel()
            {
                Id = pizza.Id,
                PizzaName = pizza.Name,
                Price = pizza.Price,
                IsOnPromotion = pizza.IsOnPromotion
            };
        }

        public static Pizza ToPizza(this PizzaDetailsViewModel pizza)
        {
            return new Pizza()
            {
                Id = pizza.Id,
                IsOnPromotion = pizza.IsOnPromotion,
                Name = pizza.PizzaName,
                Price = pizza.Price
            };
        }
    }
}
