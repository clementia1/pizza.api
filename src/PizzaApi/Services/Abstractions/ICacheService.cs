using System;
using System.Threading.Tasks;
using PizzaApi.Data.Cache;

namespace PizzaApi.Services.Abstractions
{
    public interface ICacheService<TCacheEntity>
        where TCacheEntity : class, ICacheEntity
    {
        Task AddOrUpdateAsync(TCacheEntity entity, string userName);

        Task<TCacheEntity?> GetAsync(int id, string userName);

        Task RemoveAsync(int id, string userName);
    }
}