using PizzaApi.Data;
using PizzaApi.Services;
using PizzaApi.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace PizzaApi.UnitTests.Mocks
{
    public class MockService : BaseDataService<PizzasDbContext>
    {
        public MockService(
            IDbContextWrapper<PizzasDbContext> dbContextWrapper,
            ILogger<MockService> logger)
            : base(dbContextWrapper, logger)
        {
        }

        public async Task RunWithException()
        {
            await ExecuteSafe<bool>(() =>
            {
                throw new Exception();
            });
        }

        public async Task RunWithoutException()
        {
            await ExecuteSafe<bool>(() =>
            {
                return Task.FromResult(true);
            });
        }
    }
}
