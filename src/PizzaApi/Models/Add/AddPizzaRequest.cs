using System;
using System.Collections.Generic;

namespace PizzaApi.Models.Add
{
    public class AddPizzaRequest
    {
        public string Name { get; set; } = null!;
        public string? Summary { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public string PreviewImageUrl { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public IReadOnlyCollection<IngredientDto>? Ingredients { get; set; }
    }
}