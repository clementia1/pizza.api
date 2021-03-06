// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PizzaApi.Data;

namespace PizzaApi.Migrations
{
    [DbContext(typeof(PizzasDbContext))]
    [Migration("20210706115135_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PizzaApi.Data.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.ToTable("category");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.IngredientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_ingredient");

                    b.ToTable("ingredient");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.PizzaCategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer")
                        .HasColumnName("pizza_id");

                    b.HasKey("CategoryId", "PizzaId")
                        .HasName("pk_pizza_category");

                    b.HasIndex("PizzaId")
                        .HasDatabaseName("ix_pizza_category_pizza_id");

                    b.ToTable("pizza_category");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.PizzaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("pizza_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("PreviewImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("preview_image_url");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("slug");

                    b.Property<string>("Summary")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("summary");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_pizza");

                    b.ToTable("pizza");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.PizzaIngredientEntity", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer")
                        .HasColumnName("pizza_id");

                    b.HasKey("IngredientId", "PizzaId")
                        .HasName("pk_pizza_ingredient");

                    b.HasIndex("PizzaId")
                        .HasDatabaseName("ix_pizza_ingredient_pizza_id");

                    b.ToTable("pizza_ingredient");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.PizzaCategoryEntity", b =>
                {
                    b.HasOne("PizzaApi.Data.Entities.CategoryEntity", "Category")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_pizza_category_category_category_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PizzaApi.Data.Entities.PizzaEntity", "Pizza")
                        .WithMany("Categories")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("fk_pizza_category_pizzas_pizza_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.PizzaIngredientEntity", b =>
                {
                    b.HasOne("PizzaApi.Data.Entities.IngredientEntity", "Ingredient")
                        .WithMany("Pizzas")
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("fk_pizza_ingredient_ingredient_ingredient_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PizzaApi.Data.Entities.PizzaEntity", "Pizza")
                        .WithMany("Ingredients")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("fk_pizza_ingredient_pizza_pizza_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.IngredientEntity", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaApi.Data.Entities.PizzaEntity", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
