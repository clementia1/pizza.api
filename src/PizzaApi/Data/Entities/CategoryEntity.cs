using System.Collections.Generic;

namespace PizzaApi.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PizzaCategoryEntity> Pizzas { get; set; } = new List<PizzaCategoryEntity>();
    }
}