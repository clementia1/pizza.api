using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaApi.Configuration;
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
        public async Task<IActionResult> GetPizza(int id)
        {
            var item = await _pizzaService.GetAsync(id);
            return item is null ? NotFound() : Ok(item);
        }
    }
}