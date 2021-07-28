using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PizzaApi.Data;
using PizzaApi.Data.Cache;
using PizzaApi.Data.Entities;
using PizzaApi.DataProviders.Abstractions;
using PizzaApi.Models;
using PizzaApi.Models.Add;
using PizzaApi.Models.Delete;
using PizzaApi.Models.GetById;
using PizzaApi.Models.GetByPage;
using PizzaApi.Models.GetBySlug;
using PizzaApi.Services.Abstractions;

namespace PizzaApi.Services
{
    public class PizzaService : BaseDataService<PizzasDbContext>, IPizzaService
    {
        private readonly IPizzaProvider _pizzaProvider;
        private readonly IMapper _mapper;

        public PizzaService(
            IDbContextWrapper<PizzasDbContext> wrapper,
            IPizzaProvider pizzaProvider,
            ILogger<PizzaService> logger,
            IMapper mapper)
            : base(wrapper, logger)
        {
            _pizzaProvider = pizzaProvider;
            _mapper = mapper;
        }

        public async Task<AddPizzaResponse> AddAsync(AddPizzaRequest request)
        {
            return await ExecuteSafe(async () =>
            {
                var entity = _mapper.Map<PizzaEntity>(request);
                var result = await _pizzaProvider.AddAsync(entity);

                return new AddPizzaResponse() { Id = result.Id, Message = "Successfully added to database" };
            });
        }

        public async Task<GetByIdResponse?> GetByIdAsync(int id)
        {
            return await ExecuteSafe(async () =>
            {
                var entity = await _pizzaProvider.GetById(id);
                var dto = _mapper.Map<PizzaDto>(entity);

                return new GetByIdResponse { Pizza = dto };
            });
        }

        public async Task<GetBySlugResponse?> GetBySlugAsync(string slug)
        {
            return await ExecuteSafe(async () =>
            {
                var entity = await _pizzaProvider.GetBySlug(slug);
                var dto = _mapper.Map<PizzaDto>(entity);

                return new GetBySlugResponse { Pizza = dto };
            });
        }

        public async Task<GetByPageResponse?> GetByPageAsync(int page, int size)
        {
            return await ExecuteSafe(async () =>
            {
                var entities = await _pizzaProvider.GetByPage(page, size);
                var totalCount = await _pizzaProvider.GetTotalCount();
                var totalPages = (int)Math.Ceiling((double)totalCount / size);
                var dtoCollection = _mapper.Map<IReadOnlyCollection<PizzaDto>>(entities);

                return new GetByPageResponse()
                {
                    TotalItems = totalCount,
                    TotalPages = totalPages,
                    CurrentPage = page,
                    Pizza = dtoCollection
                };
            });
        }

        public async Task<DeletePizzaResponse?> Delete(int id)
        {
            return await ExecuteSafe(async () =>
            {
                var result = await _pizzaProvider.Delete(id);
                return result is null
                    ? new DeletePizzaResponse { Message = "Item not found" }
                    : new DeletePizzaResponse { Id = result.Id, Message = "Successfully removed from database" };
            });
        }
    }
}