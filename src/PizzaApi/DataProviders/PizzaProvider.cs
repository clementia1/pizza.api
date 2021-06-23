using System;
using System.Threading.Tasks;
using PizzaApi.Data;
using PizzaApi.Data.Entities;
using PizzaApi.DataProviders.Abstractions;

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
    }
}