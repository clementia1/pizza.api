using System.Collections.Generic;

namespace PizzaApi.Models.GetByPage
{
    public class GetByPageResponse
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IReadOnlyCollection<PizzaDto?> Pizza { get; set; } = null!;
    }
}