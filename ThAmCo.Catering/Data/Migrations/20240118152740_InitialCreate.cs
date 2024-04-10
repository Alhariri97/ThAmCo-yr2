using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Catering.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UnitPrice = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "FoodBookings",
                columns: table => new
                {
                    FoodBookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientReferenceId = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfGuests = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodBookingDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBookings", x => x.FoodBookingId);
                    table.ForeignKey(
                        name: "FK_FoodBookings_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuFoodItems",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuFoodItems", x => new { x.MenuId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuFoodItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 1, "Fresh vegetable salad with dressing", "Salad", 9.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 2, "Pasta with tomato sauce and assorted vegetables", "Pasta", 12.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 3, "Assorted vegetables grilled to perfection", "Vegetable Skewers", 11.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 4, "Pizza with a variety of vegetarian toppings", "Vegetarian Pizza", 14.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 5, "Quiche filled with spinach, mushrooms, and cheese", "Spinach and Mushroom Quiche", 13.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 6, "Baked eggplant with marinara sauce and cheese", "Eggplant Parmesan", 10.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 7, "Sushi roll with avocado, cucumber, and other veggies", "Vegetarian Sushi Roll", 16.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 8, "Assorted vegetables stir-fried in a savory sauce", "Vegetable Stir Fry", 9.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 9, "Tomatoes, mozzarella, and basil drizzled with balsamic glaze", "Caprese Salad", 8.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 10, "Plant-based burger with all the fixings", "Vegetarian Burger", 12.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 11, "Fresh salmon fillet grilled to perfection", "Grilled Salmon", 18.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 12, "Shrimp sautéed in garlic, butter, and white wine sauce", "Shrimp Scampi", 16.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 13, "Butter-poached lobster tail served with drawn butter", "Lobster Tail", 29.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 14, "Spanish rice dish with a mix of seafood, saffron, and vegetables", "Seafood Paella", 24.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 15, "Delicious crab cakes made with lump crab meat and spices", "Crab Cakes", 21.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 16, "Creamy soup with tender clams, potatoes, and vegetables", "Clam Chowder", 14.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 17, "Soft tacos filled with grilled fish, coleslaw, and salsa", "Fish Tacos", 12.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 18, "Mussels cooked in a flavorful marinara sauce", "Mussels Marinara", 17.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 19, "Assorted sushi rolls with fresh fish and rice", "Sushi Assortment", 23.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 20, "Oysters topped with a rich mixture of herbs, spinach, and breadcrumbs", "Oysters Rockefeller", 19.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 21, "Juicy beef steak cooked to your liking", "Beef Steak", 22.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 22, "Creamy Alfredo sauce with grilled chicken and pasta", "Chicken Alfredo Pasta", 17.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 23, "Tender pork ribs slow-cooked and glazed with barbecue sauce", "Pork Ribs", 19.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 24, "Spicy lamb curry with aromatic herbs and spices", "Lamb Curry", 20.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 25, "Shrimp wrapped in crispy bacon and grilled to perfection", "Bacon Wrapped Shrimp", 16.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 26, "Pizza topped with a variety of sausages and cheese", "Sausage Pizza", 14.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 27, "Burrito filled with seasoned beef, beans, and rice", "Beef Burrito", 12.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 28, "Spicy or BBQ chicken wings served with dipping sauce", "Chicken Wings", 11.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 29, "Soft tacos filled with grilled steak, onions, and cilantro", "Steak Tacos", 18.99f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "Name", "UnitPrice" },
                values: new object[] { 30, "Classic sandwich with ham, cheese, and fresh vegetables", "Ham and Cheese Sandwich", 9.99f });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[] { 1, "Vegetarian Menu" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[] { 2, "Non-Vegetarian Menu" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[] { 3, "Seafood Menu" });

            migrationBuilder.InsertData(
                table: "FoodBookings",
                columns: new[] { "FoodBookingId", "ClientReferenceId", "FoodBookingDate", "MenuId", "NumberOfGuests" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 19, 15, 27, 40, 571, DateTimeKind.Local).AddTicks(6737), 1, 1 });

            migrationBuilder.InsertData(
                table: "FoodBookings",
                columns: new[] { "FoodBookingId", "ClientReferenceId", "FoodBookingDate", "MenuId", "NumberOfGuests" },
                values: new object[] { 2, 2, new DateTime(2024, 1, 20, 15, 27, 40, 571, DateTimeKind.Local).AddTicks(6769), 2, 2 });

            migrationBuilder.InsertData(
                table: "FoodBookings",
                columns: new[] { "FoodBookingId", "ClientReferenceId", "FoodBookingDate", "MenuId", "NumberOfGuests" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 51 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 8, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 9, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 10, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 11, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 12, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 13, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 14, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 15, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 16, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 17, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 18, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 19, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 20, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 21, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 22, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 23, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 24, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 25, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 26, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 27, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 28, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 29, 3 });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[] { 30, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_FoodBookings_MenuId",
                table: "FoodBookings",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuFoodItems_FoodItemId",
                table: "MenuFoodItems",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodBookings");

            migrationBuilder.DropTable(
                name: "MenuFoodItems");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
