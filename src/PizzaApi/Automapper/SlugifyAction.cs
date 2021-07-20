using AutoMapper;
using PizzaApi.Data.Entities;
using PizzaApi.Models.Add;
using Slugify;

namespace PizzaApi.Automapper
{
    public class SlugifyAction : IMappingAction<AddPizzaRequest, PizzaEntity>
    {
        private readonly ISlugHelper _slugHelper;

        public SlugifyAction(ISlugHelper slugHelper)
        {
            _slugHelper = slugHelper;
        }

        public void Process(AddPizzaRequest source, PizzaEntity destination, ResolutionContext context)
        {
            var slug = _slugHelper.GenerateSlug(source.Name);
            destination.Slug = slug;
        }
    }
}