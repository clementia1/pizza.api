using PizzaApi.Data;
using PizzaApi.Services.Abstractions;
using PizzaApi.UnitTests.Mocks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaApi.UnitTests.Services
{
    public class BaseDataServiceTest
    {
        private Mock<IDbContextWrapper<PizzasDbContext>> _dbContextWrapper;
        private Mock<IDbContextTransaction> _transaction;
        private Mock<ILogger<MockService>> _logger;
        private MockService _mockService;

        public BaseDataServiceTest()
        {
            _dbContextWrapper = new Mock<IDbContextWrapper<PizzasDbContext>>();
            _transaction = new Mock<IDbContextTransaction>();
            _logger = new Mock<ILogger<MockService>>();

            _dbContextWrapper.Setup(s => s.BeginTransaction()).Returns(_transaction.Object);

            _mockService = new MockService(_dbContextWrapper.Object, _logger.Object);
        }

        [Fact]
        public async Task ExecuteSafe_Success()
        {
            //arrange

            //act
            await _mockService.RunWithoutException();

            //assert
            _transaction.Verify(t => t.Commit(), Times.Once);
            _transaction.Verify(t => t.Rollback(), Times.Never);
        }

        [Fact]
        public async Task ExecuteSafe_Failed()
        {
            //arrange

            //act
            await _mockService.RunWithException();

            //assert
            _transaction.Verify(t => t.Commit(), Times.Never);
            _transaction.Verify(t => t.Rollback(), Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => o.ToString()
                        .Contains($"transaction is rollbacked")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}
