using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public PizzaService(
            IPizzaProvider pizzaProvider,
            IMapper mapper)
        {
            _pizzaProvider = pizzaProvider;
            _mapper = mapper;
        }

        public async Task<AddPizzaResponse> AddAsync(string name)
        {
            var result = await _pizzaProvider.AddAsync(name);

            return new AddPizzaResponse() { Id = result.Id };
        }

        public async Task<PizzaDto?> GetByIdAsync(int id)
        {
            var entity = await _pizzaProvider.GetById(id);
            return _mapper.Map<PizzaDto>(entity);
        }

        public async Task<GetPizzaPaginationResponse?> GetByPageAsync(int pageNumber, int itemsOnPage)
        {
            var result = await _pizzaProvider.GetByPage(pageNumber, itemsOnPage);

            return result is null ? null : new GetPizzaPaginationResponse { Pizza = result };
        }
    }
}