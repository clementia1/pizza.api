using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaApi.Configuration;
using PizzaApi.Filters;
using PizzaApi.Models.GetById;
using PizzaApi.Models.GetByPage;
using PizzaApi.Models.GetBySlug;
using PizzaApi.Services.Abstractions;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PizzaBffController : ControllerBase
    {
        private readonly ILogger<PizzaBffController> _logger;
        private readonly IPizzaService _pizzaService;
        private readonly Config _config;

        public PizzaBffController(
            ILogger<PizzaBffController> logger,
            IOptions<Config> config,
            IPizzaService pizzaService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
            _config = config.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _pizzaService.GetByIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var item = await _pizzaService.GetBySlugAsync(slug);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage(int page, int size)
        {
            var result = await _pizzaService.GetByPageAsync(page, size);
            return result is null ? NotFound() : Ok(result);
        }
    }
}