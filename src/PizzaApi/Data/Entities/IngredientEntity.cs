using System.Collections;
using System.Collections.Generic;

namespace PizzaApi.Data.Entities
{
    public class IngredientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public virtual ICollection<PizzaIngredientEntity> Pizzas { get; set; } = new List<PizzaIngredientEntity>();
    }
}