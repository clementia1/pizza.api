using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PizzaApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    ingredient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ingredient", x => x.ingredient_id);
                });

            migrationBuilder.CreateTable(
                name: "pizza",
                columns: table => new
                {
                    pizza_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    summary = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    preview_image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pizza", x => x.pizza_id);
                });

            migrationBuilder.CreateTable(
                name: "pizza_category",
                columns: table => new
                {
                    pizza_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pizza_category", x => new { x.category_id, x.pizza_id });
                    table.ForeignKey(
                        name: "fk_pizza_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pizza_category_pizzas_pizza_id",
                        column: x => x.pizza_id,
                        principalTable: "pizza",
                        principalColumn: "pizza_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pizza_ingredient",
                columns: table => new
                {
                    pizza_id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pizza_ingredient", x => new { x.ingredient_id, x.pizza_id });
                    table.ForeignKey(
                        name: "fk_pizza_ingredient_ingredient_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredient",
                        principalColumn: "ingredient_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pizza_ingredient_pizza_pizza_id",
                        column: x => x.pizza_id,
                        principalTable: "pizza",
                        principalColumn: "pizza_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pizza_category_pizza_id",
                table: "pizza_category",
                column: "pizza_id");

            migrationBuilder.CreateIndex(
                name: "ix_pizza_ingredient_pizza_id",
                table: "pizza_ingredient",
                column: "pizza_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pizza_category");

            migrationBuilder.DropTable(
                name: "pizza_ingredient");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "pizza");
        }
    }
}
