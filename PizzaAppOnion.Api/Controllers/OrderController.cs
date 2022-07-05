using Microsoft.AspNetCore.Mvc;
using PizzaAppOnion.Contracts.Services;
using PizzaAppOnion.Contracts.ViewModels.Order;
using PizzaAppOnion.Domain.Entities;
using PizzApp.Models.Mappers;

namespace PizzApp.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IPizzaService _pizzaService;

        public OrderController(IOrderService orderService,IPizzaService pizzaService)
        {
            _orderService = orderService;
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {

            IEnumerable<OrderViewModel> orderListViewModel = _orderService.GetAllOrders();
            return View(orderListViewModel);
            
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Pizzas = _orderService.GetOrder(id).Pizzas;
            OrderDetailsViewModel orderDetailsviewModel = _orderService.GetOrdersDetails(id);

            return View(orderDetailsviewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           OrderDetailsViewModel order = _orderService.GetOrdersDetails(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(int id , OrderDetailsViewModel order)
        {

            _orderService.EditOrder(id, order);
            
            return View(order);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            OrderDetailsViewModel orderDelete = _orderService.GetOrdersDetails(id);
            if (orderDelete == null)
            {
                return NotFound();
            }
            return View(orderDelete);

        }

        [HttpPost]

        public IActionResult Delete(int id, OrderDetailsViewModel order)
        {
            _orderService.DeleteOrder(id,order);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            ViewBag.Pizzas = _pizzaService.GetAllPizzas();
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder( OrderDetailsViewModel order)
        {

            _orderService.CreateNew(order);
            return RedirectToAction("Index");
                
        }

        

    }
}
