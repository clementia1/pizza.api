using System.Threading.Tasks;
using PizzaApi.Data;
using PizzaApi.Data.Entities;

namespace PizzaApi.DataProviders.Abstractions
{
    public interface IPizzaProvider
    {
        Task<PizzaEntity> AddAsync(string name);
    }
}