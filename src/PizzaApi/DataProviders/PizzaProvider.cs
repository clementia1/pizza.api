using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaApi.Automapper;
using PizzaApi.Data;
using PizzaApi.Data.Entities;
using PizzaApi.DataProviders.Abstractions;
using PizzaApi.Models;

namespace PizzaApi.DataProviders
{
    public class PizzaProvider : IPizzaProvider
    {
        private readonly PizzasDbContext _pizzasDbContext;
        private readonly IMapper _mapper;

        public PizzaProvider(
            PizzasDbContext pizzasDbContext,
            IMapper mapper)
        {
            _pizzasDbContext = pizzasDbContext;
            _mapper = mapper;
        }

        public async Task<PizzaEntity> AddAsync(string name)
        {
            var result = await _pizzasDbContext.Pizzas.AddAsync(new PizzaEntity() { Name = name });
            await _pizzasDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<PizzaEntity?> GetById(int id)
        {
            var result = await _pizzasDbContext.Pizzas
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IReadOnlyCollection<PizzaEntity?>> GetByPage(int pageNumber, int itemsOnPage)
        {
            var skippedItems = pageNumber <= 0 ? 0 : (pageNumber - 1) * itemsOnPage;

            var result = await _pizzasDbContext.Pizzas
                .Skip(skippedItems)
                .Take(itemsOnPage)
                .ToListAsync();

            return result;
        }
    }
}