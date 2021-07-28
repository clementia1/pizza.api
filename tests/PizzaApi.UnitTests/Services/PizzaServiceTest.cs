using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PizzaApi.Services;
using PizzaApi.Services.Abstractions;
using Moq;
using PizzaApi.DataProviders.Abstractions;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using PizzaApi.Data;
using PizzaApi.Data.Entities;
using PizzaApi.Models;
using PizzaApi.Models.GetByPage;
using Xunit;

namespace PizzaApi.UnitTests.Services
{
    public class PizzaServiceTest
    {
        private readonly IPizzaService _pizzaService;
        private readonly Mock<IPizzaProvider> _pizzaProvider;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IDbContextWrapper<PizzasDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<PizzaService>> _logger; 

        public PizzaServiceTest()
        {
            _pizzaProvider = new Mock<IPizzaProvider>();
            _mapper = new Mock<IMapper>();
            _dbContextWrapper = new Mock<IDbContextWrapper<PizzasDbContext>>();
            _logger = new Mock<ILogger<PizzaService>>();
            
            _pizzaProvider.Setup(expression: x => x.GetById(It.Is<int>(i => i >= 0)))
                .ReturnsAsync(new PizzaEntity());

            _pizzaProvider.Setup(expression: x => x.GetByPage(
                    It.Is<int>(i => i >= 0), 
                    It.Is<int>(i => i >= 0)))
                .ReturnsAsync(new List<PizzaEntity?>());

            _pizzaService = new PizzaService(_dbContextWrapper.Object, _pizzaProvider.Object, _logger.Object, _mapper.Object);
        }
        
        [Fact]
        public async Task GetById_Success()
        {
            //arrange
            var id = 11;
            
            //act
            var response = await _pizzaService.GetByIdAsync(id);

            //assert
            response.Should().BeOfType<PizzaDto?>();
        }
        
        [Fact]
        public async Task GetById_Failure()
        {
            //arrange
            var id = -11;
            
            //act
            var response = await _pizzaService.GetByIdAsync(id);

            //assert
            response.Should().BeNull();
        }

        [Theory]
        [InlineData(1, 10)]
        public async Task GetByPage_Success(int pageNumber, int itemsOnPage)
        {
            var response = await _pizzaService.GetByPageAsync(pageNumber, itemsOnPage);

            response.Should().BeOfType<GetByPageResponse?>();
        }
        
        [Theory]
        [InlineData(-1, 10)]
        [InlineData(1, -10)]
        public async Task GetByPage_Failure(int pageNumber, int itemsOnPage)
        {
            var response = await _pizzaService.GetByPageAsync(pageNumber, itemsOnPage);

            response.Should().BeNull();
        }
    }
}