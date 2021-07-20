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
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Ingredient.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Ingredient.Name))
                .ForMember(
                    dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.Ingredient.ImageUrl));

            CreateMap<AddPizzaRequest, PizzaEntity>()
                .AfterMap<SlugifyAction>();

            CreateMap<IngredientDto, IngredientEntity>();
            CreateMap<IngredientDto, PizzaIngredientEntity>()
                .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ingredient, opt => opt.MapFrom(src => src));
        }
    }
}