using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApi.Data.Entities;

namespace PizzaApi.Data.EntityConfigurations
{
    public class PizzaConfiguration : IEntityTypeConfiguration<PizzaEntity>
    {
        public void Configure(EntityTypeBuilder<PizzaEntity> builder)
        {
            builder.ToTable("pizza").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("pizza_id");
            builder.Property(p => p.Name).IsRequired().HasColumnName("name").HasMaxLength(100);
            builder.Property(p => p.Slug).IsRequired().HasColumnName("slug").HasMaxLength(255);
            builder.Property(p => p.Summary).HasColumnName("summary").HasMaxLength(1000);
            builder.Property(p => p.ImageUrl).IsRequired().HasColumnName("image_url").HasMaxLength(255);
            builder.Property(p => p.PreviewImageUrl).IsRequired().HasColumnName("preview_image_url").HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired().HasColumnName("price").HasColumnType("money");
            builder.Property(p => p.Weight).IsRequired().HasColumnName("weight").HasColumnType("double precision");
            builder.Property(p => p.CreatedDate).IsRequired().HasColumnName("created_date").HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}