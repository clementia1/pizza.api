using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaApi.Data;
using PizzaApi.Data.Entities;
using PizzaApi.Models;

namespace PizzaApi.DataProviders.Abstractions
{
    public interface IPizzaProvider
    {
        Task<int> GetTotalCount();
        Task<PizzaEntity> AddAsync(PizzaEntity pizza);
        Task<PizzaEntity?> GetById(int id);
        Task<IReadOnlyCollection<PizzaEntity?>> GetByPage(int pageNumber, int itemsOnPage);
    }
}