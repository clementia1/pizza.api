using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PizzaApi.Services;
using PizzaApi.Services.Abstractions;
using Moq;
using PizzaApi.DataProviders.Abstractions;
using FluentAssertions;
using PizzaApi.Data.Entities;
using PizzaApi.Models;
using Xunit;

namespace PizzaApi.UnitTests.Services
{
    public class PizzaServiceTest
    {
        private readonly IPizzaService _pizzaService;
        private readonly Mock<IPizzaProvider> _pizzaProvider;
        private readonly Mock<IMapper> _mapper;

        public PizzaServiceTest()
        {
            _pizzaProvider = new Mock<IPizzaProvider>();
            
            _pizzaProvider.Setup(expression: x => x.GetById(It.Is<int>(i => i >= 0)))
                .ReturnsAsync(new PizzaEntity());

            _pizzaProvider.Setup(expression: x => x.GetByPage(
                    It.Is<int>(i => i >= 0), 
                    It.Is<int>(i => i >= 0)))
                .ReturnsAsync(new List<PizzaDto?>());

            _pizzaService = new PizzaService(_pizzaProvider.Object, _mapper.Object);
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

            response.Should().BeOfType<GetPizzaPaginationResponse?>();
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