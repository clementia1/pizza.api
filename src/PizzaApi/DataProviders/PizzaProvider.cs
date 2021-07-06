using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaApi.Data;
using PizzaApi.Data.Entities;
using PizzaApi.DataProviders.Abstractions;
using PizzaApi.Models;

namespace PizzaApi.DataProviders
{
    public class PizzaProvider : IPizzaProvider
    {
        private readonly PizzasDbContext _pizzasDbContext;

        public PizzaProvider(PizzasDbContext pizzasDbContext)
        {
            _pizzasDbContext = pizzasDbContext;
        }

        public async Task<PizzaEntity> AddAsync(string name)
        {
            var result = await _pizzasDbContext.Pizzas.AddAsync(new PizzaEntity() { Name = name });
            await _pizzasDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<PizzaDto?> GetById(int id)
        {
            var result = await _pizzasDbContext.Pizzas.AsNoTracking()
                .Where(pizza => pizza.Id == id)
                .Select(pizza => new PizzaDto
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Slug = pizza.Slug,
                    Summary = pizza.Summary,
                    Price = pizza.Price,
                    Weight = pizza.Weight,
                    PreviewImageUrl = pizza.PreviewImageUrl,
                    ImageUrl = pizza.ImageUrl,
                    Ingredients = pizza.Ingredients.Select(pi => new IngredientDto
                    {
                        Id = pi.Ingredient.Id,
                        Name = pi.Ingredient.Name,
                        ImageUrl = pi.Ingredient.ImageUrl
                    }).ToList()
                }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<IReadOnlyCollection<PizzaDto?>> GetByPage(int pageNumber, int itemsOnPage)
        {
            var skippedItems = pageNumber <= 0 ? 0 : (pageNumber - 1) * itemsOnPage;

            var result = await _pizzasDbContext.Pizzas.AsNoTracking()
                .Skip(skippedItems).Take(itemsOnPage)
                .Select(pizza => new PizzaDto
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Slug = pizza.Slug,
                    Summary = pizza.Summary,
                    Price = pizza.Price,
                    Weight = pizza.Weight,
                    PreviewImageUrl = pizza.PreviewImageUrl,
                    ImageUrl = pizza.ImageUrl,
                    Ingredients = pizza.Ingredients.Select(pi => new IngredientDto
                    {
                        Id = pi.Ingredient.Id,
                        Name = pi.Ingredient.Name,
                        ImageUrl = pi.Ingredient.ImageUrl
                    }).ToList()
                }).ToListAsync();

            return result;
        }
    }
}