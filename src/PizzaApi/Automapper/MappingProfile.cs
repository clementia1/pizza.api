using System.Collections.Generic;
using AutoMapper;
using PizzaApi.Data.Entities;
using PizzaApi.Models;
using PizzaApi.Models.Add;

namespace PizzaApi.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PizzaEntity, PizzaDto>();
            CreateMap<IngredientEntity, IngredientDto>();
            CreateMap<PizzaIngredientEntity, IngredientDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(pi => pi.Ingredient.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(pi => pi.Ingredient.Name))
                .ForMember(p => p.ImageUrl, opt => opt.MapFrom(pi => pi.Ingredient.ImageUrl));

            CreateMap<AddPizzaRequest, PizzaEntity>()
                .AfterMap<SlugifyAction>();
        }
    }
}