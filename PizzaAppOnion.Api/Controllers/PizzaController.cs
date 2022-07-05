using Microsoft.AspNetCore.Mvc;
using PizzaAppOnion.Contracts.Services;
using PizzaAppOnion.Contracts.ViewModels.Pizza;
using PizzaAppOnion.Contracts.ViewModels.Shared;
using PizzaAppOnion.Domain.Entities;
using PizzApp.Models.Mappers;
using System.Diagnostics;


namespace PizzApp.Controllers
{
   
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            IEnumerable<PizzaViewModel> pizzaListViewModel = _pizzaService.GetAllPizzas();

            return View(pizzaListViewModel);

        }
        
        public IActionResult Details(int id)
        {
            PizzaDetailsViewModel pizzaDetailsviewModel = _pizzaService.GetPizzaDetails(id);

            if (pizzaDetailsviewModel is null)
            {
                return RedirectToAction("Error");
            }

            return View(pizzaDetailsviewModel);
        }

               [HttpGet]
        public IActionResult CreatePizza()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePizza(PizzaDetailsViewModel pizza)
        {
            _pizzaService.CreateNew(pizza);
            return View(pizza);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PizzaDetailsViewModel pizza = _pizzaService.GetPizzaDetails(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        [HttpPost]
        public IActionResult Edit(int id, PizzaDetailsViewModel pizza)
        {
            
            _pizzaService.EditPizza(id, pizza);
            return View(pizza);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            PizzaDetailsViewModel pizzaDelete = _pizzaService.GetPizzaDetails(id);

            if (pizzaDelete == null)
            {
                return NotFound();
            }

            return View(pizzaDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id,PizzaDetailsViewModel pizza)
        {
            
            _pizzaService.GetAllPizzaToDelete(id,pizza);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
