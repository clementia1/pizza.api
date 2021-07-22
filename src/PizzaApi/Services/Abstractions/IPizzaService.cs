using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaApi.Models.Add;
using PizzaApi.Models.Delete;
using PizzaApi.Models.GetById;
using PizzaApi.Models.GetByPage;
using PizzaApi.Models.GetBySlug;

namespace PizzaApi.Services.Abstractions
{
    public interface IPizzaService
    {
        Task<AddPizzaResponse> AddAsync(AddPizzaRequest request);
        Task<GetByIdResponse?> GetByIdAsync(int id);
        Task<GetBySlugResponse?> GetBySlugAsync(string slug);
        Task<GetByPageResponse?> GetByPageAsync(int pageNumber, int itemsOnPage);
        Task<DeletePizzaResponse?> Delete(int id);
    }
}