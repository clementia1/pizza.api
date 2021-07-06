﻿namespace PizzaApi.Models
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}