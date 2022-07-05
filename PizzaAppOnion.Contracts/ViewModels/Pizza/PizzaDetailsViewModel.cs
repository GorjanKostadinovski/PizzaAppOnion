namespace PizzaAppOnion.Contracts.ViewModels.Pizza
{
    public class PizzaDetailsViewModel
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }
    }
}
