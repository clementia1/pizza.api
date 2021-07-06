using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApi.Data.Entities;

namespace PizzaApi.Data.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("category").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("category_id");
            builder.Property(c => c.Name).IsRequired().HasColumnName("name").HasMaxLength(100);
        }
    }
}