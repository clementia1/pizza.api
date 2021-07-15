using AutoMapper;
using PizzaApi.Data.Entities;
using PizzaApi.Models;

namespace PizzaApi.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PizzaEntity, PizzaDto>()
                .ForMember(dto => dto.Ingredients, option => option.Ignore());
            CreateMap<IngredientEntity, IngredientDto>();
        }
    }
}