using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApi.Data.Entities;

namespace PizzaApi.Data.EntityConfigurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<IngredientEntity>
    {
        public void Configure(EntityTypeBuilder<IngredientEntity> builder)
        {
            builder.ToTable("ingredient").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("ingredient_id");
            builder.Property(i => i.Name).IsRequired().HasColumnName("name").HasMaxLength(100);
            builder.Property(i => i.ImageUrl).IsRequired().HasColumnName("image_url").HasMaxLength(255);
        }
    }
}