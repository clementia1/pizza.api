using System;
using System.Collections.Generic;

namespace PizzaApi.Models
{
    public class PizzaDto
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
        public IReadOnlyCollection<IngredientDto> Ingredients { get; set; } = null!;
    }
}