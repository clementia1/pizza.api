using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApi.Data.Entities;

namespace PizzaApi.Data.EntityConfigurations
{
    public class PizzaIngredientConfiguration : IEntityTypeConfiguration<PizzaIngredientEntity>
    {
        public void Configure(EntityTypeBuilder<PizzaIngredientEntity> builder)
        {
            builder.ToTable("pizza_ingredient").HasKey(pi => new { pi.IngredientId, pi.PizzaId });

            builder.HasOne(pi => pi.Ingredient)
                .WithMany(i => i.Pizzas)
                .HasForeignKey(pi => pi.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pi => pi.Pizza)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(pi => pi.PizzaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}