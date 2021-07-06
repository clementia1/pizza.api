using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaApi.Configuration;
using PizzaApi.Filters;
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

        [ServiceFilter(typeof(RateLimitAsyncResourceFilter))]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _pizzaService.GetByIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        public async Task<IActionResult> GetByPage(int pageNumber, int itemsOnPage = 10)
        {
            var item = await _pizzaService.GetByPageAsync(pageNumber, itemsOnPage);
            return item is null ? NotFound() : Ok(item);
        }
    }
}