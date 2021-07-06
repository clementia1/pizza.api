using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaApi.Data;
using PizzaApi.Data.Entities;
using PizzaApi.Models;

namespace PizzaApi.DataProviders.Abstractions
{
    public interface IPizzaProvider
    {
        Task<PizzaEntity> AddAsync(string name);
        Task<PizzaEntity?> GetById(int id);
        Task<IReadOnlyCollection<PizzaDto?>> GetByPage(int pageNumber, int itemsOnPage);
    }
}