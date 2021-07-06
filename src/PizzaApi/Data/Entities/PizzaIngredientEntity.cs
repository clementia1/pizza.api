namespace PizzaApi.Data.Entities
{
    public class PizzaIngredientEntity
    {
        public int PizzaId { get; set; }
        public virtual PizzaEntity Pizza { get; set; } = null!;

        public int IngredientId { get; set; }
        public virtual IngredientEntity Ingredient { get; set; } = null!;
    }
}