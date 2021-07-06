using System.Collections.Generic;

namespace PizzaApi.Models
{
    public class GetPizzaPaginationResponse
    {
        public IReadOnlyCollection<PizzaDto?> Pizza { get; set; } = null!;
    }
}