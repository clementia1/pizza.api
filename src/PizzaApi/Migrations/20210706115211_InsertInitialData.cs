using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaApi.Migrations
{
    public partial class InsertInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO category(name) VALUES('Meat');
                                   INSERT INTO category(name) VALUES('Seafood');
                                   INSERT INTO category(name) VALUES('Vegetarian');
                                   INSERT INTO category(name) VALUES('Cheese');
                                   INSERT INTO category(name) VALUES('Mushrooms');
                                   INSERT INTO category(name) VALUES('Sausage');");

            migrationBuilder.Sql(@"INSERT INTO ingredient(name, image_url) VALUES('chicken fillet', '/assets/images/ingredients/chicken-fillet.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('dorblu', '/assets/images/ingredients/dorblu.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('pickles', '/assets/images/ingredients/pickles.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('hunting sausages', '/assets/images/ingredients/hunting-sausages.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('mozzarella', '/assets/images/ingredients/mozzarella.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('olives', '/assets/images/ingredients/olives.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('oregano', '/assets/images/ingredients/oregano.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('parmesan', '/assets/images/ingredients/parmesan.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('pineapple', '/assets/images/ingredients/pineapple.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('roast beef', '/assets/images/ingredients/roastbeef.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('salami', '/assets/images/ingredients/salami.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('russian cheese', '/assets/images/ingredients/russian-cheese.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('tuna sauce', '/assets/images/ingredients/tuna-sauce.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('parsley', '/assets/images/ingredients/parsley.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('canned tuna', '/assets/images/ingredients/canned-tuna.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('red onion', '/assets/images/ingredients/red-onion.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('bechamel sauce', '/assets/images/ingredients/bechamel-sauce.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('pepperoni', '/assets/images/ingredients/pepperoni.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('feta cheese', '/assets/images/ingredients/feta-cheese.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('sriracha sauce', '/assets/images/ingredients/sriracha-sauce.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('green olives', '/assets/images/ingredients/green-olives.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('bell pepper', '/assets/images/ingredients/bell-pepper.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('bacon', '/assets/images/ingredients/bacon.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('champignons', '/assets/images/ingredients/champignons.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('egg yolk', '/assets/images/ingredients/egg-yolk.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('salad', '/assets/images/ingredients/salad.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('pesto sauce', '/assets/images/ingredients/pesto-sauce.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('tomato sauce', '/assets/images/ingredients/tomato-sauce.webp');
                                   INSERT INTO ingredient(name, image_url) VALUES('broccoli', '/assets/images/ingredients/broccoli.webp');");

            migrationBuilder.Sql(@"INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Pepperoni', 'pepperoni', '/assets/images/pizza/pepperoni.webp', '/assets/images/pizza/pepperoni.webp', 195, 800);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Four Meat', 'four-meat', '/assets/images/pizza/four-meat.webp', '/assets/images/pizza/four-meat.webp', 219, 760);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Vegetarian', 'vegetarian', '/assets/images/pizza/vegetarian.webp', '/assets/images/pizza/vegetarian.webp', 179, 800);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Tuna', 'tuna', '/assets/images/pizza/tuna.webp', '/assets/images/pizza/tuna.webp', 219, 730);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Roast Beef and Tuna', 'roast-beef-and-tuna', '/assets/images/pizza/roast-beef-and-tuna.webp', '/assets/images/pizza/roast-beef-and-tuna.webp', 199, 720);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Holy Diablo', 'holy-diablo', '/assets/images/pizza/holy-diablo.webp', '/assets/images/pizza/holy-diablo.webp', 199, 870);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Capricciosa', 'capricciosa', '/assets/images/pizza/capricciosa.webp', '/assets/images/pizza/capricciosa.webp', 195, 900);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Carbonara', 'carbonara', '/assets/images/pizza/carbonara.webp', '/assets/images/pizza/carbonara.webp', 205, 850);
                                   INSERT INTO pizza(name, slug, image_url, preview_image_url, price, weight) VALUES('Four Cheese', 'four-cheese', '/assets/images/pizza/four-cheese.webp', '/assets/images/pizza/four-cheese.webp', 205, 750);");

            migrationBuilder.Sql(@"INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT ingredient_id FROM ingredient WHERE Name = 'salami'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT ingredient_id FROM ingredient WHERE Name = 'champignons'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT ingredient_id FROM ingredient WHERE Name = 'pesto sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tomato sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'roast beef'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'chicken fillet'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'hunting sausages'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'salami'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'dorblu'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'parmesan'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'russian cheese'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tomato sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'feta cheese'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'broccoli'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'green olives'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'red onion'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'olives'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'bell pepper'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tomato sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'canned tuna'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'red onion'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'olives'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'bechamel sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tomato sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tuna sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'roast beef'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'parsley'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tomato sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'pepperoni'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'feta cheese'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'sriracha sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'hunting sausages'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'olives'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tomato sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'bacon'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'salami'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'green olives'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'pickles'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'champignons'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'parsley'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT ingredient_id FROM ingredient WHERE Name = 'tomato sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'bacon'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'chicken fillet'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'egg yolk'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'parmesan'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'salad'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'bechamel sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT ingredient_id FROM ingredient WHERE Name = 'dorblu'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT ingredient_id FROM ingredient WHERE Name = 'mozzarella'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT ingredient_id FROM ingredient WHERE Name = 'parmesan'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT ingredient_id FROM ingredient WHERE Name = 'russian cheese'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT ingredient_id FROM ingredient WHERE Name = 'bechamel sauce'));
                                   INSERT INTO pizza_ingredient(pizza_id, ingredient_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT ingredient_id FROM ingredient WHERE Name = 'oregano'));");

            migrationBuilder.Sql(@"INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT category_id FROM category WHERE Name = 'Mushrooms'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Pepperoni'), (SELECT category_id FROM category WHERE Name = 'Sausage'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT category_id FROM category WHERE Name = 'Meat'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT category_id FROM category WHERE Name = 'Sausage'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Meat'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT category_id FROM category WHERE Name = 'Vegetarian'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Vegetarian'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT category_id FROM category WHERE Name = 'Seafood'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Tuna'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT category_id FROM category WHERE Name = 'Meat'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT category_id FROM category WHERE Name = 'Seafood'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Roast Beef and Tuna'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Holy Diablo'), (SELECT category_id FROM category WHERE Name = 'Sausage'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT category_id FROM category WHERE Name = 'Mushrooms'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT category_id FROM category WHERE Name = 'Meat'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Capricciosa'), (SELECT category_id FROM category WHERE Name = 'Sausage'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT category_id FROM category WHERE Name = 'Meat'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Carbonara'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT category_id FROM category WHERE Name = 'Cheese'));
                                   INSERT INTO pizza_category(pizza_id, category_id) VALUES((SELECT pizza_id FROM pizza WHERE Name = 'Four Cheese'), (SELECT category_id FROM category WHERE Name = 'Vegetarian'));");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM pizza_ingredient");
            migrationBuilder.Sql("DELETE FROM category");
            migrationBuilder.Sql("DELETE FROM ingredient");
            migrationBuilder.Sql("DELETE FROM pizza");
        }
    }
}