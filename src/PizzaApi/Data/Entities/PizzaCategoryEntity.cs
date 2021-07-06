namespace PizzaApi.Data.Entities
{
    public class PizzaCategoryEntity
    {
        public int PizzaId { get; set; }
        public virtual PizzaEntity Pizza { get; set; } = null!;

        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; } = null!;
    }
}