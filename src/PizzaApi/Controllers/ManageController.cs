using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaApi.Configuration;
using PizzaApi.Models.Add;
using PizzaApi.Services.Abstractions;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IPizzaService _pizzaService;
        private readonly Config _config;

        public ManageController(
            ILogger<ManageController> logger,
            IOptions<Config> config,
            IPizzaService pizzaService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
            _config = config.Value;
        }

        [HttpPost]
        public async Task<IActionResult> AddPizza(AddPizzaRequest request)
        {
            return Ok(await _pizzaService.AddAsync(request));
        }
    }
}