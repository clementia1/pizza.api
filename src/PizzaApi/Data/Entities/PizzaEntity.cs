namespace PizzaApi.Data.Entities
{
    public class PizzaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public double Weight { get; set; }
    }
}