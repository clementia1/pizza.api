using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaApi.Data.Entities
{
    public class PizzaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Summary { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public string PreviewImageUrl { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<PizzaIngredientEntity> Ingredients { get; set; } = new List<PizzaIngredientEntity>();
        public virtual ICollection<PizzaCategoryEntity> Categories { get; set; } = new List<PizzaCategoryEntity>();
    }
}