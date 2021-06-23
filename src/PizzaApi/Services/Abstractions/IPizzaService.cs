using System.Threading.Tasks;
using PizzaApi.Models;

namespace PizzaApi.Services.Abstractions
{
    public interface IPizzaService
    {
        Task<AddPizzaResponse> AddAsync(string name);
        Task<GetPizzaResponse?> GetAsync(int id);
    }
}