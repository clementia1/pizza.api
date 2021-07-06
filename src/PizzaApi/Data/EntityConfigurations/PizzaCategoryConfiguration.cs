using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApi.Data.Entities;

namespace PizzaApi.Data.EntityConfigurations
{
    public class PizzaCategoryConfiguration : IEntityTypeConfiguration<PizzaCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<PizzaCategoryEntity> builder)
        {
            builder.ToTable("pizza_category").HasKey(pc => new { pc.CategoryId, pc.PizzaId });

            builder.HasOne(pc => pc.Category)
                .WithMany(c => c.Pizzas)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Pizza)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.PizzaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}