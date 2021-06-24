using System.Threading.Tasks;
using PizzaApi.Data.Cache;
using PizzaApi.DataProviders.Abstractions;
using PizzaApi.Models;
using PizzaApi.Services.Abstractions;

namespace PizzaApi.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaProvider _pizzaProvider;
        private readonly ICacheService<PizzaCacheEntity> _cacheService;

        public PizzaService(
            IPizzaProvider pizzaProvider,
            ICacheService<PizzaCacheEntity> cacheService)
        {
            _pizzaProvider = pizzaProvider;
            _cacheService = cacheService;
        }

        public async Task<AddPizzaResponse> AddAsync(string name)
        {
            var result = await _pizzaProvider.AddAsync(name);

            await _cacheService.AddOrUpdateAsync(new PizzaCacheEntity() { Id = result.Id, Name = name }, "userName");

            return new AddPizzaResponse() { Id = result.Id };
        }

        public async Task<GetPizzaResponse?> GetAsync(int id)
        {
            var result = await _pizzaProvider.GetById(id);

            return result is null ? null : new GetPizzaResponse() { Id = result.Id, Name = result.Name };
        }
    }
}