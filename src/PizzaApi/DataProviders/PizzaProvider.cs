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

        public async Task<PizzaEntity> AddAsync(PizzaEntity pizza)
        {
            var result = await _pizzasDbContext.Pizzas.AddAsync(pizza);
            await _pizzasDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<PizzaEntity?> GetById(int id)
        {
            return await _pizzasDbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyCollection<PizzaEntity?>> GetByPage(int page, int size)
        {
            var skippedItems = page <= 0 ? 0 : (page - 1) * size;

            var result = await _pizzasDbContext.Pizzas
                .Skip(skippedItems)
                .Take(size)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCount()
        {
            return await _pizzasDbContext.Pizzas.CountAsync();
        }
    }
}