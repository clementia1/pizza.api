using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaApi.Models.Add;
using PizzaApi.Models.Delete;
using PizzaApi.Models.GetById;
using PizzaApi.Models.GetByPage;

namespace PizzaApi.Services.Abstractions
{
    public interface IPizzaService
    {
        Task<AddPizzaResponse> AddAsync(AddPizzaRequest request);
        Task<GetByIdResponse?> GetByIdAsync(int id);
        Task<GetByPageResponse?> GetByPageAsync(int pageNumber, int itemsOnPage);
        Task<DeletePizzaResponse?> Delete(int id);
    }
}