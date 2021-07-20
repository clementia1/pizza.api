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
    [Route("api/v1/[controller]")]
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
        public async Task<IActionResult> Add(AddPizzaRequest request)
        {
            var result = await _pizzaService.AddAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pizzaService.Delete(id);
            return Ok(result);
        }
    }
}