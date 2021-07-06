using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaApi.Models;

namespace PizzaApi.Services.Abstractions
{
    public interface IPizzaService
    {
        Task<AddPizzaResponse> AddAsync(string name);
        Task<PizzaDto?> GetByIdAsync(int id);
        Task<GetPizzaPaginationResponse?> GetByPageAsync(int pageNumber, int itemsOnPage);
    }
}