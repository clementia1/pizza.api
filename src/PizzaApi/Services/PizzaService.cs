using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaApi.Data.Cache;
using PizzaApi.Data.Entities;
using PizzaApi.DataProviders.Abstractions;
using PizzaApi.Models;
using PizzaApi.Services.Abstractions;

namespace PizzaApi.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaProvider _pizzaProvider;

        public PizzaService(IPizzaProvider pizzaProvider)
        {
            _pizzaProvider = pizzaProvider;
        }

        public async Task<AddPizzaResponse> AddAsync(string name)
        {
            var result = await _pizzaProvider.AddAsync(name);

            return new AddPizzaResponse() { Id = result.Id };
        }

        public async Task<PizzaDto?> GetByIdAsync(int id)
        {
            return await _pizzaProvider.GetById(id);
        }

        public async Task<GetPizzaPaginationResponse?> GetByPageAsync(int pageNumber, int itemsOnPage)
        {
            var result = await _pizzaProvider.GetByPage(pageNumber, itemsOnPage);

            return result is null ? null : new GetPizzaPaginationResponse { Pizza = result };
        }
    }
}