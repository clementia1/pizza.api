namespace PizzaApi.Models
{
    public class AddPizzaRequest
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public double Weight { get; set; }
    }
}